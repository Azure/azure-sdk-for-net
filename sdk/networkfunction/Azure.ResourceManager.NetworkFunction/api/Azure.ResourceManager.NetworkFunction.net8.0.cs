namespace Azure.ResourceManager.NetworkFunction
{
    public partial class AzureResourceManagerNetworkFunctionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetworkFunctionContext() { }
        public static Azure.ResourceManager.NetworkFunction.AzureResourceManagerNetworkFunctionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NetworkFunctionAzureTrafficCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionAzureTrafficCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> Get(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> GetAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetIfExists(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> GetIfExistsAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionAzureTrafficCollectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>
    {
        public NetworkFunctionAzureTrafficCollectorData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CollectorPolicies { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualHubId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFunctionAzureTrafficCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionAzureTrafficCollectorResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyCollection GetNetworkFunctionCollectorPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> GetNetworkFunctionCollectorPolicy(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> GetNetworkFunctionCollectorPolicyAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> Update(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> UpdateAsync(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionCollectorPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionCollectorPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> Get(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> GetAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> GetIfExists(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> GetIfExistsAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionCollectorPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>
    {
        public NetworkFunctionCollectorPolicyData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat> EmissionPolicies { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat IngestionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFunctionCollectorPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionCollectorPolicyResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName, string collectorPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource> Update(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource>> UpdateAsync(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkFunctionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> GetNetworkFunctionAzureTrafficCollectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource GetNetworkFunctionAzureTrafficCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorCollection GetNetworkFunctionAzureTrafficCollectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource GetNetworkFunctionCollectorPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkFunction.Mocking
{
    public partial class MockableNetworkFunctionArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionArmClient() { }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource GetNetworkFunctionAzureTrafficCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyResource GetNetworkFunctionCollectorPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkFunctionResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollector(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource>> GetNetworkFunctionAzureTrafficCollectorAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorCollection GetNetworkFunctionAzureTrafficCollectors() { throw null; }
    }
    public partial class MockableNetworkFunctionSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorResource> GetNetworkFunctionAzureTrafficCollectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkFunction.Models
{
    public static partial class ArmNetworkFunctionModelFactory
    {
        public static Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat EmissionPoliciesPropertiesFormat(Azure.ResourceManager.NetworkFunction.Models.EmissionType? emissionType = default(Azure.ResourceManager.NetworkFunction.Models.EmissionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination> emissionDestinations = null) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat IngestionPolicyPropertiesFormat(Azure.ResourceManager.NetworkFunction.Models.IngestionType? ingestionType = default(Azure.ResourceManager.NetworkFunction.Models.IngestionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat> ingestionSources = null) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.NetworkFunctionAzureTrafficCollectorData NetworkFunctionAzureTrafficCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> collectorPolicies = null, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState?), Azure.Core.ResourceIdentifier virtualHubId = null, Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.NetworkFunctionCollectorPolicyData NetworkFunctionCollectorPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat ingestionPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat> emissionPolicies = null, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState?), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.TagsObject TagsObject(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CollectorProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CollectorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState left, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState left, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmissionDestinationType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmissionDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType left, Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType left, Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmissionPoliciesPropertiesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>
    {
        public EmissionPoliciesPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination> EmissionDestinations { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.EmissionType? EmissionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmissionPolicyDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>
    {
        public EmissionPolicyDestination() { }
        public Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType? DestinationType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmissionType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.EmissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmissionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.EmissionType Ipfix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.EmissionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionPolicyPropertiesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>
    {
        public IngestionPolicyPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat> IngestionSources { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionType? IngestionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IngestionSourcesPropertiesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>
    {
        public IngestionSourcesPropertiesFormat() { }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType? SourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionSourceType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionSourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType Resource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType left, Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType left, Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.IngestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.IngestionType Ipfix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.IngestionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.TagsObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkFunction.Models.TagsObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkFunction.Models.TagsObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.TagsObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
