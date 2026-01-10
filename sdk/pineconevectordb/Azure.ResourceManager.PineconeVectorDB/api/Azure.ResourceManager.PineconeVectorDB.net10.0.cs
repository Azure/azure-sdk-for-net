namespace Azure.ResourceManager.PineconeVectorDB
{
    public partial class AzureResourceManagerPineconeVectorDBContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPineconeVectorDBContext() { }
        public static Azure.ResourceManager.PineconeVectorDB.AzureResourceManagerPineconeVectorDBContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PineconeVectorDBExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> GetPineconeVectorDBOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource GetPineconeVectorDBOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationCollection GetPineconeVectorDBOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PineconeVectorDBOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>, System.Collections.IEnumerable
    {
        protected PineconeVectorDBOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PineconeVectorDBOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>
    {
        public PineconeVectorDBOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeVectorDBOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PineconeVectorDBOrganizationResource() { }
        public virtual Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> Update(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> UpdateAsync(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PineconeVectorDB.Mocking
{
    public partial class MockablePineconeVectorDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePineconeVectorDBArmClient() { }
        public virtual Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource GetPineconeVectorDBOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePineconeVectorDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePineconeVectorDBResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganization(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource>> GetPineconeVectorDBOrganizationAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationCollection GetPineconeVectorDBOrganizations() { throw null; }
    }
    public partial class MockablePineconeVectorDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePineconeVectorDBSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationResource> GetPineconeVectorDBOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PineconeVectorDB.Models
{
    public static partial class ArmPineconeVectorDBModelFactory
    {
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails PineconeVectorDBMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus?), Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.PineconeVectorDBOrganizationData PineconeVectorDBOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch PineconeVectorDBOrganizationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties PineconeVectorDBOrganizationProperties(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails marketplace = null, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails user = null, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState? provisioningState = default(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState?), string partnerDisplayName = null, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 PineconeVectorDBSingleSignOnPropertiesV2(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType type = default(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType), Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState? state = default(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState?), string enterpriseAppId = null, string uri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null) { throw null; }
    }
    public partial class PineconeVectorDBMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>
    {
        public PineconeVectorDBMarketplaceDetails(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails offerDetails) { }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PineconeVectorDBMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PineconeVectorDBMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PineconeVectorDBOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>
    {
        public PineconeVectorDBOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeVectorDBOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>
    {
        public PineconeVectorDBOrganizationPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PineconeVectorDBOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>
    {
        public PineconeVectorDBOrganizationProperties(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails marketplace, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails user) { }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBMarketplaceDetails Marketplace { get { throw null; } set { } }
        public string PartnerDisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PineconeVectorDBProvisioningState : System.IEquatable<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PineconeVectorDBProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PineconeVectorDBSingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>
    {
        public PineconeVectorDBSingleSignOnPropertiesV2(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PineconeVectorDBSingleSignOnState : System.IEquatable<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PineconeVectorDBSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PineconeVectorDBSingleSignOnType : System.IEquatable<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PineconeVectorDBSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType left, Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PineconeVectorDBUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>
    {
        public PineconeVectorDBUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PineconeVectorDB.Models.PineconeVectorDBUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
