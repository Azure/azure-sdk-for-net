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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response GetJobOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetOperationStatusPrivateEndpoint(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetOperationStatusPrivateEndpointAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation BMSPrepareDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BMSPrepareDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BMSTriggerDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BMSTriggerDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultStorageConfigOperationResultResponse> GetBMSPrepareDataMoveOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultStorageConfigOperationResultResponse>> GetBMSPrepareDataMoveOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProtectedItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectedItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> Get(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> GetAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetProtectedItemOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetProtectedItemOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> GetRecoveryPointResource(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>> GetRecoveryPointResourceAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResourceCollection GetRecoveryPointResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> GetRecoveryPointsRecommendedForMoves(Azure.ResourceManager.RecoveryServicesBackup.Models.ListRecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> GetRecoveryPointsRecommendedForMovesAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.ListRecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TriggerBackup(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequestResource backupRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerBackupAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequestResource backupRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectedItemResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected ProtectedItemResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> Get(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> GetAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectedItemResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProtectedItemResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem Properties { get { throw null; } set { } }
    }
    public partial class ProtectionContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionContainerResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItems(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItemsAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> GetProtectedItemResource(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource>> GetProtectedItemResourceAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResourceCollection GetProtectedItemResources() { throw null; }
        public virtual Azure.Response Inquire(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> InquireAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected ProtectionContainerResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> Get(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> GetAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionContainerResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProtectionContainerResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer Properties { get { throw null; } set { } }
    }
    public partial class ProtectionIntentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionIntentResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string intentObjectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionIntentResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected ProtectionIntentResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> Get(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> GetAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionIntentResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProtectionIntentResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionIntent Properties { get { throw null; } set { } }
    }
    public partial class ProtectionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectionPolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetProtectionPolicyOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetProtectionPolicyOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectionPolicyResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>, System.Collections.IEnumerable
    {
        protected ProtectionPolicyResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectionPolicyResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProtectionPolicyResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy Properties { get { throw null; } set { } }
    }
    public partial class RecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MoveRecoveryPoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveRecoveryPointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ProvisionItemLevelRecoveryConnection(Azure.ResourceManager.RecoveryServicesBackup.Models.ILRRequestResource ilrRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ProvisionItemLevelRecoveryConnectionAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.ILRRequestResource ilrRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeItemLevelRecoveryConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeItemLevelRecoveryConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestResource restoreRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestResource restoreRequestResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryPointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>, System.Collections.IEnumerable
    {
        protected RecoveryPointResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryPointResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RecoveryPointResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPoint Properties { get { throw null; } set { } }
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
        public static Azure.Response GetBackupOperationResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetBackupOperationResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetBackupOperationStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetBackupOperationStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> GetBackupPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetBackupPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource GetBackupPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionCollection GetBackupPrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResponse> GetBackupStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResponse>> GetBackupStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummaries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummariesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationResultInfoBaseResource> GetExportJobsOperationResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationResultInfoBaseResource>> GetExportJobsOperationResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource GetProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> GetProtectedItemResourcesByBackupProtectedItem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectedItemResource> GetProtectedItemResourcesByBackupProtectedItemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetProtectionContainerRefreshOperationResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetProtectionContainerRefreshOperationResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource GetProtectionContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> GetProtectionContainerResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource>> GetProtectionContainerResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResourceCollection GetProtectionContainerResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> GetProtectionContainerResourcesByBackupProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> GetProtectionContainerResourcesByBackupProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource GetProtectionIntentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> GetProtectionIntentResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource>> GetProtectionIntentResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResourceCollection GetProtectionIntentResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> GetProtectionIntentResourcesByBackupProtectionIntent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionIntentResource> GetProtectionIntentResourcesByBackupProtectionIntentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource GetProtectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource> GetProtectionPolicyResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResource>> GetProtectionPolicyResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ProtectionPolicyResourceCollection GetProtectionPolicyResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.RecoveryPointResource GetRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource GetResourceGuardProxyBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> GetResourceGuardProxyBaseResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> GetResourceGuardProxyBaseResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceCollection GetResourceGuardProxyBaseResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPIN(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinBase securityPinBase = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPINAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinBase securityPinBase = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> GetSoftDeletedProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ProtectionContainerResource> GetSoftDeletedProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationsResponse> GetValidateOperationResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationsResponse>> GetValidateOperationResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus> GetValidateOperationStatus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatus>> GetValidateOperationStatusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response RefreshProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RefreshProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation TriggerValidateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationRequest validateOperationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerValidateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationRequest validateOperationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmResourceFeatureSupportResponse> ValidateFeatureSupport(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmResourceFeatureSupportResponse>> ValidateFeatureSupportAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationsResponse> ValidateOperation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationRequest validateOperationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationsResponse>> ValidateOperationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationRequest validateOperationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResponse> ValidateProtectionIntent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResponse>> ValidateProtectionIntentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardProxyBaseResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string resourceGuardProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResponse> UnlockDelete(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResponse>> UnlockDeleteAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardProxyBaseResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> Get(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>> GetAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGuardProxyBaseResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyBase Properties { get { throw null; } set { } }
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
    public partial class AzureBackupGoalFeatureSupportRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent
    {
        public AzureBackupGoalFeatureSupportRequest() { }
    }
    public partial class AzureBackupServerContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer
    {
        public AzureBackupServerContainer() { }
    }
    public partial class AzureBackupServerEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineProperties
    {
        public AzureBackupServerEngine() { }
    }
    public partial class AzureFileShareBackupRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequest
    {
        public AzureFileShareBackupRequest() { }
        public System.DateTimeOffset? RecoveryPointExpiryTimeInUTC { get { throw null; } set { } }
    }
    public partial class AzureFileShareProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem
    {
        public AzureFileShareProtectableItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType? AzureFileShareType { get { throw null; } set { } }
        public string ParentContainerFabricId { get { throw null; } set { } }
        public string ParentContainerFriendlyName { get { throw null; } set { } }
    }
    public partial class AzureFileshareProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
    {
        public AzureFileshareProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileshareProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KPIResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
    }
    public partial class AzureFileshareProtectedItemExtendedInfo
    {
        public AzureFileshareProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string ResourceState { get { throw null; } }
        public System.DateTimeOffset? ResourceStateSyncOn { get { throw null; } }
    }
    public partial class AzureFileShareProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public AzureFileShareProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType? WorkLoadType { get { throw null; } set { } }
    }
    public partial class AzureFileShareProvisionILRRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.ILRRequest
    {
        public AzureFileShareProvisionILRRequest() { }
        public string RecoveryPointId { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
    }
    public partial class AzureFileShareRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPoint
    {
        public AzureFileShareRecoveryPoint() { }
        public System.Uri FileShareSnapshotUri { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public int? RecoveryPointSizeInGB { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
    }
    public partial class AzureFileShareRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequest
    {
        public AzureFileShareRestoreRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption? CopyOptions { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType? RecoveryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs> RestoreFileSpecs { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType? RestoreRequestType { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAFSRestoreInfo TargetDetails { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFileShareType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFileShareType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType Xsmb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType XSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.AzureFileShareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureIaaSClassicComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer
    {
        public AzureIaaSClassicComputeVmContainer() { }
    }
    public partial class AzureIaaSClassicComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem
    {
        public AzureIaaSClassicComputeVmProtectableItem() { }
    }
    public partial class AzureIaaSClassicComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmProtectedItem
    {
        public AzureIaaSClassicComputeVmProtectedItem() { }
    }
    public partial class AzureIaaSComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer
    {
        public AzureIaaSComputeVmContainer() { }
    }
    public partial class AzureIaaSComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem
    {
        public AzureIaaSComputeVmProtectableItem() { }
    }
    public partial class AzureIaaSComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmProtectedItem
    {
        public AzureIaaSComputeVmProtectedItem() { }
    }
    public partial class AzureIaasVmErrorInfo
    {
        public AzureIaasVmErrorInfo() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorString { get { throw null; } }
        public string ErrorTitle { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    public partial class AzureIaasVmHealthDetails : Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails
    {
        public AzureIaasVmHealthDetails() { }
    }
    public partial class AzureIaasVmJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public AzureIaasVmJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class AzureIaasVmJobExtendedInfo
    {
        public AzureIaasVmJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public string EstimatedRemainingDurationValue { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> InternalPropertyBag { get { throw null; } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class AzureIaasVmJobTaskDetails
    {
        public AzureIaasVmJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string InstanceId { get { throw null; } set { } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskExecutionDetails { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class AzureIaasVmJobV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public AzureIaasVmJobV2() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class AzureIaasVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
    {
        public AzureIaasVmProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ExtendedProperties ExtendedProperties { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureIaasVmHealthDetails> HealthDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KPIResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } }
        public string LastBackupStatus { get { throw null; } set { } }
        public string ProtectedItemDataId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } }
    }
    public partial class AzureIaasVmProtectedItemExtendedInfo
    {
        public AzureIaasVmProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public bool? PolicyInconsistent { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class AzureIaasVmProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public AzureIaasVmProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails InstantRPDetails { get { throw null; } set { } }
        public int? InstantRpRetentionRangeInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringPolicy> TieringPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class AzureRecoveryServiceVaultProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionIntent
    {
        public AzureRecoveryServiceVaultProtectionIntent() { }
    }
    public partial class AzureResourceProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionIntent
    {
        public AzureResourceProtectionIntent() { }
        public string FriendlyName { get { throw null; } set { } }
    }
    public partial class AzureSqlAGWorkloadContainerProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadContainer
    {
        public AzureSqlAGWorkloadContainerProtectionContainer() { }
    }
    public partial class AzureSqlContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
    {
        public AzureSqlContainer() { }
    }
    public partial class AzureSqlProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
    {
        public AzureSqlProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureSqlProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string ProtectedItemDataId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? ProtectionState { get { throw null; } set { } }
    }
    public partial class AzureSqlProtectedItemExtendedInfo
    {
        public AzureSqlProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class AzureSqlProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public AzureSqlProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
    }
    public partial class AzureStorageContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
    {
        public AzureStorageContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock? AcquireStorageAccountLock { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
    }
    public partial class AzureStorageErrorInfo
    {
        public AzureStorageErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class AzureStorageJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public AzureStorageJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureStorageErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureStorageJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
    }
    public partial class AzureStorageJobExtendedInfo
    {
        public AzureStorageJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureStorageJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class AzureStorageJobTaskDetails
    {
        public AzureStorageJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class AzureStorageProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer
    {
        public AzureStorageProtectableContainer() { }
    }
    public partial class AzureVmAppContainerProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer
    {
        public AzureVmAppContainerProtectableContainer() { }
    }
    public partial class AzureVmAppContainerProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadContainer
    {
        public AzureVmAppContainerProtectionContainer() { }
    }
    public partial class AzureVmResourceFeatureSupportRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent
    {
        public AzureVmResourceFeatureSupportRequest() { }
        public string VmSize { get { throw null; } set { } }
        public string VmSku { get { throw null; } set { } }
    }
    public partial class AzureVmResourceFeatureSupportResponse
    {
        internal AzureVmResourceFeatureSupportResponse() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus? SupportStatus { get { throw null; } }
    }
    public partial class AzureVmWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem
    {
        public AzureVmWorkloadItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? Subinquireditemcount { get { throw null; } set { } }
        public int? SubWorkloadItemCount { get { throw null; } set { } }
    }
    public partial class AzureVmWorkloadProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem
    {
        public AzureVmWorkloadProtectableItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public bool? IsAutoProtected { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ParentUniqueName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation Prebackupvalidation { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? Subinquireditemcount { get { throw null; } set { } }
        public int? Subprotectableitemcount { get { throw null; } set { } }
    }
    public partial class AzureVmWorkloadProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
    {
        public AzureVmWorkloadProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KPIResourceHealthDetails> KpisHealths { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail LastBackupErrorDetail { get { throw null; } set { } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? LastBackupStatus { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ParentType { get { throw null; } set { } }
        public string ProtectedItemDataSourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus? ProtectedItemHealthStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } }
        public string ServerName { get { throw null; } set { } }
    }
    public partial class AzureVmWorkloadProtectedItemExtendedInfo
    {
        public AzureVmWorkloadProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public string RecoveryModel { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class AzureVmWorkloadProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public AzureVmWorkloadProtectionPolicy() { }
        public bool? MakePolicyConsistent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.Settings Settings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType? WorkLoadType { get { throw null; } set { } }
    }
    public partial class AzureVmWorkloadSAPAseDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectedItem
    {
        public AzureVmWorkloadSAPAseDatabaseProtectedItem() { }
    }
    public partial class AzureVmWorkloadSAPAseDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSAPAseDatabaseWorkloadItem() { }
    }
    public partial class AzureVmWorkloadSAPAseSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSAPAseSystemProtectableItem() { }
    }
    public partial class AzureVmWorkloadSAPAseSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSAPAseSystemWorkloadItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSAPHanaDatabaseProtectableItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectedItem
    {
        public AzureVmWorkloadSAPHanaDatabaseProtectedItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSAPHanaDatabaseWorkloadItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaDBInstance : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSAPHanaDBInstance() { }
    }
    public partial class AzureVmWorkloadSAPHanaDBInstanceProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectedItem
    {
        public AzureVmWorkloadSAPHanaDBInstanceProtectedItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaHSR : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSAPHanaHSR() { }
    }
    public partial class AzureVmWorkloadSAPHanaSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSAPHanaSystemProtectableItem() { }
    }
    public partial class AzureVmWorkloadSAPHanaSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSAPHanaSystemWorkloadItem() { }
    }
    public partial class AzureVmWorkloadSQLAvailabilityGroupProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSQLAvailabilityGroupProtectableItem() { }
    }
    public partial class AzureVmWorkloadSQLDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSQLDatabaseProtectableItem() { }
    }
    public partial class AzureVmWorkloadSQLDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectedItem
    {
        public AzureVmWorkloadSQLDatabaseProtectedItem() { }
    }
    public partial class AzureVmWorkloadSQLDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSQLDatabaseWorkloadItem() { }
    }
    public partial class AzureVmWorkloadSQLInstanceProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadProtectableItem
    {
        public AzureVmWorkloadSQLInstanceProtectableItem() { }
    }
    public partial class AzureVmWorkloadSQLInstanceWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadItem
    {
        public AzureVmWorkloadSQLInstanceWorkloadItem() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectory> DataDirectoryPaths { get { throw null; } }
    }
    public partial class AzureWorkloadAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureRecoveryServiceVaultProtectionIntent
    {
        public AzureWorkloadAutoProtectionIntent() { }
    }
    public partial class AzureWorkloadBackupRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequest
    {
        public AzureWorkloadBackupRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType? BackupType { get { throw null; } set { } }
        public bool? EnableCompression { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointExpiryTimeInUTC { get { throw null; } set { } }
    }
    public partial class AzureWorkloadContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
    {
        public AzureWorkloadContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType? OperationType { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType? WorkloadType { get { throw null; } set { } }
    }
    public partial class AzureWorkloadContainerAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionIntent
    {
        public AzureWorkloadContainerAutoProtectionIntent() { }
    }
    public partial class AzureWorkloadContainerExtendedInfo
    {
        public AzureWorkloadContainerExtendedInfo() { }
        public string HostServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryInfo InquiryInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> NodesList { get { throw null; } }
    }
    public partial class AzureWorkloadErrorInfo
    {
        public AzureWorkloadErrorInfo() { }
        public string AdditionalDetails { get { throw null; } set { } }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public string ErrorTitle { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class AzureWorkloadJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public AzureWorkloadJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class AzureWorkloadJobExtendedInfo
    {
        public AzureWorkloadJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class AzureWorkloadJobTaskDetails
    {
        public AzureWorkloadJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class AzureWorkloadPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRecoveryPoint
    {
        public AzureWorkloadPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class AzureWorkloadPointInTimeRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRestoreRequest
    {
        public AzureWorkloadPointInTimeRestoreRequest() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public partial class AzureWorkloadRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPoint
    {
        public AzureWorkloadRecoveryPoint() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointTimeInUTC { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType? RestorePointType { get { throw null; } set { } }
    }
    public partial class AzureWorkloadRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequest
    {
        public AzureWorkloadRestoreRequest() { }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode? RecoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType? RecoveryType { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo TargetInfo { get { throw null; } set { } }
        public string TargetVirtualMachineId { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSAPHanaPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadPointInTimeRecoveryPoint
    {
        public AzureWorkloadSAPHanaPointInTimeRecoveryPoint() { }
    }
    public partial class AzureWorkloadSAPHanaPointInTimeRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSAPHanaRestoreRequest
    {
        public AzureWorkloadSAPHanaPointInTimeRestoreRequest() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSAPHanaPointInTimeRestoreWithRehydrateRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSAPHanaPointInTimeRestoreRequest
    {
        public AzureWorkloadSAPHanaPointInTimeRestoreWithRehydrateRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSAPHanaRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRecoveryPoint
    {
        public AzureWorkloadSAPHanaRecoveryPoint() { }
    }
    public partial class AzureWorkloadSAPHanaRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRestoreRequest
    {
        public AzureWorkloadSAPHanaRestoreRequest() { }
    }
    public partial class AzureWorkloadSAPHanaRestoreWithRehydrateRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSAPHanaRestoreRequest
    {
        public AzureWorkloadSAPHanaRestoreWithRehydrateRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadAutoProtectionIntent
    {
        public AzureWorkloadSQLAutoProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType? WorkloadItemType { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSQLRecoveryPoint
    {
        public AzureWorkloadSQLPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class AzureWorkloadSQLPointInTimeRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSQLRestoreRequest
    {
        public AzureWorkloadSQLPointInTimeRestoreRequest() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLPointInTimeRestoreWithRehydrateRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSQLPointInTimeRestoreRequest
    {
        public AzureWorkloadSQLPointInTimeRestoreWithRehydrateRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRecoveryPoint
    {
        public AzureWorkloadSQLRecoveryPoint() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSQLRecoveryPointExtendedInfo ExtendedInfo { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLRecoveryPointExtendedInfo
    {
        public AzureWorkloadSQLRecoveryPointExtendedInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectory> DataDirectoryPaths { get { throw null; } }
        public System.DateTimeOffset? DataDirectoryTimeInUTC { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadRestoreRequest
    {
        public AzureWorkloadSQLRestoreRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryMapping> AlternateDirectoryPaths { get { throw null; } }
        public bool? IsNonRecoverable { get { throw null; } set { } }
        public bool? ShouldUseAlternateTargetLocation { get { throw null; } set { } }
    }
    public partial class AzureWorkloadSQLRestoreWithRehydrateRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.AzureWorkloadSQLRestoreRequest
    {
        public AzureWorkloadSQLRestoreWithRehydrateRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
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
    public abstract partial class BackupEngineProperties
    {
        protected BackupEngineProperties() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupItemType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupItemType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureSqlDb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SAPAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SAPHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SAPHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SQLDataBase { get { throw null; } }
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
    public abstract partial class BackupJobProperties
    {
        protected BackupJobProperties() { }
        public string ActivityId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EntityFriendlyName { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.NameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit? Unit { get { throw null; } }
    }
    public partial class BackupPrivateEndpointConnectionProperties
    {
        public BackupPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public abstract partial class BackupRequest
    {
        protected BackupRequest() { }
    }
    public partial class BackupRequestResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupRequestResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequest Properties { get { throw null; } set { } }
    }
    public partial class BackupResourceConfigProperties
    {
        public BackupResourceConfigProperties() { }
        public bool? CrossRegionRestoreFlag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState? DedupState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState? StorageTypeState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState? XcoolState { get { throw null; } set { } }
    }
    public partial class BackupResourceEncryptionConfig
    {
        public BackupResourceEncryptionConfig() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType? EncryptionAtRestType { get { throw null; } set { } }
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
        public string UserAssignedIdentity { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    public partial class BackupResourceVaultConfigProperties
    {
        public BackupResourceVaultConfigProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState? EnhancedSecurityState { get { throw null; } set { } }
        public bool? IsSoftDeleteFeatureStateEditable { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState? SoftDeleteFeatureState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState? StorageTypeState { get { throw null; } set { } }
    }
    public partial class BackupStatusContent
    {
        public BackupStatusContent() { }
        public string PoLogicalName { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class BackupStatusResponse
    {
        internal BackupStatusResponse() { }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName? FabricName { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus? ProtectionStatus { get { throw null; } }
        public string RegistrationStatus { get { throw null; } }
        public string VaultId { get { throw null; } }
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
    public partial class BEKDetails
    {
        public BEKDetails() { }
        public string SecretData { get { throw null; } set { } }
        public System.Uri SecretUri { get { throw null; } set { } }
        public string SecretVaultId { get { throw null; } set { } }
    }
    public partial class ClientScriptForConnect
    {
        internal ClientScriptForConnect() { }
        public string OSType { get { throw null; } }
        public string ScriptContent { get { throw null; } }
        public string ScriptExtension { get { throw null; } }
        public string ScriptNameSuffix { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class ContainerIdentityInfo
    {
        public ContainerIdentityInfo() { }
        public string AadTenantId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string ServicePrincipalClientId { get { throw null; } set { } }
        public string UniqueName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption CreateCopy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption Overwrite { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption Skip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.CopyOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode Recover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSourceType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType AzureSqlDb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SAPAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SAPHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SAPHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SQLDataBase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Day
    {
        public Day() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
    }
    public enum DayOfWeek
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
    public readonly partial struct DedupState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DedupState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.DedupState right) { throw null; }
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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail ErrorDetail { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class DpmBackupEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineProperties
    {
        public DpmBackupEngine() { }
    }
    public partial class DpmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
    {
        public DpmContainer() { }
        public bool? CanReRegister { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public string DpmAgentVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DpmServers { get { throw null; } }
        public System.DateTimeOffset? ExtendedInfoLastRefreshedOn { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        public bool? UpgradeAvailable { get { throw null; } set { } }
    }
    public partial class DpmErrorInfo
    {
        public DpmErrorInfo() { }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public partial class DpmJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public DpmJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public string ContainerType { get { throw null; } set { } }
        public string DpmServerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DpmJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class DpmJobExtendedInfo
    {
        public DpmJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class DpmJobTaskDetails
    {
        public DpmJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class DpmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
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
        public string LastBackupStatus { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseLatestRecoveryPoint { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseOldestRecoveryPoint { get { throw null; } set { } }
        public int? OnPremiseRecoveryPointCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ProtectableObjectLoadPath { get { throw null; } }
        public bool? Protected { get { throw null; } set { } }
        public string ProtectionGroupName { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string TotalDiskStorageSizeInBytes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAtRestType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAtRestType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionAtRestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionDetails
    {
        public EncryptionDetails() { }
        public bool? EncryptionEnabled { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public string KekVaultId { get { throw null; } set { } }
        public System.Uri SecretKeyUri { get { throw null; } set { } }
        public string SecretKeyVaultId { get { throw null; } set { } }
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
    public partial class ErrorDetail
    {
        public ErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    public partial class ExportJobsOperationResultInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationResultInfoBase
    {
        internal ExportJobsOperationResultInfo() { }
        public string BlobSasKey { get { throw null; } }
        public System.Uri BlobUri { get { throw null; } }
        public string ExcelFileBlobSasKey { get { throw null; } }
        public System.Uri ExcelFileBlobUri { get { throw null; } }
    }
    public partial class ExtendedProperties
    {
        public ExtendedProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties DiskExclusionProperties { get { throw null; } set { } }
        public string LinuxVmApplicationName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricName : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricName(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName Azure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.FabricName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class FeatureSupportContent
    {
        protected FeatureSupportContent() { }
    }
    public partial class GenericContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
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
    public partial class GenericProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
    {
        public GenericProtectedItem() { }
        public string FabricName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public long? ProtectedItemId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState? ProtectionState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceAssociations { get { throw null; } }
    }
    public partial class GenericProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public GenericProtectionPolicy() { }
        public string FabricName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class GenericRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPoint
    {
        public GenericRecoveryPoint() { }
        public string FriendlyName { get { throw null; } set { } }
        public string RecoveryPointAdditionalInfo { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus ActionSuggested { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.HealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HourlySchedule
    {
        public HourlySchedule() { }
        public int? Interval { get { throw null; } set { } }
        public int? ScheduleWindowDuration { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduleWindowStartOn { get { throw null; } set { } }
    }
    public enum HttpStatusCode
    {
        Continue = 0,
        SwitchingProtocols = 1,
        OK = 2,
        Created = 3,
        Accepted = 4,
        NonAuthoritativeInformation = 5,
        NoContent = 6,
        ResetContent = 7,
        PartialContent = 8,
        MultipleChoices = 9,
        Ambiguous = 10,
        MovedPermanently = 11,
        Moved = 12,
        Found = 13,
        Redirect = 14,
        SeeOther = 15,
        RedirectMethod = 16,
        NotModified = 17,
        UseProxy = 18,
        Unused = 19,
        TemporaryRedirect = 20,
        RedirectKeepVerb = 21,
        BadRequest = 22,
        Unauthorized = 23,
        PaymentRequired = 24,
        Forbidden = 25,
        NotFound = 26,
        MethodNotAllowed = 27,
        NotAcceptable = 28,
        ProxyAuthenticationRequired = 29,
        RequestTimeout = 30,
        Conflict = 31,
        Gone = 32,
        LengthRequired = 33,
        PreconditionFailed = 34,
        RequestEntityTooLarge = 35,
        RequestUriTooLong = 36,
        UnsupportedMediaType = 37,
        RequestedRangeNotSatisfiable = 38,
        ExpectationFailed = 39,
        UpgradeRequired = 40,
        InternalServerError = 41,
        NotImplemented = 42,
        BadGateway = 43,
        ServiceUnavailable = 44,
        GatewayTimeout = 45,
        HttpVersionNotSupported = 46,
    }
    public partial class IaasVmBackupRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRequest
    {
        public IaasVmBackupRequest() { }
        public System.DateTimeOffset? RecoveryPointExpiryTimeInUTC { get { throw null; } set { } }
    }
    public partial class IaasVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
    {
        public IaasVmContainer() { }
        public string ResourceGroup { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmilrRegistrationRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.ILRRequest
    {
        public IaasVmilrRegistrationRequest() { }
        public string InitiatorName { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public bool? RenewExistingRegistration { get { throw null; } set { } }
        public string VirtualMachineId { get { throw null; } set { } }
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
        public string VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
    }
    public partial class IaasVmRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPoint
    {
        public IaasVmRecoveryPoint() { }
        public bool? IsInstantIlrSessionActive { get { throw null; } set { } }
        public bool? IsManagedVirtualMachine { get { throw null; } set { } }
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
        public string SourceVmStorageType { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class IaasVmRestoreRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequest
    {
        public IaasVmRestoreRequest() { }
        public string AffinityGroup { get { throw null; } set { } }
        public bool? CreateNewCloudService { get { throw null; } set { } }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.EncryptionDetails EncryptionDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails IdentityBasedRestoreDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityInfo IdentityInfo { get { throw null; } set { } }
        public bool? OriginalStorageAccountOption { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType? RecoveryType { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RestoreDiskLunList { get { throw null; } }
        public bool? RestoreWithManagedDisks { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string TargetDomainNameId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVirtualMachineId { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class IaasVmRestoreWithRehydrationRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreRequest
    {
        public IaasVmRestoreWithRehydrationRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
    }
    public partial class IdentityBasedRestoreDetails
    {
        public IdentityBasedRestoreDetails() { }
        public string ObjectType { get { throw null; } set { } }
        public string TargetStorageAccountId { get { throw null; } set { } }
    }
    public partial class IdentityInfo
    {
        public IdentityInfo() { }
        public bool? IsSystemAssignedIdentity { get { throw null; } set { } }
        public string ManagedIdentityResourceId { get { throw null; } set { } }
    }
    public abstract partial class ILRRequest
    {
        protected ILRRequest() { }
    }
    public partial class ILRRequestResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ILRRequestResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ILRRequest Properties { get { throw null; } set { } }
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
    public partial class InquiryInfo
    {
        public InquiryInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail ErrorDetail { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails> InquiryDetails { get { throw null; } }
        public string Status { get { throw null; } set { } }
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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail ErrorDetail { get { throw null; } set { } }
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
    public partial class KEKDetails
    {
        public KEKDetails() { }
        public string KeyBackupData { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
    }
    public partial class KeyAndSecretDetails
    {
        public KeyAndSecretDetails() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BEKDetails BekDetails { get { throw null; } set { } }
        public string EncryptionMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.KEKDetails KekDetails { get { throw null; } set { } }
    }
    public partial class KPIResourceHealthDetails
    {
        public KPIResourceHealthDetails() { }
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
    public partial class ListRecoveryPointsRecommendedForMoveContent
    {
        public ListRecoveryPointsRecommendedForMoveContent() { }
        public System.Collections.Generic.IList<string> ExcludedRPList { get { throw null; } }
        public string ObjectType { get { throw null; } set { } }
    }
    public partial class LogSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy
    {
        public LogSchedulePolicy() { }
        public int? ScheduleFrequencyInMins { get { throw null; } set { } }
    }
    public partial class LongTermRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy
    {
        public LongTermRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule DailySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule MonthlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule WeeklySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule YearlySchedule { get { throw null; } set { } }
    }
    public partial class LongTermSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy
    {
        public LongTermSchedulePolicy() { }
    }
    public partial class MabContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionContainer
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
    public partial class MabFileFolderProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItem
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
        public System.DateTimeOffset? OldestRecoveryPoint { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
    }
    public partial class MabJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public MabJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string MabServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType? MabServerType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType? WorkloadType { get { throw null; } set { } }
    }
    public partial class MabJobExtendedInfo
    {
        public MabJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabJobTaskDetails> TasksList { get { throw null; } }
    }
    public partial class MabJobTaskDetails
    {
        public MabJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
    }
    public partial class MabProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionPolicy
    {
        public MabProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy SchedulePolicy { get { throw null; } set { } }
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
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType SqlAGWorkLoadContainer { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.Day> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
    public enum MonthOfYear
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
    public partial class MoveRPAcrossTiersContent
    {
        public MoveRPAcrossTiersContent() { }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? SourceTierType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? TargetTierType { get { throw null; } set { } }
    }
    public partial class NameInfo
    {
        internal NameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class OperationResultInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationResultInfoBase
    {
        internal OperationResultInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> JobList { get { throw null; } }
    }
    public abstract partial class OperationResultInfoBase
    {
        protected OperationResultInfoBase() { }
    }
    public partial class OperationResultInfoBaseResource : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationWorkerResponse
    {
        internal OperationResultInfoBaseResource() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OperationResultInfoBase Operation { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusExtendedInfo Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue? Status { get { throw null; } }
    }
    public partial class OperationStatusError
    {
        internal OperationStatusError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public abstract partial class OperationStatusExtendedInfo
    {
        protected OperationStatusExtendedInfo() { }
    }
    public partial class OperationStatusJobExtendedInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusExtendedInfo
    {
        internal OperationStatusJobExtendedInfo() { }
        public string JobId { get { throw null; } }
    }
    public partial class OperationStatusJobsExtendedInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusExtendedInfo
    {
        internal OperationStatusJobsExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FailedJobsError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> JobIds { get { throw null; } }
    }
    public partial class OperationStatusProvisionILRExtendedInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusExtendedInfo
    {
        internal OperationStatusProvisionILRExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesBackup.Models.ClientScriptForConnect> RecoveryTargetClientScripts { get { throw null; } }
    }
    public partial class OperationStatusValidateOperationExtendedInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusExtendedInfo
    {
        internal OperationStatusValidateOperationExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail> ValidateOperationResponseValidationResults { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatusValue : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatusValue(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue Canceled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue left, Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue left, Azure.ResourceManager.RecoveryServicesBackup.Models.OperationStatusValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType Register { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType Reregister { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.OperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationWorkerResponse
    {
        internal OperationWorkerResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<string>> Headers { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.HttpStatusCode? StatusCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverwriteOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverwriteOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PointInTimeRange
    {
        public PointInTimeRange() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType CopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType right) { throw null; }
        public override string ToString() { throw null; }
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
        public PrepareDataMoveContent(string targetResourceId, string targetRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel) { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? IgnoreMoved { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceContainerArmIds { get { throw null; } }
        public string TargetRegion { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class PrepareDataMoveResponse : Azure.ResourceManager.RecoveryServicesBackup.Models.VaultStorageConfigOperationResultResponse
    {
        internal PrepareDataMoveResponse() { }
        public string CorrelationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SourceVaultProperties { get { throw null; } }
    }
    public partial class PreValidateEnableBackupContent
    {
        public PreValidateEnableBackupContent() { }
        public string Properties { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType? ResourceType { get { throw null; } set { } }
        public string VaultId { get { throw null; } set { } }
    }
    public partial class PreValidateEnableBackupResponse
    {
        internal PreValidateEnableBackupResponse() { }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus? Status { get { throw null; } }
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
    public abstract partial class ProtectedItem
    {
        protected ProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } }
        public string BackupSetName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? DeferredDeleteTimeInUTC { get { throw null; } set { } }
        public string DeferredDeleteTimeRemaining { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public bool? IsDeferredDeleteScheduleUpcoming { get { throw null; } set { } }
        public bool? IsRehydrate { get { throw null; } set { } }
        public bool? IsScheduledForDeferredDelete { get { throw null; } set { } }
        public System.DateTimeOffset? LastRecoveryPoint { get { throw null; } set { } }
        public string PolicyId { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public int? SoftDeleteRetentionPeriod { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataSourceType? WorkloadType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectedItemHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectedItemHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus NotReachable { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public abstract partial class ProtectionContainer
    {
        protected ProtectionContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        public string ProtectableObjectType { get { throw null; } set { } }
        public string RegistrationStatus { get { throw null; } set { } }
    }
    public abstract partial class ProtectionIntent
    {
        protected ProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string ItemId { get { throw null; } set { } }
        public string PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
    }
    public abstract partial class ProtectionPolicy
    {
        protected ProtectionPolicy() { }
        public int? ProtectedItemsCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState BackupsSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState ProtectionPaused { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState ProtectionStopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus Protecting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus ProtectionFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public abstract partial class RecoveryPoint
    {
        protected RecoveryPoint() { }
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
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public string RuleName { get { throw null; } set { } }
    }
    public partial class RecoveryPointRehydrationInfo
    {
        public RecoveryPointRehydrationInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan? RehydrationRetentionDuration { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType AlternateLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType Offline { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType OriginalLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType RestoreDisks { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryType right) { throw null; }
        public override string ToString() { throw null; }
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
        public string DefaultResourceRequest { get { throw null; } set { } }
        public string VaultCriticalOperation { get { throw null; } set { } }
    }
    public partial class ResourceGuardProxyBase
    {
        public ResourceGuardProxyBase() { }
        public string Description { get { throw null; } set { } }
        public string LastUpdatedTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
        public string ResourceGuardResourceId { get { throw null; } set { } }
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
    public partial class RestoreFileSpecs
    {
        public RestoreFileSpecs() { }
        public string FileSpecType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string TargetFolderPath { get { throw null; } set { } }
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
    public abstract partial class RestoreRequest
    {
        protected RestoreRequest() { }
    }
    public partial class RestoreRequestResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RestoreRequestResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequest Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreRequestType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreRequestType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType FullShareRestore { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType ItemLevelRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequestType right) { throw null; }
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
    public abstract partial class RetentionPolicy
    {
        protected RetentionPolicy() { }
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
    public abstract partial class SchedulePolicy
    {
        protected SchedulePolicy() { }
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
    public partial class SecurityPinBase
    {
        public SecurityPinBase() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
    }
    public partial class Settings
    {
        public Settings() { }
        public bool? IsCompression { get { throw null; } set { } }
        public bool? IsSqlCompression { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class SimpleRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy
    {
        public SimpleRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
    }
    public partial class SimpleSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy
    {
        public SimpleSchedulePolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.HourlySchedule HourlySchedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DayOfWeek> ScheduleRunDays { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public int? ScheduleWeeklyFrequency { get { throw null; } set { } }
    }
    public partial class SimpleSchedulePolicyV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy
    {
        public SimpleSchedulePolicyV2() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.HourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklySchedule WeeklySchedule { get { throw null; } set { } }
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
    public partial class SQLDataDirectory
    {
        public SQLDataDirectory() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType? DirectoryType { get { throw null; } set { } }
        public string LogicalName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class SQLDataDirectoryMapping
    {
        public SQLDataDirectoryMapping() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType? MappingType { get { throw null; } set { } }
        public string SourceLogicalName { get { throw null; } set { } }
        public string SourcePath { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SQLDataDirectoryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SQLDataDirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType Data { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SQLDataDirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType ReadAccessGeoZoneRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTypeState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTypeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState Locked { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.StorageTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubProtectionPolicy
    {
        public SubProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringPolicy> TieringPolicy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus DefaultOFF { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus DefaultON { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus Supported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.SupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetAFSRestoreInfo
    {
        public TargetAFSRestoreInfo() { }
        public string Name { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
    }
    public partial class TargetRestoreInfo
    {
        public TargetRestoreInfo() { }
        public string ContainerId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.OverwriteOption? OverwriteOption { get { throw null; } set { } }
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
    public partial class TieringPolicy
    {
        public TieringPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType? DurationType { get { throw null; } set { } }
        public int? DurationValue { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode? TieringMode { get { throw null; } set { } }
    }
    public partial class TokenInformation
    {
        internal TokenInformation() { }
        public long? ExpiryTimeInUtcTicks { get { throw null; } }
        public string SecurityPIN { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class TriggerDataMoveContent
    {
        public TriggerDataMoveContent(string sourceResourceId, string sourceRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? PauseGC { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceContainerArmIds { get { throw null; } }
        public string SourceRegion { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
    }
    public partial class UnlockDeleteContent
    {
        public UnlockDeleteContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public string ResourceToBeDeleted { get { throw null; } set { } }
    }
    public partial class UnlockDeleteResponse
    {
        internal UnlockDeleteResponse() { }
        public string UnlockDeleteExpiryTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsagesUnit : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsagesUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.UsagesUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateIaasVmRestoreOperationRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateRestoreOperationRequest
    {
        public ValidateIaasVmRestoreOperationRequest() { }
    }
    public abstract partial class ValidateOperationRequest
    {
        protected ValidateOperationRequest() { }
    }
    public partial class ValidateOperationsResponse
    {
        internal ValidateOperationsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesBackup.Models.ErrorDetail> ValidateOperationResponseValidationResults { get { throw null; } }
    }
    public partial class ValidateRestoreOperationRequest : Azure.ResourceManager.RecoveryServicesBackup.Models.ValidateOperationRequest
    {
        public ValidateRestoreOperationRequest() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreRequest RestoreRequest { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupJobProperties
    {
        public VaultJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultJobErrorInfo> ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedInfoPropertyBag { get { throw null; } }
    }
    public partial class VaultJobErrorInfo
    {
        public VaultJobErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
    }
    public abstract partial class VaultStorageConfigOperationResultResponse
    {
        protected VaultStorageConfigOperationResultResponse() { }
    }
    public partial class WeeklyRetentionFormat
    {
        public WeeklyRetentionFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DayOfWeek> DaysOfTheWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WeekOfMonth> WeeksOfTheMonth { get { throw null; } }
    }
    public partial class WeeklyRetentionSchedule
    {
        public WeeklyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DayOfWeek> DaysOfTheWeek { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
    public partial class WeeklySchedule
    {
        public WeeklySchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DayOfWeek> ScheduleRunDays { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
    }
    public enum WeekOfMonth
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
        Invalid = 5,
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
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus? ProtectionState { get { throw null; } set { } }
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
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SAPAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SAPAseSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SAPHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SAPHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SAPHanaSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SQLDataBase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SQLInstance { get { throw null; } }
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
    public abstract partial class WorkloadProtectableItem
    {
        protected WorkloadProtectableItem() { }
        public string BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
    }
    public partial class WorkloadProtectableItemResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkloadProtectableItemResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType AzureSqlDb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SAPAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SAPHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SAPHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SQLDataBase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct XcoolState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public XcoolState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.XcoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class YearlyRetentionSchedule
    {
        public YearlyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthOfYear> MonthsOfYear { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.Day> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
    }
}
