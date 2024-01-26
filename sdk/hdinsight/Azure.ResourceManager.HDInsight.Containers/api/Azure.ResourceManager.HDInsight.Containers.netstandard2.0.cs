namespace Azure.ResourceManager.HDInsight.Containers
{
    public partial class HDInsightClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>
    {
        public HDInsightClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile> ComputeNodes { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>, System.Collections.IEnumerable
    {
        protected HDInsightClusterPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Get(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetIfExists(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetIfExistsAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HDInsightClusterPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>
    {
        public HDInsightClusterPoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile AksClusterProfile { get { throw null; } }
        public string AksManagedResourceGroupName { get { throw null; } }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile ComputeProfile { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterPoolResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> GetHDInsightCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetHDInsightClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterCollection GetHDInsightClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HDInsightClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HDInsightClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViews(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViewsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult> GetServiceConfigs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult> GetServiceConfigsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> RunJobClusterJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>> RunJobClusterJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HDInsightContainersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetHDInsightClusterPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource GetHDInsightClusterPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolCollection GetHDInsightClusterPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource GetHDInsightClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Containers.Mocking
{
    public partial class MockableHDInsightContainersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersArmClient() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource GetHDInsightClusterPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterResource GetHDInsightClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHDInsightContainersResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPool(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource>> GetHDInsightClusterPoolAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolCollection GetHDInsightClusterPools() { throw null; }
    }
    public partial class MockableHDInsightContainersSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHDInsightContainersSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult> CheckHDInsightNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>> CheckHDInsightNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion> GetAvailableClusterVersionsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolResource> GetHDInsightClusterPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Containers.Models
{
    public partial class AksClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>
    {
        internal AksClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile AksClusterAgentPoolIdentityProfile { get { throw null; } }
        public Azure.Core.ResourceIdentifier AksClusterResourceId { get { throw null; } }
        public string AksVersion { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmHDInsightContainersModelFactory
    {
        public static Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile AksClusterProfile(Azure.Core.ResourceIdentifier aksClusterResourceId = null, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile aksClusterAgentPoolIdentityProfile = null, string aksVersion = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem ClusterComponentItem(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile ClusterConnectivityProfile(string webFqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> ssh = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult ClusterInstanceViewResult(string name = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus> serviceStatuses = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus ClusterInstanceViewStatus(string ready = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob ClusterJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile ClusterPoolComputeProfile(string vmSize = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion ClusterPoolVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterPoolVersionValue = null, string aksVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile(string clusterVersion = null, string ossVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> components = null, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile identityProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile secretsProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> serviceConfigsProfiles = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile connectivityProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile logAnalyticsProfile = null, bool? isEnabled = default(bool?), Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile sshProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile autoscaleProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> kafkaProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile trinoProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> llapProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile flinkProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile sparkProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> stubProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> scriptActionProfiles = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent ClusterResizeContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? targetWorkerNodeCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult ClusterServiceConfigResult(string serviceName = null, string fileName = null, string content = null, string componentName = null, string serviceConfigListResultPropertiesType = null, string path = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customKeys = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity> defaultKeys = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity ClusterServiceConfigValueEntity(string value = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile ClusterSshProfile(int count = 0, string podPrefix = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties FlinkJobProperties(string jobName = null, string jobJarDirectory = null, string jarName = null, string entryClass = null, string args = null, string savePointName = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction? action = default(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction?), System.Collections.Generic.IDictionary<string, string> flinkConfiguration = null, string jobId = null, string status = null, string jobOutput = null, string actionResult = null, string lastSavePoint = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterData HDInsightClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus?), string clusterType = null, string deploymentId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile> computeNodes = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile clusterProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch HDInsightClusterPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile clusterProfile = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.HDInsightClusterPoolData HDInsightClusterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus?), string deploymentId = null, string managedResourceGroupName = null, string aksManagedResourceGroupName = null, string clusterPoolVersion = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile computeProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile aksClusterProfile = null, Azure.Core.ResourceIdentifier networkSubnetId = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile logAnalyticsProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion HDInsightClusterVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterType = null, string clusterVersion = null, string ossVersion = null, string clusterPoolVersion = null, bool? isPreview = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> components = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult HDInsightNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus HDInsightServiceStatus(string kind = null, string ready = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint SshConnectivityEndpoint(string endpoint = null) { throw null; }
    }
    public partial class AuthorizationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>
    {
        public AuthorizationProfile() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public System.Collections.Generic.IList<string> UserIds { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoscaleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>
    {
        public AutoscaleSchedule(System.DateTimeOffset startOn, System.DateTimeOffset endOn, int count, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> days) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> Days { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoscaleScheduleDay : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoscaleScheduleDay(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Friday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Monday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAutoscaleProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>
    {
        public ClusterAutoscaleProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType? AutoscaleType { get { throw null; } set { } }
        public int? GracefulDecommissionTimeout { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig LoadBasedConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig ScheduleBasedConfig { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterAutoscaleType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterAutoscaleType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType LoadBased { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType ScheduleBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterComponentItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>
    {
        internal ClusterComponentItem() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterComputeNodeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>
    {
        public ClusterComputeNodeProfile(string nodeProfileType, string vmSize, int count) { }
        public int Count { get { throw null; } set { } }
        public string NodeProfileType { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterConfigFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>
    {
        public ClusterConfigFile(string fileName) { }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding? Encoding { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterConnectivityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>
    {
        internal ClusterConnectivityProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> Ssh { get { throw null; } }
        public string WebFqdn { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInstanceViewResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>
    {
        internal ClusterInstanceViewResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus> ServiceStatuses { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>
    {
        internal ClusterInstanceViewStatus() { }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterJob : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>
    {
        public ClusterJob(Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ClusterJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>
    {
        protected ClusterJobProperties() { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLogAnalyticsApplicationLogs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>
    {
        public ClusterLogAnalyticsApplicationLogs() { }
        public bool? IsStdErrorEnabled { get { throw null; } set { } }
        public bool? IsStdOutEnabled { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterLogAnalyticsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>
    {
        public ClusterLogAnalyticsProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs ApplicationLogs { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsMetricsEnabled { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>
    {
        public ClusterPoolComputeProfile(string vmSize) { }
        public int? Count { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolLogAnalyticsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>
    {
        public ClusterPoolLogAnalyticsProfile(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterPoolVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>
    {
        public ClusterPoolVersion() { }
        public string AksVersion { get { throw null; } set { } }
        public string ClusterPoolVersionValue { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>
    {
        public ClusterProfile(string clusterVersion, string ossVersion, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile identityProfile, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> Components { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterConnectivityProfile ConnectivityProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile FlinkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile IdentityProfile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> KafkaProfile { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> LlapProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile SecretsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile SparkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile SshProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StubProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile TrinoProfile { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterResizeContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>
    {
        public ClusterResizeContent(Azure.Core.AzureLocation location) { }
        public int? TargetWorkerNodeCount { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>
    {
        public ClusterSecretReference(string referenceName, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType keyVaultObjectType, string keyVaultObjectName) { }
        public string KeyVaultObjectName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType KeyVaultObjectType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSecretsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>
    {
        public ClusterSecretsProfile(Azure.Core.ResourceIdentifier keyVaultResourceId) { }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference> Secrets { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>
    {
        public ClusterServiceConfig(string component, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> files) { }
        public string Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> Files { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>
    {
        internal ClusterServiceConfigResult() { }
        public string ComponentName { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomKeys { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity> DefaultKeys { get { throw null; } }
        public string FileName { get { throw null; } }
        public string Path { get { throw null; } }
        public string ServiceConfigListResultPropertiesType { get { throw null; } }
        public string ServiceName { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>
    {
        public ClusterServiceConfigsProfile(string serviceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> configs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> Configs { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterServiceConfigValueEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>
    {
        internal ClusterServiceConfigValueEntity() { }
        public string Description { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigValueEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterSshProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>
    {
        public ClusterSshProfile(int count) { }
        public int Count { get { throw null; } set { } }
        public string PodPrefix { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceRequirement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>
    {
        public ComputeResourceRequirement(float cpu, long memory) { }
        public float Cpu { get { throw null; } set { } }
        public long Memory { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkHiveCatalogOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>
    {
        public FlinkHiveCatalogOption(string metastoreDBConnectionPasswordSecret, string metastoreDBConnectionUriString, string metastoreDBConnectionUserName) { }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlinkJobAction : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlinkJobAction(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Cancel { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Delete { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction ListSavepoint { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction New { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Savepoint { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Start { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction StatelessUpdate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Stop { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction left, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction left, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlinkJobProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>
    {
        public FlinkJobProperties(string jobName) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction? Action { get { throw null; } set { } }
        public string ActionResult { get { throw null; } }
        public string Args { get { throw null; } set { } }
        public string EntryClass { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FlinkConfiguration { get { throw null; } }
        public string JarName { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string JobJarDirectory { get { throw null; } set { } }
        public string JobName { get { throw null; } set { } }
        public string JobOutput { get { throw null; } }
        public string LastSavePoint { get { throw null; } }
        public string SavePointName { get { throw null; } set { } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>
    {
        public FlinkProfile(Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile storage, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement jobManager, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement taskManager) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption CatalogOptionsHive { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement HistoryServer { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement JobManager { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile Storage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement TaskManager { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FlinkStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>
    {
        public FlinkStorageProfile(string storageUriString) { }
        public string Storagekey { get { throw null; } set { } }
        public string StorageUriString { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>
    {
        public HDInsightClusterPatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile ClusterProfile { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>
    {
        public HDInsightClusterPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightClusterVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>
    {
        public HDInsightClusterVersion() { }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> Components { get { throw null; } }
        public bool? IsPreview { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightClusterVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightComparisonOperator : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightComparisonOperator(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightComparisonRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>
    {
        public HDInsightComparisonRule(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator @operator, float threshold) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator Operator { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightContentEncoding : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightContentEncoding(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding Base64 { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightIdentityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>
    {
        public HDInsightIdentityProfile(Azure.Core.ResourceIdentifier msiResourceId, string msiClientId, string msiObjectId) { }
        public string MsiClientId { get { throw null; } set { } }
        public string MsiObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HDInsightNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>
    {
        internal HDInsightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HDInsightProvisioningStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HDInsightProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HDInsightServiceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>
    {
        internal HDInsightServiceStatus() { }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HiveCatalogOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>
    {
        public HiveCatalogOption(string catalogName, string metastoreDBConnectionPasswordSecret, string metastoreDBConnectionUriString, string metastoreDBConnectionUserName, string metastoreWarehouseDir) { }
        public string CatalogName { get { throw null; } set { } }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
        public string MetastoreWarehouseDir { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultObjectType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultObjectType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Certificate { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Key { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType Secret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType left, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType left, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBasedConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>
    {
        public LoadBasedConfig(int minNodes, int maxNodes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> scalingRules) { }
        public int? CooldownPeriod { get { throw null; } set { } }
        public int MaxNodes { get { throw null; } set { } }
        public int MinNodes { get { throw null; } set { } }
        public int? PollIntervalInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> ScalingRules { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleActionType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleActionType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ScaleDown { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ScaleUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType left, Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType left, Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScalingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>
    {
        public ScalingRule(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType actionType, int evaluationCount, string scalingMetric, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule comparisonRule) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule ComparisonRule { get { throw null; } set { } }
        public int EvaluationCount { get { throw null; } set { } }
        public string ScalingMetric { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleBasedConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>
    {
        public ScheduleBasedConfig(string timeZone, int defaultCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> schedules) { }
        public int DefaultCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> Schedules { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptActionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>
    {
        public ScriptActionProfile(string scriptActionProfileType, string name, string uriString, System.Collections.Generic.IEnumerable<string> services) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string ScriptActionProfileType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Services { get { throw null; } }
        public bool? ShouldPersist { get { throw null; } set { } }
        public int? TimeoutInMinutes { get { throw null; } set { } }
        public string UriString { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkMetastoreSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>
    {
        public SparkMetastoreSpec(string dbServerHost, string dbName, string dbUserName, string dbPasswordSecretName, string keyVaultId) { }
        public string DBName { get { throw null; } set { } }
        public string DBPasswordSecretName { get { throw null; } set { } }
        public string DBServerHost { get { throw null; } set { } }
        public string DBUserName { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public string ThriftUriString { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>
    {
        public SparkProfile() { }
        public string DefaultStorageUriString { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec MetastoreSpec { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin> Plugins { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SparkUserPlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>
    {
        public SparkUserPlugin(string path) { }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshConnectivityEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>
    {
        internal SshConnectivityEndpoint() { }
        public string Endpoint { get { throw null; } }
        Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoCoordinator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>
    {
        public TrinoCoordinator() { }
        public bool? HighAvailabilityEnabled { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>
    {
        public TrinoProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption> CatalogOptionsHive { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator Coordinator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin> Plugins { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig UserTelemetrySpecStorage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker Worker { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoTelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>
    {
        public TrinoTelemetryConfig() { }
        public string HivecatalogName { get { throw null; } set { } }
        public string HivecatalogSchema { get { throw null; } set { } }
        public int? PartitionRetentionInDays { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoUserPlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>
    {
        public TrinoUserPlugin() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrinoWorker : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>
    {
        public TrinoWorker() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatableClusterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>
    {
        public UpdatableClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile SshProfile { get { throw null; } set { } }
        Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
