namespace Azure.ResourceManager.DatabaseFleetManager
{
    public static partial class DatabaseFleetManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource GetFleetMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.FleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.FleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FleetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile HubProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FleetMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>, System.Collections.IEnumerable
    {
        protected FleetMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.DatabaseFleetManager.FleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.DatabaseFleetManager.FleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> Get(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> GetAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> GetIfExists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> GetIfExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetMemberData : Azure.ResourceManager.Models.ResourceData
    {
        public FleetMemberData() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Group { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FleetMemberResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetMemberResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource> GetFleetMember(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetMemberResource>> GetFleetMemberAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetMemberCollection GetFleetMembers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.DatabaseFleetManager.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.DatabaseFleetManager.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateRunData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpdate ManagedClusterUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStage> StrategyStages { get { throw null; } set { } }
    }
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.UpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> Start(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> StartAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> Stop(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> StopAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseFleetManager.Models
{
    public partial class APIServerAccessProfile
    {
        public APIServerAccessProfile() { }
        public bool? EnablePrivateCluster { get { throw null; } set { } }
        public bool? EnableVnetIntegration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public static partial class ArmDatabaseFleetManagerModelFactory
    {
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResult FleetCredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults FleetCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState?), Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile hubProfile = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile FleetHubProfile(string dnsPrefix = null, Azure.ResourceManager.DatabaseFleetManager.Models.APIServerAccessProfile apiServerAccessProfile = null, Azure.Core.ResourceIdentifier agentSubnetId = null, string fqdn = null, string kubernetesVersion = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetMemberData FleetMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.Core.ResourceIdentifier clusterResourceId = null, string group = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus MemberUpdateStatus(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus status = null, string name = null, string clusterResourceId = null, string operationId = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion NodeImageVersion(string version = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateGroupStatus UpdateGroupStatus(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus> members = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStage> strategyStages = null, Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpdate managedClusterUpdate = null, Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunStatus status = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunStatus UpdateRunStatus(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStageStatus> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion> selectedNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStageStatus UpdateStageStatus(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateGroupStatus> groups = null, Azure.ResourceManager.DatabaseFleetManager.Models.WaitStatus afterStageWaitStatus = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus UpdateStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState? state = default(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.WaitStatus WaitStatus(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus status = null, int? waitDurationInSeconds = default(int?)) { throw null; }
    }
    public partial class FleetCredentialResult
    {
        internal FleetCredentialResult() { }
        public string Name { get { throw null; } }
        public byte[] Value { get { throw null; } }
    }
    public partial class FleetCredentialResults
    {
        internal FleetCredentialResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResult> Kubeconfigs { get { throw null; } }
    }
    public partial class FleetHubProfile
    {
        public FleetHubProfile() { }
        public Azure.Core.ResourceIdentifier AgentSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.APIServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    public partial class FleetMemberPatch
    {
        public FleetMemberPatch() { }
        public string Group { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetMemberProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetMemberProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Joining { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Leaving { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetPatch
    {
        public FleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterUpdate
    {
        public ManagedClusterUpdate(Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeSpec upgrade) { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeSpec Upgrade { get { throw null; } set { } }
    }
    public partial class ManagedClusterUpgradeSpec
    {
        public ManagedClusterUpgradeSpec(Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType upgradeType) { }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType UpgradeType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType Full { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType NodeImageOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType left, Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType left, Azure.ResourceManager.DatabaseFleetManager.Models.ManagedClusterUpgradeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemberUpdateStatus
    {
        internal MemberUpdateStatus() { }
        public string ClusterResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeImageSelectionType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeImageSelectionType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType Consistent { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType left, Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType left, Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeImageVersion
    {
        internal NodeImageVersion() { }
        public string Version { get { throw null; } }
    }
    public partial class UpdateGroup
    {
        public UpdateGroup(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class UpdateGroupStatus
    {
        internal UpdateGroupStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus> Members { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateRunProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.UpdateRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateRunStatus
    {
        internal UpdateRunStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion> SelectedNodeImageVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStageStatus> Stages { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus Status { get { throw null; } }
    }
    public partial class UpdateStage
    {
        public UpdateStage(string name) { }
        public int? AfterStageWaitInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateGroup> Groups { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class UpdateStageStatus
    {
        internal UpdateStageStatus() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.WaitStatus AfterStageWaitStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateGroupStatus> Groups { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Completed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Skipped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState left, Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState left, Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateStatus
    {
        internal UpdateStatus() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateState? State { get { throw null; } }
    }
    public partial class WaitStatus
    {
        internal WaitStatus() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.UpdateStatus Status { get { throw null; } }
        public int? WaitDurationInSeconds { get { throw null; } }
    }
}
