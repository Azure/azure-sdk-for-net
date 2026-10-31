namespace Azure.ResourceManager.AIGateway
{
    public static partial class AIGatewayExtensions
    {
        public static Azure.ResourceManager.AIGateway.AiGatewayResource GetAiGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource>> GetAiGatewayResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AIGateway.AiGatewayResourceCollection GetAiGatewayResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AiGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AiGatewayResource() { }
        public virtual Azure.ResourceManager.AIGateway.AiGatewayResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string aiGatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AIGateway.AiGatewayResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.AiGatewayResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AIGateway.AiGatewayResource> Update(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AIGateway.AiGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AiGatewayResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AIGateway.AiGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AIGateway.AiGatewayResource>, System.Collections.IEnumerable
    {
        protected AiGatewayResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AIGateway.AiGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aiGatewayName, Azure.ResourceManager.AIGateway.AiGatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AIGateway.AiGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aiGatewayName, Azure.ResourceManager.AIGateway.AiGatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource> Get(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource>> GetAsync(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AIGateway.AiGatewayResource> GetIfExists(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AIGateway.AiGatewayResource>> GetIfExistsAsync(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AIGateway.AiGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AIGateway.AiGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AIGateway.AiGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AIGateway.AiGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AiGatewayResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>
    {
        public AiGatewayResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.AIGateway.Models.AiGatewayProperties properties) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AIGateway.Models.AiGatewayProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AIGateway.Models.AIGatewaySku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIGateway.AiGatewayResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.AiGatewayResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.AiGatewayResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerAIGatewayContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAIGatewayContext() { }
        public static Azure.ResourceManager.AIGateway.AzureResourceManagerAIGatewayContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AIGateway.Mocking
{
    public partial class MockableAIGatewayArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAIGatewayArmClient() { }
        public virtual Azure.ResourceManager.AIGateway.AiGatewayResource GetAiGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAIGatewayResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAIGatewayResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResource(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIGateway.AiGatewayResource>> GetAiGatewayResourceAsync(string aiGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AIGateway.AiGatewayResourceCollection GetAiGatewayResources() { throw null; }
    }
    public partial class MockableAIGatewaySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAIGatewaySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AIGateway.AiGatewayResource> GetAiGatewayResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AIGateway.Models
{
    public partial class AiGatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>
    {
        public AiGatewayProperties() { }
        public Azure.Core.ResourceIdentifier BackendSubnetId { get { throw null; } set { } }
        public string FrontendDefaultHostname { get { throw null; } }
        public Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewayProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewayProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIGateway.Models.AiGatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.Models.AiGatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AiGatewayProvisioningState : System.IEquatable<Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AiGatewayProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState left, Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState left, Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AiGatewayResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>
    {
        public AiGatewayResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIGatewaySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>
    {
        public AIGatewaySku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIGateway.Models.AIGatewaySku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIGateway.Models.AIGatewaySku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIGateway.Models.AIGatewaySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.Models.AIGatewaySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AIGatewaySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AIGatewaySkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class AiGatewaySkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>
    {
        public AiGatewaySkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAIGatewayModelFactory
    {
        public static Azure.ResourceManager.AIGateway.Models.AiGatewayProperties AiGatewayProperties(Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState? provisioningState = default(Azure.ResourceManager.AIGateway.Models.AiGatewayProvisioningState?), string frontendDefaultHostname = null, Azure.Core.ResourceIdentifier backendSubnetId = null) { throw null; }
        public static Azure.ResourceManager.AIGateway.AiGatewayResourceData AiGatewayResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AIGateway.Models.AiGatewayProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.AIGateway.Models.AIGatewaySku sku = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.AIGateway.Models.AiGatewayResourcePatch AiGatewayResourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate sku = null) { throw null; }
        public static Azure.ResourceManager.AIGateway.Models.AIGatewaySku AIGatewaySku(string name = null, Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier? tier = default(Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.AIGateway.Models.AiGatewaySkuUpdate AiGatewaySkuUpdate(string name = null, Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier? tier = default(Azure.ResourceManager.AIGateway.Models.AIGatewaySkuTier?), string size = null, string family = null, int? capacity = default(int?)) { throw null; }
    }
}
