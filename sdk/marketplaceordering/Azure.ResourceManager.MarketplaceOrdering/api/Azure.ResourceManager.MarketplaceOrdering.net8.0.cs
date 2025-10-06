namespace Azure.ResourceManager.MarketplaceOrdering
{
    public partial class AzureResourceManagerMarketplaceOrderingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMarketplaceOrderingContext() { }
        public static Azure.ResourceManager.MarketplaceOrdering.AzureResourceManagerMarketplaceOrderingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MarketplaceAgreementCollection : Azure.ResourceManager.ArmCollection
    {
        protected MarketplaceAgreementCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> Get(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData> GetAllData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData> GetAllDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> GetAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> GetIfExists(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> GetIfExistsAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MarketplaceAgreementResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceAgreementResource() { }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string publisherId, string offerId, string planId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> Sign(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> SignAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceAgreementTermCollection : Azure.ResourceManager.ArmCollection
    {
        protected MarketplaceAgreementTermCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> Get(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> GetAsync(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> GetIfExists(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> GetIfExistsAsync(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MarketplaceAgreementTermData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>
    {
        public MarketplaceAgreementTermData() { }
        public bool? IsAccepted { get { throw null; } set { } }
        public System.Uri LicenseTextLink { get { throw null; } set { } }
        public System.Uri MarketplaceTermsLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public System.Uri PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrievedOn { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceAgreementTermResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceAgreementTermResource() { }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MarketplaceOrderingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> GetMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> GetMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource GetMarketplaceAgreementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementCollection GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> GetMarketplaceAgreementTerm(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> GetMarketplaceAgreementTermAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource GetMarketplaceAgreementTermResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermCollection GetMarketplaceAgreementTerms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
}
namespace Azure.ResourceManager.MarketplaceOrdering.Mocking
{
    public partial class MockableMarketplaceOrderingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMarketplaceOrderingArmClient() { }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource GetMarketplaceAgreementResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource GetMarketplaceAgreementTermResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMarketplaceOrderingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMarketplaceOrderingSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource> GetMarketplaceAgreement(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementResource>> GetMarketplaceAgreementAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementCollection GetMarketplaceAgreements() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource> GetMarketplaceAgreementTerm(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermResource>> GetMarketplaceAgreementTermAsync(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermCollection GetMarketplaceAgreementTerms() { throw null; }
    }
}
namespace Azure.ResourceManager.MarketplaceOrdering.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgreementOfferType : System.IEquatable<Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgreementOfferType(string value) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType Virtualmachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType left, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType left, Azure.ResourceManager.MarketplaceOrdering.Models.AgreementOfferType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmMarketplaceOrderingModelFactory
    {
        public static Azure.ResourceManager.MarketplaceOrdering.MarketplaceAgreementTermData MarketplaceAgreementTermData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string product = null, string plan = null, System.Uri licenseTextLink = null, System.Uri privacyPolicyLink = null, System.Uri marketplaceTermsLink = null, System.DateTimeOffset? retrievedOn = default(System.DateTimeOffset?), string signature = null, bool? isAccepted = default(bool?)) { throw null; }
    }
}
