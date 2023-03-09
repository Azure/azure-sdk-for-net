namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class BackupEngineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>, System.Collections.IEnumerable
    {
        protected BackupEngineCollection() { }
        public virtual Azure.Response<bool> Exists(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> Get(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetAsync(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupEngineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupEngineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine Properties { get { throw null; } set { } }
    }
    public partial class BackupEngineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupEngineResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupEngineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> Get(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>, System.Collections.IEnumerable
    {
        protected BackupJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupJobData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupJobData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob Properties { get { throw null; } set { } }
    }
    public partial class BackupJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupJobResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerJobCancellation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerJobCancellationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Get(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupPrivateEndpointConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class BackupPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectedItemCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectedItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Get(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectedItemData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupProtectedItemData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem Properties { get { throw null; } set { } }
    }
    public partial class BackupProtectedItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectedItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Get(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetBackupRecoveryPoint(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetBackupRecoveryPointAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointCollection GetBackupRecoveryPoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetRecoveryPointsRecommendedForMove(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetRecoveryPointsRecommendedForMoveAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerBackup(Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerBackupAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionContainerCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectionContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Get(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionContainerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupProtectionContainerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer Properties { get { throw null; } set { } }
    }
    public partial class BackupProtectionContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionContainerResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItem(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetBackupProtectedItemAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemCollection GetBackupProtectedItems() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItems(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItemsAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Inquire(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> InquireAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionIntentCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectionIntentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Get(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionIntentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupProtectionIntentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent Properties { get { throw null; } set { } }
    }
    public partial class BackupProtectionIntentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionIntentResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string intentObjectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>, System.Collections.IEnumerable
    {
        protected BackupProtectionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupProtectionPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupProtectionPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy Properties { get { throw null; } set { } }
    }
    public partial class BackupProtectionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionPolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected BackupRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupRecoveryPointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupRecoveryPointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint Properties { get { throw null; } set { } }
    }
    public partial class BackupRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MoveRecoveryPoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveRecoveryPointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ProvisionItemLevelRecoveryConnection(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ProvisionItemLevelRecoveryConnectionAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeItemLevelRecoveryConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeItemLevelRecoveryConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceConfigCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceConfigData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupResourceConfigData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties Properties { get { throw null; } set { } }
    }
    public partial class BackupResourceConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceConfigResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PrepareDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PrepareDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Update(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> UpdateAsync(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceEncryptionConfigExtendedCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupResourceEncryptionConfigExtendedData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties Properties { get { throw null; } set { } }
    }
    public partial class BackupResourceEncryptionConfigExtendedResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceEncryptionConfigExtendedResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceVaultConfigCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceVaultConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceVaultConfigData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupResourceVaultConfigData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties Properties { get { throw null; } set { } }
    }
    public partial class BackupResourceVaultConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceVaultConfigResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Update(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> UpdateAsync(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesBackupExtensions
    {
        public static Azure.Response ExportJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ExportJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetBackupEngine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetBackupEngineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource GetBackupEngineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupEngineCollection GetBackupEngines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetBackupJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetBackupJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource GetBackupJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupJobCollection GetBackupJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> GetBackupPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetBackupPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource GetBackupPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionCollection GetBackupPrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource GetBackupProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetBackupProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource GetBackupProtectionContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerCollection GetBackupProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetBackupProtectionIntentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource GetBackupProtectionIntentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentCollection GetBackupProtectionIntents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyCollection GetBackupProtectionPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetBackupProtectionPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetBackupProtectionPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource GetBackupProtectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource GetBackupRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> GetBackupResourceConfig(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetBackupResourceConfigAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource GetBackupResourceConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigCollection GetBackupResourceConfigs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> GetBackupResourceEncryptionConfigExtended(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetBackupResourceEncryptionConfigExtendedAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource GetBackupResourceEncryptionConfigExtendedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedCollection GetBackupResourceEncryptionConfigExtendeds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> GetBackupResourceVaultConfig(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetBackupResourceVaultConfigAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource GetBackupResourceVaultConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigCollection GetBackupResourceVaultConfigs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult> GetBackupStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>> GetBackupStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummaries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummariesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyCollection GetResourceGuardProxies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetResourceGuardProxy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetResourceGuardProxyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource GetResourceGuardProxyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPin(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPinAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response RefreshProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RefreshProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult> ValidateFeatureSupport(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>> ValidateFeatureSupportAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult> ValidateProtectionIntent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>> ValidateProtectionIntentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardProxyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Get(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGuardProxyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardProxyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardProxyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string resourceGuardProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult> UnlockDelete(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>> UnlockDeleteAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcquireStorageAccountLock : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcquireStorageAccountLock(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock Acquire { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock NotAcquire { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock left, Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock left, Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupCommonSettings
    {
        public BackupCommonSettings() { }
        public bool? IsCompression { get { throw null; } set { } }
        public bool? IsSqlCompression { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public abstract partial class BackupContent
    {
        protected BackupContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupCreateMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Recover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupDataSourceType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupDataSourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupDay
    {
        public BackupDay() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
    }
    public enum BackupDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupEncryptionAtRestType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupEncryptionAtRestType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupEngineExtendedInfo
    {
        public BackupEngineExtendedInfo() { }
        public double? AvailableDiskSpace { get { throw null; } set { } }
        public int? AzureProtectedInstances { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public int? DiskCount { get { throw null; } set { } }
        public int? ProtectedItemsCount { get { throw null; } set { } }
        public int? ProtectedServersCount { get { throw null; } set { } }
        public System.DateTimeOffset? RefreshedOn { get { throw null; } set { } }
        public double? UsedDiskSpace { get { throw null; } set { } }
    }
    public partial class BackupErrorDetail
    {
        public BackupErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupFabricName : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupFabricName(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName Azure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupFileShareType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupFileShareType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType Xsmb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType XSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BackupGenericEngine
    {
        protected BackupGenericEngine() { }
        public string AzureBackupAgentVersion { get { throw null; } set { } }
        public string BackupEngineId { get { throw null; } set { } }
        public string BackupEngineState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public bool? CanReRegister { get { throw null; } set { } }
        public string DpmVersion { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        public bool? IsAzureBackupAgentUpgradeAvailable { get { throw null; } set { } }
        public bool? IsDpmUpgradeAvailable { get { throw null; } set { } }
        public string RegistrationStatus { get { throw null; } set { } }
    }
    public abstract partial class BackupGenericJob
    {
        protected BackupGenericJob() { }
        public string ActivityId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EntityFriendlyName { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public abstract partial class BackupGenericProtectedItem
    {
        protected BackupGenericProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } }
        public string BackupSetName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? DeferredDeletedOn { get { throw null; } set { } }
        public string DeferredDeleteTimeRemaining { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public bool? IsDeferredDeleteScheduleUpcoming { get { throw null; } set { } }
        public bool? IsRehydrate { get { throw null; } set { } }
        public bool? IsScheduledForDeferredDelete { get { throw null; } set { } }
        public System.DateTimeOffset? LastRecoverOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public int? SoftDeleteRetentionPeriod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? WorkloadType { get { throw null; } }
    }
    public abstract partial class BackupGenericProtectionContainer
    {
        protected BackupGenericProtectionContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        public string ProtectableObjectType { get { throw null; } set { } }
        public string RegistrationStatus { get { throw null; } set { } }
    }
    public abstract partial class BackupGenericProtectionIntent
    {
        protected BackupGenericProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ItemId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
    }
    public abstract partial class BackupGenericProtectionPolicy
    {
        protected BackupGenericProtectionPolicy() { }
        public int? ProtectedItemsCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
    }
    public abstract partial class BackupGenericRecoveryPoint
    {
        protected BackupGenericRecoveryPoint() { }
    }
    public partial class BackupGoalFeatureSupportContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent
    {
        public BackupGoalFeatureSupportContent() { }
    }
    public partial class BackupHourlySchedule
    {
        public BackupHourlySchedule() { }
        public int? Interval { get { throw null; } set { } }
        public int? ScheduleWindowDuration { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduleWindowStartOn { get { throw null; } set { } }
    }
    public partial class BackupIdentityInfo
    {
        public BackupIdentityInfo() { }
        public bool? IsSystemAssignedIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupItemType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupItemType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupManagementType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupManagementType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureBackupServer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureIaasVm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureSql { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureStorage { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureWorkload { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType BackupProtectedItemCountSummary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType BackupProtectionContainerCountSummary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType DefaultBackup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Dpm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Mab { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupManagementUsage
    {
        internal BackupManagementUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit? Unit { get { throw null; } }
    }
    public enum BackupMonthOfYear
    {
        Invalid = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }
    public partial class BackupNameInfo
    {
        internal BackupNameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class BackupPrivateEndpointConnectionProperties
    {
        public BackupPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupProtectionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState BackupsSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionPaused { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionStopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupProtectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Protecting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus ProtectionFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupResourceConfigProperties
    {
        public BackupResourceConfigProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState? DedupState { get { throw null; } set { } }
        public bool? EnableCrossRegionRestore { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState? StorageTypeState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState? XcoolState { get { throw null; } set { } }
    }
    public partial class BackupResourceEncryptionConfig
    {
        public BackupResourceEncryptionConfig() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType? EncryptionAtRestType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState? InfrastructureEncryptionState { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus? LastUpdateStatus { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BackupResourceEncryptionConfigExtendedCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig Properties { get { throw null; } set { } }
    }
    public partial class BackupResourceEncryptionConfigExtendedProperties : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig
    {
        public BackupResourceEncryptionConfigExtendedProperties() { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    public partial class BackupResourceVaultConfigProperties
    {
        public BackupResourceVaultConfigProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState? EnhancedSecurityState { get { throw null; } set { } }
        public bool? IsSoftDeleteFeatureStateEditable { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState? SoftDeleteFeatureState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState? StorageTypeState { get { throw null; } set { } }
    }
    public abstract partial class BackupRetentionPolicy
    {
        protected BackupRetentionPolicy() { }
    }
    public abstract partial class BackupSchedulePolicy
    {
        protected BackupSchedulePolicy() { }
    }
    public partial class BackupServerContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer
    {
        public BackupServerContainer() { }
    }
    public partial class BackupServerEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine
    {
        public BackupServerEngine() { }
    }
    public partial class BackupStatusContent
    {
        public BackupStatusContent() { }
        public string PoLogicalName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class BackupStatusResult
    {
        internal BackupStatusResult() { }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName? FabricName { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionStatus { get { throw null; } }
        public string RegistrationStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType ReadAccessGeoZoneRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageTypeState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageTypeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Locked { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupTieringPolicy
    {
        public BackupTieringPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType? DurationType { get { throw null; } set { } }
        public int? DurationValue { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode? TieringMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType CopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupUsagesUnit : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupUsagesUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupValidationStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupWeeklySchedule
    {
        public BackupWeeklySchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> ScheduleRunDays { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
    }
    public enum BackupWeekOfMonth
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
        Invalid = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupWorkloadType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BekDetails
    {
        public BekDetails() { }
        public string SecretData { get { throw null; } set { } }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretVaultId { get { throw null; } set { } }
    }
    public partial class ContainerIdentityInfo
    {
        public ContainerIdentityInfo() { }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string ServicePrincipalClientId { get { throw null; } set { } }
        public string UniqueName { get { throw null; } set { } }
    }
    public partial class DailyRetentionSchedule
    {
        public DailyRetentionSchedule() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMoveLevel : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMoveLevel(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Container { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Vault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskExclusionProperties
    {
        public DiskExclusionProperties() { }
        public System.Collections.Generic.IList<int> DiskLunList { get { throw null; } }
        public bool? IsInclusionList { get { throw null; } set { } }
    }
    public partial class DiskInformation
    {
        public DiskInformation() { }
        public int? Lun { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DistributedNodesInfo
    {
        public DistributedNodesInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class DpmBackupEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine
    {
        public DpmBackupEngine() { }
    }
    public partial class DpmBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public DpmBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public string ContainerType { get { throw null; } set { } }
        public string DpmServerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class DpmBackupJobExtendedInfo
    {
        public DpmBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class DpmBackupJobTaskDetails
    {
        public DpmBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class DpmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public DpmContainer() { }
        public bool? CanReRegister { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public string DpmAgentVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DpmServers { get { throw null; } }
        public System.DateTimeOffset? ExtendedInfoLastRefreshedOn { get { throw null; } set { } }
        public bool? IsUpgradeAvailable { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
    }
    public partial class DpmErrorInfo
    {
        public DpmErrorInfo() { }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class DpmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public DpmProtectedItem() { }
        public string BackupEngineName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? ProtectionState { get { throw null; } set { } }
    }
    public partial class DpmProtectedItemExtendedInfo
    {
        public DpmProtectedItemExtendedInfo() { }
        public string DiskStorageUsedInBytes { get { throw null; } set { } }
        public bool? IsCollocated { get { throw null; } set { } }
        public bool? IsPresentOnCloud { get { throw null; } set { } }
        public bool? IsProtected { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseLatestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseOldestRecoverOn { get { throw null; } set { } }
        public int? OnPremiseRecoveryPointCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ProtectableObjectLoadPath { get { throw null; } }
        public string ProtectionGroupName { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string TotalDiskStorageSizeInBytes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnhancedSecurityState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnhancedSecurityState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState left, Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState left, Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class FeatureSupportContent
    {
        protected FeatureSupportContent() { }
    }
    public partial class FileShareBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent
    {
        public FileShareBackupContent() { }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareCopyOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareCopyOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption CreateCopy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Overwrite { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Skip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem
    {
        public FileShareProtectableItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType? AzureFileShareType { get { throw null; } set { } }
        public string ParentContainerFabricId { get { throw null; } set { } }
        public string ParentContainerFriendlyName { get { throw null; } set { } }
    }
    public partial class FileshareProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public FileshareProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
    }
    public partial class FileshareProtectedItemExtendedInfo
    {
        public FileshareProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string ResourceState { get { throw null; } }
        public System.DateTimeOffset? ResourceStateSyncOn { get { throw null; } }
    }
    public partial class FileShareProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public FileShareProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkLoadType { get { throw null; } set { } }
    }
    public partial class FileShareProvisionIlrContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent
    {
        public FileShareProvisionIlrContent() { }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
    }
    public partial class FileShareRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint
    {
        public FileShareRecoveryPoint() { }
        public System.Uri FileShareSnapshotUri { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public int? RecoveryPointSizeInGB { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareRecoveryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareRecoveryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType AlternateLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType Offline { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType OriginalLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType RestoreDisks { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent
    {
        public FileShareRestoreContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption? CopyOptions { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs> RestoreFileSpecs { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType? RestoreRequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo TargetDetails { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareRestoreType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareRestoreType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType FullShareRestore { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType ItemLevelRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenericContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public GenericContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo ExtendedInformation { get { throw null; } set { } }
        public string FabricName { get { throw null; } set { } }
    }
    public partial class GenericContainerExtendedInfo
    {
        public GenericContainerExtendedInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo ContainerIdentityInfo { get { throw null; } set { } }
        public string RawCertData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ServiceEndpoints { get { throw null; } }
    }
    public partial class GenericProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public GenericProtectedItem() { }
        public string FabricName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public long? ProtectedItemId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceAssociations { get { throw null; } }
    }
    public partial class GenericProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public GenericProtectionPolicy() { }
        public string FabricName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class GenericRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint
    {
        public GenericRecoveryPoint() { }
        public string FriendlyName { get { throw null; } set { } }
        public string RecoveryPointAdditionalInfo { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
    }
    public partial class IaasClassicComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer
    {
        public IaasClassicComputeVmContainer() { }
    }
    public partial class IaasClassicComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem
    {
        public IaasClassicComputeVmProtectableItem() { }
    }
    public partial class IaasClassicComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem
    {
        public IaasClassicComputeVmProtectedItem() { }
    }
    public partial class IaasComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer
    {
        public IaasComputeVmContainer() { }
    }
    public partial class IaasComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem
    {
        public IaasComputeVmProtectableItem() { }
    }
    public partial class IaasComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem
    {
        public IaasComputeVmProtectedItem() { }
    }
    public partial class IaasVmBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent
    {
        public IaasVmBackupContent() { }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
    }
    public partial class IaasVmBackupExtendedProperties
    {
        public IaasVmBackupExtendedProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties DiskExclusionProperties { get { throw null; } set { } }
        public string LinuxVmApplicationName { get { throw null; } set { } }
    }
    public partial class IaasVmBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public IaasVmBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmBackupJobExtendedInfo
    {
        public IaasVmBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public string EstimatedRemainingDurationValue { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> InternalPropertyBag { get { throw null; } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class IaasVmBackupJobTaskDetails
    {
        public IaasVmBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string InstanceId { get { throw null; } set { } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskExecutionDetails { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class IaasVmBackupJobV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public IaasVmBackupJobV2() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public IaasVmContainer() { }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmErrorInfo
    {
        public IaasVmErrorInfo() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorString { get { throw null; } }
        public string ErrorTitle { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    public partial class IaasVmHealthDetails : Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails
    {
        public IaasVmHealthDetails() { }
    }
    public partial class IaasVmIlrRegistrationContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent
    {
        public IaasVmIlrRegistrationContent() { }
        public string InitiatorName { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public bool? RenewExistingRegistration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IaasVmPolicyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IaasVmPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType V1 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IaasVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem
    {
        public IaasVmProtectableItem() { }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public IaasVmProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties ExtendedProperties { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> HealthDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } }
        public string LastBackupStatus { get { throw null; } set { } }
        public string ProtectedItemDataId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
    }
    public partial class IaasVmProtectedItemExtendedInfo
    {
        public IaasVmProtectedItemExtendedInfo() { }
        public bool? IsPolicyInconsistent { get { throw null; } set { } }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IaasVmProtectedItemHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IaasVmProtectedItemHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus ActionSuggested { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IaasVmProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public IaasVmProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails InstantRPDetails { get { throw null; } set { } }
        public int? InstantRPRetentionRangeInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy> TieringPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class IaasVmRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint
    {
        public IaasVmRecoveryPoint() { }
        public bool? IsInstantIlrSessionActive { get { throw null; } set { } }
        public bool? IsManagedVirtualMachine { get { throw null; } set { } }
        public bool? IsPrivateAccessEnabledOnAnyDisk { get { throw null; } set { } }
        public bool? IsSourceVmEncrypted { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails KeyAndSecret { get { throw null; } set { } }
        public bool? OriginalStorageAccountOption { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string RecoveryPointAdditionalInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration RecoveryPointDiskConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string SecurityType { get { throw null; } set { } }
        public string SourceVmStorageType { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class IaasVmRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent
    {
        public IaasVmRestoreContent() { }
        public string AffinityGroup { get { throw null; } set { } }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public bool? DoesCreateNewCloudService { get { throw null; } set { } }
        public bool? DoesRestoreWithManagedDisks { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails EncryptionDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails IdentityBasedRestoreDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo IdentityInfo { get { throw null; } set { } }
        public bool? OriginalStorageAccountOption { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RestoreDiskLunList { get { throw null; } }
        public string SecuredVmOSDiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetDiskNetworkAccessSettings TargetDiskNetworkAccessSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetDomainNameId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetVirtualMachineId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class IaasVmRestoreWithRehydrationContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent
    {
        public IaasVmRestoreWithRehydrationContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class IdentityBasedRestoreDetails
    {
        public IdentityBasedRestoreDetails() { }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetStorageAccountId { get { throw null; } set { } }
    }
    public abstract partial class IlrContent
    {
        protected IlrContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryptionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InquiryStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InquiryStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InquiryValidation
    {
        public InquiryValidation() { }
        public string AdditionalDetail { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class InstantRPAdditionalDetails
    {
        public InstantRPAdditionalDetails() { }
        public string AzureBackupRGNamePrefix { get { throw null; } set { } }
        public string AzureBackupRGNameSuffix { get { throw null; } set { } }
    }
    public enum JobSupportedAction
    {
        Invalid = 0,
        Cancellable = 1,
        Retriable = 2,
    }
    public partial class KekDetails
    {
        public KekDetails() { }
        public string KeyBackupData { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
    }
    public partial class KeyAndSecretDetails
    {
        public KeyAndSecretDetails() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails BekDetails { get { throw null; } set { } }
        public string EncryptionMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails KekDetails { get { throw null; } set { } }
    }
    public partial class KpiResourceHealthDetails
    {
        public KpiResourceHealthDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails> ResourceHealthDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus? ResourceHealthStatus { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastBackupStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastBackupStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastUpdateStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus FirstInitialization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Initialized { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus PartiallyFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy
    {
        public LogSchedulePolicy() { }
        public int? ScheduleFrequencyInMins { get { throw null; } set { } }
    }
    public partial class LongTermRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy
    {
        public LongTermRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule DailySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule MonthlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule WeeklySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule YearlySchedule { get { throw null; } set { } }
    }
    public partial class LongTermSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy
    {
        public LongTermSchedulePolicy() { }
    }
    public partial class MabBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public MabBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string MabServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType? MabServerType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkloadType { get { throw null; } set { } }
    }
    public partial class MabBackupJobExtendedInfo
    {
        public MabBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class MabBackupJobTaskDetails
    {
        public MabBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MabContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public MabContainer() { }
        public string AgentVersion { get { throw null; } set { } }
        public bool? CanReRegister { get { throw null; } set { } }
        public string ContainerHealthState { get { throw null; } set { } }
        public long? ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails> MabContainerHealthDetails { get { throw null; } }
        public long? ProtectedItemCount { get { throw null; } set { } }
    }
    public partial class MabContainerExtendedInfo
    {
        public MabContainerExtendedInfo() { }
        public System.Collections.Generic.IList<string> BackupItems { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType? BackupItemType { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
    }
    public partial class MabContainerHealthDetails
    {
        public MabContainerHealthDetails() { }
        public int? Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        public string Title { get { throw null; } set { } }
    }
    public partial class MabErrorInfo
    {
        public MabErrorInfo() { }
        public string ErrorString { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    public partial class MabFileFolderProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public MabFileFolderProtectedItem() { }
        public string ComputerName { get { throw null; } set { } }
        public long? DeferredDeleteSyncTimeInUTC { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public string ProtectionState { get { throw null; } set { } }
    }
    public partial class MabFileFolderProtectedItemExtendedInfo
    {
        public MabFileFolderProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class MabProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public MabProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MabServerType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MabServerType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType AzureBackupServerContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType AzureSqlContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Cluster { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType DpmContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType GenericContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType IaasVmContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType IaasVmServiceContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType MabContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType SqlAvailabilityGroupWorkLoadContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType StorageContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType VCenter { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType VmAppContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType left, Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType left, Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonthlyRetentionSchedule
    {
        public MonthlyRetentionSchedule() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
    public partial class MoveRPAcrossTiersContent
    {
        public MoveRPAcrossTiersContent() { }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? SourceTierType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? TargetTierType { get { throw null; } set { } }
    }
    public partial class PointInTimeRange
    {
        public PointInTimeRange() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class PreBackupValidation
    {
        public PreBackupValidation() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus? Status { get { throw null; } set { } }
    }
    public partial class PrepareDataMoveContent
    {
        public PrepareDataMoveContent(Azure.Core.ResourceIdentifier targetResourceId, Azure.Core.AzureLocation targetRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel) { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? IgnoreMoved { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SourceContainerArmIds { get { throw null; } }
        public Azure.Core.AzureLocation TargetRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
    }
    public partial class PreValidateEnableBackupContent
    {
        public PreValidateEnableBackupContent() { }
        public string Properties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? ResourceType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
    }
    public partial class PreValidateEnableBackupResult
    {
        internal PreValidateEnableBackupResult() { }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ProtectableContainer
    {
        protected ProtectableContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
    }
    public partial class ProtectableContainerResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProtectableContainerResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectedItemState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectedItemState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState BackupsSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionPaused { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionStopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionIlrConnectionContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProvisionIlrConnectionContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode FileRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode WorkloadRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPointDiskConfiguration
    {
        public RecoveryPointDiskConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation> ExcludedDiskList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation> IncludedDiskList { get { throw null; } }
        public int? NumberOfDisksAttachedToVm { get { throw null; } set { } }
        public int? NumberOfDisksIncludedInBackup { get { throw null; } set { } }
    }
    public partial class RecoveryPointMoveReadinessInfo
    {
        public RecoveryPointMoveReadinessInfo() { }
        public string AdditionalInfo { get { throw null; } set { } }
        public bool? IsReadyForMove { get { throw null; } set { } }
    }
    public partial class RecoveryPointProperties
    {
        public RecoveryPointProperties() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsSoftDeleted { get { throw null; } set { } }
        public string RuleName { get { throw null; } set { } }
    }
    public partial class RecoveryPointRehydrationInfo
    {
        public RecoveryPointRehydrationInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan? RehydrationRetentionDuration { get { throw null; } set { } }
    }
    public partial class RecoveryPointsRecommendedForMoveContent
    {
        public RecoveryPointsRecommendedForMoveContent() { }
        public System.Collections.Generic.IList<string> ExcludedRPList { get { throw null; } }
        public string ObjectType { get { throw null; } set { } }
    }
    public partial class RecoveryPointTierInformation
    {
        public RecoveryPointTierInformation() { }
        public System.Collections.Generic.IDictionary<string, string> ExtendedInfo { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? TierType { get { throw null; } set { } }
    }
    public partial class RecoveryPointTierInformationV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation
    {
        public RecoveryPointTierInformationV2() { }
    }
    public enum RecoveryPointTierStatus
    {
        Invalid = 0,
        Valid = 1,
        Disabled = 2,
        Deleted = 3,
        Rehydrated = 4,
    }
    public enum RecoveryPointTierType
    {
        Invalid = 0,
        InstantRP = 1,
        HardenedRP = 2,
        ArchivedRP = 3,
    }
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState
    {
        public RecoveryServicesBackupPrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class RecoveryServiceVaultProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent
    {
        public RecoveryServiceVaultProtectionIntent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationPriority : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationPriority(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority High { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority left, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority left, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuardOperationDetail
    {
        public ResourceGuardOperationDetail() { }
        public Azure.Core.ResourceIdentifier DefaultResourceId { get { throw null; } set { } }
        public string VaultCriticalOperation { get { throw null; } set { } }
    }
    public partial class ResourceGuardProxyProperties
    {
        public ResourceGuardProxyProperties() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGuardResourceId { get { throw null; } set { } }
    }
    public partial class ResourceHealthDetails
    {
        public ResourceHealthDetails() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        public string Title { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus PersistentDegraded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus PersistentUnhealthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus TransientDegraded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus TransientUnhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent
    {
        public ResourceProtectionIntent() { }
        public string FriendlyName { get { throw null; } set { } }
    }
    public abstract partial class RestoreContent
    {
        protected RestoreContent() { }
    }
    public partial class RestoreFileSpecs
    {
        public RestoreFileSpecs() { }
        public string FileSpecType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string TargetFolderPath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreOverwriteOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreOverwriteOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionDuration
    {
        public RetentionDuration() { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType? DurationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionDurationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionDurationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Days { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Months { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Weeks { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Years { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionScheduleFormat : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionScheduleFormat(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Daily { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleRunType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleRunType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Daily { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Hourly { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType left, Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType left, Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPinContent
    {
        public SecurityPinContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
    }
    public partial class SimpleRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy
    {
        public SimpleRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
    }
    public partial class SimpleSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy
    {
        public SimpleSchedulePolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> ScheduleRunDays { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public int? ScheduleWeeklyFrequency { get { throw null; } set { } }
    }
    public partial class SimpleSchedulePolicyV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy
    {
        public SimpleSchedulePolicyV2() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule WeeklySchedule { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftDeleteFeatureState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftDeleteFeatureState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState left, Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState left, Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAvailabilityGroupWorkloadProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer
    {
        public SqlAvailabilityGroupWorkloadProtectionContainer() { }
    }
    public partial class SqlContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public SqlContainer() { }
    }
    public partial class SqlDataDirectory
    {
        public SqlDataDirectory() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType? DirectoryType { get { throw null; } set { } }
        public string LogicalName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class SqlDataDirectoryMapping
    {
        public SqlDataDirectoryMapping() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType? MappingType { get { throw null; } set { } }
        public string SourceLogicalName { get { throw null; } set { } }
        public string SourcePath { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlDataDirectoryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlDataDirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Data { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public SqlProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string ProtectedItemDataId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? ProtectionState { get { throw null; } set { } }
    }
    public partial class SqlProtectedItemExtendedInfo
    {
        public SqlProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class SqlProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public SqlProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
    }
    public partial class StorageBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public StorageBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
    }
    public partial class StorageBackupJobExtendedInfo
    {
        public StorageBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class StorageBackupJobTaskDetails
    {
        public StorageBackupJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class StorageContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public StorageContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock? AcquireStorageAccountLock { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
    }
    public partial class StorageErrorInfo
    {
        public StorageErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class StorageProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer
    {
        public StorageProtectableContainer() { }
    }
    public partial class SubProtectionPolicy
    {
        public SubProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy> TieringPolicy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubProtectionPolicyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubProtectionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType CopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetAfsRestoreInfo
    {
        public TargetAfsRestoreInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
    }
    public enum TargetDiskNetworkAccessOption
    {
        SameAsOnSourceDisks = 0,
        EnablePrivateAccessForAllDisks = 1,
        EnablePublicAccessForAllDisks = 2,
    }
    public partial class TargetDiskNetworkAccessSettings
    {
        public TargetDiskNetworkAccessSettings() { }
        public string TargetDiskAccessId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetDiskNetworkAccessOption? TargetDiskNetworkAccessOption { get { throw null; } set { } }
    }
    public partial class TargetRestoreInfo
    {
        public TargetRestoreInfo() { }
        public string ContainerId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption? OverwriteOption { get { throw null; } set { } }
        public string TargetDirectoryForFileRestore { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TieringMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TieringMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode DoNotTier { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode TierAfter { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode TierRecommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenInformation
    {
        internal TokenInformation() { }
        public long? ExpiryTimeInUtcTicks { get { throw null; } }
        public string SecurityPin { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class TriggerBackupContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TriggerBackupContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent Properties { get { throw null; } set { } }
    }
    public partial class TriggerDataMoveContent
    {
        public TriggerDataMoveContent(Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.AzureLocation sourceRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? DoesPauseGC { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SourceContainerArmIds { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
    }
    public partial class TriggerRestoreContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TriggerRestoreContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent Properties { get { throw null; } set { } }
    }
    public partial class UnlockDeleteContent
    {
        public UnlockDeleteContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public string ResourceToBeDeleted { get { throw null; } set { } }
    }
    public partial class UnlockDeleteResult
    {
        internal UnlockDeleteResult() { }
        public System.DateTimeOffset? UnlockDeleteExpireOn { get { throw null; } }
    }
    public partial class VaultBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public VaultBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo> ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedInfoPropertyBag { get { throw null; } }
    }
    public partial class VaultBackupJobErrorInfo
    {
        public VaultBackupJobErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultDedupState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultDedupState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultXcoolState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultXcoolState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmAppContainerProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer
    {
        public VmAppContainerProtectableContainer() { }
    }
    public partial class VmAppContainerProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer
    {
        public VmAppContainerProtectionContainer() { }
    }
    public partial class VmEncryptionDetails
    {
        public VmEncryptionDetails() { }
        public bool? IsEncryptionEnabled { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KekVaultId { get { throw null; } set { } }
        public System.Uri SecretKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretKeyVaultId { get { throw null; } set { } }
    }
    public partial class VmResourceFeatureSupportContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent
    {
        public VmResourceFeatureSupportContent() { }
        public string VmSize { get { throw null; } set { } }
        public string VmSku { get { throw null; } set { } }
    }
    public partial class VmResourceFeatureSupportResult
    {
        internal VmResourceFeatureSupportResult() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus? SupportStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmResourceFeatureSupportStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmResourceFeatureSupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus DefaultOff { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus DefaultOn { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus Supported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem
    {
        public VmWorkloadItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? SubInquiredItemCount { get { throw null; } set { } }
        public int? SubWorkloadItemCount { get { throw null; } set { } }
    }
    public partial class VmWorkloadProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem
    {
        public VmWorkloadProtectableItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public bool? IsAutoProtected { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ParentUniqueName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation PreBackupValidation { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? SubInquiredItemCount { get { throw null; } set { } }
        public int? SubProtectableItemCount { get { throw null; } set { } }
    }
    public partial class VmWorkloadProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem
    {
        public VmWorkloadProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail LastBackupErrorDetail { get { throw null; } set { } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? LastBackupStatus { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ParentType { get { throw null; } set { } }
        public string ProtectedItemDataSourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? ProtectedItemHealthStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class VmWorkloadProtectedItemExtendedInfo
    {
        public VmWorkloadProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public string RecoveryModel { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmWorkloadProtectedItemHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmWorkloadProtectedItemHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus NotReachable { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmWorkloadProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy
    {
        public VmWorkloadProtectionPolicy() { }
        public bool? DoesMakePolicyConsistent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings Settings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkLoadType { get { throw null; } set { } }
    }
    public partial class VmWorkloadSapAseDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem
    {
        public VmWorkloadSapAseDatabaseProtectedItem() { }
    }
    public partial class VmWorkloadSapAseDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSapAseDatabaseWorkloadItem() { }
    }
    public partial class VmWorkloadSapAseSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapAseSystemProtectableItem() { }
    }
    public partial class VmWorkloadSapAseSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSapAseSystemWorkloadItem() { }
    }
    public partial class VmWorkloadSapHanaDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapHanaDatabaseProtectableItem() { }
    }
    public partial class VmWorkloadSapHanaDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem
    {
        public VmWorkloadSapHanaDatabaseProtectedItem() { }
    }
    public partial class VmWorkloadSapHanaDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSapHanaDatabaseWorkloadItem() { }
    }
    public partial class VmWorkloadSapHanaDBInstance : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapHanaDBInstance() { }
    }
    public partial class VmWorkloadSapHanaDBInstanceProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem
    {
        public VmWorkloadSapHanaDBInstanceProtectedItem() { }
    }
    public partial class VmWorkloadSapHanaHsr : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapHanaHsr() { }
    }
    public partial class VmWorkloadSapHanaSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapHanaSystemProtectableItem() { }
    }
    public partial class VmWorkloadSapHanaSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSapHanaSystemWorkloadItem() { }
    }
    public partial class VmWorkloadSqlAvailabilityGroupProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSqlAvailabilityGroupProtectableItem() { }
    }
    public partial class VmWorkloadSqlDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSqlDatabaseProtectableItem() { }
    }
    public partial class VmWorkloadSqlDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem
    {
        public VmWorkloadSqlDatabaseProtectedItem() { }
    }
    public partial class VmWorkloadSqlDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSqlDatabaseWorkloadItem() { }
    }
    public partial class VmWorkloadSqlInstanceProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSqlInstanceProtectableItem() { }
    }
    public partial class VmWorkloadSqlInstanceWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem
    {
        public VmWorkloadSqlInstanceWorkloadItem() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory> DataDirectoryPaths { get { throw null; } }
    }
    public partial class WeeklyRetentionFormat
    {
        public WeeklyRetentionFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeekOfMonth> WeeksOfTheMonth { get { throw null; } }
    }
    public partial class WeeklyRetentionSchedule
    {
        public WeeklyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
    public partial class WorkloadAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent
    {
        public WorkloadAutoProtectionIntent() { }
    }
    public partial class WorkloadBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent
    {
        public WorkloadBackupContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType? BackupType { get { throw null; } set { } }
        public bool? EnableCompression { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
    }
    public partial class WorkloadBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob
    {
        public WorkloadBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class WorkloadBackupJobExtendedInfo
    {
        public WorkloadBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class WorkloadBackupJobTaskDetails
    {
        public WorkloadBackupJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class WorkloadContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer
    {
        public WorkloadContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType? OperationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkloadType { get { throw null; } set { } }
    }
    public partial class WorkloadContainerAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent
    {
        public WorkloadContainerAutoProtectionIntent() { }
    }
    public partial class WorkloadContainerExtendedInfo
    {
        public WorkloadContainerExtendedInfo() { }
        public string HostServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo InquiryInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> NodesList { get { throw null; } }
    }
    public partial class WorkloadContainerInquiryInfo
    {
        public WorkloadContainerInquiryInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails> InquiryDetails { get { throw null; } }
        public string Status { get { throw null; } set { } }
    }
    public partial class WorkloadErrorInfo
    {
        public WorkloadErrorInfo() { }
        public string AdditionalDetails { get { throw null; } set { } }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public string ErrorTitle { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class WorkloadInquiryDetails
    {
        public WorkloadInquiryDetails() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation InquiryValidation { get { throw null; } set { } }
        public long? ItemCount { get { throw null; } set { } }
        public string WorkloadInquiryDetailsType { get { throw null; } set { } }
    }
    public abstract partial class WorkloadItem
    {
        protected WorkloadItem() { }
        public string BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class WorkloadItemResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkloadItemResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadItemType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadItemType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapAseSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SqlInstance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadOperationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadOperationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Register { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Reregister { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint
    {
        public WorkloadPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class WorkloadPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent
    {
        public WorkloadPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public abstract partial class WorkloadProtectableItem
    {
        protected WorkloadProtectableItem() { }
        public string BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class WorkloadProtectableItemResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkloadProtectableItemResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem Properties { get { throw null; } set { } }
    }
    public partial class WorkloadRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint
    {
        public WorkloadRecoveryPoint() { }
        public System.DateTimeOffset? RecoveryPointCreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType? RestorePointType { get { throw null; } set { } }
    }
    public partial class WorkloadRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent
    {
        public WorkloadRestoreContent() { }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode? RecoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo TargetInfo { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetVirtualMachineId { get { throw null; } set { } }
    }
    public partial class WorkloadSapHanaPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint
    {
        public WorkloadSapHanaPointInTimeRecoveryPoint() { }
    }
    public partial class WorkloadSapHanaPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent
    {
        public WorkloadSapHanaPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public partial class WorkloadSapHanaPointInTimeRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent
    {
        public WorkloadSapHanaPointInTimeRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class WorkloadSapHanaRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint
    {
        public WorkloadSapHanaRecoveryPoint() { }
    }
    public partial class WorkloadSapHanaRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent
    {
        public WorkloadSapHanaRestoreContent() { }
    }
    public partial class WorkloadSapHanaRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent
    {
        public WorkloadSapHanaRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class WorkloadSqlAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent
    {
        public WorkloadSqlAutoProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType? WorkloadItemType { get { throw null; } set { } }
    }
    public partial class WorkloadSqlPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint
    {
        public WorkloadSqlPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class WorkloadSqlPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent
    {
        public WorkloadSqlPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public partial class WorkloadSqlPointInTimeRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent
    {
        public WorkloadSqlPointInTimeRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class WorkloadSqlRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint
    {
        public WorkloadSqlRecoveryPoint() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo ExtendedInfo { get { throw null; } set { } }
    }
    public partial class WorkloadSqlRecoveryPointExtendedInfo
    {
        public WorkloadSqlRecoveryPointExtendedInfo() { }
        public System.DateTimeOffset? DataDirectoryInfoCapturedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory> DataDirectoryPaths { get { throw null; } }
    }
    public partial class WorkloadSqlRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent
    {
        public WorkloadSqlRestoreContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping> AlternateDirectoryPaths { get { throw null; } }
        public bool? IsNonRecoverable { get { throw null; } set { } }
        public bool? ShouldUseAlternateTargetLocation { get { throw null; } set { } }
    }
    public partial class WorkloadSqlRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent
    {
        public WorkloadSqlRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class YearlyRetentionSchedule
    {
        public YearlyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupMonthOfYear> MonthsOfYear { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
}
