namespace Azure.ResourceManager.HDInsight.Containers
{
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HDInsight.Containers.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.NodeProfile> ComputeNodes { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ClusterPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>, System.Collections.IEnumerable
    {
        protected ClusterPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.ClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterPoolName, Azure.ResourceManager.HDInsight.Containers.ClusterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> Get(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> GetAsync(string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesAksClusterProfile AksClusterProfile { get { throw null; } }
        public string AksManagedResourceGroupName { get { throw null; } }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesComputeProfile ComputeProfile { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ClusterPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterPoolResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.ClusterPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> GetCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> GetClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HDInsight.Containers.ClusterCollection GetClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.HDInsight.Containers.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterPoolName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> GetClusterJobsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViews(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult> GetInstanceViewsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigResult> GetServiceConfigs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigResult> GetServiceConfigsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource> Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob> RunJobClusterJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob>> RunJobClusterJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob clusterJob, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HDInsight.Containers.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HDInsightContainersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.NameAvailabilityResult> CheckNameAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.Models.NameAvailabilityResult>> CheckNameAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.HDInsight.Containers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion> GetAvailableClusterPoolVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersion> GetAvailableClusterVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersion> GetAvailableClusterVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> GetClusterPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource>> GetClusterPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource GetClusterPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.ClusterPoolCollection GetClusterPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> GetClusterPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HDInsight.Containers.ClusterPoolResource> GetClusterPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.HDInsight.Containers.Models
{
    public partial class AksClusterProfile
    {
        internal AksClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfileAksClusterAgentPoolIdentityProfile AksClusterAgentPoolIdentityProfile { get { throw null; } }
        public Azure.Core.ResourceIdentifier AksClusterResourceId { get { throw null; } }
        public string AksVersion { get { throw null; } }
    }
    public partial class AksClusterProfileAksClusterAgentPoolIdentityProfile : Azure.ResourceManager.HDInsight.Containers.Models.IdentityProfile
    {
        public AksClusterProfileAksClusterAgentPoolIdentityProfile(Azure.Core.ResourceIdentifier msiResourceId, string msiClientId, string msiObjectId) : base (default(Azure.Core.ResourceIdentifier), default(string), default(string)) { }
    }
    public static partial class ArmHDInsightContainersModelFactory
    {
        public static Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile AksClusterProfile(Azure.Core.ResourceIdentifier aksClusterResourceId = null, Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfileAksClusterAgentPoolIdentityProfile aksClusterAgentPoolIdentityProfile = null, string aksVersion = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentsItem ClusterComponentsItem(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.ClusterData ClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus?), string clusterType = null, string deploymentId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.NodeProfile> computeNodes = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile clusterProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewPropertiesStatus ClusterInstanceViewPropertiesStatus(string ready = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewResult ClusterInstanceViewResult(string name = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewPropertiesStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ServiceStatus> serviceStatuses = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus ClusterInstanceViewStatus(string ready = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterJob ClusterJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPatch ClusterPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile clusterProfile = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile ClusterPoolComputeProfile(string vmSize = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.ClusterPoolData ClusterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus? provisioningState = default(Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus?), string deploymentId = null, string managedResourceGroupName = null, string aksManagedResourceGroupName = null, string clusterPoolVersion = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesComputeProfile computeProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesAksClusterProfile aksClusterProfile = null, Azure.Core.ResourceIdentifier networkSubnetId = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesLogAnalyticsProfile logAnalyticsProfile = null, string status = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesAksClusterProfile ClusterPoolResourcePropertiesAksClusterProfile(Azure.Core.ResourceIdentifier aksClusterResourceId = null, Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfileAksClusterAgentPoolIdentityProfile aksClusterAgentPoolIdentityProfile = null, string aksVersion = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolResourcePropertiesComputeProfile ClusterPoolResourcePropertiesComputeProfile(string vmSize = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolVersion ClusterPoolVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterPoolVersionValue = null, string aksVersion = null, bool? isPreview = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterProfile ClusterProfile(string clusterVersion = null, string ossVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentsItem> components = null, Azure.ResourceManager.HDInsight.Containers.Models.IdentityProfile identityProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.SecretsProfile secretsProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> serviceConfigsProfiles = null, Azure.ResourceManager.HDInsight.Containers.Models.ConnectivityProfile connectivityProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile logAnalyticsProfile = null, bool? prometheusProfileEnabled = default(bool?), Azure.ResourceManager.HDInsight.Containers.Models.SshProfile sshProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleProfile autoscaleProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> kafkaProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile trinoProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> llapProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile flinkProfile = null, Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile sparkProfile = null, System.Collections.Generic.IDictionary<string, System.BinaryData> stubProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> scriptActionProfiles = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterResizeData ClusterResizeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? targetWorkerNodeCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ClusterVersion ClusterVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterType = null, string clusterVersionValue = null, string ossVersion = null, string clusterPoolVersion = null, bool? isPreview = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentsItem> components = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ConnectivityProfile ConnectivityProfile(string webFqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> ssh = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobProperties FlinkJobProperties(string jobName = null, string jobJarDirectory = null, string jarName = null, string entryClass = null, string args = null, string savePointName = null, Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction? action = default(Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction?), System.Collections.Generic.IDictionary<string, string> flinkConfiguration = null, string jobId = null, string status = null, string jobOutput = null, string actionResult = null, string lastSavePoint = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.NameAvailabilityResult NameAvailabilityResult(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigListResultValueEntity ServiceConfigListResultValueEntity(string value = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigResult ServiceConfigResult(string serviceName = null, string fileName = null, string content = null, string componentName = null, string serviceConfigListResultPropertiesType = null, string path = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customKeys = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigListResultValueEntity> defaultKeys = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ServiceStatus ServiceStatus(string kind = null, string ready = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint SshConnectivityEndpoint(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.SshProfile SshProfile(int count = 0, string podPrefix = null) { throw null; }
    }
    public partial class AuthorizationProfile
    {
        public AuthorizationProfile() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public System.Collections.Generic.IList<string> UserIds { get { throw null; } }
    }
    public partial class AutoscaleProfile
    {
        public AutoscaleProfile(bool enabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType? AutoscaleType { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public int? GracefulDecommissionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.LoadBasedConfig LoadBasedConfig { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScheduleBasedConfig ScheduleBasedConfig { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoscaleType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoscaleType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType LoadBased { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType ScheduleBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType left, Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterComponentsItem
    {
        internal ClusterComponentsItem() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ClusterConfigFile
    {
        public ClusterConfigFile(string fileName) { }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding? Encoding { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
    }
    public partial class ClusterInstanceViewPropertiesStatus : Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewStatus
    {
        internal ClusterInstanceViewPropertiesStatus() { }
    }
    public partial class ClusterInstanceViewResult
    {
        internal ClusterInstanceViewResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ServiceStatus> ServiceStatuses { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterInstanceViewPropertiesStatus Status { get { throw null; } }
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
        public bool? StdErrorEnabled { get { throw null; } set { } }
        public bool? StdOutEnabled { get { throw null; } set { } }
    }
    public partial class ClusterLogAnalyticsProfile
    {
        public ClusterLogAnalyticsProfile(bool enabled) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsApplicationLogs ApplicationLogs { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public bool? MetricsEnabled { get { throw null; } set { } }
    }
    public partial class ClusterPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.UpdatableClusterProfile ClusterProfile { get { throw null; } set { } }
    }
    public partial class ClusterPoolComputeProfile
    {
        public ClusterPoolComputeProfile(string vmSize) { }
        public int? Count { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ClusterPoolLogAnalyticsProfile
    {
        public ClusterPoolLogAnalyticsProfile(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
    }
    public partial class ClusterPoolPatch
    {
        public ClusterPoolPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ClusterPoolResourcePropertiesAksClusterProfile : Azure.ResourceManager.HDInsight.Containers.Models.AksClusterProfile
    {
        internal ClusterPoolResourcePropertiesAksClusterProfile() { }
    }
    public partial class ClusterPoolResourcePropertiesComputeProfile : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolComputeProfile
    {
        public ClusterPoolResourcePropertiesComputeProfile(string vmSize) : base (default(string)) { }
    }
    public partial class ClusterPoolResourcePropertiesLogAnalyticsProfile : Azure.ResourceManager.HDInsight.Containers.Models.ClusterPoolLogAnalyticsProfile
    {
        public ClusterPoolResourcePropertiesLogAnalyticsProfile(bool enabled) : base (default(bool)) { }
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
        public ClusterProfile(string clusterVersion, string ossVersion, Azure.ResourceManager.HDInsight.Containers.Models.IdentityProfile identityProfile, Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile authorizationProfile) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentsItem> Components { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ConnectivityProfile ConnectivityProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkProfile FlinkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.IdentityProfile IdentityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> KafkaProfile { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> LlapProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
        public bool? PrometheusProfileEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SecretsProfile SecretsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SparkProfile SparkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SshProfile SshProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StubProfile { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.TrinoProfile TrinoProfile { get { throw null; } set { } }
    }
    public partial class ClusterResizeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterResizeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? TargetWorkerNodeCount { get { throw null; } set { } }
    }
    public partial class ClusterServiceConfig
    {
        public ClusterServiceConfig(string component, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> files) { }
        public string Component { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterConfigFile> Files { get { throw null; } }
    }
    public partial class ClusterServiceConfigsProfile
    {
        public ClusterServiceConfigsProfile(string serviceName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> configs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfig> Configs { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
    }
    public partial class ClusterVersion : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterVersion() { }
        public string ClusterPoolVersion { get { throw null; } set { } }
        public string ClusterType { get { throw null; } set { } }
        public string ClusterVersionValue { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterComponentsItem> Components { get { throw null; } }
        public bool? IsPreview { get { throw null; } set { } }
        public string OssVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComparisonOperator : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComparisonOperator(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator left, Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComparisonRule
    {
        public ComparisonRule(Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator @operator, float threshold) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComparisonOperator Operator { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
    }
    public partial class ComputeResourceDefinition
    {
        public ComputeResourceDefinition(float cpu, long memory) { }
        public float Cpu { get { throw null; } set { } }
        public long Memory { get { throw null; } set { } }
    }
    public partial class ConnectivityProfile
    {
        internal ConnectivityProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HDInsight.Containers.Models.SshConnectivityEndpoint> Ssh { get { throw null; } }
        public string WebFqdn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentEncoding : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentEncoding(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding Base64 { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding left, Azure.ResourceManager.HDInsight.Containers.Models.ContentEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlinkHiveCatalogOption
    {
        public FlinkHiveCatalogOption(string metastoreDbConnectionPasswordSecret, string metastoreDbConnectionURL, string metastoreDbConnectionUserName) { }
        public string MetastoreDbConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDbConnectionURL { get { throw null; } set { } }
        public string MetastoreDbConnectionUserName { get { throw null; } set { } }
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
        public static Azure.ResourceManager.HDInsight.Containers.Models.FlinkJobAction NEW { get { throw null; } }
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
        public FlinkProfile(Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile storage, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceDefinition jobManager, Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceDefinition taskManager) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkHiveCatalogOption CatalogOptionsHive { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceDefinition HistoryServer { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceDefinition JobManager { get { throw null; } set { } }
        public int? NumReplicas { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.FlinkStorageProfile Storage { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComputeResourceDefinition TaskManager { get { throw null; } set { } }
    }
    public partial class FlinkStorageProfile
    {
        public FlinkStorageProfile(string storageUri) { }
        public string Storagekey { get { throw null; } set { } }
        public string StorageUri { get { throw null; } set { } }
    }
    public partial class HiveCatalogOption
    {
        public HiveCatalogOption(string catalogName, string metastoreDbConnectionPasswordSecret, string metastoreDbConnectionURL, string metastoreDbConnectionUserName, string metastoreWarehouseDir) { }
        public string CatalogName { get { throw null; } set { } }
        public string MetastoreDbConnectionPasswordSecret { get { throw null; } set { } }
        public string MetastoreDbConnectionURL { get { throw null; } set { } }
        public string MetastoreDbConnectionUserName { get { throw null; } set { } }
        public string MetastoreWarehouseDir { get { throw null; } set { } }
    }
    public partial class IdentityProfile
    {
        public IdentityProfile(Azure.Core.ResourceIdentifier msiResourceId, string msiClientId, string msiObjectId) { }
        public string MsiClientId { get { throw null; } set { } }
        public string MsiObjectId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsiResourceId { get { throw null; } set { } }
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
        public int? PollInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScalingRule> ScalingRules { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class NameAvailabilityResult
    {
        internal NameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NodeProfile
    {
        public NodeProfile(string nodeProfileType, string vmSize, int count) { }
        public int Count { get { throw null; } set { } }
        public string NodeProfileType { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStatus : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus left, Azure.ResourceManager.HDInsight.Containers.Models.ProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleActionType : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleActionType(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType Scaledown { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType Scaleup { get { throw null; } }
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
        public ScalingRule(Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType actionType, int evaluationCount, string scalingMetric, Azure.ResourceManager.HDInsight.Containers.Models.ComparisonRule comparisonRule) { }
        public Azure.ResourceManager.HDInsight.Containers.Models.ScaleActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ComparisonRule ComparisonRule { get { throw null; } set { } }
        public int EvaluationCount { get { throw null; } set { } }
        public string ScalingMetric { get { throw null; } set { } }
    }
    public partial class Schedule
    {
        public Schedule(string startTime, string endTime, int count, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay> days) { }
        public int Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay> Days { get { throw null; } }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class ScheduleBasedConfig
    {
        public ScheduleBasedConfig(string timeZone, int defaultCount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HDInsight.Containers.Models.Schedule> schedules) { }
        public int DefaultCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.Schedule> Schedules { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleDay : System.IEquatable<Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleDay(string value) { throw null; }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Friday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Monday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay left, Azure.ResourceManager.HDInsight.Containers.Models.ScheduleDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptActionProfile
    {
        public ScriptActionProfile(string scriptActionProfileType, string name, string uri, System.Collections.Generic.IEnumerable<string> services) { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string ScriptActionProfileType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Services { get { throw null; } }
        public bool? ShouldPersist { get { throw null; } set { } }
        public int? TimeoutInMinutes { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class SecretReference
    {
        public SecretReference(string referenceName, Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType keyVaultObjectType, string keyVaultObjectName) { }
        public string KeyVaultObjectName { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.KeyVaultObjectType KeyVaultObjectType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SecretsProfile
    {
        public SecretsProfile(Azure.Core.ResourceIdentifier keyVaultResourceId) { }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.SecretReference> Secrets { get { throw null; } }
    }
    public partial class ServiceConfigListResultValueEntity
    {
        internal ServiceConfigListResultValueEntity() { }
        public string Description { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ServiceConfigResult
    {
        internal ServiceConfigResult() { }
        public string ComponentName { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomKeys { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.HDInsight.Containers.Models.ServiceConfigListResultValueEntity> DefaultKeys { get { throw null; } }
        public string FileName { get { throw null; } }
        public string Path { get { throw null; } }
        public string ServiceConfigListResultPropertiesType { get { throw null; } }
        public string ServiceName { get { throw null; } }
    }
    public partial class ServiceStatus
    {
        internal ServiceStatus() { }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Ready { get { throw null; } }
    }
    public partial class SparkMetastoreSpec
    {
        public SparkMetastoreSpec(string dbServerHost, string dbName, string dbUserName, string dbPasswordSecretName, string keyVaultId) { }
        public string DbName { get { throw null; } set { } }
        public string DbPasswordSecretName { get { throw null; } set { } }
        public string DbServerHost { get { throw null; } set { } }
        public string DbUserName { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public string ThriftUri { get { throw null; } set { } }
    }
    public partial class SparkProfile
    {
        public SparkProfile() { }
        public string DefaultStorageUri { get { throw null; } set { } }
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
    public partial class SshProfile
    {
        public SshProfile(int count) { }
        public int Count { get { throw null; } set { } }
        public string PodPrefix { get { throw null; } }
    }
    public partial class TrinoCoordinator
    {
        public TrinoCoordinator() { }
        public bool? Enable { get { throw null; } set { } }
        public bool? HighAvailabilityEnabled { get { throw null; } set { } }
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
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class TrinoWorker
    {
        public TrinoWorker() { }
        public bool? Enable { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public bool? Suspend { get { throw null; } set { } }
    }
    public partial class UpdatableClusterProfile
    {
        public UpdatableClusterProfile() { }
        public Azure.ResourceManager.HDInsight.Containers.Models.AuthorizationProfile AuthorizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.AutoscaleProfile AutoscaleProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HDInsight.Containers.Models.ClusterLogAnalyticsProfile LogAnalyticsProfile { get { throw null; } set { } }
        public bool? PrometheusProfileEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ScriptActionProfile> ScriptActionProfiles { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HDInsight.Containers.Models.ClusterServiceConfigsProfile> ServiceConfigsProfiles { get { throw null; } }
        public Azure.ResourceManager.HDInsight.Containers.Models.SshProfile SshProfile { get { throw null; } set { } }
    }
}
