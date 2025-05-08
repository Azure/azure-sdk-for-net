namespace Azure.ResourceManager.WeightsAndBiases
{
    public partial class AzureResourceManagerWeightsAndBiasesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWeightsAndBiasesContext() { }
        public static Azure.ResourceManager.WeightsAndBiases.AzureResourceManagerWeightsAndBiasesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class WeightsAndBiasesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> GetWeightsAndBiasesInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource GetWeightsAndBiasesInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceCollection GetWeightsAndBiasesInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WeightsAndBiasesInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>, System.Collections.IEnumerable
    {
        protected WeightsAndBiasesInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instancename, Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instancename, Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> Get(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> GetAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetIfExists(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> GetIfExistsAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WeightsAndBiasesInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>
    {
        public WeightsAndBiasesInstanceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightsAndBiasesInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WeightsAndBiasesInstanceResource() { }
        public virtual Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instancename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> Update(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> UpdateAsync(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WeightsAndBiases.Mocking
{
    public partial class MockableWeightsAndBiasesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesArmClient() { }
        public virtual Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource GetWeightsAndBiasesInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWeightsAndBiasesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstance(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource>> GetWeightsAndBiasesInstanceAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceCollection GetWeightsAndBiasesInstances() { throw null; }
    }
    public partial class MockableWeightsAndBiasesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceResource> GetWeightsAndBiasesInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WeightsAndBiases.Models
{
    public static partial class ArmWeightsAndBiasesModelFactory
    {
        public static Azure.ResourceManager.WeightsAndBiases.WeightsAndBiasesInstanceData WeightsAndBiasesInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties WeightsAndBiasesInstanceProperties(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails marketplace = null, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails user = null, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState? provisioningState = default(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState?), Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties partnerProperties = null, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails WeightsAndBiasesMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus?), Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails offerDetails = null) { throw null; }
    }
    public partial class WeightsAndBiasesInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>
    {
        public WeightsAndBiasesInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightsAndBiasesInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>
    {
        public WeightsAndBiasesInstanceProperties(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails marketplace, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails user) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightsAndBiasesMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>
    {
        public WeightsAndBiasesMarketplaceDetails(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails offerDetails) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightsAndBiasesMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightsAndBiasesMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightsAndBiasesOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>
    {
        public WeightsAndBiasesOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightsAndBiasesPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>
    {
        public WeightsAndBiasesPartnerProperties(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion region, string subdomain) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion Region { get { throw null; } set { } }
        public string Subdomain { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightsAndBiasesProvisioningState : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightsAndBiasesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightsAndBiasesRegion : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightsAndBiasesRegion(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion CentralUS { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion EastUS { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion JapanEast { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion KoreaCentral { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion WestEurope { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion WestUS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesRegion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightsAndBiasesSingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>
    {
        public WeightsAndBiasesSingleSignOnPropertiesV2(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightsAndBiasesSingleSignOnState : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightsAndBiasesSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightsAndBiasesSingleSignOnType : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightsAndBiasesSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType left, Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightsAndBiasesUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>
    {
        public WeightsAndBiasesUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.WeightsAndBiasesUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
