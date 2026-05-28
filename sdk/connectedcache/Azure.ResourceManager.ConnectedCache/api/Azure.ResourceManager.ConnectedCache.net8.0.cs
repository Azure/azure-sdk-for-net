namespace Azure.ResourceManager.ConnectedCache
{
    public partial class AzureResourceManagerConnectedCacheContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerConnectedCacheContext() { }
        public static Azure.ResourceManager.ConnectedCache.AzureResourceManagerConnectedCacheContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ConnectedCacheExtensions
    {
        public static Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource GetEnterpriseMccCacheNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> GetEnterpriseMccCustomerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource GetEnterpriseMccCustomerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerCollection GetEnterpriseMccCustomers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.IspCacheNodeResource GetIspCacheNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> GetIspCustomerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.IspCustomerResource GetIspCustomerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.IspCustomerCollection GetIspCustomers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnterpriseMccCacheNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>, System.Collections.IEnumerable
    {
        protected EnterpriseMccCacheNodeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheNodeResourceName, Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheNodeResourceName, Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> Get(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> GetAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> GetIfExists(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> GetIfExistsAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnterpriseMccCacheNodeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>
    {
        public EnterpriseMccCacheNodeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnterpriseMccCacheNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnterpriseMccCacheNodeResource() { }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customerResourceName, string cacheNodeResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData> GetCacheNodeAutoUpdateHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>> GetCacheNodeAutoUpdateHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails> GetCacheNodeInstallDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>> GetCacheNodeInstallDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData> GetCacheNodeMccIssueDetailsHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>> GetCacheNodeMccIssueDetailsHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData> GetCacheNodeTlsCertificateHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>> GetCacheNodeTlsCertificateHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> Update(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> UpdateAsync(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EnterpriseMccCustomerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>, System.Collections.IEnumerable
    {
        protected EnterpriseMccCustomerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customerResourceName, Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customerResourceName, Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> Get(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> GetAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetIfExists(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> GetIfExistsAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnterpriseMccCustomerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>
    {
        public EnterpriseMccCustomerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnterpriseMccCustomerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnterpriseMccCustomerResource() { }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customerResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource> GetEnterpriseMccCacheNode(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource>> GetEnterpriseMccCacheNodeAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeCollection GetEnterpriseMccCacheNodes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> Update(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> UpdateAsync(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IspCacheNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>, System.Collections.IEnumerable
    {
        protected IspCacheNodeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheNodeResourceName, Azure.ResourceManager.ConnectedCache.IspCacheNodeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheNodeResourceName, Azure.ResourceManager.ConnectedCache.IspCacheNodeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> Get(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> GetAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> GetIfExists(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> GetIfExistsAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IspCacheNodeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>
    {
        public IspCacheNodeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCacheNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCacheNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IspCacheNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IspCacheNodeResource() { }
        public virtual Azure.ResourceManager.ConnectedCache.IspCacheNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customerResourceName, string cacheNodeResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails> GetBgpCidrs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>> GetBgpCidrsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData> GetCacheNodeAutoUpdateHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>> GetCacheNodeAutoUpdateHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails> GetCacheNodeInstallDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>> GetCacheNodeInstallDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData> GetCacheNodeMccIssueDetailsHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>> GetCacheNodeMccIssueDetailsHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ConnectedCache.IspCacheNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCacheNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCacheNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> Update(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> UpdateAsync(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IspCustomerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.IspCustomerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.IspCustomerResource>, System.Collections.IEnumerable
    {
        protected IspCustomerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.IspCustomerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string customerResourceName, Azure.ResourceManager.ConnectedCache.IspCustomerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string customerResourceName, Azure.ResourceManager.ConnectedCache.IspCustomerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> Get(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> GetAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIfExists(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> GetIfExistsAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedCache.IspCustomerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedCache.IspCustomerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedCache.IspCustomerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.IspCustomerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IspCustomerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>
    {
        public IspCustomerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCustomerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCustomerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IspCustomerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IspCustomerResource() { }
        public virtual Azure.ResourceManager.ConnectedCache.IspCustomerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customerResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource> GetIspCacheNode(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCacheNodeResource>> GetIspCacheNodeAsync(string cacheNodeResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.IspCacheNodeCollection GetIspCacheNodes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ConnectedCache.IspCustomerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.IspCustomerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.IspCustomerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> Update(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> UpdateAsync(Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConnectedCache.Mocking
{
    public partial class MockableConnectedCacheArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConnectedCacheArmClient() { }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeResource GetEnterpriseMccCacheNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource GetEnterpriseMccCustomerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.IspCacheNodeResource GetIspCacheNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.IspCustomerResource GetIspCustomerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConnectedCacheResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConnectedCacheResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomer(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource>> GetEnterpriseMccCustomerAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerCollection GetEnterpriseMccCustomers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomer(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedCache.IspCustomerResource>> GetIspCustomerAsync(string customerResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedCache.IspCustomerCollection GetIspCustomers() { throw null; }
    }
    public partial class MockableConnectedCacheSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConnectedCacheSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerResource> GetEnterpriseMccCustomersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedCache.IspCustomerResource> GetIspCustomersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConnectedCache.Models
{
    public static partial class ArmConnectedCacheModelFactory
    {
        public static Azure.ResourceManager.ConnectedCache.EnterpriseMccCacheNodeData EnterpriseMccCacheNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty properties = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.EnterpriseMccCustomerData EnterpriseMccCustomerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty properties = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.IspCacheNodeData IspCacheNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty properties = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.IspCustomerData IspCustomerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty properties = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties MccCacheNodeAdditionalProperties(System.Collections.Generic.IEnumerable<string> cacheNodePropertiesDetailsIssuesList = null, System.Collections.Generic.IEnumerable<string> issuesList = null, int? issuesCount = default(int?), Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate currentTlsCertificate = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo lastAutoUpdateInfo = null, string aggregatedStatusDetails = null, string aggregatedStatusText = null, int? aggregatedStatusCode = default(int?), string productVersion = null, bool? isProvisioned = default(bool?), string cacheNodeStateDetailedText = null, string cacheNodeStateShortText = null, int? cacheNodeState = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration> driveConfiguration = null, string bgpAsnToIPAddressMapping = null, System.Uri proxyUri = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired? isProxyRequired = default(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired?), Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType? osType = default(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType?), string autoUpdateVersion = null, string updateInfoDetails = null, System.DateTimeOffset? updateRequestedOn = default(System.DateTimeOffset?), string autoUpdateNextAvailableVersion = null, System.DateTimeOffset? autoUpdateNextAvailableOn = default(System.DateTimeOffset?), string autoUpdateAppliedVersion = null, string autoUpdateLastAppliedDetails = null, string autoUpdateLastAppliedState = null, System.DateTimeOffset? autoUpdateLastAppliedOn = default(System.DateTimeOffset?), System.DateTimeOffset? autoUpdateLastTriggeredOn = default(System.DateTimeOffset?), int? creationMethod = default(int?), string tlsStatus = null, string optionalProperty1 = null, string optionalProperty2 = null, string optionalProperty3 = null, string optionalProperty4 = null, string optionalProperty5 = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData MccCacheNodeAutoUpdateHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties MccCacheNodeAutoUpdateHistoryProperties(string customerId = null, string cacheNodeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo> autoUpdateHistory = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo MccCacheNodeAutoUpdateInfo(string imageUriBeforeUpdate = null, string imageUriTargeted = null, string imageUriTerminal = null, int? autoUpdateRingType = default(int?), System.DateTimeOffset? movedToTerminalStateOn = default(System.DateTimeOffset?), int? ruleRequestedWeek = default(int?), int? ruleRequestedDay = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedRegistryOn = default(System.DateTimeOffset?), string planChangeLogText = null, int? autoUpdateLastAppliedStatus = default(int?), string autoUpdateLastAppliedStatusText = null, string autoUpdateLastAppliedStatusDetailedText = null, long? planId = default(long?), string timeToGoLiveDateTime = null, string ruleRequestedMinute = null, string ruleRequestedHour = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails MccCacheNodeBgpCidrDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> mccCacheNodeBgpCidrs = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity MccCacheNodeEntity(Azure.Core.ResourceIdentifier fullyQualifiedResourceId = null, string customerId = null, string customerName = null, string ipAddress = null, string customerIndex = null, string cacheNodeId = null, string cacheNodeName = null, int? customerAsn = default(int?), bool? isEnabled = default(bool?), int? maxAllowableEgressInMbps = default(int?), float? maxAllowableProbability = default(float?), string xCid = null, bool? isEnterpriseManaged = default(bool?), string createAsyncOperationId = null, string deleteAsyncOperationId = null, string clientTenantId = null, string category = null, int? releaseVersion = default(int?), System.DateTimeOffset? lastSyncedWithAzureOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), int? synchWithAzureAttemptsCount = default(int?), string containerConfigurations = null, System.Collections.Generic.IEnumerable<string> cidrCsv = null, System.DateTimeOffset? cidrCsvLastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? bgpCidrCsvLastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? bgpLastReportedOn = default(System.DateTimeOffset?), string bgpReviewStateText = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState? bgpReviewState = default(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState?), string bgpReviewFeedback = null, int? bgpNumberOfTimesUpdated = default(int?), int? bgpNumberOfRecords = default(int?), int? bgpCidrBlocksCount = default(int?), int? bgpAddressSpace = default(int?), bool? shouldMigrate = default(bool?), int? bgpFileBytesTruncated = default(int?), int? cidrSelectionType = default(int?), bool? isFrozen = default(bool?), int? reviewState = default(int?), string reviewStateText = null, string reviewFeedback = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState? configurationState = default(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState?), string configurationStateText = null, int? addressSpace = default(int?), int? workerConnections = default(int?), System.DateTimeOffset? workerConnectionsLastUpdatedOn = default(System.DateTimeOffset?), int? containerResyncTrigger = default(int?), System.Uri imageUri = null, string fullyQualifiedDomainName = null, Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType? autoUpdateRingType = default(Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType?), int? autoUpdateRequestedWeek = default(int?), int? autoUpdateRequestedDay = default(int?), string autoUpdateRequestedTime = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails MccCacheNodeInstallDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties MccCacheNodeInstallProperties(string customerId = null, string cacheNodeId = null, string primaryAccountKey = null, string secondaryAccountKey = null, string registrationKey = null, string tlsCertificateProvisioningKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration> driveConfiguration = null, System.Uri proxyUri = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue MccCacheNodeIssue(string mccIssueType = null, string toastString = null, string detailString = null, string helpLink = null, System.DateTimeOffset? issueStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? issueEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData MccCacheNodeIssueHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties MccCacheNodeIssueHistoryProperties(string customerId = null, string cacheNodeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue> mccIssueHistory = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty MccCacheNodeProperty(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState? provisioningState = default(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState?), Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity cacheNode = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties additionalCacheNodeProperties = null, string statusCode = null, string statusText = null, string statusDetails = null, string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate MccCacheNodeTlsCertificate(string actionRequired = null, string certificateFileName = null, string thumbprint = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? notBeforeOn = default(System.DateTimeOffset?), string subject = null, string subjectAltName = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData MccCacheNodeTlsCertificateHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties MccCacheNodeTlsCertificateProperties(string customerId = null, string cacheNodeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate> tlsCertificateHistory = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties MccCustomerAdditionalProperties(float? customerPropertiesOverviewCacheEfficiency = default(float?), float? customerPropertiesOverviewAverageEgressMbps = default(float?), float? customerPropertiesOverviewAverageMissMbps = default(float?), float? customerPropertiesOverviewEgressMbpsMax = default(float?), System.DateTimeOffset? customerPropertiesOverviewEgressMbpsMaxOn = default(System.DateTimeOffset?), float? customerPropertiesOverviewMissMbpsMax = default(float?), System.DateTimeOffset? customerPropertiesOverviewMissMbpsMaxOn = default(System.DateTimeOffset?), int? customerPropertiesOverviewCacheNodesHealthyCount = default(int?), int? customerPropertiesOverviewCacheNodesUnhealthyCount = default(int?), bool? signupStatus = default(bool?), int? signupStatusCode = default(int?), string signupStatusText = null, int? signupPhaseStatusCode = default(int?), string signupPhaseStatusText = null, System.DateTimeOffset? peeringDBLastUpdatedOn = default(System.DateTimeOffset?), string customerOrgName = null, string customerEmail = null, string customerTransitAsn = null, Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState? customerTransitState = default(Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState?), string customerAsn = null, float? customerAsnEstimatedEgressPeekGbps = default(float?), string customerEntitlementSkuId = null, string customerEntitlementSkuGuid = null, string customerEntitlementSkuName = null, System.DateTimeOffset? customerEntitlementExpiryOn = default(System.DateTimeOffset?), string optionalProperty1 = null, string optionalProperty2 = null, string optionalProperty3 = null, string optionalProperty4 = null, string optionalProperty5 = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity MccCustomerEntity(Azure.Core.ResourceIdentifier fullyQualifiedResourceId = null, string customerId = null, string customerName = null, string contactEmail = null, string contactPhone = null, string contactName = null, bool? isEntitled = default(bool?), int? releaseVersion = default(int?), string createAsyncOperationId = null, string deleteAsyncOperationId = null, string clientTenantId = null, int? synchWithAzureAttemptsCount = default(int?), System.DateTimeOffset? lastSyncedWithAzureOn = default(System.DateTimeOffset?), bool? isEnterpriseManaged = default(bool?), bool? shouldMigrate = default(bool?), bool? resendSignupCode = default(bool?), bool? verifySignupCode = default(bool?), string verifySignupPhrase = null) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty MccCustomerProperty(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState? provisioningState = default(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState?), Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity customer = null, Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties additionalCustomerProperties = null, string statusCode = null, string statusText = null, string statusDetails = null, string status = null, Azure.ResponseError error = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpdateRingType : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpdateRingType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType Fast { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType Preview { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType Slow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType left, Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType left, Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheNodeDriveConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>
    {
        public CacheNodeDriveConfiguration() { }
        public int? CacheNumber { get { throw null; } set { } }
        public string NginxMapping { get { throw null; } set { } }
        public string PhysicalPath { get { throw null; } set { } }
        public int? SizeInGb { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedCachePatchContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>
    {
        public ConnectedCachePatchContent() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.ConnectedCachePatchContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedCacheProvisioningState : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedCacheProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState left, Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState left, Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomerTransitState : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomerTransitState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState CombinedTransit { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState NoTransit { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState TransitOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState left, Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState left, Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MccCacheNodeAdditionalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>
    {
        public MccCacheNodeAdditionalProperties() { }
        public int? AggregatedStatusCode { get { throw null; } }
        public string AggregatedStatusDetails { get { throw null; } }
        public string AggregatedStatusText { get { throw null; } }
        public string AutoUpdateAppliedVersion { get { throw null; } }
        public string AutoUpdateLastAppliedDetails { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateLastAppliedOn { get { throw null; } }
        public string AutoUpdateLastAppliedState { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateLastTriggeredOn { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateNextAvailableOn { get { throw null; } }
        public string AutoUpdateNextAvailableVersion { get { throw null; } }
        public string AutoUpdateVersion { get { throw null; } set { } }
        public string BgpAsnToIPAddressMapping { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CacheNodePropertiesDetailsIssuesList { get { throw null; } }
        public int? CacheNodeState { get { throw null; } }
        public string CacheNodeStateDetailedText { get { throw null; } }
        public string CacheNodeStateShortText { get { throw null; } }
        public int? CreationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate CurrentTlsCertificate { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration> DriveConfiguration { get { throw null; } }
        public bool? IsProvisioned { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired? IsProxyRequired { get { throw null; } set { } }
        public int? IssuesCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuesList { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo LastAutoUpdateInfo { get { throw null; } }
        public string OptionalProperty1 { get { throw null; } set { } }
        public string OptionalProperty2 { get { throw null; } set { } }
        public string OptionalProperty3 { get { throw null; } set { } }
        public string OptionalProperty4 { get { throw null; } set { } }
        public string OptionalProperty5 { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType? OSType { get { throw null; } set { } }
        public string ProductVersion { get { throw null; } }
        public System.Uri ProxyUri { get { throw null; } set { } }
        public string TlsStatus { get { throw null; } }
        public string UpdateInfoDetails { get { throw null; } set { } }
        public System.DateTimeOffset? UpdateRequestedOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeAutoUpdateHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>
    {
        internal MccCacheNodeAutoUpdateHistoryData() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeAutoUpdateHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>
    {
        internal MccCacheNodeAutoUpdateHistoryProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo> AutoUpdateHistory { get { throw null; } }
        public string CacheNodeId { get { throw null; } }
        public string CustomerId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeAutoUpdateInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>
    {
        internal MccCacheNodeAutoUpdateInfo() { }
        public int? AutoUpdateLastAppliedStatus { get { throw null; } }
        public string AutoUpdateLastAppliedStatusDetailedText { get { throw null; } }
        public string AutoUpdateLastAppliedStatusText { get { throw null; } }
        public int? AutoUpdateRingType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ImageUriBeforeUpdate { get { throw null; } }
        public string ImageUriTargeted { get { throw null; } }
        public string ImageUriTerminal { get { throw null; } }
        public System.DateTimeOffset? MovedToTerminalStateOn { get { throw null; } }
        public string PlanChangeLogText { get { throw null; } }
        public long? PlanId { get { throw null; } }
        public int? RuleRequestedDay { get { throw null; } }
        public string RuleRequestedHour { get { throw null; } }
        public string RuleRequestedMinute { get { throw null; } }
        public int? RuleRequestedWeek { get { throw null; } }
        public string TimeToGoLiveDateTime { get { throw null; } }
        public System.DateTimeOffset? UpdatedRegistryOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAutoUpdateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeBgpCidrDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>
    {
        internal MccCacheNodeBgpCidrDetails() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MccCacheNodeBgpCidrs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpCidrDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MccCacheNodeBgpReviewState : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MccCacheNodeBgpReviewState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState Approved { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState AttentionRequired { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState InReview { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState NotConfigured { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MccCacheNodeConfigurationState : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MccCacheNodeConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState Configured { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState NotConfiguredIP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MccCacheNodeEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>
    {
        public MccCacheNodeEntity() { }
        public int? AddressSpace { get { throw null; } }
        public int? AutoUpdateRequestedDay { get { throw null; } set { } }
        public string AutoUpdateRequestedTime { get { throw null; } set { } }
        public int? AutoUpdateRequestedWeek { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.AutoUpdateRingType? AutoUpdateRingType { get { throw null; } set { } }
        public int? BgpAddressSpace { get { throw null; } }
        public int? BgpCidrBlocksCount { get { throw null; } }
        public System.DateTimeOffset? BgpCidrCsvLastUpdatedOn { get { throw null; } }
        public int? BgpFileBytesTruncated { get { throw null; } }
        public System.DateTimeOffset? BgpLastReportedOn { get { throw null; } }
        public int? BgpNumberOfRecords { get { throw null; } }
        public int? BgpNumberOfTimesUpdated { get { throw null; } }
        public string BgpReviewFeedback { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeBgpReviewState? BgpReviewState { get { throw null; } }
        public string BgpReviewStateText { get { throw null; } }
        public string CacheNodeId { get { throw null; } set { } }
        public string CacheNodeName { get { throw null; } set { } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IList<string> CidrCsv { get { throw null; } }
        public System.DateTimeOffset? CidrCsvLastUpdatedOn { get { throw null; } }
        public int? CidrSelectionType { get { throw null; } set { } }
        public string ClientTenantId { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeConfigurationState? ConfigurationState { get { throw null; } }
        public string ConfigurationStateText { get { throw null; } }
        public string ContainerConfigurations { get { throw null; } }
        public int? ContainerResyncTrigger { get { throw null; } }
        public string CreateAsyncOperationId { get { throw null; } }
        public int? CustomerAsn { get { throw null; } set { } }
        public string CustomerId { get { throw null; } }
        public string CustomerIndex { get { throw null; } set { } }
        public string CustomerName { get { throw null; } set { } }
        public string DeleteAsyncOperationId { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FullyQualifiedResourceId { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } }
        public string IPAddress { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsEnterpriseManaged { get { throw null; } set { } }
        public bool? IsFrozen { get { throw null; } }
        public System.DateTimeOffset? LastSyncedWithAzureOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? MaxAllowableEgressInMbps { get { throw null; } set { } }
        public float? MaxAllowableProbability { get { throw null; } }
        public int? ReleaseVersion { get { throw null; } }
        public string ReviewFeedback { get { throw null; } }
        public int? ReviewState { get { throw null; } }
        public string ReviewStateText { get { throw null; } }
        public bool? ShouldMigrate { get { throw null; } set { } }
        public int? SynchWithAzureAttemptsCount { get { throw null; } }
        public int? WorkerConnections { get { throw null; } }
        public System.DateTimeOffset? WorkerConnectionsLastUpdatedOn { get { throw null; } }
        public string XCid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeInstallDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>
    {
        internal MccCacheNodeInstallDetails() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeInstallProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>
    {
        internal MccCacheNodeInstallProperties() { }
        public string CacheNodeId { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedCache.Models.CacheNodeDriveConfiguration> DriveConfiguration { get { throw null; } }
        public string PrimaryAccountKey { get { throw null; } }
        public System.Uri ProxyUri { get { throw null; } }
        public string RegistrationKey { get { throw null; } }
        public string SecondaryAccountKey { get { throw null; } }
        public string TlsCertificateProvisioningKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeInstallProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>
    {
        internal MccCacheNodeIssue() { }
        public string DetailString { get { throw null; } }
        public string HelpLink { get { throw null; } }
        public System.DateTimeOffset? IssueEndOn { get { throw null; } }
        public System.DateTimeOffset? IssueStartOn { get { throw null; } }
        public string MccIssueType { get { throw null; } }
        public string ToastString { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeIssueHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>
    {
        internal MccCacheNodeIssueHistoryData() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeIssueHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>
    {
        internal MccCacheNodeIssueHistoryProperties() { }
        public string CacheNodeId { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssue> MccIssueHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeIssueHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MccCacheNodeOSType : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MccCacheNodeOSType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType Eflow { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MccCacheNodeProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>
    {
        public MccCacheNodeProperty() { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeAdditionalProperties AdditionalCacheNodeProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeEntity CacheNode { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusCode { get { throw null; } set { } }
        public string StatusDetails { get { throw null; } set { } }
        public string StatusText { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MccCacheNodeProxyRequired : System.IEquatable<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MccCacheNodeProxyRequired(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired None { get { throw null; } }
        public static Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired left, Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeProxyRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MccCacheNodeTlsCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>
    {
        internal MccCacheNodeTlsCertificate() { }
        public string ActionRequired { get { throw null; } }
        public string CertificateFileName { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.DateTimeOffset? NotBeforeOn { get { throw null; } }
        public string Subject { get { throw null; } }
        public string SubjectAltName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeTlsCertificateHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>
    {
        internal MccCacheNodeTlsCertificateHistoryData() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCacheNodeTlsCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>
    {
        internal MccCacheNodeTlsCertificateProperties() { }
        public string CacheNodeId { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificate> TlsCertificateHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCacheNodeTlsCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCustomerAdditionalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>
    {
        public MccCustomerAdditionalProperties() { }
        public string CustomerAsn { get { throw null; } set { } }
        public float? CustomerAsnEstimatedEgressPeekGbps { get { throw null; } }
        public string CustomerEmail { get { throw null; } set { } }
        public System.DateTimeOffset? CustomerEntitlementExpiryOn { get { throw null; } set { } }
        public string CustomerEntitlementSkuGuid { get { throw null; } set { } }
        public string CustomerEntitlementSkuId { get { throw null; } set { } }
        public string CustomerEntitlementSkuName { get { throw null; } set { } }
        public string CustomerOrgName { get { throw null; } }
        public float? CustomerPropertiesOverviewAverageEgressMbps { get { throw null; } }
        public float? CustomerPropertiesOverviewAverageMissMbps { get { throw null; } }
        public float? CustomerPropertiesOverviewCacheEfficiency { get { throw null; } }
        public int? CustomerPropertiesOverviewCacheNodesHealthyCount { get { throw null; } }
        public int? CustomerPropertiesOverviewCacheNodesUnhealthyCount { get { throw null; } }
        public float? CustomerPropertiesOverviewEgressMbpsMax { get { throw null; } }
        public System.DateTimeOffset? CustomerPropertiesOverviewEgressMbpsMaxOn { get { throw null; } }
        public float? CustomerPropertiesOverviewMissMbpsMax { get { throw null; } }
        public System.DateTimeOffset? CustomerPropertiesOverviewMissMbpsMaxOn { get { throw null; } }
        public string CustomerTransitAsn { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.CustomerTransitState? CustomerTransitState { get { throw null; } set { } }
        public string OptionalProperty1 { get { throw null; } set { } }
        public string OptionalProperty2 { get { throw null; } set { } }
        public string OptionalProperty3 { get { throw null; } set { } }
        public string OptionalProperty4 { get { throw null; } set { } }
        public string OptionalProperty5 { get { throw null; } set { } }
        public System.DateTimeOffset? PeeringDBLastUpdatedOn { get { throw null; } }
        public int? SignupPhaseStatusCode { get { throw null; } }
        public string SignupPhaseStatusText { get { throw null; } }
        public bool? SignupStatus { get { throw null; } }
        public int? SignupStatusCode { get { throw null; } }
        public string SignupStatusText { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCustomerEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>
    {
        public MccCustomerEntity() { }
        public string ClientTenantId { get { throw null; } set { } }
        public string ContactEmail { get { throw null; } set { } }
        public string ContactName { get { throw null; } set { } }
        public string ContactPhone { get { throw null; } set { } }
        public string CreateAsyncOperationId { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public string CustomerName { get { throw null; } set { } }
        public string DeleteAsyncOperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FullyQualifiedResourceId { get { throw null; } set { } }
        public bool? IsEnterpriseManaged { get { throw null; } set { } }
        public bool? IsEntitled { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncedWithAzureOn { get { throw null; } }
        public int? ReleaseVersion { get { throw null; } set { } }
        public bool? ResendSignupCode { get { throw null; } set { } }
        public bool? ShouldMigrate { get { throw null; } set { } }
        public int? SynchWithAzureAttemptsCount { get { throw null; } }
        public bool? VerifySignupCode { get { throw null; } set { } }
        public string VerifySignupPhrase { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MccCustomerProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>
    {
        public MccCustomerProperty() { }
        public Azure.ResourceManager.ConnectedCache.Models.MccCustomerAdditionalProperties AdditionalCustomerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedCache.Models.MccCustomerEntity Customer { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.ConnectedCache.Models.ConnectedCacheProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public string StatusText { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConnectedCache.Models.MccCustomerProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
