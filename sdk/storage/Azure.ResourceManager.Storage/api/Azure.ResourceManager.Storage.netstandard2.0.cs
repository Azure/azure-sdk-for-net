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
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAll(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.ListContainersInclude? include = default(Azure.ResourceManager.Storage.Models.ListContainersInclude?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobContainerResource> GetAllAsync(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.ListContainersInclude? include = default(Azure.ResourceManager.Storage.Models.ListContainersInclude?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobContainerData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public BlobContainerData() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? DenyEncryptionScopeOverride { get { throw null; } set { } }
        public bool? EnableNfsV3AllSquash { get { throw null; } set { } }
        public bool? EnableNfsV3RootSquash { get { throw null; } set { } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning ImmutableStorageWithVersioning { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PublicAccess? PublicAccess { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse> Lease(Azure.ResourceManager.Storage.Models.LeaseContainerContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>> LeaseAsync(Azure.ResourceManager.Storage.Models.LeaseContainerContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ObjectLevelWorm(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ObjectLevelWormAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold> SetLegalHold(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold>> SetLegalHoldAsync(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource> Update(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainerResource>> UpdateAsync(Azure.ResourceManager.Storage.BlobContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobInventoryPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>, System.Collections.IEnumerable
    {
        protected BlobInventoryPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> Get(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> GetAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobInventoryPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public BlobInventoryPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema Policy { get { throw null; } set { } }
    }
    public partial class BlobInventoryPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BlobInventoryPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.BlobInventoryPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public BlobServiceData() { }
        public bool? AutomaticSnapshotPolicyEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ChangeFeed ChangeFeed { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } }
        public string DefaultServiceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public bool? IsVersioningEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy LastAccessTimeTrackingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RestorePolicyProperties RestorePolicy { get { throw null; } set { } }
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
        public virtual Azure.Response<bool> Exists(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> Get(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetAsync(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedAccountData() { }
        public string CreationTime { get { throw null; } }
        public string DeletionTime { get { throw null; } }
        public string Location { get { throw null; } }
        public string RestoreReference { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.EncryptionScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionScopeData : Azure.ResourceManager.Models.ResourceData
    {
        public EncryptionScopeData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.SmbSetting ProtocolSmb { get { throw null; } set { } }
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
    public partial class FileShareData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public FileShareData() { }
        public Azure.ResourceManager.Storage.Models.ShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeOn { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EnabledProtocols? EnabledProtocols { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.SignedIdentifier> SignedIdentifiers { get { throw null; } }
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
    public partial class ImmutabilityPolicyData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public ImmutabilityPolicyData() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } set { } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
    }
    public partial class ImmutabilityPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImmutabilityPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> ExtendImmutabilityPolicy(string ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> ExtendImmutabilityPolicyAsync(string ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> Get(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> GetAsync(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource> LockImmutabilityPolicy(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyResource>> LockImmutabilityPolicyAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.LocalUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.LocalUserResource>, System.Collections.IEnumerable
    {
        protected LocalUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.LocalUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.LocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.LocalUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string username, Azure.ResourceManager.Storage.LocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.LocalUserResource> Get(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.LocalUserResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.LocalUserResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.LocalUserResource>> GetAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.LocalUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.LocalUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.LocalUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.LocalUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalUserData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalUserData() { }
        public bool? HasSharedKey { get { throw null; } set { } }
        public bool? HasSshKey { get { throw null; } set { } }
        public bool? HasSshPassword { get { throw null; } set { } }
        public string HomeDirectory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.PermissionScope> PermissionScopes { get { throw null; } }
        public string Sid { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.SshPublicKey> SshAuthorizedKeys { get { throw null; } }
    }
    public partial class LocalUserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalUserResource() { }
        public virtual Azure.ResourceManager.Storage.LocalUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string username) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.LocalUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.LocalUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult> RegeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LocalUserRegeneratePasswordResult>> RegeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.LocalUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.LocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.LocalUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.LocalUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagementPolicyData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> Rules { get { throw null; } set { } }
    }
    public partial class ManagementPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementPolicyResource() { }
        public virtual Azure.ResourceManager.Storage.ManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ManagementPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.ManagementPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.ManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.Storage.Models.ManagementPolicyName managementPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ManagementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ManagementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } }
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
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreStatus BlobRestoreStatus { get { throw null; } }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } }
        public bool? DefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public bool? EnableNfsV3 { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public bool? FailoverInProgress { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.GeoReplicationStats GeoReplicationStats { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyCreationTime KeyCreationTime { get { throw null; } }
        public int? KeyExpirationPeriodInDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public System.DateTimeOffset? LastGeoFailoverOn { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Endpoints PrimaryEndpoints { get { throw null; } }
        public string PrimaryLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Endpoints SecondaryEndpoints { get { throw null; } }
        public string SecondaryLocation { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.AccountStatus? StatusOfPrimary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.AccountStatus? StatusOfSecondary { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> Get(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.ListAccountSasResponse> GetAccountSas(Azure.ResourceManager.Storage.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.ListAccountSasResponse>> GetAccountSasAsync(Azure.ResourceManager.Storage.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetAsync(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyCollection GetBlobInventoryPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource> GetBlobInventoryPolicy(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicyResource>> GetBlobInventoryPolicyAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.BlobServiceResource GetBlobService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource> GetEncryptionScope(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScopeResource>> GetEncryptionScopeAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeCollection GetEncryptionScopes() { throw null; }
        public virtual Azure.ResourceManager.Storage.FileServiceResource GetFileService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.LocalUserResource> GetLocalUser(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.LocalUserResource>> GetLocalUserAsync(string username, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.LocalUserCollection GetLocalUsers() { throw null; }
        public virtual Azure.ResourceManager.Storage.ManagementPolicyResource GetManagementPolicy() { throw null; }
        public virtual Azure.ResourceManager.Storage.ObjectReplicationPolicyCollection GetObjectReplicationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource> GetObjectReplicationPolicy(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicyResource>> GetObjectReplicationPolicyAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StoragePrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.QueueServiceResource GetQueueService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.ListServiceSasResponse> GetServiceSas(Azure.ResourceManager.Storage.Models.ServiceSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.ListServiceSasResponse>> GetServiceSasAsync(Azure.ResourceManager.Storage.Models.ServiceSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource> GetStoragePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource>> GetStoragePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionCollection GetStoragePrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.Storage.TableServiceResource GetTableService() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation HierarchicalNamespaceMigration(Azure.WaitUntil waitUntil, string requestType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> HierarchicalNamespaceMigrationAsync(Azure.WaitUntil waitUntil, string requestType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult> RegenerateKey(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult>> RegenerateKeyAsync(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.Models.BlobRestoreStatus> RestoreBlobRanges(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>> RestoreBlobRangesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Storage.Models.BlobRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeUserDelegationKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeUserDelegationKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> Update(Azure.ResourceManager.Storage.Models.StorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> UpdateAsync(Azure.ResourceManager.Storage.Models.StorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Storage.Models.CheckNameAvailabilityResult> CheckStorageAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storage.Models.StorageAccountCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.CheckNameAvailabilityResult>> CheckStorageAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Storage.Models.StorageAccountCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.BlobContainerResource GetBlobContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobInventoryPolicyResource GetBlobInventoryPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobServiceResource GetBlobServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccountResource>> GetDeletedAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountResource GetDeletedAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountCollection GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.DeletedAccountResource> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.EncryptionScopeResource GetEncryptionScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileServiceResource GetFileServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileShareResource GetFileShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ImmutabilityPolicyResource GetImmutabilityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.LocalUserResource GetLocalUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ManagementPolicyResource GetManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicyResource GetObjectReplicationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.QueueServiceResource GetQueueServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageSkuInformation> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccountResource>> GetStorageAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountResource GetStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccountResource> GetStorageAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.StoragePrivateEndpointConnectionResource GetStoragePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageQueueResource GetStorageQueueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.TableResource GetTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.TableServiceResource GetTableServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.StorageUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Storage.TableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public TableServiceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } }
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
namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccessPolicy
    {
        public AccessPolicy() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public enum AccessTier
    {
        Hot = 0,
        Cool = 1,
    }
    public partial class AccountImmutabilityPolicyProperties
    {
        public AccountImmutabilityPolicyProperties() { }
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
        public AccountSasContent(Azure.ResourceManager.Storage.Models.Services services, Azure.ResourceManager.Storage.Models.SignedResourceTypes resourceTypes, Azure.ResourceManager.Storage.Models.Permissions permissions, System.DateTimeOffset sharedAccessExpiryOn) { }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Permissions Permissions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.HttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SignedResourceTypes ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Services Services { get { throw null; } }
        public System.DateTimeOffset SharedAccessExpiryOn { get { throw null; } }
        public System.DateTimeOffset? SharedAccessStartOn { get { throw null; } set { } }
    }
    public enum AccountStatus
    {
        Available = 0,
        Unavailable = 1,
    }
    public partial class ActiveDirectoryProperties
    {
        public ActiveDirectoryProperties(string domainName, string netBiosDomainName, string forestName, string domainGuid, string domainSid, string azureStorageSid) { }
        public Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType? AccountType { get { throw null; } set { } }
        public string AzureStorageSid { get { throw null; } set { } }
        public string DomainGuid { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainSid { get { throw null; } set { } }
        public string ForestName { get { throw null; } set { } }
        public string NetBiosDomainName { get { throw null; } set { } }
        public string SamAccountName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveDirectoryPropertiesAccountType : System.IEquatable<Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveDirectoryPropertiesAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType Computer { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType left, Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType left, Azure.ResourceManager.Storage.Models.ActiveDirectoryPropertiesAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedCopyScope : System.IEquatable<Azure.ResourceManager.Storage.Models.AllowedCopyScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedCopyScope(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.AllowedCopyScope AAD { get { throw null; } }
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
    public partial class AzureEntityResource : Azure.ResourceManager.Models.ResourceData
    {
        public AzureEntityResource() { }
        public string Etag { get { throw null; } }
    }
    public partial class AzureFilesIdentityBasedAuthentication
    {
        public AzureFilesIdentityBasedAuthentication(Azure.ResourceManager.Storage.Models.DirectoryServiceOptions directoryServiceOptions) { }
        public Azure.ResourceManager.Storage.Models.ActiveDirectoryProperties ActiveDirectoryProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DefaultSharePermission? DefaultSharePermission { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DirectoryServiceOptions DirectoryServiceOptions { get { throw null; } set { } }
    }
    public partial class BlobInventoryPolicyDefinition
    {
        public BlobInventoryPolicyDefinition(Azure.ResourceManager.Storage.Models.Format format, Azure.ResourceManager.Storage.Models.Schedule schedule, Azure.ResourceManager.Storage.Models.ObjectType objectType, System.Collections.Generic.IEnumerable<string> schemaFields) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyFilter Filters { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Format Format { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ObjectType ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Schedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SchemaFields { get { throw null; } }
    }
    public partial class BlobInventoryPolicyFilter
    {
        public BlobInventoryPolicyFilter() { }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public bool? IncludeBlobVersions { get { throw null; } set { } }
        public bool? IncludeSnapshots { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } }
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
    public partial class BlobInventoryPolicyRule
    {
        public BlobInventoryPolicyRule(bool enabled, string name, string destination, Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDefinition Definition { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class BlobInventoryPolicySchema
    {
        public BlobInventoryPolicySchema(bool enabled, Azure.ResourceManager.Storage.Models.InventoryRuleType inventoryRuleType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> rules) { }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.InventoryRuleType InventoryRuleType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> Rules { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Bypass : System.IEquatable<Azure.ResourceManager.Storage.Models.Bypass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Bypass(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Bypass AzureServices { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Bypass Logging { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Bypass Metrics { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Bypass None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Bypass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Bypass left, Azure.ResourceManager.Storage.Models.Bypass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Bypass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Bypass left, Azure.ResourceManager.Storage.Models.Bypass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeFeed
    {
        public ChangeFeed() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Reason? Reason { get { throw null; } }
    }
    public partial class CorsRule
    {
        public CorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem> allowedMethods, int maxAgeInSeconds, System.Collections.Generic.IEnumerable<string> exposedHeaders, System.Collections.Generic.IEnumerable<string> allowedHeaders) { }
        public System.Collections.Generic.IList<string> AllowedHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem> AllowedMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public System.Collections.Generic.IList<string> ExposedHeaders { get { throw null; } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CorsRuleAllowedMethodsItem : System.IEquatable<Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CorsRuleAllowedMethodsItem(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem Delete { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem GET { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem Head { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem Merge { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem Options { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem Post { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem PUT { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem left, Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem left, Azure.ResourceManager.Storage.Models.CorsRuleAllowedMethodsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomDomain
    {
        public CustomDomain(string name) { }
        public string Name { get { throw null; } set { } }
        public bool? UseSubDomainName { get { throw null; } set { } }
    }
    public partial class DateAfterModification
    {
        public DateAfterModification() { }
        public float? DaysAfterLastAccessTimeGreaterThan { get { throw null; } set { } }
        public float? DaysAfterModificationGreaterThan { get { throw null; } set { } }
    }
    public enum DefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultSharePermission : System.IEquatable<Azure.ResourceManager.Storage.Models.DefaultSharePermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultSharePermission(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission None { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission StorageFileDataSmbShareContributor { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission StorageFileDataSmbShareElevatedContributor { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission StorageFileDataSmbShareReader { get { throw null; } }
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
        public int? Days { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DirectoryServiceOptions : System.IEquatable<Azure.ResourceManager.Storage.Models.DirectoryServiceOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DirectoryServiceOptions(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOptions Aadds { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOptions AD { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.DirectoryServiceOptions None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.DirectoryServiceOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.DirectoryServiceOptions left, Azure.ResourceManager.Storage.Models.DirectoryServiceOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.DirectoryServiceOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.DirectoryServiceOptions left, Azure.ResourceManager.Storage.Models.DirectoryServiceOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledProtocols : System.IEquatable<Azure.ResourceManager.Storage.Models.EnabledProtocols>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledProtocols(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EnabledProtocols NFS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EnabledProtocols SMB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.EnabledProtocols other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.EnabledProtocols left, Azure.ResourceManager.Storage.Models.EnabledProtocols right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.EnabledProtocols (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.EnabledProtocols left, Azure.ResourceManager.Storage.Models.EnabledProtocols right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encryption
    {
        public Encryption(Azure.ResourceManager.Storage.Models.KeySource keySource) { }
        public Azure.ResourceManager.Storage.Models.EncryptionIdentity EncryptionIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeySource KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionServices Services { get { throw null; } set { } }
    }
    public partial class EncryptionIdentity
    {
        public EncryptionIdentity() { }
        public string EncryptionFederatedIdentityClientId { get { throw null; } set { } }
        public string EncryptionUserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class EncryptionScopeKeyVaultProperties
    {
        public EncryptionScopeKeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeSource : System.IEquatable<Azure.ResourceManager.Storage.Models.EncryptionScopeSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeSource(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeSource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.EncryptionScopeSource MicrosoftStorage { get { throw null; } }
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
    public partial class EncryptionService
    {
        public EncryptionService() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
    }
    public partial class EncryptionServices
    {
        public EncryptionServices() { }
        public Azure.ResourceManager.Storage.Models.EncryptionService Blob { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionService File { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionService Queue { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionService Table { get { throw null; } set { } }
    }
    public partial class Endpoints
    {
        internal Endpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } }
        public string Queue { get { throw null; } }
        public string Table { get { throw null; } }
        public string Web { get { throw null; } }
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
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.Storage.Models.ExtendedLocationTypes? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationTypes : System.IEquatable<Azure.ResourceManager.Storage.Models.ExtendedLocationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationTypes(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ExtendedLocationTypes EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ExtendedLocationTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ExtendedLocationTypes left, Azure.ResourceManager.Storage.Models.ExtendedLocationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ExtendedLocationTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ExtendedLocationTypes left, Azure.ResourceManager.Storage.Models.ExtendedLocationTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Format : System.IEquatable<Azure.ResourceManager.Storage.Models.Format>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Format(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Format Csv { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Format Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Format other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Format left, Azure.ResourceManager.Storage.Models.Format right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Format (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Format left, Azure.ResourceManager.Storage.Models.Format right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoReplicationStats
    {
        internal GeoReplicationStats() { }
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
    public enum HttpProtocol
    {
        HttpsHttp = 0,
        Https = 1,
    }
    public partial class ImmutabilityPolicyProperties
    {
        internal ImmutabilityPolicyProperties() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public string Etag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.UpdateHistoryProperty> UpdateHistory { get { throw null; } }
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
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AccountImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } set { } }
    }
    public partial class ImmutableStorageWithVersioning
    {
        public ImmutableStorageWithVersioning() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.MigrationState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InventoryRuleType : System.IEquatable<Azure.ResourceManager.Storage.Models.InventoryRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InventoryRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.InventoryRuleType Inventory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.InventoryRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.InventoryRuleType left, Azure.ResourceManager.Storage.Models.InventoryRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.InventoryRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.InventoryRuleType left, Azure.ResourceManager.Storage.Models.InventoryRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRule
    {
        public IPRule(string ipAddressOrRange) { }
        public string Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
    }
    public partial class KeyCreationTime
    {
        internal KeyCreationTime() { }
        public System.DateTimeOffset? Key1 { get { throw null; } }
        public System.DateTimeOffset? Key2 { get { throw null; } }
    }
    public enum KeyPermission
    {
        Read = 0,
        Full = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeySource : System.IEquatable<Azure.ResourceManager.Storage.Models.KeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeySource(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.KeySource MicrosoftKeyvault { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.KeySource MicrosoftStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.KeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.KeySource left, Azure.ResourceManager.Storage.Models.KeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.KeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.KeySource left, Azure.ResourceManager.Storage.Models.KeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.Storage.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.KeyType Account { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.KeyType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.KeyType left, Azure.ResourceManager.Storage.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.KeyType left, Azure.ResourceManager.Storage.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
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
        public LastAccessTimeTrackingPolicy(bool enable) { }
        public System.Collections.Generic.IList<string> BlobType { get { throw null; } }
        public bool Enable { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Name? Name { get { throw null; } set { } }
        public int? TrackingGranularityInDays { get { throw null; } set { } }
    }
    public partial class LeaseContainerContent
    {
        public LeaseContainerContent(Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction action) { }
        public Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseContainerRequestAction : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseContainerRequestAction(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Acquire { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Break { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Change { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Release { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction Renew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction left, Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction left, Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LeaseContainerResponse
    {
        internal LeaseContainerResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseDuration : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseDuration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseDuration(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseDuration Fixed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseDuration Infinite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseDuration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseDuration left, Azure.ResourceManager.Storage.Models.LeaseDuration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseDuration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseDuration left, Azure.ResourceManager.Storage.Models.LeaseDuration right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseState : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseState Available { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseState Breaking { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseState Broken { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseState Expired { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseState Leased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseState left, Azure.ResourceManager.Storage.Models.LeaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseState left, Azure.ResourceManager.Storage.Models.LeaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.LeaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.LeaseStatus Locked { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.LeaseStatus Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.LeaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.LeaseStatus left, Azure.ResourceManager.Storage.Models.LeaseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.LeaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.LeaseStatus left, Azure.ResourceManager.Storage.Models.LeaseStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.TagProperty> Tags { get { throw null; } }
    }
    public partial class ListAccountSasResponse
    {
        internal ListAccountSasResponse() { }
        public string AccountSasToken { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListContainersInclude : System.IEquatable<Azure.ResourceManager.Storage.Models.ListContainersInclude>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListContainersInclude(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ListContainersInclude Deleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ListContainersInclude other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ListContainersInclude left, Azure.ResourceManager.Storage.Models.ListContainersInclude right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ListContainersInclude (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ListContainersInclude left, Azure.ResourceManager.Storage.Models.ListContainersInclude right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListServiceSasResponse
    {
        internal ListServiceSasResponse() { }
        public string ServiceSasToken { get { throw null; } }
    }
    public partial class LocalUserKeys
    {
        internal LocalUserKeys() { }
        public string SharedKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.SshPublicKey> SshAuthorizedKeys { get { throw null; } }
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
        public Azure.ResourceManager.Storage.Models.DateAfterModification TierToCool { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.TagFilter> BlobIndexMatch { get { throw null; } }
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
        public ManagementPolicyRule(string name, Azure.ResourceManager.Storage.Models.RuleType ruleType, Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RuleType RuleType { get { throw null; } set { } }
    }
    public partial class ManagementPolicySnapShot
    {
        public ManagementPolicySnapShot() { }
        public float? DeleteDaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? TierToArchiveDaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? TierToCoolDaysAfterCreationGreaterThan { get { throw null; } set { } }
    }
    public partial class ManagementPolicyVersion
    {
        public ManagementPolicyVersion() { }
        public float? DeleteDaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? TierToArchiveDaysAfterCreationGreaterThan { get { throw null; } set { } }
        public float? TierToCoolDaysAfterCreationGreaterThan { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationState : System.IEquatable<Azure.ResourceManager.Storage.Models.MigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.MigrationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.MigrationState InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.MigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.MigrationState left, Azure.ResourceManager.Storage.Models.MigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.MigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.MigrationState left, Azure.ResourceManager.Storage.Models.MigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MinimumTlsVersion : System.IEquatable<Azure.ResourceManager.Storage.Models.MinimumTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MinimumTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.MinimumTlsVersion TLS10 { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.MinimumTlsVersion TLS11 { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.MinimumTlsVersion TLS12 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.MinimumTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.MinimumTlsVersion left, Azure.ResourceManager.Storage.Models.MinimumTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.MinimumTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.MinimumTlsVersion left, Azure.ResourceManager.Storage.Models.MinimumTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Name : System.IEquatable<Azure.ResourceManager.Storage.Models.Name>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Name(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Name AccessTimeTracking { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Name other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Name left, Azure.ResourceManager.Storage.Models.Name right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Name (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Name left, Azure.ResourceManager.Storage.Models.Name right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet(Azure.ResourceManager.Storage.Models.DefaultAction defaultAction) { }
        public Azure.ResourceManager.Storage.Models.Bypass? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.IPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ResourceAccessRule> ResourceAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectType : System.IEquatable<Azure.ResourceManager.Storage.Models.ObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ObjectType Blob { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ObjectType Container { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ObjectType left, Azure.ResourceManager.Storage.Models.ObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ObjectType left, Azure.ResourceManager.Storage.Models.ObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Permissions : System.IEquatable<Azure.ResourceManager.Storage.Models.Permissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Permissions(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Permissions A { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions C { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions D { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions L { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions P { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions R { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions U { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Permissions W { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Permissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Permissions left, Azure.ResourceManager.Storage.Models.Permissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Permissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Permissions left, Azure.ResourceManager.Storage.Models.Permissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PermissionScope
    {
        public PermissionScope(string permissions, string service, string resourceName) { }
        public string Permissions { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string Service { get { throw null; } set { } }
    }
    public partial class ProtectedAppendWritesHistory
    {
        internal ProtectedAppendWritesHistory() { }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public enum ProvisioningState
    {
        Creating = 0,
        ResolvingDns = 1,
        Succeeded = 2,
    }
    public enum PublicAccess
    {
        None = 0,
        Container = 1,
        Blob = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Storage.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.PublicNetworkAccess left, Azure.ResourceManager.Storage.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.PublicNetworkAccess left, Azure.ResourceManager.Storage.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum Reason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.ResourceManager.Storage.Models.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ReasonCode left, Azure.ResourceManager.Storage.Models.ReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ReasonCode left, Azure.ResourceManager.Storage.Models.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceAccessRule
    {
        public ResourceAccessRule() { }
        public string ResourceId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    public partial class RestorePolicyProperties
    {
        public RestorePolicyProperties(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledOn { get { throw null; } }
        public System.DateTimeOffset? MinRestoreOn { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.ResourceManager.Storage.Models.ReasonCode? ReasonCode { get { throw null; } }
        public string RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingChoice : System.IEquatable<Azure.ResourceManager.Storage.Models.RoutingChoice>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingChoice(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.RoutingChoice InternetRouting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.RoutingChoice MicrosoftRouting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.RoutingChoice other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.RoutingChoice left, Azure.ResourceManager.Storage.Models.RoutingChoice right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.RoutingChoice (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.RoutingChoice left, Azure.ResourceManager.Storage.Models.RoutingChoice right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingPreference
    {
        public RoutingPreference() { }
        public bool? PublishInternetEndpoints { get { throw null; } set { } }
        public bool? PublishMicrosoftEndpoints { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingChoice? RoutingChoice { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleType : System.IEquatable<Azure.ResourceManager.Storage.Models.RuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.RuleType Lifecycle { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.RuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.RuleType left, Azure.ResourceManager.Storage.Models.RuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.RuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.RuleType left, Azure.ResourceManager.Storage.Models.RuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SasPolicy
    {
        public SasPolicy(string sasExpirationPeriod, Azure.ResourceManager.Storage.Models.ExpirationAction expirationAction) { }
        public Azure.ResourceManager.Storage.Models.ExpirationAction ExpirationAction { get { throw null; } set { } }
        public string SasExpirationPeriod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Schedule : System.IEquatable<Azure.ResourceManager.Storage.Models.Schedule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Schedule(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Schedule Daily { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Schedule Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Schedule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Schedule left, Azure.ResourceManager.Storage.Models.Schedule right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Schedule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Schedule left, Azure.ResourceManager.Storage.Models.Schedule right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Services : System.IEquatable<Azure.ResourceManager.Storage.Models.Services>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Services(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Services B { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Services F { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Services Q { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Services T { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Services other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Services left, Azure.ResourceManager.Storage.Models.Services right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Services (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Services left, Azure.ResourceManager.Storage.Models.Services right) { throw null; }
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
        public Azure.ResourceManager.Storage.Models.Permissions? Permissions { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.HttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SignedResource? Resource { get { throw null; } set { } }
        public string RowKeyEnd { get { throw null; } set { } }
        public string RowKeyStart { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessExpiryOn { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessStartOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessTier : System.IEquatable<Azure.ResourceManager.Storage.Models.ShareAccessTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessTier(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.ShareAccessTier Cool { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ShareAccessTier Hot { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ShareAccessTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.ShareAccessTier TransactionOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.ShareAccessTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.ShareAccessTier left, Azure.ResourceManager.Storage.Models.ShareAccessTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.ShareAccessTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.ShareAccessTier left, Azure.ResourceManager.Storage.Models.ShareAccessTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignedIdentifier
    {
        public SignedIdentifier() { }
        public Azure.ResourceManager.Storage.Models.AccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignedResource : System.IEquatable<Azure.ResourceManager.Storage.Models.SignedResource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignedResource(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.SignedResource B { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SignedResource C { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SignedResource F { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SignedResource S { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.SignedResource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.SignedResource left, Azure.ResourceManager.Storage.Models.SignedResource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.SignedResource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.SignedResource left, Azure.ResourceManager.Storage.Models.SignedResource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignedResourceTypes : System.IEquatable<Azure.ResourceManager.Storage.Models.SignedResourceTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignedResourceTypes(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.SignedResourceTypes C { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SignedResourceTypes O { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SignedResourceTypes S { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.SignedResourceTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.SignedResourceTypes left, Azure.ResourceManager.Storage.Models.SignedResourceTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.SignedResourceTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.SignedResourceTypes left, Azure.ResourceManager.Storage.Models.SignedResourceTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SKUCapability
    {
        internal SKUCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string Description { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.Storage.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.State Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.State Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.State NetworkSourceDeleted { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.State Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.State Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.State left, Azure.ResourceManager.Storage.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.State left, Azure.ResourceManager.Storage.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountCheckNameAvailabilityContent
    {
        public StorageAccountCheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class StorageAccountCreateOrUpdateContent
    {
        public StorageAccountCreateOrUpdateContent(Azure.ResourceManager.Storage.Models.StorageSku sku, Azure.ResourceManager.Storage.Models.StorageKind kind, string location) { }
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? DefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public bool? EnableNfsV3 { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public int? KeyExpirationPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageKind Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum StorageAccountExpand
    {
        GeoReplicationStats = 0,
        BlobRestoreStatus = 1,
    }
    public partial class StorageAccountInternetEndpoints
    {
        internal StorageAccountInternetEndpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public string Web { get { throw null; } }
    }
    public partial class StorageAccountKey
    {
        internal StorageAccountKey() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.KeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageAccountListKeysResult
    {
        internal StorageAccountListKeysResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.StorageAccountKey> Keys { get { throw null; } }
    }
    public partial class StorageAccountMicrosoftEndpoints
    {
        internal StorageAccountMicrosoftEndpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public string Queue { get { throw null; } }
        public string Table { get { throw null; } }
        public string Web { get { throw null; } }
    }
    public partial class StorageAccountPatch
    {
        public StorageAccountPatch() { }
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AllowedCopyScope? AllowedCopyScope { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? DefaultToOAuthAuthentication { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageAccount ImmutableStorageWithVersioning { get { throw null; } set { } }
        public bool? IsLocalUserEnabled { get { throw null; } set { } }
        public bool? IsSftpEnabled { get { throw null; } set { } }
        public int? KeyExpirationPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StorageAccountRegenerateKeyContent
    {
        public StorageAccountRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
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
    public partial class StoragePrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public StoragePrivateLinkResource() { }
        public string GroupId { get { throw null; } }
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
    public partial class StorageSku
    {
        public StorageSku(Azure.ResourceManager.Storage.Models.StorageSkuName name) { }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
    }
    public partial class StorageSkuInformation
    {
        internal StorageSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.SKUCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageKind? Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.Restriction> Restrictions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.StorageSkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSkuName : System.IEquatable<Azure.ResourceManager.Storage.Models.StorageSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardGzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardRagzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.StorageSkuName StandardZRS { get { throw null; } }
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
    public enum StorageSkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class StorageUsage
    {
        internal StorageUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.UsageUnit? Unit { get { throw null; } }
    }
    public partial class TagFilter
    {
        public TagFilter(string name, string op, string value) { }
        public string Name { get { throw null; } set { } }
        public string Op { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class TagProperty
    {
        internal TagProperty() { }
        public string ObjectIdentifier { get { throw null; } }
        public string Tag { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class UpdateHistoryProperty
    {
        internal UpdateHistoryProperty() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
        public bool? AllowProtectedAppendWritesAll { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public string ObjectIdentifier { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType? Update { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum UsageUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        Percent = 3,
        CountsPerSecond = 4,
        BytesPerSecond = 5,
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string virtualNetworkResourceId) { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.State? State { get { throw null; } set { } }
        public string VirtualNetworkResourceId { get { throw null; } set { } }
    }
}
