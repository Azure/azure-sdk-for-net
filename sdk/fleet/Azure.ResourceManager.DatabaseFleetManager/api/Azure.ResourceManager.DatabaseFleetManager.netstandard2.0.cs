namespace Azure.ResourceManager.DatabaseFleetManager
{
    public partial class DatabaseFleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>, System.Collections.IEnumerable
    {
        protected DatabaseFleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseFleetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DatabaseFleetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile HubProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class DatabaseFleetManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetDatabaseFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource GetDatabaseFleetMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource GetDatabaseFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetCollection GetDatabaseFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource GetDatabaseFleetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DatabaseFleetMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>, System.Collections.IEnumerable
    {
        protected DatabaseFleetMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> Get(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> GetAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> GetIfExists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> GetIfExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseFleetMemberData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseFleetMemberData() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Group { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DatabaseFleetMemberResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseFleetMemberResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseFleetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseFleetResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource> GetDatabaseFleetMember(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberResource>> GetDatabaseFleetMemberAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberCollection GetDatabaseFleetMembers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> GetDatabaseFleetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> GetDatabaseFleetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunCollection GetDatabaseFleetUpdateRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseFleetUpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>, System.Collections.IEnumerable
    {
        protected DatabaseFleetUpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseFleetUpdateRunData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseFleetUpdateRunData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpdate ManagedClusterUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateStage> StrategyStages { get { throw null; } set { } }
    }
    public partial class DatabaseFleetUpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseFleetUpdateRunResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> Start(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> StartAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> Stop(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> StopAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseFleetManager.Models
{
    public static partial class ArmDatabaseFleetManagerModelFactory
    {
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData DatabaseFleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetProvisioningState?), Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile hubProfile = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetMemberData DatabaseFleetMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.Core.ResourceIdentifier clusterResourceId = null, string group = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetMemberProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetUpdateRunData DatabaseFleetUpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateStage> strategyStages = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpdate managedClusterUpdate = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunStatus status = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResult FleetCredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResults FleetCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetHubProfile FleetHubProfile(string dnsPrefix = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetApiServerAccessProfile apiServerAccessProfile = null, Azure.Core.ResourceIdentifier agentSubnetId = null, string fqdn = null, string kubernetesVersion = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateGroupStatus FleetUpdateGroupStatus(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus> members = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus FleetUpdateOperationStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState? state = default(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunStatus FleetUpdateRunStatus(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateStageStatus> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion> selectedNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateStageStatus FleetUpdateStageStatus(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateGroupStatus> groups = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetWaitStatus afterStageWaitStatus = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetWaitStatus FleetWaitStatus(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus status = null, int? waitDurationInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus MemberUpdateStatus(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus status = null, string name = null, Azure.Core.ResourceIdentifier clusterResourceId = null, string operationId = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion NodeImageVersion(string version = null) { throw null; }
    }
    public partial class DatabaseFleetMemberPatch
    {
        public DatabaseFleetMemberPatch() { }
        public string Group { get { throw null; } set { } }
    }
    public partial class DatabaseFleetPatch
    {
        public DatabaseFleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FleetApiServerAccessProfile
    {
        public FleetApiServerAccessProfile() { }
        public bool? EnablePrivateCluster { get { throw null; } set { } }
        public bool? EnableVnetIntegration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
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
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetApiServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
    }
    public partial class FleetManagedClusterUpdate
    {
        public FleetManagedClusterUpdate(Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeSpec upgrade) { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeSpec Upgrade { get { throw null; } set { } }
    }
    public partial class FleetManagedClusterUpgradeSpec
    {
        public FleetManagedClusterUpgradeSpec(Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType upgradeType) { }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType UpgradeType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetManagedClusterUpgradeType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetManagedClusterUpgradeType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType Full { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType NodeImageOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetManagedClusterUpgradeType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class FleetUpdateGroup
    {
        public FleetUpdateGroup(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class FleetUpdateGroupStatus
    {
        internal FleetUpdateGroupStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.MemberUpdateStatus> Members { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus Status { get { throw null; } }
    }
    public partial class FleetUpdateOperationStatus
    {
        internal FleetUpdateOperationStatus() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetUpdateRunProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetUpdateRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetUpdateRunStatus
    {
        internal FleetUpdateRunStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.NodeImageVersion> SelectedNodeImageVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateStageStatus> Stages { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus Status { get { throw null; } }
    }
    public partial class FleetUpdateStage
    {
        public FleetUpdateStage(string name) { }
        public int? AfterStageWaitInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateGroup> Groups { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class FleetUpdateStageStatus
    {
        internal FleetUpdateStageStatus() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetWaitStatus AfterStageWaitStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateGroupStatus> Groups { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetUpdateState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Completed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Skipped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Stopped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState left, Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetWaitStatus
    {
        internal FleetWaitStatus() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus Status { get { throw null; } }
        public int? WaitDurationInSeconds { get { throw null; } }
    }
    public partial class MemberUpdateStatus
    {
        internal MemberUpdateStatus() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetUpdateOperationStatus Status { get { throw null; } }
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
}
