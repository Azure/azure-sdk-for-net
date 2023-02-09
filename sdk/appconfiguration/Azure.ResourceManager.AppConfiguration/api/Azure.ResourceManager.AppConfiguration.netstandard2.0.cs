namespace Azure.ResourceManager.AppConfiguration
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult> CheckAppConfigurationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>> CheckAppConfigurationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource GetAppConfigurationKeyValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource GetAppConfigurationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource GetAppConfigurationPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStore(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAppConfigurationStoreAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource GetAppConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreCollection GetAppConfigurationStores(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStoresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetDeletedAppConfigurationStore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetDeletedAppConfigurationStoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource GetDeletedAppConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreCollection GetDeletedAppConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class AppConfigurationKeyValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationKeyValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Get(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationKeyValueData : Azure.ResourceManager.Models.ResourceData
    {
        public AppConfigurationKeyValueData() { }
        public string ContentType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsLocked { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AppConfigurationKeyValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationKeyValueResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string keyValueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AppConfigurationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AppConfigurationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationPrivateLinkResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal AppConfigurationPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class AppConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Get(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationStoreData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppConfigurationStoreData(Azure.Core.AzureLocation location, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode? CreateMode { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
    }
    public partial class AppConfigurationStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAppConfigurationKeyValue(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAppConfigurationKeyValueAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueCollection GetAppConfigurationKeyValues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAppConfigurationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAppConfigurationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionCollection GetAppConfigurationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAppConfigurationPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAppConfigurationPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceCollection GetAppConfigurationPrivateLinkResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> GetKeys(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> GetKeysAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> RegenerateKey(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>> RegenerateKeyAsync(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAppConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected DeletedAppConfigurationStoreCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> Get(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedAppConfigurationStoreData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedAppConfigurationStoreData() { }
        public Azure.Core.ResourceIdentifier ConfigurationStoreId { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? IsPurgeProtectionEnabled { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeletedAppConfigurationStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedAppConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string configStoreName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationActionsRequired : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AppConfigurationCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class AppConfigurationKeyVaultProperties
    {
        public AppConfigurationKeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class AppConfigurationNameAvailabilityContent
    {
        public AppConfigurationNameAvailabilityContent(string name, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType ResourceType { get { throw null; } }
    }
    public partial class AppConfigurationNameAvailabilityResult
    {
        internal AppConfigurationNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class AppConfigurationPrivateEndpointConnectionReference : Azure.ResourceManager.Models.ResourceData
    {
        internal AppConfigurationPrivateEndpointConnectionReference() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class AppConfigurationPrivateLinkServiceConnectionState
    {
        public AppConfigurationPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationRegenerateKeyContent
    {
        public AppConfigurationRegenerateKeyContent() { }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationResourceType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationResourceType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType MicrosoftAppConfigurationConfigurationStores { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationSku
    {
        public AppConfigurationSku(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class AppConfigurationStoreApiKey
    {
        internal AppConfigurationStoreApiKey() { }
        public string ConnectionString { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class AppConfigurationStorePatch
    {
        public AppConfigurationStorePatch() { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ArmAppConfigurationModelFactory
    {
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData AppConfigurationKeyValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string key = null, string label = null, string value = null, string contentType = null, Azure.ETag? eTag = default(Azure.ETag?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), bool? isLocked = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult AppConfigurationNameAvailabilityResult(bool? isNameAvailable = default(bool?), string message = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData AppConfigurationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference AppConfigurationPrivateEndpointConnectionReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData AppConfigurationPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState AppConfigurationPrivateLinkServiceConnectionState(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus? status = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus?), string description = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired? actionsRequired = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey AppConfigurationStoreApiKey(string id = null, string name = null, string value = null, string connectionString = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData AppConfigurationStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string skuName = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string endpoint = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties encryptionKeyVaultProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference> privateEndpointConnections = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess?), bool? disableLocalAuth = default(bool?), int? softDeleteRetentionInDays = default(int?), bool? enablePurgeProtection = default(bool?), Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode? createMode = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData DeletedAppConfigurationStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier configurationStoreId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, bool? isPurgeProtectionEnabled = default(bool?)) { throw null; }
    }
}
