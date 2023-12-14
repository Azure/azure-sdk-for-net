namespace Azure.ResourceManager.BotService
{
    public partial class BotChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotChannelResource>, System.Collections.IEnumerable
    {
        protected BotChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.Models.BotChannelName channelName, Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.Models.BotChannelName channelName, Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> Get(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotChannelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotChannelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetAsync(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BotService.BotChannelResource> GetIfExists(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BotService.BotChannelResource>> GetIfExistsAsync(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotChannelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotChannelData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotChannelProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class BotChannelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BotChannelResource() { }
        public virtual Azure.ResourceManager.BotService.BotChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, Azure.ResourceManager.BotService.Models.BotChannelName channelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.BotChannelGetWithKeysResult> GetChannelWithKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotChannelGetWithKeysResult>> GetChannelWithKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> Update(Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> UpdateAsync(Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotResource>, System.Collections.IEnumerable
    {
        protected BotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BotService.BotResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BotService.BotResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotConnectionSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotConnectionSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotConnectionSettingResource>, System.Collections.IEnumerable
    {
        protected BotConnectionSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotConnectionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.BotService.BotConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotConnectionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.BotService.BotConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotConnectionSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotConnectionSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BotService.BotConnectionSettingResource> GetIfExists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BotService.BotConnectionSettingResource>> GetIfExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotConnectionSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotConnectionSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotConnectionSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotConnectionSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotConnectionSettingData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotConnectionSettingData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotConnectionSettingProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class BotConnectionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BotConnectionSettingResource() { }
        public virtual Azure.ResourceManager.BotService.BotConnectionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> GetWithSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> GetWithSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> Update(Azure.ResourceManager.BotService.BotConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> UpdateAsync(Azure.ResourceManager.BotService.BotConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class BotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BotResource() { }
        public virtual Azure.ResourceManager.BotService.BotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.BotCreateEmailSignInUriResult> CreateEmailSignInUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotCreateEmailSignInUriResult>> CreateEmailSignInUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> GetBotChannel(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetBotChannelAsync(Azure.ResourceManager.BotService.Models.BotChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotChannelCollection GetBotChannels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> GetBotChannelWithRegenerateKeys(Azure.ResourceManager.BotService.Models.RegenerateKeysBotChannelName channelName, Azure.ResourceManager.BotService.Models.BotChannelRegenerateKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetBotChannelWithRegenerateKeysAsync(Azure.ResourceManager.BotService.Models.RegenerateKeysBotChannelName channelName, Azure.ResourceManager.BotService.Models.BotChannelRegenerateKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource> GetBotConnectionSetting(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotConnectionSettingResource>> GetBotConnectionSettingAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotConnectionSettingCollection GetBotConnectionSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> GetBotServicePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> GetBotServicePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionCollection GetBotServicePrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResourceData> GetPrivateLinkResourcesByBotResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResourceData> GetPrivateLinkResourcesByBotResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> Update(Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> UpdateAsync(Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class BotServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityResult> CheckBotServiceNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityResult>> CheckBotServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.BotResource> GetBot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetBotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.BotChannelResource GetBotChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BotService.Models.BotServiceProvider> GetBotConnectionServiceProviders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BotService.Models.BotServiceProvider> GetBotConnectionServiceProvidersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.BotConnectionSettingResource GetBotConnectionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BotService.BotResource GetBotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BotService.BotCollection GetBots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BotService.BotResource> GetBots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BotService.BotResource> GetBotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceHostSettingsResult> GetBotServiceHostSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceHostSettingsResult>> GetBotServiceHostSettingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource GetBotServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyResult> GetBotServiceQnAMakerEndpointKey(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyResult>> GetBotServiceQnAMakerEndpointKeyAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BotServicePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected BotServicePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotServicePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public BotServicePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.BotService.Models.BotServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class BotServicePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BotServicePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BotService.Mocking
{
    public partial class MockableBotServiceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBotServiceArmClient() { }
        public virtual Azure.ResourceManager.BotService.BotChannelResource GetBotChannelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotConnectionSettingResource GetBotConnectionSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotResource GetBotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource GetBotServicePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableBotServiceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBotServiceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> GetBot(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetBotAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotCollection GetBots() { throw null; }
    }
    public partial class MockableBotServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBotServiceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.Models.BotServiceProvider> GetBotConnectionServiceProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.Models.BotServiceProvider> GetBotConnectionServiceProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotResource> GetBots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotResource> GetBotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceHostSettingsResult> GetBotServiceHostSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceHostSettingsResult>> GetBotServiceHostSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyResult> GetBotServiceQnAMakerEndpointKey(Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyResult>> GetBotServiceQnAMakerEndpointKeyAsync(Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableBotServiceTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBotServiceTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityResult> CheckBotServiceNameAvailability(Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityResult>> CheckBotServiceNameAvailabilityAsync(Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BotService.Models
{
    public partial class AcsChatChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public AcsChatChannel() { }
    }
    public partial class AlexaChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public AlexaChannel() { }
        public Azure.ResourceManager.BotService.Models.AlexaChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class AlexaChannelProperties
    {
        public AlexaChannelProperties(string alexaSkillId, bool isEnabled) { }
        public string AlexaSkillId { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.Uri ServiceEndpointUri { get { throw null; } }
        public string UriFragment { get { throw null; } }
    }
    public static partial class ArmBotServiceModelFactory
    {
        public static Azure.ResourceManager.BotService.Models.AcsChatChannel AcsChatChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.AlexaChannel AlexaChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.AlexaChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.AlexaChannelProperties AlexaChannelProperties(string alexaSkillId = null, string uriFragment = null, System.Uri serviceEndpointUri = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.BotChannelData BotChannelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.BotChannelProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotChannelGetWithKeysResult BotChannelGetWithKeysResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.BotChannelProperties resource = null, Azure.ResourceManager.BotService.Models.BotChannelSettings setting = null, string provisioningState = null, string entityTag = null, string changedTime = null, Azure.ResourceManager.BotService.Models.BotChannelProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotChannelProperties BotChannelProperties(string channelName = null, Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotChannelSite BotChannelSite(System.Guid? tenantId = default(System.Guid?), string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebChatSpeechEnabled = default(bool?), bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.BotConnectionSettingData BotConnectionSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.BotConnectionSettingProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotConnectionSettingProperties BotConnectionSettingProperties(string clientId = null, string settingId = null, string clientSecret = null, string scopes = null, string serviceProviderId = null, string serviceProviderDisplayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.BotConnectionSettingParameter> parameters = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotCreateEmailSignInUriResult BotCreateEmailSignInUriResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Uri createEmailSignInUrlResponseUri = null) { throw null; }
        public static Azure.ResourceManager.BotService.BotData BotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.BotProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotProperties BotProperties(string displayName = null, string description = null, System.Uri iconUri = null, System.Uri endpoint = null, string endpointVersion = null, System.Collections.Generic.IDictionary<string, string> allSettings = null, System.Collections.Generic.IDictionary<string, string> parameters = null, System.Uri manifestUri = null, Azure.ResourceManager.BotService.Models.BotMsaAppType? msaAppType = default(Azure.ResourceManager.BotService.Models.BotMsaAppType?), string msaAppId = null, string msaAppTenantId = null, Azure.Core.ResourceIdentifier msaAppMSIResourceId = null, System.Collections.Generic.IEnumerable<string> configuredChannels = null, System.Collections.Generic.IEnumerable<string> enabledChannels = null, string developerAppInsightKey = null, string developerAppInsightsApiKey = null, string developerAppInsightsApplicationId = null, System.Collections.Generic.IEnumerable<string> luisAppIds = null, string luisKey = null, bool? isCmekEnabled = default(bool?), System.Uri cmekKeyVaultUri = null, string cmekEncryptionStatus = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess?), bool? isStreamingSupported = default(bool?), bool? isDeveloperAppInsightsApiKeySet = default(bool?), string migrationToken = null, bool? isLocalAuthDisabled = default(bool?), string schemaTransformationVersion = null, Azure.Core.ResourceIdentifier storageResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData> privateEndpointConnections = null, string openWithHint = null, string appPasswordHint = null, string provisioningState = null, string publishingCredentials = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceHostSettingsResult BotServiceHostSettingsResult(System.Uri oAuthUri = null, System.Uri toBotFromChannelOpenIdMetadataUri = null, string toBotFromChannelTokenIssuer = null, System.Uri toBotFromEmulatorOpenIdMetadataUri = null, System.Uri toChannelFromBotLoginUri = null, string toChannelFromBotOAuthScope = null, bool? validateAuthority = default(bool?), string botOpenIdMetadata = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceNameAvailabilityResult BotServiceNameAvailabilityResult(bool? isValid = default(bool?), string message = null, string absCode = null) { throw null; }
        public static Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData BotServicePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.BotService.Models.BotServicePrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResourceData BotServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceProvider BotServiceProvider(Azure.ResourceManager.BotService.Models.BotServiceProviderProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceProviderParameter BotServiceProviderParameter(string name = null, string serviceProviderParameterType = null, string displayName = null, string description = null, System.Uri helpUri = null, string @default = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceProviderProperties BotServiceProviderProperties(string id = null, string displayName = null, string serviceProviderName = null, System.Uri devPortalUri = null, System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.BotServiceProviderParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceSku BotServiceSku(Azure.ResourceManager.BotService.Models.BotServiceSkuName name = default(Azure.ResourceManager.BotService.Models.BotServiceSkuName), Azure.ResourceManager.BotService.Models.BotServiceSkuTier? tier = default(Azure.ResourceManager.BotService.Models.BotServiceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineChannel DirectLineChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.DirectLineChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineSite DirectLineSite(System.Guid? tenantId = default(System.Guid?), string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebChatSpeechEnabled = default(bool?), bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineSpeechChannel DirectLineSpeechChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.DirectLineSpeechChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.EmailChannel EmailChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.EmailChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.FacebookChannel FacebookChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.FacebookChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.FacebookChannelProperties FacebookChannelProperties(string verifyToken = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.FacebookPage> pages = null, string appId = null, string appSecret = null, System.Uri callbackUri = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.Models.GetBotServiceQnAMakerEndpointKeyResult GetBotServiceQnAMakerEndpointKeyResult(string primaryEndpointKey = null, string secondaryEndpointKey = null, string installedVersion = null, string lastStableVersion = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.KikChannel KikChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.KikChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineChannel LineChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.LineChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineChannelProperties LineChannelProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.LineRegistration> lineRegistrations = null, System.Uri callbackUri = null, bool? isValidated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineRegistration LineRegistration(string generatedId = null, string channelSecret = null, string channelAccessToken = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.M365Extensions M365Extensions(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.MsTeamsChannel MsTeamsChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.MsTeamsChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.Omnichannel Omnichannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.OutlookChannel OutlookChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SearchAssistant SearchAssistant(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SkypeChannel SkypeChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SkypeChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SlackChannel SlackChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SlackChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SlackChannelProperties SlackChannelProperties(string clientId = null, string clientSecret = null, string verificationToken = null, string scopes = null, System.Uri landingPageUri = null, string redirectAction = null, string lastSubmissionId = null, bool? registerBeforeOAuthFlow = default(bool?), bool? isValidated = default(bool?), string signingSecret = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SmsChannel SmsChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SmsChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.TelegramChannel TelegramChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.TelegramChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.TelephonyChannel TelephonyChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.TelephonyChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatChannel WebChatChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.WebChatChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatChannelProperties WebChatChannelProperties(string webChatEmbedCode = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.WebChatSite> sites = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatSite WebChatSite(System.Guid? tenantId = default(System.Guid?), string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebChatSpeechEnabled = default(bool?), bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
    }
    public partial class BotChannelGetWithKeysResult : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotChannelGetWithKeysResult(Azure.Core.AzureLocation location) { }
        public string ChangedTime { get { throw null; } set { } }
        public string EntityTag { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotChannelProperties Properties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotChannelProperties Resource { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotChannelSettings Setting { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotChannelName : System.IEquatable<Azure.ResourceManager.BotService.Models.BotChannelName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotChannelName(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotChannelName AcsChatChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName AlexaChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName DirectLineChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName DirectLineSpeechChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName EmailChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName FacebookChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName KikChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName LineChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName M365Extensions { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName MsTeamsChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName Omnichannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName OutlookChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName SearchAssistant { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName SkypeChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName SlackChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName SmsChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName TelegramChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName TelephonyChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotChannelName WebChatChannel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotChannelName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotChannelName left, Azure.ResourceManager.BotService.Models.BotChannelName right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotChannelName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotChannelName left, Azure.ResourceManager.BotService.Models.BotChannelName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BotChannelProperties
    {
        protected BotChannelProperties() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class BotChannelRegenerateKeysContent
    {
        public BotChannelRegenerateKeysContent(string siteName, Azure.ResourceManager.BotService.Models.BotServiceKey key) { }
        public Azure.ResourceManager.BotService.Models.BotServiceKey Key { get { throw null; } }
        public string SiteName { get { throw null; } }
    }
    public partial class BotChannelSettings
    {
        public BotChannelSettings() { }
        public System.Uri BotIconUri { get { throw null; } set { } }
        public string BotId { get { throw null; } set { } }
        public string ChannelDisplayName { get { throw null; } set { } }
        public string ChannelId { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExtensionKey1 { get { throw null; } set { } }
        public string ExtensionKey2 { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? RequireTermsAgreement { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.BotChannelSite> Sites { get { throw null; } }
    }
    public partial class BotChannelSite
    {
        public BotChannelSite(string siteName, bool isEnabled) { }
        public string AppId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsBlockUserUploadEnabled { get { throw null; } set { } }
        public bool? IsDetailedLoggingEnabled { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsEndpointParametersEnabled { get { throw null; } set { } }
        public bool? IsNoStorageEnabled { get { throw null; } set { } }
        public bool? IsSecureSiteEnabled { get { throw null; } set { } }
        public bool? IsTokenEnabled { get { throw null; } }
        public bool? IsV1Enabled { get { throw null; } set { } }
        public bool? IsV3Enabled { get { throw null; } set { } }
        public bool? IsWebchatPreviewEnabled { get { throw null; } set { } }
        public bool? IsWebChatSpeechEnabled { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public string Key2 { get { throw null; } }
        public string SiteId { get { throw null; } }
        public string SiteName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TrustedOrigins { get { throw null; } }
    }
    public partial class BotConnectionSettingParameter
    {
        public BotConnectionSettingParameter() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class BotConnectionSettingProperties
    {
        public BotConnectionSettingProperties() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.BotConnectionSettingParameter> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
        public string Scopes { get { throw null; } set { } }
        public string ServiceProviderDisplayName { get { throw null; } set { } }
        public string ServiceProviderId { get { throw null; } set { } }
        public string SettingId { get { throw null; } }
    }
    public partial class BotCreateEmailSignInUriResult
    {
        internal BotCreateEmailSignInUriResult() { }
        public System.Uri CreateEmailSignInUrlResponseUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotMsaAppType : System.IEquatable<Azure.ResourceManager.BotService.Models.BotMsaAppType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotMsaAppType(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotMsaAppType MultiTenant { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotMsaAppType SingleTenant { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotMsaAppType UserAssignedMSI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotMsaAppType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotMsaAppType left, Azure.ResourceManager.BotService.Models.BotMsaAppType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotMsaAppType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotMsaAppType left, Azure.ResourceManager.BotService.Models.BotMsaAppType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BotProperties
    {
        public BotProperties(string displayName, System.Uri endpoint, string msaAppId) { }
        public System.Collections.Generic.IDictionary<string, string> AllSettings { get { throw null; } }
        public string AppPasswordHint { get { throw null; } set { } }
        public string CmekEncryptionStatus { get { throw null; } }
        public System.Uri CmekKeyVaultUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ConfiguredChannels { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DeveloperAppInsightKey { get { throw null; } set { } }
        public string DeveloperAppInsightsApiKey { get { throw null; } set { } }
        public string DeveloperAppInsightsApplicationId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledChannels { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public string EndpointVersion { get { throw null; } }
        public System.Uri IconUri { get { throw null; } set { } }
        public bool? IsCmekEnabled { get { throw null; } set { } }
        public bool? IsDeveloperAppInsightsApiKeySet { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsStreamingSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LuisAppIds { get { throw null; } }
        public string LuisKey { get { throw null; } set { } }
        public System.Uri ManifestUri { get { throw null; } set { } }
        public string MigrationToken { get { throw null; } }
        public string MsaAppId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MsaAppMSIResourceId { get { throw null; } set { } }
        public string MsaAppTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotMsaAppType? MsaAppType { get { throw null; } set { } }
        public string OpenWithHint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingCredentials { get { throw null; } set { } }
        public string SchemaTransformationVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class BotServiceHostSettingsResult
    {
        internal BotServiceHostSettingsResult() { }
        public string BotOpenIdMetadata { get { throw null; } }
        public System.Uri OAuthUri { get { throw null; } }
        public System.Uri ToBotFromChannelOpenIdMetadataUri { get { throw null; } }
        public string ToBotFromChannelTokenIssuer { get { throw null; } }
        public System.Uri ToBotFromEmulatorOpenIdMetadataUri { get { throw null; } }
        public System.Uri ToChannelFromBotLoginUri { get { throw null; } }
        public string ToChannelFromBotOAuthScope { get { throw null; } }
        public bool? ValidateAuthority { get { throw null; } }
    }
    public enum BotServiceKey
    {
        Key1 = 0,
        Key2 = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServiceKind : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceKind Azurebot { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceKind Bot { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceKind Designer { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceKind Function { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceKind Sdk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServiceKind left, Azure.ResourceManager.BotService.Models.BotServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServiceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServiceKind left, Azure.ResourceManager.BotService.Models.BotServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BotServiceNameAvailabilityContent
    {
        public BotServiceNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class BotServiceNameAvailabilityResult
    {
        internal BotServiceNameAvailabilityResult() { }
        public string AbsCode { get { throw null; } }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServicePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServicePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServicePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServicePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BotServicePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BotServicePrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class BotServicePrivateLinkServiceConnectionState
    {
        public BotServicePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class BotServiceProvider
    {
        internal BotServiceProvider() { }
        public Azure.ResourceManager.BotService.Models.BotServiceProviderProperties Properties { get { throw null; } }
    }
    public partial class BotServiceProviderParameter
    {
        internal BotServiceProviderParameter() { }
        public string Default { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri HelpUri { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServiceProviderParameterType { get { throw null; } }
    }
    public partial class BotServiceProviderProperties
    {
        internal BotServiceProviderProperties() { }
        public System.Uri DevPortalUri { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BotService.Models.BotServiceProviderParameter> Parameters { get { throw null; } }
        public string ServiceProviderName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServicePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServicePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess left, Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess left, Azure.ResourceManager.BotService.Models.BotServicePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BotServiceSku
    {
        public BotServiceSku(Azure.ResourceManager.BotService.Models.BotServiceSkuName name) { }
        public Azure.ResourceManager.BotService.Models.BotServiceSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServiceSkuName : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServiceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServiceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceSkuName F0 { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceSkuName S1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServiceSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServiceSkuName left, Azure.ResourceManager.BotService.Models.BotServiceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServiceSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServiceSkuName left, Azure.ResourceManager.BotService.Models.BotServiceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BotServiceSkuTier : System.IEquatable<Azure.ResourceManager.BotService.Models.BotServiceSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BotServiceSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.BotServiceSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.BotServiceSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.BotServiceSkuTier left, Azure.ResourceManager.BotService.Models.BotServiceSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.BotServiceSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.BotServiceSkuTier left, Azure.ResourceManager.BotService.Models.BotServiceSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DirectLineChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public DirectLineChannel() { }
        public Azure.ResourceManager.BotService.Models.DirectLineChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class DirectLineChannelProperties
    {
        public DirectLineChannelProperties() { }
        public string DirectLineEmbedCode { get { throw null; } set { } }
        public string ExtensionKey1 { get { throw null; } set { } }
        public string ExtensionKey2 { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.DirectLineSite> Sites { get { throw null; } }
    }
    public partial class DirectLineSite : Azure.ResourceManager.BotService.Models.BotChannelSite
    {
        public DirectLineSite(string siteName, bool isEnabled) : base (default(string), default(bool)) { }
    }
    public partial class DirectLineSpeechChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public DirectLineSpeechChannel() { }
        public Azure.ResourceManager.BotService.Models.DirectLineSpeechChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class DirectLineSpeechChannelProperties
    {
        public DirectLineSpeechChannelProperties() { }
        public string CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CognitiveServiceResourceId { get { throw null; } set { } }
        public string CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public string CustomSpeechModelId { get { throw null; } set { } }
        public string CustomVoiceDeploymentId { get { throw null; } set { } }
        public bool? IsDefaultBotForCogSvcAccount { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class EmailChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public EmailChannel() { }
        public Azure.ResourceManager.BotService.Models.EmailChannelProperties Properties { get { throw null; } set { } }
    }
    public enum EmailChannelAuthMethod
    {
        Password = 0,
        Graph = 1,
    }
    public partial class EmailChannelProperties
    {
        public EmailChannelProperties(string emailAddress, bool isEnabled) { }
        public Azure.ResourceManager.BotService.Models.EmailChannelAuthMethod? AuthMethod { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public string MagicCode { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
    }
    public partial class FacebookChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public FacebookChannel() { }
        public Azure.ResourceManager.BotService.Models.FacebookChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class FacebookChannelProperties
    {
        public FacebookChannelProperties(string appId, bool isEnabled) { }
        public string AppId { get { throw null; } set { } }
        public string AppSecret { get { throw null; } set { } }
        public System.Uri CallbackUri { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.FacebookPage> Pages { get { throw null; } }
        public string VerifyToken { get { throw null; } }
    }
    public partial class FacebookPage
    {
        public FacebookPage(string id) { }
        public string AccessToken { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class GetBotServiceQnAMakerEndpointKeyContent
    {
        public GetBotServiceQnAMakerEndpointKeyContent() { }
        public string Authkey { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
    }
    public partial class GetBotServiceQnAMakerEndpointKeyResult
    {
        internal GetBotServiceQnAMakerEndpointKeyResult() { }
        public string InstalledVersion { get { throw null; } }
        public string LastStableVersion { get { throw null; } }
        public string PrimaryEndpointKey { get { throw null; } }
        public string SecondaryEndpointKey { get { throw null; } }
    }
    public partial class KikChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public KikChannel() { }
        public Azure.ResourceManager.BotService.Models.KikChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class KikChannelProperties
    {
        public KikChannelProperties(string userName, bool isEnabled) { }
        public string ApiKey { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsValidated { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class LineChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public LineChannel() { }
        public Azure.ResourceManager.BotService.Models.LineChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class LineChannelProperties
    {
        public LineChannelProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.LineRegistration> lineRegistrations) { }
        public System.Uri CallbackUri { get { throw null; } }
        public bool? IsValidated { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.LineRegistration> LineRegistrations { get { throw null; } }
    }
    public partial class LineRegistration
    {
        public LineRegistration() { }
        public string ChannelAccessToken { get { throw null; } set { } }
        public string ChannelSecret { get { throw null; } set { } }
        public string GeneratedId { get { throw null; } }
    }
    public partial class M365Extensions : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public M365Extensions() { }
    }
    public partial class MsTeamsChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public MsTeamsChannel() { }
        public Azure.ResourceManager.BotService.Models.MsTeamsChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class MsTeamsChannelProperties
    {
        public MsTeamsChannelProperties(bool isEnabled) { }
        public bool? AcceptedTerms { get { throw null; } set { } }
        public string CallingWebhook { get { throw null; } set { } }
        public string DeploymentEnvironment { get { throw null; } set { } }
        public string IncomingCallRoute { get { throw null; } set { } }
        public bool? IsCallingEnabled { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public partial class Omnichannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public Omnichannel() { }
    }
    public partial class OutlookChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public OutlookChannel() { }
    }
    public enum RegenerateKeysBotChannelName
    {
        WebChatChannel = 0,
        DirectLineChannel = 1,
    }
    public partial class SearchAssistant : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public SearchAssistant() { }
    }
    public partial class SkypeChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public SkypeChannel() { }
        public Azure.ResourceManager.BotService.Models.SkypeChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class SkypeChannelProperties
    {
        public SkypeChannelProperties(bool isEnabled) { }
        public string CallingWebHook { get { throw null; } set { } }
        public string GroupsMode { get { throw null; } set { } }
        public string IncomingCallRoute { get { throw null; } set { } }
        public bool? IsCallingEnabled { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsGroupsEnabled { get { throw null; } set { } }
        public bool? IsMediaCardsEnabled { get { throw null; } set { } }
        public bool? IsMessagingEnabled { get { throw null; } set { } }
        public bool? IsScreenSharingEnabled { get { throw null; } set { } }
        public bool? IsVideoEnabled { get { throw null; } set { } }
    }
    public partial class SlackChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public SlackChannel() { }
        public Azure.ResourceManager.BotService.Models.SlackChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class SlackChannelProperties
    {
        public SlackChannelProperties(bool isEnabled) { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsValidated { get { throw null; } }
        public System.Uri LandingPageUri { get { throw null; } set { } }
        public string LastSubmissionId { get { throw null; } }
        public string RedirectAction { get { throw null; } }
        public bool? RegisterBeforeOAuthFlow { get { throw null; } set { } }
        public string Scopes { get { throw null; } set { } }
        public string SigningSecret { get { throw null; } set { } }
        public string VerificationToken { get { throw null; } set { } }
    }
    public partial class SmsChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public SmsChannel() { }
        public Azure.ResourceManager.BotService.Models.SmsChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class SmsChannelProperties
    {
        public SmsChannelProperties(string phone, string accountSID, bool isEnabled) { }
        public string AccountSID { get { throw null; } set { } }
        public string AuthToken { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsValidated { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class TelegramChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public TelegramChannel() { }
        public Azure.ResourceManager.BotService.Models.TelegramChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class TelegramChannelProperties
    {
        public TelegramChannelProperties(bool isEnabled) { }
        public string AccessToken { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public bool? IsValidated { get { throw null; } set { } }
    }
    public partial class TelephonyChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public TelephonyChannel() { }
        public Azure.ResourceManager.BotService.Models.TelephonyChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class TelephonyChannelProperties
    {
        public TelephonyChannelProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.TelephonyChannelResourceApiConfiguration> ApiConfigurations { get { throw null; } }
        public string CognitiveServiceRegion { get { throw null; } set { } }
        public string CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public string DefaultLocale { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.TelephonyPhoneNumbers> PhoneNumbers { get { throw null; } }
        public string PremiumSku { get { throw null; } set { } }
    }
    public partial class TelephonyChannelResourceApiConfiguration
    {
        public TelephonyChannelResourceApiConfiguration() { }
        public string CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CognitiveServiceResourceId { get { throw null; } set { } }
        public string CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public string DefaultLocale { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string ProviderName { get { throw null; } set { } }
    }
    public partial class TelephonyPhoneNumbers
    {
        public TelephonyPhoneNumbers() { }
        public string AcsEndpoint { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AcsResourceId { get { throw null; } set { } }
        public string AcsSecret { get { throw null; } set { } }
        public string CognitiveServiceRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CognitiveServiceResourceId { get { throw null; } set { } }
        public string CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public string DefaultLocale { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string OfferType { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
    }
    public partial class WebChatChannel : Azure.ResourceManager.BotService.Models.BotChannelProperties
    {
        public WebChatChannel() { }
        public Azure.ResourceManager.BotService.Models.WebChatChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class WebChatChannelProperties
    {
        public WebChatChannelProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.WebChatSite> Sites { get { throw null; } }
        public string WebChatEmbedCode { get { throw null; } }
    }
    public partial class WebChatSite : Azure.ResourceManager.BotService.Models.BotChannelSite
    {
        public WebChatSite(string siteName, bool isEnabled) : base (default(string), default(bool)) { }
    }
}
