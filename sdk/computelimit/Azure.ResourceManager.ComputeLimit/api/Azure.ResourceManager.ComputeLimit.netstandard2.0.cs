namespace Azure.ResourceManager.ComputeLimit
{
    public partial class AzureResourceManagerComputeLimitContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeLimitContext() { }
        public static Azure.ResourceManager.ComputeLimit.AzureResourceManagerComputeLimitContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ComputeLimitExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> GetComputeLimitGuestSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> GetComputeLimitGuestSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource GetComputeLimitGuestSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionCollection GetComputeLimitGuestSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> GetComputeLimitSharedLimit(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> GetComputeLimitSharedLimitAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource GetComputeLimitSharedLimitResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitCollection GetComputeLimitSharedLimits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class ComputeLimitGuestSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ComputeLimitGuestSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestSubscriptionId, Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestSubscriptionId, Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> Get(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> GetAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> GetIfExists(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> GetIfExistsAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeLimitGuestSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>
    {
        public ComputeLimitGuestSubscriptionData() { }
        public Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState? GuestSubscriptionProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeLimitGuestSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeLimitGuestSubscriptionResource() { }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string guestSubscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeLimitSharedLimitCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>, System.Collections.IEnumerable
    {
        protected ComputeLimitSharedLimitCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeLimitSharedLimitData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>
    {
        public ComputeLimitSharedLimitData() { }
        public Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeLimitSharedLimitResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeLimitSharedLimitResource() { }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeLimit.Mocking
{
    public partial class MockableComputeLimitArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeLimitArmClient() { }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource GetComputeLimitGuestSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource GetComputeLimitSharedLimitResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeLimitSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeLimitSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource> GetComputeLimitGuestSubscription(Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionResource>> GetComputeLimitGuestSubscriptionAsync(Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionCollection GetComputeLimitGuestSubscriptions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource> GetComputeLimitSharedLimit(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitResource>> GetComputeLimitSharedLimitAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitCollection GetComputeLimitSharedLimits(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeLimit.Models
{
    public static partial class ArmComputeLimitModelFactory
    {
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitGuestSubscriptionData ComputeLimitGuestSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState? guestSubscriptionProvisioningState = default(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName ComputeLimitLimitName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.ComputeLimitSharedLimitData ComputeLimitSharedLimitData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties ComputeLimitSharedLimitProperties(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName resourceName = null, int? limit = default(int?), string unit = null, Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState?)) { throw null; }
    }
    public partial class ComputeLimitLimitName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>
    {
        internal ComputeLimitLimitName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeLimitResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeLimitResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState left, Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState left, Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeLimitSharedLimitProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>
    {
        public ComputeLimitSharedLimitProperties() { }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.ComputeLimit.Models.ComputeLimitResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeLimit.Models.ComputeLimitLimitName ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.ComputeLimitSharedLimitProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
