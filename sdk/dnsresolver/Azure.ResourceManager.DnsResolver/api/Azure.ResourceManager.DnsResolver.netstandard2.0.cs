namespace Azure.ResourceManager.DnsResolver
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRuleset GetDnsForwardingRuleset(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolver GetDnsResolver(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.ForwardingRule GetForwardingRule(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.InboundEndpoint GetInboundEndpoint(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.OutboundEndpoint GetOutboundEndpoint(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.VirtualNetworkLink GetVirtualNetworkLink(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleCollection GetForwardingRules() { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkLinkCollection GetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>, System.Collections.IEnumerable
    {
        protected DnsForwardingRulesetCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string dnsForwardingRulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DnsForwardingRulesetData : Azure.ResourceManager.Models.TrackedResource
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
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsResolverDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsResolverDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.InboundEndpointCollection GetInboundEndpoints() { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.OutboundEndpointCollection GetOutboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsResolverUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.DnsResolverUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsResolverUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.DnsResolverUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolver>, System.Collections.IEnumerable
    {
        protected DnsResolverCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.DnsResolverCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.DnsResolverCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string dnsResolverName, Azure.ResourceManager.DnsResolver.DnsResolverData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DnsResolverData : Azure.ResourceManager.Models.TrackedResource
    {
        public DnsResolverData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverState? DnsResolverState { get { throw null; } }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualNetwork { get { throw null; } set { } }
    }
    public partial class ForwardingRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ForwardingRule() { }
        public virtual Azure.ResourceManager.DnsResolver.ForwardingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsForwardingRulesetName, string forwardingRuleName) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.ForwardingRuleDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.ForwardingRuleDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule> Update(Azure.ResourceManager.DnsResolver.Models.ForwardingRuleUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> UpdateAsync(Azure.ResourceManager.DnsResolver.Models.ForwardingRuleUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ForwardingRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.ForwardingRule>, System.Collections.IEnumerable
    {
        protected ForwardingRuleCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.ForwardingRuleCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.ForwardingRuleCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string forwardingRuleName, Azure.ResourceManager.DnsResolver.ForwardingRuleData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ForwardingRuleData : Azure.ResourceManager.Models.Resource
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
        public virtual Azure.ResourceManager.DnsResolver.Models.InboundEndpointDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.InboundEndpointDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.InboundEndpointUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.InboundEndpointUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.InboundEndpointUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.InboundEndpointUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.InboundEndpoint>, System.Collections.IEnumerable
    {
        protected InboundEndpointCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.InboundEndpointCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.InboundEndpointCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string inboundEndpointName, Azure.ResourceManager.DnsResolver.InboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class InboundEndpointData : Azure.ResourceManager.Models.TrackedResource
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
        public virtual Azure.ResourceManager.DnsResolver.Models.OutboundEndpointDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.OutboundEndpointDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.OutboundEndpointUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.OutboundEndpointUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.OutboundEndpointUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.OutboundEndpointUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.OutboundEndpoint>, System.Collections.IEnumerable
    {
        protected OutboundEndpointCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.OutboundEndpointCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.OutboundEndpointCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string outboundEndpointName, Azure.ResourceManager.DnsResolver.OutboundEndpointData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class OutboundEndpointData : Azure.ResourceManager.Models.TrackedResource
    {
        public OutboundEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetCollection GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsByVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string virtualNetworkName, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkDeleteOperation Delete(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkDeleteOperation> DeleteAsync(bool waitForCompletion, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkUpdateOptions options, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>, System.Collections.IEnumerable
    {
        protected VirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkLinkCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.VirtualNetworkLinkData parameters, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualNetworkLinkData : Azure.ResourceManager.Models.Resource
    {
        public VirtualNetworkLinkData() { }
        public string Etag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualNetwork { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.DnsResolver.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.CreatedByType left, Azure.ResourceManager.DnsResolver.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.CreatedByType left, Azure.ResourceManager.DnsResolver.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsForwardingRulesetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>
    {
        protected DnsForwardingRulesetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.DnsForwardingRuleset Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetDeleteOperation : Azure.Operation
    {
        protected DnsForwardingRulesetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>
    {
        protected DnsForwardingRulesetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.DnsForwardingRuleset Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleset>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetUpdateOptions
    {
        public DnsForwardingRulesetUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DnsResolverCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.DnsResolver>
    {
        protected DnsResolverCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.DnsResolver Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverDeleteOperation : Azure.Operation
    {
        protected DnsResolverDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DnsResolverUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.DnsResolver>
    {
        protected DnsResolverUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.DnsResolver Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolver>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverUpdateOptions
    {
        public DnsResolverUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ForwardingRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.ForwardingRule>
    {
        protected ForwardingRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.ForwardingRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.ForwardingRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ForwardingRuleDeleteOperation : Azure.Operation
    {
        protected ForwardingRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ForwardingRuleUpdateOptions
    {
        public ForwardingRuleUpdateOptions() { }
        public Azure.ResourceManager.DnsResolver.Models.ForwardingRuleState? ForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
    }
    public partial class InboundEndpointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.InboundEndpoint>
    {
        protected InboundEndpointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.InboundEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointDeleteOperation : Azure.Operation
    {
        protected InboundEndpointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.InboundEndpoint>
    {
        protected InboundEndpointUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.InboundEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.InboundEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InboundEndpointUpdateOptions
    {
        public InboundEndpointUpdateOptions() { }
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
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class OutboundEndpointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.OutboundEndpoint>
    {
        protected OutboundEndpointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.OutboundEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointDeleteOperation : Azure.Operation
    {
        protected OutboundEndpointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.OutboundEndpoint>
    {
        protected OutboundEndpointUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.OutboundEndpoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.OutboundEndpoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OutboundEndpointUpdateOptions
    {
        public OutboundEndpointUpdateOptions() { }
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
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
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
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualNetworkLink { get { throw null; } }
    }
    public partial class VirtualNetworkLinkCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>
    {
        protected VirtualNetworkLinkCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.VirtualNetworkLink Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkDeleteOperation : Azure.Operation
    {
        protected VirtualNetworkLinkDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkUpdateOperation : Azure.Operation<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>
    {
        protected VirtualNetworkLinkUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DnsResolver.VirtualNetworkLink Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DnsResolver.VirtualNetworkLink>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkLinkUpdateOptions
    {
        public VirtualNetworkLinkUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
}
