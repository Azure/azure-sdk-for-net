namespace Azure.ResourceManager.TrustedSigning
{
    public partial class AzureResourceManagerTrustedSigningContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTrustedSigningContext() { }
        public static Azure.ResourceManager.TrustedSigning.AzureResourceManagerTrustedSigningContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class TrustedSigningAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>, System.Collections.IEnumerable
    {
        protected TrustedSigningAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrustedSigningAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>
    {
        public TrustedSigningAccountData(Azure.Core.AzureLocation location) { }
        public System.Uri AccountUri { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? SkuName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrustedSigningAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrustedSigningAccountResource() { }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> GetTrustedSigningCertificateProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> GetTrustedSigningCertificateProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileCollection GetTrustedSigningCertificateProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrustedSigningCertificateProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>, System.Collections.IEnumerable
    {
        protected TrustedSigningCertificateProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrustedSigningCertificateProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>
    {
        public TrustedSigningCertificateProfileData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate> Certificates { get { throw null; } }
        public string IdentityValidationId { get { throw null; } set { } }
        public bool? IncludeCity { get { throw null; } set { } }
        public bool? IncludeCountry { get { throw null; } set { } }
        public bool? IncludePostalCode { get { throw null; } set { } }
        public bool? IncludeState { get { throw null; } set { } }
        public bool? IncludeStreetAddress { get { throw null; } set { } }
        public Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType ProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrustedSigningCertificateProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrustedSigningCertificateProfileResource() { }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeCertificate(Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeCertificateAsync(Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TrustedSigningExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult> CheckTrustedSigningAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>> CheckTrustedSigningAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> GetTrustedSigningAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource GetTrustedSigningAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.TrustedSigningAccountCollection GetTrustedSigningAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource GetTrustedSigningCertificateProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.TrustedSigning.Mocking
{
    public partial class MockableTrustedSigningArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningArmClient() { }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource GetTrustedSigningAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileResource GetTrustedSigningCertificateProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableTrustedSigningResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource>> GetTrustedSigningAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TrustedSigning.TrustedSigningAccountCollection GetTrustedSigningAccounts() { throw null; }
    }
    public partial class MockableTrustedSigningSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTrustedSigningSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult> CheckTrustedSigningAccountNameAvailability(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>> CheckTrustedSigningAccountNameAvailabilityAsync(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TrustedSigning.TrustedSigningAccountResource> GetTrustedSigningAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TrustedSigning.Models
{
    public static partial class ArmTrustedSigningModelFactory
    {
        public static Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent RevokeCertificateContent(string serialNumber = null, string thumbprint = null, System.DateTimeOffset effectiveOn = default(System.DateTimeOffset), string reason = null, string remarks = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.TrustedSigningAccountData TrustedSigningAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri accountUri = null, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState? provisioningState = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState?), Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? skuName = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName?)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent TrustedSigningAccountNameAvailabilityContent(Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), string name = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult TrustedSigningAccountNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason? reason = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch TrustedSigningAccountPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? skuName = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName?)) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate TrustedSigningCertificate(string serialNumber = null, string enhancedKeyUsage = null, string subjectName = null, string thumbprint = null, System.DateTimeOffset? createOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus? status = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus?), System.DateTimeOffset? requestedOn = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), string reason = null, string remarks = null, Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus? revocationStatus = default(Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus?), string failureReason = null) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.TrustedSigningCertificateProfileData TrustedSigningCertificateProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType? profileType = default(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType?), bool? includeStreetAddress = default(bool?), bool? includeCity = default(bool?), bool? includeState = default(bool?), bool? includeCountry = default(bool?), bool? includePostalCode = default(bool?), string identityValidationId = null, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState? provisioningState = default(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState?), Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus? status = default(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate> certificates = null) { throw null; }
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
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProfileType : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProfileType(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType PrivateTrust { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType PrivateTrustCIPolicy { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType PublicTrust { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType PublicTrustTest { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType VbsEnclave { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType left, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType left, Azure.ResourceManager.TrustedSigning.Models.CertificateProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateRevocationStatus : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateRevocationStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus left, Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RevokeCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>
    {
        public RevokeCertificateContent(string serialNumber, string thumbprint, System.DateTimeOffset effectiveOn, string reason) { }
        public System.DateTimeOffset EffectiveOn { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.RevokeCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrustedSigningAccountNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>
    {
        public TrustedSigningAccountNameAvailabilityContent(Azure.Core.ResourceType resourceType, string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrustedSigningAccountNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>
    {
        internal TrustedSigningAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustedSigningAccountNameUnavailabilityReason : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustedSigningAccountNameUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason AccountNameInvalid { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason AlreadyExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountNameUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrustedSigningAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>
    {
        public TrustedSigningAccountPatch() { }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrustedSigningCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>
    {
        internal TrustedSigningCertificate() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string EnhancedKeyUsage { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Remarks { get { throw null; } }
        public System.DateTimeOffset? RequestedOn { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.CertificateRevocationStatus? RevocationStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus? Status { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustedSigningCertificateStatus : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustedSigningCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus Active { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus Revoked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrustedSigningProvisioningState : System.IEquatable<Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrustedSigningProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
        public static implicit operator Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName left, Azure.ResourceManager.TrustedSigning.Models.TrustedSigningSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
}
