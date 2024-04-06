namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsForwardingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>, System.Collections.IEnumerable
    {
        protected DnsForwardingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.DnsForwardingRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string forwardingRuleName, Azure.ResourceManager.DnsResolver.DnsForwardingRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> Get(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> GetAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> GetIfExists(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> GetIfExistsAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsForwardingRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>
    {
        public DnsForwardingRuleData(string domainName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> targetDnsServers) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState? DnsForwardingRuleState { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsForwardingRuleResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName, string forwardingRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> Update(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> UpdateAsync(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>, System.Collections.IEnumerable
    {
        protected DnsForwardingRulesetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rulesetName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Get(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetAsync(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetIfExists(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetIfExistsAsync(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsForwardingRulesetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>
    {
        public DnsForwardingRulesetData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> dnsResolverOutboundEndpoints) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResolverOutboundEndpoints { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsForwardingRulesetResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource> GetDnsForwardingRule(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource>> GetDnsForwardingRuleAsync(string forwardingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRuleCollection GetDnsForwardingRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> GetDnsForwardingRulesetVirtualNetworkLink(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> GetDnsForwardingRulesetVirtualNetworkLinkAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkCollection GetDnsForwardingRulesetVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsForwardingRulesetVirtualNetworkLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>, System.Collections.IEnumerable
    {
        protected DnsForwardingRulesetVirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkLinkName, Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> Get(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> GetAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> GetIfExists(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> GetIfExistsAsync(string virtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsForwardingRulesetVirtualNetworkLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>
    {
        public DnsForwardingRulesetVirtualNetworkLinkData(Azure.ResourceManager.Resources.Models.WritableSubResource virtualNetwork) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetVirtualNetworkLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsForwardingRulesetVirtualNetworkLinkResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName, string virtualNetworkLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetIfExists(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetIfExistsAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>
    {
        public DnsResolverData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource virtualNetwork) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverState? DnsResolverState { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DnsResolverExtensions
    {
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource GetDnsForwardingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRuleset(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetDnsForwardingRulesetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource GetDnsForwardingRulesetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetCollection GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource GetDnsForwardingRulesetVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolver(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetDnsResolverAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource GetDnsResolverInboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource GetDnsResolverOutboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverResource GetDnsResolverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolvers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DnsResolverInboundEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>, System.Collections.IEnumerable
    {
        protected DnsResolverInboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inboundEndpointName, Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> Get(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> GetAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> GetIfExists(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> GetIfExistsAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverInboundEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>
    {
        public DnsResolverInboundEndpointData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration> ipConfigurations) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverInboundEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverInboundEndpointResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string inboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverOutboundEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>, System.Collections.IEnumerable
    {
        protected DnsResolverOutboundEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string outboundEndpointName, Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> Get(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> GetAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> GetIfExists(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> GetIfExistsAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverOutboundEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>
    {
        public DnsResolverOutboundEndpointData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource subnet) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverOutboundEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverOutboundEndpointResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverName, string outboundEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource> GetDnsResolverInboundEndpoint(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource>> GetDnsResolverInboundEndpointAsync(string inboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointCollection GetDnsResolverInboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> GetDnsResolverOutboundEndpoint(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> GetDnsResolverOutboundEndpointAsync(string outboundEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointCollection GetDnsResolverOutboundEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkDnsResolverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkDnsResolverResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesets(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolvers(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolversAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DnsResolver.Mocking
{
    public partial class MockableDnsResolverArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDnsResolverArmClient() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRuleResource GetDnsForwardingRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource GetDnsForwardingRulesetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkResource GetDnsForwardingRulesetVirtualNetworkLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource GetDnsResolverInboundEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource GetDnsResolverOutboundEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverResource GetDnsResolverResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.VirtualNetworkDnsResolverResource GetVirtualNetworkDnsResolverResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDnsResolverResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDnsResolverResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRuleset(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource>> GetDnsForwardingRulesetAsync(string rulesetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsForwardingRulesetCollection GetDnsForwardingRulesets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolver(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverResource>> GetDnsResolverAsync(string dnsResolverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers() { throw null; }
    }
    public partial class MockableDnsResolverSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDnsResolverSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesets(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesetsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolvers(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolversAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DnsResolver.Models
{
    public static partial class ArmDnsResolverModelFactory
    {
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRuleData DnsForwardingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> targetDnsServers = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState? dnsForwardingRuleState = default(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState?), Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData DnsForwardingRulesetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> dnsResolverOutboundEndpoints = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData DnsForwardingRulesetVirtualNetworkLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier virtualNetworkId = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverData DnsResolverData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier virtualNetworkId = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverState? dnsResolverState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverState?), Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData DnsResolverInboundEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration> ipConfigurations = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData DnsResolverOutboundEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset VirtualNetworkDnsForwardingRuleset(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier virtualNetworkLinkId = null) { throw null; }
    }
    public partial class DnsForwardingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>
    {
        public DnsForwardingRulePatch() { }
        public Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState? DnsForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>
    {
        public DnsForwardingRulesetPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResolverOutboundEndpoints { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetVirtualNetworkLinkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>
    {
        public DnsForwardingRulesetVirtualNetworkLinkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulesetVirtualNetworkLinkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsForwardingRuleState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsForwardingRuleState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState left, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState left, Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsResolverInboundEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>
    {
        public DnsResolverInboundEndpointPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverOutboundEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>
    {
        public DnsResolverOutboundEndpointPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>
    {
        public DnsResolverPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsResolverProvisioningState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsResolverProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState left, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState left, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InboundEndpointIPAllocationMethod : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InboundEndpointIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod left, Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod left, Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InboundEndpointIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>
    {
        public InboundEndpointIPConfiguration(Azure.ResourceManager.Resources.Models.WritableSubResource subnet) { }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetDnsServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>
    {
        public TargetDnsServer(System.Net.IPAddress ipAddress) { }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        Azure.ResourceManager.DnsResolver.Models.TargetDnsServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.TargetDnsServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkDnsForwardingRuleset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>
    {
        internal VirtualNetworkDnsForwardingRuleset() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkLinkId { get { throw null; } }
        Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
