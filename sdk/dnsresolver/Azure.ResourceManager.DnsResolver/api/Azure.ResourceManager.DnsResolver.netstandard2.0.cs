namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsForwardingRulesetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>, System.Collections.IEnumerable
    {
        protected DnsForwardingRulesetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Get(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetAsync(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsForwardingRulesetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DnsForwardingRulesetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResolverOutboundEndpoints { get { throw null; } }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
    }
    public partial class DnsForwardingRulesetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsForwardingRulesetResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> GetForwardingRule(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>> GetForwardingRuleAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleCollection GetForwardingRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> GetVirtualNetworkLink(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>> GetVirtualNetworkLinkAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkLinkCollection GetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>, System.Collections.IEnumerable
    {
        protected DnsResolverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> Get(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DnsResolverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverState? DnsResolverState { get { throw null; } }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
    }
    public static partial class DnsResolverExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRuleset(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetDnsForwardingRulesetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource GetDnsForwardingRulesetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetCollection GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolver(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetDnsResolverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverResource GetDnsResolverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolvers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolversByVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolversByVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.ForwardingRuleResource GetForwardingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.InboundEndpointResource GetInboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.OutboundEndpointResource GetOutboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource GetVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DnsResolverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> GetInboundEndpoint(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> GetInboundEndpointAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.InboundEndpointCollection GetInboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> GetOutboundEndpoint(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> GetOutboundEndpointAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.OutboundEndpointCollection GetOutboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ForwardingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>, System.Collections.IEnumerable
    {
        protected ForwardingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> Get(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>> GetAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ForwardingRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public ForwardingRuleData() { }
        public string DomainName { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState? ForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
    }
    public partial class ForwardingRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ForwardingRuleResource() { }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName, string forwardingRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource> Update(Azure.ResourceManager.DnsResolver.Models.ForwardingRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRuleResource>> UpdateAsync(Azure.ResourceManager.DnsResolver.Models.ForwardingRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpointResource>, System.Collections.IEnumerable
    {
        protected InboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> Get(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.InboundEndpointResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.InboundEndpointResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> GetAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.InboundEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.InboundEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InboundEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public InboundEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.IPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
    }
    public partial class InboundEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InboundEndpointResource() { }
        public virtual Azure.ResourceManager.DnsResolver.InboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string inboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.InboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.InboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>, System.Collections.IEnumerable
    {
        protected OutboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> Get(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> GetAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OutboundEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OutboundEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class OutboundEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OutboundEndpointResource() { }
        public virtual Azure.ResourceManager.DnsResolver.OutboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string outboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.OutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.OutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> Get(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>> GetAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkLinkData() { }
        public string Etag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkLinkResource() { }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName, string virtualNetworkLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DnsResolver.Models
{
    public partial class DnsForwardingRulesetPatch
    {
        public DnsForwardingRulesetPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DnsResolverPatch
    {
        public DnsResolverPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsResolverState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsResolverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsResolverState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverState Connected { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverState Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsResolverState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsResolverState left, Azure.ResourceManager.DnsResolver.Models.DnsResolverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsResolverState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsResolverState left, Azure.ResourceManager.DnsResolver.Models.DnsResolverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForwardingRulePatch
    {
        public ForwardingRulePatch() { }
        public Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState? ForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForwardingRuleState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForwardingRuleState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState left, Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState left, Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundEndpointPatch
    {
        public InboundEndpointPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAllocationMethod : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod left, Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod left, Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPConfiguration
    {
        public IPConfiguration() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.DnsResolver.Models.IPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class OutboundEndpointPatch
    {
        public OutboundEndpointPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.ProvisioningState left, Azure.ResourceManager.DnsResolver.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.ProvisioningState left, Azure.ResourceManager.DnsResolver.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetDnsServer
    {
        public TargetDnsServer() { }
        public string IPAddress { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
    }
    public partial class VirtualNetworkDnsForwardingRuleset
    {
        internal VirtualNetworkDnsForwardingRuleset() { }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkLinkId { get { throw null; } }
    }
    public partial class VirtualNetworkLinkPatch
    {
        public VirtualNetworkLinkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
}
