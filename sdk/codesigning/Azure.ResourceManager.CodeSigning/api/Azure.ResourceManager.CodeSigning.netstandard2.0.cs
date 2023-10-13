namespace Azure.ResourceManager.CodeSigning
{
    public partial class CodeSigningAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>, System.Collections.IEnumerable
    {
        protected CodeSigningAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CodeSigning.CodeSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CodeSigning.CodeSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeSigningAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CodeSigningAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AccountUri { get { throw null; } }
        public Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CodeSigningAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeSigningAccountResource() { }
        public virtual Azure.ResourceManager.CodeSigning.CodeSigningAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> GetCodeSigningCertificateProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> GetCodeSigningCertificateProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileCollection GetCodeSigningCertificateProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> Update(Azure.ResourceManager.CodeSigning.Models.CodeSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> UpdateAsync(Azure.ResourceManager.CodeSigning.Models.CodeSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CodeSigningCertificateProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>, System.Collections.IEnumerable
    {
        protected CodeSigningCertificateProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CodeSigningCertificateProfileData : Azure.ResourceManager.Models.ResourceData
    {
        public CodeSigningCertificateProfileData(Azure.ResourceManager.CodeSigning.Models.CertificateProfileType profileType, Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy rotationPolicy, string commonName, string organization) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificate> Certificates { get { throw null; } }
        public string City { get { throw null; } }
        public string CommonName { get { throw null; } set { } }
        public string Country { get { throw null; } }
        public bool? DoesIncludeCity { get { throw null; } set { } }
        public bool? DoesIncludeCountry { get { throw null; } set { } }
        public bool? DoesIncludePostalCode { get { throw null; } set { } }
        public bool? DoesIncludeState { get { throw null; } set { } }
        public bool? DoesIncludeStreetAddress { get { throw null; } set { } }
        public string EnhancedKeyUsage { get { throw null; } }
        public string IdentityValidationId { get { throw null; } }
        public string Organization { get { throw null; } set { } }
        public string OrganizationUnit { get { throw null; } set { } }
        public string PostalCode { get { throw null; } }
        public Azure.ResourceManager.CodeSigning.Models.CertificateProfileType ProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy RotationPolicy { get { throw null; } set { } }
        public string State { get { throw null; } }
        public Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus? Status { get { throw null; } }
        public string StreetAddress { get { throw null; } }
    }
    public partial class CodeSigningCertificateProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CodeSigningCertificateProfileResource() { }
        public virtual Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource> Update(Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource>> UpdateAsync(Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CodeSigningExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CodeSigning.Models.CodeSigningNameAvailabilityResult> CheckCodeSigningNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CodeSigning.Models.CodeSigningNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.Models.CodeSigningNameAvailabilityResult>> CheckCodeSigningNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CodeSigning.Models.CodeSigningNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetCodeSigningAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource>> GetCodeSigningAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CodeSigning.CodeSigningAccountResource GetCodeSigningAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CodeSigning.CodeSigningAccountCollection GetCodeSigningAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetCodeSigningAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CodeSigning.CodeSigningAccountResource> GetCodeSigningAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileResource GetCodeSigningCertificateProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.CodeSigning.Models
{
    public static partial class ArmCodeSigningModelFactory
    {
        public static Azure.ResourceManager.CodeSigning.CodeSigningAccountData CodeSigningAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri accountUri = null, Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState? provisioningState = default(Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.CodeSigning.CodeSigningCertificateProfileData CodeSigningCertificateProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CodeSigning.Models.CertificateProfileType profileType = default(Azure.ResourceManager.CodeSigning.Models.CertificateProfileType), Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy rotationPolicy = default(Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy), string commonName = null, string organization = null, string organizationUnit = null, string streetAddress = null, bool? doesIncludeStreetAddress = default(bool?), string state = null, bool? doesIncludeState = default(bool?), string city = null, bool? doesIncludeCity = default(bool?), string postalCode = null, bool? doesIncludePostalCode = default(bool?), string country = null, bool? doesIncludeCountry = default(bool?), string enhancedKeyUsage = null, string identityValidationId = null, Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState? provisioningState = default(Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState?), Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus? status = default(Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificate> certificates = null) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningNameAvailabilityResult CodeSigningNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.CodeSigning.Models.CodeSigningNameUnavailableReason? reason = default(Azure.ResourceManager.CodeSigning.Models.CodeSigningNameUnavailableReason?), string message = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileStatus : System.IEquatable<Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.CodeSigning.Models.CertificateProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileType : System.IEquatable<Azure.ResourceManager.CodeSigning.Models.CertificateProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileType(string value) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileType PrivateTrust { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileType PrivateTrustCIPolicy { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileType PublicTrust { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileType PublicTrustTest { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateProfileType VbsEnclave { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CodeSigning.Models.CertificateProfileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CodeSigning.Models.CertificateProfileType left, Azure.ResourceManager.CodeSigning.Models.CertificateProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CodeSigning.Models.CertificateProfileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CodeSigning.Models.CertificateProfileType left, Azure.ResourceManager.CodeSigning.Models.CertificateProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateRevocation
    {
        public CertificateRevocation() { }
        public string Reason { get { throw null; } set { } }
        public string Remarks { get { throw null; } set { } }
        public System.DateTimeOffset? RequestedOn { get { throw null; } set { } }
        public System.DateTimeOffset? RevokedOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateRotationPolicy : System.IEquatable<Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateRotationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy ThirtyDays { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy ThreeDays { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy left, Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy left, Azure.ResourceManager.CodeSigning.Models.CertificateRotationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeSigningAccountPatch
    {
        public CodeSigningAccountPatch() { }
        public System.Uri AccountUri { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CodeSigningCertificate
    {
        public CodeSigningCertificate() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CodeSigning.Models.CertificateRevocation> Revocations { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus? Status { get { throw null; } set { } }
        public string SubjectName { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CodeSigningCertificateProfilePatch
    {
        public CodeSigningCertificateProfilePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificate> Certificates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CodeSigningCertificateStatus : System.IEquatable<Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CodeSigningCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus RevocationFailed { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus RevocationInitiated { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus RevocationInProgress { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus left, Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus left, Azure.ResourceManager.CodeSigning.Models.CodeSigningCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeSigningNameAvailabilityContent
    {
        public CodeSigningNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class CodeSigningNameAvailabilityResult
    {
        internal CodeSigningNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.CodeSigning.Models.CodeSigningNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum CodeSigningNameUnavailableReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CodeSigningProvisioningState : System.IEquatable<Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CodeSigningProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState left, Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState left, Azure.ResourceManager.CodeSigning.Models.CodeSigningProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
