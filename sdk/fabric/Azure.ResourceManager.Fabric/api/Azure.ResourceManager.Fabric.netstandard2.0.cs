namespace Azure.ResourceManager.Fabric
{
    public partial class AzureResourceManagerFabricContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerFabricContext() { }
        public static Azure.ResourceManager.Fabric.AzureResourceManagerFabricContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public FabricCapacityData(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.FabricCapacityProperties properties, Azure.ResourceManager.Fabric.Models.FabricSku sku) { }
        public Azure.ResourceManager.Fabric.Models.FabricCapacityProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.FabricSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity> GetSkusForCapacity(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity> GetSkusForCapacityAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fabric.FabricCapacityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fabric.Models.FabricCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Fabric.FabricCapacityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Fabric.Models.FabricCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FabricExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult> CheckFabricCapacityNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>> CheckFabricCapacityNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fabric.FabricCapacityCollection GetFabricCapacities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.FabricCapacityResource>> GetFabricCapacityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Fabric.FabricCapacityResource GetFabricCapacityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity> GetSkusFabricCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity> GetSkusFabricCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult> CheckFabricCapacityNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>> CheckFabricCapacityNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.FabricCapacityResource> GetFabricCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity> GetSkusFabricCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity> GetSkusFabricCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Fabric.Models
{
    public static partial class ArmFabricModelFactory
    {
        public static Azure.ResourceManager.Fabric.FabricCapacityData FabricCapacityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Fabric.Models.FabricCapacityProperties properties = null, Azure.ResourceManager.Fabric.Models.FabricSku sku = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricCapacityProperties FabricCapacityProperties(Azure.ResourceManager.Fabric.Models.FabricProvisioningState? provisioningState = default(Azure.ResourceManager.Fabric.Models.FabricProvisioningState?), Azure.ResourceManager.Fabric.Models.FabricResourceState? state = default(Azure.ResourceManager.Fabric.Models.FabricResourceState?), System.Collections.Generic.IEnumerable<string> administrationMembers = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult FabricNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason? reason = default(Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity FabricSkuDetailsForExistingCapacity(string resourceType = null, Azure.ResourceManager.Fabric.Models.FabricSku sku = null) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity FabricSkuDetailsForNewCapacity(string resourceType = null, string name = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null) { throw null; }
    }
    public partial class FabricCapacityAdministration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>
    {
        public FabricCapacityAdministration(System.Collections.Generic.IEnumerable<string> members) { }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricCapacityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>
    {
        public FabricCapacityPatch() { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.FabricSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricCapacityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>
    {
        public FabricCapacityProperties(Azure.ResourceManager.Fabric.Models.FabricCapacityAdministration administration) { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.FabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.FabricResourceState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricCapacityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricCapacityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>
    {
        public FabricNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>
    {
        internal FabricNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason left, Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason left, Azure.ResourceManager.Fabric.Models.FabricNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricProvisioningState : System.IEquatable<Azure.ResourceManager.Fabric.Models.FabricProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.FabricProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.FabricProvisioningState left, Azure.ResourceManager.Fabric.Models.FabricProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.FabricProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.FabricProvisioningState left, Azure.ResourceManager.Fabric.Models.FabricProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricResourceState : System.IEquatable<Azure.ResourceManager.Fabric.Models.FabricResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Failed { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Paused { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Fabric.Models.FabricResourceState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.FabricResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.FabricResourceState left, Azure.ResourceManager.Fabric.Models.FabricResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.FabricResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.FabricResourceState left, Azure.ResourceManager.Fabric.Models.FabricResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSku>
    {
        public FabricSku(string name, Azure.ResourceManager.Fabric.Models.FabricSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Fabric.Models.FabricSkuTier Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricSkuDetailsForExistingCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>
    {
        internal FabricSkuDetailsForExistingCapacity() { }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Fabric.Models.FabricSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForExistingCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricSkuDetailsForNewCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>
    {
        internal FabricSkuDetailsForNewCapacity() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Fabric.Models.FabricSkuDetailsForNewCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricSkuTier : System.IEquatable<Azure.ResourceManager.Fabric.Models.FabricSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Fabric.Models.FabricSkuTier Fabric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Fabric.Models.FabricSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Fabric.Models.FabricSkuTier left, Azure.ResourceManager.Fabric.Models.FabricSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Fabric.Models.FabricSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Fabric.Models.FabricSkuTier left, Azure.ResourceManager.Fabric.Models.FabricSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
}
