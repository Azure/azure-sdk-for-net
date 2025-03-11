namespace Azure.ResourceManager.ArizeAIObservabilityEval
{
    public static partial class ArizeAIObservabilityEvalExtensions
    {
        public static Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> Update(Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> UpdateAsync(Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ArizeAIObservabilityEval.Mocking
{
    public partial class MockableArizeAIObservabilityEvalArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalArmClient() { }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource GetOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableArizeAIObservabilityEvalResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResource(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource>> GetOrganizationResourceAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceCollection GetOrganizationResources() { throw null; }
    }
    public partial class MockableArizeAIObservabilityEvalSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResource> GetOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ArizeAIObservabilityEval.Models
{
    public static partial class ArmArizeAIObservabilityEvalModelFactory
    {
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties OrganizationProperties(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails user = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState?), string partnerDescription = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.OrganizationResourceData OrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>
    {
        public OrganizationProperties(Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails marketplace, Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails user) { }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public string PartnerDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>
    {
        public OrganizationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.OrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>
    {
        public SingleSignOnPropertiesV2(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnType : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.SingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
