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
    public partial class HDInsightClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HDInsightClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComputeNodeProfile> ComputeNodes { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
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
    public partial class HDInsightClusterPoolData : Azure.ResourceManager.Models.TrackedResourceData
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
    public partial class AksClusterProfile
    {
        internal AksClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightIdentityProfile AksClusterAgentPoolIdentityProfile { get { throw null; } }
        public Azure.Core.ResourceIdentifier AksClusterResourceId { get { throw null; } }
        public string AksVersion { get { throw null; } }
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
    public partial class AuthorizationProfile
    {
        public AuthorizationProfile() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public System.Collections.Generic.IList<string> UserIds { get { throw null; } }
    }
    public partial class AutoscaleSchedule
    {
        public AutoscaleSchedule(System.DateTimeOffset startOn, System.DateTimeOffset endOn, int count, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> days) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleScheduleDay> Days { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
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
    public partial class ClusterAutoscaleProfile
    {
        public ClusterAutoscaleProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleType? AutoscaleType { get { throw null; } set { } }
        public int? GracefulDecommissionTimeout { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig LoadBasedConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig ScheduleBasedConfig { get { throw null; } set { } }
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
    public partial class ClusterComponentItem
    {
        internal ClusterComponentItem() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ClusterComputeNodeProfile
    {
        public ClusterComputeNodeProfile(string nodeProfileType, string vmSize, int count) { }
        public int Count { get { throw null; } set { } }
        public string NodeProfileType { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ClusterConfigFile
    {
        public ClusterConfigFile(string fileName) { }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightContentEncoding? Encoding { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
    }
    public partial class ClusterConnectivityProfile
    {
        internal ClusterConnectivityProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> Ssh { get { throw null; } }
        public string WebFqdn { get { throw null; } }
    }
    public partial class ClusterInstanceViewResult
    {
        internal ClusterInstanceViewResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.HDInsightServiceStatus> ServiceStatuses { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus Status { get { throw null; } }
    }
    public partial class ClusterInstanceViewStatus
    {
        internal ClusterInstanceViewStatus() { }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class ClusterJob : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterJob(Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties Properties { get { throw null; } set { } }
    }
    public abstract partial class ClusterJobProperties
    {
        protected ClusterJobProperties() { }
    }
    public partial class ClusterLogAnalyticsApplicationLogs
    {
        public ClusterLogAnalyticsApplicationLogs() { }
        public bool? IsStdErrorEnabled { get { throw null; } set { } }
        public bool? IsStdOutEnabled { get { throw null; } set { } }
    }
    public partial class ClusterLogAnalyticsProfile
    {
        public ClusterLogAnalyticsProfile(bool isEnabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs ApplicationLogs { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsMetricsEnabled { get { throw null; } set { } }
    }
    public partial class ClusterPoolComputeProfile
    {
        public ClusterPoolComputeProfile(string vmSize) { }
        public int? Count { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ClusterPoolLogAnalyticsProfile
    {
        public ClusterPoolLogAnalyticsProfile(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class ClusterPoolVersion : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterPoolVersion() { }
        public string AksVersion { get { throw null; } set { } }
        public string ClusterPoolVersionValue { get { throw null; } set { } }
        public bool? IsPreview { get { throw null; } set { } }
    }
    public partial class ClusterProfile
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
    }
    public partial class ClusterResizeContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterResizeContent(Azure.Core.AzureLocation location) { }
        public int? TargetWorkerNodeCount { get { throw null; } set { } }
    }
    public partial class ClusterSecretReference
    {
        public ClusterSecretReference(string referenceName, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType keyVaultObjectType, string keyVaultObjectName) { }
        public string KeyVaultObjectName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType KeyVaultObjectType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ClusterSecretsProfile
    {
        public ClusterSecretsProfile(Azure.Core.ResourceIdentifier keyVaultResourceId) { }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterSecretReference> Secrets { get { throw null; } }
    }
    public partial class ClusterServiceConfig
    {
        public ClusterServiceConfig(string component, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> files) { }
        public string Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> Files { get { throw null; } }
    }
    public partial class ClusterServiceConfigResult
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
    }
    public partial class ClusterServiceConfigsProfile
    {
        public ClusterServiceConfigsProfile(string serviceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> configs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> Configs { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
    }
    public partial class ClusterServiceConfigValueEntity
    {
        internal ClusterServiceConfigValueEntity() { }
        public string Description { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ClusterSshProfile
    {
        public ClusterSshProfile(int count) { }
        public int Count { get { throw null; } set { } }
        public string PodPrefix { get { throw null; } }
    }
    public partial class ComputeResourceRequirement
    {
        public ComputeResourceRequirement(float cpu, long memory) { }
        public float Cpu { get { throw null; } set { } }
        public long Memory { get { throw null; } set { } }
    }
    public partial class FlinkHiveCatalogOption
    {
        public FlinkHiveCatalogOption(string metastoreDBConnectionPasswordSecret, string metastoreDBConnectionUriString, string metastoreDBConnectionUserName) { }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
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
    public partial class FlinkJobProperties : Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties
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
    }
    public partial class FlinkProfile
    {
        public FlinkProfile(Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile storage, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement jobManager, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement taskManager) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption CatalogOptionsHive { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement HistoryServer { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement JobManager { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile Storage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceRequirement TaskManager { get { throw null; } set { } }
    }
    public partial class FlinkStorageProfile
    {
        public FlinkStorageProfile(string storageUriString) { }
        public string Storagekey { get { throw null; } set { } }
        public string StorageUriString { get { throw null; } set { } }
    }
    public partial class HDInsightClusterPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HDInsightClusterPatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile ClusterProfile { get { throw null; } set { } }
    }
    public partial class HDInsightClusterPoolPatch
    {
        public HDInsightClusterPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HDInsightClusterVersion : Azure.ResourceManager.Models.ResourceData
    {
        public HDInsightClusterVersion() { }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentItem> Components { get { throw null; } }
        public bool? IsPreview { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
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
    public partial class HDInsightComparisonRule
    {
        public HDInsightComparisonRule(Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator @operator, float threshold) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonOperator Operator { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
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
    public partial class HDInsightIdentityProfile
    {
        public HDInsightIdentityProfile(Azure.Core.ResourceIdentifier msiResourceId, string msiClientId, string msiObjectId) { }
        public string MsiClientId { get { throw null; } set { } }
        public string MsiObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
    }
    public partial class HDInsightNameAvailabilityContent
    {
        public HDInsightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class HDInsightNameAvailabilityResult
    {
        internal HDInsightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
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
    public partial class HDInsightServiceStatus
    {
        internal HDInsightServiceStatus() { }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
    }
    public partial class HiveCatalogOption
    {
        public HiveCatalogOption(string catalogName, string metastoreDBConnectionPasswordSecret, string metastoreDBConnectionUriString, string metastoreDBConnectionUserName, string metastoreWarehouseDir) { }
        public string CatalogName { get { throw null; } set { } }
        public string MetastoreDBConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDBConnectionUriString { get { throw null; } set { } }
        public string MetastoreDBConnectionUserName { get { throw null; } set { } }
        public string MetastoreWarehouseDir { get { throw null; } set { } }
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
    public partial class LoadBasedConfig
    {
        public LoadBasedConfig(int minNodes, int maxNodes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> scalingRules) { }
        public int? CooldownPeriod { get { throw null; } set { } }
        public int MaxNodes { get { throw null; } set { } }
        public int MinNodes { get { throw null; } set { } }
        public int? PollIntervalInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> ScalingRules { get { throw null; } }
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
    public partial class ScalingRule
    {
        public ScalingRule(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType actionType, int evaluationCount, string scalingMetric, Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule comparisonRule) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.HDInsightComparisonRule ComparisonRule { get { throw null; } set { } }
        public int EvaluationCount { get { throw null; } set { } }
        public string ScalingMetric { get { throw null; } set { } }
    }
    public partial class ScheduleBasedConfig
    {
        public ScheduleBasedConfig(string timeZone, int defaultCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> schedules) { }
        public int DefaultCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleSchedule> Schedules { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ScriptActionProfile
    {
        public ScriptActionProfile(string scriptActionProfileType, string name, string uriString, System.Collections.Generic.IEnumerable<string> services) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string ScriptActionProfileType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Services { get { throw null; } }
        public bool? ShouldPersist { get { throw null; } set { } }
        public int? TimeoutInMinutes { get { throw null; } set { } }
        public string UriString { get { throw null; } set { } }
    }
    public partial class SparkMetastoreSpec
    {
        public SparkMetastoreSpec(string dbServerHost, string dbName, string dbUserName, string dbPasswordSecretName, string keyVaultId) { }
        public string DBName { get { throw null; } set { } }
        public string DBPasswordSecretName { get { throw null; } set { } }
        public string DBServerHost { get { throw null; } set { } }
        public string DBUserName { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public string ThriftUriString { get { throw null; } set { } }
    }
    public partial class SparkProfile
    {
        public SparkProfile() { }
        public string DefaultStorageUriString { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkMetastoreSpec MetastoreSpec { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.SparkUserPlugin> Plugins { get { throw null; } }
    }
    public partial class SparkUserPlugin
    {
        public SparkUserPlugin(string path) { }
        public string Path { get { throw null; } set { } }
    }
    public partial class SshConnectivityEndpoint
    {
        internal SshConnectivityEndpoint() { }
        public string Endpoint { get { throw null; } }
    }
    public partial class TrinoCoordinator
    {
        public TrinoCoordinator() { }
        public bool? HighAvailabilityEnabled { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
    }
    public partial class TrinoProfile
    {
        public TrinoProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.HiveCatalogOption> CatalogOptionsHive { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoCoordinator Coordinator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.TrinoUserPlugin> Plugins { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoTelemetryConfig UserTelemetrySpecStorage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoWorker Worker { get { throw null; } set { } }
    }
    public partial class TrinoTelemetryConfig
    {
        public TrinoTelemetryConfig() { }
        public string HivecatalogName { get { throw null; } set { } }
        public string HivecatalogSchema { get { throw null; } set { } }
        public int? PartitionRetentionInDays { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class TrinoUserPlugin
    {
        public TrinoUserPlugin() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class TrinoWorker
    {
        public TrinoWorker() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
    }
    public partial class UpdatableClusterProfile
    {
        public UpdatableClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterAutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterSshProfile SshProfile { get { throw null; } set { } }
    }
}
