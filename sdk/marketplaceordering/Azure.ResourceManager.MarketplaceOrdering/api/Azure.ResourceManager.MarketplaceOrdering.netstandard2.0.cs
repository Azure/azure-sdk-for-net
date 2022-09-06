namespace Azure.ResourceManager.MarketplaceOrdering
{
    public partial class AgreementOfferPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData>, System.Collections.IEnumerable
    {
        protected AgreementOfferPlanCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource> Get(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource>> GetAsync(string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MarketplaceOrdering.AgreementTermData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgreementOfferPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgreementOfferPlanResource() { }
        public virtual Azure.ResourceManager.MarketplaceOrdering.AgreementTermData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string publisherId, string offerId, string planId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource> Sign(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource>> SignAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgreementTermData : Azure.ResourceManager.Models.ResourceData
    {
        public AgreementTermData() { }
        public bool? Accepted { get { throw null; } set { } }
        public string LicenseTextLink { get { throw null; } set { } }
        public string MarketplaceTermsLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public string PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrieveDatetime { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
    }
    public static partial class MarketplaceOrderingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource> GetAgreementOfferPlan(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource>> GetAgreementOfferPlanAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanResource GetAgreementOfferPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.AgreementOfferPlanCollection GetAgreementOfferPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource> GetOfferTypePublisherOfferPlanAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource>> GetOfferTypePublisherOfferPlanAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource GetOfferTypePublisherOfferPlanAgreementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementCollection GetOfferTypePublisherOfferPlanAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class OfferTypePublisherOfferPlanAgreementCollection : Azure.ResourceManager.ArmCollection
    {
        protected OfferTypePublisherOfferPlanAgreementCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, Azure.ResourceManager.MarketplaceOrdering.AgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, Azure.ResourceManager.MarketplaceOrdering.AgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource> Get(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource>> GetAsync(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OfferTypePublisherOfferPlanAgreementResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferTypePublisherOfferPlanAgreementResource() { }
        public virtual Azure.ResourceManager.MarketplaceOrdering.AgreementTermData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType offerType, string publisherId, string offerId, string planId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.AgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MarketplaceOrdering.OfferTypePublisherOfferPlanAgreementResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MarketplaceOrdering.AgreementTermData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MarketplaceOrdering.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OfferType : System.IEquatable<Azure.ResourceManager.MarketplaceOrdering.Models.OfferType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OfferType(string value) { throw null; }
        public static Azure.ResourceManager.MarketplaceOrdering.Models.OfferType Virtualmachine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType left, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MarketplaceOrdering.Models.OfferType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MarketplaceOrdering.Models.OfferType left, Azure.ResourceManager.MarketplaceOrdering.Models.OfferType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
