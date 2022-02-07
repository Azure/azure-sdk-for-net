namespace Azure.ResourceManager.AppConfiguration
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.AppConfiguration.ConfigurationStore GetConfigurationStore(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ConfigurationStore : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationStore() { }
        public virtual Azure.ResourceManager.AppConfiguration.ConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> GetKeys(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.ApiKey> GetKeysAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.KeyValue> GetKeyValue(Azure.ResourceManager.AppConfiguration.Models.ListKeyValueOptions listKeyValueOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.KeyValue>> GetKeyValueAsync(Azure.ResourceManager.AppConfiguration.Models.ListKeyValueOptions listKeyValueOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey> RegenerateKey(Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyOptions regenerateKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.ApiKey>> RegenerateKeyAsync(Azure.ResourceManager.AppConfiguration.Models.RegenerateKeyOptions regenerateKeyOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateOptions configurationStoreUpdateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreUpdateOptions configurationStoreUpdateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoreCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStore>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStore>, System.Collections.IEnumerable
    {
        protected ConfigurationStoreCollection() { }
        public virtual Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string configStoreName, Azure.ResourceManager.AppConfiguration.ConfigurationStoreData configStoreCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.Models.ConfigurationStoreCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string configStoreName, Azure.ResourceManager.AppConfiguration.ConfigurationStoreData configStoreCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> Get(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.ConfigurationStore> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.ConfigurationStore> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> GetAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore> GetIfExists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> GetIfExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.ConfigurationStore> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStore>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.ConfigurationStore> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.ConfigurationStore>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationStoreData : Azure.ResourceManager.Models.TrackedResource
    {
        public ConfigurationStoreData(Azure.Core.AzureLocation location, Azure.ResourceManager.AppConfiguration.Models.Sku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreationDate { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.AppConfiguration.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.PrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.Resource
    {
        internal PrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.AppConfiguration.ConfigurationStoreCollection GetConfigurationStores(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus> CheckAppConfigurationNameAvailability(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityParameters checkNameAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.NameAvailabilityStatus>> CheckAppConfigurationNameAvailabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.AppConfiguration.Models.CheckNameAvailabilityParameters checkNameAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppConfiguration.ConfigurationStore> GetConfigurationStores(this Azure.ResourceManager.Resources.Subscription subscription, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.ConfigurationStore> GetConfigurationStoresAsync(this Azure.ResourceManager.Resources.Subscription subscription, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CheckNameAvailabilityParameters
    {
        public CheckNameAvailabilityParameters(string name, Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType type) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ConfigurationResourceType Type { get { throw null; } }
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
    public partial class ConfigurationStoreCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.ConfigurationStore>
    {
        protected ConfigurationStoreCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.ConfigurationStore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoreDeleteOperation : Azure.Operation
    {
        protected ConfigurationStoreDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoreUpdateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.ConfigurationStore>
    {
        protected ConfigurationStoreUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.ConfigurationStore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.ConfigurationStore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationStoreUpdateOptions
    {
        public ConfigurationStoreUpdateOptions() { }
        public Azure.ResourceManager.AppConfiguration.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.Sku Sku { get { throw null; } set { } }
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
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.AppConfiguration.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
    }
    public partial class KeyValue
    {
        internal KeyValue() { }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public bool? Locked { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class ListKeyValueOptions
    {
        public ListKeyValueOptions(string key) { }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } set { } }
    }
    public partial class NameAvailabilityStatus
    {
        internal NameAvailabilityStatus() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.AppConfiguration.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionReference : Azure.ResourceManager.Models.Resource
    {
        internal PrivateEndpointConnectionReference() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PrivateEndpoint { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.AppConfiguration.Models.ActionsRequired? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.ConnectionStatus? Status { get { throw null; } set { } }
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
    public partial class RegenerateKeyOptions
    {
        public RegenerateKeyOptions() { }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType left, Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType left, Azure.ResourceManager.AppConfiguration.Models.ResourceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Sku
    {
        public Sku(string name) { }
        public string Name { get { throw null; } set { } }
    }
}
