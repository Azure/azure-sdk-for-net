namespace Azure.ResourceManager.BotService
{
    public partial class BotChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotChannelResource>, System.Collections.IEnumerable
    {
        protected BotChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.Models.ChannelName channelName, Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.BotChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.BotService.Models.ChannelName channelName, Azure.ResourceManager.BotService.BotChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> Get(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.BotChannelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.BotChannelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetAsync(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotChannelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotChannelData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.Channel Properties { get { throw null; } set { } }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, Azure.ResourceManager.BotService.Models.ChannelName channelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.ListChannelWithKeysResponse> GetWithKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.ListChannelWithKeysResponse>> GetWithKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BotData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.Models.CreateEmailSignInUrlResponse> CreateSignInUrlEmail(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.CreateEmailSignInUrlResponse>> CreateSignInUrlEmailAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> GetBotChannel(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> GetBotChannelAsync(Azure.ResourceManager.BotService.Models.ChannelName channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotChannelCollection GetBotChannels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> GetBotServicePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>> GetBotServicePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionCollection GetBotServicePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> GetConnectionSetting(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> GetConnectionSettingAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.BotService.ConnectionSettingCollection GetConnectionSettings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResource> GetPrivateLinkResourcesByBotResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResource> GetPrivateLinkResourcesByBotResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotChannelResource> RegenerateKeysDirectLine(Azure.ResourceManager.BotService.Models.RegenerateKeysChannelName channelName, Azure.ResourceManager.BotService.Models.SiteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotChannelResource>> RegenerateKeysDirectLineAsync(Azure.ResourceManager.BotService.Models.RegenerateKeysChannelName channelName, Azure.ResourceManager.BotService.Models.SiteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.BotResource> Update(Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> UpdateAsync(Azure.ResourceManager.BotService.BotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class BotServiceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.BotService.BotResource> GetBot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.BotResource>> GetBotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.BotChannelResource GetBotChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BotService.BotResource GetBotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.BotService.BotCollection GetBots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BotService.BotResource> GetBots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BotService.BotResource> GetBotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource GetBotServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.Models.CheckNameAvailabilityResponseBody> GetCheckNameAvailabilityBot(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BotService.Models.CheckNameAvailabilityRequestBody checkNameAvailabilityRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.CheckNameAvailabilityResponseBody>> GetCheckNameAvailabilityBotAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.BotService.Models.CheckNameAvailabilityRequestBody checkNameAvailabilityRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.BotService.ConnectionSettingResource GetConnectionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.Models.HostSettingsResponse> GetHostSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.HostSettingsResponse>> GetHostSettingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.Models.OperationResultsDescription> GetOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.Models.OperationResultsDescription>> GetOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.BotService.Models.QnAMakerEndpointKeysResponse> GetQnAMakerEndpointKey(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.BotService.Models.QnAMakerEndpointKeysRequestBody qnAMakerEndpointKeysRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.Models.QnAMakerEndpointKeysResponse>> GetQnAMakerEndpointKeyAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.BotService.Models.QnAMakerEndpointKeysRequestBody qnAMakerEndpointKeysRequestBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.BotService.Models.ServiceProvider> GetServiceProvidersBotConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.BotService.Models.ServiceProvider> GetServiceProvidersBotConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BotServicePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public BotServicePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.BotService.Models.BotServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
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
    public partial class ConnectionSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.ConnectionSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.ConnectionSettingResource>, System.Collections.IEnumerable
    {
        protected ConnectionSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.ConnectionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.BotService.ConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.BotService.ConnectionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.BotService.ConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.BotService.ConnectionSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.BotService.ConnectionSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.BotService.ConnectionSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.BotService.ConnectionSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.BotService.ConnectionSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.ConnectionSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectionSettingData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConnectionSettingData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.ConnectionSettingProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ConnectionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectionSettingResource() { }
        public virtual Azure.ResourceManager.BotService.ConnectionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> GetWithSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> GetWithSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource> Update(Azure.ResourceManager.BotService.ConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.BotService.ConnectionSettingResource>> UpdateAsync(Azure.ResourceManager.BotService.ConnectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.BotService.Models
{
    public partial class AlexaChannel : Azure.ResourceManager.BotService.Models.Channel
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
        public string UrlFragment { get { throw null; } }
    }
    public partial class BotProperties
    {
        public BotProperties(string displayName, string endpoint, string msaAppId) { }
        public System.Collections.Generic.IDictionary<string, string> AllSettings { get { throw null; } }
        public string AppPasswordHint { get { throw null; } set { } }
        public string CmekEncryptionStatus { get { throw null; } }
        public System.Uri CmekKeyVaultUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> ConfiguredChannels { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DeveloperAppInsightKey { get { throw null; } set { } }
        public string DeveloperAppInsightsApiKey { get { throw null; } set { } }
        public string DeveloperAppInsightsApplicationId { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledChannels { get { throw null; } }
        public string Endpoint { get { throw null; } set { } }
        public string EndpointVersion { get { throw null; } }
        public System.Uri IconUri { get { throw null; } set { } }
        public bool? IsCmekEnabled { get { throw null; } set { } }
        public bool? IsDeveloperAppInsightsApiKeySet { get { throw null; } }
        public bool? IsStreamingSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LuisAppIds { get { throw null; } }
        public string LuisKey { get { throw null; } set { } }
        public System.Uri ManifestUri { get { throw null; } set { } }
        public string MigrationToken { get { throw null; } }
        public string MsaAppId { get { throw null; } set { } }
        public string MsaAppMSIResourceId { get { throw null; } set { } }
        public string MsaAppTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.MsaAppType? MsaAppType { get { throw null; } set { } }
        public string OpenWithHint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.BotService.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublishingCredentials { get { throw null; } set { } }
        public string SchemaTransformationVersion { get { throw null; } set { } }
        public string StorageResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
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
    public static partial class BotServiceModelFactory
    {
        public static Azure.ResourceManager.BotService.Models.AlexaChannel AlexaChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.AlexaChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.AlexaChannelProperties AlexaChannelProperties(string alexaSkillId = null, string urlFragment = null, System.Uri serviceEndpointUri = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.BotChannelData BotChannelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.Channel properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.BotData BotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.BotProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotProperties BotProperties(string displayName = null, string description = null, System.Uri iconUri = null, string endpoint = null, string endpointVersion = null, System.Collections.Generic.IDictionary<string, string> allSettings = null, System.Collections.Generic.IDictionary<string, string> parameters = null, System.Uri manifestUri = null, Azure.ResourceManager.BotService.Models.MsaAppType? msaAppType = default(Azure.ResourceManager.BotService.Models.MsaAppType?), string msaAppId = null, string msaAppTenantId = null, string msaAppMSIResourceId = null, System.Collections.Generic.IEnumerable<string> configuredChannels = null, System.Collections.Generic.IEnumerable<string> enabledChannels = null, string developerAppInsightKey = null, string developerAppInsightsApiKey = null, string developerAppInsightsApplicationId = null, System.Collections.Generic.IEnumerable<string> luisAppIds = null, string luisKey = null, bool? isCmekEnabled = default(bool?), System.Uri cmekKeyVaultUri = null, string cmekEncryptionStatus = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.BotService.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.BotService.Models.PublicNetworkAccess?), bool? isStreamingSupported = default(bool?), bool? isDeveloperAppInsightsApiKeySet = default(bool?), string migrationToken = null, bool? disableLocalAuth = default(bool?), string schemaTransformationVersion = null, string storageResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData> privateEndpointConnections = null, string openWithHint = null, string appPasswordHint = null, string provisioningState = null, string publishingCredentials = null) { throw null; }
        public static Azure.ResourceManager.BotService.BotServicePrivateEndpointConnectionData BotServicePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.BotService.Models.BotServicePrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.BotService.Models.BotServicePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServicePrivateLinkResource BotServicePrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.BotServiceSku BotServiceSku(Azure.ResourceManager.BotService.Models.BotServiceSkuName name = default(Azure.ResourceManager.BotService.Models.BotServiceSkuName), Azure.ResourceManager.BotService.Models.BotServiceSkuTier? tier = default(Azure.ResourceManager.BotService.Models.BotServiceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.Channel Channel(string channelName = null, Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ChannelSettings ChannelSettings(string extensionKey1 = null, string extensionKey2 = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.Site> sites = null, string channelId = null, string channelDisplayName = null, string botId = null, System.Uri botIconUri = null, bool? isEnabled = default(bool?), bool? disableLocalAuth = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.CheckNameAvailabilityResponseBody CheckNameAvailabilityResponseBody(bool? valid = default(bool?), string message = null) { throw null; }
        public static Azure.ResourceManager.BotService.ConnectionSettingData ConnectionSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.ConnectionSettingProperties properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ConnectionSettingProperties ConnectionSettingProperties(string id = null, string name = null, string clientId = null, string settingId = null, string clientSecret = null, string scopes = null, string serviceProviderId = null, string serviceProviderDisplayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.ConnectionSettingParameter> parameters = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.CreateEmailSignInUrlResponse CreateEmailSignInUrlResponse(string id = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Uri createEmailSignInUrlResponseUri = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineChannel DirectLineChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.DirectLineChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineChannelProperties DirectLineChannelProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.DirectLineSite> sites = null, string extensionKey1 = null, string extensionKey2 = null, string directLineEmbedCode = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineSite DirectLineSite(string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.DirectLineSpeechChannel DirectLineSpeechChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.DirectLineSpeechChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.EmailChannel EmailChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.EmailChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.FacebookChannel FacebookChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.FacebookChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.FacebookChannelProperties FacebookChannelProperties(string verifyToken = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.FacebookPage> pages = null, string appId = null, string appSecret = null, System.Uri callbackUri = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.Models.HostSettingsResponse HostSettingsResponse(System.Uri oAuthUri = null, System.Uri toBotFromChannelOpenIdMetadataUri = null, string toBotFromChannelTokenIssuer = null, System.Uri toBotFromEmulatorOpenIdMetadataUri = null, System.Uri toChannelFromBotLoginUri = null, string toChannelFromBotOAuthScope = null, bool? validateAuthority = default(bool?), string botOpenIdMetadata = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.KikChannel KikChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.KikChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineChannel LineChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.LineChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineChannelProperties LineChannelProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.LineRegistration> lineRegistrations = null, System.Uri callbackUri = null, bool? isValidated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.LineRegistration LineRegistration(string generatedId = null, string channelSecret = null, string channelAccessToken = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ListChannelWithKeysResponse ListChannelWithKeysResponse(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.BotService.Models.Channel resource = null, Azure.ResourceManager.BotService.Models.ChannelSettings setting = null, string provisioningState = null, string entityTag = null, string changedTime = null, Azure.ResourceManager.BotService.Models.Channel properties = null, Azure.ResourceManager.BotService.Models.BotServiceSku sku = null, Azure.ResourceManager.BotService.Models.BotServiceKind? kind = default(Azure.ResourceManager.BotService.Models.BotServiceKind?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.MsTeamsChannel MsTeamsChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.MsTeamsChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.OperationResultsDescription OperationResultsDescription(string id = null, string name = null, Azure.ResourceManager.BotService.Models.OperationResultStatus? status = default(Azure.ResourceManager.BotService.Models.OperationResultStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.OutlookChannel OutlookChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.QnAMakerEndpointKeysResponse QnAMakerEndpointKeysResponse(string primaryEndpointKey = null, string secondaryEndpointKey = null, string installedVersion = null, string lastStableVersion = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ServiceProvider ServiceProvider(Azure.ResourceManager.BotService.Models.ServiceProviderProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ServiceProviderParameter ServiceProviderParameter(string name = null, string serviceProviderParameterType = null, string displayName = null, string description = null, System.Uri helpUri = null, string @default = null, bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ServiceProviderProperties ServiceProviderProperties(string id = null, string displayName = null, string serviceProviderName = null, System.Uri devPortalUri = null, System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.ServiceProviderParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.Site Site(string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SkypeChannel SkypeChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SkypeChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SlackChannel SlackChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SlackChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SlackChannelProperties SlackChannelProperties(string clientId = null, string clientSecret = null, string verificationToken = null, string scopes = null, System.Uri landingPageUri = null, string redirectAction = null, string lastSubmissionId = null, bool? registerBeforeOAuthFlow = default(bool?), bool? isValidated = default(bool?), string signingSecret = null, bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.BotService.Models.SmsChannel SmsChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.SmsChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.TelegramChannel TelegramChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.TelegramChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatChannel WebChatChannel(Azure.ETag? etag = default(Azure.ETag?), string provisioningState = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.BotService.Models.WebChatChannelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatChannelProperties WebChatChannelProperties(string webChatEmbedCode = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.BotService.Models.WebChatSite> sites = null) { throw null; }
        public static Azure.ResourceManager.BotService.Models.WebChatSite WebChatSite(string siteId = null, string siteName = null, string key = null, string key2 = null, bool isEnabled = false, bool? isTokenEnabled = default(bool?), bool? isEndpointParametersEnabled = default(bool?), bool? isDetailedLoggingEnabled = default(bool?), bool? isBlockUserUploadEnabled = default(bool?), bool? isNoStorageEnabled = default(bool?), Azure.ETag? etag = default(Azure.ETag?), string appId = null, bool? isV1Enabled = default(bool?), bool? isV3Enabled = default(bool?), bool? isSecureSiteEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> trustedOrigins = null, bool? isWebchatPreviewEnabled = default(bool?)) { throw null; }
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
    public partial class BotServicePrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public BotServicePrivateLinkResource() { }
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
    public abstract partial class Channel
    {
        protected Channel() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelName : System.IEquatable<Azure.ResourceManager.BotService.Models.ChannelName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelName(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.ChannelName AlexaChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName DirectLineChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName DirectLineSpeechChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName EmailChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName FacebookChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName KikChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName LineChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName MsTeamsChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName Omnichannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName OutlookChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName SkypeChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName SlackChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName SmsChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName TelegramChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName TelephonyChannel { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.ChannelName WebChatChannel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.ChannelName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.ChannelName left, Azure.ResourceManager.BotService.Models.ChannelName right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.ChannelName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.ChannelName left, Azure.ResourceManager.BotService.Models.ChannelName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChannelSettings
    {
        public ChannelSettings() { }
        public System.Uri BotIconUri { get { throw null; } set { } }
        public string BotId { get { throw null; } set { } }
        public string ChannelDisplayName { get { throw null; } set { } }
        public string ChannelId { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExtensionKey1 { get { throw null; } }
        public string ExtensionKey2 { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.Site> Sites { get { throw null; } }
    }
    public partial class CheckNameAvailabilityRequestBody
    {
        public CheckNameAvailabilityRequestBody() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResponseBody
    {
        internal CheckNameAvailabilityResponseBody() { }
        public string Message { get { throw null; } }
        public bool? Valid { get { throw null; } }
    }
    public partial class ConnectionSettingParameter
    {
        public ConnectionSettingParameter() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ConnectionSettingProperties
    {
        public ConnectionSettingProperties() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.ConnectionSettingParameter> Parameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
        public string Scopes { get { throw null; } set { } }
        public string ServiceProviderDisplayName { get { throw null; } set { } }
        public string ServiceProviderId { get { throw null; } set { } }
        public string SettingId { get { throw null; } }
    }
    public partial class CreateEmailSignInUrlResponse
    {
        internal CreateEmailSignInUrlResponse() { }
        public System.Uri CreateEmailSignInUrlResponseUri { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class DirectLineChannel : Azure.ResourceManager.BotService.Models.Channel
    {
        public DirectLineChannel() { }
        public Azure.ResourceManager.BotService.Models.DirectLineChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class DirectLineChannelProperties
    {
        public DirectLineChannelProperties() { }
        public string DirectLineEmbedCode { get { throw null; } set { } }
        public string ExtensionKey1 { get { throw null; } }
        public string ExtensionKey2 { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.BotService.Models.DirectLineSite> Sites { get { throw null; } }
    }
    public partial class DirectLineSite : Azure.ResourceManager.BotService.Models.Site
    {
        public DirectLineSite(string siteName, bool isEnabled) : base (default(string), default(bool)) { }
    }
    public partial class DirectLineSpeechChannel : Azure.ResourceManager.BotService.Models.Channel
    {
        public DirectLineSpeechChannel() { }
        public Azure.ResourceManager.BotService.Models.DirectLineSpeechChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class DirectLineSpeechChannelProperties
    {
        public DirectLineSpeechChannelProperties() { }
        public string CognitiveServiceRegion { get { throw null; } set { } }
        public string CognitiveServiceResourceId { get { throw null; } set { } }
        public string CognitiveServiceSubscriptionKey { get { throw null; } set { } }
        public string CustomSpeechModelId { get { throw null; } set { } }
        public string CustomVoiceDeploymentId { get { throw null; } set { } }
        public bool? IsDefaultBotForCogSvcAccount { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class EmailChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class FacebookChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class HostSettingsResponse
    {
        internal HostSettingsResponse() { }
        public string BotOpenIdMetadata { get { throw null; } }
        public System.Uri OAuthUri { get { throw null; } }
        public System.Uri ToBotFromChannelOpenIdMetadataUri { get { throw null; } }
        public string ToBotFromChannelTokenIssuer { get { throw null; } }
        public System.Uri ToBotFromEmulatorOpenIdMetadataUri { get { throw null; } }
        public System.Uri ToChannelFromBotLoginUri { get { throw null; } }
        public string ToChannelFromBotOAuthScope { get { throw null; } }
        public bool? ValidateAuthority { get { throw null; } }
    }
    public enum Key
    {
        Key1 = 0,
        Key2 = 1,
    }
    public partial class KikChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class LineChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class ListChannelWithKeysResponse : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ListChannelWithKeysResponse(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ChangedTime { get { throw null; } set { } }
        public string EntityTag { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.Channel Properties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.Channel Resource { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.ChannelSettings Setting { get { throw null; } set { } }
        public Azure.ResourceManager.BotService.Models.BotServiceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MsaAppType : System.IEquatable<Azure.ResourceManager.BotService.Models.MsaAppType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MsaAppType(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.MsaAppType MultiTenant { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.MsaAppType SingleTenant { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.MsaAppType UserAssignedMSI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.MsaAppType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.MsaAppType left, Azure.ResourceManager.BotService.Models.MsaAppType right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.MsaAppType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.MsaAppType left, Azure.ResourceManager.BotService.Models.MsaAppType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MsTeamsChannel : Azure.ResourceManager.BotService.Models.Channel
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
        public bool? EnableCalling { get { throw null; } set { } }
        public string IncomingCallRoute { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public partial class OperationResultsDescription
    {
        internal OperationResultsDescription() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.BotService.Models.OperationResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationResultStatus : System.IEquatable<Azure.ResourceManager.BotService.Models.OperationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.OperationResultStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.OperationResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.OperationResultStatus Requested { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.OperationResultStatus Running { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.OperationResultStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.OperationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.OperationResultStatus left, Azure.ResourceManager.BotService.Models.OperationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.OperationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.OperationResultStatus left, Azure.ResourceManager.BotService.Models.OperationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutlookChannel : Azure.ResourceManager.BotService.Models.Channel
    {
        public OutlookChannel() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.BotService.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.BotService.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.BotService.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.BotService.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.BotService.Models.PublicNetworkAccess left, Azure.ResourceManager.BotService.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.BotService.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.BotService.Models.PublicNetworkAccess left, Azure.ResourceManager.BotService.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QnAMakerEndpointKeysRequestBody
    {
        public QnAMakerEndpointKeysRequestBody() { }
        public string Authkey { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
    }
    public partial class QnAMakerEndpointKeysResponse
    {
        internal QnAMakerEndpointKeysResponse() { }
        public string InstalledVersion { get { throw null; } }
        public string LastStableVersion { get { throw null; } }
        public string PrimaryEndpointKey { get { throw null; } }
        public string SecondaryEndpointKey { get { throw null; } }
    }
    public enum RegenerateKeysChannelName
    {
        WebChatChannel = 0,
        DirectLineChannel = 1,
    }
    public partial class ServiceProvider
    {
        internal ServiceProvider() { }
        public Azure.ResourceManager.BotService.Models.ServiceProviderProperties Properties { get { throw null; } }
    }
    public partial class ServiceProviderParameter
    {
        internal ServiceProviderParameter() { }
        public string Default { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri HelpUri { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string ServiceProviderParameterType { get { throw null; } }
    }
    public partial class ServiceProviderProperties
    {
        internal ServiceProviderProperties() { }
        public System.Uri DevPortalUri { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.BotService.Models.ServiceProviderParameter> Parameters { get { throw null; } }
        public string ServiceProviderName { get { throw null; } }
    }
    public partial class Site
    {
        public Site(string siteName, bool isEnabled) { }
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
        public string Key { get { throw null; } }
        public string Key2 { get { throw null; } }
        public string SiteId { get { throw null; } }
        public string SiteName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TrustedOrigins { get { throw null; } }
    }
    public partial class SiteContent
    {
        public SiteContent(string siteName, Azure.ResourceManager.BotService.Models.Key key) { }
        public Azure.ResourceManager.BotService.Models.Key Key { get { throw null; } }
        public string SiteName { get { throw null; } }
    }
    public partial class SkypeChannel : Azure.ResourceManager.BotService.Models.Channel
    {
        public SkypeChannel() { }
        public Azure.ResourceManager.BotService.Models.SkypeChannelProperties Properties { get { throw null; } set { } }
    }
    public partial class SkypeChannelProperties
    {
        public SkypeChannelProperties(bool isEnabled) { }
        public string CallingWebHook { get { throw null; } set { } }
        public bool? EnableCalling { get { throw null; } set { } }
        public bool? EnableGroups { get { throw null; } set { } }
        public bool? EnableMediaCards { get { throw null; } set { } }
        public bool? EnableMessaging { get { throw null; } set { } }
        public bool? EnableScreenSharing { get { throw null; } set { } }
        public bool? EnableVideo { get { throw null; } set { } }
        public string GroupsMode { get { throw null; } set { } }
        public string IncomingCallRoute { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
    }
    public partial class SlackChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class SmsChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class TelegramChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class WebChatChannel : Azure.ResourceManager.BotService.Models.Channel
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
    public partial class WebChatSite : Azure.ResourceManager.BotService.Models.Site
    {
        public WebChatSite(string siteName, bool isEnabled) : base (default(string), default(bool)) { }
    }
}
