namespace Azure.ResourceManager.Cdn
{
    public partial class AzureResourceManagerCdnContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCdnContext() { }
        public static Azure.ResourceManager.Cdn.AzureResourceManagerCdnContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CdnCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>, System.Collections.IEnumerable
    {
        protected CdnCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Get(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetIfExists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetIfExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnCustomDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>
    {
        public CdnCustomDomainData() { }
        public Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent CustomDomainHttpsContent { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState? CustomHttpsAvailabilityState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? CustomHttpsProvisioningState { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CustomDomainResourceState? ResourceState { get { throw null; } }
        public string ValidationData { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnCustomDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnCustomDomainResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string customDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> DisableCustomHttps(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> DisableCustomHttpsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> EnableCustomHttps(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> EnableCustomHttpsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.CdnCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>, System.Collections.IEnumerable
    {
        protected CdnEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.CdnEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.CdnEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>
    {
        public CdnEndpointData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.CdnCustomDomainData> CustomDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain> DeepCreatedCustomDomains { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultOriginGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy DeliveryPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.GeoFilter> GeoFilters { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
        public bool? IsHttpAllowed { get { throw null; } set { } }
        public bool? IsHttpsAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OptimizationType? OptimizationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup> OriginGroups { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin> Origins { get { throw null; } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningKey> UriSigningKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnEndpointResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource> GetCdnCustomDomain(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnCustomDomainResource>> GetCdnCustomDomainAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnCustomDomainCollection GetCdnCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> GetCdnOrigin(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetCdnOriginAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetCdnOriginGroup(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetCdnOriginGroupAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginGroupCollection GetCdnOriginGroups() { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginCollection GetCdnOrigins() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation LoadContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.LoadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> LoadContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.LoadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.CdnEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult> ValidateCustomDomain(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>> ValidateCustomDomainAsync(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CdnExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult> CanMigrateProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CanMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult>> CanMigrateProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CanMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailabilityWithSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityWithSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult> CheckEndpointNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>> CheckEndpointNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnCustomDomainResource GetCdnCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnEndpointResource GetCdnEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginGroupResource GetCdnOriginGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginResource GetCdnOriginResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyCollection GetCdnWebApplicationFirewallPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetCdnWebApplicationFirewallPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetCdnWebApplicationFirewallPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource GetCdnWebApplicationFirewallPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodes(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource GetFrontDoorCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorEndpointResource GetFrontDoorEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource GetFrontDoorOriginGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorOriginResource GetFrontDoorOriginResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRouteResource GetFrontDoorRouteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRuleResource GetFrontDoorRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRuleSetResource GetFrontDoorRuleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorSecretResource GetFrontDoorSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource GetFrontDoorSecurityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> GetProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Cdn.ProfileResource GetProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Cdn.ProfileCollection GetProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult> MigrateProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.MigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult>> MigrateProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.MigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult> ValidateProbe(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>> ValidateProbeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnOriginCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>, System.Collections.IEnumerable
    {
        protected CdnOriginCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.CdnOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.CdnOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> Get(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnOriginResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnOriginResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnOriginResource> GetIfExists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnOriginResource>> GetIfExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnOriginResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnOriginResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnOriginData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>
    {
        public CdnOriginData() { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OriginProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginResourceState? ResourceState { get { throw null; } }
        public int? Weight { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnOriginGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>, System.Collections.IEnumerable
    {
        protected CdnOriginGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.CdnOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.CdnOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Get(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnOriginGroupResource> GetIfExists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetIfExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnOriginGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnOriginGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnOriginGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnOriginGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>
    {
        public CdnOriginGroupData() { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnOriginGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnOriginGroupResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnOriginGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string originGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.CdnOriginGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnOriginResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnOriginResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnOriginData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string originName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnOriginResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.CdnOriginData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnOriginData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnOriginData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnOriginData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnOriginResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>, System.Collections.IEnumerable
    {
        protected CdnWebApplicationFirewallPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>
    {
        public CdnWebApplicationFirewallPolicyData(Azure.Core.AzureLocation location, Azure.ResourceManager.Cdn.Models.CdnSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CustomRule> CustomRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> EndpointLinks { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet> ManagedRuleSets { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafPolicySettings PolicySettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RateLimitRule> RateLimitRules { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.PolicyResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CdnWebApplicationFirewallPolicyResource() { }
        public virtual Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorCustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>, System.Collections.IEnumerable
    {
        protected FrontDoorCustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.FrontDoorCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customDomainName, Azure.ResourceManager.Cdn.FrontDoorCustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> Get(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> GetAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> GetIfExists(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> GetIfExistsAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorCustomDomainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>
    {
        public FrontDoorCustomDomainData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier DnsZoneId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DomainValidationState? DomainValidationState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PreValidatedCustomDomainResourceId { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent TlsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DomainValidationProperties ValidationProperties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorCustomDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorCustomDomainResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorCustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string customDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshValidationToken(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshValidationTokenAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorCustomDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorCustomDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorCustomDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>, System.Collections.IEnumerable
    {
        protected FrontDoorEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.FrontDoorEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.Cdn.FrontDoorEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorEndpointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>
    {
        public FrontDoorEndpointData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorEndpointResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource> GetFrontDoorRoute(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> GetFrontDoorRouteAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRouteCollection GetFrontDoorRoutes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult> ValidateCustomDomain(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>> ValidateCustomDomainAsync(Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorOriginCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginResource>, System.Collections.IEnumerable
    {
        protected FrontDoorOriginCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.FrontDoorOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originName, Azure.ResourceManager.Cdn.FrontDoorOriginData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource> Get(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorOriginResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorOriginResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> GetAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorOriginResource> GetIfExists(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> GetIfExistsAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorOriginResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorOriginResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorOriginData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>
    {
        public FrontDoorOriginData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public bool? EnforceCertificateNameCheck { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginGroupName { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginId { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties SharedPrivateLinkResource { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorOriginGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>, System.Collections.IEnumerable
    {
        protected FrontDoorOriginGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.FrontDoorOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string originGroupName, Azure.ResourceManager.Cdn.FrontDoorOriginGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> Get(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> GetAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> GetIfExists(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> GetIfExistsAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorOriginGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>
    {
        public FrontDoorOriginGroupData() { }
        public Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LoadBalancingSettings LoadBalancingSettings { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? SessionAffinityState { get { throw null; } set { } }
        public int? TrafficRestorationTimeInMinutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorOriginGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorOriginGroupResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string originGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource> GetFrontDoorOrigin(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> GetFrontDoorOriginAsync(string originName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginCollection GetFrontDoorOrigins() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorOriginGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorOriginResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorOriginResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string originGroupName, string originName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorOriginData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorOriginData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorOriginData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorOriginResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorRouteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRouteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRouteResource>, System.Collections.IEnumerable
    {
        protected FrontDoorRouteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRouteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string routeName, Azure.ResourceManager.Cdn.FrontDoorRouteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string routeName, Azure.ResourceManager.Cdn.FrontDoorRouteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource> Get(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorRouteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorRouteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> GetAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRouteResource> GetIfExists(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> GetIfExistsAsync(string routeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorRouteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRouteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorRouteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRouteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorRouteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>
    {
        public FrontDoorRouteData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo> CustomDomains { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string EndpointName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpsRedirect? HttpsRedirect { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? LinkToDefaultDomain { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RuleSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol> SupportedProtocols { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRouteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRouteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRouteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorRouteResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRouteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string endpointName, string routeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorRouteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRouteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRouteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRouteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRouteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleResource>, System.Collections.IEnumerable
    {
        protected FrontDoorRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Cdn.FrontDoorRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Cdn.FrontDoorRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>
    {
        public FrontDoorRuleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleSetName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorRuleResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string ruleSetName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorRuleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>, System.Collections.IEnumerable
    {
        protected FrontDoorRuleSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorRuleSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>
    {
        public FrontDoorRuleSetData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRuleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorRuleSetResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource> GetFrontDoorRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleResource>> GetFrontDoorRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleCollection GetFrontDoorRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorRuleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorRuleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorRuleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorSecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecretResource>, System.Collections.IEnumerable
    {
        protected FrontDoorSecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.Cdn.FrontDoorSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string secretName, Azure.ResourceManager.Cdn.FrontDoorSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource> Get(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorSecretResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorSecretResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> GetAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorSecretResource> GetIfExists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> GetIfExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorSecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorSecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorSecretData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>
    {
        public FrontDoorSecretData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorSecretResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorSecretResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string secretName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecretResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.FrontDoorSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.FrontDoorSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorSecurityPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>, System.Collections.IEnumerable
    {
        protected FrontDoorSecurityPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> Get(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> GetAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> GetIfExists(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> GetIfExistsAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorSecurityPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>
    {
        public FrontDoorSecurityPolicyData() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? DeploymentStatus { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorSecurityPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorSecurityPolicyResource() { }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string securityPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.ProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.ProfileResource>, System.Collections.IEnumerable
    {
        protected ProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.Cdn.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.Cdn.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.ProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.ProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Cdn.ProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Cdn.ProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Cdn.ProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Cdn.ProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Cdn.ProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.ProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>
    {
        public ProfileData(Azure.Core.AzureLocation location, Azure.ResourceManager.Cdn.Models.CdnSku sku) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ExtendedProperties { get { throw null; } }
        public System.Guid? FrontDoorId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing LogScrubbing { get { throw null; } set { } }
        public int? OriginResponseTimeoutSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProfileProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ProfileResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.ProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.ProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileResource() { }
        public virtual Azure.ResourceManager.Cdn.ProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AbortMigration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AbortMigrationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult> CheckCdnMigrationCompatibility(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult>> CheckCdnMigrationCompatibilityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult> CheckEndpointNameAvailabilityFrontDoorProfile(Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>> CheckEndpointNameAvailabilityFrontDoorProfileAsync(Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckFrontDoorProfileHostNameAvailability(Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckFrontDoorProfileHostNameAvailabilityAsync(Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.SsoUri> GenerateSsoUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.SsoUri>> GenerateSsoUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource> GetCdnEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnEndpointResource>> GetCdnEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnEndpointCollection GetCdnEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource> GetFrontDoorCustomDomain(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource>> GetFrontDoorCustomDomainAsync(string customDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorCustomDomainCollection GetFrontDoorCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource> GetFrontDoorEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorEndpointResource>> GetFrontDoorEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorEndpointCollection GetFrontDoorEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource> GetFrontDoorOriginGroup(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource>> GetFrontDoorOriginGroupAsync(string originGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginGroupCollection GetFrontDoorOriginGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetFrontDoorProfileResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.FrontDoorUsage> GetFrontDoorProfileResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource> GetFrontDoorRuleSet(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorRuleSetResource>> GetFrontDoorRuleSetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleSetCollection GetFrontDoorRuleSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource> GetFrontDoorSecret(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecretResource>> GetFrontDoorSecretAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecretCollection GetFrontDoorSecrets() { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyCollection GetFrontDoorSecurityPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource> GetFrontDoorSecurityPolicy(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource>> GetFrontDoorSecurityPolicyAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ContinentsResponse> GetLogAnalyticsLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ContinentsResponse>> GetLogAnalyticsLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse> GetLogAnalyticsMetrics(Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse> GetLogAnalyticsMetrics(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity granularity, System.Collections.Generic.IEnumerable<string> customDomains, System.Collections.Generic.IEnumerable<string> protocols, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<string> continents = null, System.Collections.Generic.IEnumerable<string> countryOrRegions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse>> GetLogAnalyticsMetricsAsync(Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.MetricsResponse>> GetLogAnalyticsMetricsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity granularity, System.Collections.Generic.IEnumerable<string> customDomains, System.Collections.Generic.IEnumerable<string> protocols, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<string> continents = null, System.Collections.Generic.IEnumerable<string> countryOrRegions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse> GetLogAnalyticsRankings(Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsRankingsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse> GetLogAnalyticsRankings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRanking> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRankingMetric> metrics, int maxRanking, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, System.Collections.Generic.IEnumerable<string> customDomains = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse>> GetLogAnalyticsRankingsAsync(Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsRankingsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.RankingsResponse>> GetLogAnalyticsRankingsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRanking> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRankingMetric> metrics, int maxRanking, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, System.Collections.Generic.IEnumerable<string> customDomains = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ResourcesResponse> GetLogAnalyticsResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ResourcesResponse>> GetLogAnalyticsResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult> GetSupportedOptimizationTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>> GetSupportedOptimizationTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse> GetWafLogAnalyticsMetrics(Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse> GetWafLogAnalyticsMetrics(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.WafGranularity granularity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>> GetWafLogAnalyticsMetricsAsync(Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsMetricsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>> GetWafLogAnalyticsMetricsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.WafGranularity granularity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse> GetWafLogAnalyticsRankings(Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsRankingsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse> GetWafLogAnalyticsRankings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, int maxRanking, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingType> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>> GetWafLogAnalyticsRankingsAsync(Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsRankingsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>> GetWafLogAnalyticsRankingsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, int maxRanking, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingType> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafAction> actions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRuleType> ruleTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult> MigrateCdnToAfd(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult>> MigrateCdnToAfdAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MigrationCommit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrationCommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Cdn.ProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.ProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.ProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.ProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource> UpgradeFrontDoorProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.ProfileResource>> UpgradeFrontDoorProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateSecretResult> ValidateSecretFrontDoorProfile(Azure.ResourceManager.Cdn.Models.ValidateSecretContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>> ValidateSecretFrontDoorProfileAsync(Azure.ResourceManager.Cdn.Models.ValidateSecretContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Cdn.Mocking
{
    public partial class MockableCdnArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCdnArmClient() { }
        public virtual Azure.ResourceManager.Cdn.CdnCustomDomainResource GetCdnCustomDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnEndpointResource GetCdnEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginGroupResource GetCdnOriginGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnOriginResource GetCdnOriginResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource GetCdnWebApplicationFirewallPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorCustomDomainResource GetFrontDoorCustomDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorEndpointResource GetFrontDoorEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginGroupResource GetFrontDoorOriginGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorOriginResource GetFrontDoorOriginResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRouteResource GetFrontDoorRouteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleResource GetFrontDoorRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorRuleSetResource GetFrontDoorRuleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecretResource GetFrontDoorSecretResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyResource GetFrontDoorSecurityPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Cdn.ProfileResource GetProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCdnResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCdnResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult> CanMigrateProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CanMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.CanMigrateResult>> CanMigrateProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.CanMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult> CheckEndpointNameAvailability(Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>> CheckEndpointNameAvailabilityAsync(Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyCollection GetCdnWebApplicationFirewallPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource> GetCdnWebApplicationFirewallPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyResource>> GetCdnWebApplicationFirewallPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.ProfileResource> GetProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.ProfileResource>> GetProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Cdn.ProfileCollection GetProfiles() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult> MigrateProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.MigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Cdn.Models.MigrateResult>> MigrateProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Cdn.Models.MigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCdnSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCdnSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailabilityWithSubscription(Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityWithSubscriptionAsync(Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.ProfileResource> GetProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.CdnUsage> GetResourceUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult> ValidateProbe(Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>> ValidateProbeAsync(Azure.ResourceManager.Cdn.Models.ValidateProbeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCdnTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCdnTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult> CheckCdnNameAvailability(Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>> CheckCdnNameAvailabilityAsync(Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Cdn.Models.EdgeNode> GetEdgeNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Cdn.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdCipherSuiteSetType : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdCipherSuiteSetType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType Customized { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType Tls1_0_2019 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType Tls1_2_2022 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType Tls1_2_2023 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType left, Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType left, Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdCustomizedCipherSuiteForTls12 : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdCustomizedCipherSuiteForTls12(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes128_Gcm_Sha256 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes256_Gcm_Sha384 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Gcm_Sha256 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Sha256 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Gcm_Sha384 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Sha384 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 left, Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 left, Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AfdCustomizedCipherSuiteForTls13 : System.IEquatable<Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AfdCustomizedCipherSuiteForTls13(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 Tls_Aes_128_Gcm_Sha256 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 Tls_Aes_256_Gcm_Sha384 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 left, Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 left, Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13 right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmCdnModelFactory
    {
        public static Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties AzureFirstPartyManagedCertificateProperties(Azure.Core.ResourceIdentifier secretSourceId = null, string subject = null, string expirationDate = null, string certificateAuthority = null, System.Collections.Generic.IEnumerable<string> subjectAlternativeNames = null, string thumbprint = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CanMigrateResult CanMigrateResult(Azure.Core.ResourceIdentifier resourceId = null, string canMigrateResultType = null, bool? canMigrate = default(bool?), Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku? defaultSku = default(Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MigrationErrorType> errors = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.Models.CanMigrateResult CanMigrateResult(string Id = null, string canMigrateResultType = null, bool? canMigrate = default(bool?), Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku? defaultSku = default(Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MigrationErrorType> errors = null) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnCustomDomainData CdnCustomDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string hostName = null, Azure.ResourceManager.Cdn.Models.CustomDomainResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState?), Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? customHttpsProvisioningState = default(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState?), Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState? customHttpsAvailabilityState = default(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState?), Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent customDomainHttpsContent = null, string validationData = null, Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.CdnEndpointData CdnEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string originPath = null, System.Collections.Generic.IEnumerable<string> contentTypesToCompress = null, string originHostHeader = null, bool? isCompressionEnabled = default(bool?), bool? isHttpAllowed = default(bool?), bool? isHttpsAllowed = default(bool?), Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? queryStringCachingBehavior = default(Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior?), Azure.ResourceManager.Cdn.Models.OptimizationType? optimizationType = default(Azure.ResourceManager.Cdn.Models.OptimizationType?), string probePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.GeoFilter> geoFilters = null, Azure.Core.ResourceIdentifier defaultOriginGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.UriSigningKey> uriSigningKeys = null, Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy deliveryPolicy = null, Azure.Core.ResourceIdentifier webApplicationFirewallPolicyLinkId = null, string hostName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin> origins = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup> originGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.CdnCustomDomainData> customDomains = null, Azure.ResourceManager.Cdn.Models.EndpointResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.EndpointResourceState?), Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnEndpointData CdnEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string originPath = null, System.Collections.Generic.IEnumerable<string> contentTypesToCompress = null, string originHostHeader = null, bool? isCompressionEnabled = default(bool?), bool? isHttpAllowed = default(bool?), bool? isHttpsAllowed = default(bool?), Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? queryStringCachingBehavior = default(Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior?), Azure.ResourceManager.Cdn.Models.OptimizationType? optimizationType = default(Azure.ResourceManager.Cdn.Models.OptimizationType?), string probePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.GeoFilter> geoFilters = null, Azure.Core.ResourceIdentifier defaultOriginGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.UriSigningKey> uriSigningKeys = null, Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy deliveryPolicy = null, Azure.Core.ResourceIdentifier webApplicationFirewallPolicyLinkId = null, string hostName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin> origins = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup> originGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain> deepCreatedCustomDomains = null, Azure.ResourceManager.Cdn.Models.EndpointResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.EndpointResourceState?), Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent CdnMigrationToAfdContent(Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName = default(Azure.ResourceManager.Cdn.Models.CdnSkuName?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping> migrationEndpointMappings = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult CdnNameAvailabilityResult(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginData CdnOriginData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string hostName = null, int? httpPort = default(int?), int? httpsPort = default(int?), string originHostHeader = null, int? priority = default(int?), int? weight = default(int?), bool? enabled = default(bool?), string privateLinkAlias = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, string privateLinkLocation = null, string privateLinkApprovalMessage = null, Azure.ResourceManager.Cdn.Models.OriginResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.OriginResourceState?), Azure.ResourceManager.Cdn.Models.OriginProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.OriginProvisioningState?), Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? privateEndpointStatus = default(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus?)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnOriginGroupData CdnOriginGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Cdn.Models.HealthProbeSettings healthProbeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> origins = null, int? trafficRestorationTimeToHealedOrNewEndpointsInMinutes = default(int?), Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings responseBasedOriginErrorDetectionSettings = null, Azure.ResourceManager.Cdn.Models.OriginGroupResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState?), Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnUsage CdnUsage(string resourceType = null, Azure.ResourceManager.Cdn.Models.CdnUsageUnit? unit = default(Azure.ResourceManager.Cdn.Models.CdnUsageUnit?), int? currentValue = default(int?), int? limit = default(int?)) { throw null; }
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData CdnWebApplicationFirewallPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName = default(Azure.ResourceManager.Cdn.Models.CdnSkuName?), Azure.ResourceManager.Cdn.Models.WafPolicySettings policySettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.RateLimitRule> rateLimitRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.CustomRule> customRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet> managedRuleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> endpointLinks = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState?), Azure.ResourceManager.Cdn.Models.PolicyResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.PolicyResourceState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.CdnWebApplicationFirewallPolicyData CdnWebApplicationFirewallPolicyData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName, Azure.ResourceManager.Cdn.Models.WafPolicySettings policySettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.RateLimitRule> rateLimitRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.CustomRule> customRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet> managedRuleSets, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> endpointLinks, Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState? provisioningState, Azure.ResourceManager.Cdn.Models.PolicyResourceState? resourceState) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems(System.DateTimeOffset? dateOn = default(System.DateTimeOffset?), float? value = default(float?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems(System.DateTimeOffset? dateOn = default(System.DateTimeOffset?), float? value = default(float?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems(string metric = null, long? value = default(long?), double? percentage = default(double?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ContinentsResponse ContinentsResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem> continents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem> countryOrRegions = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem ContinentsResponseContinentsItem(string id = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem ContinentsResponseCountryOrRegionsItem(string id = null, string continentId = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties CustomerCertificateProperties(Azure.Core.ResourceIdentifier secretSourceId = null, string secretVersion = null, bool? useLatestVersion = default(bool?), string subject = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), string certificateAuthority = null, System.Collections.Generic.IEnumerable<string> subjectAlternativeNames = null, string thumbprint = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain DeepCreatedCustomDomain(string name = null, string hostName = null, string validationData = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin DeepCreatedOrigin(string name = null, string hostName = null, int? httpPort = default(int?), int? httpsPort = default(int?), string originHostHeader = null, int? priority = default(int?), int? weight = default(int?), bool? enabled = default(bool?), string privateLinkAlias = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, string privateLinkLocation = null, string privateLinkApprovalMessage = null, Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? privateEndpointStatus = default(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationProperties DomainValidationProperties(string validationToken = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EdgeNode EdgeNode(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.IPAddressGroup> ipAddressGroups = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent EndpointNameAvailabilityContent(string name = null, Azure.ResourceManager.Cdn.Models.CdnResourceType resourceType = default(Azure.ResourceManager.Cdn.Models.CdnResourceType), Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult EndpointNameAvailabilityResult(bool? nameAvailable = default(bool?), string availableHostname = null, string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo FrontDoorActivatedResourceInfo(Azure.Core.ResourceIdentifier id = null, bool? isActive = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.FrontDoorCustomDomainData FrontDoorCustomDomainData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string profileName, Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent tlsSettings, Azure.Core.ResourceIdentifier dnsZoneId, Azure.Core.ResourceIdentifier preValidatedCustomDomainResourceId, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState, Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus, Azure.ResourceManager.Cdn.Models.DomainValidationState? domainValidationState, string hostName, Azure.ResourceManager.Cdn.Models.DomainValidationProperties validationProperties) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorCustomDomainData FrontDoorCustomDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string profileName = null, Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent tlsSettings = null, Azure.Core.ResourceIdentifier dnsZoneId = null, Azure.Core.ResourceIdentifier preValidatedCustomDomainResourceId = null, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?), Azure.ResourceManager.Cdn.Models.DomainValidationState? domainValidationState = default(Azure.ResourceManager.Cdn.Models.DomainValidationState?), string hostName = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Cdn.Models.DomainValidationProperties validationProperties = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch FrontDoorCustomDomainPatch(string profileName = null, Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent tlsSettings = null, Azure.Core.ResourceIdentifier dnsZoneId = null, Azure.Core.ResourceIdentifier preValidatedCustomDomainResourceId = null) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorEndpointData FrontDoorEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string profileName = null, Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?), string hostName = null, Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch FrontDoorEndpointPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string profileName = null, Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorOriginData FrontDoorOriginData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string originGroupName = null, Azure.Core.ResourceIdentifier originId = null, string hostName = null, int? httpPort = default(int?), int? httpsPort = default(int?), string originHostHeader = null, int? priority = default(int?), int? weight = default(int?), Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties sharedPrivateLinkResource = null, Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), bool? enforceCertificateNameCheck = default(bool?), Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorOriginGroupData FrontDoorOriginGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string profileName = null, Azure.ResourceManager.Cdn.Models.LoadBalancingSettings loadBalancingSettings = null, Azure.ResourceManager.Cdn.Models.HealthProbeSettings healthProbeSettings = null, int? trafficRestorationTimeInMinutes = default(int?), Azure.ResourceManager.Cdn.Models.EnabledState? sessionAffinityState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties authentication = null, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.FrontDoorOriginGroupData FrontDoorOriginGroupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string profileName, Azure.ResourceManager.Cdn.Models.LoadBalancingSettings loadBalancingSettings, Azure.ResourceManager.Cdn.Models.HealthProbeSettings healthProbeSettings, int? trafficRestorationTimeInMinutes, Azure.ResourceManager.Cdn.Models.EnabledState? sessionAffinityState, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState, Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch FrontDoorOriginGroupPatch(string profileName, Azure.ResourceManager.Cdn.Models.LoadBalancingSettings loadBalancingSettings, Azure.ResourceManager.Cdn.Models.HealthProbeSettings healthProbeSettings, int? trafficRestorationTimeInMinutes, Azure.ResourceManager.Cdn.Models.EnabledState? sessionAffinityState) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch FrontDoorOriginGroupPatch(string profileName = null, Azure.ResourceManager.Cdn.Models.LoadBalancingSettings loadBalancingSettings = null, Azure.ResourceManager.Cdn.Models.HealthProbeSettings healthProbeSettings = null, int? trafficRestorationTimeInMinutes = default(int?), Azure.ResourceManager.Cdn.Models.EnabledState? sessionAffinityState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties authentication = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch FrontDoorOriginPatch(string originGroupName = null, Azure.Core.ResourceIdentifier originId = null, string hostName = null, int? httpPort = default(int?), int? httpsPort = default(int?), string originHostHeader = null, int? priority = default(int?), int? weight = default(int?), Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties sharedPrivateLinkResource = null, Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), bool? enforceCertificateNameCheck = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRouteData FrontDoorRouteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string endpointName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo> customDomains = null, Azure.Core.ResourceIdentifier originGroupId = null, string originPath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> ruleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol> supportedProtocols = null, System.Collections.Generic.IEnumerable<string> patternsToMatch = null, Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration cacheConfiguration = null, Azure.ResourceManager.Cdn.Models.ForwardingProtocol? forwardingProtocol = default(Azure.ResourceManager.Cdn.Models.ForwardingProtocol?), Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? linkToDefaultDomain = default(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain?), Azure.ResourceManager.Cdn.Models.HttpsRedirect? httpsRedirect = default(Azure.ResourceManager.Cdn.Models.HttpsRedirect?), Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?), Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch FrontDoorRoutePatch(string endpointName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo> customDomains = null, Azure.Core.ResourceIdentifier originGroupId = null, string originPath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> ruleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol> supportedProtocols = null, System.Collections.Generic.IEnumerable<string> patternsToMatch = null, Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration cacheConfiguration = null, Azure.ResourceManager.Cdn.Models.ForwardingProtocol? forwardingProtocol = default(Azure.ResourceManager.Cdn.Models.ForwardingProtocol?), Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? linkToDefaultDomain = default(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain?), Azure.ResourceManager.Cdn.Models.HttpsRedirect? httpsRedirect = default(Azure.ResourceManager.Cdn.Models.HttpsRedirect?), Azure.ResourceManager.Cdn.Models.EnabledState? enabledState = default(Azure.ResourceManager.Cdn.Models.EnabledState?)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRuleData FrontDoorRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ruleSetName = null, int? order = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> conditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> actions = null, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? matchProcessingBehavior = default(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior?), Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch FrontDoorRulePatch(string ruleSetName = null, int? order = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> conditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> actions = null, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? matchProcessingBehavior = default(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior?)) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorRuleSetData FrontDoorRuleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?), string profileName = null) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorSecretData FrontDoorSecretData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?), string profileName = null, Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Cdn.FrontDoorSecurityPolicyData FrontDoorSecurityPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState?), Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus? deploymentStatus = default(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus?), string profileName = null, Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorUsage FrontDoorUsage(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit unit = default(Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit), long currentValue = (long)0, long limit = (long)0, Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName name = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName FrontDoorUsageResourceName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties ManagedCertificateProperties(string subject = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition ManagedRuleDefinition(string ruleId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition ManagedRuleGroupDefinition(string ruleGroupName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition> rules = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition ManagedRuleSetDefinition(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName = default(Azure.ResourceManager.Cdn.Models.CdnSkuName?), string provisioningState = null, string ruleSetType = null, string ruleSetVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition> ruleGroups = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponse MetricsResponse(System.DateTimeOffset? dateTimeBegin = default(System.DateTimeOffset?), System.DateTimeOffset? dateTimeEnd = default(System.DateTimeOffset?), Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity? granularity = default(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem> series = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem MetricsResponseSeriesItem(string metric = null, Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit? unit = default(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems> data = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem MetricsResponseSeriesPropertiesItemsItem(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MigrateResult MigrateResult(Azure.Core.ResourceIdentifier resourceId = null, string migrateResultType = null, Azure.Core.ResourceIdentifier migratedProfileResourceIdId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.Models.MigrateResult MigrateResult(string Id = null, string migrateResultType = null, Azure.Core.ResourceIdentifier migratedProfileResourceIdId = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MigrationContent MigrationContent(Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName = default(Azure.ResourceManager.Cdn.Models.CdnSkuName?), Azure.Core.ResourceIdentifier classicResourceReferenceId = null, string profileName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping> migrationWebApplicationFirewallMappings = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MigrationErrorType MigrationErrorType(string code = null, string resourceName = null, string errorMessage = null, string nextSteps = null) { throw null; }
        public static Azure.ResourceManager.Cdn.ProfileData ProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName = default(Azure.ResourceManager.Cdn.Models.CdnSkuName?), string kind = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Cdn.Models.ProfileResourceState? resourceState = default(Azure.ResourceManager.Cdn.Models.ProfileResourceState?), Azure.ResourceManager.Cdn.Models.ProfileProvisioningState? provisioningState = default(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, string> extendedProperties = null, System.Guid? frontDoorId = default(System.Guid?), int? originResponseTimeoutSeconds = default(int?), Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing logScrubbing = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Cdn.ProfileData ProfileData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Cdn.Models.CdnSkuName? skuName, string kind, Azure.ResourceManager.Cdn.Models.ProfileResourceState? resourceState, Azure.ResourceManager.Cdn.Models.ProfileProvisioningState? provisioningState, System.Guid? frontDoorId, int? originResponseTimeoutSeconds) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RankingsResponse RankingsResponse(System.DateTimeOffset? dateTimeBegin = default(System.DateTimeOffset?), System.DateTimeOffset? dateTimeEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem> tables = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem RankingsResponseTablesItem(string ranking = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem> data = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem RankingsResponseTablesPropertiesItemsItem(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem> metrics = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem RankingsResponseTablesPropertiesItemsMetricsItem(string metric = null, long? value = default(long?), float? percentage = default(float?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ResourcesResponse ResourcesResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem> endpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem> customDomains = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem ResourcesResponseCustomDomainsItem(string id = null, string name = null, string endpointId = null, bool? history = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem ResourcesResponseEndpointsItem(string id = null, string name = null, bool? history = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem> customDomains = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem ResourcesResponseEndpointsPropertiesItemsItem(string id = null, string name = null, string endpointId = null, bool? history = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SsoUri SsoUri(System.Uri availableSsoUri = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult SupportedOptimizationTypesListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.OptimizationType> supportedOptimizationTypes = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult ValidateCustomDomainResult(bool? isCustomDomainValid = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ValidateProbeResult ValidateProbeResult(bool? isValid = default(bool?), string errorCode = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ValidateSecretContent ValidateSecretContent(Azure.ResourceManager.Cdn.Models.SecretType secretType = default(Azure.ResourceManager.Cdn.Models.SecretType), Azure.Core.ResourceIdentifier secretSourceId = null, string secretVersion = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ValidateSecretResult ValidateSecretResult(Azure.ResourceManager.Cdn.Models.ValidationStatus? status = default(Azure.ResourceManager.Cdn.Models.ValidationStatus?), string message = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponse WafMetricsResponse(System.DateTimeOffset? dateTimeBegin = default(System.DateTimeOffset?), System.DateTimeOffset? dateTimeEnd = default(System.DateTimeOffset?), Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity? granularity = default(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem> series = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem WafMetricsResponseSeriesItem(string metric = null, Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit? unit = default(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems> data = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem WafMetricsResponseSeriesPropertiesItemsItem(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingsResponse WafRankingsResponse(System.DateTimeOffset? dateTimeBegin = default(System.DateTimeOffset?), System.DateTimeOffset? dateTimeEnd = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem> data = null) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem WafRankingsResponseDataItem(System.Collections.Generic.IEnumerable<string> groupValues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems> metrics = null) { throw null; }
    }
    public partial class AzureFirstPartyManagedCertificateProperties : Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>
    {
        public AzureFirstPartyManagedCertificateProperties() { }
        public string CertificateAuthority { get { throw null; } }
        public string ExpirationDate { get { throw null; } }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IList<string> SubjectAlternativeNames { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.AzureFirstPartyManagedCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheBehaviorSetting : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheBehaviorSetting(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting BypassCache { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting Override { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting SetIfMissing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting left, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting left, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>
    {
        public CacheConfiguration() { }
        public Azure.ResourceManager.Cdn.Models.RuleCacheBehavior? CacheBehavior { get { throw null; } set { } }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled? IsCompressionEnabled { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CacheExpirationActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>
    {
        public CacheExpirationActionProperties(Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting cacheBehavior, Azure.ResourceManager.Cdn.Models.CdnCacheLevel cacheType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CacheExpirationActionProperties(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType actionType, Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting cacheBehavior, Azure.ResourceManager.Cdn.Models.CdnCacheLevel cacheType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.CacheExpirationActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CacheBehaviorSetting CacheBehavior { get { throw null; } set { } }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CdnCacheLevel CacheType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheExpirationActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheExpirationActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheExpirationActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheExpirationActionType CacheExpirationAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType left, Azure.ResourceManager.Cdn.Models.CacheExpirationActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheExpirationActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheExpirationActionType left, Azure.ResourceManager.Cdn.Models.CacheExpirationActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheKeyQueryStringActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CacheKeyQueryStringActionProperties(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType actionType, Azure.ResourceManager.Cdn.Models.QueryStringBehavior queryStringBehavior) { }
        public CacheKeyQueryStringActionProperties(Azure.ResourceManager.Cdn.Models.QueryStringBehavior queryStringBehavior) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType ActionType { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringBehavior QueryStringBehavior { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CacheKeyQueryStringActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CacheKeyQueryStringActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType CacheKeyQueryStringBehaviorAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType left, Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType left, Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CanMigrateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>
    {
        public CanMigrateContent(Azure.ResourceManager.Resources.Models.WritableSubResource classicResourceReference) { }
        public Azure.Core.ResourceIdentifier ClassicResourceReferenceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CanMigrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CanMigrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CanMigrateDefaultSku : System.IEquatable<Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CanMigrateDefaultSku(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku PremiumAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku StandardAzureFrontDoor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku left, Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku left, Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CanMigrateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>
    {
        internal CanMigrateResult() { }
        public bool? CanMigrate { get { throw null; } }
        public string CanMigrateResultType { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CanMigrateDefaultSku? DefaultSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.MigrationErrorType> Errors { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CanMigrateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CanMigrateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CanMigrateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnCacheLevel : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnCacheLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnCacheLevel(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnCacheLevel All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnCacheLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnCacheLevel left, Azure.ResourceManager.Cdn.Models.CdnCacheLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnCacheLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnCacheLevel left, Azure.ResourceManager.Cdn.Models.CdnCacheLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnCertificateSource : Azure.ResourceManager.Cdn.Models.CertificateSourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CdnCertificateSource(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType sourceType, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType certificateType) { }
        public CdnCertificateSource(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType certificateType) { }
        public Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType CertificateType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType SourceType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnCertificateSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnCertificateSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCertificateSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnCertificateSourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnCertificateSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType CdnCertificateSource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType left, Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType left, Azure.ResourceManager.Cdn.Models.CdnCertificateSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnCustomDomainCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>
    {
        public CdnCustomDomainCreateOrUpdateContent() { }
        public string HostName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnCustomDomainCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>
    {
        public CdnEndpointPatch() { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultOriginGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy DeliveryPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.GeoFilter> GeoFilters { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
        public bool? IsHttpAllowed { get { throw null; } set { } }
        public bool? IsHttpsAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OptimizationType? OptimizationType { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningKey> UriSigningKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState left, Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState left, Azure.ResourceManager.Cdn.Models.CdnEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnManagedCertificateType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnManagedCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType Dedicated { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType left, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType left, Azure.ResourceManager.Cdn.Models.CdnManagedCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnManagedHttpsContent : Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>
    {
        public CdnManagedHttpsContent(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType protocolType, Azure.ResourceManager.Cdn.Models.CdnCertificateSource certificateSourceParameters) : base (default(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType)) { }
        public Azure.ResourceManager.Cdn.Models.CdnCertificateSource CertificateSourceParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnManagedHttpsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnMigrationToAfdContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>
    {
        public CdnMigrationToAfdContent(Azure.ResourceManager.Cdn.Models.CdnSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping> MigrationEndpointMappings { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnMigrationToAfdContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CdnMinimumTlsVersion
    {
        None = 0,
        Tls1_0 = 1,
        Tls1_2 = 2,
    }
    public partial class CdnNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>
    {
        public CdnNameAvailabilityContent(string name, Azure.ResourceManager.Cdn.Models.CdnResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>
    {
        internal CdnNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnOriginGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>
    {
        public CdnOriginGroupPatch() { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CdnOriginPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>
    {
        public CdnOriginPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnOriginPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnOriginPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnOriginPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnResourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnResourceType Endpoints { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnResourceType FrontDoorEndpoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnResourceType left, Azure.ResourceManager.Cdn.Models.CdnResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnResourceType left, Azure.ResourceManager.Cdn.Models.CdnResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnSku>
    {
        public CdnSku() { }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnSkuName : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName CustomVerizon { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName PremiumAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName PremiumVerizon { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName Standard955BandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAkamai { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAvgBandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlus955BandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlusAvgBandWidthChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardPlusChinaCdn { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CdnSkuName StandardVerizon { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnSkuName left, Azure.ResourceManager.Cdn.Models.CdnSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnSkuName left, Azure.ResourceManager.Cdn.Models.CdnSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnUsage>
    {
        internal CdnUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CdnUsageUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.CdnUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CdnUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CdnUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CdnUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CdnUsageUnit left, Azure.ResourceManager.Cdn.Models.CdnUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CdnUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CdnUsageUnit left, Azure.ResourceManager.Cdn.Models.CdnUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CdnWebApplicationFirewallPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>
    {
        public CdnWebApplicationFirewallPolicyPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CdnWebApplicationFirewallPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateDeleteAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.CertificateDeleteAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateDeleteAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CertificateDeleteAction NoAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction left, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CertificateDeleteAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CertificateDeleteAction left, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class CertificateSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>
    {
        protected CertificateSourceProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CertificateSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CertificateSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CertificateSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateUpdateAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.CertificateUpdateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateUpdateAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CertificateUpdateAction NoAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction left, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CertificateUpdateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CertificateUpdateAction left, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CidrIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>
    {
        public CidrIPAddress() { }
        public string BaseIPAddress { get { throw null; } set { } }
        public int? PrefixLength { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CidrIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CidrIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CidrIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClientPortMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ClientPortMatchCondition(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.ClientPortOperator clientPortOperator) { }
        public ClientPortMatchCondition(Azure.ResourceManager.Cdn.Models.ClientPortOperator clientPortOperator) { }
        public Azure.ResourceManager.Cdn.Models.ClientPortOperator ClientPortOperator { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientPortMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientPortMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType ClientPortCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ClientPortMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientPortOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ClientPortOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientPortOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ClientPortOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ClientPortOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ClientPortOperator left, Azure.ResourceManager.Cdn.Models.ClientPortOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ClientPortOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ClientPortOperator left, Azure.ResourceManager.Cdn.Models.ClientPortOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>
    {
        internal Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems() { }
        public System.DateTimeOffset? DateOn { get { throw null; } }
        public float? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>
    {
        internal Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems() { }
        public System.DateTimeOffset? DateOn { get { throw null; } }
        public float? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>
    {
        internal ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems() { }
        public string Metric { get { throw null; } }
        public double? Percentage { get { throw null; } }
        public long? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinentsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>
    {
        internal ContinentsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem> Continents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem> CountryOrRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinentsResponseContinentsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>
    {
        internal ContinentsResponseContinentsItem() { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseContinentsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinentsResponseCountryOrRegionsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>
    {
        internal ContinentsResponseCountryOrRegionsItem() { }
        public string ContinentId { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ContinentsResponseCountryOrRegionsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CookiesMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CookiesMatchCondition(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.CookiesOperator cookiesOperator) { }
        public CookiesMatchCondition(Azure.ResourceManager.Cdn.Models.CookiesOperator cookiesOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType ConditionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CookiesOperator CookiesOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CookiesMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CookiesMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CookiesMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CookiesMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CookiesMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType CookiesCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType left, Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType left, Azure.ResourceManager.Cdn.Models.CookiesMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CookiesOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.CookiesOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CookiesOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CookiesOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CookiesOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CookiesOperator left, Azure.ResourceManager.Cdn.Models.CookiesOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CookiesOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CookiesOperator left, Azure.ResourceManager.Cdn.Models.CookiesOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class CustomDomainHttpsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>
    {
        protected CustomDomainHttpsContent(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType protocolType) { }
        public Azure.ResourceManager.Cdn.Models.CdnMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType ProtocolType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomDomainResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomDomainResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomDomainResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomDomainResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState left, Azure.ResourceManager.Cdn.Models.CustomDomainResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomDomainResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomDomainResourceState left, Azure.ResourceManager.Cdn.Models.CustomDomainResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerCertificateProperties : Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>
    {
        public CustomerCertificateProperties(Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) { }
        public string CertificateAuthority { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IList<string> SubjectAlternativeNames { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public bool? UseLatestVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomerCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsAvailabilityState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState CertificateDeleted { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState CertificateDeployed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DeletingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DeployingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestApproved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestRejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState DomainControlValidationRequestTimedOut { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState IssuingCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState PendingDomainControlValidationREquestApproval { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState SubmittingDomainControlValidationRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState left, Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState left, Azure.ResourceManager.Cdn.Models.CustomHttpsAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Disabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Enabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.Cdn.Models.CustomHttpsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRule>
    {
        public CustomRule(string name, int priority, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition> matchConditions, Azure.ResourceManager.Cdn.Models.OverrideActionType action) { }
        public Azure.ResourceManager.Cdn.Models.OverrideActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition> MatchConditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomRuleEnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState left, Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState left, Azure.ResourceManager.Cdn.Models.CustomRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRuleMatchCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>
    {
        public CustomRuleMatchCondition(Azure.ResourceManager.Cdn.Models.WafMatchVariable matchVariable, Azure.ResourceManager.Cdn.Models.MatchOperator matchOperator, System.Collections.Generic.IEnumerable<string> matchValue) { }
        public Azure.ResourceManager.Cdn.Models.MatchOperator MatchOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValue { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMatchVariable MatchVariable { get { throw null; } set { } }
        public bool? NegateCondition { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.TransformType> Transforms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeepCreatedCustomDomain : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>
    {
        internal DeepCreatedCustomDomain() { }
        public string HostName { get { throw null; } }
        public string Name { get { throw null; } }
        public string ValidationData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedCustomDomain>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeepCreatedOrigin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>
    {
        public DeepCreatedOrigin(string name) { }
        public bool? Enabled { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string OriginHostHeader { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOrigin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeepCreatedOriginGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>
    {
        public DeepCreatedOriginGroup(string name) { }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Origins { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings ResponseBasedOriginErrorDetectionSettings { get { throw null; } set { } }
        public int? TrafficRestorationTimeToHealedOrNewEndpointsInMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeepCreatedOriginGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>
    {
        public DeliveryRule(int order, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Order { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DeliveryRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>
    {
        protected DeliveryRuleAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DeliveryRuleActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>
    {
        protected DeliveryRuleActionProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleCacheExpirationAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>
    {
        public DeliveryRuleCacheExpirationAction(Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.CacheExpirationActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheExpirationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleCacheKeyQueryStringAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>
    {
        public DeliveryRuleCacheKeyQueryStringAction(Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.CacheKeyQueryStringActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCacheKeyQueryStringAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleClientPortCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>
    {
        public DeliveryRuleClientPortCondition(Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.ClientPortMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleClientPortCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DeliveryRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>
    {
        protected DeliveryRuleCondition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DeliveryRuleConditionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>
    {
        protected DeliveryRuleConditionProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleCookiesCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>
    {
        public DeliveryRuleCookiesCondition(Azure.ResourceManager.Cdn.Models.CookiesMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.CookiesMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleCookiesCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleHostNameCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>
    {
        public DeliveryRuleHostNameCondition(Azure.ResourceManager.Cdn.Models.HostNameMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.HostNameMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHostNameCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleHttpVersionCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>
    {
        public DeliveryRuleHttpVersionCondition(Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleHttpVersionCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleIsDeviceCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>
    {
        public DeliveryRuleIsDeviceCondition(Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleIsDeviceCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRulePostArgsCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>
    {
        public DeliveryRulePostArgsCondition(Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRulePostArgsCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleQueryStringCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>
    {
        public DeliveryRuleQueryStringCondition(Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleQueryStringCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRemoteAddressCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>
    {
        public DeliveryRuleRemoteAddressCondition(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRemoteAddressCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestBodyCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>
    {
        public DeliveryRuleRequestBodyCondition(Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestBodyCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestHeaderAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>
    {
        public DeliveryRuleRequestHeaderAction(Azure.ResourceManager.Cdn.Models.HeaderActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.HeaderActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestHeaderCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>
    {
        public DeliveryRuleRequestHeaderCondition(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestHeaderCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestMethodCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>
    {
        public DeliveryRuleRequestMethodCondition(Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestMethodCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestSchemeCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>
    {
        public DeliveryRuleRequestSchemeCondition(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestSchemeCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRequestUriCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>
    {
        public DeliveryRuleRequestUriCondition(Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRequestUriCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleResponseHeaderAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>
    {
        public DeliveryRuleResponseHeaderAction(Azure.ResourceManager.Cdn.Models.HeaderActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.HeaderActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleResponseHeaderAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleRouteConfigurationOverrideAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>
    {
        public DeliveryRuleRouteConfigurationOverrideAction(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleRouteConfigurationOverrideAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleServerPortCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>
    {
        public DeliveryRuleServerPortCondition(Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleServerPortCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleSocketAddressCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>
    {
        public DeliveryRuleSocketAddressCondition(Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSocketAddressCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeliveryRuleSslProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeliveryRuleSslProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol left, Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol left, Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeliveryRuleSslProtocolCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>
    {
        public DeliveryRuleSslProtocolCondition(Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleSslProtocolMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DeliveryRuleSslProtocolMatchCondition(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType sslProtocolMatchConditionType, Azure.ResourceManager.Cdn.Models.SslProtocolOperator sslProtocolOperator) { }
        public DeliveryRuleSslProtocolMatchCondition(Azure.ResourceManager.Cdn.Models.SslProtocolOperator sslProtocolOperator) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocol> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType SslProtocolMatchConditionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SslProtocolOperator SslProtocolOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleSslProtocolMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleUriFileExtensionCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>
    {
        public DeliveryRuleUriFileExtensionCondition(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileExtensionCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleUriFileNameCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>
    {
        public DeliveryRuleUriFileNameCondition(Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriFileNameCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryRuleUriPathCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>
    {
        public DeliveryRuleUriPathCondition(Azure.ResourceManager.Cdn.Models.UriPathMatchCondition properties) { }
        public Azure.ResourceManager.Cdn.Models.UriPathMatchCondition Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DeliveryRuleUriPathCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DestinationProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.DestinationProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DestinationProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DestinationProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DestinationProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DestinationProtocol left, Azure.ResourceManager.Cdn.Models.DestinationProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DestinationProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DestinationProtocol left, Azure.ResourceManager.Cdn.Models.DestinationProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Cdn.Models.DomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope left, Azure.ResourceManager.Cdn.Models.DomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DomainNameLabelScope left, Azure.ResourceManager.Cdn.Models.DomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>
    {
        internal DomainValidationProperties() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string ValidationToken { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DomainValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.DomainValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.DomainValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainValidationState : System.IEquatable<Azure.ResourceManager.Cdn.Models.DomainValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Approved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState InternalError { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState PendingRevalidation { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState RefreshingValidationToken { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Rejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Submitting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.DomainValidationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.DomainValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.DomainValidationState left, Azure.ResourceManager.Cdn.Models.DomainValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.DomainValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.DomainValidationState left, Azure.ResourceManager.Cdn.Models.DomainValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeNode : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EdgeNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EdgeNode>
    {
        public EdgeNode() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.IPAddressGroup> IPAddressGroups { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EdgeNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EdgeNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EdgeNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EdgeNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EdgeNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EdgeNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EdgeNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.EnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.EnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.EnabledState left, Azure.ResourceManager.Cdn.Models.EnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.EnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.EnabledState left, Azure.ResourceManager.Cdn.Models.EnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointDeliveryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>
    {
        public EndpointDeliveryPolicy(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.DeliveryRule> rules) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRule> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointDeliveryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>
    {
        public EndpointNameAvailabilityContent(string name, Azure.ResourceManager.Cdn.Models.CdnResourceType resourceType) { }
        public Azure.ResourceManager.Cdn.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>
    {
        internal EndpointNameAvailabilityResult() { }
        public string AvailableHostname { get { throw null; } }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.EndpointNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.EndpointResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.EndpointResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.EndpointResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.EndpointResourceState left, Azure.ResourceManager.Cdn.Models.EndpointResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.EndpointResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.EndpointResourceState left, Azure.ResourceManager.Cdn.Models.EndpointResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForwardingProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.ForwardingProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForwardingProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol HttpOnly { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol HttpsOnly { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ForwardingProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ForwardingProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ForwardingProtocol left, Azure.ResourceManager.Cdn.Models.ForwardingProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ForwardingProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ForwardingProtocol left, Azure.ResourceManager.Cdn.Models.ForwardingProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorActivatedResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>
    {
        public FrontDoorActivatedResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorCertificateType : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType AzureFirstPartyManagedCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType CustomerCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType ManagedCertificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType left, Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType left, Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorCustomDomainHttpsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>
    {
        public FrontDoorCustomDomainHttpsContent(Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType certificateType) { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorCertificateType CertificateType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.AfdCipherSuiteSetType? CipherSuiteSetType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet CustomizedCipherSuiteSet { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>
    {
        public FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls12> CipherSuiteSetForTls12 { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.AfdCustomizedCipherSuiteForTls13> CipherSuiteSetForTls13 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorCustomDomainPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>
    {
        public FrontDoorCustomDomainPatch() { }
        public Azure.Core.ResourceIdentifier DnsZoneId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PreValidatedCustomDomainResourceId { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainHttpsContent TlsSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorCustomDomainPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorDeploymentStatus : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorDeploymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus left, Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus left, Azure.ResourceManager.Cdn.Models.FrontDoorDeploymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>
    {
        public FrontDoorEndpointPatch() { }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorEndpointProtocol : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorEndpointProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol left, Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol left, Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum FrontDoorMinimumTlsVersion
    {
        Tls1_0 = 0,
        Tls1_2 = 1,
        Tls1_3 = 2,
    }
    public partial class FrontDoorOriginGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>
    {
        public FrontDoorOriginGroupPatch() { }
        public Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeSettings HealthProbeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LoadBalancingSettings LoadBalancingSettings { get { throw null; } set { } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? SessionAffinityState { get { throw null; } set { } }
        public int? TrafficRestorationTimeInMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorOriginPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>
    {
        public FrontDoorOriginPatch() { }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public bool? EnforceCertificateNameCheck { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public string OriginGroupName { get { throw null; } }
        public string OriginHostHeader { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginId { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties SharedPrivateLinkResource { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorOriginPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState left, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState left, Azure.ResourceManager.Cdn.Models.FrontDoorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorPurgeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>
    {
        public FrontDoorPurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
        public System.Collections.Generic.IList<string> Domains { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorPurgeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorQueryStringCachingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorQueryStringCachingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior IgnoreQueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior IgnoreSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior IncludeSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior UseQueryString { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorRouteCacheConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>
    {
        public FrontDoorRouteCacheConfiguration() { }
        public Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings CompressionSettings { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorQueryStringCachingBehavior? QueryStringCachingBehavior { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRoutePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>
    {
        public FrontDoorRoutePatch() { }
        public Azure.ResourceManager.Cdn.Models.FrontDoorRouteCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo> CustomDomains { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.EnabledState? EnabledState { get { throw null; } set { } }
        public string EndpointName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpsRedirect? HttpsRedirect { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain? LinkToDefaultDomain { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        public string OriginPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> RuleSets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.FrontDoorEndpointProtocol> SupportedProtocols { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRoutePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>
    {
        public FrontDoorRulePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.DeliveryRuleCondition> Conditions { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string RuleSetName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FrontDoorSecretProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>
    {
        protected FrontDoorSecretProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorSecurityPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>
    {
        public FrontDoorSecurityPolicyPatch() { }
        public Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorSecurityPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>
    {
        internal FrontDoorUsage() { }
        public long CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorUsageResourceName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>
    {
        internal FrontDoorUsageResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.FrontDoorUsageResourceName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorUsageUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit left, Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit left, Azure.ResourceManager.Cdn.Models.FrontDoorUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.GeoFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.GeoFilter>
    {
        public GeoFilter(string relativePath, Azure.ResourceManager.Cdn.Models.GeoFilterAction action, System.Collections.Generic.IEnumerable<string> countryCodes) { }
        public Azure.ResourceManager.Cdn.Models.GeoFilterAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CountryCodes { get { throw null; } }
        public string RelativePath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.GeoFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.GeoFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.GeoFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.GeoFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.GeoFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.GeoFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.GeoFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum GeoFilterAction
    {
        Block = 0,
        Allow = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeaderAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.HeaderAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeaderAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Append { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Delete { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HeaderAction Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HeaderAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HeaderAction left, Azure.ResourceManager.Cdn.Models.HeaderAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HeaderAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HeaderAction left, Azure.ResourceManager.Cdn.Models.HeaderAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HeaderActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>
    {
        public HeaderActionProperties(Azure.ResourceManager.Cdn.Models.HeaderAction headerAction, string headerName) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public HeaderActionProperties(Azure.ResourceManager.Cdn.Models.HeaderActionType actionType, Azure.ResourceManager.Cdn.Models.HeaderAction headerAction, string headerName) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.HeaderActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HeaderAction HeaderAction { get { throw null; } set { } }
        public string HeaderName { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HeaderActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HeaderActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HeaderActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeaderActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HeaderActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeaderActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HeaderActionType HeaderAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HeaderActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HeaderActionType left, Azure.ResourceManager.Cdn.Models.HeaderActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HeaderActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HeaderActionType left, Azure.ResourceManager.Cdn.Models.HeaderActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum HealthProbeProtocol
    {
        NotSet = 0,
        Http = 1,
        Https = 2,
    }
    public enum HealthProbeRequestType
    {
        NotSet = 0,
        Get = 1,
        Head = 2,
    }
    public partial class HealthProbeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>
    {
        public HealthProbeSettings() { }
        public int? ProbeIntervalInSeconds { get { throw null; } set { } }
        public string ProbePath { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeProtocol? ProbeProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HealthProbeRequestType? ProbeRequestType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HealthProbeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HealthProbeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HealthProbeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>
    {
        public HostNameAvailabilityContent(string hostName) { }
        public string HostName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostNameMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public HostNameMatchCondition(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.HostNameOperator hostNameOperator) { }
        public HostNameMatchCondition(Azure.ResourceManager.Cdn.Models.HostNameOperator hostNameOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType ConditionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HostNameOperator HostNameOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HostNameMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HostNameMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HostNameMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostNameMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostNameMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType HostNameCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.HostNameMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostNameOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.HostNameOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostNameOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HostNameOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HostNameOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HostNameOperator left, Azure.ResourceManager.Cdn.Models.HostNameOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HostNameOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HostNameOperator left, Azure.ResourceManager.Cdn.Models.HostNameOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpErrorRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>
    {
        public HttpErrorRange() { }
        public int? Begin { get { throw null; } set { } }
        public int? End { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HttpErrorRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HttpErrorRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpErrorRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpsRedirect : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpsRedirect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpsRedirect(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpsRedirect Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.HttpsRedirect Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpsRedirect other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpsRedirect left, Azure.ResourceManager.Cdn.Models.HttpsRedirect right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpsRedirect (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpsRedirect left, Azure.ResourceManager.Cdn.Models.HttpsRedirect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpVersionMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public HttpVersionMatchCondition(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.HttpVersionOperator httpVersionOperator) { }
        public HttpVersionMatchCondition(Azure.ResourceManager.Cdn.Models.HttpVersionOperator httpVersionOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType ConditionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.HttpVersionOperator HttpVersionOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.HttpVersionMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpVersionMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpVersionMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType HttpVersionCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType left, Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType left, Azure.ResourceManager.Cdn.Models.HttpVersionMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpVersionOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.HttpVersionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpVersionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.HttpVersionOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.HttpVersionOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.HttpVersionOperator left, Azure.ResourceManager.Cdn.Models.HttpVersionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.HttpVersionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.HttpVersionOperator left, Azure.ResourceManager.Cdn.Models.HttpVersionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAddressGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>
    {
        public IPAddressGroup() { }
        public string DeliveryRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CidrIPAddress> IPv4Addresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.CidrIPAddress> IPv6Addresses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.IPAddressGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.IPAddressGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IPAddressGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IsDeviceMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public IsDeviceMatchCondition(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.IsDeviceOperator isDeviceOperator) { }
        public IsDeviceMatchCondition(Azure.ResourceManager.Cdn.Models.IsDeviceOperator isDeviceOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType ConditionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.IsDeviceOperator IsDeviceOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.IsDeviceMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue Desktop { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue Mobile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType IsDeviceCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType left, Azure.ResourceManager.Cdn.Models.IsDeviceMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDeviceOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.IsDeviceOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDeviceOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.IsDeviceOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.IsDeviceOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.IsDeviceOperator left, Azure.ResourceManager.Cdn.Models.IsDeviceOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.IsDeviceOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.IsDeviceOperator left, Azure.ResourceManager.Cdn.Models.IsDeviceOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultCertificateSource : Azure.ResourceManager.Cdn.Models.CertificateSourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public KeyVaultCertificateSource(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType sourceType, string subscriptionId, string resourceGroupName, string vaultName, string secretName, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction updateRule, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction deleteRule) { }
        public KeyVaultCertificateSource(string subscriptionId, string resourceGroupName, string vaultName, string secretName, Azure.ResourceManager.Cdn.Models.CertificateUpdateAction updateRule, Azure.ResourceManager.Cdn.Models.CertificateDeleteAction deleteRule) { }
        public Azure.ResourceManager.Cdn.Models.CertificateDeleteAction DeleteRule { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType SourceType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CertificateUpdateAction UpdateRule { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultCertificateSourceType : System.IEquatable<Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultCertificateSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType KeyVaultCertificateSource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType left, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType left, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSigningKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>
    {
        public KeyVaultSigningKey(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType keyType, string subscriptionId, string resourceGroupName, string vaultName, string secretName, string secretVersion) { }
        public Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType KeyType { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string VaultName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSigningKeyType : System.IEquatable<Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSigningKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType KeyVaultSigningKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType left, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType left, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkToDefaultDomain : System.IEquatable<Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkToDefaultDomain(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain left, Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain left, Azure.ResourceManager.Cdn.Models.LinkToDefaultDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBalancingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>
    {
        public LoadBalancingSettings() { }
        public int? AdditionalLatencyInMilliseconds { get { throw null; } set { } }
        public int? SampleSize { get { throw null; } set { } }
        public int? SuccessfulSamplesRequired { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.LoadBalancingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.LoadBalancingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadBalancingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadContent>
    {
        public LoadContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.LoadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.LoadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.LoadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.LoadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestBandwidth { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric ClientRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric OriginRequestBandwidth { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric OriginRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetric TotalLatency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetric left, Azure.ResourceManager.Cdn.Models.LogMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetric left, Azure.ResourceManager.Cdn.Models.LogMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetricsGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetricsGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetricsGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity left, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetricsGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetricsGranularity left, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogMetricsGroupBy : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogMetricsGroupBy(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CacheStatus { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy CustomDomain { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy HttpStatusCode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy Protocol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy left, Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy left, Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogRanking : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogRanking>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogRanking(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Browser { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Referrer { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking Uri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRanking UserAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogRanking other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogRanking left, Azure.ResourceManager.Cdn.Models.LogRanking right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogRanking (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogRanking left, Azure.ResourceManager.Cdn.Models.LogRanking right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogRankingMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.LogRankingMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogRankingMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ClientRequestCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ClientRequestTraffic { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric ErrorCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric HitCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric MissCount { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.LogRankingMetric UserErrorCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.LogRankingMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.LogRankingMetric left, Azure.ResourceManager.Cdn.Models.LogRankingMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.LogRankingMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.LogRankingMetric left, Azure.ResourceManager.Cdn.Models.LogRankingMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedCertificateProperties : Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>
    {
        public ManagedCertificateProperties() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string Subject { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>
    {
        internal ManagedRuleDefinition() { }
        public string Description { get { throw null; } }
        public string RuleId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleGroupDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>
    {
        internal ManagedRuleGroupDefinition() { }
        public string Description { get { throw null; } }
        public string RuleGroupName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ManagedRuleDefinition> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleGroupOverrideSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>
    {
        public ManagedRuleGroupOverrideSetting(string ruleGroupName) { }
        public string RuleGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleOverrideSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>
    {
        public ManagedRuleOverrideSetting(string ruleId) { }
        public Azure.ResourceManager.Cdn.Models.OverrideActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState? EnabledState { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleOverrideSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleSetDefinition : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>
    {
        public ManagedRuleSetDefinition() { }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupDefinition> RuleGroups { get { throw null; } }
        public string RuleSetType { get { throw null; } }
        public string RuleSetVersion { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ManagedRuleSetDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleSetupState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleSetupState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState left, Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState left, Azure.ResourceManager.Cdn.Models.ManagedRuleSetupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.MatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator IPMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MatchOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MatchOperator left, Azure.ResourceManager.Cdn.Models.MatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MatchOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MatchOperator left, Azure.ResourceManager.Cdn.Models.MatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchProcessingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchProcessingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior Continue { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior left, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior left, Azure.ResourceManager.Cdn.Models.MatchProcessingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>
    {
        internal MetricsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity? Granularity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem> Series { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsResponseGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsResponseGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.MetricsResponseGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponseSeriesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>
    {
        internal MetricsResponseSeriesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.Components1Gs0LlpSchemasMetricsresponsePropertiesSeriesItemsPropertiesDataItems> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem> Groups { get { throw null; } }
        public string Metric { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsResponseSeriesItemUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsResponseSeriesItemUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit BitsPerSecond { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit Count { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit MilliSeconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesItemUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricsResponseSeriesPropertiesItemsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>
    {
        internal MetricsResponseSeriesPropertiesItemsItem() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MetricsResponseSeriesPropertiesItemsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrateResult>
    {
        internal MigrateResult() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigratedProfileResourceIdId { get { throw null; } }
        public string MigrateResultType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationContent>
    {
        public MigrationContent(Azure.ResourceManager.Cdn.Models.CdnSku sku, Azure.ResourceManager.Resources.Models.WritableSubResource classicResourceReference, string profileName) { }
        public Azure.Core.ResourceIdentifier ClassicResourceReferenceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping> MigrationWebApplicationFirewallMappings { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.CdnSkuName? SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationEndpointMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>
    {
        public MigrationEndpointMapping() { }
        public string MigratedFrom { get { throw null; } set { } }
        public string MigratedTo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationEndpointMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationErrorType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>
    {
        internal MigrationErrorType() { }
        public string Code { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string NextSteps { get { throw null; } }
        public string ResourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationErrorType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationErrorType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationErrorType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationWebApplicationFirewallMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>
    {
        public MigrationWebApplicationFirewallMapping() { }
        public Azure.Core.ResourceIdentifier MigratedFromId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MigratedToId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.MigrationWebApplicationFirewallMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptimizationType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OptimizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptimizationType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType DynamicSiteAcceleration { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType GeneralMediaStreaming { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType GeneralWebDelivery { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType LargeFileDownload { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OptimizationType VideoOnDemandMediaStreaming { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OptimizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OptimizationType left, Azure.ResourceManager.Cdn.Models.OptimizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OptimizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OptimizationType left, Azure.ResourceManager.Cdn.Models.OptimizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OriginAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>
    {
        public OriginAuthenticationProperties() { }
        public Azure.ResourceManager.Cdn.Models.OriginAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.Uri Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginAuthenticationType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginAuthenticationType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginAuthenticationType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginAuthenticationType left, Azure.ResourceManager.Cdn.Models.OriginAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginAuthenticationType left, Azure.ResourceManager.Cdn.Models.OriginAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OriginGroupOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>
    {
        public OriginGroupOverride() { }
        public Azure.ResourceManager.Cdn.Models.ForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OriginGroupOverrideAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>
    {
        public OriginGroupOverrideAction(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OriginGroupOverrideActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public OriginGroupOverrideActionProperties(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType actionType, Azure.ResourceManager.Resources.Models.WritableSubResource originGroup) { }
        public OriginGroupOverrideActionProperties(Azure.ResourceManager.Resources.Models.WritableSubResource originGroup) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType ActionType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OriginGroupId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupOverrideActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupOverrideActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType OriginGroupOverrideAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType left, Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType left, Azure.ResourceManager.Cdn.Models.OriginGroupOverrideActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginGroupResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginGroupResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginGroupResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginGroupResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState left, Azure.ResourceManager.Cdn.Models.OriginGroupResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginGroupResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginGroupResourceState left, Azure.ResourceManager.Cdn.Models.OriginGroupResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginProvisioningState left, Azure.ResourceManager.Cdn.Models.OriginProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OriginResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.OriginResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OriginResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OriginResourceState Deleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OriginResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OriginResourceState left, Azure.ResourceManager.Cdn.Models.OriginResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OriginResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OriginResourceState left, Azure.ResourceManager.Cdn.Models.OriginResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverrideActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.OverrideActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverrideActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.OverrideActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OverrideActionType Block { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OverrideActionType Log { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.OverrideActionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.OverrideActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.OverrideActionType left, Azure.ResourceManager.Cdn.Models.OverrideActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.OverrideActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.OverrideActionType left, Azure.ResourceManager.Cdn.Models.OverrideActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParamIndicator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ParamIndicator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParamIndicator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator Expires { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator KeyId { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ParamIndicator Signature { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ParamIndicator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ParamIndicator left, Azure.ResourceManager.Cdn.Models.ParamIndicator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ParamIndicator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ParamIndicator left, Azure.ResourceManager.Cdn.Models.ParamIndicator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEnabledState : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyEnabledState left, Azure.ResourceManager.Cdn.Models.PolicyEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyEnabledState left, Azure.ResourceManager.Cdn.Models.PolicyEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyMode : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyMode(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyMode Detection { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyMode Prevention { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyMode left, Azure.ResourceManager.Cdn.Models.PolicyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyMode left, Azure.ResourceManager.Cdn.Models.PolicyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicyResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicyResourceState Enabling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicyResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicyResourceState left, Azure.ResourceManager.Cdn.Models.PolicyResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicyResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicyResourceState left, Azure.ResourceManager.Cdn.Models.PolicyResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicySettingsDefaultCustomBlockResponseStatusCode : System.IEquatable<Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode>
    {
        private readonly int _dummyPrimitive;
        public PolicySettingsDefaultCustomBlockResponseStatusCode(int value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredFive { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredSix { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredThree { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode FourHundredTwentyNine { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode TwoHundred { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode left, Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode left, Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostArgsMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public PostArgsMatchCondition(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.PostArgsOperator postArgsOperator) { }
        public PostArgsMatchCondition(Azure.ResourceManager.Cdn.Models.PostArgsOperator postArgsOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PostArgsOperator PostArgsOperator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PostArgsMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostArgsMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostArgsMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType PostArgsCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType left, Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType left, Azure.ResourceManager.Cdn.Models.PostArgsMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostArgsOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.PostArgsOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostArgsOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PostArgsOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PostArgsOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PostArgsOperator left, Azure.ResourceManager.Cdn.Models.PostArgsOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PostArgsOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PostArgsOperator left, Azure.ResourceManager.Cdn.Models.PostArgsOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreTransformCategory : System.IEquatable<Azure.ResourceManager.Cdn.Models.PreTransformCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreTransformCategory(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Lowercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Trim { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory Uppercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory UriDecode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PreTransformCategory UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PreTransformCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PreTransformCategory left, Azure.ResourceManager.Cdn.Models.PreTransformCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PreTransformCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PreTransformCategory left, Azure.ResourceManager.Cdn.Models.PreTransformCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointStatus : System.IEquatable<Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus left, Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus left, Azure.ResourceManager.Cdn.Models.PrivateEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileChangeSkuWafMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>
    {
        public ProfileChangeSkuWafMapping(string securityPolicyName, Azure.ResourceManager.Resources.Models.WritableSubResource changeToWafPolicy) { }
        public Azure.Core.ResourceIdentifier ChangeToWafPolicyId { get { throw null; } }
        public string SecurityPolicyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileLogScrubbing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>
    {
        public ProfileLogScrubbing() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules> ScrubbingRules { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ProfileScrubbingState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>
    {
        public ProfilePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ProfileLogScrubbing LogScrubbing { get { throw null; } set { } }
        public int? OriginResponseTimeoutSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProfileProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState left, Azure.ResourceManager.Cdn.Models.ProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProfileProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProfileProvisioningState left, Azure.ResourceManager.Cdn.Models.ProfileProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileResourceGetLogAnalyticsMetricsOptions
    {
        public ProfileResourceGetLogAnalyticsMetricsOptions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.LogMetricsGranularity granularity, System.Collections.Generic.IEnumerable<string> customDomains, System.Collections.Generic.IEnumerable<string> protocols) { }
        public System.Collections.Generic.IList<string> Continents { get { throw null; } }
        public System.Collections.Generic.IList<string> CountryOrRegions { get { throw null; } }
        public System.Collections.Generic.IList<string> CustomDomains { get { throw null; } }
        public System.DateTimeOffset DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.LogMetricsGranularity Granularity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.LogMetricsGroupBy> GroupBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.LogMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<string> Protocols { get { throw null; } }
    }
    public partial class ProfileResourceGetLogAnalyticsRankingsOptions
    {
        public ProfileResourceGetLogAnalyticsRankingsOptions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRanking> rankings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.LogRankingMetric> metrics, int maxRanking, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd) { }
        public System.Collections.Generic.IList<string> CustomDomains { get { throw null; } }
        public System.DateTimeOffset DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset DateTimeEnd { get { throw null; } }
        public int MaxRanking { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.LogRankingMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.LogRanking> Rankings { get { throw null; } }
    }
    public partial class ProfileResourceGetWafLogAnalyticsMetricsOptions
    {
        public ProfileResourceGetWafLogAnalyticsMetricsOptions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, Azure.ResourceManager.Cdn.Models.WafGranularity granularity) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafAction> Actions { get { throw null; } }
        public System.DateTimeOffset DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafGranularity Granularity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy> GroupBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafRuleType> RuleTypes { get { throw null; } }
    }
    public partial class ProfileResourceGetWafLogAnalyticsRankingsOptions
    {
        public ProfileResourceGetWafLogAnalyticsRankingsOptions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafMetric> metrics, System.DateTimeOffset dateTimeBegin, System.DateTimeOffset dateTimeEnd, int maxRanking, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.WafRankingType> rankings) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafAction> Actions { get { throw null; } }
        public System.DateTimeOffset DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset DateTimeEnd { get { throw null; } }
        public int MaxRanking { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafRankingType> Rankings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.WafRuleType> RuleTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileResourceState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProfileResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState AbortingMigration { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState CommittingMigration { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Migrated { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileResourceState PendingMigrationCommit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProfileResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProfileResourceState left, Azure.ResourceManager.Cdn.Models.ProfileResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProfileResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProfileResourceState left, Azure.ResourceManager.Cdn.Models.ProfileResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileScrubbingRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>
    {
        public ProfileScrubbingRules(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable matchVariable, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator selectorMatchOperator) { }
        public Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable MatchVariable { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator SelectorMatchOperator { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileScrubbingRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileScrubbingState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ProfileScrubbingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileScrubbingState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ProfileScrubbingState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ProfileScrubbingState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ProfileScrubbingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ProfileScrubbingState left, Azure.ResourceManager.Cdn.Models.ProfileScrubbingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ProfileScrubbingState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ProfileScrubbingState left, Azure.ResourceManager.Cdn.Models.ProfileScrubbingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>
    {
        public ProfileUpgradeContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping> wafMappingList) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ProfileChangeSkuWafMapping> WafMappingList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ProfileUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurgeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PurgeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PurgeContent>
    {
        public PurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.PurgeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PurgeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.PurgeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.PurgeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PurgeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PurgeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.PurgeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior Exclude { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior ExcludeAll { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior Include { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringBehavior IncludeAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringBehavior left, Azure.ResourceManager.Cdn.Models.QueryStringBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringBehavior left, Azure.ResourceManager.Cdn.Models.QueryStringBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum QueryStringCachingBehavior
    {
        NotSet = 0,
        IgnoreQueryString = 1,
        BypassCaching = 2,
        UseQueryString = 3,
    }
    public partial class QueryStringMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public QueryStringMatchCondition(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.QueryStringOperator queryStringOperator) { }
        public QueryStringMatchCondition(Azure.ResourceManager.Cdn.Models.QueryStringOperator queryStringOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.QueryStringOperator QueryStringOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.QueryStringMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType QueryStringCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType left, Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType left, Azure.ResourceManager.Cdn.Models.QueryStringMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryStringOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.QueryStringOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryStringOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.QueryStringOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.QueryStringOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.QueryStringOperator left, Azure.ResourceManager.Cdn.Models.QueryStringOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.QueryStringOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.QueryStringOperator left, Azure.ResourceManager.Cdn.Models.QueryStringOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RankingsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>
    {
        internal RankingsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem> Tables { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RankingsResponseTablesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>
    {
        internal RankingsResponseTablesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem> Data { get { throw null; } }
        public string Ranking { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RankingsResponseTablesPropertiesItemsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>
    {
        internal RankingsResponseTablesPropertiesItemsItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem> Metrics { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RankingsResponseTablesPropertiesItemsMetricsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>
    {
        internal RankingsResponseTablesPropertiesItemsMetricsItem() { }
        public string Metric { get { throw null; } }
        public float? Percentage { get { throw null; } }
        public long? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RankingsResponseTablesPropertiesItemsMetricsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RateLimitRule : Azure.ResourceManager.Cdn.Models.CustomRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>
    {
        public RateLimitRule(string name, int priority, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition> matchConditions, Azure.ResourceManager.Cdn.Models.OverrideActionType action, int rateLimitThreshold, int rateLimitDurationInMinutes) : base (default(string), default(int), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Cdn.Models.CustomRuleMatchCondition>), default(Azure.ResourceManager.Cdn.Models.OverrideActionType)) { }
        public int RateLimitDurationInMinutes { get { throw null; } set { } }
        public int RateLimitThreshold { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RateLimitRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RateLimitRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RateLimitRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedirectType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RedirectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedirectType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RedirectType Found { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType Moved { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType PermanentRedirect { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RedirectType TemporaryRedirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RedirectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RedirectType left, Azure.ResourceManager.Cdn.Models.RedirectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RedirectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RedirectType left, Azure.ResourceManager.Cdn.Models.RedirectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteAddressMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RemoteAddressMatchCondition(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator remoteAddressOperator) { }
        public RemoteAddressMatchCondition(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator remoteAddressOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RemoteAddressOperator RemoteAddressOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteAddressMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteAddressMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType RemoteAddressCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.RemoteAddressMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteAddressOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RemoteAddressOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteAddressOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RemoteAddressOperator IPMatch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator left, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RemoteAddressOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RemoteAddressOperator left, Azure.ResourceManager.Cdn.Models.RemoteAddressOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestBodyMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestBodyMatchCondition(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestBodyOperator requestBodyOperator) { }
        public RequestBodyMatchCondition(Azure.ResourceManager.Cdn.Models.RequestBodyOperator requestBodyOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestBodyOperator RequestBodyOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestBodyMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestBodyMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestBodyMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType RequestBodyCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestBodyMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestBodyOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestBodyOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestBodyOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestBodyOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestBodyOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestBodyOperator left, Azure.ResourceManager.Cdn.Models.RequestBodyOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestBodyOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestBodyOperator left, Azure.ResourceManager.Cdn.Models.RequestBodyOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestHeaderMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestHeaderMatchCondition(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator requestHeaderOperator) { }
        public RequestHeaderMatchCondition(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator requestHeaderOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestHeaderOperator RequestHeaderOperator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestHeaderMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestHeaderMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType RequestHeaderCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestHeaderMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestHeaderOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestHeaderOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestHeaderOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestHeaderOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator left, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestHeaderOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestHeaderOperator left, Azure.ResourceManager.Cdn.Models.RequestHeaderOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestMethodMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestMethodMatchCondition(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestMethodOperator requestMethodOperator) { }
        public RequestMethodMatchCondition(Azure.ResourceManager.Cdn.Models.RequestMethodOperator requestMethodOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestMethodOperator RequestMethodOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestMethodMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Delete { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Get { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Head { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Options { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Post { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Put { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType RequestMethodCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestMethodMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestMethodOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestMethodOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestMethodOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestMethodOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestMethodOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestMethodOperator left, Azure.ResourceManager.Cdn.Models.RequestMethodOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestMethodOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestMethodOperator left, Azure.ResourceManager.Cdn.Models.RequestMethodOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestSchemeMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestSchemeMatchCondition(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator requestSchemeOperator) { }
        public RequestSchemeMatchCondition(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator requestSchemeOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestSchemeOperator RequestSchemeOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeMatchConditionMatchValue : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeMatchConditionMatchValue(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue Http { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionMatchValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType RequestSchemeCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestSchemeMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSchemeOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestSchemeOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSchemeOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestSchemeOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator left, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestSchemeOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestSchemeOperator left, Azure.ResourceManager.Cdn.Models.RequestSchemeOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestUriMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestUriMatchCondition(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.RequestUriOperator requestUriOperator) { }
        public RequestUriMatchCondition(Azure.ResourceManager.Cdn.Models.RequestUriOperator requestUriOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RequestUriOperator RequestUriOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RequestUriMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestUriMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestUriMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType RequestUriCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType left, Azure.ResourceManager.Cdn.Models.RequestUriMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestUriOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.RequestUriOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestUriOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RequestUriOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RequestUriOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RequestUriOperator left, Azure.ResourceManager.Cdn.Models.RequestUriOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RequestUriOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RequestUriOperator left, Azure.ResourceManager.Cdn.Models.RequestUriOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcesResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>
    {
        internal ResourcesResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem> CustomDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesResponseCustomDomainsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>
    {
        internal ResourcesResponseCustomDomainsItem() { }
        public string EndpointId { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseCustomDomainsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesResponseEndpointsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>
    {
        internal ResourcesResponseEndpointsItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem> CustomDomains { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesResponseEndpointsPropertiesItemsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>
    {
        internal ResourcesResponseEndpointsPropertiesItemsItem() { }
        public string EndpointId { get { throw null; } }
        public bool? History { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResourcesResponseEndpointsPropertiesItemsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResponseBasedDetectedErrorType
    {
        None = 0,
        TcpErrorsOnly = 1,
        TcpAndHttpErrors = 2,
    }
    public partial class ResponseBasedOriginErrorDetectionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>
    {
        public ResponseBasedOriginErrorDetectionSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.HttpErrorRange> HttpErrorRanges { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ResponseBasedDetectedErrorType? ResponseBasedDetectedErrorType { get { throw null; } set { } }
        public int? ResponseBasedFailoverThresholdPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ResponseBasedOriginErrorDetectionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteCacheCompressionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>
    {
        public RouteCacheCompressionSettings() { }
        public System.Collections.Generic.IList<string> ContentTypesToCompress { get { throw null; } }
        public bool? IsCompressionEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteCacheCompressionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteConfigurationOverrideActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>
    {
        public RouteConfigurationOverrideActionProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public RouteConfigurationOverrideActionProperties(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType actionType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.CacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.OriginGroupOverride OriginGroupOverride { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteConfigurationOverrideActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteConfigurationOverrideActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType RouteConfigurationOverrideAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType left, Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType left, Azure.ResourceManager.Cdn.Models.RouteConfigurationOverrideActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleCacheBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleCacheBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleCacheBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior HonorOrigin { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior OverrideAlways { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleCacheBehavior OverrideIfOriginMissing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior left, Azure.ResourceManager.Cdn.Models.RuleCacheBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleCacheBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleCacheBehavior left, Azure.ResourceManager.Cdn.Models.RuleCacheBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleIsCompressionEnabled : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleIsCompressionEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled left, Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled left, Azure.ResourceManager.Cdn.Models.RuleIsCompressionEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleQueryStringCachingBehavior : System.IEquatable<Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleQueryStringCachingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IgnoreQueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IgnoreSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior IncludeSpecifiedQueryStrings { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior UseQueryString { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior left, Azure.ResourceManager.Cdn.Models.RuleQueryStringCachingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScrubbingRuleEntryMatchOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScrubbingRuleEntryMatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator EqualsAny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScrubbingRuleEntryMatchVariable : System.IEquatable<Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScrubbingRuleEntryMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable QueryStringArgNames { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable RequestIPAddress { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable RequestUri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScrubbingRuleEntryState : System.IEquatable<Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScrubbingRuleEntryState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState left, Azure.ResourceManager.Cdn.Models.ScrubbingRuleEntryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SecretType AzureFirstPartyManagedCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SecretType CustomerCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SecretType ManagedCertificate { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SecretType UriSigningKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SecretType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SecretType left, Azure.ResourceManager.Cdn.Models.SecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SecretType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SecretType left, Azure.ResourceManager.Cdn.Models.SecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecureDeliveryProtocolType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecureDeliveryProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType IPBased { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType ServerNameIndication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType left, Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType left, Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class SecurityPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>
    {
        protected SecurityPolicyProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityPolicyWebApplicationFirewall : Azure.ResourceManager.Cdn.Models.SecurityPolicyProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>
    {
        public SecurityPolicyWebApplicationFirewall() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation> Associations { get { throw null; } }
        public Azure.Core.ResourceIdentifier WafPolicyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityPolicyWebApplicationFirewallAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>
    {
        public SecurityPolicyWebApplicationFirewallAssociation() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.FrontDoorActivatedResourceInfo> Domains { get { throw null; } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SecurityPolicyWebApplicationFirewallAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerPortMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ServerPortMatchCondition(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.ServerPortOperator serverPortOperator) { }
        public ServerPortMatchCondition(Azure.ResourceManager.Cdn.Models.ServerPortOperator serverPortOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.ServerPortOperator ServerPortOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ServerPortMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPortMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPortMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType ServerPortCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType left, Azure.ResourceManager.Cdn.Models.ServerPortMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerPortOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.ServerPortOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerPortOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ServerPortOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ServerPortOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ServerPortOperator left, Azure.ResourceManager.Cdn.Models.ServerPortOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ServerPortOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ServerPortOperator left, Azure.ResourceManager.Cdn.Models.ServerPortOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>
    {
        public SharedPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkId { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SharedPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class SocketAddressMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public SocketAddressMatchCondition(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.SocketAddressOperator socketAddressOperator) { }
        public SocketAddressMatchCondition(Azure.ResourceManager.Cdn.Models.SocketAddressOperator socketAddressOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.SocketAddressOperator SocketAddressOperator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SocketAddressMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SocketAddressMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SocketAddressMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType SocketAddressCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType left, Azure.ResourceManager.Cdn.Models.SocketAddressMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SocketAddressOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.SocketAddressOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SocketAddressOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.SocketAddressOperator IPMatch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SocketAddressOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SocketAddressOperator left, Azure.ResourceManager.Cdn.Models.SocketAddressOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SocketAddressOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SocketAddressOperator left, Azure.ResourceManager.Cdn.Models.SocketAddressOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslProtocolMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslProtocolMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType SslProtocolCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType left, Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType left, Azure.ResourceManager.Cdn.Models.SslProtocolMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslProtocolOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.SslProtocolOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslProtocolOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.SslProtocolOperator Equal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.SslProtocolOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.SslProtocolOperator left, Azure.ResourceManager.Cdn.Models.SslProtocolOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.SslProtocolOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.SslProtocolOperator left, Azure.ResourceManager.Cdn.Models.SslProtocolOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsoUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SsoUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SsoUri>
    {
        internal SsoUri() { }
        public System.Uri AvailableSsoUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SsoUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SsoUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SsoUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SsoUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SsoUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SsoUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SsoUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedOptimizationTypesListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>
    {
        internal SupportedOptimizationTypesListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.OptimizationType> SupportedOptimizationTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.SupportedOptimizationTypesListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformType : System.IEquatable<Azure.ResourceManager.Cdn.Models.TransformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.TransformType Lowercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType Trim { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType Uppercase { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType UriDecode { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.TransformType UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.TransformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.TransformType left, Azure.ResourceManager.Cdn.Models.TransformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.TransformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.TransformType left, Azure.ResourceManager.Cdn.Models.TransformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriFileExtensionMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriFileExtensionMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator uriFileExtensionOperator) { }
        public UriFileExtensionMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator uriFileExtensionOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator UriFileExtensionOperator { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileExtensionMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileExtensionMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType UriFileExtensionMatchCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileExtensionMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileExtensionOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileExtensionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator left, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator left, Azure.ResourceManager.Cdn.Models.UriFileExtensionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriFileNameMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriFileNameMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriFileNameOperator uriFileNameOperator) { }
        public UriFileNameMatchCondition(Azure.ResourceManager.Cdn.Models.UriFileNameOperator uriFileNameOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.UriFileNameOperator UriFileNameOperator { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriFileNameMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileNameMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileNameMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType UriFilenameCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriFileNameMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriFileNameOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriFileNameOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriFileNameOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriFileNameOperator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriFileNameOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriFileNameOperator left, Azure.ResourceManager.Cdn.Models.UriFileNameOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriFileNameOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriFileNameOperator left, Azure.ResourceManager.Cdn.Models.UriFileNameOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriPathMatchCondition : Azure.ResourceManager.Cdn.Models.DeliveryRuleConditionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriPathMatchCondition(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType conditionType, Azure.ResourceManager.Cdn.Models.UriPathOperator uriPathOperator) { }
        public UriPathMatchCondition(Azure.ResourceManager.Cdn.Models.UriPathOperator uriPathOperator) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType ConditionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValues { get { throw null; } }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.PreTransformCategory> Transforms { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.UriPathOperator UriPathOperator { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriPathMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriPathMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriPathMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriPathMatchConditionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriPathMatchConditionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType UriPathMatchCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType left, Azure.ResourceManager.Cdn.Models.UriPathMatchConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriPathOperator : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriPathOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriPathOperator(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Any { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator RegEx { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.UriPathOperator Wildcard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriPathOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriPathOperator left, Azure.ResourceManager.Cdn.Models.UriPathOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriPathOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriPathOperator left, Azure.ResourceManager.Cdn.Models.UriPathOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriRedirectAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>
    {
        public UriRedirectAction(Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRedirectAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRedirectAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriRedirectActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>
    {
        public UriRedirectActionProperties(Azure.ResourceManager.Cdn.Models.RedirectType redirectType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriRedirectActionProperties(Azure.ResourceManager.Cdn.Models.UriRedirectActionType actionType, Azure.ResourceManager.Cdn.Models.RedirectType redirectType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriRedirectActionType ActionType { get { throw null; } set { } }
        public string CustomFragment { get { throw null; } set { } }
        public string CustomHostname { get { throw null; } set { } }
        public string CustomPath { get { throw null; } set { } }
        public string CustomQueryString { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.DestinationProtocol? DestinationProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.RedirectType RedirectType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRedirectActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriRedirectActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriRedirectActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriRedirectActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriRedirectActionType UriRedirectAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriRedirectActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriRedirectActionType left, Azure.ResourceManager.Cdn.Models.UriRedirectActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriRedirectActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriRedirectActionType left, Azure.ResourceManager.Cdn.Models.UriRedirectActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriRewriteAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>
    {
        public UriRewriteAction(Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRewriteAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRewriteAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriRewriteActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriRewriteActionProperties(Azure.ResourceManager.Cdn.Models.UriRewriteActionType actionType, string sourcePattern, string destination) { }
        public UriRewriteActionProperties(string sourcePattern, string destination) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriRewriteActionType ActionType { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public bool? PreserveUnmatchedPath { get { throw null; } set { } }
        public string SourcePattern { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriRewriteActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriRewriteActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriRewriteActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriRewriteActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriRewriteActionType UriRewriteAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriRewriteActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriRewriteActionType left, Azure.ResourceManager.Cdn.Models.UriRewriteActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriRewriteActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriRewriteActionType left, Azure.ResourceManager.Cdn.Models.UriRewriteActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriSigningAction : Azure.ResourceManager.Cdn.Models.DeliveryRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>
    {
        public UriSigningAction(Azure.ResourceManager.Cdn.Models.UriSigningActionProperties properties) { }
        public Azure.ResourceManager.Cdn.Models.UriSigningActionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriSigningActionProperties : Azure.ResourceManager.Cdn.Models.DeliveryRuleActionProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>
    {
        public UriSigningActionProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriSigningActionProperties(Azure.ResourceManager.Cdn.Models.UriSigningActionType actionType) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Cdn.Models.UriSigningActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm? Algorithm { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier> ParameterNameOverride { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriSigningActionType : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriSigningActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriSigningActionType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriSigningActionType UriSigningAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriSigningActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriSigningActionType left, Azure.ResourceManager.Cdn.Models.UriSigningActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriSigningActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriSigningActionType left, Azure.ResourceManager.Cdn.Models.UriSigningActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UriSigningAlgorithm : System.IEquatable<Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UriSigningAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm Sha256 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm left, Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm left, Azure.ResourceManager.Cdn.Models.UriSigningAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UriSigningKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>
    {
        public UriSigningKey(string keyId, Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey keySourceParameters) { }
        public string KeyId { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.KeyVaultSigningKey KeySourceParameters { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriSigningKeyProperties : Azure.ResourceManager.Cdn.Models.FrontDoorSecretProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public UriSigningKeyProperties(string keyId, Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) { }
        public UriSigningKeyProperties(string keyId, Azure.ResourceManager.Resources.Models.WritableSubResource secretSource, string secretVersion) { }
        public string KeyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningKeyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriSigningParamIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>
    {
        public UriSigningParamIdentifier(Azure.ResourceManager.Cdn.Models.ParamIndicator paramIndicator, string paramName) { }
        public Azure.ResourceManager.Cdn.Models.ParamIndicator ParamIndicator { get { throw null; } set { } }
        public string ParamName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UriSigningParamIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserManagedHttpsContent : Azure.ResourceManager.Cdn.Models.CustomDomainHttpsContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>
    {
        public UserManagedHttpsContent(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType protocolType, Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource certificateSourceParameters) : base (default(Azure.ResourceManager.Cdn.Models.SecureDeliveryProtocolType)) { }
        public Azure.ResourceManager.Cdn.Models.KeyVaultCertificateSource CertificateSourceParameters { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.UserManagedHttpsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateCustomDomainContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>
    {
        public ValidateCustomDomainContent(string hostName) { }
        public string HostName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateCustomDomainResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>
    {
        internal ValidateCustomDomainResult() { }
        public bool? IsCustomDomainValid { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateCustomDomainResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateProbeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>
    {
        public ValidateProbeContent(System.Uri probeUri) { }
        public System.Uri ProbeUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateProbeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateProbeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateProbeResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>
    {
        internal ValidateProbeResult() { }
        public string ErrorCode { get { throw null; } }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateProbeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateProbeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateProbeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateSecretContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>
    {
        public ValidateSecretContent(Azure.ResourceManager.Cdn.Models.SecretType secretType, Azure.ResourceManager.Resources.Models.WritableSubResource secretSource) { }
        public Azure.Core.ResourceIdentifier SecretSourceId { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.SecretType SecretType { get { throw null; } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateSecretContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateSecretContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateSecretResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>
    {
        internal ValidateSecretResult() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.ValidationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateSecretResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.ValidateSecretResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.ValidateSecretResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationStatus : System.IEquatable<Azure.ResourceManager.Cdn.Models.ValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.ValidationStatus AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ValidationStatus CertificateExpired { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.ValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.ValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.ValidationStatus left, Azure.ResourceManager.Cdn.Models.ValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.ValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.ValidationStatus left, Azure.ResourceManager.Cdn.Models.ValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafAction : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafAction(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Block { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Log { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafAction Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafAction left, Azure.ResourceManager.Cdn.Models.WafAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafAction left, Azure.ResourceManager.Cdn.Models.WafAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafGranularity left, Azure.ResourceManager.Cdn.Models.WafGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafGranularity left, Azure.ResourceManager.Cdn.Models.WafGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMatchVariable : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable Cookies { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable PostArgs { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable QueryString { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RemoteAddr { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestBody { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestHeader { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestMethod { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable RequestUri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMatchVariable SocketAddr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMatchVariable left, Azure.ResourceManager.Cdn.Models.WafMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMatchVariable left, Azure.ResourceManager.Cdn.Models.WafMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetric : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetric(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetric ClientRequestCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetric left, Azure.ResourceManager.Cdn.Models.WafMetric right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetric left, Azure.ResourceManager.Cdn.Models.WafMetric right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>
    {
        internal WafMetricsResponse() { }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity? Granularity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem> Series { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetricsResponseGranularity : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetricsResponseGranularity(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity P1D { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity PT1H { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity PT5M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponseSeriesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>
    {
        internal WafMetricsResponseSeriesItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.Components18OrqelSchemasWafmetricsresponsePropertiesSeriesItemsPropertiesDataItems> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem> Groups { get { throw null; } }
        public string Metric { get { throw null; } }
        public Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafMetricsResponseSeriesItemUnit : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafMetricsResponseSeriesItemUnit(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit left, Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesItemUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafMetricsResponseSeriesPropertiesItemsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>
    {
        internal WafMetricsResponseSeriesPropertiesItemsItem() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafMetricsResponseSeriesPropertiesItemsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WafPolicyManagedRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>
    {
        public WafPolicyManagedRuleSet(string ruleSetType, string ruleSetVersion) { }
        public int? AnomalyScore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Cdn.Models.ManagedRuleGroupOverrideSetting> RuleGroupOverrides { get { throw null; } }
        public string RuleSetType { get { throw null; } set { } }
        public string RuleSetVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicyManagedRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WafPolicySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>
    {
        public WafPolicySettings() { }
        public System.BinaryData DefaultCustomBlockResponseBody { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicySettingsDefaultCustomBlockResponseStatusCode? DefaultCustomBlockResponseStatusCode { get { throw null; } set { } }
        public System.Uri DefaultRedirectUri { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicyEnabledState? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.Cdn.Models.PolicyMode? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafPolicySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafPolicySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafPolicySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRankingGroupBy : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRankingGroupBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRankingGroupBy(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingGroupBy CustomDomain { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingGroupBy HttpStatusCode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy left, Azure.ResourceManager.Cdn.Models.WafRankingGroupBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRankingGroupBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRankingGroupBy left, Azure.ResourceManager.Cdn.Models.WafRankingGroupBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WafRankingsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>
    {
        internal WafRankingsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem> Data { get { throw null; } }
        public System.DateTimeOffset? DateTimeBegin { get { throw null; } }
        public System.DateTimeOffset? DateTimeEnd { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafRankingsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafRankingsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WafRankingsResponseDataItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>
    {
        internal WafRankingsResponseDataItem() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Cdn.Models.ComponentsKpo1PjSchemasWafrankingsresponsePropertiesDataItemsPropertiesMetricsItems> Metrics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Cdn.Models.WafRankingsResponseDataItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRankingType : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRankingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRankingType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType Action { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType ClientIP { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType CountryOrRegion { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleGroup { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleId { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType RuleType { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType Uri { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRankingType UserAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRankingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRankingType left, Azure.ResourceManager.Cdn.Models.WafRankingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRankingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRankingType left, Azure.ResourceManager.Cdn.Models.WafRankingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WafRuleType : System.IEquatable<Azure.ResourceManager.Cdn.Models.WafRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WafRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Bot { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Custom { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WafRuleType Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WafRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WafRuleType left, Azure.ResourceManager.Cdn.Models.WafRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WafRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WafRuleType left, Azure.ResourceManager.Cdn.Models.WafRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationFirewallPolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationFirewallPolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState left, Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState left, Azure.ResourceManager.Cdn.Models.WebApplicationFirewallPolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
