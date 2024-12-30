namespace Azure.ResourceManager.NeonPostgres
{
    public partial class NeonOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.IEnumerable
    {
        protected NeonOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public NeonOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonOrganizationResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NeonPostgresExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Mocking
{
    public partial class MockableNeonPostgresArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresArmClient() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNeonPostgresResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations() { throw null; }
    }
    public partial class MockableNeonPostgresSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Models
{
    public static partial class ArmNeonPostgresModelFactory
    {
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationData NeonOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties partnerOrganizationProperties = null) { throw null; }
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
    public partial class NeonCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>
    {
        public NeonCompanyDetails() { }
        public string BusinessPhone { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public long? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>
    {
        public NeonMarketplaceDetails(Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails offerDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>
    {
        public NeonOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>
    {
        public NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails UserDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>
    {
        public NeonSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public string SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonSingleSignOnState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>
    {
        public NeonUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>
    {
        public PartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
