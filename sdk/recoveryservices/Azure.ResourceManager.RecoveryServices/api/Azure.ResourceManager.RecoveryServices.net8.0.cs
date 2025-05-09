namespace Azure.ResourceManager.RecoveryServices
{
    public partial class AzureResourceManagerRecoveryServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRecoveryServicesContext() { }
        public static Azure.ResourceManager.RecoveryServices.AzureResourceManagerRecoveryServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class RecoveryServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult> CheckRecoveryServicesNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>> CheckRecoveryServicesNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult> GetRecoveryServiceCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>> GetRecoveryServiceCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource GetRecoveryServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetRecoveryServicesVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource GetRecoveryServicesVaultExtendedInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource GetRecoveryServicesVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultCollection GetRecoveryServicesVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected RecoveryServicesPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>
    {
        internal RecoveryServicesPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>, System.Collections.IEnumerable
    {
        protected RecoveryServicesVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryServicesVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>
    {
        public RecoveryServicesVaultData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesVaultExtendedInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>
    {
        public RecoveryServicesVaultExtendedInfoData() { }
        public string Algorithm { get { throw null; } set { } }
        public string EncryptionKey { get { throw null; } set { } }
        public string EncryptionKeyThumbprint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string IntegrityKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesVaultExtendedInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesVaultExtendedInfoResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> Update(Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> UpdateAsync(Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesVaultResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult> CreateVaultCertificate(string certificateName, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>> CreateVaultCertificateAsync(string certificateName, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRegisteredIdentity(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRegisteredIdentityAsync(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetRecoveryServicesPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetRecoveryServicesPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceCollection GetRecoveryServicesPrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource GetRecoveryServicesVaultExtendedInfo() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServices.Mocking
{
    public partial class MockableRecoveryServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesArmClient() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource GetRecoveryServicesPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource GetRecoveryServicesVaultExtendedInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource GetRecoveryServicesVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRecoveryServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult> CheckRecoveryServicesNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>> CheckRecoveryServicesNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVault(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetRecoveryServicesVaultAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultCollection GetRecoveryServicesVaults() { throw null; }
    }
    public partial class MockableRecoveryServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult> GetRecoveryServiceCapabilities(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>> GetRecoveryServiceCapabilitiesAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServices.Models
{
    public static partial class ArmRecoveryServicesModelFactory
    {
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult RecoveryServicesNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection RecoveryServicesPrivateEndpointConnection(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType> groupIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties RecoveryServicesPrivateEndpointConnectionVaultProperties(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData RecoveryServicesPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState RecoveryServicesPrivateLinkServiceConnectionState(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus? status = default(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings RecoveryServicesSecuritySettings(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState? immutabilityState = default(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState?), Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings softDeleteSettings = null, Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization? multiUserAuthorization = default(Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData RecoveryServicesVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties properties = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku sku = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData RecoveryServicesVaultExtendedInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string integrityKey = null, string encryptionKey = null, string encryptionKeyThumbprint = null, string algorithm = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch RecoveryServicesVaultPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties properties = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties RecoveryServicesVaultProperties(string provisioningState = null, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails upgradeDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties> privateEndpointConnections = null, Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? privateEndpointStateForBackup = default(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState?), Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? privateEndpointStateForSiteRecovery = default(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState?), Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption encryption = null, Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails moveDetails = null, Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState? moveState = default(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState?), Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion? backupStorageVersion = default(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion?), Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess?), Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings monitoringSettings = null, Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState? crossSubscriptionRestoreState = default(Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState?), Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings redundancySettings = null, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings securitySettings = null, Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel? secureScore = default(Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary ReplicationJobSummary(int? failedJobs = default(int?), int? suspendedJobs = default(int?), int? inProgressJobs = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage ReplicationUsage(Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary monitoringSummary = null, Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary jobsSummary = null, int? protectedItemCount = default(int?), int? recoveryPlanCount = default(int?), int? registeredServersCount = default(int?), int? recoveryServicesProviderAuthType = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails ResourceCertificateAndAadDetails(byte[] certificate = null, string friendlyName = null, string issuer = null, long? resourceId = default(long?), string subject = null, System.BinaryData thumbprint = null, System.DateTimeOffset? validStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? validEndOn = default(System.DateTimeOffset?), string aadAuthority = null, System.Guid aadTenantId = default(System.Guid), string servicePrincipalClientId = null, string servicePrincipalObjectId = null, string azureManagementEndpointAudience = null, Azure.Core.ResourceIdentifier serviceResourceId = null, string aadAudience = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails ResourceCertificateAndAcsDetails(byte[] certificate = null, string friendlyName = null, string issuer = null, long? resourceId = default(long?), string subject = null, System.BinaryData thumbprint = null, System.DateTimeOffset? validStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? validEndOn = default(System.DateTimeOffset?), string globalAcsNamespace = null, string globalAcsHostName = null, string globalAcsRPRealm = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails ResourceCertificateDetails(string authType = null, byte[] certificate = null, string friendlyName = null, string issuer = null, long? resourceId = default(long?), string subject = null, System.BinaryData thumbprint = null, System.DateTimeOffset? validStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? validEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult VaultCertificateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary VaultMonitoringSummary(int? unHealthyVmCount = default(int?), int? unHealthyProviderCount = default(int?), int? eventsCount = default(int?), int? deprecatedProviderCount = default(int?), int? supportedProviderCount = default(int?), int? unsupportedProviderCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails VaultPropertiesMoveDetails(string operationId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier targetResourceId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings VaultPropertiesRedundancySettings(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy? standardTierStorageRedundancy = default(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy?), Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore? crossRegionRestore = default(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails VaultUpgradeDetails(string operationId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState? status = default(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState?), string message = null, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType? triggerType = default(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType?), Azure.Core.ResourceIdentifier upgradedResourceId = null, Azure.Core.ResourceIdentifier previousResourceId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsage VaultUsage(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit? unit = default(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit?), string quotaPeriod = null, System.DateTimeOffset? nextResetOn = default(System.DateTimeOffset?), long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo name = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo VaultUsageNameInfo(string value = null, string localizedValue = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageVersion : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageVersion(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion Unassigned { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion V1 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion left, Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion left, Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapabilitiesResult : Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>
    {
        public CapabilitiesResult(Azure.Core.ResourceType resourceCapabilitiesBaseType) : base (default(Azure.Core.ResourceType)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult> CapabilitiesResultDnsZones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CmkKekIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>
    {
        public CmkKekIdentity() { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CrossRegionRestore : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CrossRegionRestore(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore left, Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore left, Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CrossSubscriptionRestoreState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CrossSubscriptionRestoreState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState PermanentlyDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState left, Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState left, Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsZone : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>
    {
        public DnsZone() { }
        public Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType? SubResource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.DnsZone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.DnsZone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsZoneResult : Azure.ResourceManager.RecoveryServices.Models.DnsZone, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>
    {
        public DnsZoneResult() { }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Locked { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState left, Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState left, Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryptionState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiUserAuthorization : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiUserAuthorization(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization left, Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization left, Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RawCertificateData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>
    {
        public RawCertificateData() { }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType? AuthType { get { throw null; } set { } }
        public byte[] Certificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RawCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RawCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RawCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesAlertsState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesAlertsState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesAuthType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesAuthType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Aad { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType AccessControlService { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Acs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesCertificateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>
    {
        public RecoveryServicesCertificateContent() { }
        public Azure.ResourceManager.RecoveryServices.Models.RawCertificateData Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>
    {
        public RecoveryServicesNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>
    {
        internal RecoveryServicesNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesPrivateEndpointConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>
    {
        internal RecoveryServicesPrivateEndpointConnection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesPrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesPrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesPrivateEndpointConnectionVaultProperties : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>
    {
        internal RecoveryServicesPrivateEndpointConnectionVaultProperties() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>
    {
        internal RecoveryServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesSecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>
    {
        public RecoveryServicesSecuritySettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.MultiUserAuthorization? MultiUserAuthorization { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>
    {
        public RecoveryServicesSku(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName name) { }
        public string Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesSkuName : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesSkuName(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName RS0 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesSoftDeleteSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>
    {
        public RecoveryServicesSoftDeleteSettings() { }
        public int? SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState? SoftDeleteState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesSoftDeleteState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesSoftDeleteState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState AlwaysON { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSoftDeleteState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesVaultPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>
    {
        public RecoveryServicesVaultPatch(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServicesVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>
    {
        public RecoveryServicesVaultProperties() { }
        public Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion? BackupStorageVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.CrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption Encryption { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails MoveDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState? MoveState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForBackup { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForSiteRecovery { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings RedundancySettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel? SecureScore { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails UpgradeDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicationJobSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>
    {
        internal ReplicationJobSummary() { }
        public int? FailedJobs { get { throw null; } }
        public int? InProgressJobs { get { throw null; } }
        public int? SuspendedJobs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicationUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>
    {
        internal ReplicationUsage() { }
        public Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary JobsSummary { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary MonitoringSummary { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public int? RecoveryPlanCount { get { throw null; } }
        public int? RecoveryServicesProviderAuthType { get { throw null; } }
        public int? RegisteredServersCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCapabilities : Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>
    {
        public ResourceCapabilities(Azure.Core.ResourceType resourceCapabilitiesBaseType) : base (default(Azure.Core.ResourceType)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZone> CapabilitiesDnsZones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCapabilitiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>
    {
        public ResourceCapabilitiesBase(Azure.Core.ResourceType resourceCapabilitiesBaseType) { }
        public Azure.Core.ResourceType ResourceCapabilitiesBaseType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCertificateAndAadDetails : Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>
    {
        internal ResourceCertificateAndAadDetails() { }
        public string AadAudience { get { throw null; } }
        public string AadAuthority { get { throw null; } }
        public System.Guid AadTenantId { get { throw null; } }
        public string AzureManagementEndpointAudience { get { throw null; } }
        public string ServicePrincipalClientId { get { throw null; } }
        public string ServicePrincipalObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAadDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCertificateAndAcsDetails : Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>
    {
        internal ResourceCertificateAndAcsDetails() { }
        public string GlobalAcsHostName { get { throw null; } }
        public string GlobalAcsNamespace { get { throw null; } }
        public string GlobalAcsRPRealm { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateAndAcsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResourceCertificateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>
    {
        protected ResourceCertificateDetails() { }
        public byte[] Certificate { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Issuer { get { throw null; } }
        public long? ResourceId { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? ValidEndOn { get { throw null; } }
        public System.DateTimeOffset? ValidStartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceMoveState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CommitTimedout { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CriticalFailure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState Failure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState MoveSucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PartialSuccess { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PrepareTimedout { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState left, Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState left, Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecureScoreLevel : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecureScoreLevel(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel Adequate { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel Maximum { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel Minimum { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel left, Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel left, Azure.ResourceManager.RecoveryServices.Models.SecureScoreLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandardTierStorageRedundancy : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandardTierStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy left, Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy left, Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultCertificateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>
    {
        internal VaultCertificateResult() { }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultMonitoringSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>
    {
        public VaultMonitoringSettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState? ClassicAlertAlertsForCriticalOperations { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultMonitoringSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>
    {
        internal VaultMonitoringSummary() { }
        public int? DeprecatedProviderCount { get { throw null; } }
        public int? EventsCount { get { throw null; } }
        public int? SupportedProviderCount { get { throw null; } }
        public int? UnHealthyProviderCount { get { throw null; } }
        public int? UnHealthyVmCount { get { throw null; } }
        public int? UnsupportedProviderCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPrivateEndpointState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPrivateEndpointState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState left, Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState left, Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultPropertiesEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>
    {
        public VaultPropertiesEncryption() { }
        public Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity KekIdentity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultPropertiesMoveDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>
    {
        public VaultPropertiesMoveDetails() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultPropertiesRedundancySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>
    {
        public VaultPropertiesRedundancySettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore? CrossRegionRestore { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy? StandardTierStorageRedundancy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultSubResourceType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultSubResourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureBackup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureBackupSecondary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureSiteRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultUpgradeDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>
    {
        public VaultUpgradeDetails() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PreviousResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState? Status { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType? TriggerType { get { throw null; } }
        public Azure.Core.ResourceIdentifier UpgradedResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUpgradeState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUpgradeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Upgraded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUpgradeTriggerType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUpgradeTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType ForcedUpgrade { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType UserTriggered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>
    {
        internal VaultUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultUsageNameInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>
    {
        internal VaultUsageNameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUsageUnit : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit left, Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit left, Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
