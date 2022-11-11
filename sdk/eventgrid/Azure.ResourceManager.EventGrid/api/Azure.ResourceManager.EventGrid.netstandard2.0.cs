namespace Azure.ResourceManager.EventGrid
{
    public partial class DomainEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DomainEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class EventGridDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.EventGridDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.EventGridDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventGridDomainData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class EventGridDomainPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetDomainEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetDomainEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainEventSubscriptionCollection GetDomainEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> GetDomainTopic(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetDomainTopicAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicCollection GetDomainTopics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetEventGridDomainPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetEventGridDomainPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionCollection GetEventGridDomainPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys> RegenerateKey(Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EventGridExtensions
    {
        public static Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource GetDomainEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource GetDomainTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicResource GetDomainTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetEventGridDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainResource GetEventGridDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainCollection GetEventGridDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetEventGridTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicResource GetEventGridTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicCollection GetEventGridTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetEventSubscription(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetEventSubscriptionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionResource GetEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionCollection GetEventSubscriptions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypes(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetPartnerNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource GetPartnerNamespaceChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetSystemTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource GetSystemTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicResource GetSystemTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicCollection GetSystemTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource GetTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> GetTopicType(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetTopicTypeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeResource GetTopicTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeCollection GetTopicTypes(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetVerifiedPartner(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetVerifiedPartnerAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerResource GetVerifiedPartnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerCollection GetVerifiedPartners(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridPartnerNamespacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridPartnerNamespacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public EventGridPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class EventGridPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventGridPrivateLinkResourceData() { }
        public string DisplayName { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class EventGridSubscriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public EventGridSubscriptionData() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public string Topic { get { throw null; } }
    }
    public partial class EventGridTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.EventGridTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.EventGridTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventGridTopicData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class EventGridTopicPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetEventGridTopicPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetEventGridTopicPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionCollection GetEventGridTopicPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicEventSubscriptionCollection GetTopicEventSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected EventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class EventSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> AuthorizePartner(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> AuthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> UnauthorizePartner(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UnauthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespaceChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespaceChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> Get(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerNamespaceChannelData : Azure.ResourceManager.Models.ResourceData
    {
        public PartnerNamespaceChannelData() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType? ChannelType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo PartnerTopicInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState? ReadinessState { get { throw null; } set { } }
    }
    public partial class PartnerNamespaceChannelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespaceChannelResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerNamespaceName, string channelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Uri Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PartnerRegistrationFullyQualifiedId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode? PartnerTopicRoutingMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class PartnerNamespacePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetEventGridPartnerNamespacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetEventGridPartnerNamespacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionCollection GetEventGridPartnerNamespacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetPartnerNamespaceChannel(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetPartnerNamespaceChannelAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceChannelCollection GetPartnerNamespaceChannels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources() { throw null; }
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
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public string PartnerTopicFriendlyDescription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class PartnerTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected PartnerTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? MetricResourceId { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier Source { get { throw null; } set { } }
        public string TopicType { get { throw null; } set { } }
    }
    public partial class SystemTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected SystemTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string systemTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class TopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected TopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>, System.Collections.IEnumerable
    {
        protected TopicTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> Get(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public TopicTypeData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType? ResourceRegionType { get { throw null; } set { } }
        public string SourceResourceFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope> SupportedScopesForSource { get { throw null; } }
    }
    public partial class TopicTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicTypeResource() { }
        public virtual Azure.ResourceManager.EventGrid.TopicTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string topicTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public abstract partial class AdvancedFilter
    {
        protected AdvancedFilter() { }
        public string Key { get { throw null; } set { } }
    }
    public partial class AzureFunctionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public AzureFunctionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class BoolEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter
    {
        public BoolEqualsAdvancedFilter() { }
        public bool? Value { get { throw null; } set { } }
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
    public abstract partial class DeadLetterDestination
    {
        protected DeadLetterDestination() { }
    }
    public partial class DeadLetterWithResourceIdentity
    {
        public DeadLetterWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
    }
    public abstract partial class DeliveryAttributeMapping
    {
        protected DeliveryAttributeMapping() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DeliveryWithResourceIdentity
    {
        public DeliveryWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
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
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema CloudEventSchemaV1_0 { get { throw null; } }
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
    public partial class EventGridDomainPatch
    {
        public EventGridDomainPatch() { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridDomainProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridDomainProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridDomainRegenerateKeyContent
    {
        public EventGridDomainRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class EventGridDomainSharedAccessKeys
    {
        internal EventGridDomainSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    public partial class EventGridInboundIPRule
    {
        public EventGridInboundIPRule() { }
        public Azure.ResourceManager.EventGrid.Models.EventGridIPActionType? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridInputSchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridInputSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridInputSchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema CloudEventSchemaV1_0 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema CustomEventSchema { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema EventGridSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema left, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridInputSchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema left, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EventGridInputSchemaMapping
    {
        protected EventGridInputSchemaMapping() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridIPActionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridIPActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridIPActionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridIPActionType Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType left, Azure.ResourceManager.EventGrid.Models.EventGridIPActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridIPActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType left, Azure.ResourceManager.EventGrid.Models.EventGridIPActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridJsonInputSchemaMapping : Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping
    {
        public EventGridJsonInputSchemaMapping() { }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault DataVersion { get { throw null; } set { } }
        public string EventTimeSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault EventType { get { throw null; } set { } }
        public string IdSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault Subject { get { throw null; } set { } }
        public string TopicSourceField { get { throw null; } set { } }
    }
    public partial class EventGridPartnerContent
    {
        public EventGridPartnerContent() { }
        public System.DateTimeOffset? AuthorizationExpireOn { get { throw null; } set { } }
        public string PartnerName { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
    }
    public partial class EventGridPrivateEndpointConnectionState
    {
        public EventGridPrivateEndpointConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridPrivateEndpointPersistedConnectionStatus : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridPrivateEndpointPersistedConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridResourceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridResourceRegionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridResourceRegionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType GlobalResource { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType RegionalResource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType left, Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType left, Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridSubscriptionPatch
    {
        public EventGridSubscriptionPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
    }
    public partial class EventGridTopicPatch
    {
        public EventGridTopicPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public EventHubEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public abstract partial class EventSubscriptionDestination
    {
        protected EventSubscriptionDestination() { }
    }
    public partial class EventSubscriptionFilter
    {
        public EventSubscriptionFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.AdvancedFilter> AdvancedFilters { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedEventTypes { get { throw null; } }
        public bool? IsAdvancedFilteringOnArraysEnabled { get { throw null; } set { } }
        public bool? IsSubjectCaseSensitive { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
    }
    public partial class EventSubscriptionFullUri
    {
        internal EventSubscriptionFullUri() { }
        public System.Uri Endpoint { get { throw null; } }
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
    public partial class EventSubscriptionRetryPolicy
    {
        public EventSubscriptionRetryPolicy() { }
        public int? EventTimeToLiveInMinutes { get { throw null; } set { } }
        public int? MaxDeliveryAttempts { get { throw null; } set { } }
    }
    public partial class EventTypeUnderTopic : Azure.ResourceManager.Models.ResourceData
    {
        public EventTypeUnderTopic() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsInDefaultSet { get { throw null; } set { } }
        public System.Uri SchemaUri { get { throw null; } set { } }
    }
    public partial class HybridConnectionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public HybridConnectionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class InlineEventProperties
    {
        public InlineEventProperties() { }
        public System.Uri DataSchemaUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
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
    public partial class PartnerAuthorization
    {
        public PartnerAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent> AuthorizedPartnersList { get { throw null; } }
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
    public partial class PartnerNamespaceChannelPatch
    {
        public PartnerNamespaceChannelPatch() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceChannelProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceChannelProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState IdleDueToMirroredPartnerTopicDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceChannelType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceChannelType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType PartnerTopic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerNamespacePatch
    {
        public PartnerNamespacePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
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
    public partial class PartnerTopicEventTypeInfo
    {
        public PartnerTopicEventTypeInfo() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.EventGrid.Models.InlineEventProperties> InlineEventTypes { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventDefinitionKind? Kind { get { throw null; } set { } }
    }
    public partial class PartnerTopicInfo
    {
        public PartnerTopicInfo() { }
        public System.Guid? AzureSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class PartnerTopicPatch
    {
        public PartnerTopicPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
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
    public readonly partial struct PartnerTopicReadinessState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicReadinessState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState right) { throw null; }
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
    public partial class ServiceBusQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public ServiceBusQueueEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class ServiceBusTopicEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public ServiceBusTopicEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class StorageQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination
    {
        public StorageQueueEventSubscriptionDestination() { }
        public long? QueueMessageTimeToLiveInSeconds { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public System.Guid? AzureActiveDirectoryTenantId { get { throw null; } set { } }
        public System.Uri BaseEndpoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public string UriOrAzureActiveDirectoryApplicationId { get { throw null; } set { } }
    }
}
