namespace Azure.ResourceManager.MongoDBAtlas
{
    public partial class AzureResourceManagerMongoDBAtlasContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMongoDBAtlasContext() { }
        public static Azure.ResourceManager.MongoDBAtlas.AzureResourceManagerMongoDBAtlasContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MongoDBAtlasExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> GetMongoDBAtlasOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource GetMongoDBAtlasOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationCollection GetMongoDBAtlasOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoDBAtlasOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>, System.Collections.IEnumerable
    {
        protected MongoDBAtlasOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoDBAtlasOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>
    {
        public MongoDBAtlasOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoDBAtlasOrganizationResource() { }
        public virtual Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoDBAtlas.Mocking
{
    public partial class MockableMongoDBAtlasArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoDBAtlasArmClient() { }
        public virtual Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource GetMongoDBAtlasOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMongoDBAtlasResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoDBAtlasResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource>> GetMongoDBAtlasOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationCollection GetMongoDBAtlasOrganizations() { throw null; }
    }
    public partial class MockableMongoDBAtlasSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoDBAtlasSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationResource> GetMongoDBAtlasOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoDBAtlas.Models
{
    public static partial class ArmMongoDBAtlasModelFactory
    {
        public static Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails MongoDBAtlasMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.MongoDBAtlasOrganizationData MongoDBAtlasOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties MongoDBAtlasOrganizationProperties(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails marketplace = null, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails user = null, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState? provisioningState = default(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState?), Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties partnerProperties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBAtlasMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>
    {
        public MongoDBAtlasMarketplaceDetails(string subscriptionId, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails offerDetails) { }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>
    {
        public MongoDBAtlasOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>
    {
        public MongoDBAtlasOrganizationPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>
    {
        public MongoDBAtlasOrganizationProperties(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails marketplace, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails user) { }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasOrganizationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>
    {
        public MongoDBAtlasOrganizationUpdateProperties() { }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasOrganizationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoDBAtlasPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>
    {
        public MongoDBAtlasPartnerProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoDBAtlasResourceProvisioningState : System.IEquatable<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoDBAtlasResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState left, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState left, Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoDBAtlasUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>
    {
        public MongoDBAtlasUserDetails(string firstName, string lastName, string emailAddress) { }
        public string CompanyName { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoDBAtlas.Models.MongoDBAtlasUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
