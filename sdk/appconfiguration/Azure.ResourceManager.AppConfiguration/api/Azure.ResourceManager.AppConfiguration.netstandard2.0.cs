namespace Azure.ResourceManager.AppConfiguration
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus> CheckAppConfigurationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus>> CheckAppConfigurationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource GetAppConfigurationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource GetAppConfigurationPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> GetConfigurationStore(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> GetConfigurationStoreAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource GetConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.ConfigurationStoreCollection GetConfigurationStores(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> GetConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> GetConfigurationStoresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> GetDeletedConfigurationStore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> GetDeletedConfigurationStoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource GetDeletedConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreCollection GetDeletedConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.KeyValueResource GetKeyValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class ConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected ConfigurationStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.ConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.ConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> Get(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> GetAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationStoreData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConfigurationStoreData(Azure.Core.AzureLocation location, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.AppConfiguration.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.KeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
    }
    public partial class ConfigurationStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAppConfigurationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAppConfigurationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionCollection GetAppConfigurationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAppConfigurationPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAppConfigurationPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceCollection GetAppConfigurationPrivateLinkResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> GetKeys(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> GetKeysAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> GetKeyValue(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> GetKeyValueAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.KeyValueCollection GetKeyValues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey> RegenerateKey(Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey>> RegenerateKeyAsync(Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.ConfigurationStoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected DeletedConfigurationStoreCollection() { }
        public virtual Azure.Response<bool> Exists(string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> Get(string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> GetAsync(string location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedConfigurationStoreData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedConfigurationStoreData() { }
        public string ConfigurationStoreId { get { throw null; } }
        public System.DateTimeOffset? DeletionOn { get { throw null; } }
        public string Location { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeletedConfigurationStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string configStoreName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.KeyValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.KeyValueResource>, System.Collections.IEnumerable
    {
        protected KeyValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.KeyValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.KeyValueData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.KeyValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.KeyValueData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> Get(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.KeyValueResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.KeyValueResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> GetAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.KeyValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.KeyValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.KeyValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.KeyValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyValueData : Azure.ResourceManager.Models.ResourceData
    {
        public KeyValueData() { }
        public string ContentType { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public bool? Locked { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class KeyValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyValueResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.KeyValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string keyValueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.KeyValueResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.KeyValueResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.KeyValueData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.KeyValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.KeyValueData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequired : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ActionsRequired None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ActionsRequired Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.ActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.ActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiKey
    {
        internal ApiKey() { }
        public string ConnectionString { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ReadOnly { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class AppConfigurationPrivateLinkServiceConnectionState
    {
        public AppConfigurationPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.AppConfiguration.Models.ActionsRequired? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class AppConfigurationSku
    {
        public AppConfigurationSku(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name, Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationResourceType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationResourceType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType MicrosoftAppConfigurationConfigurationStores { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationStorePatch
    {
        public ConfigurationStorePatch() { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.KeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class NameAvailabilityStatus
    {
        internal NameAvailabilityStatus() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionReference : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateEndpointConnectionReference() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent() { }
        public string Id { get { throw null; } set { } }
    }
}
