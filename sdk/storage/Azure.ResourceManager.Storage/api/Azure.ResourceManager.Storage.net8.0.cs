namespace Azure.ResourceManager.Storage
{
    public partial class AzureResourceManagerStorageContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerStorageContext() { }
        public static Azure.ResourceManager.Storage.AzureResourceManagerStorageContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BlobContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>, System.Collections.IEnumerable
    {
        protected BlobContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAll(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.BlobContainerState? include = default(Azure.ResourceManager.Storage.Models.BlobContainerState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAll(string maxpagesize, string filter, Azure.ResourceManager.Storage.Models.BlobContainerState? include, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.BlobContainerState? include = default(Azure.ResourceManager.Storage.Models.BlobContainerState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAllAsync(string maxpagesize, string filter, Azure.ResourceManager.Storage.Models.BlobContainerState? include, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.BlobContainerResource> GetIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.BlobContainerResource>> GetIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>
    {
        public BlobContainerData() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? EnableNfsV3AllSquash { get { throw null; } set { } }
        public bool? EnableNfsV3RootSquash { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy ImmutabilityPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public bool? PreventEncryptionScopeOverride { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StoragePublicAccessType? PublicAccess { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlobContainerResource() { }
        public virtual Azure.ResourceManager.Storage.BlobContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold> ClearLegalHold(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold>> ClearLegalHoldAsync(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableVersionLevelImmutability(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableVersionLevelImmutabilityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse> Lease(Azure.ResourceManager.Storage.Models.LeaseContainerContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>> LeaseAsync(Azure.ResourceManager.Storage.Models.LeaseContainerContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold> SetLegalHold(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold>> SetLegalHoldAsync(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.BlobContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Update(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> UpdateAsync(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobInventoryPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>
    {
        public BlobInventoryPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema PolicySchema { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobInventoryPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobInventoryPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobInventoryPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlobInventoryPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.BlobInventoryPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobInventoryPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobInventoryPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>
    {
        public BlobServiceData() { }
        public Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed ChangeFeed { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
        public string DefaultServiceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public bool? IsAutomaticSnapshotPolicyEnabled { get { throw null; } set { } }
        public bool? IsVersioningEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy LastAccessTimeTrackingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RestorePolicy RestorePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlobServiceResource() { }
        public virtual Azure.ResourceManager.Storage.BlobServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> GetBlobContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetBlobContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobContainerCollection GetBlobContainers() { throw null; }
        Azure.ResourceManager.Storage.BlobServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.BlobServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.BlobServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.BlobServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedAccountCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> Get(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.DeletedAccountResource> GetIfExists(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.DeletedAccountResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAccountData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>
    {
        public DeletedAccountData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string RestoreReference { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.DeletedAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.DeletedAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedAccountResource() { }
        public virtual Azure.ResourceManager.Storage.DeletedAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string deletedAccountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.DeletedAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.DeletedAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.DeletedAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.DeletedAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>, System.Collections.IEnumerable
    {
        protected EncryptionScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.EncryptionScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string encryptionScopeName, Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.EncryptionScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string encryptionScopeName, Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> Get(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAll(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType? include = default(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType? include = default(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.EncryptionScopeResource> GetIfExists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetIfExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionScopeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>
    {
        public EncryptionScopeData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.EncryptionScopeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.EncryptionScopeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionScopeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EncryptionScopeResource() { }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string encryptionScopeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.EncryptionScopeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.EncryptionScopeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.EncryptionScopeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> Update(Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> UpdateAsync(Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>
    {
        public FileServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SmbSetting ProtocolSmbSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ShareDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileServiceResource() { }
        public virtual Azure.ResourceManager.Storage.FileServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.FileServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.FileServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileServiceUsageResource GetFileServiceUsage() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> GetFileShare(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> GetFileShareAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileShareCollection GetFileShares() { throw null; }
        Azure.ResourceManager.Storage.FileServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceUsageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>
    {
        public FileServiceUsageData() { }
        public Azure.ResourceManager.Storage.Models.FileServiceUsageProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceUsageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceUsageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceUsageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileServiceUsageResource() { }
        public virtual Azure.ResourceManager.Storage.FileServiceUsageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileServiceUsageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileServiceUsageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.FileServiceUsageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileServiceUsageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileServiceUsageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShareResource>, System.Collections.IEnumerable
    {
        protected FileShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.Storage.FileShareData data, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.Storage.FileShareData data, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> Get(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.FileShareResource> GetAll(int? maxpagesize = default(int?), string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.FileShareResource> GetAll(string maxpagesize, string filter, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.FileShareResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.FileShareResource> GetAllAsync(string maxpagesize, string filter, string expand, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> GetAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.FileShareResource> GetIfExists(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.FileShareResource>> GetIfExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.FileShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.FileShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileShareData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>
    {
        public FileShareData() { }
        public Azure.ResourceManager.Storage.Models.FileShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeOn { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol? EnabledProtocol { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting FileSharePaidBursting { get { throw null; } set { } }
        public int? IncludedBurstIops { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseStatus? LeaseStatus { get { throw null; } }
        public long? MaxBurstCreditsForIops { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.DateTimeOffset? NextAllowedProvisionedBandwidthDowngradeOn { get { throw null; } }
        public System.DateTimeOffset? NextAllowedProvisionedIopsDowngradeOn { get { throw null; } }
        public System.DateTimeOffset? NextAllowedQuotaDowngradeOn { get { throw null; } }
        public int? ProvisionedBandwidthMibps { get { throw null; } set { } }
        public int? ProvisionedIops { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier> SignedIdentifiers { get { throw null; } }
        public System.DateTimeOffset? SnapshotOn { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileShareResource() { }
        public virtual Azure.ResourceManager.Storage.FileShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string xMsSnapshot = null, string include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string xMsSnapshot = null, string include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> Get(string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> GetAsync(string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LeaseShareResponse> Lease(Azure.ResourceManager.Storage.Models.LeaseShareContent content = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LeaseShareResponse>> LeaseAsync(Azure.ResourceManager.Storage.Models.LeaseShareContent content = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restore(Azure.ResourceManager.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestoreAsync(Azure.ResourceManager.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.FileShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.FileShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.FileShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.FileShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> Update(Azure.ResourceManager.Storage.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> UpdateAsync(Azure.ResourceManager.Storage.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImmutabilityPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>
    {
        public ImmutabilityPolicyData() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ImmutabilityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ImmutabilityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImmutabilityPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImmutabilityPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ImmutabilityPolicyData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ImmutabilityPolicyData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> ExtendImmutabilityPolicy(Azure.ETag ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> ExtendImmutabilityPolicyAsync(Azure.ETag ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> Get(Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> GetAsync(Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> LockImmutabilityPolicy(Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> LockImmutabilityPolicyAsync(Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.ImmutabilityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ImmutabilityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ImmutabilityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> Get(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>> GetAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> GetIfExists(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>
    {
        internal NetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile Profile { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation ResourceAssociation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string networkSecurityPerimeterConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectReplicationPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>, System.Collections.IEnumerable
    {
        protected ObjectReplicationPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string objectReplicationPolicyId, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string objectReplicationPolicyId, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> Get(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> GetAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> GetIfExists(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> GetIfExistsAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ObjectReplicationPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>
    {
        public ObjectReplicationPolicyData() { }
        public string DestinationAccount { get { throw null; } set { } }
        public System.DateTimeOffset? EnabledOn { get { throw null; } }
        public bool? IsMetricsEnabled { get { throw null; } set { } }
        public string PolicyId { get { throw null; } }
        public bool? PriorityReplicationEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> Rules { get { throw null; } }
        public string SourceAccount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ObjectReplicationPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ObjectReplicationPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectReplicationPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ObjectReplicationPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.ObjectReplicationPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string objectReplicationPolicyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.ObjectReplicationPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.ObjectReplicationPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.ObjectReplicationPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>
    {
        public QueueServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.QueueServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.QueueServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueueServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueueServiceResource() { }
        public virtual Azure.ResourceManager.Storage.QueueServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.QueueServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.QueueServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.QueueServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.QueueServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.QueueServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.QueueServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource> GetStorageQueue(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> GetStorageQueueAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageQueueCollection GetStorageQueues() { throw null; }
        Azure.ResourceManager.Storage.QueueServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.QueueServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.QueueServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.QueueServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>, System.Collections.IEnumerable
    {
        protected StorageAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> Get(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountResource> GetIfExists(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountResource>> GetIfExistsAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>
    {
        public StorageAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? AccessTier { get { throw null; } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreStatus BlobRestoreStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageCustomDomain CustomDomain { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? DnsEndpointType { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryption Encryption { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.GeoReplicationStatistics GeoReplicationStats { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsAccountMigrationInProgress { get { throw null; } }
        public bool? IsBlobEnabled { get { throw null; } set { } }
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? IsExtendedGroupEnabled { get { throw null; } set { } }
        public bool? IsFailoverInProgress { get { throw null; } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public bool? IsIPv6EndpointToBePublished { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsNfsV3Enabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public bool? IsSkuConversionBlocked { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime KeyCreationTime { get { throw null; } }
        public int? KeyExpirationPeriodInDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public System.DateTimeOffset? LastGeoFailoverOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet NetworkRuleSet { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEndpoints PrimaryEndpoints { get { throw null; } }
        public Azure.Core.AzureLocation? PrimaryLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Storage.Models.StorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy SasPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEndpoints SecondaryEndpoints { get { throw null; } }
        public Azure.Core.AzureLocation? SecondaryLocation { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountStatus? StatusOfPrimary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountStatus? StatusOfSecondary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? StorageAccountProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountLocalUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>, System.Collections.IEnumerable
    {
        protected StorageAccountLocalUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> Get(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAll(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam? include = default(Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam? include = default(Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> GetAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetIfExists(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> GetIfExistsAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountLocalUserData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>
    {
        public StorageAccountLocalUserData() { }
        public System.Collections.Generic.IList<int> ExtendedGroups { get { throw null; } }
        public int? GroupId { get { throw null; } set { } }
        public bool? HasSharedKey { get { throw null; } set { } }
        public bool? HasSshKey { get { throw null; } set { } }
        public bool? HasSshPassword { get { throw null; } set { } }
        public string HomeDirectory { get { throw null; } set { } }
        public bool? IsAclAuthorizationAllowed { get { throw null; } set { } }
        public bool? IsNfsV3Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StoragePermissionScope> PermissionScopes { get { throw null; } }
        public string Sid { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } }
        public int? UserId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountLocalUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountLocalUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountLocalUserResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountLocalUserResource() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountLocalUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string username) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult> RegeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>> RegeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageAccountLocalUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountLocalUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountLocalUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountManagementPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>
    {
        public StorageAccountManagementPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> Rules { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountManagementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountManagementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountManagementPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountManagementPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.Storage.Models.ManagementPolicyName managementPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageAccountManagementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountManagementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountManagementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountMigrationCollection : Azure.ResourceManager.ArmCollection
    {
        protected StorageAccountMigrationCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource> Get(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource>> GetAsync(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountMigrationResource> GetIfExists(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StorageAccountMigrationResource>> GetIfExistsAsync(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountMigrationData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>
    {
        public StorageAccountMigrationData(Azure.ResourceManager.Storage.Models.StorageSkuName targetSkuName) { }
        public string Id { get { throw null; } }
        public string MigrationFailedDetailedReason { get { throw null; } }
        public string MigrationFailedReason { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus? MigrationStatus { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName TargetSkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountMigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountMigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountMigrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountMigrationResource() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountMigrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageAccountMigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountMigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountMigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountResource() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AbortHierarchicalNamespaceMigration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AbortHierarchicalNamespaceMigrationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CustomerInitiatedMigration(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountMigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CustomerInitiatedMigrationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountMigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableHierarchicalNamespace(Azure.WaitUntil waitUntil, string requestType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableHierarchicalNamespaceAsync(Azure.WaitUntil waitUntil, string requestType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.StorageAccountFailoverType? failoverType = default(Azure.ResourceManager.Storage.Models.StorageAccountFailoverType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.StorageAccountFailoverType? failoverType = default(Azure.ResourceManager.Storage.Models.StorageAccountFailoverType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> Get(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.GetAccountSasResult> GetAccountSas(Azure.ResourceManager.Storage.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.GetAccountSasResult>> GetAccountSasAsync(Azure.ResourceManager.Storage.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetAsync(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyResource GetBlobInventoryPolicy() { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobServiceResource GetBlobService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> GetEncryptionScope(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetEncryptionScopeAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeCollection GetEncryptionScopes() { throw null; }
        public virtual Azure.ResourceManager.Storage.FileServiceResource GetFileService() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageAccountKey> GetKeys(Azure.ResourceManager.Storage.Models.StorageListKeyExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageListKeyExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageAccountKey> GetKeysAsync(Azure.ResourceManager.Storage.Models.StorageListKeyExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageListKeyExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource> GetNetworkSecurityPerimeterConfiguration(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource>> GetNetworkSecurityPerimeterConfigurationAsync(string networkSecurityPerimeterConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationCollection GetNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.ResourceManager.Storage.ObjectReplicationPolicyCollection GetObjectReplicationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> GetObjectReplicationPolicy(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> GetObjectReplicationPolicyAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.QueueServiceResource GetQueueService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.GetServiceSasResult> GetServiceSas(Azure.ResourceManager.Storage.Models.ServiceSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.GetServiceSasResult>> GetServiceSasAsync(Azure.ResourceManager.Storage.Models.ServiceSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetStorageAccountLocalUser(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> GetStorageAccountLocalUserAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountLocalUserCollection GetStorageAccountLocalUsers() { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource GetStorageAccountManagementPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource> GetStorageAccountMigration(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountMigrationResource>> GetStorageAccountMigrationAsync(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountMigrationCollection GetStorageAccountMigrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetStoragePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetStoragePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionCollection GetStoragePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> GetStorageTaskAssignment(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> GetStorageTaskAssignmentAsync(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageTaskAssignmentCollection GetStorageTaskAssignments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance> GetStorageTaskAssignmentsInstancesReports(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance> GetStorageTaskAssignmentsInstancesReportsAsync(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.TableServiceResource GetTableService() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageAccountKey> RegenerateKey(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageAccountKey> RegenerateKeyAsync(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountRestoreBlobRangesOperation RestoreBlobRanges(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.StorageAccountRestoreBlobRangesOperation> RestoreBlobRangesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeUserDelegationKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeUserDelegationKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> Update(Azure.ResourceManager.Storage.Models.StorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> UpdateAsync(Azure.ResourceManager.Storage.Models.StorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountRestoreBlobRangesOperation : Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>
    {
        protected StorageAccountRestoreBlobRangesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.Models.BlobRestoreStatus Value { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.BlobRestoreStatus GetCurrentStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.ValueTask<Azure.ResourceManager.Storage.Models.BlobRestoreStatus> GetCurrentStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.BlobContainerResource GetBlobContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobInventoryPolicyResource GetBlobInventoryPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobServiceResource GetBlobServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetDeletedAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountResource GetDeletedAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountCollection GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.EncryptionScopeResource GetEncryptionScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileServiceResource GetFileServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileServiceUsageResource GetFileServiceUsageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileShareResource GetFileShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.QueueServiceResource GetQueueServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetStorageAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountLocalUserResource GetStorageAccountLocalUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource GetStorageAccountManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountMigrationResource GetStorageAccountMigrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountResource GetStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource GetStoragePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageQueueResource GetStorageQueueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageTaskAssignmentResource GetStorageTaskAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.TableResource GetTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.TableServiceResource GetTableServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StoragePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected StoragePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StoragePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>
    {
        public StoragePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StoragePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageQueueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>, System.Collections.IEnumerable
    {
        protected StorageQueueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageQueueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string queueName, Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageQueueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string queueName, Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource> Get(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAll(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAll(string maxpagesize, string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAllAsync(string maxpagesize, string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> GetAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StorageQueueResource> GetIfExists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StorageQueueResource>> GetIfExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageQueueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageQueueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageQueueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>
    {
        public StorageQueueData() { }
        public int? ApproximateMessageCount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageQueueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageQueueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageQueueResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageQueueResource() { }
        public virtual Azure.ResourceManager.Storage.StorageQueueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string queueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageQueueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageQueueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageQueueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageQueueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource> Update(Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> UpdateAsync(Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTaskAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>, System.Collections.IEnumerable
    {
        protected StorageTaskAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageTaskAssignmentName, Azure.ResourceManager.Storage.StorageTaskAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageTaskAssignmentName, Azure.ResourceManager.Storage.StorageTaskAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> Get(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> GetAsync(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> GetIfExists(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> GetIfExistsAsync(string storageTaskAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageTaskAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>
    {
        public StorageTaskAssignmentData(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties properties) { }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageTaskAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageTaskAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageTaskAssignmentResource() { }
        public virtual Azure.ResourceManager.Storage.StorageTaskAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string storageTaskAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReports(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance> GetStorageTaskAssignmentInstancesReportsAsync(int? maxpagesize = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.StorageTaskAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.StorageTaskAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.StorageTaskAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageTaskAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageTaskAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.TableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.TableResource>, System.Collections.IEnumerable
    {
        protected TableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.TableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.TableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Storage.TableResource> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Storage.TableResource>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.TableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.TableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.TableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.TableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TableData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>
    {
        public TableData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier> SignedIdentifiers { get { throw null; } }
        public string TableName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TableResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TableResource() { }
        public virtual Azure.ResourceManager.Storage.TableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string tableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Storage.TableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> Update(Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> UpdateAsync(Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>
    {
        public TableServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TableServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TableServiceResource() { }
        public virtual Azure.ResourceManager.Storage.TableServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.TableServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.TableServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> GetTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> GetTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.TableCollection GetTables() { throw null; }
        Azure.ResourceManager.Storage.TableServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.TableServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.TableServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.TableServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Storage.Mocking
{
    public partial class MockableStorageArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageArmClient() { }
        public virtual Azure.ResourceManager.Storage.BlobContainerResource GetBlobContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyResource GetBlobInventoryPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobServiceResource GetBlobServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.DeletedAccountResource GetDeletedAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeResource GetEncryptionScopeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileServiceResource GetFileServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileServiceUsageResource GetFileServiceUsageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileShareResource GetFileShareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.QueueServiceResource GetQueueServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountLocalUserResource GetStorageAccountLocalUserResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource GetStorageAccountManagementPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountMigrationResource GetStorageAccountMigrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountResource GetStorageAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource GetStoragePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageQueueResource GetStorageQueueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageTaskAssignmentResource GetStorageTaskAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.TableResource GetTableResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Storage.TableServiceResource GetTableServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableStorageResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccount(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetStorageAccountAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts() { throw null; }
    }
    public partial class MockableStorageSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableStorageSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccount(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetDeletedAccountAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.DeletedAccountCollection GetDeletedAccounts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountImmutabilityPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>
    {
        public AccountImmutabilityPolicy() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountImmutabilityPolicyState : System.IEquatable<Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountImmutabilityPolicyState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState Locked { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState left, Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState left, Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccountSasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountSasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountSasContent>
    {
        public AccountSasContent(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService services, Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType resourceTypes, Azure.ResourceManager.Storage.Models.StorageAccountSasPermission permissions, System.DateTimeOffset sharedAccessExpireOn) { }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPermission Permissions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService Services { get { throw null; } }
        public System.DateTimeOffset SharedAccessExpireOn { get { throw null; } }
        public System.DateTimeOffset? SharedAccessStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.AccountSasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountSasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.AccountSasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.AccountSasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountSasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountSasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.AccountSasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveDirectoryAccountType : System.IEquatable<Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveDirectoryAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType Computer { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType left, Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType left, Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedCopyScope : System.IEquatable<Azure.ResourceManager.Storage.Models.AllowedCopyScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedCopyScope(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.AllowedCopyScope Aad { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.AllowedCopyScope PrivateLink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.AllowedCopyScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.AllowedCopyScope left, Azure.ResourceManager.Storage.Models.AllowedCopyScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.AllowedCopyScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.AllowedCopyScope left, Azure.ResourceManager.Storage.Models.AllowedCopyScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmStorageModelFactory
    {
        public static Azure.ResourceManager.Storage.Models.AccountSasContent AccountSasContent(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService services = default(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService), Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType resourceTypes = default(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType), Azure.ResourceManager.Storage.Models.StorageAccountSasPermission permissions = default(Azure.ResourceManager.Storage.Models.StorageAccountSasPermission), string ipAddressOrRange = null, Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol? protocols = default(Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol?), System.DateTimeOffset? sharedAccessStartOn = default(System.DateTimeOffset?), System.DateTimeOffset sharedAccessExpireOn = default(System.DateTimeOffset), string keyToSign = null) { throw null; }
        public static Azure.ResourceManager.Storage.BlobContainerData BlobContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null, bool? isDeleted = default(bool?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), int? remainingRetentionDays = default(int?), string defaultEncryptionScope = null, bool? preventEncryptionScopeOverride = default(bool?), Azure.ResourceManager.Storage.Models.StoragePublicAccessType? publicAccess = default(Azure.ResourceManager.Storage.Models.StoragePublicAccessType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.StorageLeaseStatus? leaseStatus = default(Azure.ResourceManager.Storage.Models.StorageLeaseStatus?), Azure.ResourceManager.Storage.Models.StorageLeaseState? leaseState = default(Azure.ResourceManager.Storage.Models.StorageLeaseState?), Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? leaseDuration = default(Azure.ResourceManager.Storage.Models.StorageLeaseDurationType?), System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy immutabilityPolicy = null, Azure.ResourceManager.Storage.Models.LegalHoldProperties legalHold = null, bool? hasLegalHold = default(bool?), bool? hasImmutabilityPolicy = default(bool?), Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning immutableStorageWithVersioning = null, bool? enableNfsV3RootSquash = default(bool?), bool? enableNfsV3AllSquash = default(bool?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy BlobContainerImmutabilityPolicy(Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry> updateHistory = null, int? immutabilityPeriodSinceCreationInDays = default(int?), Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? state = default(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState?), bool? allowProtectedAppendWrites = default(bool?), bool? allowProtectedAppendWritesAll = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Storage.BlobInventoryPolicyData BlobInventoryPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema policySchema = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema BlobInventoryPolicySchema(bool isEnabled = false, string destination = null, Azure.ResourceManager.Storage.Models.BlobInventoryRuleType ruleType = default(Azure.ResourceManager.Storage.Models.BlobInventoryRuleType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> rules = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobRestoreStatus BlobRestoreStatus(Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus? status = default(Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus?), string failureReason = null, string restoreId = null, Azure.ResourceManager.Storage.Models.BlobRestoreContent parameters = null) { throw null; }
        public static Azure.ResourceManager.Storage.BlobServiceData BlobServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.StorageSku sku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageCorsRule> corsRules = null, string defaultServiceVersion = null, Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy deleteRetentionPolicy = null, bool? isVersioningEnabled = default(bool?), bool? isAutomaticSnapshotPolicyEnabled = default(bool?), Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed changeFeed = null, Azure.ResourceManager.Storage.Models.RestorePolicy restorePolicy = null, Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy containerDeleteRetentionPolicy = null, Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy lastAccessTimeTrackingPolicy = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BurstingConstants BurstingConstants(int? burstFloorIops = default(int?), double? burstIOScalar = default(double?), int? burstTimeframeSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountData DeletedAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier storageAccountResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string restoreReference = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.EncryptionScopeData EncryptionScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.EncryptionScopeSource? source = default(Azure.ResourceManager.Storage.Models.EncryptionScopeSource?), Azure.ResourceManager.Storage.Models.EncryptionScopeState? state = default(Azure.ResourceManager.Storage.Models.EncryptionScopeState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties keyVaultProperties = null, bool? requireInfrastructureEncryption = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties EncryptionScopeKeyVaultProperties(System.Uri keyUri = null, string currentVersionedKeyIdentifier = null, System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileServiceAccountLimits FileServiceAccountLimits(int? maxFileShares = default(int?), int? maxProvisionedStorageGiB = default(int?), int? maxProvisionedIops = default(int?), int? maxProvisionedBandwidthMiBPerSec = default(int?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileServiceAccountUsage FileServiceAccountUsage(Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements liveShares = null, Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements softDeletedShares = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements FileServiceAccountUsageElements(int? fileShareCount = default(int?), int? provisionedStorageGiB = default(int?), int? provisionedIops = default(int?), int? provisionedBandwidthMiBPerSec = default(int?)) { throw null; }
        public static Azure.ResourceManager.Storage.FileServiceData FileServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.StorageSku sku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageCorsRule> corsRules = null, Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy shareDeleteRetentionPolicy = null, Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings protocolSettings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.FileServiceData FileServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Storage.Models.StorageSku sku, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageCorsRule> corsRules, Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy shareDeleteRetentionPolicy, Azure.ResourceManager.Storage.Models.SmbSetting protocolSmbSetting) { throw null; }
        public static Azure.ResourceManager.Storage.FileServiceUsageData FileServiceUsageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.FileServiceUsageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileServiceUsageProperties FileServiceUsageProperties(Azure.ResourceManager.Storage.Models.FileServiceAccountLimits storageAccountLimits = null, Azure.ResourceManager.Storage.Models.FileShareLimits fileShareLimits = null, Azure.ResourceManager.Storage.Models.FileShareRecommendations fileShareRecommendations = null, Azure.ResourceManager.Storage.Models.BurstingConstants burstingConstants = null, Azure.ResourceManager.Storage.Models.FileServiceAccountUsage storageAccountUsage = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.FileShareData FileShareData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.DateTimeOffset? lastModifiedOn, System.Collections.Generic.IDictionary<string, string> metadata, int? shareQuota, Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol? enabledProtocol, Azure.ResourceManager.Storage.Models.RootSquashType? rootSquash, string version, bool? isDeleted, System.DateTimeOffset? deletedOn, int? remainingRetentionDays, Azure.ResourceManager.Storage.Models.FileShareAccessTier? accessTier, System.DateTimeOffset? accessTierChangeOn, string accessTierStatus, long? shareUsageBytes, Azure.ResourceManager.Storage.Models.StorageLeaseStatus? leaseStatus, Azure.ResourceManager.Storage.Models.StorageLeaseState? leaseState, Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? leaseDuration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier> signedIdentifiers, System.DateTimeOffset? snapshotOn, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.Storage.FileShareData FileShareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> metadata = null, int? shareQuota = default(int?), int? provisionedIops = default(int?), int? provisionedBandwidthMibps = default(int?), int? includedBurstIops = default(int?), long? maxBurstCreditsForIops = default(long?), System.DateTimeOffset? nextAllowedQuotaDowngradeOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextAllowedProvisionedIopsDowngradeOn = default(System.DateTimeOffset?), System.DateTimeOffset? nextAllowedProvisionedBandwidthDowngradeOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol? enabledProtocol = default(Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol?), Azure.ResourceManager.Storage.Models.RootSquashType? rootSquash = default(Azure.ResourceManager.Storage.Models.RootSquashType?), string version = null, bool? isDeleted = default(bool?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), int? remainingRetentionDays = default(int?), Azure.ResourceManager.Storage.Models.FileShareAccessTier? accessTier = default(Azure.ResourceManager.Storage.Models.FileShareAccessTier?), System.DateTimeOffset? accessTierChangeOn = default(System.DateTimeOffset?), string accessTierStatus = null, long? shareUsageBytes = default(long?), Azure.ResourceManager.Storage.Models.StorageLeaseStatus? leaseStatus = default(Azure.ResourceManager.Storage.Models.StorageLeaseStatus?), Azure.ResourceManager.Storage.Models.StorageLeaseState? leaseState = default(Azure.ResourceManager.Storage.Models.StorageLeaseState?), Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? leaseDuration = default(Azure.ResourceManager.Storage.Models.StorageLeaseDurationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier> signedIdentifiers = null, System.DateTimeOffset? snapshotOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting fileSharePaidBursting = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileShareLimits FileShareLimits(int? minProvisionedStorageGiB = default(int?), int? maxProvisionedStorageGiB = default(int?), int? minProvisionedIops = default(int?), int? maxProvisionedIops = default(int?), int? minProvisionedBandwidthMiBPerSec = default(int?), int? maxProvisionedBandwidthMiBPerSec = default(int?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileShareRecommendations FileShareRecommendations(int? baseIops = default(int?), double? ioScalar = default(double?), int? baseBandwidthMiBPerSec = default(int?), double? bandwidthScalar = default(double?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.GeoReplicationStatistics GeoReplicationStatistics(Azure.ResourceManager.Storage.Models.GeoReplicationStatus? status, System.DateTimeOffset? lastSyncOn, bool? canFailover) { throw null; }
        public static Azure.ResourceManager.Storage.Models.GeoReplicationStatistics GeoReplicationStatistics(Azure.ResourceManager.Storage.Models.GeoReplicationStatus? status = default(Azure.ResourceManager.Storage.Models.GeoReplicationStatus?), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), bool? canFailover = default(bool?), bool? canPlannedFailover = default(bool?), Azure.ResourceManager.Storage.Models.PostFailoverRedundancy? postFailoverRedundancy = default(Azure.ResourceManager.Storage.Models.PostFailoverRedundancy?), Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy? postPlannedFailoverRedundancy = default(Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.GetAccountSasResult GetAccountSasResult(string accountSasToken = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.GetServiceSasResult GetServiceSasResult(string serviceSasToken = null) { throw null; }
        public static Azure.ResourceManager.Storage.ImmutabilityPolicyData ImmutabilityPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? immutabilityPeriodSinceCreationInDays = default(int?), Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? state = default(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState?), bool? allowProtectedAppendWrites = default(bool?), bool? allowProtectedAppendWritesAll = default(bool?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning ImmutableStorageWithVersioning(bool? isEnabled = default(bool?), System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState? migrationState = default(Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerContent LeaseContainerContent(Azure.ResourceManager.Storage.Models.LeaseContainerAction action = default(Azure.ResourceManager.Storage.Models.LeaseContainerAction), string leaseId = null, int? breakPeriod = default(int?), int? leaseDuration = default(int?), string proposedLeaseId = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerResponse LeaseContainerResponse(string leaseId = null, string leaseTimeSeconds = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseShareContent LeaseShareContent(Azure.ResourceManager.Storage.Models.LeaseShareAction action = default(Azure.ResourceManager.Storage.Models.LeaseShareAction), string leaseId = null, int? breakPeriod = default(int?), int? leaseDuration = default(int?), string proposedLeaseId = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseShareResponse LeaseShareResponse(string leaseId = null, string leaseTimeSeconds = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LegalHold LegalHold(bool? hasLegalHold = default(bool?), System.Collections.Generic.IEnumerable<string> tags = null, bool? allowProtectedAppendWritesAll = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LegalHoldProperties LegalHoldProperties(bool? hasLegalHold = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.LegalHoldTag> tags = null, Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory protectedAppendWritesHistory = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LegalHoldTag LegalHoldTag(string tag = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string objectIdentifier = null, System.Guid? tenantId = default(System.Guid?), string upn = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LocalUserKeys LocalUserKeys(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> sshAuthorizedKeys = null, string sharedKey = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult LocalUserRegeneratePasswordResult(string sshPassword = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter NetworkSecurityPerimeter(string id = null, System.Guid? perimeterGuid = default(System.Guid?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Storage.NetworkSecurityPerimeterConfigurationData NetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue> provisioningIssues = null, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter networkSecurityPerimeter = null, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation resourceAssociation = null, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile profile = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile NetworkSecurityPerimeterConfigurationPropertiesProfile(string name = null, float? accessRulesVersion = default(float?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.NspAccessRule> accessRules = null, float? diagnosticSettingsVersion = default(float?), System.Collections.Generic.IEnumerable<string> enabledLogCategories = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation(string name = null, Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode? accessMode = default(Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue NetworkSecurityPerimeterProvisioningIssue(string name = null, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties NetworkSecurityPerimeterProvisioningIssueProperties(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType? issueType = default(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType?), Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity? severity = default(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity?), string description = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NspAccessRule NspAccessRule(string name = null, Azure.ResourceManager.Storage.Models.NspAccessRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NspAccessRuleProperties NspAccessRuleProperties(Azure.ResourceManager.Storage.Models.NspAccessRuleDirection? direction = default(Azure.ResourceManager.Storage.Models.NspAccessRuleDirection?), System.Collections.Generic.IEnumerable<string> addressPrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> subscriptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter> networkSecurityPerimeters = null, System.Collections.Generic.IEnumerable<string> fullyQualifiedDomainNames = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyData ObjectReplicationPolicyData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string policyId, System.DateTimeOffset? enabledOn, string sourceAccount, string destinationAccount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> rules) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyData ObjectReplicationPolicyData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string policyId, System.DateTimeOffset? enabledOn, string sourceAccount, string destinationAccount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> rules, bool? isMetricsEnabled) { throw null; }
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyData ObjectReplicationPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string policyId = null, System.DateTimeOffset? enabledOn = default(System.DateTimeOffset?), string sourceAccount = null, string destinationAccount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> rules = null, bool? isMetricsEnabled = default(bool?), bool? priorityReplicationEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory ProtectedAppendWritesHistory(bool? allowProtectedAppendWritesAll = default(bool?), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.QueueServiceData QueueServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageCorsRule> corsRules = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.RestorePolicy RestorePolicy(bool isEnabled = false, int? days = default(int?), System.DateTimeOffset? lastEnabledOn = default(System.DateTimeOffset?), System.DateTimeOffset? minRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ServiceSasContent ServiceSasContent(string canonicalizedResource = null, Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType? resource = default(Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType?), Azure.ResourceManager.Storage.Models.StorageAccountSasPermission? permissions = default(Azure.ResourceManager.Storage.Models.StorageAccountSasPermission?), string ipAddressOrRange = null, Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol? protocols = default(Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol?), System.DateTimeOffset? sharedAccessStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? sharedAccessExpiryOn = default(System.DateTimeOffset?), string identifier = null, string partitionKeyStart = null, string partitionKeyEnd = null, string rowKeyStart = null, string rowKeyEnd = null, string keyToSign = null, string cacheControl = null, string contentDisposition = null, string contentEncoding = null, string contentLanguage = null, string contentType = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? zonePlacementPolicy, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, bool? isIPv6EndpointToBePublished, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku = null, Azure.ResourceManager.Storage.Models.StorageKind kind = default(Azure.ResourceManager.Storage.Models.StorageKind), Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? zonePlacementPolicy = default(Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope = default(Azure.ResourceManager.Storage.Models.AllowedCopyScope?), Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess?), Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy = null, int? keyExpirationPeriodInDays = default(int?), Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain = null, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption = null, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet = null, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier = default(Azure.ResourceManager.Storage.Models.StorageAccountAccessTier?), Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = null, bool? enableHttpsTrafficOnly = default(bool?), bool? isSftpEnabled = default(bool?), bool? isLocalUserEnabled = default(bool?), bool? isExtendedGroupEnabled = default(bool?), bool? isHnsEnabled = default(bool?), Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState = default(Azure.ResourceManager.Storage.Models.LargeFileSharesState?), Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference = null, bool? isIPv6EndpointToBePublished = default(bool?), bool? allowBlobPublicAccess = default(bool?), Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion?), bool? allowSharedKeyAccess = default(bool?), bool? isNfsV3Enabled = default(bool?), bool? allowCrossTenantReplication = default(bool?), bool? isDefaultToOAuthAuthentication = default(bool?), Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning = null, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType = default(Azure.ResourceManager.Storage.Models.StorageDnsEndpointType?), bool? isBlobEnabled = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.StorageAccountData StorageAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind? kind, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? zonePlacementPolicy, Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? storageAccountProvisioningState, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints primaryEndpoints, Azure.Core.AzureLocation? primaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfPrimary, System.DateTimeOffset? lastGeoFailoverOn, Azure.Core.AzureLocation? secondaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfSecondary, System.DateTimeOffset? createdOn, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime keyCreationTime, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints secondaryEndpoints, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, bool? isIPv6EndpointToBePublished, Azure.ResourceManager.Storage.Models.BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType, bool? isSkuConversionBlocked, bool? isAccountMigrationInProgress) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountData StorageAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Storage.Models.StorageSku sku = null, Azure.ResourceManager.Storage.Models.StorageKind? kind = default(Azure.ResourceManager.Storage.Models.StorageKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? zonePlacementPolicy = default(Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy?), Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? storageAccountProvisioningState = default(Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState?), Azure.ResourceManager.Storage.Models.StorageAccountEndpoints primaryEndpoints = null, Azure.Core.AzureLocation? primaryLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfPrimary = default(Azure.ResourceManager.Storage.Models.StorageAccountStatus?), System.DateTimeOffset? lastGeoFailoverOn = default(System.DateTimeOffset?), Azure.Core.AzureLocation? secondaryLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfSecondary = default(Azure.ResourceManager.Storage.Models.StorageAccountStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain = null, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy = null, int? keyExpirationPeriodInDays = default(int?), Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime keyCreationTime = null, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints secondaryEndpoints = null, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption = null, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier = default(Azure.ResourceManager.Storage.Models.StorageAccountAccessTier?), Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = null, bool? enableHttpsTrafficOnly = default(bool?), Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet = null, bool? isSftpEnabled = default(bool?), bool? isLocalUserEnabled = default(bool?), bool? isExtendedGroupEnabled = default(bool?), bool? isHnsEnabled = default(bool?), Azure.ResourceManager.Storage.Models.GeoReplicationStatistics geoReplicationStats = null, bool? isFailoverInProgress = default(bool?), Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState = default(Azure.ResourceManager.Storage.Models.LargeFileSharesState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference = null, bool? isIPv6EndpointToBePublished = default(bool?), Azure.ResourceManager.Storage.Models.BlobRestoreStatus blobRestoreStatus = null, bool? allowBlobPublicAccess = default(bool?), Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion?), bool? allowSharedKeyAccess = default(bool?), bool? isNfsV3Enabled = default(bool?), bool? allowCrossTenantReplication = default(bool?), bool? isDefaultToOAuthAuthentication = default(bool?), Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess?), Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning = null, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope = default(Azure.ResourceManager.Storage.Models.AllowedCopyScope?), Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus storageAccountSkuConversionStatus = null, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType = default(Azure.ResourceManager.Storage.Models.StorageDnsEndpointType?), bool? isSkuConversionBlocked = default(bool?), bool? isAccountMigrationInProgress = default(bool?), bool? isBlobEnabled = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.StorageAccountData StorageAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind? kind, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? storageAccountProvisioningState, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints primaryEndpoints, Azure.Core.AzureLocation? primaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfPrimary, System.DateTimeOffset? lastGeoFailoverOn, Azure.Core.AzureLocation? secondaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfSecondary, System.DateTimeOffset? createdOn, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime keyCreationTime, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints secondaryEndpoints, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, Azure.ResourceManager.Storage.Models.BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType, bool? isSkuConversionBlocked, bool? isAccountMigrationInProgress) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.StorageAccountData StorageAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind? kind, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.Storage.Models.StorageProvisioningState? provisioningState, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints primaryEndpoints, Azure.Core.AzureLocation? primaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfPrimary, System.DateTimeOffset? lastGeoFailoverOn, Azure.Core.AzureLocation? secondaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfSecondary, System.DateTimeOffset? createdOn, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime keyCreationTime, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints secondaryEndpoints, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, Azure.ResourceManager.Storage.Models.BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.StorageAccountData StorageAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind? kind, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.Storage.Models.StorageProvisioningState? provisioningState, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints primaryEndpoints, Azure.Core.AzureLocation? primaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfPrimary, System.DateTimeOffset? lastGeoFailoverOn, Azure.Core.AzureLocation? secondaryLocation, Azure.ResourceManager.Storage.Models.StorageAccountStatus? statusOfSecondary, System.DateTimeOffset? createdOn, Azure.ResourceManager.Storage.Models.StorageCustomDomain customDomain, Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime keyCreationTime, Azure.ResourceManager.Storage.Models.StorageAccountEndpoints secondaryEndpoints, Azure.ResourceManager.Storage.Models.StorageAccountEncryption encryption, Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? accessTier, Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, Azure.ResourceManager.Storage.Models.GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, Azure.ResourceManager.Storage.Models.LargeFileSharesState? largeFileSharesState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Storage.Models.StorageRoutingPreference routingPreference, Azure.ResourceManager.Storage.Models.BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Storage.Models.ImmutableStorageAccount immutableStorageWithVersioning, Azure.ResourceManager.Storage.Models.AllowedCopyScope? allowedCopyScope, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? dnsEndpointType, bool? isSkuConversionBlocked, bool? isAccountMigrationInProgress) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageAccountEndpoints StorageAccountEndpoints(System.Uri blobUri, System.Uri queueUri, System.Uri tableUri, System.Uri fileUri, System.Uri webUri, System.Uri dfsUri, Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints microsoftEndpoints, Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints internetEndpoints) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountEndpoints StorageAccountEndpoints(System.Uri blobUri = null, System.Uri queueUri = null, System.Uri tableUri = null, System.Uri fileUri = null, System.Uri webUri = null, System.Uri dfsUri = null, Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints microsoftEndpoints = null, Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints internetEndpoints = null, Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints ipv6Endpoints = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints StorageAccountInternetEndpoints(System.Uri blobUri = null, System.Uri fileUri = null, System.Uri webUri = null, System.Uri dfsUri = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints StorageAccountIPv6Endpoints(string blob = null, string queue = null, string table = null, string file = null, string web = null, string dfs = null, Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints microsoftEndpoints = null, Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints internetEndpoints = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountKey StorageAccountKey(string keyName = null, string value = null, Azure.ResourceManager.Storage.Models.StorageAccountKeyPermission? permissions = default(Azure.ResourceManager.Storage.Models.StorageAccountKeyPermission?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime StorageAccountKeyCreationTime(System.DateTimeOffset? key1 = default(System.DateTimeOffset?), System.DateTimeOffset? key2 = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties StorageAccountKeyVaultProperties(string keyName = null, string keyVersion = null, System.Uri keyVaultUri = null, string currentVersionedKeyIdentifier = null, System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? currentVersionedKeyExpirationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.StorageAccountLocalUserData StorageAccountLocalUserData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StoragePermissionScope> permissionScopes, string homeDirectory, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> sshAuthorizedKeys, string sid, bool? hasSharedKey, bool? hasSshKey, bool? hasSshPassword) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountLocalUserData StorageAccountLocalUserData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StoragePermissionScope> permissionScopes = null, string homeDirectory = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> sshAuthorizedKeys = null, string sid = null, bool? hasSharedKey = default(bool?), bool? hasSshKey = default(bool?), bool? hasSshPassword = default(bool?), int? userId = default(int?), int? groupId = default(int?), bool? isAclAuthorizationAllowed = default(bool?), System.Collections.Generic.IEnumerable<int> extendedGroups = null, bool? isNfsV3Enabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountManagementPolicyData StorageAccountManagementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> rules = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints StorageAccountMicrosoftEndpoints(System.Uri blobUri = null, System.Uri queueUri = null, System.Uri tableUri = null, System.Uri fileUri = null, System.Uri webUri = null, System.Uri dfsUri = null) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountMigrationData StorageAccountMigrationData(string id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Storage.Models.StorageSkuName targetSkuName = default(Azure.ResourceManager.Storage.Models.StorageSkuName), Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus? migrationStatus = default(Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus?), string migrationFailedReason = null, string migrationFailedDetailedReason = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent StorageAccountNameAvailabilityContent(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult StorageAccountNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Storage.Models.StorageAccountNameUnavailableReason? reason = default(Azure.ResourceManager.Storage.Models.StorageAccountNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus(Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState? skuConversionStatus = default(Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState?), Azure.ResourceManager.Storage.Models.StorageSkuName? targetSkuName = default(Azure.ResourceManager.Storage.Models.StorageSkuName?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageEncryptionService StorageEncryptionService(bool? isEnabled = default(bool?), System.DateTimeOffset? lastEnabledOn = default(System.DateTimeOffset?), Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType? keyType = default(Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType?)) { throw null; }
        public static Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData StoragePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData StoragePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Storage.StorageQueueData StorageQueueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> metadata = null, int? approximateMessageCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSku StorageSku(Azure.ResourceManager.Storage.Models.StorageSkuName name = default(Azure.ResourceManager.Storage.Models.StorageSkuName), Azure.ResourceManager.Storage.Models.StorageSkuTier? tier = default(Azure.ResourceManager.Storage.Models.StorageSkuTier?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuCapability StorageSkuCapability(string name = null, string value = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageSkuInformation StorageSkuInformation(Azure.ResourceManager.Storage.Models.StorageSkuName name, Azure.ResourceManager.Storage.Models.StorageSkuTier? tier, string resourceType, Azure.ResourceManager.Storage.Models.StorageKind? kind, System.Collections.Generic.IEnumerable<string> locations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSkuCapability> capabilities, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSkuRestriction> restrictions) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuInformation StorageSkuInformation(Azure.ResourceManager.Storage.Models.StorageSkuName name = default(Azure.ResourceManager.Storage.Models.StorageSkuName), Azure.ResourceManager.Storage.Models.StorageSkuTier? tier = default(Azure.ResourceManager.Storage.Models.StorageSkuTier?), string resourceType = null, Azure.ResourceManager.Storage.Models.StorageKind? kind = default(Azure.ResourceManager.Storage.Models.StorageKind?), System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSkuCapability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageSkuRestriction> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo StorageSkuLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuRestriction StorageSkuRestriction(string restrictionType = null, System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode? reasonCode = default(Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Storage.StorageTaskAssignmentData StorageTaskAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties StorageTaskAssignmentPatchProperties(string taskId, bool? isEnabled, string description, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext executionContext, string reportPrefix, Azure.ResourceManager.Storage.Models.StorageProvisioningState? provisioningState, Azure.ResourceManager.Storage.Models.StorageTaskReportProperties runStatus) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties StorageTaskAssignmentPatchProperties(string taskId = null, bool? isEnabled = default(bool?), string description = null, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext executionContext = null, string reportPrefix = null, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState? storageTaskAssignmentProvisioningState = default(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState?), Azure.ResourceManager.Storage.Models.StorageTaskReportProperties runStatus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties StorageTaskAssignmentProperties(Azure.Core.ResourceIdentifier taskId, bool isEnabled, string description, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext executionContext, string reportPrefix, Azure.ResourceManager.Storage.Models.StorageProvisioningState? provisioningState, Azure.ResourceManager.Storage.Models.StorageTaskReportProperties runStatus) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties StorageTaskAssignmentProperties(Azure.Core.ResourceIdentifier taskId = null, bool isEnabled = false, string description = null, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext executionContext = null, string reportPrefix = null, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState? storageTaskAssignmentProvisioningState = default(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState?), Azure.ResourceManager.Storage.Models.StorageTaskReportProperties runStatus = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskReportInstance StorageTaskReportInstance(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Storage.Models.StorageTaskReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskReportProperties StorageTaskReportProperties(Azure.Core.ResourceIdentifier taskAssignmentId = null, Azure.Core.ResourceIdentifier storageAccountId = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), string objectsTargetedCount = null, string objectsOperatedOnCount = null, string objectFailedCount = null, string objectsSucceededCount = null, string runStatusError = null, Azure.ResourceManager.Storage.Models.StorageTaskRunStatus? runStatusEnum = default(Azure.ResourceManager.Storage.Models.StorageTaskRunStatus?), string summaryReportPath = null, Azure.Core.ResourceIdentifier taskId = null, string taskVersion = null, Azure.ResourceManager.Storage.Models.StorageTaskRunResult? runResult = default(Azure.ResourceManager.Storage.Models.StorageTaskRunResult?)) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageUsage StorageUsage(Azure.ResourceManager.Storage.Models.StorageUsageUnit? unit = default(Azure.ResourceManager.Storage.Models.StorageUsageUnit?), int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.Storage.Models.StorageUsageName name = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageUsageName StorageUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Storage.TableData TableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string tableName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier> signedIdentifiers = null) { throw null; }
        public static Azure.ResourceManager.Storage.TableServiceData TableServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.StorageCorsRule> corsRules = null) { throw null; }
        public static Azure.ResourceManager.Storage.Models.UpdateHistoryEntry UpdateHistoryEntry(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType? updateType = default(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType?), int? immutabilityPeriodSinceCreationInDays = default(int?), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string objectIdentifier = null, System.Guid? tenantId = default(System.Guid?), string upn = null, bool? allowProtectedAppendWrites = default(bool?), bool? allowProtectedAppendWritesAll = default(bool?)) { throw null; }
    }
    public partial class BlobContainerImmutabilityPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>
    {
        internal BlobContainerImmutabilityPolicy() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry> UpdateHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobContainerImmutabilityPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobContainerState : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobContainerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobContainerState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobContainerState Deleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobContainerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobContainerState left, Azure.ResourceManager.Storage.Models.BlobContainerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobContainerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobContainerState left, Azure.ResourceManager.Storage.Models.BlobContainerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobInventoryPolicyDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>
    {
        public BlobInventoryPolicyDefinition(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat format, Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule schedule, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType objectType, System.Collections.Generic.IEnumerable<string> schemaFields) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter Filters { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat Format { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SchemaFields { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobInventoryPolicyFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>
    {
        public BlobInventoryPolicyFilter() { }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public int? CreationTimeLastNDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludePrefix { get { throw null; } }
        public bool? IncludeBlobVersions { get { throw null; } set { } }
        public bool? IncludeDeleted { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IncludePrefix { get { throw null; } }
        public bool? IncludeSnapshots { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobInventoryPolicyFormat : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobInventoryPolicyFormat(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobInventoryPolicyName : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobInventoryPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobInventoryPolicyObjectType : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobInventoryPolicyObjectType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType Blob { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType Container { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobInventoryPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>
    {
        public BlobInventoryPolicyRule(bool isEnabled, string name, string destination, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition Definition { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobInventoryPolicySchedule : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobInventoryPolicySchedule(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule Daily { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule left, Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobInventoryPolicySchema : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>
    {
        public BlobInventoryPolicySchema(bool isEnabled, Azure.ResourceManager.Storage.Models.BlobInventoryRuleType ruleType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> rules) { }
        public string Destination { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> Rules { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryRuleType RuleType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobInventoryRuleType : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobInventoryRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobInventoryRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobInventoryRuleType Inventory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobInventoryRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobInventoryRuleType left, Azure.ResourceManager.Storage.Models.BlobInventoryRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobInventoryRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobInventoryRuleType left, Azure.ResourceManager.Storage.Models.BlobInventoryRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>
    {
        public BlobRestoreContent(System.DateTimeOffset timeToRestore, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobRestoreRange> blobRanges) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobRestoreRange> BlobRanges { get { throw null; } }
        public System.DateTimeOffset TimeToRestore { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobRestoreProgressStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobRestoreProgressStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus left, Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus left, Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobRestoreRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>
    {
        public BlobRestoreRange(string startRange, string endRange) { }
        public string EndRange { get { throw null; } set { } }
        public string StartRange { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobRestoreStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>
    {
        internal BlobRestoreStatus() { }
        public string FailureReason { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreContent Parameters { get { throw null; } }
        public string RestoreId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobRestoreStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobServiceChangeFeed : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>
    {
        public BlobServiceChangeFeed() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BlobServiceChangeFeed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BurstingConstants : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BurstingConstants>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BurstingConstants>
    {
        internal BurstingConstants() { }
        public int? BurstFloorIops { get { throw null; } }
        public double? BurstIOScalar { get { throw null; } }
        public int? BurstTimeframeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BurstingConstants System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BurstingConstants>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.BurstingConstants>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.BurstingConstants System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BurstingConstants>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BurstingConstants>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.BurstingConstants>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CorsRuleAllowedMethod : System.IEquatable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CorsRuleAllowedMethod(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Connect { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Get { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Head { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Merge { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Options { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Patch { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Post { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Put { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod left, Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod left, Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DateAfterCreation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>
    {
        public DateAfterCreation(float daysAfterCreationGreaterThan) { }
        public float DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DateAfterCreation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DateAfterCreation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateAfterModification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterModification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterModification>
    {
        public DateAfterModification() { }
        public float? DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastAccessTimeGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
        public float? DaysAfterModificationGreaterThan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DateAfterModification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterModification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DateAfterModification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DateAfterModification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterModification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterModification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DateAfterModification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultSharePermission : System.IEquatable<Azure.ResourceManager.Storage.Models.DefaultSharePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultSharePermission(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission Contributor { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission ElevatedContributor { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission None { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.DefaultSharePermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.DefaultSharePermission left, Azure.ResourceManager.Storage.Models.DefaultSharePermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.DefaultSharePermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.DefaultSharePermission left, Azure.ResourceManager.Storage.Models.DefaultSharePermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeletedShare : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeletedShare>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeletedShare>
    {
        public DeletedShare(string deletedShareName, string deletedShareVersion) { }
        public string DeletedShareName { get { throw null; } }
        public string DeletedShareVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DeletedShare System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeletedShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeletedShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DeletedShare System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeletedShare>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeletedShare>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeletedShare>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>
    {
        public DeleteRetentionPolicy() { }
        public bool? AllowPermanentDelete { get { throw null; } set { } }
        public int? Days { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DirectoryServiceOption : System.IEquatable<Azure.ResourceManager.Storage.Models.DirectoryServiceOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DirectoryServiceOption(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOption Aadds { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOption Aadkerb { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOption AD { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.DirectoryServiceOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.DirectoryServiceOption left, Azure.ResourceManager.Storage.Models.DirectoryServiceOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.DirectoryServiceOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.DirectoryServiceOption left, Azure.ResourceManager.Storage.Models.DirectoryServiceOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionScopeKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>
    {
        public EncryptionScopeKeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopesIncludeType : System.IEquatable<Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopesIncludeType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType All { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType left, Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType left, Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeSource : System.IEquatable<Azure.ResourceManager.Storage.Models.EncryptionScopeSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeSource(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeSource KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeSource Storage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.EncryptionScopeSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.EncryptionScopeSource left, Azure.ResourceManager.Storage.Models.EncryptionScopeSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.EncryptionScopeSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.EncryptionScopeSource left, Azure.ResourceManager.Storage.Models.EncryptionScopeSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeState : System.IEquatable<Azure.ResourceManager.Storage.Models.EncryptionScopeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.EncryptionScopeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.EncryptionScopeState left, Azure.ResourceManager.Storage.Models.EncryptionScopeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.EncryptionScopeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.EncryptionScopeState left, Azure.ResourceManager.Storage.Models.EncryptionScopeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionIntervalUnit : System.IEquatable<Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionIntervalUnit(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit Days { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit left, Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit left, Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecutionTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>
    {
        public ExecutionTarget() { }
        public System.Collections.Generic.IList<string> ExcludePrefix { get { throw null; } }
        public System.Collections.Generic.IList<string> Prefix { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ExecutionTrigger(Azure.ResourceManager.Storage.Models.ExecutionTriggerType triggerType, Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters parameters) { }
        public ExecutionTrigger(Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType taskExecutionTriggerType, Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters parameters) { }
        public Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType TaskExecutionTriggerType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Storage.Models.ExecutionTriggerType TriggerType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionTriggerParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>
    {
        public ExecutionTriggerParameters() { }
        public System.DateTimeOffset? EndBy { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit? IntervalUnit { get { throw null; } set { } }
        public System.DateTimeOffset? StartFrom { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionTriggerParametersUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>
    {
        public ExecutionTriggerParametersUpdate() { }
        public System.DateTimeOffset? EndBy { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExecutionIntervalUnit? IntervalUnit { get { throw null; } set { } }
        public System.DateTimeOffset? StartFrom { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ExecutionTriggerType
    {
        RunOnce = 0,
        OnSchedule = 1,
    }
    public partial class ExecutionTriggerUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>
    {
        public ExecutionTriggerUpdate() { }
        public Azure.ResourceManager.Storage.Models.ExecutionTriggerParametersUpdate Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType? TaskExecutionTriggerType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Storage.Models.ExecutionTriggerType? TriggerType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpirationAction : System.IEquatable<Azure.ResourceManager.Storage.Models.ExpirationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpirationAction(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ExpirationAction Block { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ExpirationAction Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ExpirationAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ExpirationAction left, Azure.ResourceManager.Storage.Models.ExpirationAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ExpirationAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ExpirationAction left, Azure.ResourceManager.Storage.Models.ExpirationAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileServiceAccountLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>
    {
        internal FileServiceAccountLimits() { }
        public int? MaxFileShares { get { throw null; } }
        public int? MaxProvisionedBandwidthMiBPerSec { get { throw null; } }
        public int? MaxProvisionedIops { get { throw null; } }
        public int? MaxProvisionedStorageGiB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceAccountUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>
    {
        internal FileServiceAccountUsage() { }
        public Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements LiveShares { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements SoftDeletedShares { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceAccountUsageElements : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>
    {
        internal FileServiceAccountUsageElements() { }
        public int? FileShareCount { get { throw null; } }
        public int? ProvisionedBandwidthMiBPerSec { get { throw null; } }
        public int? ProvisionedIops { get { throw null; } }
        public int? ProvisionedStorageGiB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceAccountUsageElements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceProtocolSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>
    {
        public FileServiceProtocolSettings() { }
        public bool? IsRequired { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SmbSetting SmbSetting { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceProtocolSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileServiceUsageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>
    {
        internal FileServiceUsageProperties() { }
        public Azure.ResourceManager.Storage.Models.BurstingConstants BurstingConstants { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileShareLimits FileShareLimits { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileShareRecommendations FileShareRecommendations { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileServiceAccountLimits StorageAccountLimits { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileServiceAccountUsage StorageAccountUsage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceUsageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileServiceUsageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileServiceUsageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareAccessTier : System.IEquatable<Azure.ResourceManager.Storage.Models.FileShareAccessTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareAccessTier(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileShareAccessTier Cool { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.FileShareAccessTier Hot { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.FileShareAccessTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.FileShareAccessTier TransactionOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.FileShareAccessTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.FileShareAccessTier left, Azure.ResourceManager.Storage.Models.FileShareAccessTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.FileShareAccessTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.FileShareAccessTier left, Azure.ResourceManager.Storage.Models.FileShareAccessTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareEnabledProtocol : System.IEquatable<Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareEnabledProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol Nfs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol Smb { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol left, Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol left, Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareLimits>
    {
        internal FileShareLimits() { }
        public int? MaxProvisionedBandwidthMiBPerSec { get { throw null; } }
        public int? MaxProvisionedIops { get { throw null; } }
        public int? MaxProvisionedStorageGiB { get { throw null; } }
        public int? MinProvisionedBandwidthMiBPerSec { get { throw null; } }
        public int? MinProvisionedIops { get { throw null; } }
        public int? MinProvisionedStorageGiB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileShareLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileShareLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSharePropertiesFileSharePaidBursting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>
    {
        public FileSharePropertiesFileSharePaidBursting() { }
        public bool? PaidBurstingEnabled { get { throw null; } set { } }
        public int? PaidBurstingMaxBandwidthMibps { get { throw null; } set { } }
        public int? PaidBurstingMaxIops { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileSharePropertiesFileSharePaidBursting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareRecommendations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>
    {
        internal FileShareRecommendations() { }
        public double? BandwidthScalar { get { throw null; } }
        public int? BaseBandwidthMiBPerSec { get { throw null; } }
        public int? BaseIops { get { throw null; } }
        public double? IoScalar { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileShareRecommendations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FileShareRecommendations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FileShareRecommendations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilesIdentityBasedAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>
    {
        public FilesIdentityBasedAuthentication(Azure.ResourceManager.Storage.Models.DirectoryServiceOption directoryServiceOptions) { }
        public Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties ActiveDirectoryProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DefaultSharePermission? DefaultSharePermission { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DirectoryServiceOption DirectoryServiceOptions { get { throw null; } set { } }
        public bool? IsSmbOAuthEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeoReplicationStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>
    {
        internal GeoReplicationStatistics() { }
        public bool? CanFailover { get { throw null; } }
        public bool? CanPlannedFailover { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PostFailoverRedundancy? PostFailoverRedundancy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy? PostPlannedFailoverRedundancy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.GeoReplicationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GeoReplicationStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GeoReplicationStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GeoReplicationStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoReplicationStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.GeoReplicationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoReplicationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.GeoReplicationStatus Bootstrap { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.GeoReplicationStatus Live { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.GeoReplicationStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.GeoReplicationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.GeoReplicationStatus left, Azure.ResourceManager.Storage.Models.GeoReplicationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.GeoReplicationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.GeoReplicationStatus left, Azure.ResourceManager.Storage.Models.GeoReplicationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetAccountSasResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>
    {
        internal GetAccountSasResult() { }
        public string AccountSasToken { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GetAccountSasResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GetAccountSasResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetAccountSasResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetServiceSasResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>
    {
        internal GetServiceSasResult() { }
        public string ServiceSasToken { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GetServiceSasResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.GetServiceSasResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.GetServiceSasResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityPolicyState : System.IEquatable<Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityPolicyState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState Locked { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState left, Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState left, Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityPolicyUpdateType : System.IEquatable<Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityPolicyUpdateType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType Extend { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType Lock { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType Put { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType left, Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType left, Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImmutableStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>
    {
        public ImmutableStorageAccount() { }
        public Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ImmutableStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ImmutableStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImmutableStorageWithVersioning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>
    {
        public ImmutableStorageWithVersioning() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutableStorageWithVersioningMigrationState : System.IEquatable<Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutableStorageWithVersioningMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState left, Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState left, Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeFileSharesState : System.IEquatable<Azure.ResourceManager.Storage.Models.LargeFileSharesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeFileSharesState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LargeFileSharesState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LargeFileSharesState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LargeFileSharesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LargeFileSharesState left, Azure.ResourceManager.Storage.Models.LargeFileSharesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LargeFileSharesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LargeFileSharesState left, Azure.ResourceManager.Storage.Models.LargeFileSharesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LastAccessTimeTrackingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>
    {
        public LastAccessTimeTrackingPolicy(bool isEnabled) { }
        public System.Collections.Generic.IList<string> BlobType { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName? Name { get { throw null; } set { } }
        public int? TrackingGranularityInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastAccessTimeTrackingPolicyName : System.IEquatable<Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastAccessTimeTrackingPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName AccessTimeTracking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName left, Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName left, Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseContainerAction : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseContainerAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseContainerAction(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerAction Acquire { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerAction Break { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerAction Change { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerAction Release { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerAction Renew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseContainerAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseContainerAction left, Azure.ResourceManager.Storage.Models.LeaseContainerAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseContainerAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseContainerAction left, Azure.ResourceManager.Storage.Models.LeaseContainerAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LeaseContainerContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>
    {
        public LeaseContainerContent(Azure.ResourceManager.Storage.Models.LeaseContainerAction action) { }
        public Azure.ResourceManager.Storage.Models.LeaseContainerAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseContainerContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseContainerContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LeaseContainerResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>
    {
        internal LeaseContainerResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseContainerResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseContainerResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseShareAction : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseShareAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseShareAction(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseShareAction Acquire { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseShareAction Break { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseShareAction Change { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseShareAction Release { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseShareAction Renew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseShareAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseShareAction left, Azure.ResourceManager.Storage.Models.LeaseShareAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseShareAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseShareAction left, Azure.ResourceManager.Storage.Models.LeaseShareAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LeaseShareContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>
    {
        public LeaseShareContent(Azure.ResourceManager.Storage.Models.LeaseShareAction action) { }
        public Azure.ResourceManager.Storage.Models.LeaseShareAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseShareContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseShareContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LeaseShareResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>
    {
        internal LeaseShareResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseShareResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LeaseShareResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LeaseShareResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LegalHold : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHold>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHold>
    {
        public LegalHold(System.Collections.Generic.IEnumerable<string> tags) { }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHold System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHold System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LegalHoldProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>
    {
        internal LegalHoldProperties() { }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory ProtectedAppendWritesHistory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.LegalHoldTag> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHoldProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHoldProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LegalHoldTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>
    {
        internal LegalHoldTag() { }
        public string ObjectIdentifier { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Upn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHoldTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LegalHoldTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LegalHoldTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListLocalUserIncludeParam : System.IEquatable<Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListLocalUserIncludeParam(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam Nfsv3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam left, Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam left, Azure.ResourceManager.Storage.Models.ListLocalUserIncludeParam right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocalUserKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>
    {
        internal LocalUserKeys() { }
        public string SharedKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LocalUserKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LocalUserKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalUserRegeneratePasswordResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>
    {
        internal LocalUserRegeneratePasswordResult() { }
        public string SshPassword { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>
    {
        public ManagementPolicyAction() { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob BaseBlob { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot Snapshot { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyVersion Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyBaseBlob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>
    {
        public ManagementPolicyBaseBlob() { }
        public Azure.ResourceManager.Storage.Models.DateAfterModification Delete { get { throw null; } set { } }
        public bool? EnableAutoTierToHotFromCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToHot { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>
    {
        public ManagementPolicyDefinition(Azure.ResourceManager.Storage.Models.ManagementPolicyAction actions) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyAction Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyFilter Filters { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>
    {
        public ManagementPolicyFilter(System.Collections.Generic.IEnumerable<string> blobTypes) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter> BlobIndexMatch { get { throw null; } }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementPolicyName : System.IEquatable<Azure.ResourceManager.Storage.Models.ManagementPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ManagementPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ManagementPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ManagementPolicyName left, Azure.ResourceManager.Storage.Models.ManagementPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ManagementPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ManagementPolicyName left, Azure.ResourceManager.Storage.Models.ManagementPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>
    {
        public ManagementPolicyRule(string name, Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType ruleType, Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType RuleType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementPolicyRuleType : System.IEquatable<Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementPolicyRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType Lifecycle { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType left, Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType left, Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementPolicySnapShot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>
    {
        public ManagementPolicySnapShot() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToHot { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyTagFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>
    {
        public ManagementPolicyTagFilter(string name, string @operator, string value) { }
        public string Name { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementPolicyVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>
    {
        public ManagementPolicyVersion() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToHot { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ManagementPolicyVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ManagementPolicyVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>
    {
        internal NetworkSecurityPerimeter() { }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Guid? PerimeterGuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationPropertiesProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>
    {
        internal NetworkSecurityPerimeterConfigurationPropertiesProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.NspAccessRule> AccessRules { get { throw null; } }
        public float? AccessRulesVersion { get { throw null; } }
        public float? DiagnosticSettingsVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> EnabledLogCategories { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>
    {
        internal NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation() { }
        public Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode? AccessMode { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationPropertiesResourceAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>
    {
        internal NetworkSecurityPerimeterProvisioningIssue() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterProvisioningIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>
    {
        internal NetworkSecurityPerimeterProvisioningIssueProperties() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType? IssueType { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity? Severity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterProvisioningIssueSeverity : System.IEquatable<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterProvisioningIssueSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterProvisioningIssueType : System.IEquatable<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterProvisioningIssueType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType ConfigurationPropagationFailure { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType left, Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeterProvisioningIssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NspAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRule>
    {
        internal NspAccessRule() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NspAccessRuleProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NspAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NspAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NspAccessRuleDirection : System.IEquatable<Azure.ResourceManager.Storage.Models.NspAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NspAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.NspAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.NspAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.NspAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.NspAccessRuleDirection left, Azure.ResourceManager.Storage.Models.NspAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.NspAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.NspAccessRuleDirection left, Azure.ResourceManager.Storage.Models.NspAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NspAccessRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>
    {
        internal NspAccessRuleProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.NspAccessRuleDirection? Direction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.NetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NspAccessRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.NspAccessRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.NspAccessRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectReplicationPolicyFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>
    {
        public ObjectReplicationPolicyFilter() { }
        public string MinCreationTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectReplicationPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>
    {
        public ObjectReplicationPolicyRule(string sourceContainer, string destinationContainer) { }
        public string DestinationContainer { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter Filters { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public string SourceContainer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostFailoverRedundancy : System.IEquatable<Azure.ResourceManager.Storage.Models.PostFailoverRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostFailoverRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.PostFailoverRedundancy StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PostFailoverRedundancy StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.PostFailoverRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.PostFailoverRedundancy left, Azure.ResourceManager.Storage.Models.PostFailoverRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.PostFailoverRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.PostFailoverRedundancy left, Azure.ResourceManager.Storage.Models.PostFailoverRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostPlannedFailoverRedundancy : System.IEquatable<Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostPlannedFailoverRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy StandardGrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy StandardGzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy StandardRagrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy StandardRagzrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy left, Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy left, Azure.ResourceManager.Storage.Models.PostPlannedFailoverRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectedAppendWritesHistory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>
    {
        internal ProtectedAppendWritesHistory() { }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceAssociationAccessMode : System.IEquatable<Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceAssociationAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode Audit { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode Enforced { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode Learning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode left, Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode left, Azure.ResourceManager.Storage.Models.ResourceAssociationAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.RestorePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.RestorePolicy>
    {
        public RestorePolicy(bool isEnabled) { }
        public int? Days { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
        public System.DateTimeOffset? MinRestoreOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.RestorePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.RestorePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.RestorePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.RestorePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.RestorePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.RestorePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.RestorePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RootSquashType : System.IEquatable<Azure.ResourceManager.Storage.Models.RootSquashType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RootSquashType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.RootSquashType AllSquash { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.RootSquashType NoRootSquash { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.RootSquashType RootSquash { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.RootSquashType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.RootSquashType left, Azure.ResourceManager.Storage.Models.RootSquashType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.RootSquashType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.RootSquashType left, Azure.ResourceManager.Storage.Models.RootSquashType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>
    {
        public ServiceSasContent(string canonicalizedResource) { }
        public string CacheControl { get { throw null; } set { } }
        public string CanonicalizedResource { get { throw null; } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public string PartitionKeyEnd { get { throw null; } set { } }
        public string PartitionKeyStart { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPermission? Permissions { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountHttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType? Resource { get { throw null; } set { } }
        public string RowKeyEnd { get { throw null; } set { } }
        public string RowKeyStart { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessExpiryOn { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ServiceSasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.ServiceSasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.ServiceSasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceSasSignedResourceType : System.IEquatable<Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceSasSignedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType Blob { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType Container { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType File { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType Share { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType left, Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType left, Azure.ResourceManager.Storage.Models.ServiceSasSignedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SmbSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.SmbSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.SmbSetting>
    {
        public SmbSetting() { }
        public string AuthenticationMethods { get { throw null; } set { } }
        public string ChannelEncryption { get { throw null; } set { } }
        public bool? IsMultiChannelEnabled { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public string KerberosTicketEncryption { get { throw null; } set { } }
        public string Versions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.SmbSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.SmbSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.SmbSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.SmbSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.SmbSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.SmbSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.SmbSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageAccountAccessTier
    {
        Hot = 0,
        Cool = 1,
        Premium = 2,
        Cold = 3,
    }
    public partial class StorageAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>
    {
        public StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageCustomDomain CustomDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? DnsEndpointType { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsBlobEnabled { get { throw null; } set { } }
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? IsExtendedGroupEnabled { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public bool? IsIPv6EndpointToBePublished { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsNfsV3Enabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public int? KeyExpirationPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageKind Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>
    {
        public StorageAccountEncryption() { }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity EncryptionIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices Services { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountEncryptionIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>
    {
        public StorageAccountEncryptionIdentity() { }
        public string EncryptionFederatedIdentityClientId { get { throw null; } set { } }
        public string EncryptionUserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountEncryptionServices : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>
    {
        public StorageAccountEncryptionServices() { }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Blob { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService File { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Queue { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Table { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>
    {
        internal StorageAccountEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints IPv6Endpoints { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } }
        public System.Uri QueueUri { get { throw null; } }
        public System.Uri TableUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageAccountExpand
    {
        GeoReplicationStats = 0,
        BlobRestoreStatus = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountFailoverType : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountFailoverType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountFailoverType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountFailoverType Planned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountFailoverType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountFailoverType left, Azure.ResourceManager.Storage.Models.StorageAccountFailoverType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountFailoverType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountFailoverType left, Azure.ResourceManager.Storage.Models.StorageAccountFailoverType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum StorageAccountHttpProtocol
    {
        HttpsHttp = 0,
        Https = 1,
    }
    public partial class StorageAccountInternetEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>
    {
        internal StorageAccountInternetEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>
    {
        public StorageAccountIPRule(string ipAddressOrRange) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction? Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountIPv6Endpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>
    {
        internal StorageAccountIPv6Endpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } }
        public string Queue { get { throw null; } }
        public string Table { get { throw null; } }
        public string Web { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountIPv6Endpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>
    {
        internal StorageAccountKey() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountKeyCreationTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>
    {
        internal StorageAccountKeyCreationTime() { }
        public System.DateTimeOffset? Key1 { get { throw null; } }
        public System.DateTimeOffset? Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyCreationTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageAccountKeyPermission
    {
        Read = 0,
        Full = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountKeySource : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountKeySource(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountKeySource KeyVault { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountKeySource Storage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountKeySource left, Azure.ResourceManager.Storage.Models.StorageAccountKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountKeySource left, Azure.ResourceManager.Storage.Models.StorageAccountKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>
    {
        public StorageAccountKeyVaultProperties() { }
        public System.DateTimeOffset? CurrentVersionedKeyExpirationTimestamp { get { throw null; } }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountMicrosoftEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>
    {
        internal StorageAccountMicrosoftEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public System.Uri QueueUri { get { throw null; } }
        public System.Uri TableUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountMigrationName : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountMigrationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountMigrationName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName left, Azure.ResourceManager.Storage.Models.StorageAccountMigrationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountMigrationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountMigrationName left, Azure.ResourceManager.Storage.Models.StorageAccountMigrationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountMigrationStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountMigrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus SubmittedForConversion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus left, Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus left, Azure.ResourceManager.Storage.Models.StorageAccountMigrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>
    {
        public StorageAccountNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>
    {
        internal StorageAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageAccountNameUnavailableReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountNetworkRuleAction : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction left, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction left, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>
    {
        public StorageAccountNetworkRuleSet(Azure.ResourceManager.Storage.Models.StorageNetworkDefaultAction defaultAction) { }
        public Azure.ResourceManager.Storage.Models.StorageNetworkBypass? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageNetworkDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountIPRule> IPv6Rules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule> ResourceAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountNetworkRuleState : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState NetworkSourceDeleted { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState left, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState left, Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>
    {
        public StorageAccountPatch() { }
        public Azure.ResourceManager.Storage.Models.StorageAccountAccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.FilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageCustomDomain CustomDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageDnsEndpointType? DnsEndpointType { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsBlobEnabled { get { throw null; } set { } }
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? IsExtendedGroupEnabled { get { throw null; } set { } }
        public bool? IsIPv6EndpointToBePublished { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public int? KeyExpirationPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountProvisioningState : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState ResolvingDns { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState left, Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState left, Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>
    {
        public StorageAccountRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountResourceAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>
    {
        public StorageAccountResourceAccessRule() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountSasPermission : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountSasPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountSasPermission(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission A { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission C { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission D { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission L { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission P { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission R { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission U { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasPermission W { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountSasPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountSasPermission left, Azure.ResourceManager.Storage.Models.StorageAccountSasPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountSasPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountSasPermission left, Azure.ResourceManager.Storage.Models.StorageAccountSasPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountSasPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>
    {
        public StorageAccountSasPolicy(string sasExpirationPeriod, Azure.ResourceManager.Storage.Models.ExpirationAction expirationAction) { }
        public Azure.ResourceManager.Storage.Models.ExpirationAction ExpirationAction { get { throw null; } set { } }
        public string SasExpirationPeriod { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountSasSignedResourceType : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountSasSignedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType C { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType O { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType S { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType left, Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType left, Azure.ResourceManager.Storage.Models.StorageAccountSasSignedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountSasSignedService : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountSasSignedService(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService B { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService F { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService Q { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService T { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService left, Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService left, Azure.ResourceManager.Storage.Models.StorageAccountSasSignedService right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountSkuConversionState : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountSkuConversionState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState left, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState left, Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountSkuConversionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>
    {
        public StorageAccountSkuConversionStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState? SkuConversionStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName? TargetSkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageAccountStatus
    {
        Available = 0,
        Unavailable = 1,
    }
    public partial class StorageAccountVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>
    {
        public StorageAccountVirtualNetworkRule(Azure.Core.ResourceIdentifier virtualNetworkResourceId) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction? Action { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState? State { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountZonePlacementPolicy : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountZonePlacementPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy Any { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy left, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy left, Azure.ResourceManager.Storage.Models.StorageAccountZonePlacementPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageActiveDirectoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>
    {
        public StorageActiveDirectoryProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public StorageActiveDirectoryProperties(string domainName, System.Guid domainGuid) { }
        public Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType? AccountType { get { throw null; } set { } }
        public System.Guid? ActiveDirectoryDomainGuid { get { throw null; } set { } }
        public string AzureStorageSid { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Guid DomainGuid { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainSid { get { throw null; } set { } }
        public string ForestName { get { throw null; } set { } }
        public string NetBiosDomainName { get { throw null; } set { } }
        public string SamAccountName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageCorsRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>
    {
        public StorageCorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod> allowedMethods, int maxAgeInSeconds, System.Collections.Generic.IEnumerable<string> exposedHeaders, System.Collections.Generic.IEnumerable<string> allowedHeaders) { }
        public System.Collections.Generic.IList<string> AllowedHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod> AllowedMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public System.Collections.Generic.IList<string> ExposedHeaders { get { throw null; } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageCorsRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageCorsRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCorsRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageCustomDomain : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>
    {
        public StorageCustomDomain(string name) { }
        public bool? IsUseSubDomainNameEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageCustomDomain System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageCustomDomain System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageCustomDomain>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageDnsEndpointType : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageDnsEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageDnsEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageDnsEndpointType AzureDnsZone { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageDnsEndpointType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageDnsEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageDnsEndpointType left, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageDnsEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageDnsEndpointType left, Azure.ResourceManager.Storage.Models.StorageDnsEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageEncryptionKeyType : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageEncryptionKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType Account { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType left, Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType left, Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageEncryptionService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>
    {
        public StorageEncryptionService() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageEncryptionService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageEncryptionService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageEncryptionService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageKind : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageKind(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageKind BlobStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageKind BlockBlobStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageKind FileStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageKind Storage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageKind StorageV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageKind left, Azure.ResourceManager.Storage.Models.StorageKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageKind left, Azure.ResourceManager.Storage.Models.StorageKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageLeaseDurationType : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageLeaseDurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageLeaseDurationType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseDurationType Fixed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseDurationType Infinite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageLeaseDurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageLeaseDurationType left, Azure.ResourceManager.Storage.Models.StorageLeaseDurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageLeaseDurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageLeaseDurationType left, Azure.ResourceManager.Storage.Models.StorageLeaseDurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageLeaseState : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageLeaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageLeaseState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseState Available { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseState Breaking { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseState Broken { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseState Expired { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseState Leased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageLeaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageLeaseState left, Azure.ResourceManager.Storage.Models.StorageLeaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageLeaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageLeaseState left, Azure.ResourceManager.Storage.Models.StorageLeaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageLeaseStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageLeaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageLeaseStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseStatus Locked { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageLeaseStatus Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageLeaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageLeaseStatus left, Azure.ResourceManager.Storage.Models.StorageLeaseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageLeaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageLeaseStatus left, Azure.ResourceManager.Storage.Models.StorageLeaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageListKeyExpand : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageListKeyExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageListKeyExpand(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageListKeyExpand Kerb { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageListKeyExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageListKeyExpand left, Azure.ResourceManager.Storage.Models.StorageListKeyExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageListKeyExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageListKeyExpand left, Azure.ResourceManager.Storage.Models.StorageListKeyExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageMinimumTlsVersion : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageMinimumTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion Tls1_2 { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion Tls1_3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion left, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion left, Azure.ResourceManager.Storage.Models.StorageMinimumTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageNetworkBypass : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageNetworkBypass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageNetworkBypass(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageNetworkBypass AzureServices { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageNetworkBypass Logging { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageNetworkBypass Metrics { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageNetworkBypass None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageNetworkBypass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageNetworkBypass left, Azure.ResourceManager.Storage.Models.StorageNetworkBypass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageNetworkBypass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageNetworkBypass left, Azure.ResourceManager.Storage.Models.StorageNetworkBypass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum StorageNetworkDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class StoragePermissionScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>
    {
        public StoragePermissionScope(string permissions, string service, string resourceName) { }
        public string Permissions { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string Service { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePermissionScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePermissionScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePermissionScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StoragePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>
    {
        public StoragePrivateLinkResourceData() { }
        public Azure.Core.ResourceIdentifier GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StoragePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>
    {
        public StoragePrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageProvisioningState
    {
        Creating = 0,
        ResolvingDns = 1,
        Succeeded = 2,
        ValidateSubscriptionQuotaBegin = 3,
        ValidateSubscriptionQuotaEnd = 4,
        Deleting = 5,
        Canceled = 6,
        Failed = 7,
    }
    public enum StoragePublicAccessType
    {
        None = 0,
        Container = 1,
        Blob = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess left, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess left, Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode left, Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode left, Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageRoutingChoice : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageRoutingChoice>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageRoutingChoice(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageRoutingChoice InternetRouting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageRoutingChoice MicrosoftRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageRoutingChoice other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageRoutingChoice left, Azure.ResourceManager.Storage.Models.StorageRoutingChoice right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageRoutingChoice (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageRoutingChoice left, Azure.ResourceManager.Storage.Models.StorageRoutingChoice right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageRoutingPreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>
    {
        public StorageRoutingPreference() { }
        public bool? IsInternetEndpointsPublished { get { throw null; } set { } }
        public bool? IsMicrosoftEndpointsPublished { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingChoice? RoutingChoice { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageRoutingPreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageRoutingPreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageRoutingPreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageServiceAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>
    {
        public StorageServiceAccessPolicy() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSignedIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>
    {
        public StorageSignedIdentifier() { }
        public Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSignedIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSignedIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSku>
    {
        public StorageSku(Azure.ResourceManager.Storage.Models.StorageSkuName name) { }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>
    {
        internal StorageSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSkuInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>
    {
        internal StorageSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSkuRestriction> Restrictions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>
    {
        internal StorageSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSkuName : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumV2Zrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardV2Grs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardV2Gzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardV2Zrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageSkuName left, Azure.ResourceManager.Storage.Models.StorageSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageSkuName left, Azure.ResourceManager.Storage.Models.StorageSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSkuRestriction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>
    {
        internal StorageSkuRestriction() { }
        public Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode? ReasonCode { get { throw null; } }
        public string RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSkuRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSkuRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageSkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class StorageSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>
    {
        public StorageSshPublicKey() { }
        public string Description { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTableAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>
    {
        public StorageTableAccessPolicy(string permission) { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTableSignedIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>
    {
        public StorageTableSignedIdentifier(string id) { }
        public Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentExecutionContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>
    {
        public StorageTaskAssignmentExecutionContext(Azure.ResourceManager.Storage.Models.ExecutionTrigger trigger) { }
        public Azure.ResourceManager.Storage.Models.ExecutionTarget Target { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExecutionTrigger Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>
    {
        public StorageTaskAssignmentPatch() { }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>
    {
        public StorageTaskAssignmentPatchProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext ExecutionContext { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Storage.Models.StorageProvisioningState? ProvisioningState { get { throw null; } }
        public string ReportPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskReportProperties RunStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState? StorageTaskAssignmentProvisioningState { get { throw null; } }
        public string TaskId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>
    {
        public StorageTaskAssignmentProperties(Azure.Core.ResourceIdentifier taskId, bool isEnabled, string description, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext executionContext, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport report) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentExecutionContext ExecutionContext { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Storage.Models.StorageProvisioningState? ProvisioningState { get { throw null; } }
        public string ReportPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskReportProperties RunStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState? StorageTaskAssignmentProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskAssignmentProvisioningState : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskAssignmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState ValidateSubscriptionQuotaBegin { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState ValidateSubscriptionQuotaEnd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState left, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState left, Azure.ResourceManager.Storage.Models.StorageTaskAssignmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTaskAssignmentReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>
    {
        public StorageTaskAssignmentReport(string prefix) { }
        public string Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskAssignmentUpdateExecutionContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>
    {
        public StorageTaskAssignmentUpdateExecutionContext() { }
        public Azure.ResourceManager.Storage.Models.ExecutionTarget Target { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExecutionTriggerUpdate Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskAssignmentUpdateExecutionContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskReportInstance : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>
    {
        public StorageTaskReportInstance() { }
        public Azure.ResourceManager.Storage.Models.StorageTaskReportProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskReportInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskReportInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageTaskReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>
    {
        public StorageTaskReportProperties() { }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public string ObjectFailedCount { get { throw null; } }
        public string ObjectsOperatedOnCount { get { throw null; } }
        public string ObjectsSucceededCount { get { throw null; } }
        public string ObjectsTargetedCount { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageTaskRunResult? RunResult { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageTaskRunStatus? RunStatusEnum { get { throw null; } }
        public string RunStatusError { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } }
        public string SummaryReportPath { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } }
        public string TaskVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageTaskReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageTaskReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskRunResult : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageTaskRunResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskRunResult(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskRunResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskRunResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageTaskRunResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageTaskRunResult left, Azure.ResourceManager.Storage.Models.StorageTaskRunResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageTaskRunResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageTaskRunResult left, Azure.ResourceManager.Storage.Models.StorageTaskRunResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTaskRunStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageTaskRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTaskRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageTaskRunStatus Finished { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageTaskRunStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.StorageTaskRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.StorageTaskRunStatus left, Azure.ResourceManager.Storage.Models.StorageTaskRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.StorageTaskRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.StorageTaskRunStatus left, Azure.ResourceManager.Storage.Models.StorageTaskRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsage>
    {
        internal StorageUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageUsageName Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsageName>
    {
        internal StorageUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.StorageUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.StorageUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.StorageUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StorageUsageUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        Percent = 3,
        CountsPerSecond = 4,
        BytesPerSecond = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskExecutionTriggerType : System.IEquatable<Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskExecutionTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType OnSchedule { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType RunOnce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType left, Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType left, Azure.ResourceManager.Storage.Models.TaskExecutionTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateHistoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>
    {
        internal UpdateHistoryEntry() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public string ObjectIdentifier { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType? UpdateType { get { throw null; } }
        public string Upn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.UpdateHistoryEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Storage.Models.UpdateHistoryEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
