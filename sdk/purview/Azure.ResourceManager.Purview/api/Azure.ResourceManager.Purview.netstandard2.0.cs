namespace Azure.ResourceManager.Purview
{
    public partial class AccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.AccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.AccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources ManagedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountSku Sku { get { throw null; } }
    }
    public partial class AccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.Purview.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AddRootCollectionAdmin(Azure.ResourceManager.Purview.Models.CollectionAdminUpdate collectionAdminUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddRootCollectionAdminAsync(Azure.ResourceManager.Purview.Models.CollectionAdminUpdate collectionAdminUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetPurviewPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetPurviewPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionCollection GetPurviewPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetPurviewPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetPurviewPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceCollection GetPurviewPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PurviewExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Purview.Models.CheckNameAvailabilityResult> CheckNameAvailabilityAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.AccountResource> GetAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.AccountCollection GetAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Purview.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Purview.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultAccountPayload> GetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.ScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultAccountPayload>> GetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.ScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource GetPurviewPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResource GetPurviewPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response RemoveDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.ScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RemoveDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.ScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultAccountPayload> SetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultAccountPayload>> SetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.ResourceManager.Purview.Models
{
    public partial class AccessKeys
    {
        internal AccessKeys() { }
        public string AtlasKafkaPrimaryEndpoint { get { throw null; } }
        public string AtlasKafkaSecondaryEndpoint { get { throw null; } }
    }
    public partial class AccountEndpoints
    {
        internal AccountEndpoints() { }
        public string Catalog { get { throw null; } }
        public string Guardian { get { throw null; } }
        public string Scan { get { throw null; } }
    }
    public partial class AccountPatch
    {
        public AccountPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AccountProperties
    {
        public AccountProperties() { }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources ManagedResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class AccountPropertiesEndpoints : Azure.ResourceManager.Purview.Models.AccountEndpoints
    {
        internal AccountPropertiesEndpoints() { }
    }
    public partial class AccountPropertiesManagedResources : Azure.ResourceManager.Purview.Models.ManagedResources
    {
        internal AccountPropertiesManagedResources() { }
    }
    public partial class AccountSku : Azure.ResourceManager.Purview.Models.PurviewAccountSku
    {
        internal AccountSku() { }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.Reason? Reason { get { throw null; } }
    }
    public partial class CollectionAdminUpdate
    {
        public CollectionAdminUpdate() { }
        public string ObjectId { get { throw null; } set { } }
    }
    public partial class DefaultAccountPayload
    {
        public DefaultAccountPayload() { }
        public string AccountName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string ScopeTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.ScopeType? ScopeType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class ManagedResources
    {
        internal ManagedResources() { }
        public string EventHubNamespace { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string StorageAccount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Name : System.IEquatable<Azure.ResourceManager.Purview.Models.Name>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Name(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.Name Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.Name other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.Name left, Azure.ResourceManager.Purview.Models.Name right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.Name (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.Name left, Azure.ResourceManager.Purview.Models.Name right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Purview.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.ProvisioningState left, Azure.ResourceManager.Purview.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.ProvisioningState left, Azure.ResourceManager.Purview.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Purview.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PublicNetworkAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountSku
    {
        internal PurviewAccountSku() { }
        public int? Capacity { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.Name? Name { get { throw null; } }
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
        public Azure.ResourceManager.Purview.Models.Status? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.Purview.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.Reason left, Azure.ResourceManager.Purview.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.Reason left, Azure.ResourceManager.Purview.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScopeType : System.IEquatable<Azure.ResourceManager.Purview.Models.ScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ScopeType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.ScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.ScopeType left, Azure.ResourceManager.Purview.Models.ScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.ScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.ScopeType left, Azure.ResourceManager.Purview.Models.ScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Purview.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.Status Approved { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.Status Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.Status Pending { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.Status Rejected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.Status Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.Status left, Azure.ResourceManager.Purview.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.Status left, Azure.ResourceManager.Purview.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
}
