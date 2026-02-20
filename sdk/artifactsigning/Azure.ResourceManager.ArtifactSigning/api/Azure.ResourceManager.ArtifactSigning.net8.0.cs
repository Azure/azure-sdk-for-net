namespace Azure.ResourceManager.ArtifactSigning
{
    public partial class ArtifactSigningAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>, System.Collections.IEnumerable
    {
        protected ArtifactSigningAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactSigningAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>
    {
        public ArtifactSigningAccountData(Azure.Core.AzureLocation location) { }
        public System.Uri AccountUri { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName? SkuName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactSigningAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactSigningAccountResource() { }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> GetArtifactSigningCertificateProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> GetArtifactSigningCertificateProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileCollection GetArtifactSigningCertificateProfiles() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArtifactSigningCertificateProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>, System.Collections.IEnumerable
    {
        protected ArtifactSigningCertificateProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactSigningCertificateProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>
    {
        public ArtifactSigningCertificateProfileData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate> Certificates { get { throw null; } }
        public string IdentityValidationId { get { throw null; } set { } }
        public bool? IncludeCity { get { throw null; } set { } }
        public bool? IncludeCountry { get { throw null; } set { } }
        public bool? IncludePostalCode { get { throw null; } set { } }
        public bool? IncludeState { get { throw null; } set { } }
        public bool? IncludeStreetAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType ProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactSigningCertificateProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactSigningCertificateProfileResource() { }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeCertificate(Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeCertificateAsync(Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ArtifactSigningExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult> CheckArtifactSigningAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>> CheckArtifactSigningAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> GetArtifactSigningAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource GetArtifactSigningAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountCollection GetArtifactSigningAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource GetArtifactSigningCertificateProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AzureResourceManagerArtifactSigningContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerArtifactSigningContext() { }
        public static Azure.ResourceManager.ArtifactSigning.AzureResourceManagerArtifactSigningContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.ArtifactSigning.Mocking
{
    public partial class MockableArtifactSigningArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableArtifactSigningArmClient() { }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource GetArtifactSigningAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileResource GetArtifactSigningCertificateProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableArtifactSigningResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArtifactSigningResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource>> GetArtifactSigningAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountCollection GetArtifactSigningAccounts() { throw null; }
    }
    public partial class MockableArtifactSigningSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableArtifactSigningSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult> CheckArtifactSigningAccountNameAvailability(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>> CheckArtifactSigningAccountNameAvailabilityAsync(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountResource> GetArtifactSigningAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ArtifactSigning.Models
{
    public static partial class ArmArtifactSigningModelFactory
    {
        public static Azure.ResourceManager.ArtifactSigning.ArtifactSigningAccountData ArtifactSigningAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri accountUri = null, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState? provisioningState = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState?), Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName? skuName = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName?)) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent ArtifactSigningAccountNameAvailabilityContent(Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), string name = null) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult ArtifactSigningAccountNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason? reason = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch ArtifactSigningAccountPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName? skuName = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName?)) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate ArtifactSigningCertificate(string serialNumber = null, string enhancedKeyUsage = null, string subjectName = null, string thumbprint = null, System.DateTimeOffset? createOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus? status = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus?), System.DateTimeOffset? requestedOn = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), string reason = null, string remarks = null, Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus? revocationStatus = default(Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus?), string failureReason = null) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.ArtifactSigningCertificateProfileData ArtifactSigningCertificateProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType? profileType = default(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType?), bool? includeStreetAddress = default(bool?), bool? includeCity = default(bool?), bool? includeState = default(bool?), bool? includeCountry = default(bool?), bool? includePostalCode = default(bool?), string identityValidationId = null, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState? provisioningState = default(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState?), Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus? status = default(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate> certificates = null) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent RevokeCertificateContent(string serialNumber = null, string thumbprint = null, System.DateTimeOffset effectiveOn = default(System.DateTimeOffset), string reason = null, string remarks = null) { throw null; }
    }
    public partial class ArtifactSigningAccountNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>
    {
        public ArtifactSigningAccountNameAvailabilityContent(Azure.Core.ResourceType resourceType, string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactSigningAccountNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>
    {
        internal ArtifactSigningAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactSigningAccountNameUnavailabilityReason : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactSigningAccountNameUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason AccountNameInvalid { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason AlreadyExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountNameUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactSigningAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>
    {
        public ArtifactSigningAccountPatch() { }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArtifactSigningCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>
    {
        internal ArtifactSigningCertificate() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string EnhancedKeyUsage { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } }
        public System.DateTimeOffset? RequestedOn { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus? RevocationStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus? Status { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactSigningCertificateStatus : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactSigningCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactSigningProvisioningState : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactSigningProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArtifactSigningSkuName : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArtifactSigningSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName left, Azure.ResourceManager.ArtifactSigning.Models.ArtifactSigningSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileStatus : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileType : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileType(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType PrivateTrust { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType PrivateTrustCIPolicy { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType PublicTrust { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType PublicTrustTest { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType VbsEnclave { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType left, Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType left, Azure.ResourceManager.ArtifactSigning.Models.CertificateProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateRevocationStatus : System.IEquatable<Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateRevocationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus left, Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus left, Azure.ResourceManager.ArtifactSigning.Models.CertificateRevocationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RevokeCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>
    {
        public RevokeCertificateContent(string serialNumber, string thumbprint, System.DateTimeOffset effectiveOn, string reason) { }
        public System.DateTimeOffset EffectiveOn { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ArtifactSigning.Models.RevokeCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
