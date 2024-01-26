namespace Azure.ResourceManager.Confluent
{
    public static partial class ConfluentExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> CreateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>> CreateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetConfluentOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationResource GetConfluentOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationCollection GetConfluentOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfluentOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>, System.Collections.IEnumerable
    {
        protected ConfluentOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfluentOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>
    {
        public ConfluentOrganizationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail OfferDetail { get { throw null; } set { } }
        public System.Guid? OrganizationId { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? ProvisioningState { get { throw null; } }
        public System.Uri SsoUri { get { throw null; } }
        public Azure.ResourceManager.Confluent.Models.ConfluentUserDetail UserDetail { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.ConfluentOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.ConfluentOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfluentOrganizationResource() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> Update(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> UpdateAsync(Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Confluent.Mocking
{
    public partial class MockableConfluentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentArmClient() { }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationResource GetConfluentOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConfluentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> GetConfluentOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Confluent.ConfluentOrganizationCollection GetConfluentOrganizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> ValidateOrganization(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.ConfluentOrganizationResource>> ValidateOrganizationAsync(string organizationName, Azure.ResourceManager.Confluent.ConfluentOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableConfluentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfluentSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> CreateMarketplaceAgreement(Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>> CreateMarketplaceAgreementAsync(Azure.ResourceManager.Confluent.Models.ConfluentAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.ConfluentOrganizationResource> GetConfluentOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreements(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Confluent.Models.ConfluentAgreement> GetMarketplaceAgreementsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Confluent.Models
{
    public static partial class ArmConfluentModelFactory
    {
        public static Azure.ResourceManager.Confluent.Models.ConfluentAgreement ConfluentAgreement(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string product = null, string plan = null, string licenseTextLink = null, string privacyPolicyLink = null, System.DateTimeOffset? retrieveOn = default(System.DateTimeOffset?), string signature = null, bool? isAccepted = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail ConfluentOfferDetail(string publisherId = null, string id = null, string planId = null, string planName = null, string termUnit = null, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? status = default(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus?)) { throw null; }
        public static Azure.ResourceManager.Confluent.ConfluentOrganizationData ConfluentOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Confluent.Models.ConfluentProvisionState? provisioningState = default(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState?), System.Guid? organizationId = default(System.Guid?), System.Uri ssoUri = null, Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail offerDetail = null, Azure.ResourceManager.Confluent.Models.ConfluentUserDetail userDetail = null) { throw null; }
    }
    public partial class ConfluentAgreement : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>
    {
        public ConfluentAgreement() { }
        public bool? IsAccepted { get { throw null; } set { } }
        public string LicenseTextLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public string PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrieveOn { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOfferDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>
    {
        public ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit) { }
        public string Id { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus? Status { get { throw null; } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOfferDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfluentOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>
    {
        public ConfluentOrganizationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfluentProvisionState : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConfluentProvisionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfluentProvisionState(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentProvisionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState left, Azure.ResourceManager.Confluent.Models.ConfluentProvisionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConfluentProvisionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConfluentProvisionState left, Azure.ResourceManager.Confluent.Models.ConfluentProvisionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfluentSaaSOfferStatus : System.IEquatable<Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfluentSaaSOfferStatus(string value) { throw null; }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Reinstated { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Unsubscribed { get { throw null; } }
        public static Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus left, Azure.ResourceManager.Confluent.Models.ConfluentSaaSOfferStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfluentUserDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>
    {
        public ConfluentUserDetail(string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Confluent.Models.ConfluentUserDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Confluent.Models.ConfluentUserDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
