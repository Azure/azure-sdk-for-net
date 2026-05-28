namespace Azure.ResourceManager.Batch
{
    public partial class AzureResourceManagerBatchContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerBatchContext() { }
        public static Azure.ResourceManager.Batch.AzureResourceManagerBatchContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BatchAccountCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>, System.Collections.IEnumerable
    {
        protected BatchAccountCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>
    {
        public BatchAccountCertificateData() { }
        public Azure.ResponseError DeleteCertificateError { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? Format { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? PreviousProvisioningState { get { throw null; } }
        public System.DateTimeOffset? PreviousProvisioningStateTransitOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitOn { get { throw null; } }
        public string PublicData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountCertificateResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> CancelDeletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> CancelDeletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchAccountCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> Update(Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> UpdateAsync(Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>, System.Collections.IEnumerable
    {
        protected BatchAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>
    {
        public BatchAccountData() { }
        public string AccountEndpoint { get { throw null; } }
        public int? ActiveJobAndJobScheduleQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration AutoStorage { get { throw null; } }
        public int? DedicatedCoreQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota> DedicatedCoreQuotaPerVmFamily { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsDedicatedCoreQuotaPerVmFamilyEnforced { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchKeyVaultReference KeyVaultReference { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public int? LowPriorityCoreQuota { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NodeManagementEndpoint { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? PoolAllocationMode { get { throw null; } }
        public int? PoolQuota { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountDetectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>, System.Collections.IEnumerable
    {
        protected BatchAccountDetectorCollection() { }
        public virtual Azure.Response<bool> Exists(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> Get(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetIfExists(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetIfExistsAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountDetectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountDetectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountDetectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountDetectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>
    {
        public BatchAccountDetectorData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountDetectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountDetectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountDetectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountDetectorResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string detectorId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchAccountDetectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountDetectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountDetectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>, System.Collections.IEnumerable
    {
        protected BatchAccountPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchAccountPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetAll(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetAllAsync(int? maxresults = default(int?), string select = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchAccountPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchAccountPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchAccountPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchAccountPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>
    {
        public BatchAccountPoolData() { }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionOn { get { throw null; } }
        public System.Collections.Generic.IList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference> ApplicationPackages { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun AutoScaleRun { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchCertificateReference> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? CurrentDedicatedNodes { get { throw null; } }
        public int? CurrentLowPriorityNodes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NodeCommunicationMode? CurrentNodeCommunicationMode { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchVmConfiguration DeploymentVmConfiguration { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? InterNodeCommunication { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchMountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningStateTransitOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus ResizeOperationStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ResourceTags { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask StartTask { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNodeFillType? TaskSchedulingNodeFillType { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchUserAccount> UserAccounts { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountPoolResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> DisableAutoScale(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> DisableAutoScaleAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> StopResize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> StopResizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchAccountPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> Update(Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> UpdateAsync(Azure.ResourceManager.Batch.BatchAccountPoolData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchAccountResource() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource> GetBatchAccountCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountCertificateResource>> GetBatchAccountCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateCollection GetBatchAccountCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource> GetBatchAccountDetector(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountDetectorResource>> GetBatchAccountDetectorAsync(string detectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorCollection GetBatchAccountDetectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource> GetBatchAccountPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountPoolResource>> GetBatchAccountPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolCollection GetBatchAccountPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> GetBatchApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetBatchApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationCollection GetBatchApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetBatchPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetBatchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionCollection GetBatchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetBatchPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetBatchPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResourceCollection GetBatchPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> GetNetworkSecurityPerimeterConfiguration(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>> GetNetworkSecurityPerimeterConfigurationAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationCollection GetNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys> RegenerateKey(Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchAccountKeys>> RegenerateKeyAsync(Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SynchronizeAutoStorageKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SynchronizeAutoStorageKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> Update(Azure.ResourceManager.Batch.Models.BatchAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> UpdateAsync(Azure.ResourceManager.Batch.Models.BatchAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>, System.Collections.IEnumerable
    {
        protected BatchApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchApplicationResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchApplicationResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchApplicationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>
    {
        public BatchApplicationData() { }
        public bool? AllowUpdates { get { throw null; } set { } }
        public string DefaultVersion { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplicationPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>, System.Collections.IEnumerable
    {
        protected BatchApplicationPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchApplicationPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchApplicationPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchApplicationPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchApplicationPackageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>
    {
        public BatchApplicationPackageData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Format { get { throw null; } }
        public System.DateTimeOffset? LastActivatedOn { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchApplicationPackageState? State { get { throw null; } }
        public System.Uri StorageUri { get { throw null; } }
        public System.DateTimeOffset? StorageUriExpireOn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplicationPackageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchApplicationPackageResource() { }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Activate(Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> ActivateAsync(Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchApplicationPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchApplicationPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchApplicationResource() { }
        public virtual Azure.ResourceManager.Batch.BatchApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource> GetBatchApplicationPackage(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationPackageResource>> GetBatchApplicationPackageAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageCollection GetBatchApplicationPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource> Update(Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchApplicationResource>> UpdateAsync(Azure.ResourceManager.Batch.BatchApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class BatchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult> CheckBatchNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>> CheckBatchNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetBatchAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCertificateResource GetBatchAccountCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountDetectorResource GetBatchAccountDetectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountPoolResource GetBatchAccountPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountResource GetBatchAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCollection GetBatchAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationPackageResource GetBatchApplicationPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationResource GetBatchApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource GetBatchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateLinkResource GetBatchPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota> GetBatchQuotas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota>> GetBatchQuotasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class BatchPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected BatchPrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>
    {
        public BatchPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.BatchPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected BatchPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetAll(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetAllAsync(int? maxresults = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.BatchPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.BatchPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.BatchPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>
    {
        public BatchPrivateLinkResourceData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.BatchPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.BatchPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> Get(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>> GetAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> GetIfExists(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>
    {
        internal NetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string networkSecurityPerimeterConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReconcileConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReconcileConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Batch.Mocking
{
    public partial class MockableBatchArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchArmClient() { }
        public virtual Azure.ResourceManager.Batch.BatchAccountCertificateResource GetBatchAccountCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountDetectorResource GetBatchAccountDetectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountPoolResource GetBatchAccountPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountResource GetBatchAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationPackageResource GetBatchApplicationPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchApplicationResource GetBatchApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionResource GetBatchPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchPrivateLinkResource GetBatchPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableBatchResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.BatchAccountResource>> GetBatchAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Batch.BatchAccountCollection GetBatchAccounts() { throw null; }
    }
    public partial class MockableBatchSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableBatchSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult> CheckBatchNameAvailability(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>> CheckBatchNameAvailabilityAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.BatchAccountResource> GetBatchAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota> GetBatchQuotas(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Batch.Models.BatchLocationQuota>> GetBatchQuotasAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkus(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Batch.Models.BatchSupportedSku> GetBatchSupportedVirtualMachineSkusAsync(Azure.Core.AzureLocation locationName, int? maxresults = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Batch.Models
{
    public static partial class ArmBatchModelFactory
    {
        public static Azure.ResourceManager.Batch.Models.BatchAccessRule BatchAccessRule(string name = null, Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties BatchAccessRuleProperties(Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection? direction = default(Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection?), System.Collections.Generic.IEnumerable<string> addressPrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> subscriptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter> networkSecurityPerimeters = null, System.Collections.Generic.IEnumerable<string> fullyQualifiedDomainNames = null, System.Collections.Generic.IEnumerable<string> emailAddresses = null, System.Collections.Generic.IEnumerable<string> phoneNumbers = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent BatchAccountCertificateCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? format = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat?), System.BinaryData data = null, string password = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountCertificateData BatchAccountCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string thumbprintAlgorithm = null, string thumbprintString = null, Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? format = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat?), Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState?), System.DateTimeOffset? provisioningStateTransitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState? previousProvisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState?), System.DateTimeOffset? previousProvisioningStateTransitOn = default(System.DateTimeOffset?), string publicData = null, Azure.ResponseError deleteCertificateError = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent BatchAccountCreateOrUpdateContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration autoStorage = null, Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? poolAllocationMode = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode?), Azure.ResourceManager.Batch.Models.BatchKeyVaultReference keyVaultReference = null, Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess?), Azure.ResourceManager.Batch.Models.BatchNetworkProfile networkProfile = null, Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> allowedAuthenticationModes = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountData BatchAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string accountEndpoint = null, string nodeManagementEndpoint = null, Azure.ResourceManager.Batch.Models.BatchProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchProvisioningState?), Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? poolAllocationMode = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode?), Azure.ResourceManager.Batch.Models.BatchKeyVaultReference keyVaultReference = null, Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess?), Azure.ResourceManager.Batch.Models.BatchNetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration autoStorage = null, Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration encryption = null, int? dedicatedCoreQuota = default(int?), int? lowPriorityCoreQuota = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota> dedicatedCoreQuotaPerVmFamily = null, bool? isDedicatedCoreQuotaPerVmFamilyEnforced = default(bool?), int? poolQuota = default(int?), int? activeJobAndJobScheduleQuota = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> allowedAuthenticationModes = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountDetectorData BatchAccountDetectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency BatchAccountEndpointDependency(string domainName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountKeys BatchAccountKeys(string accountName = null, string primary = null, string secondary = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint BatchAccountOutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun BatchAccountPoolAutoScaleRun(System.DateTimeOffset evaluationOn = default(System.DateTimeOffset), string results = null, Azure.ResponseError error = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Batch.BatchAccountPoolData BatchAccountPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string displayName, System.DateTimeOffset? lastModifiedOn, System.DateTimeOffset? createdOn, Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState? provisioningState, System.DateTimeOffset? provisioningStateTransitOn, Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState? allocationState, System.DateTimeOffset? allocationStateTransitionOn, string vmSize, Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration deploymentConfiguration, int? currentDedicatedNodes, int? currentLowPriorityNodes, Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings scaleSettings, Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun autoScaleRun, Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? interNodeCommunication, Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration networkConfiguration, int? taskSlotsPerNode, Azure.ResourceManager.Batch.Models.BatchNodeFillType? taskSchedulingNodeFillType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchUserAccount> userAccounts, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem> metadata, Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask startTask, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchCertificateReference> certificates, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference> applicationPackages, System.Collections.Generic.IEnumerable<string> applicationLicenses, Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus resizeOperationStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchMountConfiguration> mountConfiguration, Azure.ResourceManager.Batch.Models.NodeCommunicationMode? targetNodeCommunicationMode, Azure.ResourceManager.Batch.Models.NodeCommunicationMode? currentNodeCommunicationMode, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.Batch.BatchAccountPoolData BatchAccountPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string displayName = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState?), System.DateTimeOffset? provisioningStateTransitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState? allocationState = default(Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationState?), System.DateTimeOffset? allocationStateTransitionOn = default(System.DateTimeOffset?), string vmSize = null, Azure.ResourceManager.Batch.Models.BatchVmConfiguration deploymentVmConfiguration = null, int? currentDedicatedNodes = default(int?), int? currentLowPriorityNodes = default(int?), Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings scaleSettings = null, Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun autoScaleRun = null, Azure.ResourceManager.Batch.Models.InterNodeCommunicationState? interNodeCommunication = default(Azure.ResourceManager.Batch.Models.InterNodeCommunicationState?), Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration networkConfiguration = null, int? taskSlotsPerNode = default(int?), Azure.ResourceManager.Batch.Models.BatchNodeFillType? taskSchedulingNodeFillType = default(Azure.ResourceManager.Batch.Models.BatchNodeFillType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchUserAccount> userAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem> metadata = null, Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask startTask = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchCertificateReference> certificates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference> applicationPackages = null, System.Collections.Generic.IEnumerable<string> applicationLicenses = null, Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus resizeOperationStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchMountConfiguration> mountConfiguration = null, Azure.ResourceManager.Batch.Models.NodeCommunicationMode? targetNodeCommunicationMode = default(Azure.ResourceManager.Batch.Models.NodeCommunicationMode?), Azure.ResourceManager.Batch.Models.NodeCommunicationMode? currentNodeCommunicationMode = default(Azure.ResourceManager.Batch.Models.NodeCommunicationMode?), Azure.ResourceManager.Batch.Models.UpgradePolicy upgradePolicy = null, System.Collections.Generic.IDictionary<string, string> resourceTags = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationData BatchApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, bool? allowUpdates = default(bool?), string defaultVersion = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchApplicationPackageData BatchApplicationPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Batch.Models.BatchApplicationPackageState? state = default(Azure.ResourceManager.Batch.Models.BatchApplicationPackageState?), string format = null, System.Uri storageUri = null, System.DateTimeOffset? storageUriExpireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastActivatedOn = default(System.DateTimeOffset?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchEndpointDetail BatchEndpointDetail(int? port = default(int?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchIPRule BatchIPRule(Azure.ResourceManager.Batch.Models.BatchIPRuleAction action = default(Azure.ResourceManager.Batch.Models.BatchIPRuleAction), string value = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchLocationQuota BatchLocationQuota(int? accountQuota = default(int?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent BatchNameAvailabilityContent(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult BatchNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason? reason = default(Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateEndpointConnectionData BatchPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState connectionState = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.BatchPrivateLinkResourceData BatchPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState BatchPrivateLinkServiceConnectionState(Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus status = Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus.Approved, string description = null, string actionRequired = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningIssue BatchProvisioningIssue(string name = null, Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties BatchProvisioningIssueProperties(Azure.ResourceManager.Batch.Models.BatchIssueType? issueType = default(Azure.ResourceManager.Batch.Models.BatchIssueType?), Azure.ResourceManager.Batch.Models.BatchSeverity? severity = default(Azure.ResourceManager.Batch.Models.BatchSeverity?), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> suggestedResourceIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccessRule> suggestedAccessRules = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus BatchResizeOperationStatus(int? targetDedicatedNodes = default(int?), int? targetLowPriorityNodes = default(int?), System.TimeSpan? resizeTimeout = default(System.TimeSpan?), Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? nodeDeallocationOption = default(Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchResourceAssociation BatchResourceAssociation(string name = null, Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode? accessMode = default(Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSkuCapability BatchSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSupportedSku BatchSupportedSku(string name = null, string familyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchSkuCapability> capabilities = null, System.DateTimeOffset? batchSupportEndOfLife = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota BatchVmFamilyCoreQuota(string name = null, int? coreQuota = default(int?)) { throw null; }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter NetworkSecurityPerimeter(Azure.Core.ResourceIdentifier id = null, System.Guid? perimeterGuid = default(System.Guid?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Batch.NetworkSecurityPerimeterConfigurationData NetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties NetworkSecurityPerimeterConfigurationProperties(Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue> provisioningIssues = null, Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter networkSecurityPerimeter = null, Azure.ResourceManager.Batch.Models.BatchResourceAssociation resourceAssociation = null, Azure.ResourceManager.Batch.Models.NetworkSecurityProfile profile = null) { throw null; }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityProfile NetworkSecurityProfile(string name = null, int? accessRulesVersion = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Batch.Models.BatchAccessRule> accessRules = null, int? diagnosticSettingsVersion = default(int?), System.Collections.Generic.IEnumerable<string> enabledLogCategories = null) { throw null; }
    }
    public partial class AutomaticOSUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
        public bool? OSRollingUpgradeDeferral { get { throw null; } set { } }
        public bool? UseRollingUpgradePolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>
    {
        internal BatchAccessRule() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchAccessRuleDirection : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection left, Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection left, Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchAccessRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>
    {
        internal BatchAccessRuleProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccessRuleDirection? Direction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EmailAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PhoneNumbers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccessRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountAutoScaleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>
    {
        public BatchAccountAutoScaleSettings(string formula) { }
        public System.TimeSpan? EvaluationInterval { get { throw null; } set { } }
        public string Formula { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountAutoStorageBaseConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>
    {
        public BatchAccountAutoStorageBaseConfiguration(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.ResourceManager.Batch.Models.BatchAutoStorageAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NodeIdentityResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountAutoStorageConfiguration : Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>
    {
        public BatchAccountAutoStorageConfiguration(Azure.Core.ResourceIdentifier storageAccountId, System.DateTimeOffset lastKeySyncedOn) : base (default(Azure.Core.ResourceIdentifier)) { }
        public System.DateTimeOffset LastKeySyncedOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountCertificateCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>
    {
        public BatchAccountCertificateCreateOrUpdateContent() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchAccountCertificateFormat? Format { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCertificateCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchAccountCertificateFormat
    {
        Pfx = 0,
        Cer = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchAccountCertificateProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchAccountCertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountCertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>
    {
        public BatchAccountCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchKeyVaultReference KeyVaultReference { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountPoolAllocationMode? PoolAllocationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountEncryptionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>
    {
        public BatchAccountEncryptionConfiguration() { }
        public System.Uri KeyIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountKeySource? KeySource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>
    {
        internal BatchAccountEndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountFixedScaleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>
    {
        public BatchAccountFixedScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>
    {
        internal BatchAccountKeys() { }
        public string AccountName { get { throw null; } }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchAccountKeySource
    {
        MicrosoftBatch = 0,
        MicrosoftKeyVault = 1,
    }
    public enum BatchAccountKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class BatchAccountOutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>
    {
        internal BatchAccountOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAccountEndpointDependency> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountOutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>
    {
        public BatchAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchAuthenticationMode> AllowedAuthenticationModes { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoStorageBaseConfiguration AutoStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchAccountPoolAllocationMode
    {
        BatchService = 0,
        UserSubscription = 1,
    }
    public enum BatchAccountPoolAllocationState
    {
        Steady = 0,
        Resizing = 1,
        Stopping = 2,
    }
    public partial class BatchAccountPoolAutoScaleRun : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>
    {
        internal BatchAccountPoolAutoScaleRun() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset EvaluationOn { get { throw null; } }
        public string Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolAutoScaleRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountPoolMetadataItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>
    {
        public BatchAccountPoolMetadataItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolMetadataItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchAccountPoolProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchAccountPoolProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState left, Azure.ResourceManager.Batch.Models.BatchAccountPoolProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchAccountPoolScaleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>
    {
        public BatchAccountPoolScaleSettings() { }
        public Azure.ResourceManager.Batch.Models.BatchAccountAutoScaleSettings AutoScale { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAccountFixedScaleSettings FixedScale { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolScaleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountPoolStartTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>
    {
        public BatchAccountPoolStartTask() { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchResourceFile> ResourceFiles { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchUserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountPoolStartTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchAccountRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>
    {
        public BatchAccountRegenerateKeyContent(Azure.ResourceManager.Batch.Models.BatchAccountKeyType keyType) { }
        public Azure.ResourceManager.Batch.Models.BatchAccountKeyType KeyType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAccountRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplicationPackageActivateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>
    {
        public BatchApplicationPackageActivateContent(string format) { }
        public string Format { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageActivateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchApplicationPackageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>
    {
        public BatchApplicationPackageReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchApplicationPackageState
    {
        Pending = 0,
        Active = 1,
    }
    public enum BatchAuthenticationMode
    {
        SharedKey = 0,
        Aad = 1,
        TaskAuthenticationToken = 2,
    }
    public enum BatchAutoStorageAuthenticationMode
    {
        StorageKeys = 0,
        BatchAccountManagedIdentity = 1,
    }
    public enum BatchAutoUserScope
    {
        Task = 0,
        Pool = 1,
    }
    public partial class BatchAutoUserSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>
    {
        public BatchAutoUserSpecification() { }
        public Azure.ResourceManager.Batch.Models.BatchUserAccountElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchAutoUserScope? Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchBlobFileSystemConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>
    {
        public BatchBlobFileSystemConfiguration(string accountName, string containerName, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string BlobfuseOptions { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchCertificateReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>
    {
        public BatchCertificateReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchCertificateStoreLocation? StoreLocation { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchCertificateVisibility> Visibility { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchCertificateReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchCertificateReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCertificateReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchCertificateStoreLocation
    {
        CurrentUser = 0,
        LocalMachine = 1,
    }
    public enum BatchCertificateVisibility
    {
        StartTask = 0,
        Task = 1,
        RemoteUser = 2,
    }
    public partial class BatchCifsMountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>
    {
        public BatchCifsMountConfiguration(string username, string source, string relativeMountPath, string password) { }
        public string MountOptions { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchContainerWorkingDirectory
    {
        TaskWorkingDirectory = 0,
        ContainerImageDefault = 1,
    }
    public partial class BatchDeploymentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>
    {
        public BatchDeploymentConfiguration() { }
        public Azure.ResourceManager.Batch.Models.BatchVmConfiguration VmConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchDeploymentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchDiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchDiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement CacheDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement left, Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement left, Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum BatchDiskCachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public enum BatchDiskEncryptionTarget
    {
        OSDisk = 0,
        TemporaryDisk = 1,
    }
    public enum BatchEndpointAccessDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchEndpointAccessProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>
    {
        public BatchEndpointAccessProfile(Azure.ResourceManager.Batch.Models.BatchEndpointAccessDefaultAction defaultAction) { }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchIPRule> IPRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>
    {
        internal BatchEndpointDetail() { }
        public int? Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchEnvironmentSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>
    {
        public BatchEnvironmentSetting(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchEnvironmentSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchFileShareConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>
    {
        public BatchFileShareConfiguration(string accountName, System.Uri fileUri, string accountKey, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public System.Uri FileUri { get { throw null; } set { } }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchImageReference>
    {
        public BatchImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchInboundEndpointProtocol
    {
        Tcp = 0,
        Udp = 1,
    }
    public partial class BatchInboundNatPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>
    {
        public BatchInboundNatPool(string name, Azure.ResourceManager.Batch.Models.BatchInboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPortRangeEnd { get { throw null; } set { } }
        public int FrontendPortRangeStart { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchInboundEndpointProtocol Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchInboundNatPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchInboundNatPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchInboundNatPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchIPAddressProvisioningType
    {
        BatchManaged = 0,
        UserManaged = 1,
        NoPublicIPAddresses = 2,
    }
    public partial class BatchIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchIPRule>
    {
        public BatchIPRule(string value) { }
        public Azure.ResourceManager.Batch.Models.BatchIPRuleAction Action { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchIPRuleAction : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchIPRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchIPRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchIPRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchIPRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchIPRuleAction left, Azure.ResourceManager.Batch.Models.BatchIPRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchIPRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchIPRuleAction left, Azure.ResourceManager.Batch.Models.BatchIPRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchIssueType : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchIssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchIssueType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchIssueType ConfigurationPropagationFailure { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchIssueType MissingIdentityConfiguration { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchIssueType MissingPerimeterConfiguration { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchIssueType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchIssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchIssueType left, Azure.ResourceManager.Batch.Models.BatchIssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchIssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchIssueType left, Azure.ResourceManager.Batch.Models.BatchIssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchKeyVaultReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>
    {
        public BatchKeyVaultReference(Azure.Core.ResourceIdentifier id, System.Uri uri) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchKeyVaultReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchKeyVaultReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchKeyVaultReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchLinuxUserConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>
    {
        public BatchLinuxUserConfiguration() { }
        public int? Gid { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        public int? Uid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchLocationQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>
    {
        internal BatchLocationQuota() { }
        public int? AccountQuota { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchLocationQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchLocationQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchLocationQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchMountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>
    {
        public BatchMountConfiguration() { }
        public Azure.ResourceManager.Batch.Models.BatchBlobFileSystemConfiguration BlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchCifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchFileShareConfiguration FileShareConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchMountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchMountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchMountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>
    {
        public BatchNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>
    {
        internal BatchNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class BatchNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>
    {
        public BatchNetworkConfiguration() { }
        public Azure.ResourceManager.Batch.Models.DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchInboundNatPool> EndpointInboundNatPools { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>
    {
        public BatchNetworkProfile() { }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile AccountAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchEndpointAccessProfile NodeManagementAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchNetworkSecurityGroupRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>
    {
        public BatchNetworkSecurityGroupRule(int priority, Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRuleAccess access, string sourceAddressPrefix) { }
        public Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRuleAccess Access { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNetworkSecurityGroupRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchNetworkSecurityGroupRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class BatchNfsMountConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>
    {
        public BatchNfsMountConfiguration(string source, string relativeMountPath) { }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchNfsMountConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchNodeDeallocationOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public enum BatchNodeFillType
    {
        Spread = 0,
        Pack = 1,
    }
    public enum BatchNodePlacementPolicyType
    {
        Regional = 0,
        Zonal = 1,
    }
    public partial class BatchOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>
    {
        public BatchOSDisk() { }
        public Azure.ResourceManager.Batch.Models.BatchDiskCachingType? Caching { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement? EphemeralOSDiskPlacement { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.ManagedDisk ManagedDisk { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Batch.Models.BatchPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>
    {
        public BatchPrivateLinkServiceConnectionState(Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus status) { }
        public string ActionRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchPrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class BatchProvisioningIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>
    {
        internal BatchProvisioningIssue() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchProvisioningIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchProvisioningIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchProvisioningIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>
    {
        internal BatchProvisioningIssueProperties() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchIssueType? IssueType { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAccessRule> SuggestedAccessRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchProvisioningIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchProvisioningState left, Azure.ResourceManager.Batch.Models.BatchProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchProvisioningState left, Azure.ResourceManager.Batch.Models.BatchProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>
    {
        public BatchPublicIPAddressConfiguration() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IPAddressIds { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchIPAddressProvisioningType? Provision { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
        SecuredByPerimeter = 2,
    }
    public partial class BatchResizeOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>
    {
        internal BatchResizeOperationStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchNodeDeallocationOption? NodeDeallocationOption { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public int? TargetDedicatedNodes { get { throw null; } }
        public int? TargetLowPriorityNodes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResizeOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchResourceAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>
    {
        internal BatchResourceAssociation() { }
        public Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode? AccessMode { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResourceAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResourceAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchResourceFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>
    {
        public BatchResourceFile() { }
        public string AutoBlobContainerName { get { throw null; } set { } }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
        public string FileMode { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public System.Uri HttpUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResourceFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchResourceFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchResourceFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchSecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchSecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType left, Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType left, Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>
    {
        public BatchSecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchSecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchUefiSettings UefiSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchSecurityType
    {
        TrustedLaunch = 0,
        ConfidentialVm = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchSeverity : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchSeverity left, Azure.ResourceManager.Batch.Models.BatchSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchSeverity left, Azure.ResourceManager.Batch.Models.BatchSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>
    {
        internal BatchSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchStorageAccountType
    {
        StandardLrs = 0,
        PremiumLrs = 1,
        StandardSsdLrs = 2,
    }
    public partial class BatchSupportedSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>
    {
        internal BatchSupportedSku() { }
        public System.DateTimeOffset? BatchSupportEndOfLife { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchSkuCapability> Capabilities { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSupportedSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchSupportedSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchSupportedSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchTaskContainerSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>
    {
        public BatchTaskContainerSettings(string imageName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry> ContainerHostBatchBindMounts { get { throw null; } }
        public string ContainerRunOptions { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry Registry { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchContainerWorkingDirectory? WorkingDirectory { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchTaskContainerSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchUefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>
    {
        public BatchUefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVTpmEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchUserAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>
    {
        public BatchUserAccount(string name, string password) { }
        public Azure.ResourceManager.Batch.Models.BatchUserAccountElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchLinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchWindowsLoginMode? WindowsUserLoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUserAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUserAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchUserAccountElevationLevel
    {
        NonAdmin = 0,
        Admin = 1,
    }
    public partial class BatchUserIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>
    {
        public BatchUserIdentity() { }
        public Azure.ResourceManager.Batch.Models.BatchAutoUserSpecification AutoUser { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUserIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchUserIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchUserIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchVmConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>
    {
        public BatchVmConfiguration(Azure.ResourceManager.Batch.Models.BatchImageReference imageReference, string nodeAgentSkuId) { }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmDataDisk> DataDisks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchDiskEncryptionTarget> DiskEncryptionTargets { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchDiffDiskPlacement? EphemeralOSDiskPlacement { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchImageReference ImageReference { get { throw null; } set { } }
        public bool? IsAutomaticUpdateEnabled { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public string NodeAgentSkuId { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchNodePlacementPolicyType? NodePlacementPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchOSDisk OSDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchVmContainerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>
    {
        public BatchVmContainerConfiguration() { }
        public BatchVmContainerConfiguration(Azure.ResourceManager.Batch.Models.BatchVmContainerType containerType) { }
        public System.Collections.Generic.IList<string> ContainerImageNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry> ContainerRegistries { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchVmContainerType ContainerType { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchVmContainerRegistry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>
    {
        public BatchVmContainerRegistry() { }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RegistryServer { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmContainerRegistry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BatchVmContainerType : System.IEquatable<Azure.ResourceManager.Batch.Models.BatchVmContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BatchVmContainerType(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.BatchVmContainerType CriCompatible { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.BatchVmContainerType DockerCompatible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.BatchVmContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.BatchVmContainerType left, Azure.ResourceManager.Batch.Models.BatchVmContainerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.BatchVmContainerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.BatchVmContainerType left, Azure.ResourceManager.Batch.Models.BatchVmContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchVmDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>
    {
        public BatchVmDataDisk(int lun, int diskSizeInGB) { }
        public Azure.ResourceManager.Batch.Models.BatchDiskCachingType? Caching { get { throw null; } set { } }
        public int DiskSizeInGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchVmExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>
    {
        public BatchVmExtension(string name, string publisher, string extensionType) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchVmFamilyCoreQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>
    {
        internal BatchVmFamilyCoreQuota() { }
        public int? CoreQuota { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.BatchVmFamilyCoreQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BatchWindowsLoginMode
    {
        Batch = 0,
        Interactive = 1,
    }
    public partial class ContainerHostBatchBindMountEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>
    {
        public ContainerHostBatchBindMountEntry() { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.ContainerHostDataPath? Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ContainerHostBatchBindMountEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerHostDataPath : System.IEquatable<Azure.ResourceManager.Batch.Models.ContainerHostDataPath>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerHostDataPath(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath Applications { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath JobPrep { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath Shared { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath Startup { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath Task { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ContainerHostDataPath VfsMounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.ContainerHostDataPath other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.ContainerHostDataPath left, Azure.ResourceManager.Batch.Models.ContainerHostDataPath right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.ContainerHostDataPath (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.ContainerHostDataPath left, Azure.ResourceManager.Batch.Models.ContainerHostDataPath right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DynamicVNetAssignmentScope
    {
        None = 0,
        Job = 1,
    }
    public enum InterNodeCommunicationState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ManagedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ManagedDisk>
    {
        public ManagedDisk() { }
        public Azure.ResourceManager.Batch.Models.BatchSecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.BatchStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.ManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.ManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.ManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.ManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>
    {
        internal NetworkSecurityPerimeter() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Guid? PerimeterGuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>
    {
        internal NetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NetworkSecurityProfile Profile { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Batch.Models.BatchResourceAssociation ResourceAssociation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Batch.Models.NetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>
    {
        internal NetworkSecurityProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Batch.Models.BatchAccessRule> AccessRules { get { throw null; } }
        public int? AccessRulesVersion { get { throw null; } }
        public int? DiagnosticSettingsVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledLogCategories { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.NetworkSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.NetworkSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum NodeCommunicationMode
    {
        Default = 0,
        Classic = 1,
        Simplified = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceAssociationAccessMode : System.IEquatable<Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceAssociationAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode Audit { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode Enforced { get { throw null; } }
        public static Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode Learning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode left, Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode left, Azure.ResourceManager.Batch.Models.ResourceAssociationAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RollingUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>
    {
        public RollingUpgradePolicy() { }
        public bool? EnableCrossZoneUpgrade { get { throw null; } set { } }
        public int? MaxBatchInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public string PauseTimeBetweenBatches { get { throw null; } set { } }
        public bool? PrioritizeUnhealthyInstances { get { throw null; } set { } }
        public bool? RollbackFailedInstancesOnPolicyBreach { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.RollingUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.RollingUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.RollingUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum UpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class UpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>
    {
        public UpgradePolicy(Azure.ResourceManager.Batch.Models.UpgradeMode mode) { }
        public Azure.ResourceManager.Batch.Models.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.UpgradeMode Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Batch.Models.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.UpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Batch.Models.UpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Batch.Models.UpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
