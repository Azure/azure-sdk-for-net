namespace Azure.ResourceManager.DnsResolver
{
    public partial class AzureResourceManagerDnsResolverContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDnsResolverContext() { }
        public static Azure.ResourceManager.DnsResolver.AzureResourceManagerDnsResolverContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>
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
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>
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
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsForwardingRulesetVirtualNetworkLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>
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
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetVirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverDomainListCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>, System.Collections.IEnumerable
    {
        protected DnsResolverDomainListCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsResolverDomainListName, Azure.ResourceManager.DnsResolver.DnsResolverDomainListData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsResolverDomainListName, Azure.ResourceManager.DnsResolver.DnsResolverDomainListData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> Get(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> GetAsync(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetIfExists(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> GetIfExistsAsync(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverDomainListData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>
    {
        public DnsResolverDomainListData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> Domains { get { throw null; } }
        public System.Uri DomainsUri { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverDomainListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverDomainListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverDomainListResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverDomainListResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverDomainListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> Bulk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk dnsResolverDomainListBulk, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> BulkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk dnsResolverDomainListBulk, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverDomainListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DnsResolver.DnsResolverDomainListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverDomainListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverDomainListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainList(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> GetDnsResolverDomainListAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource GetDnsResolverDomainListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverDomainListCollection GetDnsResolverDomainLists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainLists(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainListsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource GetDnsResolverInboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource GetDnsResolverOutboundEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverPolicyCollection GetDnsResolverPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> GetDnsResolverPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource GetDnsResolverPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource GetDnsResolverPolicyVirtualNetworkLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverResource GetDnsResolverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolvers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverResource> GetDnsResolversAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource GetDnsSecurityRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverInboundEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>
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
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverOutboundEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>
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
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverOutboundEndpointPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>, System.Collections.IEnumerable
    {
        protected DnsResolverPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsResolverPolicyName, Azure.ResourceManager.DnsResolver.DnsResolverPolicyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsResolverPolicyName, Azure.ResourceManager.DnsResolver.DnsResolverPolicyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> Get(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> GetAsync(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetIfExists(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> GetIfExistsAsync(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>
    {
        public DnsResolverPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverPolicyResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> GetDnsResolverPolicyVirtualNetworkLink(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> GetDnsResolverPolicyVirtualNetworkLinkAsync(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkCollection GetDnsResolverPolicyVirtualNetworkLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> GetDnsSecurityRule(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> GetDnsSecurityRuleAsync(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsSecurityRuleCollection GetDnsSecurityRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverPolicyVirtualNetworkLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>, System.Collections.IEnumerable
    {
        protected DnsResolverPolicyVirtualNetworkLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsResolverPolicyVirtualNetworkLinkName, Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsResolverPolicyVirtualNetworkLinkName, Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> Get(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> GetAsync(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> GetIfExists(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> GetIfExistsAsync(string dnsResolverPolicyVirtualNetworkLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsResolverPolicyVirtualNetworkLinkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>
    {
        public DnsResolverPolicyVirtualNetworkLinkData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.WritableSubResource virtualNetwork) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverPolicyVirtualNetworkLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsResolverPolicyVirtualNetworkLinkResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverPolicyName, string dnsResolverPolicyVirtualNetworkLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsResolverResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>
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
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsResolverData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsResolverData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsResolverResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsSecurityRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>, System.Collections.IEnumerable
    {
        protected DnsSecurityRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsSecurityRuleName, Azure.ResourceManager.DnsResolver.DnsSecurityRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsSecurityRuleName, Azure.ResourceManager.DnsResolver.DnsSecurityRuleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> Get(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> GetAsync(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> GetIfExists(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> GetIfExistsAsync(string dnsSecurityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsSecurityRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>
    {
        public DnsSecurityRuleData(Azure.Core.AzureLocation location, int priority, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction action) { }
        public DnsSecurityRuleData(Azure.Core.AzureLocation location, int priority, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction action, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> dnsResolverDomainLists) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResolverDomainLists { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState? DnsSecurityRuleState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.ManagedDomainList> ManagedDomainLists { get { throw null; } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsSecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsSecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsSecurityRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsSecurityRuleResource() { }
        public virtual Azure.ResourceManager.DnsResolver.DnsSecurityRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dnsResolverPolicyName, string dnsSecurityRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DnsResolver.DnsSecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.DnsSecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.DnsSecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkDnsResolverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkDnsResolverResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesets(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset> GetDnsForwardingRulesetsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolverPoliciesByVirtualNetwork(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.WritableSubResource> GetDnsResolverPoliciesByVirtualNetworkAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource GetDnsResolverDomainListResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointResource GetDnsResolverInboundEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointResource GetDnsResolverOutboundEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource GetDnsResolverPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkResource GetDnsResolverPolicyVirtualNetworkLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverResource GetDnsResolverResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsSecurityRuleResource GetDnsSecurityRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainList(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource>> GetDnsResolverDomainListAsync(string dnsResolverDomainListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverDomainListCollection GetDnsResolverDomainLists() { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverPolicyCollection GetDnsResolverPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPolicy(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource>> GetDnsResolverPolicyAsync(string dnsResolverPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DnsResolver.DnsResolverCollection GetDnsResolvers() { throw null; }
    }
    public partial class MockableDnsResolverSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDnsResolverSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesets(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsForwardingRulesetResource> GetDnsForwardingRulesetsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainLists(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverDomainListResource> GetDnsResolverDomainListsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPolicies(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DnsResolver.DnsResolverPolicyResource> GetDnsResolverPoliciesAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.DnsResolver.DnsResolverDomainListData DnsResolverDomainListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> domains = null, System.Uri domainsUri = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverInboundEndpointData DnsResolverInboundEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration> ipConfigurations = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverOutboundEndpointData DnsResolverOutboundEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverPolicyData DnsResolverPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?), System.Guid? resourceGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsResolverPolicyVirtualNetworkLinkData DnsResolverPolicyVirtualNetworkLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier virtualNetworkId = null, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DnsResolver.DnsSecurityRuleData DnsSecurityRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), int priority = 0, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType? actionType = default(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> dnsResolverDomainLists = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DnsResolver.Models.ManagedDomainList> managedDomainLists = null, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState? dnsSecurityRuleState = default(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState?), Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState = default(Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DnsResolver.DnsSecurityRuleData DnsSecurityRuleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, int priority, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType? actionType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> dnsResolverDomainLists, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState? dnsSecurityRuleState, Azure.ResourceManager.DnsResolver.Models.DnsResolverProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset VirtualNetworkDnsForwardingRuleset(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier virtualNetworkLinkId = null) { throw null; }
    }
    public partial class DnsForwardingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsForwardingRulePatch>
    {
        public DnsForwardingRulePatch() { }
        public Azure.ResourceManager.DnsResolver.Models.DnsForwardingRuleState? DnsForwardingRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer> TargetDnsServers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class DnsResolverDomainListBulk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>
    {
        public DnsResolverDomainListBulk(System.Uri storageUri, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction action) { }
        public Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction Action { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsResolverDomainListBulkAction : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsResolverDomainListBulkAction(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction Download { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction left, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction left, Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListBulkAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsResolverDomainListPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>
    {
        public DnsResolverDomainListPatch() { }
        public System.Collections.Generic.IList<string> Domains { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverDomainListPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverInboundEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverInboundEndpointPatch>
    {
        public DnsResolverInboundEndpointPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>
    {
        public DnsResolverPolicyPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsResolverPolicyVirtualNetworkLinkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>
    {
        public DnsResolverPolicyVirtualNetworkLinkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsResolverPolicyVirtualNetworkLinkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DnsSecurityRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>
    {
        public DnsSecurityRuleAction() { }
        public Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType? ActionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsSecurityRuleActionType : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsSecurityRuleActionType(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType Alert { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType Block { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType left, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType left, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsSecurityRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>
    {
        public DnsSecurityRulePatch() { }
        public Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleActionType? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DnsResolverDomainLists { get { throw null; } }
        public Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState? DnsSecurityRuleState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DnsResolver.Models.ManagedDomainList> ManagedDomainLists { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsSecurityRuleState : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsSecurityRuleState(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState left, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState left, Azure.ResourceManager.DnsResolver.Models.DnsSecurityRuleState right) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.InboundEndpointIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedDomainList : System.IEquatable<Azure.ResourceManager.DnsResolver.Models.ManagedDomainList>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedDomainList(string value) { throw null; }
        public static Azure.ResourceManager.DnsResolver.Models.ManagedDomainList AzureDnsThreatIntel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DnsResolver.Models.ManagedDomainList other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DnsResolver.Models.ManagedDomainList left, Azure.ResourceManager.DnsResolver.Models.ManagedDomainList right) { throw null; }
        public static implicit operator Azure.ResourceManager.DnsResolver.Models.ManagedDomainList (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DnsResolver.Models.ManagedDomainList left, Azure.ResourceManager.DnsResolver.Models.ManagedDomainList right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetDnsServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.TargetDnsServer>
    {
        public TargetDnsServer(System.Net.IPAddress ipAddress) { }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DnsResolver.Models.VirtualNetworkDnsForwardingRuleset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
