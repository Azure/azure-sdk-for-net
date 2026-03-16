namespace Azure.ResourceManager.ConfidentialLedger
{
    public partial class AzureResourceManagerConfidentialLedgerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerConfidentialLedgerContext() { }
        public static Azure.ResourceManager.ConfidentialLedger.AzureResourceManagerConfidentialLedgerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConfidentialLedgerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.IEnumerable
    {
        protected ConfidentialLedgerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetIfExists(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetIfExistsAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfidentialLedgerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>
    {
        public ConfidentialLedgerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ConfidentialLedgerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult> CheckConfidentialLedgerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>> CheckConfidentialLedgerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedger(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetConfidentialLedgerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource GetConfidentialLedgerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerCollection GetConfidentialLedgers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfidentialLedgerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfidentialLedgerResource() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ledgerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult> FilesExport(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>> FilesExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConfidentialLedger.Mocking
{
    public partial class MockableConfidentialLedgerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerArmClient() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource GetConfidentialLedgerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConfidentialLedgerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedger(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetConfidentialLedgerAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerCollection GetConfidentialLedgers() { throw null; }
    }
    public partial class MockableConfidentialLedgerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult> CheckConfidentialLedgerNameAvailability(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>> CheckConfidentialLedgerNameAvailabilityAsync(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgers(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgersAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConfidentialLedger.Models
{
    public partial class AadBasedSecurityPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>
    {
        public AadBasedSecurityPrincipal() { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmConfidentialLedgerModelFactory
    {
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData ConfidentialLedgerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent ConfidentialLedgerFilesExportContent(string restoreRegion = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult ConfidentialLedgerFilesExportResult(string message = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult ConfidentialLedgerNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? reason = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties ConfidentialLedgerProperties(string ledgerName = null, System.Uri ledgerUri = null, System.Uri identityServiceUri = null, string ledgerInternalNamespace = null, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState? runningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? ledgerType = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? provisioningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku? ledgerSku = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> aadBasedSecurityPrincipals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> certBasedSecurityPrincipals = null, string hostLevel = null, int? maxBodySizeInMb = default(int?), string subjectName = null, int? nodeCount = default(int?), string writeLBAddressPrefix = null, int? workerThreads = default(int?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform? enclavePlatform = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType? applicationType = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType?), string scittConfiguration = null) { throw null; }
    }
    public partial class CertBasedSecurityPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>
    {
        public CertBasedSecurityPrincipal() { }
        public string Cert { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerApplicationType : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType CodeTransparency { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType ConfidentialLedger { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerEnclavePlatform : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerEnclavePlatform(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform AmdSevSnp { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform IntelSgx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialLedgerFilesExportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>
    {
        public ConfidentialLedgerFilesExportContent(System.Uri uri) { }
        public string RestoreRegion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerFilesExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>
    {
        internal ConfidentialLedgerFilesExportResult() { }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerFilesExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>
    {
        public ConfidentialLedgerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>
    {
        internal ConfidentialLedgerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerNameUnavailableReason : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialLedgerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>
    {
        public ConfidentialLedgerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> AadBasedSecurityPrincipals { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerApplicationType? ApplicationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> CertBasedSecurityPrincipals { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerEnclavePlatform? EnclavePlatform { get { throw null; } }
        public string HostLevel { get { throw null; } set { } }
        public System.Uri IdentityServiceUri { get { throw null; } }
        public string LedgerInternalNamespace { get { throw null; } }
        public string LedgerName { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku? LedgerSku { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? LedgerType { get { throw null; } set { } }
        public System.Uri LedgerUri { get { throw null; } }
        public int? MaxBodySizeInMb { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState? RunningState { get { throw null; } set { } }
        public string ScittConfiguration { get { throw null; } set { } }
        public string SubjectName { get { throw null; } set { } }
        public int? WorkerThreads { get { throw null; } set { } }
        public string WriteLBAddressPrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerProvisioningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerRoleName : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Administrator { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Contributor { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerRunningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerRunningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Active { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Paused { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerSku : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerSku(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku Basic { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku Standard { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerType : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerType(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Private { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Public { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
