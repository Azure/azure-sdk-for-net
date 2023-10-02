namespace Azure.ResourceManager.Fleet
{
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.Fleet.FleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FleetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.FleetHubProfile HubProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.FleetProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class FleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Fleet.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetMemberResource GetFleetMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fleet.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetUpdateStrategyResource GetFleetUpdateStrategyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Fleet.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class FleetMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetMemberResource>, System.Collections.IEnumerable
    {
        protected FleetMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.Fleet.FleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.Fleet.FleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource> Get(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource>> GetAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetMemberResource> GetIfExists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetMemberResource>> GetIfExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.FleetMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.FleetMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetMemberData : Azure.ResourceManager.Models.ResourceData
    {
        public FleetMemberData() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Group { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FleetMemberResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetMemberResource() { }
        public virtual Azure.ResourceManager.Fleet.FleetMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.Fleet.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.Models.FleetCredentialResults> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.Models.FleetCredentialResults>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource> GetFleetMember(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetMemberResource>> GetFleetMemberAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Fleet.FleetMemberCollection GetFleetMembers() { throw null; }
        public virtual Azure.ResourceManager.Fleet.FleetUpdateStrategyCollection GetFleetUpdateStrategies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> GetFleetUpdateStrategy(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> GetFleetUpdateStrategyAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Fleet.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.Models.FleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetUpdateStrategyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>, System.Collections.IEnumerable
    {
        protected FleetUpdateStrategyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.Fleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.Fleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> Get(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> GetAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> GetIfExists(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> GetIfExistsAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetUpdateStrategyData : Azure.ResourceManager.Models.ResourceData
    {
        public FleetUpdateStrategyData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.UpdateStage> StrategyStages { get { throw null; } set { } }
    }
    public partial class FleetUpdateStrategyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetUpdateStrategyResource() { }
        public virtual Azure.ResourceManager.Fleet.FleetUpdateStrategyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateStrategyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.FleetUpdateStrategyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Fleet.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Fleet.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fleet.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fleet.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fleet.UpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fleet.UpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fleet.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fleet.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fleet.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.UpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateRunData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.ManagedClusterUpdate ManagedClusterUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateRunStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.UpdateStage> StrategyStages { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UpdateStrategyId { get { throw null; } set { } }
    }
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual Azure.ResourceManager.Fleet.UpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fleet.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource> Start(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource>> StartAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource> Stop(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource>> StopAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fleet.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fleet.UpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fleet.Models
{
    public partial class AgentProfile
    {
        public AgentProfile() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class APIServerAccessProfile
    {
        public APIServerAccessProfile() { }
        public bool? EnablePrivateCluster { get { throw null; } set { } }
        public bool? EnableVnetIntegration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public static partial class ArmFleetModelFactory
    {
        public static Azure.ResourceManager.Fleet.Models.FleetCredentialResult FleetCredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.FleetCredentialResults FleetCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.FleetCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Fleet.Models.FleetProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.FleetProvisioningState?), Azure.ResourceManager.Fleet.Models.FleetHubProfile hubProfile = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.FleetHubProfile FleetHubProfile(string dnsPrefix = null, Azure.ResourceManager.Fleet.Models.APIServerAccessProfile apiServerAccessProfile = null, Azure.ResourceManager.Fleet.Models.AgentProfile agentProfile = null, string fqdn = null, string kubernetesVersion = null, string portalFqdn = null) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetMemberData FleetMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.Core.ResourceIdentifier clusterResourceId = null, string group = null, Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Fleet.FleetUpdateStrategyData FleetUpdateStrategyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.UpdateStage> strategyStages = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.MemberUpdateStatus MemberUpdateStatus(Azure.ResourceManager.Fleet.Models.UpdateStatus status = null, string name = null, string clusterResourceId = null, string operationId = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.NodeImageVersion NodeImageVersion(string version = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateGroupStatus UpdateGroupStatus(Azure.ResourceManager.Fleet.Models.UpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.MemberUpdateStatus> members = null) { throw null; }
        public static Azure.ResourceManager.Fleet.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState? provisioningState = default(Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState?), Azure.Core.ResourceIdentifier updateStrategyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.UpdateStage> strategyStages = null, Azure.ResourceManager.Fleet.Models.ManagedClusterUpdate managedClusterUpdate = null, Azure.ResourceManager.Fleet.Models.UpdateRunStatus status = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateRunStatus UpdateRunStatus(Azure.ResourceManager.Fleet.Models.UpdateStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.UpdateStageStatus> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.NodeImageVersion> selectedNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateStageStatus UpdateStageStatus(Azure.ResourceManager.Fleet.Models.UpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fleet.Models.UpdateGroupStatus> groups = null, Azure.ResourceManager.Fleet.Models.WaitStatus afterStageWaitStatus = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateStatus UpdateStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Fleet.Models.UpdateState? state = default(Azure.ResourceManager.Fleet.Models.UpdateState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.WaitStatus WaitStatus(Azure.ResourceManager.Fleet.Models.UpdateStatus status = null, int? waitDurationInSeconds = default(int?)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Fleet.Models.FleetCredentialResult> Kubeconfigs { get { throw null; } }
    }
    public partial class FleetHubProfile
    {
        public FleetHubProfile() { }
        public Azure.ResourceManager.Fleet.Models.AgentProfile AgentProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.APIServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public string PortalFqdn { get { throw null; } }
    }
    public partial class FleetMemberPatch
    {
        public FleetMemberPatch() { }
        public string Group { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetMemberProvisioningState : System.IEquatable<Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetMemberProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Joining { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Leaving { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetMemberProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetPatch
    {
        public FleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetProvisioningState : System.IEquatable<Azure.ResourceManager.Fleet.Models.FleetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.FleetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.FleetProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.FleetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.FleetProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetUpdateStrategyProvisioningState : System.IEquatable<Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetUpdateStrategyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.Fleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedClusterUpdate
    {
        public ManagedClusterUpdate(Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeSpec upgrade) { }
        public Azure.ResourceManager.Fleet.Models.NodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeSpec Upgrade { get { throw null; } set { } }
    }
    public partial class ManagedClusterUpgradeSpec
    {
        public ManagedClusterUpgradeSpec(Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType upgradeType) { }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType UpgradeType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedClusterUpgradeType : System.IEquatable<Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedClusterUpgradeType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType Full { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType NodeImageOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType left, Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType left, Azure.ResourceManager.Fleet.Models.ManagedClusterUpgradeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemberUpdateStatus
    {
        internal MemberUpdateStatus() { }
        public string ClusterResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeImageSelectionType : System.IEquatable<Azure.ResourceManager.Fleet.Models.NodeImageSelectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeImageSelectionType(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.NodeImageSelectionType Consistent { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.NodeImageSelectionType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.NodeImageSelectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.NodeImageSelectionType left, Azure.ResourceManager.Fleet.Models.NodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.NodeImageSelectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.NodeImageSelectionType left, Azure.ResourceManager.Fleet.Models.NodeImageSelectionType right) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Fleet.Models.MemberUpdateStatus> Members { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateRunProvisioningState : System.IEquatable<Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState left, Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState left, Azure.ResourceManager.Fleet.Models.UpdateRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateRunStatus
    {
        internal UpdateRunStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Fleet.Models.NodeImageVersion> SelectedNodeImageVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Fleet.Models.UpdateStageStatus> Stages { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateStatus Status { get { throw null; } }
    }
    public partial class UpdateStage
    {
        public UpdateStage(string name) { }
        public int? AfterStageWaitInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Fleet.Models.UpdateGroup> Groups { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class UpdateStageStatus
    {
        internal UpdateStageStatus() { }
        public Azure.ResourceManager.Fleet.Models.WaitStatus AfterStageWaitStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Fleet.Models.UpdateGroupStatus> Groups { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateState : System.IEquatable<Azure.ResourceManager.Fleet.Models.UpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateState(string value) { throw null; }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Completed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Running { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Fleet.Models.UpdateState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fleet.Models.UpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fleet.Models.UpdateState left, Azure.ResourceManager.Fleet.Models.UpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fleet.Models.UpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fleet.Models.UpdateState left, Azure.ResourceManager.Fleet.Models.UpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateStatus
    {
        internal UpdateStatus() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Fleet.Models.UpdateState? State { get { throw null; } }
    }
    public partial class WaitStatus
    {
        internal WaitStatus() { }
        public Azure.ResourceManager.Fleet.Models.UpdateStatus Status { get { throw null; } }
        public int? WaitDurationInSeconds { get { throw null; } }
    }
}
