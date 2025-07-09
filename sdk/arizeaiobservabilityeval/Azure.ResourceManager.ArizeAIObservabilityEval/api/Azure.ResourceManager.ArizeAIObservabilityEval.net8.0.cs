namespace Azure.ResourceManager.ArizeAIObservabilityEval
{
    public static partial class ArizeAIObservabilityEvalExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> GetArizeAIObservabilityEvalOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource GetArizeAIObservabilityEvalOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationCollection GetArizeAIObservabilityEvalOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>, System.Collections.IEnumerable
    {
        protected ArizeAIObservabilityEvalOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>
    {
        public ArizeAIObservabilityEvalOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArizeAIObservabilityEvalOrganizationResource() { }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> Update(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> UpdateAsync(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerArizeAIObservabilityEvalContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerArizeAIObservabilityEvalContext() { }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.AzureResourceManagerArizeAIObservabilityEvalContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.ArizeAIObservabilityEval.Mocking
{
    public partial class MockableArizeAIObservabilityEvalArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalArmClient() { }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource GetArizeAIObservabilityEvalOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableArizeAIObservabilityEvalResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganization(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource>> GetArizeAIObservabilityEvalOrganizationAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationCollection GetArizeAIObservabilityEvalOrganizations() { throw null; }
    }
    public partial class MockableArizeAIObservabilityEvalSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArizeAIObservabilityEvalSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationResource> GetArizeAIObservabilityEvalOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ArizeAIObservabilityEval.Models
{
    public partial class ArizeAIObservabilityEvalMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>
    {
        public ArizeAIObservabilityEvalMarketplaceDetails(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails offerDetails) { }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArizeAIObservabilityEvalMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArizeAIObservabilityEvalMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>
    {
        public ArizeAIObservabilityEvalOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOfferPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>
    {
        public ArizeAIObservabilityEvalOfferPartnerProperties(string description) { }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArizeAIObservabilityEvalOfferProvisioningState : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArizeAIObservabilityEvalOfferProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>
    {
        public ArizeAIObservabilityEvalOrganizationPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArizeAIObservabilityEvalOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>
    {
        public ArizeAIObservabilityEvalOrganizationProperties(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails marketplace, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails user, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferPartnerProperties partnerProperties) { }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails Marketplace { get { throw null; } set { } }
        public string PartnerDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArizeAIObservabilityEvalSingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>
    {
        public ArizeAIObservabilityEvalSingleSignOnPropertiesV2(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArizeAIObservabilityEvalSingleSignOnState : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArizeAIObservabilityEvalSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArizeAIObservabilityEvalSingleSignOnType : System.IEquatable<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArizeAIObservabilityEvalSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType left, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArizeAIObservabilityEvalUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>
    {
        public ArizeAIObservabilityEvalUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmArizeAIObservabilityEvalModelFactory
    {
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails ArizeAIObservabilityEvalMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceSubscriptionStatus?), Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.ArizeAIObservabilityEvalOrganizationData ArizeAIObservabilityEvalOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOrganizationProperties ArizeAIObservabilityEvalOrganizationProperties(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalMarketplaceDetails marketplace = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalUserDetails user = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState? provisioningState = default(Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalOfferProvisioningState?), string partnerDescription = null, Azure.ResourceManager.ArizeAIObservabilityEval.Models.ArizeAIObservabilityEvalSingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
    }
}
