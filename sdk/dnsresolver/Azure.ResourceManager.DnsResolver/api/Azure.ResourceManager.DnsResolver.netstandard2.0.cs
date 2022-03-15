namespace Azure.ResourceManager.DnsResolver
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRuleset GetDnsForwardingRuleset(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolver GetDnsResolver(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.ForwardingRule GetForwardingRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.InboundEndpoint GetInboundEndpoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.OutboundEndpoint GetOutboundEndpoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.VirtualNetworkLink GetVirtualNetworkLink(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DnsForwardingRuleset : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsForwardingRuleset() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> GetForwardingRule(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> GetForwardingRuleAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleCollection GetForwardingRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> GetVirtualNetworkLink(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> GetVirtualNetworkLinkAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkLinkCollection GetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>, System.Collections.IEnumerable
    {
        protected DnsForwardingRulesetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> Get(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> GetAsync(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetIfExists(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> GetIfExistsAsync(string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>.GetEnumerator() { throw null; }
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
    public partial class DnsResolver : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolver() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> GetInboundEndpoint(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> GetInboundEndpointAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.InboundEndpointCollection GetInboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> GetOutboundEndpoint(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> GetOutboundEndpointAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.OutboundEndpointCollection GetOutboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>, System.Collections.IEnumerable
    {
        protected DnsResolverCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolver> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolver>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> Get(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolver> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolver> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> GetAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> GetIfExists(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> GetIfExistsAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolver> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolver> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>.GetEnumerator() { throw null; }
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
    public partial class ForwardingRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ForwardingRule() { }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName, string forwardingRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> Update(Azure.ResourceManager.DnsResolver.Models.PatchableForwardingRuleData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> UpdateAsync(Azure.ResourceManager.DnsResolver.Models.PatchableForwardingRuleData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ForwardingRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>, System.Collections.IEnumerable
    {
        protected ForwardingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.ForwardingRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.ForwardingRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> Get(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.ForwardingRule> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.ForwardingRule> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> GetAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> GetIfExists(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> GetIfExistsAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.ForwardingRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.ForwardingRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>.GetEnumerator() { throw null; }
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
    public partial class InboundEndpoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InboundEndpoint() { }
        public virtual Azure.ResourceManager.DnsResolver.InboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string inboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>, System.Collections.IEnumerable
    {
        protected InboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpoint> CreateOrUpdate(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.InboundEndpoint>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> Get(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.InboundEndpoint> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.InboundEndpoint> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> GetAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> GetIfExists(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> GetIfExistsAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.InboundEndpoint> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.InboundEndpoint> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>.GetEnumerator() { throw null; }
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
    public partial class OutboundEndpoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OutboundEndpoint() { }
        public virtual Azure.ResourceManager.DnsResolver.OutboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string outboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>, System.Collections.IEnumerable
    {
        protected OutboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpoint> CreateOrUpdate(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> Get(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.OutboundEndpoint> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.OutboundEndpoint> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> GetAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> GetIfExists(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> GetIfExistsAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.OutboundEndpoint> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.OutboundEndpoint> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>.GetEnumerator() { throw null; }
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
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetDnsForwardingRuleset(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> GetDnsForwardingRulesetAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string dnsForwardingRulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetCollection GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> GetDnsResolver(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> GetDnsResolverAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolversByVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolversByVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> GetDnsForwardingRulesetsAsync(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolver> GetDnsResolvers(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolver> GetDnsResolversAsync(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkLink() { }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName, string virtualNetworkLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.PatchableVirtualNetworkLinkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.PatchableVirtualNetworkLinkData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>, System.Collections.IEnumerable
    {
        protected VirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> Get(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> GetAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> GetIfExists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> GetIfExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>.GetEnumerator() { throw null; }
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
}
namespace Azure.ResourceManager.DnsResolver.Models
{
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
    public partial class PatchableForwardingRuleData
    {
        public PatchableForwardingRuleData() { }
        public Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState? ForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
    }
    public partial class PatchableVirtualNetworkLinkData
    {
        public PatchableVirtualNetworkLinkData() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
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
        public Azure.Core.ResourceIdentifier VirtualNetworkLinkId { get { throw null; } set { } }
    }
}
