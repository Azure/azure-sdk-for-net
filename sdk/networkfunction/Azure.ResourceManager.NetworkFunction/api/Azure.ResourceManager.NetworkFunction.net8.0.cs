namespace Azure.ResourceManager.NetworkFunction
{
    public partial class AzureResourceManagerNetworkFunctionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetworkFunctionContext() { }
        public static Azure.ResourceManager.NetworkFunction.AzureResourceManagerNetworkFunctionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureTrafficCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>, System.Collections.IEnumerable
    {
        protected AzureTrafficCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Get(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetIfExists(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetIfExistsAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureTrafficCollectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>
    {
        public AzureTrafficCollectorData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CollectorPolicies { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualHubId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureTrafficCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureTrafficCollectorResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.CollectorPolicyCollection GetCollectorPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetCollectorPolicy(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetCollectorPolicyAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Update(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> UpdateAsync(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CollectorPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>, System.Collections.IEnumerable
    {
        protected CollectorPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Get(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetIfExists(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetIfExistsAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CollectorPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>
    {
        public CollectorPolicyData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat> EmissionPolicies { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat IngestionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.CollectorPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.CollectorPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectorPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CollectorPolicyResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.CollectorPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName, string collectorPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkFunction.CollectorPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.CollectorPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.CollectorPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Update(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> UpdateAsync(Azure.ResourceManager.NetworkFunction.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkFunctionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAzureTrafficCollectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource GetAzureTrafficCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorCollection GetAzureTrafficCollectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.CollectorPolicyResource GetCollectorPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkFunction.Mocking
{
    public partial class MockableNetworkFunctionArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionArmClient() { }
        public virtual Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource GetAzureTrafficCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.CollectorPolicyResource GetCollectorPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkFunctionResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollector(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAzureTrafficCollectorAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorCollection GetAzureTrafficCollectors() { throw null; }
    }
    public partial class MockableNetworkFunctionSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkFunctionSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkFunction.Models
{
    public static partial class ArmNetworkFunctionModelFactory
    {
        public static Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData AzureTrafficCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> collectorPolicies = null, Azure.Core.ResourceIdentifier virtualHubId = null, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.CollectorPolicyData CollectorPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat ingestionPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat> emissionPolicies = null, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState?)) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState left, Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.CollectorProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType left, Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType left, Azure.ResourceManager.NetworkFunction.Models.EmissionDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmissionPoliciesPropertiesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat>
    {
        public EmissionPoliciesPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination> EmissionDestinations { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.EmissionType? EmissionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionPolicyPropertiesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat>
    {
        public IngestionPolicyPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat> IngestionSources { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionType? IngestionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType left, Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionSourceType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.TagsObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkFunction.Models.TagsObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkFunction.Models.TagsObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
