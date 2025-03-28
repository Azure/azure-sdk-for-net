namespace Azure.ResourceManager.WeightsAndBiases
{
    public partial class InstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceResource() { }
        public virtual Azure.ResourceManager.WeightsAndBiases.InstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instancename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WeightsAndBiases.InstanceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.InstanceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> Update(Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> UpdateAsync(Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WeightsAndBiases.InstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WeightsAndBiases.InstanceResource>, System.Collections.IEnumerable
    {
        protected InstanceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WeightsAndBiases.InstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instancename, Azure.ResourceManager.WeightsAndBiases.InstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instancename, Azure.ResourceManager.WeightsAndBiases.InstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> Get(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> GetAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetIfExists(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> GetIfExistsAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WeightsAndBiases.InstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WeightsAndBiases.InstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WeightsAndBiases.InstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WeightsAndBiases.InstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>
    {
        public InstanceResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.InstanceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.InstanceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.InstanceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WeightsAndBiasesExtensions
    {
        public static Azure.ResourceManager.WeightsAndBiases.InstanceResource GetInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> GetInstanceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.InstanceResourceCollection GetInstanceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WeightsAndBiases.Mocking
{
    public partial class MockableWeightsAndBiasesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesArmClient() { }
        public virtual Azure.ResourceManager.WeightsAndBiases.InstanceResource GetInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWeightsAndBiasesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResource(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WeightsAndBiases.InstanceResource>> GetInstanceResourceAsync(string instancename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WeightsAndBiases.InstanceResourceCollection GetInstanceResources() { throw null; }
    }
    public partial class MockableWeightsAndBiasesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWeightsAndBiasesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WeightsAndBiases.InstanceResource> GetInstanceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WeightsAndBiases.Models
{
    public static partial class ArmWeightsAndBiasesModelFactory
    {
        public static Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties InstanceProperties(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.WeightsAndBiases.Models.UserDetails user = null, Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState?), Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties partnerProperties = null, Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.InstanceResourceData InstanceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails offerDetails = null) { throw null; }
    }
    public partial class InstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>
    {
        public InstanceProperties(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails marketplace, Azure.ResourceManager.WeightsAndBiases.Models.UserDetails user) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>
    {
        public InstanceResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.InstanceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.WeightsAndBiases.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>
    {
        public PartnerProperties(Azure.ResourceManager.WeightsAndBiases.Models.Region region, string subdomain) { }
        public Azure.ResourceManager.WeightsAndBiases.Models.Region Region { get { throw null; } set { } }
        public string Subdomain { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.PartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Region : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.Region>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Region(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Centralus { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Eastus { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Japaneast { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Koreacentral { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Westeurope { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.Region Westus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.Region other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.Region left, Azure.ResourceManager.WeightsAndBiases.Models.Region right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.Region (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.Region left, Azure.ResourceManager.WeightsAndBiases.Models.Region right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState left, Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState left, Azure.ResourceManager.WeightsAndBiases.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>
    {
        public SingleSignOnPropertiesV2(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState left, Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState left, Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnType : System.IEquatable<Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType left, Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType left, Azure.ResourceManager.WeightsAndBiases.Models.SingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WeightsAndBiases.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WeightsAndBiases.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
