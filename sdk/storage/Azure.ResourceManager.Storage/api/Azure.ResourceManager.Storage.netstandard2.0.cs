namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>, System.Collections.IEnumerable
    {
        protected BlobContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAll(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.BlobContainerState? include = default(Azure.ResourceManager.Storage.Models.BlobContainerState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAllAsync(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.BlobContainerState? include = default(Azure.ResourceManager.Storage.Models.BlobContainerState?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobContainerData : Azure.ResourceManager.Models.ResourceData
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
    }
    public partial class BlobContainerResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Update(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> UpdateAsync(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobInventoryPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public BlobInventoryPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema PolicySchema { get { throw null; } set { } }
    }
    public partial class BlobInventoryPolicyResource : Azure.ResourceManager.ArmResource
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
    }
    public partial class BlobServiceData : Azure.ResourceManager.Models.ResourceData
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
    }
    public partial class BlobServiceResource : Azure.ResourceManager.ArmResource
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
    }
    public partial class DeletedAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedAccountCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> Get(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetAsync(Azure.Core.AzureLocation location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedAccountData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string RestoreReference { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } }
    }
    public partial class DeletedAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedAccountResource() { }
        public virtual Azure.ResourceManager.Storage.DeletedAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string deletedAccountName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAllAsync(int? maxpagesize = default(int?), string filter = null, Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType? include = default(Azure.ResourceManager.Storage.Models.EncryptionScopesIncludeType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionScopeData : Azure.ResourceManager.Models.ResourceData
    {
        public EncryptionScopeData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeState? State { get { throw null; } set { } }
    }
    public partial class EncryptionScopeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EncryptionScopeResource() { }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string encryptionScopeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> Update(Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> UpdateAsync(Azure.ResourceManager.Storage.EncryptionScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public FileServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.SmbSetting ProtocolSmbSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ShareDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
    }
    public partial class FileServiceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> GetFileShare(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> GetFileShareAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.FileShareCollection GetFileShares() { throw null; }
    }
    public partial class FileShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShareResource>, System.Collections.IEnumerable
    {
        protected FileShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.Storage.FileShareData data, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.FileShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.Storage.FileShareData data, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> Get(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.FileShareResource> GetAll(string maxpagesize = null, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.FileShareResource> GetAllAsync(string maxpagesize = null, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> GetAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.FileShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.FileShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileShareData : Azure.ResourceManager.Models.ResourceData
    {
        public FileShareData() { }
        public Azure.ResourceManager.Storage.Models.FileShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeOn { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.FileShareEnabledProtocol? EnabledProtocol { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageLeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageSignedIdentifier> SignedIdentifiers { get { throw null; } }
        public System.DateTimeOffset? SnapshotOn { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class FileShareResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShareResource> Update(Azure.ResourceManager.Storage.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShareResource>> UpdateAsync(Azure.ResourceManager.Storage.FileShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImmutabilityPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ImmutabilityPolicyData() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
    }
    public partial class ImmutabilityPolicyResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ObjectReplicationPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ObjectReplicationPolicyData() { }
        public string DestinationAccount { get { throw null; } set { } }
        public System.DateTimeOffset? EnabledOn { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> Rules { get { throw null; } }
        public string SourceAccount { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicyResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ObjectReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public QueueServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
    }
    public partial class QueueServiceResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? IsFailoverInProgress { get { throw null; } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsNfsV3Enabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
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
        public Azure.ResourceManager.Storage.Models.StorageProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StoragePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSasPolicy SasPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEndpoints SecondaryEndpoints { get { throw null; } }
        public Azure.Core.AzureLocation? SecondaryLocation { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountStatus? StatusOfPrimary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountStatus? StatusOfSecondary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus { get { throw null; } set { } }
    }
    public partial class StorageAccountLocalUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>, System.Collections.IEnumerable
    {
        protected StorageAccountLocalUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> Get(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> GetAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountLocalUserData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageAccountLocalUserData() { }
        public bool? HasSharedKey { get { throw null; } set { } }
        public bool? HasSshKey { get { throw null; } set { } }
        public bool? HasSshPassword { get { throw null; } set { } }
        public string HomeDirectory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StoragePermissionScope> PermissionScopes { get { throw null; } }
        public string Sid { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } }
    }
    public partial class StorageAccountLocalUserResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.StorageAccountLocalUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.StorageAccountLocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountManagementPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageAccountManagementPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> Rules { get { throw null; } set { } }
    }
    public partial class StorageAccountManagementPolicyResource : Azure.ResourceManager.ArmResource
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
    }
    public partial class StorageAccountResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetStoragePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetStoragePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionCollection GetStoragePrivateEndpointConnections() { throw null; }
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
        public static Azure.ResourceManager.Storage.FileShareResource GetFileShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.QueueServiceResource GetQueueServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetStorageAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountLocalUserResource GetStorageAccountLocalUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountManagementPolicyResource GetStorageAccountManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountResource GetStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource GetStoragePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageQueueResource GetStorageQueueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StoragePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public StoragePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Storage.Models.StoragePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StoragePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class StoragePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAll(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageQueueResource> GetAllAsync(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> GetAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageQueueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageQueueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageQueueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageQueueData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageQueueData() { }
        public int? ApproximateMessageCount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class StorageQueueResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource> Update(Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueueResource>> UpdateAsync(Azure.ResourceManager.Storage.StorageQueueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.TableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.TableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.TableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.TableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TableData : Azure.ResourceManager.Models.ResourceData
    {
        public TableData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageTableSignedIdentifier> SignedIdentifiers { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class TableResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> Update(Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> UpdateAsync(Azure.ResourceManager.Storage.TableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public TableServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageCorsRule> CorsRules { get { throw null; } }
    }
    public partial class TableServiceResource : Azure.ResourceManager.ArmResource
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
    }
}
namespace Azure.ResourceManager.Storage.Mock
{
    public partial class DeletedAccountResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected DeletedAccountResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts() { throw null; }
    }
    public partial class StorageAccountResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected StorageAccountResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult> CheckStorageAccountNameAvailability(Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(Azure.ResourceManager.Storage.Models.StorageAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Storage.DeletedAccountCollection GetDeletedAccounts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountImmutabilityPolicy
    {
        public AccountImmutabilityPolicy() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyState? State { get { throw null; } set { } }
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
    public partial class AccountSasContent
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
    public partial class BlobContainerImmutabilityPolicy
    {
        internal BlobContainerImmutabilityPolicy() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.UpdateHistoryEntry> UpdateHistory { get { throw null; } }
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
    public partial class BlobInventoryPolicyDefinition
    {
        public BlobInventoryPolicyDefinition(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat format, Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule schedule, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType objectType, System.Collections.Generic.IEnumerable<string> schemaFields) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter Filters { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFormat Format { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyObjectType ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SchemaFields { get { throw null; } }
    }
    public partial class BlobInventoryPolicyFilter
    {
        public BlobInventoryPolicyFilter() { }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludePrefix { get { throw null; } }
        public bool? IncludeBlobVersions { get { throw null; } set { } }
        public bool? IncludeDeleted { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IncludePrefix { get { throw null; } }
        public bool? IncludeSnapshots { get { throw null; } set { } }
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
    public partial class BlobInventoryPolicyRule
    {
        public BlobInventoryPolicyRule(bool isEnabled, string name, string destination, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition Definition { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public partial class BlobInventoryPolicySchema
    {
        public BlobInventoryPolicySchema(bool isEnabled, Azure.ResourceManager.Storage.Models.BlobInventoryRuleType ruleType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> rules) { }
        public string Destination { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> Rules { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryRuleType RuleType { get { throw null; } set { } }
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
    public partial class BlobRestoreContent
    {
        public BlobRestoreContent(System.DateTimeOffset timeToRestore, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobRestoreRange> blobRanges) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobRestoreRange> BlobRanges { get { throw null; } }
        public System.DateTimeOffset TimeToRestore { get { throw null; } set { } }
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
    public partial class BlobRestoreRange
    {
        public BlobRestoreRange(string startRange, string endRange) { }
        public string EndRange { get { throw null; } set { } }
        public string StartRange { get { throw null; } set { } }
    }
    public partial class BlobRestoreStatus
    {
        internal BlobRestoreStatus() { }
        public string FailureReason { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreContent Parameters { get { throw null; } }
        public string RestoreId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus? Status { get { throw null; } }
    }
    public partial class BlobServiceChangeFeed
    {
        public BlobServiceChangeFeed() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CorsRuleAllowedMethod : System.IEquatable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CorsRuleAllowedMethod(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Get { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Head { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Merge { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Options { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Patch { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Post { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod Put { get { throw null; } }
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
    public partial class DateAfterCreation
    {
        public DateAfterCreation(float daysAfterCreationGreaterThan) { }
        public float DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
    }
    public partial class DateAfterModification
    {
        public DateAfterModification() { }
        public float? DaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastAccessTimeGreaterThan { get { throw null; } set { } }
        public float? DaysAfterLastTierChangeGreaterThan { get { throw null; } set { } }
        public float? DaysAfterModificationGreaterThan { get { throw null; } set { } }
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
    public partial class DeletedShare
    {
        public DeletedShare(string deletedShareName, string deletedShareVersion) { }
        public string DeletedShareName { get { throw null; } }
        public string DeletedShareVersion { get { throw null; } }
    }
    public partial class DeleteRetentionPolicy
    {
        public DeleteRetentionPolicy() { }
        public bool? AllowPermanentDelete { get { throw null; } set { } }
        public int? Days { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
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
    public partial class EncryptionScopeKeyVaultProperties
    {
        public EncryptionScopeKeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
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
    public readonly partial struct ExpirationAction : System.IEquatable<Azure.ResourceManager.Storage.Models.ExpirationAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpirationAction(string value) { throw null; }
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
    public partial class FilesIdentityBasedAuthentication
    {
        public FilesIdentityBasedAuthentication(Azure.ResourceManager.Storage.Models.DirectoryServiceOption directoryServiceOptions) { }
        public Azure.ResourceManager.Storage.Models.StorageActiveDirectoryProperties ActiveDirectoryProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DefaultSharePermission? DefaultSharePermission { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DirectoryServiceOption DirectoryServiceOptions { get { throw null; } set { } }
    }
    public partial class GeoReplicationStatistics
    {
        internal GeoReplicationStatistics() { }
        public bool? CanFailover { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.GeoReplicationStatus? Status { get { throw null; } }
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
    public partial class GetAccountSasResult
    {
        internal GetAccountSasResult() { }
        public string AccountSasToken { get { throw null; } }
    }
    public partial class GetServiceSasResult
    {
        internal GetServiceSasResult() { }
        public string ServiceSasToken { get { throw null; } }
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
    public partial class ImmutableStorageAccount
    {
        public ImmutableStorageAccount() { }
        public Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class ImmutableStorageWithVersioning
    {
        public ImmutableStorageWithVersioning() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioningMigrationState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
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
    public partial class LastAccessTimeTrackingPolicy
    {
        public LastAccessTimeTrackingPolicy(bool isEnabled) { }
        public System.Collections.Generic.IList<string> BlobType { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicyName? Name { get { throw null; } set { } }
        public int? TrackingGranularityInDays { get { throw null; } set { } }
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
    public partial class LeaseContainerContent
    {
        public LeaseContainerContent(Azure.ResourceManager.Storage.Models.LeaseContainerAction action) { }
        public Azure.ResourceManager.Storage.Models.LeaseContainerAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
    }
    public partial class LeaseContainerResponse
    {
        internal LeaseContainerResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
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
    public partial class LeaseShareContent
    {
        public LeaseShareContent(Azure.ResourceManager.Storage.Models.LeaseShareAction action) { }
        public Azure.ResourceManager.Storage.Models.LeaseShareAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
    }
    public partial class LeaseShareResponse
    {
        internal LeaseShareResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
    }
    public partial class LegalHold
    {
        public LegalHold(System.Collections.Generic.IEnumerable<string> tags) { }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    public partial class LegalHoldProperties
    {
        internal LegalHoldProperties() { }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ProtectedAppendWritesHistory ProtectedAppendWritesHistory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.LegalHoldTag> Tags { get { throw null; } }
    }
    public partial class LegalHoldTag
    {
        internal LegalHoldTag() { }
        public string ObjectIdentifier { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class LocalUserKeys
    {
        internal LocalUserKeys() { }
        public string SharedKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSshPublicKey> SshAuthorizedKeys { get { throw null; } }
    }
    public partial class LocalUserRegeneratePasswordResult
    {
        internal LocalUserRegeneratePasswordResult() { }
        public string SshPassword { get { throw null; } }
    }
    public partial class ManagementPolicyAction
    {
        public ManagementPolicyAction() { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyBaseBlob BaseBlob { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicySnapShot Snapshot { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyVersion Version { get { throw null; } set { } }
    }
    public partial class ManagementPolicyBaseBlob
    {
        public ManagementPolicyBaseBlob() { }
        public Azure.ResourceManager.Storage.Models.DateAfterModification Delete { get { throw null; } set { } }
        public bool? EnableAutoTierToHotFromCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToHot { get { throw null; } set { } }
    }
    public partial class ManagementPolicyDefinition
    {
        public ManagementPolicyDefinition(Azure.ResourceManager.Storage.Models.ManagementPolicyAction actions) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyAction Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyFilter Filters { get { throw null; } set { } }
    }
    public partial class ManagementPolicyFilter
    {
        public ManagementPolicyFilter(System.Collections.Generic.IEnumerable<string> blobTypes) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyTagFilter> BlobIndexMatch { get { throw null; } }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } }
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
    public partial class ManagementPolicyRule
    {
        public ManagementPolicyRule(string name, Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType ruleType, Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyRuleType RuleType { get { throw null; } set { } }
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
    public partial class ManagementPolicySnapShot
    {
        public ManagementPolicySnapShot() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToHot { get { throw null; } set { } }
    }
    public partial class ManagementPolicyTagFilter
    {
        public ManagementPolicyTagFilter(string name, string @operator, string value) { }
        public string Name { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ManagementPolicyVersion
    {
        public ManagementPolicyVersion() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCold { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToHot { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicyFilter
    {
        public ObjectReplicationPolicyFilter() { }
        public string MinCreationTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } }
    }
    public partial class ObjectReplicationPolicyRule
    {
        public ObjectReplicationPolicyRule(string sourceContainer, string destinationContainer) { }
        public string DestinationContainer { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyFilter Filters { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public string SourceContainer { get { throw null; } set { } }
    }
    public partial class ProtectedAppendWritesHistory
    {
        internal ProtectedAppendWritesHistory() { }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class RestorePolicy
    {
        public RestorePolicy(bool isEnabled) { }
        public int? Days { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
        public System.DateTimeOffset? MinRestoreOn { get { throw null; } }
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
    public partial class ServiceSasContent
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
    public partial class SmbSetting
    {
        public SmbSetting() { }
        public string AuthenticationMethods { get { throw null; } set { } }
        public string ChannelEncryption { get { throw null; } set { } }
        public bool? IsMultiChannelEnabled { get { throw null; } set { } }
        public string KerberosTicketEncryption { get { throw null; } set { } }
        public string Versions { get { throw null; } set { } }
    }
    public enum StorageAccountAccessTier
    {
        Hot = 0,
        Cool = 1,
        Premium = 2,
    }
    public partial class StorageAccountCreateOrUpdateContent
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
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
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
    }
    public partial class StorageAccountEncryption
    {
        public StorageAccountEncryption() { }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryptionIdentity EncryptionIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountEncryptionServices Services { get { throw null; } set { } }
    }
    public partial class StorageAccountEncryptionIdentity
    {
        public StorageAccountEncryptionIdentity() { }
        public string EncryptionFederatedIdentityClientId { get { throw null; } set { } }
        public string EncryptionUserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class StorageAccountEncryptionServices
    {
        public StorageAccountEncryptionServices() { }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Blob { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService File { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Queue { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionService Table { get { throw null; } set { } }
    }
    public partial class StorageAccountEndpoints
    {
        internal StorageAccountEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } }
        public System.Uri QueueUri { get { throw null; } }
        public System.Uri TableUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
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
    public partial class StorageAccountInternetEndpoints
    {
        internal StorageAccountInternetEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
    }
    public partial class StorageAccountIPRule
    {
        public StorageAccountIPRule(string ipAddressOrRange) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction? Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
    }
    public partial class StorageAccountKey
    {
        internal StorageAccountKey() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountKeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageAccountKeyCreationTime
    {
        internal StorageAccountKeyCreationTime() { }
        public System.DateTimeOffset? Key1 { get { throw null; } }
        public System.DateTimeOffset? Key2 { get { throw null; } }
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
    public partial class StorageAccountKeyVaultProperties
    {
        public StorageAccountKeyVaultProperties() { }
        public System.DateTimeOffset? CurrentVersionedKeyExpirationTimestamp { get { throw null; } }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
    }
    public partial class StorageAccountMicrosoftEndpoints
    {
        internal StorageAccountMicrosoftEndpoints() { }
        public System.Uri BlobUri { get { throw null; } }
        public System.Uri DfsUri { get { throw null; } }
        public System.Uri FileUri { get { throw null; } }
        public System.Uri QueueUri { get { throw null; } }
        public System.Uri TableUri { get { throw null; } }
        public System.Uri WebUri { get { throw null; } }
    }
    public partial class StorageAccountNameAvailabilityContent
    {
        public StorageAccountNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class StorageAccountNameAvailabilityResult
    {
        internal StorageAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNameUnavailableReason? Reason { get { throw null; } }
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
    public partial class StorageAccountNetworkRuleSet
    {
        public StorageAccountNetworkRuleSet(Azure.ResourceManager.Storage.Models.StorageNetworkDefaultAction defaultAction) { }
        public Azure.ResourceManager.Storage.Models.StorageNetworkBypass? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageNetworkDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountResourceAccessRule> ResourceAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.StorageAccountVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
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
    public partial class StorageAccountPatch
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
        public bool? IsDefaultToOAuthAuthentication { get { throw null; } set { } }
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
    }
    public partial class StorageAccountRegenerateKeyContent
    {
        public StorageAccountRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class StorageAccountResourceAccessRule
    {
        public StorageAccountResourceAccessRule() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
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
    public partial class StorageAccountSasPolicy
    {
        public StorageAccountSasPolicy(string sasExpirationPeriod, Azure.ResourceManager.Storage.Models.ExpirationAction expirationAction) { }
        public Azure.ResourceManager.Storage.Models.ExpirationAction ExpirationAction { get { throw null; } set { } }
        public string SasExpirationPeriod { get { throw null; } set { } }
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
    public partial class StorageAccountSkuConversionStatus
    {
        public StorageAccountSkuConversionStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountSkuConversionState? SkuConversionStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName? TargetSkuName { get { throw null; } set { } }
    }
    public enum StorageAccountStatus
    {
        Available = 0,
        Unavailable = 1,
    }
    public partial class StorageAccountVirtualNetworkRule
    {
        public StorageAccountVirtualNetworkRule(Azure.Core.ResourceIdentifier virtualNetworkResourceId) { }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleAction? Action { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageAccountNetworkRuleState? State { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
    }
    public partial class StorageActiveDirectoryProperties
    {
        public StorageActiveDirectoryProperties(string domainName, System.Guid domainGuid) { }
        public Azure.ResourceManager.Storage.Models.ActiveDirectoryAccountType? AccountType { get { throw null; } set { } }
        public string AzureStorageSid { get { throw null; } set { } }
        public System.Guid DomainGuid { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainSid { get { throw null; } set { } }
        public string ForestName { get { throw null; } set { } }
        public string NetBiosDomainName { get { throw null; } set { } }
        public string SamAccountName { get { throw null; } set { } }
    }
    public partial class StorageCorsRule
    {
        public StorageCorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod> allowedMethods, int maxAgeInSeconds, System.Collections.Generic.IEnumerable<string> exposedHeaders, System.Collections.Generic.IEnumerable<string> allowedHeaders) { }
        public System.Collections.Generic.IList<string> AllowedHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethod> AllowedMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public System.Collections.Generic.IList<string> ExposedHeaders { get { throw null; } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class StorageCustomDomain
    {
        public StorageCustomDomain(string name) { }
        public bool? IsUseSubDomainNameEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public partial class StorageEncryptionService
    {
        public StorageEncryptionService() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageEncryptionKeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
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
    public partial class StoragePermissionScope
    {
        public StoragePermissionScope(string permissions, string service, string resourceName) { }
        public string Permissions { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string Service { get { throw null; } set { } }
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
    public partial class StoragePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public StoragePrivateLinkResourceData() { }
        public Azure.Core.ResourceIdentifier GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class StoragePrivateLinkServiceConnectionState
    {
        public StoragePrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StoragePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public enum StorageProvisioningState
    {
        Creating = 0,
        ResolvingDns = 1,
        Succeeded = 2,
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
    public partial class StorageRoutingPreference
    {
        public StorageRoutingPreference() { }
        public bool? IsInternetEndpointsPublished { get { throw null; } set { } }
        public bool? IsMicrosoftEndpointsPublished { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageRoutingChoice? RoutingChoice { get { throw null; } set { } }
    }
    public partial class StorageServiceAccessPolicy
    {
        public StorageServiceAccessPolicy() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class StorageSignedIdentifier
    {
        public StorageSignedIdentifier() { }
        public Azure.ResourceManager.Storage.Models.StorageServiceAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class StorageSku
    {
        public StorageSku(Azure.ResourceManager.Storage.Models.StorageSkuName name) { }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
    }
    public partial class StorageSkuCapability
    {
        internal StorageSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageSkuInformation
    {
        internal StorageSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageSkuRestriction> Restrictions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSkuName : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagzrs { get { throw null; } }
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
    public partial class StorageSkuRestriction
    {
        internal StorageSkuRestriction() { }
        public Azure.ResourceManager.Storage.Models.StorageRestrictionReasonCode? ReasonCode { get { throw null; } }
        public string RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum StorageSkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class StorageSshPublicKey
    {
        public StorageSshPublicKey() { }
        public string Description { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
    }
    public partial class StorageTableAccessPolicy
    {
        public StorageTableAccessPolicy(string permission) { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class StorageTableSignedIdentifier
    {
        public StorageTableSignedIdentifier(string id) { }
        public Azure.ResourceManager.Storage.Models.StorageTableAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class StorageUsage
    {
        internal StorageUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageUsageName Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageUsageUnit? Unit { get { throw null; } }
    }
    public partial class StorageUsageName
    {
        internal StorageUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class UpdateHistoryEntry
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
    }
}
