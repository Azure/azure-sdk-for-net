namespace Azure.ResourceManager.DeploymentManager
{
    public partial class ArtifactSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>, System.Collections.IEnumerable
    {
        protected ArtifactSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string artifactSourceName, Azure.ResourceManager.DeploymentManager.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string artifactSourceName, Azure.ResourceManager.DeploymentManager.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> Get(string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> GetAsync(string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactSourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArtifactSourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArtifactRoot { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.Authentication Authentication { get { throw null; } set { } }
        public string SourceType { get { throw null; } set { } }
    }
    public partial class ArtifactSourceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactSourceResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.ArtifactSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string artifactSourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeploymentManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource> GetArtifactSource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ArtifactSourceResource>> GetArtifactSourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string artifactSourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ArtifactSourceResource GetArtifactSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ArtifactSourceCollection GetArtifactSources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> GetRollout(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> GetRolloutAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.RolloutResource GetRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.RolloutCollection GetRollouts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ServiceTopologyResource GetServiceTopologyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> GetServiceTopologyResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> GetServiceTopologyResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceCollection GetServiceTopologyResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.ServiceUnitResource GetServiceUnitResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.StepResource GetStepResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> GetStepResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> GetStepResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeploymentManager.StepResourceCollection GetStepResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
    }
    public partial class RolloutCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.RolloutResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.RolloutResource>, System.Collections.IEnumerable
    {
        protected RolloutCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.RolloutResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.DeploymentManager.Models.RolloutCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.RolloutResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.DeploymentManager.Models.RolloutCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> Get(string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.RolloutResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.RolloutResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> GetAsync(string rolloutName, int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.RolloutResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.RolloutResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.RolloutResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.RolloutResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RolloutData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RolloutData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArtifactSourceId { get { throw null; } set { } }
        public string BuildVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.RolloutOperationInfo OperationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeploymentManager.Models.Service> Services { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeploymentManager.Models.StepGroup> StepGroups { get { throw null; } }
        public string TargetServiceTopologyId { get { throw null; } set { } }
        public int? TotalRetryAttempts { get { throw null; } }
    }
    public partial class RolloutResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RolloutResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.RolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rolloutName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> Get(int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> GetAsync(int? retryAttempt = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> Restart(bool? skipSucceeded = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> RestartAsync(bool? skipSucceeded = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.RolloutResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.RolloutResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.Models.RolloutCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.RolloutResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.Models.RolloutCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceTopologyName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> GetServiceUnitResource(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> GetServiceUnitResourceAsync(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceUnitResourceCollection GetServiceUnitResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.DeploymentManager.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.DeploymentManager.ServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceResourceData(Azure.Core.AzureLocation location, string targetLocation, string targetSubscriptionId) : base (default(Azure.Core.AzureLocation)) { }
        public string TargetLocation { get { throw null; } set { } }
        public string TargetSubscriptionId { get { throw null; } set { } }
    }
    public partial class ServiceTopologyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceTopologyResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceTopologyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource> GetServiceResource(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceResource>> GetServiceResourceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceResourceCollection GetServiceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceTopologyResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>, System.Collections.IEnumerable
    {
        protected ServiceTopologyResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceTopologyName, Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceTopologyName, Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> Get(string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>> GetAsync(string serviceTopologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceTopologyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceTopologyResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceTopologyResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArtifactSourceId { get { throw null; } set { } }
    }
    public partial class ServiceUnitResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceUnitResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceUnitResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceTopologyName, string serviceName, string serviceUnitName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceUnitResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.ServiceUnitResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceUnitResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>, System.Collections.IEnumerable
    {
        protected ServiceUnitResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceUnitName, Azure.ResourceManager.DeploymentManager.ServiceUnitResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceUnitName, Azure.ResourceManager.DeploymentManager.ServiceUnitResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> Get(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>> GetAsync(string serviceUnitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.ServiceUnitResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.ServiceUnitResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceUnitResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceUnitResourceData(Azure.Core.AzureLocation location, string targetResourceGroup, Azure.ResourceManager.DeploymentManager.Models.DeploymentMode deploymentMode) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DeploymentManager.Models.ServiceUnitArtifacts Artifacts { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.DeploymentMode DeploymentMode { get { throw null; } set { } }
        public string TargetResourceGroup { get { throw null; } set { } }
    }
    public partial class StepResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StepResource() { }
        public virtual Azure.ResourceManager.DeploymentManager.StepResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string stepName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.StepResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.StepResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.StepResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeploymentManager.StepResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StepResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.StepResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.StepResource>, System.Collections.IEnumerable
    {
        protected StepResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.StepResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.DeploymentManager.StepResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeploymentManager.StepResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string stepName, Azure.ResourceManager.DeploymentManager.StepResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource> Get(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeploymentManager.StepResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeploymentManager.StepResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeploymentManager.StepResource>> GetAsync(string stepName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeploymentManager.StepResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeploymentManager.StepResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeploymentManager.StepResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.StepResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StepResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StepResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DeploymentManager.Models.StepProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DeploymentManager.Models.StepProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.DeploymentManager.Mock
{
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.DeploymentManager.ArtifactSourceCollection GetArtifactSources() { throw null; }
        public virtual Azure.ResourceManager.DeploymentManager.RolloutCollection GetRollouts() { throw null; }
        public virtual Azure.ResourceManager.DeploymentManager.ServiceTopologyResourceCollection GetServiceTopologyResources() { throw null; }
        public virtual Azure.ResourceManager.DeploymentManager.StepResourceCollection GetStepResources() { throw null; }
    }
}
namespace Azure.ResourceManager.DeploymentManager.Models
{
    public partial class ApiKeyAuthentication : Azure.ResourceManager.DeploymentManager.Models.RestRequestAuthentication
    {
        public ApiKeyAuthentication(string name, Azure.ResourceManager.DeploymentManager.Models.RestAuthLocation @in, string value) { }
        public Azure.ResourceManager.DeploymentManager.Models.RestAuthLocation In { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public abstract partial class Authentication
    {
        protected Authentication() { }
    }
    public enum DeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public abstract partial class HealthCheckStepAttributes
    {
        protected HealthCheckStepAttributes(System.TimeSpan healthyStateDuration) { }
        public System.TimeSpan HealthyStateDuration { get { throw null; } set { } }
        public System.TimeSpan? MaxElasticDuration { get { throw null; } set { } }
        public System.TimeSpan? WaitDuration { get { throw null; } set { } }
    }
    public partial class HealthCheckStepProperties : Azure.ResourceManager.DeploymentManager.Models.StepProperties
    {
        public HealthCheckStepProperties(Azure.ResourceManager.DeploymentManager.Models.HealthCheckStepAttributes attributes) { }
        public Azure.ResourceManager.DeploymentManager.Models.HealthCheckStepAttributes Attributes { get { throw null; } set { } }
    }
    public partial class Identity
    {
        public Identity(string identityType, System.Collections.Generic.IEnumerable<string> identityIds) { }
        public System.Collections.Generic.IList<string> IdentityIds { get { throw null; } }
        public string IdentityType { get { throw null; } set { } }
    }
    public partial class Message
    {
        internal Message() { }
        public string MessageValue { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
    }
    public partial class PrePostStep
    {
        public PrePostStep(string stepId) { }
        public string StepId { get { throw null; } set { } }
    }
    public partial class ResourceOperation
    {
        internal ResourceOperation() { }
        public string OperationId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public enum RestAuthLocation
    {
        Query = 0,
        Header = 1,
    }
    public partial class RestHealthCheck
    {
        public RestHealthCheck(string name, Azure.ResourceManager.DeploymentManager.Models.RestRequest request) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.RestRequest Request { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.RestResponse Response { get { throw null; } set { } }
    }
    public partial class RestHealthCheckStepAttributes : Azure.ResourceManager.DeploymentManager.Models.HealthCheckStepAttributes
    {
        public RestHealthCheckStepAttributes(System.TimeSpan healthyStateDuration) : base (default(System.TimeSpan)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeploymentManager.Models.RestHealthCheck> HealthChecks { get { throw null; } }
    }
    public enum RestMatchQuantifier
    {
        All = 0,
        Any = 1,
    }
    public partial class RestRequest
    {
        public RestRequest(Azure.ResourceManager.DeploymentManager.Models.RestRequestMethod method, System.Uri uri, Azure.ResourceManager.DeploymentManager.Models.RestRequestAuthentication authentication) { }
        public Azure.ResourceManager.DeploymentManager.Models.RestRequestAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.RestRequestMethod Method { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public abstract partial class RestRequestAuthentication
    {
        protected RestRequestAuthentication() { }
    }
    public enum RestRequestMethod
    {
        GET = 0,
        Post = 1,
    }
    public partial class RestResponse
    {
        public RestResponse() { }
        public Azure.ResourceManager.DeploymentManager.Models.RestResponseRegex Regex { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SuccessStatusCodes { get { throw null; } }
    }
    public partial class RestResponseRegex
    {
        public RestResponseRegex() { }
        public System.Collections.Generic.IList<string> Matches { get { throw null; } }
        public Azure.ResourceManager.DeploymentManager.Models.RestMatchQuantifier? MatchQuantifier { get { throw null; } set { } }
    }
    public partial class RolloutCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RolloutCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.DeploymentManager.Models.Identity identity, string buildVersion, string targetServiceTopologyId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeploymentManager.Models.StepGroup> stepGroups) : base (default(Azure.Core.AzureLocation)) { }
        public string ArtifactSourceId { get { throw null; } set { } }
        public string BuildVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeploymentManager.Models.Identity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeploymentManager.Models.StepGroup> StepGroups { get { throw null; } }
        public string TargetServiceTopologyId { get { throw null; } set { } }
    }
    public partial class RolloutIdentityAuthentication : Azure.ResourceManager.DeploymentManager.Models.RestRequestAuthentication
    {
        public RolloutIdentityAuthentication() { }
    }
    public partial class RolloutOperationInfo
    {
        internal RolloutOperationInfo() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public int? RetryAttempt { get { throw null; } }
        public bool? SkipSucceededOnRetry { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class RolloutStep
    {
        internal RolloutStep() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeploymentManager.Models.Message> Messages { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DeploymentManager.Models.StepOperationInfo OperationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeploymentManager.Models.ResourceOperation> ResourceOperations { get { throw null; } }
        public string Status { get { throw null; } }
        public string StepGroup { get { throw null; } }
    }
    public partial class SasAuthentication : Azure.ResourceManager.DeploymentManager.Models.Authentication
    {
        public SasAuthentication() { }
        public System.Uri SasUri { get { throw null; } set { } }
    }
    public partial class Service : Azure.ResourceManager.DeploymentManager.Models.ServiceProperties
    {
        internal Service() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeploymentManager.Models.ServiceUnit> ServiceUnits { get { throw null; } }
    }
    public partial class ServiceProperties
    {
        internal ServiceProperties() { }
        public string TargetLocation { get { throw null; } }
        public string TargetSubscriptionId { get { throw null; } }
    }
    public partial class ServiceUnit : Azure.ResourceManager.DeploymentManager.Models.ServiceUnitProperties
    {
        internal ServiceUnit() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeploymentManager.Models.RolloutStep> Steps { get { throw null; } }
    }
    public partial class ServiceUnitArtifacts
    {
        public ServiceUnitArtifacts() { }
        public string ParametersArtifactSourceRelativePath { get { throw null; } set { } }
        public System.Uri ParametersUri { get { throw null; } set { } }
        public string TemplateArtifactSourceRelativePath { get { throw null; } set { } }
        public System.Uri TemplateUri { get { throw null; } set { } }
    }
    public partial class ServiceUnitProperties
    {
        internal ServiceUnitProperties() { }
        public Azure.ResourceManager.DeploymentManager.Models.ServiceUnitArtifacts Artifacts { get { throw null; } }
        public Azure.ResourceManager.DeploymentManager.Models.DeploymentMode DeploymentMode { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } }
    }
    public partial class StepGroup
    {
        public StepGroup(string name, string deploymentTargetId) { }
        public System.Collections.Generic.IList<string> DependsOnStepGroups { get { throw null; } }
        public string DeploymentTargetId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeploymentManager.Models.PrePostStep> PostDeploymentSteps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeploymentManager.Models.PrePostStep> PreDeploymentSteps { get { throw null; } }
    }
    public partial class StepOperationInfo
    {
        internal StepOperationInfo() { }
        public string CorrelationId { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public abstract partial class StepProperties
    {
        protected StepProperties() { }
    }
    public partial class WaitStepAttributes
    {
        public WaitStepAttributes(System.TimeSpan duration) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
    }
    public partial class WaitStepProperties : Azure.ResourceManager.DeploymentManager.Models.StepProperties
    {
        public WaitStepProperties(Azure.ResourceManager.DeploymentManager.Models.WaitStepAttributes attributes) { }
        public System.TimeSpan? AttributesDuration { get { throw null; } set { } }
    }
}
