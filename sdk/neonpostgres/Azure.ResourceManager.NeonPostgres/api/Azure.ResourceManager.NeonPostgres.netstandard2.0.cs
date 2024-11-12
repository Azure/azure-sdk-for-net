namespace Azure.ResourceManager.NeonPostgres
{
    public static partial class NeonPostgresExtensions
    {
        public static Azure.ResourceManager.NeonPostgres.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.OrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.OrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.OrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Mocking
{
    public partial class MockableNeonPostgresArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresArmClient() { }
        public virtual Azure.ResourceManager.NeonPostgres.OrganizationResource GetOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNeonPostgresResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResource(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.OrganizationResource>> GetOrganizationResourceAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.OrganizationResourceCollection GetOrganizationResources() { throw null; }
    }
    public partial class MockableNeonPostgresSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.OrganizationResource> GetOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Models
{
    public static partial class ArmNeonPostgresModelFactory
    {
        public static Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties OrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.NeonPostgres.Models.UserDetails userDetails = null, Azure.ResourceManager.NeonPostgres.Models.CompanyDetails companyDetails = null, Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState?), Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties partnerOrganizationProperties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.OrganizationResourceData OrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties properties = null) { throw null; }
    }
    public partial class CompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>
    {
        public CompanyDetails() { }
        public string BusinessPhone { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public long? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.CompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.CompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.CompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.NeonPostgres.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>
    {
        public OrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails marketplaceDetails, Azure.ResourceManager.NeonPostgres.Models.UserDetails userDetails, Azure.ResourceManager.NeonPostgres.Models.CompanyDetails companyDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.CompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.UserDetails UserDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.OrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>
    {
        public PartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>
    {
        public SingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public string SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
