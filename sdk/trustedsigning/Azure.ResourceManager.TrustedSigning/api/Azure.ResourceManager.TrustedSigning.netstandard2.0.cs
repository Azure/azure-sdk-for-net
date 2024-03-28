namespace Azure.ResourceManager.TrustedSigning
{
    public partial class CertificateProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>, System.Collections.IEnumerable
    {
        protected CertificateProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrustedSigning.CertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrustedSigning.CertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>
    {
        public CertificateProfileData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.TrustedSigning.Models.Certificate> Certificates { get { throw null; } }
        public string City { get { throw null; } }
        public string CommonName { get { throw null; } }
        public string Country { get { throw null; } }
        public string EnhancedKeyUsage { get { throw null; } }
        public string IdentityValidationId { get { throw null; } set { } }
        public bool? IncludeCity { get { throw null; } set { } }
        public bool? IncludeCountry { get { throw null; } set { } }
        public bool? IncludePostalCode { get { throw null; } set { } }
        public bool? IncludeState { get { throw null; } set { } }
        public bool? IncludeStreetAddress { get { throw null; } set { } }
        public string Organization { get { throw null; } }
        public string OrganizationUnit { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.ProfileType? ProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.TrustedSigning.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string State { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus? Status { get { throw null; } }
        public string StreetAddress { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.CertificateProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.CertificateProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CertificateProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertificateProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateProfileResource() { }
        public virtual Azure.ResourceManager.TrustedSigning.CertificateProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeCertificate(Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeCertificateAsync(Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.CertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.CertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeSigningAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>, System.Collections.IEnumerable
    {
        protected CodeSigningAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.TrustedSigning.CodeSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.TrustedSigning.CodeSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeSigningAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>
    {
        public CodeSigningAccountData(Azure.Core.AzureLocation location) { }
        public System.Uri AccountUri { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? SkuName { get { throw null; } set { } }
        Azure.ResourceManager.TrustedSigning.CodeSigningAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.CodeSigningAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.CodeSigningAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeSigningAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeSigningAccountResource() { }
        public virtual Azure.ResourceManager.TrustedSigning.CodeSigningAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource> GetCertificateProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CertificateProfileResource>> GetCertificateProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.CertificateProfileCollection GetCertificateProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TrustedSigningExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult> CheckNameAvailabilityCodeSigningAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityCodeSigningAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.CertificateProfileResource GetCertificateProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> GetCodeSigningAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource GetCodeSigningAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.CodeSigningAccountCollection GetCodeSigningAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrustedSigning.Mocking
{
    public partial class MockableTrustedSigningArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningArmClient() { }
        public virtual Azure.ResourceManager.TrustedSigning.CertificateProfileResource GetCertificateProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource GetCodeSigningAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableTrustedSigningResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource>> GetCodeSigningAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.CodeSigningAccountCollection GetCodeSigningAccounts() { throw null; }
    }
    public partial class MockableTrustedSigningSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult> CheckNameAvailabilityCodeSigningAccount(Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityCodeSigningAccountAsync(Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.CodeSigningAccountResource> GetCodeSigningAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrustedSigning.Models
{
    public static partial class ArmTrustedSigningModelFactory
    {
        public static Azure.ResourceManager.TrustedSigning.Models.Certificate Certificate(string serialNumber = null, string subjectName = null, string thumbprint = null, string createdDate = null, string expiryDate = null, Azure.ResourceManager.TrustedSigning.Models.CertificateStatus? status = default(Azure.ResourceManager.TrustedSigning.Models.CertificateStatus?), System.DateTimeOffset? requestedOn = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), string reason = null, string remarks = null, Azure.ResourceManager.TrustedSigning.Models.RevocationStatus? statusRevocationStatus = default(Azure.ResourceManager.TrustedSigning.Models.RevocationStatus?), string failureReason = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.CertificateProfileData CertificateProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.TrustedSigning.Models.ProfileType? profileType = default(Azure.ResourceManager.TrustedSigning.Models.ProfileType?), string commonName = null, string organization = null, string organizationUnit = null, string streetAddress = null, bool? includeStreetAddress = default(bool?), string city = null, bool? includeCity = default(bool?), string state = null, bool? includeState = default(bool?), string country = null, bool? includeCountry = default(bool?), string postalCode = null, bool? includePostalCode = default(bool?), string enhancedKeyUsage = null, string identityValidationId = null, Azure.ResourceManager.TrustedSigning.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.TrustedSigning.Models.ProvisioningState?), Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus? status = default(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.Models.Certificate> certificates = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason? reason = default(Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.CodeSigningAccountData CodeSigningAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri accountUri = null, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? skuName = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName?), Azure.ResourceManager.TrustedSigning.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.TrustedSigning.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate RevokeCertificate(string serialNumber = null, string thumbprint = null, System.DateTimeOffset effectiveOn = default(System.DateTimeOffset), string reason = null, string remarks = null) { throw null; }
    }
    public partial class Certificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>
    {
        internal Certificate() { }
        public string CreatedDate { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string ExpiryDate { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } }
        public System.DateTimeOffset? RequestedOn { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.CertificateStatus? Status { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.RevocationStatus? StatusRevocationStatus { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.Models.Certificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.Certificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.Certificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileStatus : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus Active { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateStatus : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.CertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.CertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.CertificateStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.CertificateStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>
    {
        public CheckNameAvailability(string name) { }
        public string Name { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeSigningAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>
    {
        public CodeSigningAccountPatch() { }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.CodeSigningAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NameUnavailabilityReason : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NameUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason AccountNameInvalid { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason AlreadyExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason left, Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason left, Azure.ResourceManager.TrustedSigning.Models.NameUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileType : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.ProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileType(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.ProfileType PrivateTrust { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProfileType PrivateTrustCIPolicy { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProfileType PublicTrust { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProfileType PublicTrustTest { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProfileType VBSEnclave { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.ProfileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.ProfileType left, Azure.ResourceManager.TrustedSigning.Models.ProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.ProfileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.ProfileType left, Azure.ResourceManager.TrustedSigning.Models.ProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.ProvisioningState left, Azure.ResourceManager.TrustedSigning.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.ProvisioningState left, Azure.ResourceManager.TrustedSigning.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RevocationStatus : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.RevocationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RevocationStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.RevocationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.RevocationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.RevocationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.RevocationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.RevocationStatus left, Azure.ResourceManager.TrustedSigning.Models.RevocationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.RevocationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.RevocationStatus left, Azure.ResourceManager.TrustedSigning.Models.RevocationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RevokeCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>
    {
        public RevokeCertificate(string serialNumber, string thumbprint, System.DateTimeOffset effectiveOn, string reason) { }
        public System.DateTimeOffset EffectiveOn { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustedSigningSkuName : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustedSigningSkuName(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
}
