namespace Azure.ResourceManager.EventGrid
{
    public partial class ChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.ChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.ChannelResource>, System.Collections.IEnumerable
    {
        protected ChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.ChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.ChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.ChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.ChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource> Get(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.ChannelResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.ChannelResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource>> GetAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.ChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.ChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.ChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.ChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChannelData : Azure.ResourceManager.Models.ResourceData
    {
        public ChannelData() { }
        public Azure.ResourceManager.EventGrid.Models.ChannelType? ChannelType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeIfNotActivatedUtc { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo PartnerTopicInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ReadinessState? ReadinessState { get { throw null; } set { } }
    }
    public partial class ChannelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChannelResource() { }
        public virtual Azure.ResourceManager.EventGrid.ChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerNamespaceName, string channelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.EventGrid.Models.ChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.EventGrid.Models.ChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainResource>, System.Collections.IEnumerable
    {
        protected DomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.DomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.DomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.InputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.InputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.DomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class DomainEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DomainEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainEventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainResource() { }
        public virtual Azure.ResourceManager.EventGrid.DomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetDomainEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetDomainEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainEventSubscriptionCollection GetDomainEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> GetDomainTopic(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetDomainTopicAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicCollection GetDomainTopics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.DomainSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.DomainSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.DomainSharedAccessKeys> RegenerateKey(Azure.ResourceManager.EventGrid.Models.DomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.DomainSharedAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.EventGrid.Models.DomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.DomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.DomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>, System.Collections.IEnumerable
    {
        protected DomainTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> Get(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainTopicData : Azure.ResourceManager.Models.ResourceData
    {
        public DomainTopicData() { }
        public Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DomainTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DomainTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainTopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string domainTopicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetDomainTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetDomainTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionCollection GetDomainTopicEventSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected EventGridDomainPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> CreateOrUpdate(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected EventGridDomainPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EventGridExtensions
    {
        public static Azure.ResourceManager.EventGrid.ChannelResource GetChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.DomainResource> GetDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainResource>> GetDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource GetDomainEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainResource GetDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainCollection GetDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.DomainResource> GetDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainResource> GetDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource GetDomainTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicResource GetDomainTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetEventGridDomainPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetEventGridDomainPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionCollection GetEventGridDomainPrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetEventGridDomainPrivateLinkResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetEventGridDomainPrivateLinkResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetEventGridPartnerNamespacePrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetEventGridPartnerNamespacePrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionCollection GetEventGridPartnerNamespacePrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetEventGridTopicPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetEventGridTopicPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionCollection GetEventGridTopicPrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetEventGridTopicPrivateLinkResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetEventGridTopicPrivateLinkResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetEventSubscription(this Azure.ResourceManager.ArmResource armResource, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetEventSubscriptionAsync(this Azure.ResourceManager.ArmResource armResource, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionResource GetEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionCollection GetEventSubscriptions(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventType> GetEventTypesTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerNamespace, string resourceTypeName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventType> GetEventTypesTopicsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerNamespace, string resourceTypeName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopic(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetGlobalByResourceGroupForTopicTypeEventSubscriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetGlobalByResourceGroupForTopicTypeEventSubscriptionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetGlobalBySubscriptionForTopicTypeEventSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetGlobalBySubscriptionForTopicTypeEventSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetPartnerNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetPartnerNamespacePrivateLinkResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetPartnerNamespacePrivateLinkResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentName) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceResource GetPartnerNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceCollection GetPartnerNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetPartnerRegistrationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerRegistrationResource GetPartnerRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerRegistrationCollection GetPartnerRegistrations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetPartnerTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource GetPartnerTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicResource GetPartnerTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicCollection GetPartnerTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalByResourceGroupEventSubscriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalByResourceGroupEventSubscriptionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalByResourceGroupForTopicTypeEventSubscriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalByResourceGroupForTopicTypeEventSubscriptionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalBySubscriptionEventSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalBySubscriptionEventSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalBySubscriptionForTopicTypeEventSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetRegionalBySubscriptionForTopicTypeEventSubscriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetSystemTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource GetSystemTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicResource GetSystemTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicCollection GetSystemTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> GetTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> GetTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource GetTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicResource GetTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicCollection GetTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.TopicResource> GetTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicResource> GetTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> GetTopicTypeInfo(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>> GetTopicTypeInfoAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeInfoResource GetTopicTypeInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeInfoCollection GetTopicTypeInfos(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetVerifiedPartner(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetVerifiedPartnerAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerResource GetVerifiedPartnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerCollection GetVerifiedPartners(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected EventGridPartnerNamespacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> CreateOrUpdate(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridPartnerNamespacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public EventGridPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.EventGrid.Models.ConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class EventGridPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventGridPrivateLinkResourceData() { }
        public string DisplayName { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class EventGridTopicPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected EventGridTopicPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> CreateOrUpdate(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parentName, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected EventGridTopicPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected EventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventSubscriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public EventSubscriptionData() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.RetryPolicy RetryPolicy { get { throw null; } set { } }
        public string Topic { get { throw null; } }
    }
    public partial class EventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtensionTopicData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtensionTopicData() { }
        public string Description { get { throw null; } set { } }
        public string SystemTopic { get { throw null; } set { } }
    }
    public partial class ExtensionTopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.ExtensionTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.ExtensionTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.ExtensionTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PartnerConfigurationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventGrid.Models.PartnerAuthorization PartnerAuthorization { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class PartnerConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerConfigurationResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> AuthorizePartner(Azure.ResourceManager.EventGrid.Models.Partner partnerInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> AuthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.Partner partnerInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.PartnerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.PartnerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> UnauthorizePartner(Azure.ResourceManager.EventGrid.Models.Partner partnerInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UnauthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.Partner partnerInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerNamespaceName, Azure.ResourceManager.EventGrid.PartnerNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerNamespaceName, Azure.ResourceManager.EventGrid.PartnerNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> Get(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerNamespaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PartnerNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public string PartnerRegistrationFullyQualifiedId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode? PartnerTopicRoutingMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class PartnerNamespacePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected PartnerNamespacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> Get(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAll(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData> GetAllAsync(string parentName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>> GetAsync(string parentName, string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespaceResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerNamespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource> GetChannel(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.ChannelResource>> GetChannelAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.ChannelCollection GetChannels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys> RegenerateKey(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>, System.Collections.IEnumerable
    {
        protected PartnerRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerRegistrationName, Azure.ResourceManager.EventGrid.PartnerRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerRegistrationName, Azure.ResourceManager.EventGrid.PartnerRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> Get(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerRegistrationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PartnerRegistrationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PartnerRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerRegistrationResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerRegistrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>, System.Collections.IEnumerable
    {
        protected PartnerTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerTopicName, Azure.ResourceManager.EventGrid.PartnerTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerTopicName, Azure.ResourceManager.EventGrid.PartnerTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Get(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerTopicData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PartnerTopicData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState? ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeIfNotActivatedUtc { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public string PartnerTopicFriendlyDescription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class PartnerTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected PartnerTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerTopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Activate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> ActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerTopicName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Deactivate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> DeactivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetPartnerTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetPartnerTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionCollection GetPartnerTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Update(Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> UpdateAsync(Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SystemTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>, System.Collections.IEnumerable
    {
        protected SystemTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string systemTopicName, Azure.ResourceManager.EventGrid.SystemTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string systemTopicName, Azure.ResourceManager.EventGrid.SystemTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> Get(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.SystemTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.SystemTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SystemTopicData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SystemTopicData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string TopicType { get { throw null; } set { } }
    }
    public partial class SystemTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected SystemTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SystemTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string systemTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SystemTopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string systemTopicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetSystemTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetSystemTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionCollection GetSystemTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.SystemTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.SystemTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicResource>, System.Collections.IEnumerable
    {
        protected TopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.TopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.TopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TopicData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.InputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.InputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.TopicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class TopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected TopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicEventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventSubscriptionUpdateParameters eventSubscriptionUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.TopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicEventSubscriptionCollection GetTopicEventSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicTypeInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>, System.Collections.IEnumerable
    {
        protected TopicTypeInfoCollection() { }
        public virtual Azure.Response<bool> Exists(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> Get(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>> GetAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicTypeInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public TopicTypeInfoData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ResourceRegionType? ResourceRegionType { get { throw null; } set { } }
        public string SourceResourceFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope> SupportedScopesForSource { get { throw null; } }
    }
    public partial class TopicTypeInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicTypeInfoResource() { }
        public virtual Azure.ResourceManager.EventGrid.TopicTypeInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string topicTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventType> GetEventTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventType> GetEventTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VerifiedPartnerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>, System.Collections.IEnumerable
    {
        protected VerifiedPartnerCollection() { }
        public virtual Azure.Response<bool> Exists(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> Get(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VerifiedPartnerData : Azure.ResourceManager.Models.ResourceData
    {
        public VerifiedPartnerData() { }
        public string OrganizationName { get { throw null; } set { } }
        public string PartnerDisplayName { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerDetails PartnerTopicDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class VerifiedPartnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VerifiedPartnerResource() { }
        public virtual Azure.ResourceManager.EventGrid.VerifiedPartnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string verifiedPartnerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class AdvancedFilter
    {
        public AdvancedFilter() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AzureFunctionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public AzureFunctionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class BoolEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public BoolEqualsAdvancedFilter() { }
        public bool? Value { get { throw null; } set { } }
    }
    public partial class ChannelPatch
    {
        public ChannelPatch() { }
        public Azure.ResourceManager.EventGrid.Models.EventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeIfNotActivatedUtc { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState IdleDueToMirroredPartnerTopicDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.ChannelProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ChannelType PartnerTopic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ChannelType left, Azure.ResourceManager.EventGrid.Models.ChannelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ChannelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ChannelType left, Azure.ResourceManager.EventGrid.Models.ChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectionState
    {
        public ConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataResidencyBoundary : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataResidencyBoundary(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary WithinGeopair { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary WithinRegion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary left, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary left, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeadLetterDestination
    {
        public DeadLetterDestination() { }
    }
    public partial class DeadLetterWithResourceIdentity
    {
        public DeadLetterWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
    }
    public partial class DeliveryAttributeMapping
    {
        public DeliveryAttributeMapping() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DeliveryWithResourceIdentity
    {
        public DeliveryWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
    }
    public partial class DomainPatch
    {
        public DomainPatch() { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DomainProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DomainProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DomainProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainRegenerateKeyContent
    {
        public DomainRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class DomainSharedAccessKeys
    {
        internal DomainSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicDeliveryAttributeMapping : Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping
    {
        public DynamicDeliveryAttributeMapping() { }
        public string SourceField { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventDefinitionKind : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventDefinitionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventDefinitionKind(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventDefinitionKind Inline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind left, Azure.ResourceManager.EventGrid.Models.EventDefinitionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventDefinitionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind left, Azure.ResourceManager.EventGrid.Models.EventDefinitionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventDeliverySchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventDeliverySchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventDeliverySchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema CloudEventSchemaV10 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema CustomInputSchema { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema EventGridSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema left, Azure.ResourceManager.EventGrid.Models.EventDeliverySchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventDeliverySchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema left, Azure.ResourceManager.EventGrid.Models.EventDeliverySchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public EventHubEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class EventSubscriptionDestination
    {
        public EventSubscriptionDestination() { }
    }
    public partial class EventSubscriptionFilter
    {
        public EventSubscriptionFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.AdvancedFilter> AdvancedFilters { get { throw null; } }
        public bool? EnableAdvancedFilteringOnArrays { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IncludedEventTypes { get { throw null; } }
        public bool? IsSubjectCaseSensitive { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
    }
    public partial class EventSubscriptionFullUri
    {
        internal EventSubscriptionFullUri() { }
        public System.Uri EndpointUri { get { throw null; } }
    }
    public partial class EventSubscriptionIdentity
    {
        public EventSubscriptionIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState AwaitingManualAction { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventSubscriptionUpdateParameters
    {
        public EventSubscriptionUpdateParameters() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.RetryPolicy RetryPolicy { get { throw null; } set { } }
    }
    public partial class EventType : Azure.ResourceManager.Models.ResourceData
    {
        public EventType() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsInDefaultSet { get { throw null; } set { } }
        public System.Uri SchemaUri { get { throw null; } set { } }
    }
    public partial class EventTypeInfo
    {
        public EventTypeInfo() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.EventGrid.Models.InlineEventProperties> InlineEventTypes { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventDefinitionKind? Kind { get { throw null; } set { } }
    }
    public partial class HybridConnectionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public HybridConnectionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class IdentityInfo
    {
        public IdentityInfo() { }
        public Azure.ResourceManager.EventGrid.Models.IdentityType? IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.IdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.IdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.IdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.IdentityType left, Azure.ResourceManager.EventGrid.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.IdentityType left, Azure.ResourceManager.EventGrid.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundIPRule
    {
        public InboundIPRule() { }
        public Azure.ResourceManager.EventGrid.Models.IPActionType? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class InlineEventProperties
    {
        public InlineEventProperties() { }
        public System.Uri DataSchemaUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputSchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.InputSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputSchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.InputSchema CloudEventSchemaV10 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.InputSchema CustomEventSchema { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.InputSchema EventGridSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.InputSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.InputSchema left, Azure.ResourceManager.EventGrid.Models.InputSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.InputSchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.InputSchema left, Azure.ResourceManager.EventGrid.Models.InputSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InputSchemaMapping
    {
        public InputSchemaMapping() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPActionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.IPActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPActionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.IPActionType Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.IPActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.IPActionType left, Azure.ResourceManager.EventGrid.Models.IPActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.IPActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.IPActionType left, Azure.ResourceManager.EventGrid.Models.IPActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IsNotNullAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public IsNotNullAdvancedFilter() { }
    }
    public partial class IsNullOrUndefinedAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public IsNullOrUndefinedAdvancedFilter() { }
    }
    public partial class JsonFieldWithDefault
    {
        public JsonFieldWithDefault() { }
        public string DefaultValue { get { throw null; } set { } }
        public string SourceField { get { throw null; } set { } }
    }
    public partial class JsonInputSchemaMapping : Azure.ResourceManager.EventGrid.Models.InputSchemaMapping
    {
        public JsonInputSchemaMapping() { }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault DataVersion { get { throw null; } set { } }
        public string EventTimeSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault EventType { get { throw null; } set { } }
        public string IdSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault Subject { get { throw null; } set { } }
        public string TopicSourceField { get { throw null; } set { } }
    }
    public partial class NumberGreaterThanAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberGreaterThanAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
    }
    public partial class NumberGreaterThanOrEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberGreaterThanOrEqualsAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
    }
    public partial class NumberInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberInAdvancedFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
    }
    public partial class NumberInRangeAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberInRangeAdvancedFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
    }
    public partial class NumberLessThanAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberLessThanAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
    }
    public partial class NumberLessThanOrEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberLessThanOrEqualsAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
    }
    public partial class NumberNotInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberNotInAdvancedFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
    }
    public partial class NumberNotInRangeAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public NumberNotInRangeAdvancedFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
    }
    public partial class Partner
    {
        public Partner() { }
        public System.DateTimeOffset? AuthorizationExpirationTimeInUtc { get { throw null; } set { } }
        public string PartnerName { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
    }
    public partial class PartnerAuthorization
    {
        public PartnerAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.Partner> AuthorizedPartnersList { get { throw null; } }
        public int? DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
    }
    public partial class PartnerConfigurationPatch
    {
        public PartnerConfigurationPatch() { }
        public int? DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerDetails
    {
        public PartnerDetails() { }
        public string Description { get { throw null; } set { } }
        public string LongDescription { get { throw null; } set { } }
        public System.Uri SetupUri { get { throw null; } set { } }
    }
    public partial class PartnerNamespacePatch
    {
        public PartnerNamespacePatch() { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerNamespaceRegenerateKeyContent
    {
        public PartnerNamespaceRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class PartnerNamespaceSharedAccessKeys
    {
        internal PartnerNamespaceSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    public partial class PartnerRegistrationPatch
    {
        public PartnerRegistrationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerRegistrationProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerRegistrationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicActivationState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicActivationState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState Deactivated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerTopicInfo
    {
        public PartnerTopicInfo() { }
        public string AzureSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class PartnerTopicPatch
    {
        public PartnerTopicPatch() { }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState IdleDueToMirroredChannelResourceDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicRoutingMode : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicRoutingMode(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode ChannelNameHeader { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode SourceEventAttribute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode left, Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode left, Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistedConnectionStatus : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistedConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.PersistedConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadinessState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ReadinessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadinessState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ReadinessState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ReadinessState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ReadinessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ReadinessState left, Azure.ResourceManager.EventGrid.Models.ReadinessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ReadinessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ReadinessState left, Azure.ResourceManager.EventGrid.Models.ReadinessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceRegionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ResourceRegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceRegionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ResourceRegionType GlobalResource { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceRegionType RegionalResource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ResourceRegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ResourceRegionType left, Azure.ResourceManager.EventGrid.Models.ResourceRegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ResourceRegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ResourceRegionType left, Azure.ResourceManager.EventGrid.Models.ResourceRegionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetryPolicy
    {
        public RetryPolicy() { }
        public int? EventTimeToLiveInMinutes { get { throw null; } set { } }
        public int? MaxDeliveryAttempts { get { throw null; } set { } }
    }
    public partial class ServiceBusQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public ServiceBusQueueEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ServiceBusTopicEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public ServiceBusTopicEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class StaticDeliveryAttributeMapping : Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping
    {
        public StaticDeliveryAttributeMapping() { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class StorageBlobDeadLetterDestination : Azure.ResourceManager.EventGrid.Models.DeadLetterDestination
    {
        public StorageBlobDeadLetterDestination() { }
        public string BlobContainerName { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class StorageQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public StorageQueueEventSubscriptionDestination() { }
        public long? QueueMessageTimeToLiveInSeconds { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class StringBeginsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringBeginsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringContainsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringContainsAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringEndsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringEndsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringInAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringNotBeginsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringNotBeginsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringNotContainsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringNotContainsAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringNotEndsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringNotEndsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class StringNotInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public StringNotInAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class SystemTopicPatch
    {
        public SystemTopicPatch() { }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TopicPatch
    {
        public TopicPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.IdentityInfo Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.InboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopicRegenerateKeyContent
    {
        public TopicRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class TopicSharedAccessKeys
    {
        internal TopicSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicTypeProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicTypeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicTypeSourceScope : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicTypeSourceScope(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope AzureSubscription { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope Resource { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope ResourceGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope left, Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope left, Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VerifiedPartnerProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VerifiedPartnerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState left, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState left, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebHookEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public WebHookEventSubscriptionDestination() { }
        public System.Uri AzureActiveDirectoryApplicationIdOrUri { get { throw null; } set { } }
        public string AzureActiveDirectoryTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public System.Uri EndpointBaseUri { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
    }
}
