namespace Azure.ResourceManager.SustainabilityServices
{
    public partial class CalculationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CalculationResource() { }
        public virtual Azure.ResourceManager.SustainabilityServices.CalculationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string calculationResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SustainabilityServices.CalculationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.CalculationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SustainabilityServices.CalculationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SustainabilityServices.CalculationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CalculationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SustainabilityServices.CalculationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SustainabilityServices.CalculationResource>, System.Collections.IEnumerable
    {
        protected CalculationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SustainabilityServices.CalculationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string calculationResourceName, Azure.ResourceManager.SustainabilityServices.CalculationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SustainabilityServices.CalculationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string calculationResourceName, Azure.ResourceManager.SustainabilityServices.CalculationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> Get(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> GetAsync(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetIfExists(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SustainabilityServices.CalculationResource>> GetIfExistsAsync(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SustainabilityServices.CalculationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SustainabilityServices.CalculationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SustainabilityServices.CalculationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SustainabilityServices.CalculationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CalculationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>
    {
        public CalculationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.CalculationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.CalculationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.CalculationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SustainabilityServicesExtensions
    {
        public static Azure.ResourceManager.SustainabilityServices.CalculationResource GetCalculationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> GetCalculationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SustainabilityServices.CalculationResourceCollection GetCalculationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SustainabilityServices.Mocking
{
    public partial class MockableSustainabilityServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSustainabilityServicesArmClient() { }
        public virtual Azure.ResourceManager.SustainabilityServices.CalculationResource GetCalculationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSustainabilityServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSustainabilityServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResource(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SustainabilityServices.CalculationResource>> GetCalculationResourceAsync(string calculationResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SustainabilityServices.CalculationResourceCollection GetCalculationResources() { throw null; }
    }
    public partial class MockableSustainabilityServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSustainabilityServicesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SustainabilityServices.CalculationResource> GetCalculationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SustainabilityServices.Models
{
    public static partial class ArmSustainabilityServicesModelFactory
    {
        public static Azure.ResourceManager.SustainabilityServices.CalculationResourceData CalculationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku sku = null) { throw null; }
        public static Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties CalculationResourceProperties(Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState?), string version = null, string tokenClaimsApplicationId = null, string ddosPlan = null, string serviceUri = null, Azure.Core.ResourceIdentifier storageProfileId = null, Azure.Core.ResourceIdentifier akvProfileId = null, Azure.Core.ResourceIdentifier appServiceProfileId = null, Azure.Core.ResourceIdentifier redisProfileId = null, Azure.Core.ResourceIdentifier monitoringProfileId = null, Azure.Core.ResourceIdentifier azureFrontDoorProfileId = null, string cachingType = null, bool? enablePublicEndpoint = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> managedOnBehalfOfMoboBrokerResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion> denyAssignmentExclusions = null) { throw null; }
    }
    public partial class CalculationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>
    {
        public CalculationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculationResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>
    {
        public CalculationResourceProperties(string tokenClaimsApplicationId) { }
        public Azure.Core.ResourceIdentifier AkvProfileId { get { throw null; } }
        public Azure.Core.ResourceIdentifier AppServiceProfileId { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureFrontDoorProfileId { get { throw null; } }
        public string CachingType { get { throw null; } set { } }
        public string DdosPlan { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion> DenyAssignmentExclusions { get { throw null; } }
        public bool? EnablePublicEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public Azure.Core.ResourceIdentifier MonitoringProfileId { get { throw null; } }
        public Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RedisProfileId { get { throw null; } }
        public string ServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageProfileId { get { throw null; } }
        public string TokenClaimsApplicationId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CalculationResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>
    {
        public CalculationResourceUpdateProperties() { }
        public string CachingType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion> DenyAssignmentExclusions { get { throw null; } }
        public bool? EnablePublicEndpoint { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.CalculationResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenyAssignmentExclusion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>
    {
        public DenyAssignmentExclusion(string id, string type) { }
        public string Id { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.DenyAssignmentExclusion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState left, Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState left, Azure.ResourceManager.SustainabilityServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SustainabilityServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>
    {
        public SustainabilityServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SustainabilityServices.Models.SustainabilityServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SustainabilityServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
}
