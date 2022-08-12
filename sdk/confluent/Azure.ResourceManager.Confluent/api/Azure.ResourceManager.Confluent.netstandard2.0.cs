namespace Azure.ResourceManager.Confluent
{
    public static partial class ConfluentExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource> CreateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource>> CreateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreementResource> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> ValidateOrganizationValidation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> ValidateOrganizationValidationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.Confluent.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> Update(Azure.ResourceManager.Confluent.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> UpdateAsync(Azure.ResourceManager.Confluent.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.OrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Confluent.Models.OfferDetail offerDetail, Azure.ResourceManager.Confluent.Models.UserDetail userDetail) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.OfferDetail OfferDetail { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ProvisionState? ProvisioningState { get { throw null; } }
        public System.Uri SsoUri { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.UserDetail UserDetail { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Confluent.Models
{
    public partial class ConfluentAgreementResource : Azure.ResourceManager.Models.ResourceData
    {
        public ConfluentAgreementResource() { }
        public bool? Accepted { get { throw null; } set { } }
        public string LicenseTextLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public string PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrieveDatetime { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
    }
    public partial class OfferDetail
    {
        public OfferDetail(string publisherId, string id, string planId, string planName, string termUnit) { }
        public string Id { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.SaaSOfferStatus? Status { get { throw null; } }
        public string TermUnit { get { throw null; } set { } }
    }
    public partial class OrganizationResourcePatch
    {
        public OrganizationResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionState : System.IEquatable<Azure.ResourceManager.Confluent.Models.ProvisionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionState(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ProvisionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ProvisionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ProvisionState left, Azure.ResourceManager.Confluent.Models.ProvisionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ProvisionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ProvisionState left, Azure.ResourceManager.Confluent.Models.ProvisionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SaaSOfferStatus : System.IEquatable<Azure.ResourceManager.Confluent.Models.SaaSOfferStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SaaSOfferStatus(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Reinstated { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Unsubscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.SaaSOfferStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.SaaSOfferStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.SaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.SaaSOfferStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.SaaSOfferStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.SaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.SaaSOfferStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetail
    {
        public UserDetail(string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
    }
}
