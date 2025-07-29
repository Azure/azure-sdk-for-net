namespace Azure.ResourceManager.StreamAnalytics
{
    public partial class AzureResourceManagerStreamAnalyticsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStreamAnalyticsContext() { }
        public static Azure.ResourceManager.StreamAnalytics.AzureResourceManagerStreamAnalyticsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamAnalyticsClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>
    {
        public StreamAnalyticsClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>
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
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> GetIfExists(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>> GetIfExistsAsync(string privateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>
    {
        public StreamAnalyticsPrivateEndpointData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>
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
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetIfExists(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetIfExistsAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>
    {
        public StreamingJobData(Azure.Core.AzureLocation location) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> GetIfExists(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>> GetIfExistsAsync(string functionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobFunctionData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>
    {
        public StreamingJobFunctionData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobFunctionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>
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
        Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> GetIfExists(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>> GetIfExistsAsync(string inputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobInputData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>
    {
        public StreamingJobInputData() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobInputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobInputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobInputResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>
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
        Azure.ResourceManager.StreamAnalytics.StreamingJobInputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobInputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobInputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> GetIfExists(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> GetIfExistsAsync(string outputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingJobOutputData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobOutputResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>
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
        Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus> Test(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>> TestAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>
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
        Azure.ResourceManager.StreamAnalytics.StreamingJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> GetIfExists(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> GetIfExistsAsync(string transformationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingJobTransformationData : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>
    {
        public StreamingJobTransformationData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public int? StreamingUnits { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> ValidStreamingUnits { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobTransformationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingJobTransformationResource() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName, string transformationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource> Update(Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource>> UpdateAsync(Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StreamAnalytics.Mocking
{
    public partial class MockableStreamAnalyticsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStreamAnalyticsArmClient() { }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource GetStreamAnalyticsClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsPrivateEndpointResource GetStreamAnalyticsPrivateEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobFunctionResource GetStreamingJobFunctionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobInputResource GetStreamingJobInputResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobOutputResource GetStreamingJobOutputResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobResource GetStreamingJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobTransformationResource GetStreamingJobTransformationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStreamAnalyticsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStreamAnalyticsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource>> GetStreamAnalyticsClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterCollection GetStreamAnalyticsClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJob(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.StreamingJobResource>> GetStreamingJobAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StreamAnalytics.StreamingJobCollection GetStreamingJobs() { throw null; }
    }
    public partial class MockableStreamAnalyticsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStreamAnalyticsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult> CompileQuerySubscription(Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>> CompileQuerySubscriptionAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery compileQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota> GetQuotasSubscriptions(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota> GetQuotasSubscriptionsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterResource> GetStreamAnalyticsClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobs(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StreamAnalytics.StreamingJobResource> GetStreamingJobsAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult> SampleInputSubscription(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>> SampleInputSubscriptionAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult> TestInputSubscription(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>> TestInputSubscriptionAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult> TestOutputSubscription(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>> TestOutputSubscriptionAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput testOutput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult> TestQuerySubscription(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>> TestQuerySubscriptionAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery testQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StreamAnalytics.Models
{
    public partial class AggregateFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>
    {
        public AggregateFunctionProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmStreamAnalyticsModelFactory
    {
        public static Azure.ResourceManager.StreamAnalytics.Models.AggregateFunctionProperties AggregateFunctionProperties(Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs = null, string outputDataType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding binding = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp LastOutputEventTimestamp(System.DateTimeOffset? lastOutputEventOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties ReferenceInputProperties(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization serialization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> diagnosticsConditions = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? compressionType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType?), string partitionKey = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? watermarkMode = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode?), Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource datasource = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties ScalarFunctionProperties(Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs = null, string outputDataType = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding binding = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.StreamAnalyticsClusterData StreamAnalyticsClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku sku = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob StreamAnalyticsClusterJob(Azure.Core.ResourceIdentifier id = null, int? streamingUnits = default(int?), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState? jobState = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties StreamAnalyticsClusterProperties(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? clusterId = default(System.Guid?), Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState? provisioningState = default(Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState?), int? capacityAllocated = default(int?), int? capacityAssigned = default(int?)) { throw null; }
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery StreamAnalyticsCompileQuery(string query = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput> inputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction> functions = null, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType jobType = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType), Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel? compatibilityLevel = default(Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel?)) { throw null; }
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
        public static Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery StreamAnalyticsTestQuery(Azure.ResourceManager.StreamAnalytics.StreamingJobData streamingJob = null, System.Uri writeUri = null, string path = null) { throw null; }
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
    public partial class AvroFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>
    {
        public AvroFormatSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.AvroFormatSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BlobReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobReferenceInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>
    {
        public BlobStreamInputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Container { get { throw null; } set { } }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public int? SourcePartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public string TimeFormat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.BlobStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CSharpFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>
    {
        public CSharpFunctionBinding() { }
        public string Class { get { throw null; } set { } }
        public string DllPath { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUpdateMode? UpdateMode { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CSharpFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>
    {
        public CSharpFunctionRetrieveDefaultDefinitionContent() { }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CSharpFunctionRetrieveDefaultDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CsvFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>
    {
        public CsvFormatSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding? Encoding { get { throw null; } set { } }
        public string FieldDelimiter { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CsvFormatSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomClrFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>
    {
        public CustomClrFormatSerialization() { }
        public string SerializationClassName { get { throw null; } set { } }
        public string SerializationDllPath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.CustomClrFormatSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeStoreOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DataLakeStoreOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DocumentDbOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>
    {
        public DocumentDbOutputDataSource() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string CollectionNamePattern { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string DocumentId { get { throw null; } set { } }
        public string PartitionKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.DocumentDbOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EMachineLearningStudioFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>
    {
        public EMachineLearningStudioFunctionBinding() { }
        public string ApiKey { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs Inputs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EMachineLearningStudioFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EventGridStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>
    {
        public EventGridStreamInputDataSource() { }
        public System.Collections.Generic.IList<string> EventTypes { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventGridEventSchemaType? Schema { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource Subscriber { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventGridStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubV2OutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2OutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventHubV2StreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.EventHubV2StreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FunctionOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>
    {
        public FunctionOutputDataSource() { }
        public string ApiKey { get { throw null; } set { } }
        public string FunctionAppName { get { throw null; } set { } }
        public string FunctionName { get { throw null; } set { } }
        public int? MaxBatchCount { get { throw null; } set { } }
        public int? MaxBatchSize { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FunctionRetrieveDefaultDefinitionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>
    {
        protected FunctionRetrieveDefaultDefinitionContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayMessageBusOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>
    {
        public GatewayMessageBusOutputDataSource() { }
        public string Topic { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayMessageBusStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>
    {
        public GatewayMessageBusStreamInputDataSource() { }
        public string Topic { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.GatewayMessageBusStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IoTHubStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>
    {
        public IoTHubStreamInputDataSource() { }
        public string ConsumerGroupName { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string IotHubNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.IoTHubStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JavaScriptFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>
    {
        public JavaScriptFunctionBinding() { }
        public string Script { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JavaScriptFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>
    {
        public JavaScriptFunctionRetrieveDefaultDefinitionContent() { }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JavaScriptFunctionRetrieveDefaultDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsonFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>
    {
        public JsonFormatSerialization() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerializationEncoding? Encoding { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.JsonOutputSerializationFormat? Format { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.JsonFormatSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LastOutputEventTimestamp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>
    {
        internal LastOutputEventTimestamp() { }
        public System.DateTimeOffset? LastOutputEventOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.LastOutputEventTimestamp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServiceFunctionBinding : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServiceFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>
    {
        public MachineLearningServiceFunctionRetrieveDefaultDefinitionContent() { }
        public string ExecuteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceFunctionRetrieveDefaultDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServiceInputColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>
    {
        public MachineLearningServiceInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceInputColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningServiceOutputColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>
    {
        public MachineLearningServiceOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningServiceOutputColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningStudioFunctionRetrieveDefaultDefinitionContent : Azure.ResourceManager.StreamAnalytics.Models.FunctionRetrieveDefaultDefinitionContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>
    {
        public MachineLearningStudioFunctionRetrieveDefaultDefinitionContent() { }
        public string ExecuteEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionUdfType? UdfType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioFunctionRetrieveDefaultDefinitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningStudioInputColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>
    {
        public MachineLearningStudioInputColumn() { }
        public string DataType { get { throw null; } set { } }
        public int? MapTo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningStudioInputs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>
    {
        public MachineLearningStudioInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputColumn> ColumnNames { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineLearningStudioOutputColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>
    {
        public MachineLearningStudioOutputColumn() { }
        public string DataType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.MachineLearningStudioOutputColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParquetFormatSerialization : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>
    {
        public ParquetFormatSerialization() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ParquetFormatSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSQLOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>
    {
        public PostgreSQLOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public int? MaxWriterCount { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PostgreSQLOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerBIOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.PowerBIOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RawOutputDatasource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>
    {
        public RawOutputDatasource() { }
        public System.Uri PayloadUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawOutputDatasource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RawReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>
    {
        public RawReferenceInputDataSource() { }
        public System.BinaryData Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawReferenceInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RawStreamInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>
    {
        public RawStreamInputDataSource() { }
        public System.BinaryData Payload { get { throw null; } set { } }
        public System.Uri PayloadUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.RawStreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ReferenceInputDataSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>
    {
        protected ReferenceInputDataSource() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReferenceInputProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>
    {
        public ReferenceInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource Datasource { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalarFunctionProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>
    {
        public ScalarFunctionProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScalarFunctionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScaleStreamingJobContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>
    {
        public ScaleStreamingJobContent() { }
        public int? StreamingUnits { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ScaleStreamingJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusQueueOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>
    {
        public ServiceBusQueueOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string QueueName { get { throw null; } set { } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemPropertyColumns { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusQueueOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusTopicOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>
    {
        public ServiceBusTopicOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyColumns { get { throw null; } }
        public string ServiceBusNamespace { get { throw null; } set { } }
        public string SharedAccessPolicyKey { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SystemPropertyColumns { get { throw null; } }
        public string TopicName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.ServiceBusTopicOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDatabaseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlDatabaseOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlReferenceInputDataSource : Azure.ResourceManager.StreamAnalytics.Models.ReferenceInputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SqlReferenceInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartStreamingJobContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>
    {
        public StartStreamingJobContent() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputStartMode? OutputStartMode { get { throw null; } set { } }
        public System.DateTimeOffset? OutputStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StartStreamingJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsClusterJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>
    {
        internal StreamAnalyticsClusterJob() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobState? JobState { get { throw null; } }
        public int? StreamingUnits { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>
    {
        public StreamAnalyticsClusterProperties() { }
        public int? CapacityAllocated { get { throw null; } }
        public int? CapacityAssigned { get { throw null; } }
        public System.Guid? ClusterId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsClusterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>
    {
        public StreamAnalyticsClusterSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSkuName? Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsClusterSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsCompileQuery : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>
    {
        public StreamAnalyticsCompileQuery(string query, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType jobType) { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobCompatibilityLevel? CompatibilityLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction> Functions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput> Inputs { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobType JobType { get { throw null; } }
        public string Query { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsCompileQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamAnalyticsDataSerialization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>
    {
        protected StreamAnalyticsDataSerialization() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>
    {
        internal StreamAnalyticsError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>
    {
        internal StreamAnalyticsErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsPrivateEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>
    {
        public StreamAnalyticsPrivateEndpointProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsPrivateLinkConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>
    {
        public StreamAnalyticsPrivateLinkConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsPrivateLinkServiceConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>
    {
        public StreamAnalyticsPrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsPrivateLinkServiceConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsQueryCompilationError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>
    {
        internal StreamAnalyticsQueryCompilationError() { }
        public int? EndColumn { get { throw null; } }
        public int? EndLine { get { throw null; } }
        public bool? IsGlobal { get { throw null; } }
        public string Message { get { throw null; } }
        public int? StartColumn { get { throw null; } }
        public int? StartLine { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsQueryCompilationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>
    {
        internal StreamAnalyticsQueryCompilationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Functions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Inputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Outputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryCompilationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsQueryFunction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>
    {
        public StreamAnalyticsQueryFunction(string name, string queryFunctionType, string bindingType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> inputs, Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput output) { }
        public string BindingType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } }
        public string OutputDataType { get { throw null; } }
        public string QueryFunctionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsQueryInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>
    {
        public StreamAnalyticsQueryInput(string name, string queryInputType) { }
        public string Name { get { throw null; } }
        public string QueryInputType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsQueryTestingResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>
    {
        internal StreamAnalyticsQueryTestingResult() { }
        public System.Uri OutputUri { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResultStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsQueryTestingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsResourceTestStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>
    {
        internal StreamAnalyticsResourceTestStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsResourceTestStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsSampleInputContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>
    {
        public StreamAnalyticsSampleInputContent() { }
        public string CompatibilityLevel { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DataLocalion { get { throw null; } set { } }
        public System.Uri EventsUri { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobInputData Input { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsSampleInputResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>
    {
        internal StreamAnalyticsSampleInputResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Diagnostics { get { throw null; } }
        public System.Uri EventsDownloadUri { get { throw null; } }
        public System.DateTimeOffset? LastArrivedOn { get { throw null; } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResultStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSampleInputResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>
    {
        public StreamAnalyticsStorageAccount() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsSubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>
    {
        public StreamAnalyticsSubResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsSubscriptionQuota : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>
    {
        public StreamAnalyticsSubscriptionQuota() { }
        public int? CurrentCount { get { throw null; } }
        public int? MaxCount { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsSubscriptionQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsTestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>
    {
        public StreamAnalyticsTestContent(Azure.ResourceManager.StreamAnalytics.StreamingJobInputData input) { }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobInputData Input { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsTestDatasourceResult : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsError, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>
    {
        internal StreamAnalyticsTestDatasourceResult() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResultStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestDatasourceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamAnalyticsTestOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>
    {
        public StreamAnalyticsTestOutput(Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData output) { }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobOutputData Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamAnalyticsTestQuery : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>
    {
        public StreamAnalyticsTestQuery(Azure.ResourceManager.StreamAnalytics.StreamingJobData streamingJob) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.StreamingJobData StreamingJob { get { throw null; } }
        public System.Uri WriteUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsTestQuery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamingJobDiagnosticCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>
    {
        internal StreamingJobDiagnosticCondition() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Since { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobExternal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>
    {
        public StreamingJobExternal() { }
        public string Container { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration RefreshConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount StorageAccount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobExternal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingJobFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>
    {
        protected StreamingJobFunctionBinding() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobFunctionInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>
    {
        public StreamingJobFunctionInput() { }
        public string DataType { get { throw null; } set { } }
        public bool? IsConfigurationParameter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobFunctionOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>
    {
        public StreamingJobFunctionOutput() { }
        public string DataType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingJobFunctionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>
    {
        protected StreamingJobFunctionProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionBinding Binding { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionInput> Inputs { get { throw null; } }
        public string OutputDataType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobFunctionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class StreamingJobInputProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>
    {
        protected StreamingJobInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingCompressionType? CompressionType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobDiagnosticCondition> DiagnosticsConditions { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsDataSerialization Serialization { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputWatermarkMode? WatermarkMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class StreamingJobOutputDataSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>
    {
        protected StreamingJobOutputDataSource() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamingJobOutputWatermarkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>
    {
        public StreamingJobOutputWatermarkProperties() { }
        public string MaxWatermarkDifferenceAcrossPartitions { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkMode? WatermarkMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputWatermarkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamingJobRefreshConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>
    {
        public StreamingJobRefreshConfiguration() { }
        public string DateFormat { get { throw null; } set { } }
        public string PathPattern { get { throw null; } set { } }
        public string RefreshInterval { get { throw null; } set { } }
        public Azure.ResourceManager.StreamAnalytics.Models.DataRefreshType? RefreshType { get { throw null; } set { } }
        public string TimeFormat { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobRefreshConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StreamingJobStorageAccount : Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsStorageAccount, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>
    {
        public StreamingJobStorageAccount() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamingJobStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class StreamInputDataSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>
    {
        protected StreamInputDataSource() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StreamInputProperties : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobInputProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>
    {
        public StreamInputProperties() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamInputDataSource Datasource { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.StreamInputProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynapseOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>
    {
        public SynapseOutputDataSource() { }
        public Azure.ResourceManager.StreamAnalytics.Models.StreamAnalyticsAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.SynapseOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TableOutputDataSource : Azure.ResourceManager.StreamAnalytics.Models.StreamingJobOutputDataSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>
    {
        public TableOutputDataSource() { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ColumnsToRemove { get { throw null; } }
        public string PartitionKey { get { throw null; } set { } }
        public string RowKey { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.StreamAnalytics.Models.TableOutputDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
