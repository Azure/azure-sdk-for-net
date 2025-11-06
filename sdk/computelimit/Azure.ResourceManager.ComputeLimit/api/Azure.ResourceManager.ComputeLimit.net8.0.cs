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
        public static Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> GetGuestSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> GetGuestSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource GetGuestSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.GuestSubscriptionCollection GetGuestSubscriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource> GetSharedLimit(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> GetSharedLimitAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.SharedLimitResource GetSharedLimitResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.SharedLimitCollection GetSharedLimits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class GuestSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>, System.Collections.IEnumerable
    {
        protected GuestSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestSubscriptionId, Azure.ResourceManager.ComputeLimit.GuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestSubscriptionId, Azure.ResourceManager.ComputeLimit.GuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> Get(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> GetAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> GetIfExists(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> GetIfExistsAsync(string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>
    {
        public GuestSubscriptionData() { }
        public Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState? GuestSubscriptionProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.GuestSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.GuestSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestSubscriptionResource() { }
        public virtual Azure.ResourceManager.ComputeLimit.GuestSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string guestSubscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeLimit.GuestSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.GuestSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.GuestSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.GuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.GuestSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedLimitCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.SharedLimitResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.SharedLimitResource>, System.Collections.IEnumerable
    {
        protected SharedLimitCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.SharedLimitResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeLimit.SharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.ComputeLimit.SharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeLimit.SharedLimitResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeLimit.SharedLimitResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.SharedLimitResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeLimit.SharedLimitResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeLimit.SharedLimitResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeLimit.SharedLimitResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeLimit.SharedLimitResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedLimitData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>
    {
        public SharedLimitData() { }
        public Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.SharedLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.SharedLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedLimitResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedLimitResource() { }
        public virtual Azure.ResourceManager.ComputeLimit.SharedLimitData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeLimit.SharedLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.SharedLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.SharedLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.SharedLimitResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.SharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeLimit.SharedLimitData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeLimit.Mocking
{
    public partial class MockableComputeLimitArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeLimitArmClient() { }
        public virtual Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource GetGuestSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.SharedLimitResource GetSharedLimitResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeLimitSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeLimitSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource> GetGuestSubscription(Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.GuestSubscriptionResource>> GetGuestSubscriptionAsync(Azure.Core.AzureLocation location, string guestSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.GuestSubscriptionCollection GetGuestSubscriptions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource> GetSharedLimit(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeLimit.SharedLimitResource>> GetSharedLimitAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeLimit.SharedLimitCollection GetSharedLimits(Azure.Core.AzureLocation location) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeLimit.Models
{
    public static partial class ArmComputeLimitModelFactory
    {
        public static Azure.ResourceManager.ComputeLimit.GuestSubscriptionData GuestSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState? guestSubscriptionProvisioningState = default(Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.LimitName LimitName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.SharedLimitData SharedLimitData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties SharedLimitProperties(Azure.ResourceManager.ComputeLimit.Models.LimitName resourceName = null, int? limit = default(int?), string unit = null, Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState?)) { throw null; }
    }
    public partial class LimitName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>
    {
        internal LimitName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.LimitName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.LimitName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.LimitName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState left, Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState left, Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedLimitProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>
    {
        public SharedLimitProperties() { }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.ComputeLimit.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeLimit.Models.LimitName ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeLimit.Models.SharedLimitProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
