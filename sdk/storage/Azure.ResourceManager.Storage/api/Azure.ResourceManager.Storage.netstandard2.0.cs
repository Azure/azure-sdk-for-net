namespace Azure.ResourceManager.Storage
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Storage.BlobContainer GetBlobContainer(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobInventoryPolicy GetBlobInventoryPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.BlobService GetBlobService(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccount GetDeletedAccount(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.EncryptionScope GetEncryptionScope(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileService GetFileService(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.FileShare GetFileShare(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ImmutabilityPolicy GetImmutabilityPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ManagementPolicy GetManagementPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.ObjectReplicationPolicy GetObjectReplicationPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.QueueService GetQueueService(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageAccount GetStorageAccount(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.StorageQueue GetStorageQueue(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.Table GetTable(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Storage.TableService GetTableService(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class BlobContainer : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BlobContainer() { }
        public virtual Azure.ResourceManager.Storage.BlobContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold> ClearLegalHold(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold>> ClearLegalHoldAsync(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.BlobContainerDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobContainerDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainer> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.ImmutabilityPolicy GetImmutabilityPolicy() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse> Lease(Azure.ResourceManager.Storage.Models.LeaseContainerRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LeaseContainerResponse>> LeaseAsync(Azure.ResourceManager.Storage.Models.LeaseContainerRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.BlobContainerObjectLevelWormOperation ObjectLevelWorm(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobContainerObjectLevelWormOperation> ObjectLevelWormAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold> SetLegalHold(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LegalHold>> SetLegalHoldAsync(Azure.ResourceManager.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainer> Update(Azure.ResourceManager.Storage.BlobContainerData blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> UpdateAsync(Azure.ResourceManager.Storage.BlobContainerData blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainer>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainer>, System.Collections.IEnumerable
    {
        protected BlobContainerCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.BlobContainerCreateOperation CreateOrUpdate(string containerName, Azure.ResourceManager.Storage.BlobContainerData blobContainer, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobContainerCreateOperation> CreateOrUpdateAsync(string containerName, Azure.ResourceManager.Storage.BlobContainerData blobContainer, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainer> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobContainer> GetAll(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.ListContainersInclude? include = default(Azure.ResourceManager.Storage.Models.ListContainersInclude?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobContainer> GetAllAsync(string maxpagesize = null, string filter = null, Azure.ResourceManager.Storage.Models.ListContainersInclude? include = default(Azure.ResourceManager.Storage.Models.ListContainersInclude?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobContainer> GetIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> GetIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobContainer> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobContainer>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobContainer> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobContainer>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobContainerData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public BlobContainerData() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public bool? DenyEncryptionScopeOverride { get { throw null; } set { } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning ImmutableStorageWithVersioning { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PublicAccess? PublicAccess { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class BlobInventoryPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BlobInventoryPolicy() { }
        public virtual Azure.ResourceManager.Storage.BlobInventoryPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobInventoryPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicy>, System.Collections.IEnumerable
    {
        protected BlobInventoryPolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.BlobInventoryPolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, Azure.ResourceManager.Storage.BlobInventoryPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, Azure.ResourceManager.Storage.BlobInventoryPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy> Get(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.BlobInventoryPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.BlobInventoryPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy>> GetAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy> GetIfExists(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy>> GetIfExistsAsync(Azure.ResourceManager.Storage.Models.BlobInventoryPolicyName blobInventoryPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.BlobInventoryPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.BlobInventoryPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.BlobInventoryPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BlobInventoryPolicyData : Azure.ResourceManager.Models.Resource
    {
        public BlobInventoryPolicyData() { }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobInventoryPolicySchema Policy { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class BlobService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BlobService() { }
        public virtual Azure.ResourceManager.Storage.BlobServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.BlobServiceSetServicePropertiesOperation CreateOrUpdate(Azure.ResourceManager.Storage.BlobServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobServiceSetServicePropertiesOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.BlobServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.BlobService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.BlobService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.BlobContainerCollection GetBlobContainers() { throw null; }
    }
    public partial class BlobServiceData : Azure.ResourceManager.Models.Resource
    {
        public BlobServiceData() { }
        public bool? AutomaticSnapshotPolicyEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ChangeFeed ChangeFeed { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.CorsRules Cors { get { throw null; } set { } }
        public string DefaultServiceVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public bool? IsVersioningEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LastAccessTimeTrackingPolicy LastAccessTimeTrackingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RestorePolicyProperties RestorePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Sku Sku { get { throw null; } }
    }
    public partial class DeletedAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DeletedAccount() { }
        public virtual Azure.ResourceManager.Storage.DeletedAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccount> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccount>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAccountCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected DeletedAccountCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccount> Get(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccount>> GetAsync(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.DeletedAccount> GetIfExists(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.DeletedAccount>> GetIfExistsAsync(string location, string deletedAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedAccountData : Azure.ResourceManager.Models.Resource
    {
        public DeletedAccountData() { }
        public string CreationTime { get { throw null; } }
        public string DeletionTime { get { throw null; } }
        public string Location { get { throw null; } }
        public string RestoreReference { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } }
    }
    public partial class EncryptionScope : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected EncryptionScope() { }
        public virtual Azure.ResourceManager.Storage.EncryptionScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScope> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScope> Update(Azure.ResourceManager.Storage.EncryptionScopeData encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> UpdateAsync(Azure.ResourceManager.Storage.EncryptionScopeData encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionScopeCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScope>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScope>, System.Collections.IEnumerable
    {
        protected EncryptionScopeCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.EncryptionScopePutOperation CreateOrUpdate(string encryptionScopeName, Azure.ResourceManager.Storage.EncryptionScopeData encryptionScope, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.EncryptionScopePutOperation> CreateOrUpdateAsync(string encryptionScopeName, Azure.ResourceManager.Storage.EncryptionScopeData encryptionScope, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScope> Get(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.EncryptionScope> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.EncryptionScope> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> GetAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.EncryptionScope> GetIfExists(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> GetIfExistsAsync(string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.EncryptionScope> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.EncryptionScope>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.EncryptionScope> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.EncryptionScope>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionScopeData : Azure.ResourceManager.Models.Resource
    {
        public EncryptionScopeData() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.EncryptionScopeState? State { get { throw null; } set { } }
    }
    public partial class FileService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected FileService() { }
        public virtual Azure.ResourceManager.Storage.FileServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.FileServiceSetServicePropertiesOperation CreateOrUpdate(Azure.ResourceManager.Storage.FileServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.FileServiceSetServicePropertiesOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.FileServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.FileShareCollection GetFileShares() { throw null; }
    }
    public partial class FileServiceData : Azure.ResourceManager.Models.Resource
    {
        public FileServiceData() { }
        public Azure.ResourceManager.Storage.Models.CorsRules Cors { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DeleteRetentionPolicy ShareDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Sku Sku { get { throw null; } }
    }
    public partial class FileShare : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected FileShare() { }
        public virtual Azure.ResourceManager.Storage.FileShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.FileShareDeleteOperation Delete(string xMsSnapshot = null, string include = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.FileShareDeleteOperation> DeleteAsync(string xMsSnapshot = null, string include = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShare> Get(string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShare>> GetAsync(string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.LeaseShareResponse> Lease(string xMsSnapshot = null, Azure.ResourceManager.Storage.Models.LeaseShareRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.LeaseShareResponse>> LeaseAsync(string xMsSnapshot = null, Azure.ResourceManager.Storage.Models.LeaseShareRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restore(Azure.ResourceManager.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestoreAsync(Azure.ResourceManager.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShare> Update(Azure.ResourceManager.Storage.FileShareData fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShare>> UpdateAsync(Azure.ResourceManager.Storage.FileShareData fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileShareCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShare>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShare>, System.Collections.IEnumerable
    {
        protected FileShareCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.FileShareCreateOperation CreateOrUpdate(string shareName, Azure.ResourceManager.Storage.FileShareData fileShare, string expand = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.FileShareCreateOperation> CreateOrUpdateAsync(string shareName, Azure.ResourceManager.Storage.FileShareData fileShare, string expand = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShare> Get(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.FileShare> GetAll(string maxpagesize = null, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.FileShare> GetAllAsync(string maxpagesize = null, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShare>> GetAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.FileShare> GetIfExists(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.FileShare>> GetIfExistsAsync(string shareName, string expand = null, string xMsSnapshot = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.FileShare> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.FileShare>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.FileShare> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.FileShare>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileShareData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public FileShareData() { }
        public Azure.ResourceManager.Storage.Models.ShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeTime { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EnabledProtocols? EnabledProtocols { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.SignedIdentifier> SignedIdentifiers { get { throw null; } }
        public System.DateTimeOffset? SnapshotTime { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ImmutabilityPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ImmutabilityPolicy() { }
        public virtual Azure.ResourceManager.Storage.ImmutabilityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.BlobContainerCreateOrUpdateImmutabilityPolicyOperation CreateOrUpdate(string ifMatch = null, Azure.ResourceManager.Storage.ImmutabilityPolicyData parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobContainerCreateOrUpdateImmutabilityPolicyOperation> CreateOrUpdateAsync(string ifMatch = null, Azure.ResourceManager.Storage.ImmutabilityPolicyData parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.BlobContainerDeleteImmutabilityPolicyOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.BlobContainerDeleteImmutabilityPolicyOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy> ExtendImmutabilityPolicy(string ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy>> ExtendImmutabilityPolicyAsync(string ifMatch, Azure.ResourceManager.Storage.ImmutabilityPolicyData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy> Get(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy>> GetAsync(string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy> LockImmutabilityPolicy(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy>> LockImmutabilityPolicyAsync(string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImmutabilityPolicyData : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public ImmutabilityPolicyData() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
    }
    public partial class ManagementPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ManagementPolicy() { }
        public virtual Azure.ResourceManager.Storage.ManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.ManagementPolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.Storage.ManagementPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.ManagementPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.ManagementPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.ManagementPolicyDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.ManagementPolicyDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ManagementPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ManagementPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementPolicyData : Azure.ResourceManager.Models.Resource
    {
        public ManagementPolicyData() { }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicySchema Policy { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ObjectReplicationPolicy() { }
        public virtual Azure.ResourceManager.Storage.ObjectReplicationPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectReplicationPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicy>, System.Collections.IEnumerable
    {
        protected ObjectReplicationPolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyCreateOrUpdateOperation CreateOrUpdate(string objectReplicationPolicyId, Azure.ResourceManager.Storage.ObjectReplicationPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(string objectReplicationPolicyId, Azure.ResourceManager.Storage.ObjectReplicationPolicyData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy> Get(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.ObjectReplicationPolicy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.ObjectReplicationPolicy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy>> GetAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy> GetIfExists(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy>> GetIfExistsAsync(string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.ObjectReplicationPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.ObjectReplicationPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ObjectReplicationPolicyData : Azure.ResourceManager.Models.Resource
    {
        public ObjectReplicationPolicyData() { }
        public string DestinationAccount { get { throw null; } set { } }
        public System.DateTimeOffset? EnabledTime { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ObjectReplicationPolicyRule> Rules { get { throw null; } }
        public string SourceAccount { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.Storage.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionPutOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.Storage.PrivateEndpointConnectionData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionPutOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.Storage.PrivateEndpointConnectionData properties, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class QueueService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected QueueService() { }
        public virtual Azure.ResourceManager.Storage.QueueServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.QueueServiceSetServicePropertiesOperation CreateOrUpdate(Azure.ResourceManager.Storage.QueueServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.QueueServiceSetServicePropertiesOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.QueueServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.QueueService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.QueueService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.StorageQueueCollection GetStorageQueues() { throw null; }
    }
    public partial class QueueServiceData : Azure.ResourceManager.Models.Resource
    {
        public QueueServiceData() { }
        public Azure.ResourceManager.Storage.Models.CorsRules Cors { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Storage.StorageAccountCollection GetStorageAccounts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class StorageAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected StorageAccount() { }
        public virtual Azure.ResourceManager.Storage.StorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.StorageAccountDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.StorageAccountDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.StorageAccountFailoverOperation Failover(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.StorageAccountFailoverOperation> FailoverAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> Get(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.ListAccountSasResponse> GetAccountSAS(Azure.ResourceManager.Storage.Models.AccountSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.ListAccountSasResponse>> GetAccountSASAsync(Azure.ResourceManager.Storage.Models.AccountSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> GetAsync(Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.BlobInventoryPolicyCollection GetBlobInventoryPolicies() { throw null; }
        public Azure.ResourceManager.Storage.BlobService GetBlobService() { throw null; }
        public Azure.ResourceManager.Storage.EncryptionScopeCollection GetEncryptionScopes() { throw null; }
        public Azure.ResourceManager.Storage.FileService GetFileService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.ManagementPolicy GetManagementPolicy() { throw null; }
        public Azure.ResourceManager.Storage.ObjectReplicationPolicyCollection GetObjectReplicationPolicies() { throw null; }
        public Azure.ResourceManager.Storage.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.PrivateLinkResource>> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.PrivateLinkResource>>> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.QueueService GetQueueService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.ListServiceSasResponse> GetServiceSAS(Azure.ResourceManager.Storage.Models.ServiceSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.ListServiceSasResponse>> GetServiceSASAsync(Azure.ResourceManager.Storage.Models.ServiceSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.TableService GetTableService() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult> RegenerateKey(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyParameters regenerateKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.StorageAccountListKeysResult>> RegenerateKeyAsync(Azure.ResourceManager.Storage.Models.StorageAccountRegenerateKeyParameters regenerateKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.StorageAccountRestoreBlobRangesOperation RestoreBlobRanges(Azure.ResourceManager.Storage.Models.BlobRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.StorageAccountRestoreBlobRangesOperation> RestoreBlobRangesAsync(Azure.ResourceManager.Storage.Models.BlobRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeUserDelegationKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeUserDelegationKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> Update(Azure.ResourceManager.Storage.Models.StorageAccountUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> UpdateAsync(Azure.ResourceManager.Storage.Models.StorageAccountUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccount>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccount>, System.Collections.IEnumerable
    {
        protected StorageAccountCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.StorageAccountCreateOperation CreateOrUpdate(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountCreateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.StorageAccountCreateOperation> CreateOrUpdateAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountCreateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> Get(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageAccount> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccount> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> GetAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageAccount> GetIfExists(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> GetIfExistsAsync(string accountName, Azure.ResourceManager.Storage.Models.StorageAccountExpand? expand = default(Azure.ResourceManager.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageAccount> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageAccount>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageAccount> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageAccount>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountData : Azure.ResourceManager.Models.TrackedResource
    {
        public StorageAccountData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreStatus BlobRestoreStatus { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public bool? EnableNfsV3 { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public bool? FailoverInProgress { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.GeoReplicationStats GeoReplicationStats { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyCreationTime KeyCreationTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.KeyPolicy KeyPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Kind? Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public System.DateTimeOffset? LastGeoFailoverTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Endpoints PrimaryEndpoints { get { throw null; } }
        public string PrimaryLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Endpoints SecondaryEndpoints { get { throw null; } }
        public string SecondaryLocation { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Sku Sku { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.AccountStatus? StatusOfPrimary { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.AccountStatus? StatusOfSecondary { get { throw null; } }
    }
    public partial class StorageQueue : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected StorageQueue() { }
        public virtual Azure.ResourceManager.Storage.StorageQueueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.QueueDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.QueueDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueue> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueue> Update(Azure.ResourceManager.Storage.StorageQueueData queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> UpdateAsync(Azure.ResourceManager.Storage.StorageQueueData queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageQueueCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageQueue>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageQueue>, System.Collections.IEnumerable
    {
        protected StorageQueueCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.QueueCreateOperation CreateOrUpdate(string queueName, Azure.ResourceManager.Storage.StorageQueueData queue, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.QueueCreateOperation> CreateOrUpdateAsync(string queueName, Azure.ResourceManager.Storage.StorageQueueData queue, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueue> Get(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.StorageQueue> GetAll(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageQueue> GetAllAsync(string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> GetAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.StorageQueue> GetIfExists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> GetIfExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.StorageQueue> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.StorageQueue>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.StorageQueue> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.StorageQueue>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageQueueData : Azure.ResourceManager.Models.Resource
    {
        public StorageQueueData() { }
        public int? ApproximateMessageCount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Storage.Models.CheckNameAvailabilityResult> CheckNameAvailabilityStorageAccount(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Storage.Models.StorageAccountCheckNameAvailabilityParameters accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityStorageAccountAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Storage.Models.StorageAccountCheckNameAvailabilityParameters accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetDeletedAccountByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetDeletedAccountByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Storage.DeletedAccountCollection GetDeletedAccounts(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.DeletedAccountData> GetDeletedAccounts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.DeletedAccountData> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.SkuInformation> GetSkus(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.SkuInformation> GetSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetStorageAccountByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetStorageAccountByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.StorageAccount> GetStorageAccounts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.StorageAccount> GetStorageAccountsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Storage.Models.Usage> GetUsagesByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Storage.Models.Usage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Table : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected Table() { }
        public virtual Azure.ResourceManager.Storage.TableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.TableDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.TableDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Table> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Table>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Table> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Table>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.Table>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Table>, System.Collections.IEnumerable
    {
        protected TableCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Storage.Models.TableCreateOperation CreateOrUpdate(string tableName, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.TableCreateOperation> CreateOrUpdateAsync(string tableName, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Table> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Storage.Table> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Storage.Table> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Table>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.Table> GetIfExists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.Table>> GetIfExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Storage.Table> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Storage.Table>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Storage.Table> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Table>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TableData : Azure.ResourceManager.Models.Resource
    {
        public TableData() { }
        public string TableName { get { throw null; } }
    }
    public partial class TableService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected TableService() { }
        public virtual Azure.ResourceManager.Storage.TableServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Storage.Models.TableServiceSetServicePropertiesOperation CreateOrUpdate(Azure.ResourceManager.Storage.TableServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Storage.Models.TableServiceSetServicePropertiesOperation> CreateOrUpdateAsync(Azure.ResourceManager.Storage.TableServiceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Storage.TableService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Storage.TableService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Storage.TableCollection GetTables() { throw null; }
    }
    public partial class TableServiceData : Azure.ResourceManager.Models.Resource
    {
        public TableServiceData() { }
        public Azure.ResourceManager.Storage.Models.CorsRules Cors { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccessPolicy
    {
        public AccessPolicy() { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } set { } }
        public string Permission { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
    }
    public enum AccessTier
    {
        Hot = 0,
        Cool = 1,
    }
    public partial class AccountSasParameters
    {
        public AccountSasParameters(Azure.ResourceManager.Storage.Models.Services services, Azure.ResourceManager.Storage.Models.SignedResourceTypes resourceTypes, Azure.ResourceManager.Storage.Models.Permissions permissions, System.DateTimeOffset sharedAccessExpiryTime) { }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Permissions Permissions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.HttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SignedResourceTypes ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Services Services { get { throw null; } }
        public System.DateTimeOffset SharedAccessExpiryTime { get { throw null; } }
        public System.DateTimeOffset? SharedAccessStartTime { get { throw null; } set { } }
    }
    public enum AccountStatus
    {
        Available = 0,
        Unavailable = 1,
    }
    public partial class ActiveDirectoryProperties
    {
        public ActiveDirectoryProperties(string domainName, string netBiosDomainName, string forestName, string domainGuid, string domainSid, string azureStorageSid) { }
        public string AzureStorageSid { get { throw null; } set { } }
        public string DomainGuid { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainSid { get { throw null; } set { } }
        public string ForestName { get { throw null; } set { } }
        public string NetBiosDomainName { get { throw null; } set { } }
    }
    public partial class AzureEntityResource : Azure.ResourceManager.Models.Resource
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
    public partial class BlobContainerCreateOperation : Azure.Operation<Azure.ResourceManager.Storage.BlobContainer>
    {
        protected BlobContainerCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.BlobContainer Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerCreateOrUpdateImmutabilityPolicyOperation : Azure.Operation<Azure.ResourceManager.Storage.ImmutabilityPolicy>
    {
        protected BlobContainerCreateOrUpdateImmutabilityPolicyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.ImmutabilityPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerDeleteImmutabilityPolicyOperation : Azure.Operation<Azure.ResourceManager.Storage.ImmutabilityPolicyData>
    {
        protected BlobContainerDeleteImmutabilityPolicyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.ImmutabilityPolicyData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ImmutabilityPolicyData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerDeleteOperation : Azure.Operation
    {
        protected BlobContainerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerObjectLevelWormOperation : Azure.Operation
    {
        protected BlobContainerObjectLevelWormOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobContainerUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.BlobContainer>
    {
        protected BlobContainerUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.BlobContainer Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobContainer>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobInventoryPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.BlobInventoryPolicy>
    {
        protected BlobInventoryPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.BlobInventoryPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobInventoryPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class BlobInventoryPolicyDeleteOperation : Azure.Operation
    {
        protected BlobInventoryPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public BlobInventoryPolicySchema(bool enabled, Azure.ResourceManager.Storage.Models.InventoryRuleType type, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> rules) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.BlobInventoryPolicyRule> Rules { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.InventoryRuleType Type { get { throw null; } set { } }
    }
    public partial class BlobRestoreParameters
    {
        public BlobRestoreParameters(System.DateTimeOffset timeToRestore, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.BlobRestoreRange> blobRanges) { }
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
        public Azure.ResourceManager.Storage.Models.BlobRestoreParameters Parameters { get { throw null; } }
        public string RestoreId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.BlobRestoreProgressStatus? Status { get { throw null; } }
    }
    public partial class BlobServiceSetServicePropertiesOperation : Azure.Operation<Azure.ResourceManager.Storage.BlobService>
    {
        protected BlobServiceSetServicePropertiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.BlobService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.BlobService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CorsRules
    {
        public CorsRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Storage.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.CreatedByType left, Azure.ResourceManager.Storage.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.CreatedByType left, Azure.ResourceManager.Storage.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomDomain
    {
        public CustomDomain(string name) { }
        public string Name { get { throw null; } set { } }
        public bool? UseSubDomainName { get { throw null; } set { } }
    }
    public partial class DateAfterCreation
    {
        public DateAfterCreation(float daysAfterCreationGreaterThan) { }
        public float DaysAfterCreationGreaterThan { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Storage.Models.DefaultSharePermission StorageFileDataSmbShareOwner { get { throw null; } }
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
        public string EncryptionUserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class EncryptionScopeKeyVaultProperties
    {
        public EncryptionScopeKeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyUri { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
    }
    public partial class EncryptionScopePatchOperation : Azure.Operation<Azure.ResourceManager.Storage.EncryptionScope>
    {
        protected EncryptionScopePatchOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.EncryptionScope Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionScopePutOperation : Azure.Operation<Azure.ResourceManager.Storage.EncryptionScope>
    {
        protected EncryptionScopePutOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.EncryptionScope Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.EncryptionScope>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastEnabledTime { get { throw null; } }
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
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExtendedLocationTypes? Type { get { throw null; } set { } }
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
    public partial class FileServiceItems
    {
        internal FileServiceItems() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.FileServiceData> Value { get { throw null; } }
    }
    public partial class FileServiceSetServicePropertiesOperation : Azure.Operation<Azure.ResourceManager.Storage.FileService>
    {
        protected FileServiceSetServicePropertiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.FileService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileShareCreateOperation : Azure.Operation<Azure.ResourceManager.Storage.FileShare>
    {
        protected FileShareCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.FileShare Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileShare>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileShare>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileShareDeleteOperation : Azure.Operation
    {
        protected FileShareDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileShareItem : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public FileShareItem() { }
        public Azure.ResourceManager.Storage.Models.ShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeTime { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.EnabledProtocols? EnabledProtocols { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.SignedIdentifier> SignedIdentifiers { get { throw null; } }
        public System.DateTimeOffset? SnapshotTime { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class FileShareUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.FileShare>
    {
        protected FileShareUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.FileShare Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileShare>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.FileShare>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastSyncTime { get { throw null; } }
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
    public partial class Identity
    {
        public Identity(Azure.ResourceManager.Storage.Models.IdentityType type) { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.IdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.Storage.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.IdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.IdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.IdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.IdentityType left, Azure.ResourceManager.Storage.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.IdentityType left, Azure.ResourceManager.Storage.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImmutabilityPolicyProperties
    {
        internal ImmutabilityPolicyProperties() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } }
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
        public IPRule(string iPAddressOrRange) { }
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
    public partial class KeyPolicy
    {
        public KeyPolicy(int keyExpirationPeriodInDays) { }
        public int KeyExpirationPeriodInDays { get { throw null; } set { } }
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
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Kind : System.IEquatable<Azure.ResourceManager.Storage.Models.Kind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Kind(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.Kind BlobStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Kind BlockBlobStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Kind FileStorage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Kind Storage { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.Kind StorageV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.Kind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.Kind left, Azure.ResourceManager.Storage.Models.Kind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.Kind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.Kind left, Azure.ResourceManager.Storage.Models.Kind right) { throw null; }
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
        public LastAccessTimeTrackingPolicy(bool enable) { }
        public System.Collections.Generic.IList<string> BlobType { get { throw null; } }
        public bool Enable { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Name? Name { get { throw null; } set { } }
        public int? TrackingGranularityInDays { get { throw null; } set { } }
    }
    public partial class LeaseContainerRequest
    {
        public LeaseContainerRequest(Azure.ResourceManager.Storage.Models.LeaseContainerRequestAction action) { }
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
    public partial class LeaseShareRequest
    {
        public LeaseShareRequest(Azure.ResourceManager.Storage.Models.LeaseShareAction action) { }
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
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    public partial class LegalHoldProperties
    {
        internal LegalHoldProperties() { }
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.TagProperty> Tags { get { throw null; } }
    }
    public partial class ListAccountSasResponse
    {
        internal ListAccountSasResponse() { }
        public string AccountSasToken { get { throw null; } }
    }
    public partial class ListContainerItem : Azure.ResourceManager.Storage.Models.AzureEntityResource
    {
        public ListContainerItem() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public bool? DenyEncryptionScopeOverride { get { throw null; } set { } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutableStorageWithVersioning ImmutableStorageWithVersioning { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.PublicAccess? PublicAccess { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public string Version { get { throw null; } }
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
    public partial class ListQueue : Azure.ResourceManager.Models.Resource
    {
        public ListQueue() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class ListQueueServices
    {
        internal ListQueueServices() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.QueueServiceData> Value { get { throw null; } }
    }
    public partial class ListServiceSasResponse
    {
        internal ListServiceSasResponse() { }
        public string ServiceSasToken { get { throw null; } }
    }
    public partial class ListTableServices
    {
        internal ListTableServices() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.TableServiceData> Value { get { throw null; } }
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
    public partial class ManagementPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.ManagementPolicy>
    {
        protected ManagementPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.ManagementPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ManagementPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ManagementPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementPolicyDefinition
    {
        public ManagementPolicyDefinition(Azure.ResourceManager.Storage.Models.ManagementPolicyAction actions) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyAction Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyFilter Filters { get { throw null; } set { } }
    }
    public partial class ManagementPolicyDeleteOperation : Azure.Operation
    {
        protected ManagementPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public ManagementPolicyRule(string name, Azure.ResourceManager.Storage.Models.RuleType type, Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition definition) { }
        public Azure.ResourceManager.Storage.Models.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RuleType Type { get { throw null; } set { } }
    }
    public partial class ManagementPolicySchema
    {
        public ManagementPolicySchema(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> rules) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ManagementPolicyRule> Rules { get { throw null; } }
    }
    public partial class ManagementPolicySnapShot
    {
        public ManagementPolicySnapShot() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
    }
    public partial class ManagementPolicyVersion
    {
        public ManagementPolicyVersion() { }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToArchive { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.DateAfterCreation TierToCool { get { throw null; } set { } }
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
    public partial class Multichannel
    {
        public Multichannel() { }
        public bool? Enabled { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.IPRule> IpRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.ResourceAccessRule> ResourceAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Storage.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class ObjectReplicationPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.ObjectReplicationPolicy>
    {
        protected ObjectReplicationPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.ObjectReplicationPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.ObjectReplicationPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectReplicationPolicyDeleteOperation : Azure.Operation
    {
        protected ObjectReplicationPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Storage.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionPutOperation : Azure.Operation<Azure.ResourceManager.Storage.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionPutOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ProtocolSettings
    {
        public ProtocolSettings() { }
        public Azure.ResourceManager.Storage.Models.SmbSetting Smb { get { throw null; } set { } }
    }
    public enum ProvisioningState
    {
        Creating = 0,
        ResolvingDNS = 1,
        Succeeded = 2,
    }
    public enum PublicAccess
    {
        Container = 0,
        Blob = 1,
        None = 2,
    }
    public partial class QueueCreateOperation : Azure.Operation<Azure.ResourceManager.Storage.StorageQueue>
    {
        protected QueueCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.StorageQueue Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueDeleteOperation : Azure.Operation
    {
        protected QueueDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueServiceSetServicePropertiesOperation : Azure.Operation<Azure.ResourceManager.Storage.QueueService>
    {
        protected QueueServiceSetServicePropertiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.QueueService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.QueueService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.QueueService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.StorageQueue>
    {
        protected QueueUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.StorageQueue Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageQueue>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastEnabledTime { get { throw null; } }
        public System.DateTimeOffset? MinRestoreTime { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.ResourceManager.Storage.Models.ReasonCode? ReasonCode { get { throw null; } }
        public string Type { get { throw null; } }
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
    public partial class ServiceSasParameters
    {
        public ServiceSasParameters(string canonicalizedResource) { }
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
        public System.DateTimeOffset? SharedAccessExpiryTime { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessStartTime { get { throw null; } set { } }
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
    public partial class Sku
    {
        public Sku(Azure.ResourceManager.Storage.Models.SkuName name) { }
        public Azure.ResourceManager.Storage.Models.SkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SkuTier? Tier { get { throw null; } }
    }
    public partial class SKUCapability
    {
        internal SKUCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuInformation
    {
        internal SkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.SKUCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.Kind? Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.SkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Storage.Models.Restriction> Restrictions { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.SkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuName : System.IEquatable<Azure.ResourceManager.Storage.Models.SkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuName(string value) { throw null; }
        public static Azure.ResourceManager.Storage.Models.SkuName PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardGRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardGzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardRagrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardRagzrs { get { throw null; } }
        public static Azure.ResourceManager.Storage.Models.SkuName StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Storage.Models.SkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Storage.Models.SkuName left, Azure.ResourceManager.Storage.Models.SkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Storage.Models.SkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Storage.Models.SkuName left, Azure.ResourceManager.Storage.Models.SkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class SmbSetting
    {
        public SmbSetting() { }
        public string AuthenticationMethods { get { throw null; } set { } }
        public string ChannelEncryption { get { throw null; } set { } }
        public string KerberosTicketEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Multichannel Multichannel { get { throw null; } set { } }
        public string Versions { get { throw null; } set { } }
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
    public partial class StorageAccountCheckNameAvailabilityParameters
    {
        public StorageAccountCheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class StorageAccountCreateOperation : Azure.Operation<Azure.ResourceManager.Storage.StorageAccount>
    {
        protected StorageAccountCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.StorageAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountCreateParameters
    {
        public StorageAccountCreateParameters(Azure.ResourceManager.Storage.Models.Sku sku, Azure.ResourceManager.Storage.Models.Kind kind, string location) { }
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public bool? EnableNfsV3 { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyPolicy KeyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Kind Kind { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Sku Sku { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StorageAccountDeleteOperation : Azure.Operation
    {
        protected StorageAccountDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum StorageAccountExpand
    {
        GeoReplicationStats = 0,
        BlobRestoreStatus = 1,
    }
    public partial class StorageAccountFailoverOperation : Azure.Operation
    {
        protected StorageAccountFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? CreationTime { get { throw null; } }
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
    public partial class StorageAccountRegenerateKeyParameters
    {
        public StorageAccountRegenerateKeyParameters(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class StorageAccountRestoreBlobRangesOperation : Azure.Operation<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>
    {
        protected StorageAccountRestoreBlobRangesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.Models.BlobRestoreStatus Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.StorageAccount>
    {
        protected StorageAccountUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.StorageAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.StorageAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountUpdateParameters
    {
        public StorageAccountUpdateParameters() { }
        public Azure.ResourceManager.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public bool? AllowBlobPublicAccess { get { throw null; } set { } }
        public bool? AllowCrossTenantReplication { get { throw null; } set { } }
        public bool? AllowSharedKeyAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.KeyPolicy KeyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Kind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.MinimumTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.SasPolicy SasPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Storage.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TableCreateOperation : Azure.Operation<Azure.ResourceManager.Storage.Table>
    {
        protected TableCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.Table Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Table>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Table>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableDeleteOperation : Azure.Operation
    {
        protected TableDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableServiceSetServicePropertiesOperation : Azure.Operation<Azure.ResourceManager.Storage.TableService>
    {
        protected TableServiceSetServicePropertiesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.TableService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.TableService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.TableService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableUpdateOperation : Azure.Operation<Azure.ResourceManager.Storage.Table>
    {
        protected TableUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Storage.Table Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Table>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Storage.Table>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public string ObjectIdentifier { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.ImmutabilityPolicyUpdateType? Update { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class Usage
    {
        internal Usage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.Storage.Models.UsageUnit? Unit { get { throw null; } }
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
