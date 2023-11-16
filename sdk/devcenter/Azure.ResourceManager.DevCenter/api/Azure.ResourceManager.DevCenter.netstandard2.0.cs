namespace Azure.ResourceManager.DevCenter
{
    public partial class AllowedEnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected AllowedEnvironmentTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AllowedEnvironmentTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public AllowedEnvironmentTypeData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AllowedEnvironmentTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AllowedEnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string environmentTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> GetIfExists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>> GetIfExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedNetworkConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AttachedNetworkConnectionData() { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkConnectionId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? NetworkConnectionLocation { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetIfExists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetIfExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevBoxDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevBoxDefinitionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ActiveImageReference { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? ImageValidationStatus { get { throw null; } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class DevCenterCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>, System.Collections.IEnumerable
    {
        protected DevCenterCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.DevCenter.DevCenterCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterCatalogData : Azure.ResourceManager.Models.ResourceData
    {
        public DevCenterCatalogData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? SyncState { get { throw null; } }
    }
    public partial class DevCenterCatalogResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterCatalogResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Sync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterResource> GetIfExists(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterResource>> GetIfExistsAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterData(Azure.Core.AzureLocation location) { }
        public System.Uri DevCenterUri { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DevCenterEnvironmentTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>, System.Collections.IEnumerable
    {
        protected DevCenterEnvironmentTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterEnvironmentTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public DevCenterEnvironmentTypeData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DevCenterEnvironmentTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterEnvironmentTypeResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> Update(Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentTypePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevCenterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> CheckDevCenterNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> CheckDevCenterNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource GetAllowedEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource GetDevCenterEnvironmentTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterGalleryResource GetDevCenterGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageResource GetDevCenterImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetDevCenterNetworkConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource GetDevCenterNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionCollection GetDevCenterNetworkConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus> GetDevCenterOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>> GetDevCenterOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolResource GetDevCenterPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetDevCenterProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectResource GetDevCenterProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectCollection GetDevCenterProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCollection GetDevCenters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCentersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleResource GetDevCenterScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DevCenterGalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>, System.Collections.IEnumerable
    {
        protected DevCenterGalleryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Get(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetIfExists(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetIfExistsAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterGalleryData : Azure.ResourceManager.Models.ResourceData
    {
        public DevCenterGalleryData() { }
        public Azure.Core.ResourceIdentifier GalleryResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DevCenterGalleryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterGalleryResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetDevCenterImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetDevCenterImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageCollection GetDevCenterImages() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.DevCenterGalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>, System.Collections.IEnumerable
    {
        protected DevCenterImageCollection() { }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterImageData : Azure.ResourceManager.Models.ResourceData
    {
        public DevCenterImageData() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration { get { throw null; } }
        public string Sku { get { throw null; } }
    }
    public partial class DevCenterImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterImageResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string devCenterName, string galleryName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> GetImageVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetImageVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionCollection GetImageVersions() { throw null; }
    }
    public partial class DevCenterNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected DevCenterNetworkConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkConnectionName, Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Get(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetIfExists(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetIfExistsAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterNetworkConnectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterNetworkConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevCenter.Models.DomainJoinType? DomainJoinType { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? HealthCheckStatus { get { throw null; } }
        public string NetworkingResourceGroupName { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class DevCenterNetworkConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterNetworkConnectionResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetail() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint> GetOutboundEnvironmentEndpoints(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint> GetOutboundEnvironmentEndpointsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunHealthChecks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunHealthChecksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterNetworkConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>, System.Collections.IEnumerable
    {
        protected DevCenterPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.DevCenterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevCenter.DevCenterPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterPoolData(Azure.Core.AzureLocation location) { }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> HealthStatusDetails { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
    }
    public partial class DevCenterPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterPoolResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetDevCenterSchedule(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetDevCenterScheduleAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleCollection GetDevCenterSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunHealthChecks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunHealthChecksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.DevCenterProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.DevCenter.DevCenterProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterProjectData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public System.Uri DevCenterUri { get { throw null; } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DevCenterProjectEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>, System.Collections.IEnumerable
    {
        protected DevCenterProjectEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string environmentTypeName, Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Get(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetIfExists(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetIfExistsAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterProjectEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevCenterProjectEnvironmentData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> UserRoleAssignments { get { throw null; } }
    }
    public partial class DevCenterProjectEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectEnvironmentResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string environmentTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> Update(Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> UpdateAsync(Azure.ResourceManager.DevCenter.Models.DevCenterProjectEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterProjectResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource> GetAllowedEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource>> GetAllowedEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeCollection GetAllowedEnvironmentTypes() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource> GetDevCenterPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterPoolResource>> GetDevCenterPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolCollection GetDevCenterPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource> GetDevCenterProjectEnvironment(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource>> GetDevCenterProjectEnvironmentAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentCollection GetDevCenterProjectEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetProjectAttachedNetworkConnection(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetProjectAttachedNetworkConnectionAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionCollection GetProjectAttachedNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetProjectDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetProjectDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionCollection GetProjectDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource> GetDevBoxDefinition(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevBoxDefinitionResource>> GetDevBoxDefinitionAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionCollection GetDevBoxDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource> GetDevCenterCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterCatalogResource>> GetDevCenterCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogCollection GetDevCenterCatalogs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource> GetDevCenterEnvironmentType(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource>> GetDevCenterEnvironmentTypeAsync(string environmentTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeCollection GetDevCenterEnvironmentTypes() { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryCollection GetDevCenterGalleries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource> GetDevCenterGallery(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterGalleryResource>> GetDevCenterGalleryAsync(string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImages(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterImageResource> GetImagesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevCenterScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>, System.Collections.IEnumerable
    {
        protected DevCenterScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.DevCenterScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.DevCenter.DevCenterScheduleData data, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> GetIfExists(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetIfExistsAsync(string scheduleName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevCenterScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public DevCenterScheduleData() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class DevCenterScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevCenterScheduleResource() { }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string poolName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Get(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> GetAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevCenter.DevCenterScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevCenter.Models.DevCenterSchedulePatch patch, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthCheckStatusDetailData : Azure.ResourceManager.Models.ResourceData
    {
        public HealthCheckStatusDetailData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> HealthChecks { get { throw null; } }
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
    public partial class ImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>, System.Collections.IEnumerable
    {
        protected ImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ImageVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ImageVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevCenter.ImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public ImageVersionData() { }
        public bool? IsExcludedFromLatest { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public int? OSDiskImageSizeInGB { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class ProjectAttachedNetworkConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>, System.Collections.IEnumerable
    {
        protected ProjectAttachedNetworkConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> Get(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource> GetIfExists(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource>> GetIfExistsAsync(string attachedNetworkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProjectDevBoxDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>, System.Collections.IEnumerable
    {
        protected ProjectDevBoxDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> Get(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource> GetIfExists(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource>> GetIfExistsAsync(string devBoxDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
}
namespace Azure.ResourceManager.DevCenter.Mocking
{
    public partial class MockableDevCenterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterArmClient() { }
        public virtual Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeResource GetAllowedEnvironmentTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.AttachedNetworkConnectionResource GetAttachedNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevBoxDefinitionResource GetDevBoxDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCatalogResource GetDevCenterCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeResource GetDevCenterEnvironmentTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterGalleryResource GetDevCenterGalleryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterImageResource GetDevCenterImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource GetDevCenterNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterPoolResource GetDevCenterPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentResource GetDevCenterProjectEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectResource GetDevCenterProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterResource GetDevCenterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterScheduleResource GetDevCenterScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.HealthCheckStatusDetailResource GetHealthCheckStatusDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ImageVersionResource GetImageVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectAttachedNetworkConnectionResource GetProjectAttachedNetworkConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.ProjectDevBoxDefinitionResource GetProjectDevBoxDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevCenterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenter(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterResource>> GetDevCenterAsync(string devCenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnection(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource>> GetDevCenterNetworkConnectionAsync(string networkConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionCollection GetDevCenterNetworkConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.DevCenterProjectResource>> GetDevCenterProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterProjectCollection GetDevCenterProjects() { throw null; }
        public virtual Azure.ResourceManager.DevCenter.DevCenterCollection GetDevCenters() { throw null; }
    }
    public partial class MockableDevCenterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevCenterSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult> CheckDevCenterNameAvailability(Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult>> CheckDevCenterNameAvailabilityAsync(Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnections(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionResource> GetDevCenterNetworkConnectionsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus> GetDevCenterOperationStatus(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus>> GetDevCenterOperationStatusAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjects(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterProjectResource> GetDevCenterProjectsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCenters(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.DevCenterResource> GetDevCentersAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscription(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails> GetDevCenterSkusBySubscriptionAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevCenter.Models.DevCenterUsage> GetDevCenterUsagesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevCenter.Models
{
    public static partial class ArmDevCenterModelFactory
    {
        public static Azure.ResourceManager.DevCenter.AllowedEnvironmentTypeData AllowedEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.AttachedNetworkConnectionData AttachedNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier networkConnectionId = null, Azure.Core.AzureLocation? networkConnectionLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevBoxDefinitionData DevBoxDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevCenter.Models.DevCenterImageReference imageReference = null, Azure.ResourceManager.DevCenter.Models.DevCenterSku sku = null, string osStorageType = null, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.ImageValidationStatus? imageValidationStatus = default(Azure.ResourceManager.DevCenter.Models.ImageValidationStatus?), Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails imageValidationErrorDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterImageReference activeImageReference = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCapability DevCenterCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterCatalogData DevCenterCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog gitHub = null, Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog adoGit = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState? syncState = default(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState?), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterData DevCenterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail DevCenterEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole DevCenterEnvironmentRole(string roleName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterEnvironmentTypeData DevCenterEnvironmentTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterGalleryData DevCenterGalleryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.Core.ResourceIdentifier galleryResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck DevCenterHealthCheck(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? status = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string errorType = null, string recommendedAction = null, string additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail DevCenterHealthStatusDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterImageData DevCenterImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string publisher = null, string offer = null, string sku = null, Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration recommendedMachineConfiguration = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? hibernateSupport = default(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterImageReference DevCenterImageReference(Azure.Core.ResourceIdentifier id = null, string exactVersion = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameAvailabilityResult DevCenterNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? reason = default(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterNetworkConnectionData DevCenterNetworkConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier subnetId = null, string domainName = null, string organizationUnit = null, string domainUsername = null, string domainPassword = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? healthCheckStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus?), string networkingResourceGroupName = null, Azure.ResourceManager.DevCenter.Models.DomainJoinType? domainJoinType = default(Azure.ResourceManager.DevCenter.Models.DomainJoinType?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterOperationStatus DevCenterOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterPoolData DevCenterPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string devBoxDefinitionName = null, string networkConnectionName = null, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? licenseType = default(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType?), Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? localAdministrator = default(Azure.ResourceManager.DevCenter.Models.LocalAdminStatus?), Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration stopOnDisconnect = null, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus? healthStatus = default(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatusDetail> healthStatusDetails = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectData DevCenterProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier devCenterId = null, string description = null, int? maxDevBoxesPerUser = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?), System.Uri devCenterUri = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterProjectEnvironmentData DevCenterProjectEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier deploymentTargetId = null, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? status = default(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> roles = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> userRoleAssignments = null, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange DevCenterResourceRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.DevCenterScheduleData DevCenterScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? scheduledType = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType?), Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? frequency = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency?), string time = null, string timeZone = null, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? state = default(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterSkuDetails DevCenterSkuDetails(string name = null, Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier? tier = default(Azure.ResourceManager.DevCenter.Models.DevCenterSkuTier?), string size = null, string family = null, int? capacity = default(int?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterCapability> capabilities = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsage DevCenterUsage(long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? unit = default(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit?), Azure.ResourceManager.DevCenter.Models.DevCenterUsageName name = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsageName DevCenterUsageName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EndpointDependency EndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.HealthCheckStatusDetailData HealthCheckStatusDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheck> healthChecks = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.ImageValidationErrorDetails ImageValidationErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.ImageVersionData ImageVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string namePropertiesName = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), bool? isExcludedFromLatest = default(bool?), int? osDiskImageSizeInGB = default(int?), Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState? provisioningState = default(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevCenter.Models.EndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.RecommendedMachineConfiguration RecommendedMachineConfiguration(Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange memory = null, Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange vCpus = null) { throw null; }
    }
    public partial class DevBoxDefinitionPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevBoxDefinitionPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport? HibernateSupport { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterImageReference ImageReference { get { throw null; } set { } }
        public string OSStorageType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterSku Sku { get { throw null; } set { } }
    }
    public partial class DevCenterCapability
    {
        internal DevCenterCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class DevCenterCatalogPatch
    {
        public DevCenterCatalogPatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog AdoGit { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterGitCatalog GitHub { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterCatalogSyncState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterCatalogSyncState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState left, Azure.ResourceManager.DevCenter.Models.DevCenterCatalogSyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterEndpointDetail
    {
        internal DevCenterEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class DevCenterEnvironmentRole
    {
        public DevCenterEnvironmentRole() { }
        public string Description { get { throw null; } }
        public string RoleName { get { throw null; } }
    }
    public partial class DevCenterEnvironmentTypePatch
    {
        public DevCenterEnvironmentTypePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DevCenterGitCatalog
    {
        public DevCenterGitCatalog() { }
        public string Branch { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class DevCenterHealthCheck
    {
        internal DevCenterHealthCheck() { }
        public string AdditionalDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHealthCheckStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHealthCheckStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthCheckStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHealthStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterHealthStatusDetail
    {
        internal DevCenterHealthStatusDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterHibernateSupport : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterHibernateSupport(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport left, Azure.ResourceManager.DevCenter.Models.DevCenterHibernateSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterImageReference
    {
        public DevCenterImageReference() { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterLicenseType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType WindowsClient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType left, Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterNameAvailabilityContent
    {
        public DevCenterNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class DevCenterNameAvailabilityResult
    {
        internal DevCenterNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason left, Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason left, Azure.ResourceManager.DevCenter.Models.DevCenterNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterNetworkConnectionPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevCenterNetworkConnectionPatch() { }
        public string DomainName { get { throw null; } set { } }
        public string DomainPassword { get { throw null; } set { } }
        public string DomainUsername { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class DevCenterOperationStatus : Azure.ResourceManager.Models.OperationStatusResult
    {
        internal DevCenterOperationStatus() : base (default(string)) { }
        public System.BinaryData Properties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
    }
    public partial class DevCenterPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevCenterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class DevCenterPoolPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevCenterPoolPatch() { }
        public string DevBoxDefinitionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.LocalAdminStatus? LocalAdministrator { get { throw null; } set { } }
        public string NetworkConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectConfiguration StopOnDisconnect { get { throw null; } set { } }
    }
    public partial class DevCenterProjectEnvironmentPatch
    {
        public DevCenterProjectEnvironmentPatch() { }
        public Azure.Core.ResourceIdentifier DeploymentTargetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterUserRoleAssignments> UserRoleAssignments { get { throw null; } }
    }
    public partial class DevCenterProjectPatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevCenterProjectPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DevCenterId { get { throw null; } set { } }
        public int? MaxDevBoxesPerUser { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterProvisioningState : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState MovingResources { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState RolloutInProgress { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState StorageProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState TransientFailure { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Updated { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState left, Azure.ResourceManager.DevCenter.Models.DevCenterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterResourceRange
    {
        internal DevCenterResourceRange() { }
        public int? Max { get { throw null; } }
        public int? Min { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduledFrequency : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduledFrequency(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency Daily { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduledType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduledType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType StopDevBox { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterScheduleEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterScheduleEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus left, Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterSchedulePatch : Azure.ResourceManager.DevCenter.Models.DevCenterTrackedResourceUpdate
    {
        public DevCenterSchedulePatch() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledFrequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduledType? ScheduledType { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterScheduleEnableStatus? State { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public enum DevCenterSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class DevCenterTrackedResourceUpdate
    {
        public DevCenterTrackedResourceUpdate() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DevCenterUsage
    {
        internal DevCenterUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageName Name { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit? Unit { get { throw null; } }
    }
    public partial class DevCenterUsageName
    {
        internal DevCenterUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevCenterUsageUnit : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevCenterUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit left, Azure.ResourceManager.DevCenter.Models.DevCenterUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevCenterUserRoleAssignments
    {
        public DevCenterUserRoleAssignments() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DevCenter.Models.DevCenterEnvironmentRole> Roles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainJoinType : System.IEquatable<Azure.ResourceManager.DevCenter.Models.DomainJoinType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainJoinType(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType AadJoin { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.DomainJoinType HybridAadJoin { get { throw null; } }
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
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.DevCenterEndpointDetail> EndpointDetails { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentTypeEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentTypeEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus left, Azure.ResourceManager.DevCenter.Models.EnvironmentTypeEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct LocalAdminStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.LocalAdminStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalAdminStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.LocalAdminStatus IsEnabled { get { throw null; } }
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
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevCenter.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class RecommendedMachineConfiguration
    {
        internal RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange Memory { get { throw null; } }
        public Azure.ResourceManager.DevCenter.Models.DevCenterResourceRange VCpus { get { throw null; } }
    }
    public partial class StopOnDisconnectConfiguration
    {
        public StopOnDisconnectConfiguration() { }
        public int? GracePeriodMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StopOnDisconnectEnableStatus : System.IEquatable<Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StopOnDisconnectEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus left, Azure.ResourceManager.DevCenter.Models.StopOnDisconnectEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
