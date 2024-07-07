namespace Azure.ResourceManager.Fabric
{
    public partial class FabricCapacityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fabric.FabricCapacityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fabric.FabricCapacityResource>, System.Collections.IEnumerable
    {
        protected FabricCapacityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fabric.FabricCapacityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityName, Azure.ResourceManager.Fabric.FabricCapacityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fabric.FabricCapacityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityName, Azure.ResourceManager.Fabric.FabricCapacityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> Get(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetAsync(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Fabric.FabricCapacityResource> GetIfExists(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetIfExistsAsync(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Fabric.FabricCapacityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Fabric.FabricCapacityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Fabric.FabricCapacityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Fabric.FabricCapacityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FabricCapacityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>
    {
        public FabricCapacityData(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.RpSku sku) { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.RpSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.ResourceState? State { get { throw null; } }
        Azure.ResourceManager.Fabric.FabricCapacityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.FabricCapacityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricCapacityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FabricCapacityResource() { }
        public virtual Azure.ResourceManager.Fabric.FabricCapacityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity> GetSkusForCapacity(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity> GetSkusForCapacityAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Fabric.FabricCapacityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.FabricCapacityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.FabricCapacityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> Update(Azure.ResourceManager.Fabric.Models.FabricCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> UpdateAsync(Azure.ResourceManager.Fabric.Models.FabricCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FabricExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult> CheckNameAvailabilityFabricCapacity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityFabricCapacityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fabric.FabricCapacityCollection GetFabricCapacities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetFabricCapacityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fabric.FabricCapacityResource GetFabricCapacityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity> GetSkusFabricCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity> GetSkusFabricCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fabric.Mocking
{
    public partial class MockableFabricArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFabricArmClient() { }
        public virtual Azure.ResourceManager.Fabric.FabricCapacityResource GetFabricCapacityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableFabricResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFabricResourceGroupResource() { }
        public virtual Azure.ResourceManager.Fabric.FabricCapacityCollection GetFabricCapacities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacity(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetFabricCapacityAsync(string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableFabricSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFabricSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult> CheckNameAvailabilityFabricCapacity(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityFabricCapacityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity> GetSkusFabricCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity> GetSkusFabricCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fabric.Models
{
    public static partial class ArmFabricModelFactory
    {
        public static Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Fabric.FabricCapacityData FabricCapacityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Fabric.Models.RpSku sku = null, Azure.ResourceManager.Fabric.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Fabric.Models.ProvisioningState?), Azure.ResourceManager.Fabric.Models.ResourceState? state = default(Azure.ResourceManager.Fabric.Models.ResourceState?), System.Collections.Generic.IEnumerable<string> administrationMembers = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity RpSkuDetailsForExistingCapacity(string resourceType = null, Azure.ResourceManager.Fabric.Models.RpSku sku = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity RpSkuDetailsForNewCapacity(string resourceType = null, string name = null, System.Collections.Generic.IEnumerable<string> locations = null) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricCapacityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>
    {
        public FabricCapacityPatch() { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.RpSkuUpdate Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Fabric.Models.FabricCapacityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Fabric.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.ProvisioningState left, Azure.ResourceManager.Fabric.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.ProvisioningState left, Azure.ResourceManager.Fabric.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.ResourceManager.Fabric.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Paused { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.ResourceState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.ResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.ResourceState left, Azure.ResourceManager.Fabric.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.ResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.ResourceState left, Azure.ResourceManager.Fabric.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RpSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSku>
    {
        public RpSku(string name, Azure.ResourceManager.Fabric.Models.RpSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.RpSkuTier Tier { get { throw null; } set { } }
        Azure.ResourceManager.Fabric.Models.RpSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.RpSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RpSkuDetailsForExistingCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>
    {
        internal RpSkuDetailsForExistingCapacity() { }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.RpSku Sku { get { throw null; } }
        Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForExistingCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RpSkuDetailsForNewCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>
    {
        internal RpSkuDetailsForNewCapacity() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuDetailsForNewCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RpSkuTier : System.IEquatable<Azure.ResourceManager.Fabric.Models.RpSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RpSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.RpSkuTier Fabric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.RpSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.RpSkuTier left, Azure.ResourceManager.Fabric.Models.RpSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.RpSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.RpSkuTier left, Azure.ResourceManager.Fabric.Models.RpSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RpSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>
    {
        public RpSkuUpdate() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.RpSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.Fabric.Models.RpSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.RpSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.RpSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
