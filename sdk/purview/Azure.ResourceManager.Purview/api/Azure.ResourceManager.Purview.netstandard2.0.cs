namespace Azure.ResourceManager.Purview
{
    public partial class PurviewAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>, System.Collections.IEnumerable
    {
        protected PurviewAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.PurviewAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.PurviewAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PurviewAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedResource ManagedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountSku Sku { get { throw null; } }
    }
    public partial class PurviewAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewAccountResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AddRootCollectionAdmin(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddRootCollectionAdminAsync(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetPurviewPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetPurviewPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionCollection GetPurviewPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetPurviewPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetPurviewPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceCollection GetPurviewPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.PurviewAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.PurviewAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PurviewExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckPurviewAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckPurviewAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> GetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetPurviewAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewAccountResource GetPurviewAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewAccountCollection GetPurviewAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource GetPurviewPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResource GetPurviewPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response RemoveDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RemoveDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> SetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PurviewPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PurviewPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PurviewPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PurviewPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal PurviewPrivateLinkResourceData() { }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties Properties { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Purview.Mock
{
    public partial class PurviewAccountResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected PurviewAccountResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckPurviewAccountNameAvailability(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckPurviewAccountNameAvailabilityAsync(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccounts(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccountsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Purview.PurviewAccountCollection GetPurviewAccounts() { throw null; }
    }
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> GetDefaultAccount(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetDefaultAccountAsync(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveDefaultAccount(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveDefaultAccountAsync(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> SetDefaultAccount(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetDefaultAccountAsync(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Purview.Models
{
    public partial class CollectionAdminUpdateContent
    {
        public CollectionAdminUpdateContent() { }
        public string AdminObjectId { get { throw null; } set { } }
    }
    public partial class DefaultPurviewAccountPayload
    {
        public DefaultPurviewAccountPayload() { }
        public string AccountName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.Guid? ScopeTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountScopeType? ScopeType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class PurviewAccountAccessKey
    {
        internal PurviewAccountAccessKey() { }
        public string AtlasKafkaPrimaryEndpoint { get { throw null; } }
        public string AtlasKafkaSecondaryEndpoint { get { throw null; } }
    }
    public partial class PurviewAccountEndpoint
    {
        internal PurviewAccountEndpoint() { }
        public string Catalog { get { throw null; } }
        public string Guardian { get { throw null; } }
        public string Scan { get { throw null; } }
    }
    public partial class PurviewAccountNameAvailabilityContent
    {
        public PurviewAccountNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class PurviewAccountNameAvailabilityResult
    {
        internal PurviewAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountPatch
    {
        public PurviewAccountPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PurviewAccountProperties
    {
        public PurviewAccountProperties() { }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedResource ManagedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountScopeType : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountScopeType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountSku
    {
        internal PurviewAccountSku() { }
        public int? Capacity { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountSkuName? Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountSkuName : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewManagedResource
    {
        internal PurviewManagedResource() { }
        public Azure.Core.ResourceIdentifier EventHubNamespace { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccount { get { throw null; } }
    }
    public partial class PurviewPrivateLinkResourceProperties
    {
        internal PurviewPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PurviewPrivateLinkServiceConnectionState
    {
        public PurviewPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewPrivateLinkServiceStatus : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewPrivateLinkServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus left, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus left, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewProvisioningState : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
