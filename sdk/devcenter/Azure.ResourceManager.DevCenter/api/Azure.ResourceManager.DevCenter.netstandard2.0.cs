namespace Azure.ResourceManager.DevCenter
{
    public partial class AttachedNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected AttachedNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedNetworkConnectionName, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedNetworkConnectionName, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Get(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedNetworkConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AttachedNetworkConnectionData() { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public string NetworkConnectionId { get { throw null; } set { } }
        public string NetworkConnectionLocation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class AttachedNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttachedNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string attachedNetworkConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.CatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.CatalogResource>, System.Collections.IEnumerable
    {
        protected CatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.CatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.CatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.CatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.CatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.CatalogResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.CatalogResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.CatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.CatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.CatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.CatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CatalogData : Azure.ResourceManager.Models.ResourceData
    {
        public CatalogData() { }
        public Azure.ResourceManager.DevCenter.Models.GitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.GitCatalog GitHub { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class CatalogResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.CatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Sync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.CatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.CatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.CatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.CatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevBoxDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>, System.Collections.IEnumerable
    {
        protected DevBoxDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devBoxDefinitionName, Azure.ResourceManager.DevCenter.DevBoxDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devBoxDefinitionName, Azure.ResourceManager.DevCenter.DevBoxDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Get(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevBoxDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevBoxDefinitionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevCenter.Models.ImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? ImageValidationStatus { get { throw null; } }
        public string OSStorageType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
    }
    public partial class DevBoxDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevBoxDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string devBoxDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevBoxDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>, System.Collections.IEnumerable
    {
        protected DevCenterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string devCenterName, Azure.ResourceManager.DevCenter.DevCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string devCenterName, Azure.ResourceManager.DevCenter.DevCenterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> Get(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public static partial class DevCenterExtensions
    {
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.CatalogResource GetCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCollection GetDevCenters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCentersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.EnvironmentTypeResource GetEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.GalleryResource GetGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageResource GetImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> GetNetworkConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> GetNetworkConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.NetworkConnectionResource GetNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.NetworkConnectionCollection GetNetworkConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.NetworkConnectionResource> GetNetworkConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.NetworkConnectionResource> GetNetworkConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.OperationStatus> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.OperationStatus>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.PoolResource GetPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> GetProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> GetProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource GetProjectEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectCollection GetProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectResource> GetProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectResource> GetProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.ScheduleResource GetScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetSkusBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetSkusBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionCollection GetAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource> GetCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.CatalogResource>> GetCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.CatalogCollection GetCatalogs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionCollection GetDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> GetEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> GetEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.EnvironmentTypeCollection GetEnvironmentTypes() { throw null; }
        public virtual Azure.ResourceManager.DevCenter.GalleryCollection GetGalleries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource> GetGallery(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource>> GetGalleryAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ImageResource> GetImages(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ImageResource> GetImagesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected EnvironmentTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.EnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.EnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnvironmentTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public EnvironmentTypeData() { }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EnvironmentTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.EnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource> Update(Azure.ResourceManager.DevCenter.Models.EnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.EnvironmentTypeResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.EnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.GalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.GalleryResource>, System.Collections.IEnumerable
    {
        protected GalleryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.GalleryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.GalleryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource> Get(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.GalleryResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.GalleryResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource>> GetAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.GalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.GalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.GalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.GalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryData : Azure.ResourceManager.Models.ResourceData
    {
        public GalleryData() { }
        public string GalleryResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class GalleryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryResource() { }
        public virtual Azure.ResourceManager.DevCenter.GalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.GalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageResource> GetImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageResource>> GetImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageCollection GetImages() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.GalleryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.GalleryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthCheckStatusDetailData : Azure.ResourceManager.Models.ResourceData
    {
        public HealthCheckStatusDetailData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.HealthCheck> HealthChecks { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class HealthCheckStatusDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthCheckStatusDetailResource() { }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageResource>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ImageResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ImageResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.ResourceData
    {
        public ImageData() { }
        public string Description { get { throw null; } }
        public string Offer { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration { get { throw null; } }
        public string Sku { get { throw null; } }
    }
    public partial class ImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> GetImageVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetImageVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionCollection GetImageVersions() { throw null; }
    }
    public partial class ImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.IEnumerable
    {
        protected ImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public ImageVersionData() { }
        public bool? ExcludeFromLatest { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public int? OSDiskImageSizeInGb { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
    }
    public partial class ImageVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageVersionResource() { }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName, string imageName, string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.NetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.NetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected NetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.NetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.NetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.NetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> Get(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.NetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.NetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> GetAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.NetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.NetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.NetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.NetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkConnectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public string NetworkingResourceGroupName { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class NetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.NetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetail() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunHealthChecks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunHealthChecksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.NetworkConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.NetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.NetworkConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.NetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.PoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.PoolResource>, System.Collections.IEnumerable
    {
        protected PoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.PoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.PoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.PoolResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.PoolResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.PoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.PoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.PoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.PoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PoolResource() { }
        public virtual Azure.ResourceManager.DevCenter.PoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource> GetSchedule(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource>> GetScheduleAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ScheduleCollection GetSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.PoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.PoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.PoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.PoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectAttachedNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected ProjectAttachedNetworkConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> Get(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectAttachedNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectAttachedNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string attachedNetworkConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProjectData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public string DevCenterId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ProjectDevBoxDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.IEnumerable
    {
        protected ProjectDevBoxDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> Get(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectDevBoxDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectDevBoxDefinitionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string devBoxDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectEnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected ProjectEnvironmentTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectEnvironmentTypeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProjectEnvironmentTypeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DeploymentTargetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.EnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.UserRoleAssignmentValue> UserRoleAssignments { get { throw null; } }
    }
    public partial class ProjectEnvironmentTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectEnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> Update(Azure.ResourceManager.DevCenter.Models.ProjectEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.ProjectEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.DevCenter.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.PoolResource> GetPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.PoolResource>> GetPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.PoolCollection GetPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetProjectAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetProjectAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionCollection GetProjectAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetProjectDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetProjectDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionCollection GetProjectDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource> GetProjectEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeResource>> GetProjectEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeCollection GetProjectEnvironmentTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.ProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ScheduleResource>, System.Collections.IEnumerable
    {
        protected ScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.ScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.ScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.ScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource> Get(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ScheduleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ScheduleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource>> GetAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public ScheduleData() { }
        public Azure.ResourceManager.DevCenter.Models.ScheduledFrequency? Frequency { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ScheduledType? TypePropertiesType { get { throw null; } set { } }
    }
    public partial class ScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduleResource() { }
        public virtual Azure.ResourceManager.DevCenter.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource> Get(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ScheduleResource>> GetAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.SchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.SchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevCenter.Models
{
    public partial class Capability
    {
        internal Capability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class CatalogPatch
    {
        public CatalogPatch() { }
        public Azure.ResourceManager.DevCenter.Models.GitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.GitCatalog GitHub { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DevBoxDefinitionPatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public DevBoxDefinitionPatch() { }
        public Azure.ResourceManager.DevCenter.Models.ImageReference ImageReference { get { throw null; } set { } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
    }
    public static partial class DevCenterModelFactory
    {
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData AttachedNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string networkConnectionId = null, string networkConnectionLocation = null, Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus?), Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.Capability Capability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.CatalogData CatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.GitCatalog gitHub = null, Azure.ResourceManager.DevCenter.Models.GitCatalog adoGit = null, string provisioningState = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.ImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, string provisioningState = null, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.ImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails DevCenterSkuDetails(string name = null, Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? tier = default(Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier?), string size = null, string family = null, int? capacity = default(int?), string resourceType = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.Capability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.DevCenter.Models.UsageUnit? unit = default(Azure.ResourceManager.DevCenter.Models.UsageUnit?), Azure.ResourceManager.DevCenter.Models.UsageName name = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentRole EnvironmentRole(string roleName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.EnvironmentTypeData EnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.GalleryData GalleryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string galleryResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheck HealthCheck(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? status = default(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string errorType = null, string recommendedAction = null, string additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData HealthCheckStatusDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.HealthCheck> healthChecks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageData ImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string publisher = null, string offer = null, string sku = null, Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration recommendedMachineConfiguration = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageReference ImageReference(string id = null, string exactVersion = null, string publisher = null, string offer = null, string sku = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionData ImageVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string namePropertiesName = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), bool? excludeFromLatest = default(bool?), int? osDiskImageSizeInGb = default(int?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.NetworkConnectionData NetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string subnetId = null, string domainName = null, string organizationUnit = null, string domainUsername = null, string domainPassword = null, string provisioningState = null, Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus?), string networkingResourceGroupName = null, Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.OperationStatus OperationStatus(string id = null, string name = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), float? percentComplete = default(float?), System.BinaryData properties = null, Azure.ResourceManager.DevCenter.Models.OperationStatusError error = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.OperationStatusError OperationStatusError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.PoolData PoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string devBoxDefinitionName = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.LicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.LicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectData ProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string devCenterId = null, string description = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectEnvironmentTypeData ProjectEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string deploymentTargetId = null, Azure.ResourceManager.DevCenter.Models.EnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.EnvironmentRole> roles = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.UserRoleAssignmentValue> userRoleAssignments = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration(Azure.ResourceManager.DevCenter.Models.ResourceRange memory = null, Azure.ResourceManager.DevCenter.Models.ResourceRange vCpus = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ResourceRange ResourceRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.ScheduleData ScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.ScheduledType? typePropertiesType = default(Azure.ResourceManager.DevCenter.Models.ScheduledType?), Azure.ResourceManager.DevCenter.Models.ScheduledFrequency? frequency = default(Azure.ResourceManager.DevCenter.Models.ScheduledFrequency?), string time = null, string timeZone = null, Azure.ResourceManager.DevCenter.Models.EnableStatus? state = default(Azure.ResourceManager.DevCenter.Models.EnableStatus?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.UsageName UsageName(string localizedValue = null, string value = null) { throw null; }
    }
    public partial class DevCenterPatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public DevCenterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class DevCenterSku
    {
        public DevCenterSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? Tier { get { throw null; } set { } }
    }
    public partial class DevCenterSkuDetails : Azure.ResourceManager.DevCenter.Models.DevCenterSku
    {
        public DevCenterSkuDetails(string name) : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.Capability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum DevCenterSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class DevCenterUsage
    {
        internal DevCenterUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.UsageUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainJoinType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DomainJoinType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainJoinType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType AzureADJoin { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType HybridAzureADJoin { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DomainJoinType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DomainJoinType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DomainJoinType left, Azure.ResourceManager.DevCenter.Models.DomainJoinType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.EnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.EnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.EnableStatus left, Azure.ResourceManager.DevCenter.Models.EnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.EnableStatus left, Azure.ResourceManager.DevCenter.Models.EnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentRole
    {
        public EnvironmentRole() { }
        public string Description { get { throw null; } }
        public string RoleName { get { throw null; } }
    }
    public partial class EnvironmentTypePatch
    {
        public EnvironmentTypePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class GitCatalog
    {
        public GitCatalog() { }
        public string Branch { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class HealthCheck
    {
        internal HealthCheck() { }
        public string AdditionalDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.HealthCheckStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthCheckStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.HealthCheckStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthCheckStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.HealthCheckStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.HealthCheckStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.HealthCheckStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.HealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.HealthCheckStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageReference
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class ImageValidationErrorDetails
    {
        internal ImageValidationErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageValidationStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ImageValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ImageValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus left, Azure.ResourceManager.DevCenter.Models.ImageValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.LicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.LicenseType WindowsClient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.LicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.LicenseType left, Azure.ResourceManager.DevCenter.Models.LicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.LicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.LicenseType left, Azure.ResourceManager.DevCenter.Models.LicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalAdminStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.LocalAdminStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalAdminStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.LocalAdminStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus left, Azure.ResourceManager.DevCenter.Models.LocalAdminStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkConnectionPatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public NetworkConnectionPatch() { }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.OperationStatusError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class OperationStatusError
    {
        internal OperationStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class PoolPatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public PoolPatch() { }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public string NetworkConnectionName { get { throw null; } set { } }
    }
    public partial class ProjectEnvironmentTypePatch
    {
        public ProjectEnvironmentTypePatch() { }
        public string DeploymentTargetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.EnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.UserRoleAssignmentValue> UserRoleAssignments { get { throw null; } }
    }
    public partial class ProjectPatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public ProjectPatch() { }
        public string Description { get { throw null; } set { } }
        public string DevCenterId { get { throw null; } set { } }
    }
    public partial class RecommendedMachineConfiguration
    {
        internal RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.ResourceRange Memory { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ResourceRange VCpus { get { throw null; } }
    }
    public partial class ResourceRange
    {
        internal ResourceRange() { }
        public int? Max { get { throw null; } }
        public int? Min { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledFrequency : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ScheduledFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ScheduledFrequency Daily { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ScheduledFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.ScheduledFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ScheduledFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.ScheduledFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.ScheduledType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ScheduledType StopDevBox { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.ScheduledType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.ScheduledType left, Azure.ResourceManager.DevCenter.Models.ScheduledType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.ScheduledType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.ScheduledType left, Azure.ResourceManager.DevCenter.Models.ScheduledType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchedulePatch : Azure.ResourceManager.DevCenter.Models.TrackedResourceUpdate
    {
        public SchedulePatch() { }
        public Azure.ResourceManager.DevCenter.Models.ScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.EnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class TrackedResourceUpdate
    {
        public TrackedResourceUpdate() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.DevCenter.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.UsageUnit left, Azure.ResourceManager.DevCenter.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.UsageUnit left, Azure.ResourceManager.DevCenter.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserRoleAssignmentValue
    {
        public UserRoleAssignmentValue() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.EnvironmentRole> Roles { get { throw null; } }
    }
}
