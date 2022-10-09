namespace Azure.ResourceManager.DataProtection
{
    public partial class AzureBackupJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureBackupJobResource() { }
        public virtual Azure.ResourceManager.DataProtection.AzureBackupJobResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureBackupJobResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.AzureBackupJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.AzureBackupJobResource>, System.Collections.IEnumerable
    {
        protected AzureBackupJobResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.AzureBackupJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.AzureBackupJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.AzureBackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.AzureBackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.AzureBackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.AzureBackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureBackupJobResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupJobResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.AzureBackupJob Properties { get { throw null; } set { } }
    }
    public partial class AzureBackupRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureBackupRecoveryPointResource() { }
        public virtual Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureBackupRecoveryPointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected AzureBackupRecoveryPointResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureBackupRecoveryPointResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupRecoveryPointResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.AzureBackupRecoveryPoint Properties { get { throw null; } set { } }
    }
    public partial class BackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtection.BackupInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo> AdhocBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo>> AdhocBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.Models.AzureBackupFindRestorableTimeRangesResponseResource> FindRestorableTimeRange(Azure.ResourceManager.DataProtection.Models.AzureBackupFindRestorableTimeRangesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.Models.AzureBackupFindRestorableTimeRangesResponseResource>> FindRestorableTimeRangeAsync(Azure.ResourceManager.DataProtection.Models.AzureBackupFindRestorableTimeRangesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource> GetAzureBackupRecoveryPointResource(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource>> GetAzureBackupRecoveryPointResourceAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResourceCollection GetAzureBackupRecoveryPointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SuspendBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SyncBackupInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.SyncBackupInstanceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.SyncBackupInstanceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRehydrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.AzureBackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRehydrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.AzureBackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo> TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo>> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo> ValidateForRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.ValidateRestoreRequestObject validateRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo>> ValidateForRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.ValidateRestoreRequestObject validateRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupInstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BackupInstanceResource>, System.Collections.IEnumerable
    {
        protected BackupInstanceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtection.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtection.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.BackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.BackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.BackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.BackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BackupInstanceResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.BackupInstance Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BackupVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupVaultResource() { }
        public virtual Azure.ResourceManager.DataProtection.BackupVaultResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource> GetAzureBackupJobResource(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.AzureBackupJobResource>> GetAzureBackupJobResourceAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.AzureBackupJobResourceCollection GetAzureBackupJobResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource> GetBackupInstanceResource(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupInstanceResource>> GetBackupInstanceResourceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.BackupInstanceResourceCollection GetBackupInstanceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> GetBaseBackupPolicyResource(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>> GetBaseBackupPolicyResourceAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceCollection GetBaseBackupPolicyResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> GetDeletedBackupInstanceResource(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>> GetDeletedBackupInstanceResourceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.DeletedBackupInstanceResourceCollection GetDeletedBackupInstanceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> GetResourceGuardProxyBaseResource(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>> GetResourceGuardProxyBaseResourceAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceCollection GetResourceGuardProxyBaseResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerExportJob(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerExportJobAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo> ValidateForBackupBackupInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.ValidateForBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.Models.OperationJobExtendedInfo>> ValidateForBackupBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.Models.ValidateForBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupVaultResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BackupVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BackupVaultResource>, System.Collections.IEnumerable
    {
        protected BackupVaultResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtection.BackupVaultResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BackupVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtection.BackupVaultResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.BackupVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.BackupVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.BackupVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BackupVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.BackupVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BackupVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupVaultResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupVaultResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtection.Models.BackupVault properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.BackupVault Properties { get { throw null; } set { } }
    }
    public partial class BaseBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BaseBackupPolicyResource() { }
        public virtual Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BaseBackupPolicyResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected BaseBackupPolicyResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtection.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.BaseBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BaseBackupPolicyResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BaseBackupPolicyResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.BaseBackupPolicy Properties { get { throw null; } set { } }
    }
    public static partial class DataProtectionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataProtection.Models.FeatureValidationResponseBase> CheckFeatureSupportDataProtection(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtection.Models.FeatureValidationRequestBase featureValidationRequestBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.Models.FeatureValidationResponseBase>> CheckFeatureSupportDataProtectionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtection.Models.FeatureValidationRequestBase featureValidationRequestBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtection.Models.CheckNameAvailabilityResult> CheckNameAvailabilityBackupVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtection.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityBackupVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtection.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtection.AzureBackupJobResource GetAzureBackupJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.AzureBackupRecoveryPointResource GetAzureBackupRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.BackupInstanceResource GetBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.BackupVaultResource GetBackupVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource> GetBackupVaultResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.BackupVaultResource>> GetBackupVaultResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtection.BackupVaultResourceCollection GetBackupVaultResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtection.BackupVaultResource> GetBackupVaultResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtection.BackupVaultResource> GetBackupVaultResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtection.BaseBackupPolicyResource GetBaseBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource GetDeletedBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource GetResourceGuardDeleteProtectedItemRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource GetResourceGuardDeleteResourceGuardProxyRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource GetResourceGuardDisableSoftDeleteRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource GetResourceGuardGetBackupSecurityPINRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource GetResourceGuardProxyBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardResource GetResourceGuardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> GetResourceGuardResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> GetResourceGuardResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardResourceCollection GetResourceGuardResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardResource> GetResourceGuardResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardResource> GetResourceGuardResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource GetResourceGuardUpdateProtectedItemRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource GetResourceGuardUpdateProtectionPolicyRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeletedBackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedBackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtection.DeletedBackupInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Undelete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UndeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedBackupInstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>, System.Collections.IEnumerable
    {
        protected DeletedBackupInstanceResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.DeletedBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedBackupInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedBackupInstanceResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.DeletedBackupInstance Properties { get { throw null; } set { } }
    }
    public partial class DppBaseResourceData
    {
        internal DppBaseResourceData() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ResourceGuardDeleteProtectedItemRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDeleteProtectedItemRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDeleteProtectedItemRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDeleteProtectedItemRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardDeleteResourceGuardProxyRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDeleteResourceGuardProxyRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDeleteResourceGuardProxyRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDeleteResourceGuardProxyRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardDisableSoftDeleteRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDisableSoftDeleteRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDisableSoftDeleteRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDisableSoftDeleteRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardGetBackupSecurityPINRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardGetBackupSecurityPINRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardGetBackupSecurityPINRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardGetBackupSecurityPINRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardProxyBaseResource() { }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string resourceGuardProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.Models.UnlockDeleteResponse> UnlockDelete(Azure.ResourceManager.DataProtection.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.Models.UnlockDeleteResponse>> UnlockDeleteAsync(Azure.ResourceManager.DataProtection.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardProxyBaseResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> Get(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>> GetAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardProxyBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceGuardProxyBaseResourceData() { }
        public Azure.ResourceManager.DataProtection.Models.ResourceGuardProxyBase Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardResource() { }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource> GetResourceGuardDeleteProtectedItemRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestResource>> GetResourceGuardDeleteProtectedItemRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardDeleteProtectedItemRequestCollection GetResourceGuardDeleteProtectedItemRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource> GetResourceGuardDeleteResourceGuardProxyRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetResourceGuardDeleteResourceGuardProxyRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardDeleteResourceGuardProxyRequestCollection GetResourceGuardDeleteResourceGuardProxyRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource> GetResourceGuardDisableSoftDeleteRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestResource>> GetResourceGuardDisableSoftDeleteRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardDisableSoftDeleteRequestCollection GetResourceGuardDisableSoftDeleteRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource> GetResourceGuardGetBackupSecurityPINRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestResource>> GetResourceGuardGetBackupSecurityPINRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardGetBackupSecurityPINRequestCollection GetResourceGuardGetBackupSecurityPINRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> GetResourceGuardUpdateProtectedItemRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>> GetResourceGuardUpdateProtectedItemRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestCollection GetResourceGuardUpdateProtectedItemRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> GetResourceGuardUpdateProtectionPolicyRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>> GetResourceGuardUpdateProtectionPolicyRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestCollection GetResourceGuardUpdateProtectionPolicyRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> Update(Azure.ResourceManager.DataProtection.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> UpdateAsync(Azure.ResourceManager.DataProtection.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtection.ResourceGuardResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtection.ResourceGuardResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtection.ResourceGuardResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource> Get(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardResource>> GetAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGuardResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.ResourceGuard Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardUpdateProtectedItemRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardUpdateProtectedItemRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardUpdateProtectedItemRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardUpdateProtectedItemRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectedItemRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardUpdateProtectionPolicyRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardUpdateProtectionPolicyRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardUpdateProtectionPolicyRequestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardUpdateProtectionPolicyRequestResource() { }
        public virtual Azure.ResourceManager.DataProtection.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtection.ResourceGuardUpdateProtectionPolicyRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataProtection.Models
{
    public partial class AbsoluteDeleteOption : Azure.ResourceManager.DataProtection.Models.DeleteOption
    {
        public AbsoluteDeleteOption(System.TimeSpan duration) : base (default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AbsoluteMarker : System.IEquatable<Azure.ResourceManager.DataProtection.Models.AbsoluteMarker>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AbsoluteMarker(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.AbsoluteMarker AllBackup { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.AbsoluteMarker FirstOfDay { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.AbsoluteMarker FirstOfMonth { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.AbsoluteMarker FirstOfWeek { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.AbsoluteMarker FirstOfYear { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.AbsoluteMarker other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.AbsoluteMarker left, Azure.ResourceManager.DataProtection.Models.AbsoluteMarker right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.AbsoluteMarker (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.AbsoluteMarker left, Azure.ResourceManager.DataProtection.Models.AbsoluteMarker right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdHocBackupRuleOptions
    {
        public AdHocBackupRuleOptions(string ruleName, Azure.ResourceManager.DataProtection.Models.AdhocBackupTriggerOption triggerOption) { }
        public string RuleName { get { throw null; } }
        public string TriggerOptionRetentionTagOverride { get { throw null; } }
    }
    public partial class AdhocBackupTriggerOption
    {
        public AdhocBackupTriggerOption() { }
        public string RetentionTagOverride { get { throw null; } set { } }
    }
    public partial class AdhocBasedTaggingCriteria
    {
        public AdhocBasedTaggingCriteria() { }
        public Azure.ResourceManager.DataProtection.Models.RetentionTag TagInfo { get { throw null; } set { } }
    }
    public partial class AdhocBasedTriggerContext : Azure.ResourceManager.DataProtection.Models.TriggerContext
    {
        public AdhocBasedTriggerContext(Azure.ResourceManager.DataProtection.Models.AdhocBasedTaggingCriteria taggingCriteria) { }
        public Azure.ResourceManager.DataProtection.Models.RetentionTag TaggingCriteriaTagInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.AlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.AlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.AlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.AlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.AlertsState left, Azure.ResourceManager.DataProtection.Models.AlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.AlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.AlertsState left, Azure.ResourceManager.DataProtection.Models.AlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AuthCredentials
    {
        protected AuthCredentials() { }
    }
    public partial class AzureBackupDiscreteRecoveryPoint : Azure.ResourceManager.DataProtection.Models.AzureBackupRecoveryPoint
    {
        public AzureBackupDiscreteRecoveryPoint(System.DateTimeOffset recoveryPointOn) { }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.RecoveryPointDataStoreDetails> RecoveryPointDataStoresDetails { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
        public System.DateTimeOffset RecoveryPointOn { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string RetentionTagName { get { throw null; } set { } }
        public string RetentionTagVersion { get { throw null; } set { } }
    }
    public partial class AzureBackupFindRestorableTimeRangesContent
    {
        public AzureBackupFindRestorableTimeRangesContent(Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType sourceDataStoreType) { }
        public string EndTime { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType SourceDataStoreType { get { throw null; } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class AzureBackupFindRestorableTimeRangesResponse
    {
        public AzureBackupFindRestorableTimeRangesResponse() { }
        public string ObjectType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.RestorableTimeRange> RestorableTimeRanges { get { throw null; } }
    }
    public partial class AzureBackupFindRestorableTimeRangesResponseResource : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupFindRestorableTimeRangesResponseResource() { }
        public Azure.ResourceManager.DataProtection.Models.AzureBackupFindRestorableTimeRangesResponse Properties { get { throw null; } set { } }
    }
    public partial class AzureBackupJob
    {
        public AzureBackupJob(string activityId, string backupInstanceFriendlyName, string dataSourceId, string dataSourceLocation, string dataSourceName, string dataSourceType, bool isUserTriggered, string operation, string operationCategory, bool progressEnabled, string sourceResourceGroup, string sourceSubscriptionId, System.DateTimeOffset startOn, string status, string subscriptionId, System.Collections.Generic.IEnumerable<string> supportedActions, string vaultName) { }
        public string ActivityId { get { throw null; } set { } }
        public string BackupInstanceFriendlyName { get { throw null; } set { } }
        public string BackupInstanceId { get { throw null; } }
        public string DataSourceId { get { throw null; } set { } }
        public string DataSourceLocation { get { throw null; } set { } }
        public string DataSourceName { get { throw null; } set { } }
        public string DataSourceSetName { get { throw null; } set { } }
        public string DataSourceType { get { throw null; } set { } }
        public string DestinationDataStoreName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.JobExtendedInfo ExtendedInfo { get { throw null; } }
        public bool IsUserTriggered { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public string OperationCategory { get { throw null; } set { } }
        public string PolicyId { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public bool ProgressEnabled { get { throw null; } set { } }
        public System.Uri ProgressUri { get { throw null; } }
        public string RestoreType { get { throw null; } }
        public string SourceDataStoreName { get { throw null; } set { } }
        public string SourceResourceGroup { get { throw null; } set { } }
        public string SourceSubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedActions { get { throw null; } }
        public string VaultName { get { throw null; } set { } }
    }
    public partial class AzureBackupParams : Azure.ResourceManager.DataProtection.Models.BackupParameters
    {
        public AzureBackupParams(string backupType) { }
        public string BackupType { get { throw null; } set { } }
    }
    public abstract partial class AzureBackupRecoveryPoint
    {
        protected AzureBackupRecoveryPoint() { }
    }
    public partial class AzureBackupRecoveryPointBasedRestoreRequest : Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent
    {
        public AzureBackupRecoveryPointBasedRestoreRequest(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId) : base (default(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType)) { }
        public string RecoveryPointId { get { throw null; } }
    }
    public partial class AzureBackupRecoveryTimeBasedRestoreRequest : Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent
    {
        public AzureBackupRecoveryTimeBasedRestoreRequest(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointTime) : base (default(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType)) { }
        public string RecoveryPointTime { get { throw null; } }
    }
    public partial class AzureBackupRehydrationContent
    {
        public AzureBackupRehydrationContent(string recoveryPointId, System.TimeSpan rehydrationRetentionDuration) { }
        public string RecoveryPointId { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.RehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    public abstract partial class AzureBackupRestoreContent
    {
        protected AzureBackupRestoreContent(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType sourceDataStoreType) { }
        public Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase RestoreTargetInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.SourceDataStoreType SourceDataStoreType { get { throw null; } }
        public string SourceResourceId { get { throw null; } set { } }
    }
    public partial class AzureBackupRestoreWithRehydrationRequest : Azure.ResourceManager.DataProtection.Models.AzureBackupRecoveryPointBasedRestoreRequest
    {
        public AzureBackupRestoreWithRehydrationRequest(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId, Azure.ResourceManager.DataProtection.Models.RehydrationPriority rehydrationPriority, System.TimeSpan rehydrationRetentionDuration) : base (default(Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType), default(string)) { }
        public Azure.ResourceManager.DataProtection.Models.RehydrationPriority RehydrationPriority { get { throw null; } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    public partial class AzureBackupRule : Azure.ResourceManager.DataProtection.Models.BasePolicyRule
    {
        public AzureBackupRule(string name, Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase dataStore, Azure.ResourceManager.DataProtection.Models.TriggerContext trigger) : base (default(string)) { }
        public Azure.ResourceManager.DataProtection.Models.BackupParameters BackupParameters { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.TriggerContext Trigger { get { throw null; } set { } }
    }
    public partial class AzureOperationalStoreParameters : Azure.ResourceManager.DataProtection.Models.DataStoreParameters
    {
        public AzureOperationalStoreParameters(Azure.ResourceManager.DataProtection.Models.DataStoreType dataStoreType) : base (default(Azure.ResourceManager.DataProtection.Models.DataStoreType)) { }
        public string ResourceGroupId { get { throw null; } set { } }
    }
    public partial class AzureRetentionRule : Azure.ResourceManager.DataProtection.Models.BasePolicyRule
    {
        public AzureRetentionRule(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.Models.SourceLifeCycle> lifecycles) : base (default(string)) { }
        public bool? IsDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.SourceLifeCycle> Lifecycles { get { throw null; } }
    }
    public abstract partial class BackupCriteria
    {
        protected BackupCriteria() { }
    }
    public partial class BackupInstance
    {
        public BackupInstance(Azure.ResourceManager.DataProtection.Models.Datasource dataSourceInfo, Azure.ResourceManager.DataProtection.Models.PolicyInfo policyInfo, string objectType) { }
        public Azure.ResourceManager.DataProtection.Models.CurrentProtectionState? CurrentProtectionState { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.Datasource DataSourceInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.DatasourceSet DataSourceSetInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.PolicyInfo PolicyInfo { get { throw null; } set { } }
        public Azure.ResponseError ProtectionErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.ProtectionStatusDetails ProtectionStatus { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.ValidationType? ValidationType { get { throw null; } set { } }
    }
    public abstract partial class BackupParameters
    {
        protected BackupParameters() { }
    }
    public partial class BackupPolicy : Azure.ResourceManager.DataProtection.Models.BaseBackupPolicy
    {
        public BackupPolicy(System.Collections.Generic.IEnumerable<string> datasourceTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.Models.BasePolicyRule> policyRules) : base (default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.BasePolicyRule> PolicyRules { get { throw null; } }
    }
    public partial class BackupSchedule
    {
        public BackupSchedule(System.Collections.Generic.IEnumerable<string> repeatingTimeIntervals) { }
        public System.Collections.Generic.IList<string> RepeatingTimeIntervals { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class BackupVault
    {
        public BackupVault(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.Models.StorageSetting> storageSettings) { }
        public Azure.ResourceManager.DataProtection.Models.AlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public bool? IsVaultProtectedByResourceGuard { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.ResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.ResourceMoveState? ResourceMoveState { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.SecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.StorageSetting> StorageSettings { get { throw null; } }
    }
    public abstract partial class BaseBackupPolicy
    {
        protected BaseBackupPolicy(System.Collections.Generic.IEnumerable<string> datasourceTypes) { }
        public System.Collections.Generic.IList<string> DatasourceTypes { get { throw null; } }
    }
    public abstract partial class BasePolicyRule
    {
        protected BasePolicyRule(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class CopyOnExpiryOption : Azure.ResourceManager.DataProtection.Models.CopyOption
    {
        public CopyOnExpiryOption() { }
    }
    public abstract partial class CopyOption
    {
        protected CopyOption() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrentProtectionState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.CurrentProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrentProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState BackupSchedulesSuspended { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState ConfiguringProtection { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState ConfiguringProtectionFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState NotProtected { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState ProtectionConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState ProtectionStopped { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState RetentionSchedulesSuspended { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.CurrentProtectionState UpdatingProtection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.CurrentProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.CurrentProtectionState left, Azure.ResourceManager.DataProtection.Models.CurrentProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.CurrentProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.CurrentProtectionState left, Azure.ResourceManager.DataProtection.Models.CurrentProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomCopyOption : Azure.ResourceManager.DataProtection.Models.CopyOption
    {
        public CustomCopyOption() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
    }
    public partial class Datasource
    {
        public Datasource(string resourceId) { }
        public string DatasourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class DatasourceSet
    {
        public DatasourceSet(string resourceId) { }
        public string DatasourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class DataStoreInfoBase
    {
        public DataStoreInfoBase(Azure.ResourceManager.DataProtection.Models.DataStoreType dataStoreType, string objectType) { }
        public Azure.ResourceManager.DataProtection.Models.DataStoreType DataStoreType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
    }
    public abstract partial class DataStoreParameters
    {
        protected DataStoreParameters(Azure.ResourceManager.DataProtection.Models.DataStoreType dataStoreType) { }
        public Azure.ResourceManager.DataProtection.Models.DataStoreType DataStoreType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataStoreType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.DataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.DataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DataStoreType OperationalStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.DataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.DataStoreType left, Azure.ResourceManager.DataProtection.Models.DataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.DataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.DataStoreType left, Azure.ResourceManager.DataProtection.Models.DataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Day
    {
        public Day() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeek : System.IEquatable<Azure.ResourceManager.DataProtection.Models.DayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.DayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.DayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.DayOfWeek left, Azure.ResourceManager.DataProtection.Models.DayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.DayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.DayOfWeek left, Azure.ResourceManager.DataProtection.Models.DayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeletedBackupInstance : Azure.ResourceManager.DataProtection.Models.BackupInstance
    {
        public DeletedBackupInstance(Azure.ResourceManager.DataProtection.Models.Datasource dataSourceInfo, Azure.ResourceManager.DataProtection.Models.PolicyInfo policyInfo, string objectType) : base (default(Azure.ResourceManager.DataProtection.Models.Datasource), default(Azure.ResourceManager.DataProtection.Models.PolicyInfo), default(string)) { }
        public Azure.ResourceManager.DataProtection.Models.DeletionInfo DeletionInfo { get { throw null; } }
    }
    public abstract partial class DeleteOption
    {
        protected DeleteOption(System.TimeSpan duration) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
    }
    public partial class DeletionInfo
    {
        internal DeletionInfo() { }
        public string BillingEndDate { get { throw null; } }
        public string DeleteActivityId { get { throw null; } }
        public string DeletionTime { get { throw null; } }
        public string ScheduledPurgeTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureSupportStatus : System.IEquatable<Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureSupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus AlphaPreview { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus PrivatePreview { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus PublicPreview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus left, Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus left, Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.FeatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.FeatureType DataSourceType { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.FeatureType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.FeatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.FeatureType left, Azure.ResourceManager.DataProtection.Models.FeatureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.FeatureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.FeatureType left, Azure.ResourceManager.DataProtection.Models.FeatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureValidationRequest : Azure.ResourceManager.DataProtection.Models.FeatureValidationRequestBase
    {
        public FeatureValidationRequest() { }
        public string FeatureName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.FeatureType? FeatureType { get { throw null; } set { } }
    }
    public abstract partial class FeatureValidationRequestBase
    {
        protected FeatureValidationRequestBase() { }
    }
    public partial class FeatureValidationResponse : Azure.ResourceManager.DataProtection.Models.FeatureValidationResponseBase
    {
        internal FeatureValidationResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtection.Models.SupportedFeature> Features { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.FeatureType? FeatureType { get { throw null; } }
    }
    public abstract partial class FeatureValidationResponseBase
    {
        protected FeatureValidationResponseBase() { }
    }
    public partial class ImmediateCopyOption : Azure.ResourceManager.DataProtection.Models.CopyOption
    {
        public ImmediateCopyOption() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.ImmutabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.ImmutabilityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ImmutabilityState Locked { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ImmutabilityState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.ImmutabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.ImmutabilityState left, Azure.ResourceManager.DataProtection.Models.ImmutabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.ImmutabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.ImmutabilityState left, Azure.ResourceManager.DataProtection.Models.ImmutabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ItemLevelRestoreCriteria
    {
        protected ItemLevelRestoreCriteria() { }
    }
    public partial class ItemLevelRestoreTargetInfo : Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase
    {
        public ItemLevelRestoreTargetInfo(Azure.ResourceManager.DataProtection.Models.RecoveryOption recoveryOption, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.Models.ItemLevelRestoreCriteria> restoreCriteria, Azure.ResourceManager.DataProtection.Models.Datasource datasourceInfo) : base (default(Azure.ResourceManager.DataProtection.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtection.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.Datasource DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.DatasourceSet DatasourceSetInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.ItemLevelRestoreCriteria> RestoreCriteria { get { throw null; } }
    }
    public partial class JobExtendedInfo
    {
        internal JobExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string BackupInstanceState { get { throw null; } }
        public double? DataTransferredInBytes { get { throw null; } }
        public string RecoveryDestination { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.RestoreJobRecoveryPointDetails SourceRecoverPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtection.Models.JobSubTask> SubTasks { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.RestoreJobRecoveryPointDetails TargetRecoverPoint { get { throw null; } }
    }
    public partial class JobSubTask
    {
        internal JobSubTask() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public int TaskId { get { throw null; } }
        public string TaskName { get { throw null; } }
        public string TaskProgress { get { throw null; } }
        public string TaskStatus { get { throw null; } }
    }
    public partial class KubernetesPVRestoreCriteria : Azure.ResourceManager.DataProtection.Models.ItemLevelRestoreCriteria
    {
        public KubernetesPVRestoreCriteria() { }
        public string Name { get { throw null; } set { } }
        public string StorageClassName { get { throw null; } set { } }
    }
    public partial class KubernetesStorageClassRestoreCriteria : Azure.ResourceManager.DataProtection.Models.ItemLevelRestoreCriteria
    {
        public KubernetesStorageClassRestoreCriteria() { }
        public string Provisioner { get { throw null; } set { } }
        public string SelectedStorageClassName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Month : System.IEquatable<Azure.ResourceManager.DataProtection.Models.Month>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Month(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.Month April { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month August { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month December { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month February { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month January { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month July { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month June { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month March { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month May { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month November { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month October { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Month September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.Month other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.Month left, Azure.ResourceManager.DataProtection.Models.Month right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.Month (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.Month left, Azure.ResourceManager.DataProtection.Models.Month right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class OperationExtendedInfo
    {
        protected OperationExtendedInfo() { }
    }
    public partial class OperationJobExtendedInfo : Azure.ResourceManager.DataProtection.Models.OperationExtendedInfo
    {
        internal OperationJobExtendedInfo() { }
        public string JobId { get { throw null; } }
    }
    public partial class PatchBackupVaultInput
    {
        public PatchBackupVaultInput() { }
        public Azure.ResourceManager.DataProtection.Models.AlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.SecuritySettings SecuritySettings { get { throw null; } set { } }
    }
    public partial class PatchResourceRequestInput
    {
        public PatchResourceRequestInput() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.PatchBackupVaultInput Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PolicyInfo
    {
        public PolicyInfo(string policyId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.DataStoreParameters> DataStoreParametersList { get { throw null; } }
        public string PolicyId { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } }
    }
    public partial class ProtectionStatusDetails
    {
        internal ProtectionStatusDetails() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.Status? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.ProvisioningState left, Azure.ResourceManager.DataProtection.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.ProvisioningState left, Azure.ResourceManager.DataProtection.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangeBasedItemLevelRestoreCriteria : Azure.ResourceManager.DataProtection.Models.ItemLevelRestoreCriteria
    {
        public RangeBasedItemLevelRestoreCriteria() { }
        public string MaxMatchingValue { get { throw null; } set { } }
        public string MinMatchingValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryOption : System.IEquatable<Azure.ResourceManager.DataProtection.Models.RecoveryOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryOption(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.RecoveryOption FailIfExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.RecoveryOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.RecoveryOption left, Azure.ResourceManager.DataProtection.Models.RecoveryOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.RecoveryOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.RecoveryOption left, Azure.ResourceManager.DataProtection.Models.RecoveryOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPointDataStoreDetails
    {
        public RecoveryPointDataStoreDetails() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string MetaData { get { throw null; } set { } }
        public string RecoveryPointDataStoreDetailsType { get { throw null; } set { } }
        public System.DateTimeOffset? RehydrationExpiryOn { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.RehydrationStatus? RehydrationStatus { get { throw null; } }
        public string State { get { throw null; } set { } }
        public bool? Visible { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationPriority : System.IEquatable<Azure.ResourceManager.DataProtection.Models.RehydrationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationPriority(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationPriority High { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationPriority Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationPriority Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.RehydrationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.RehydrationPriority left, Azure.ResourceManager.DataProtection.Models.RehydrationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.RehydrationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.RehydrationPriority left, Azure.ResourceManager.DataProtection.Models.RehydrationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationStatus : System.IEquatable<Azure.ResourceManager.DataProtection.Models.RehydrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationStatus CreateINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationStatus DeleteINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RehydrationStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.RehydrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.RehydrationStatus left, Azure.ResourceManager.DataProtection.Models.RehydrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.RehydrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.RehydrationStatus left, Azure.ResourceManager.DataProtection.Models.RehydrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuard
    {
        public ResourceGuard() { }
        public bool? AllowAutoApprovals { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtection.Models.ResourceGuardOperation> ResourceGuardOperations { get { throw null; } }
        public System.Collections.Generic.IList<string> VaultCriticalOperationExclusionList { get { throw null; } }
    }
    public partial class ResourceGuardOperation
    {
        internal ResourceGuardOperation() { }
        public string RequestResourceType { get { throw null; } }
        public string VaultCriticalOperation { get { throw null; } }
    }
    public partial class ResourceGuardOperationDetail
    {
        public ResourceGuardOperationDetail() { }
        public string DefaultResourceRequest { get { throw null; } set { } }
        public string VaultCriticalOperation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceGuardProvisioningState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceGuardProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState left, Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState left, Azure.ResourceManager.DataProtection.Models.ResourceGuardProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuardProxyBase
    {
        public ResourceGuardProxyBase() { }
        public string Description { get { throw null; } set { } }
        public string LastUpdatedTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
        public string ResourceGuardResourceId { get { throw null; } set { } }
    }
    public partial class ResourceMoveDetails
    {
        internal ResourceMoveDetails() { }
        public string CompletionTimeUtc { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string SourceResourcePath { get { throw null; } }
        public string StartTimeUtc { get { throw null; } }
        public string TargetResourcePath { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceMoveState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.ResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState CommitTimedout { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState CriticalFailure { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState MoveSucceeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState PartialSuccess { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState PrepareTimedout { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ResourceMoveState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.ResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.ResourceMoveState left, Azure.ResourceManager.DataProtection.Models.ResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.ResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.ResourceMoveState left, Azure.ResourceManager.DataProtection.Models.ResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorableTimeRange
    {
        public RestorableTimeRange(string startTime, string endTime) { }
        public string EndTime { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class RestoreFilesTargetInfo : Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase
    {
        public RestoreFilesTargetInfo(Azure.ResourceManager.DataProtection.Models.RecoveryOption recoveryOption, Azure.ResourceManager.DataProtection.Models.TargetDetails targetDetails) : base (default(Azure.ResourceManager.DataProtection.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtection.Models.TargetDetails TargetDetails { get { throw null; } }
    }
    public partial class RestoreJobRecoveryPointDetails
    {
        internal RestoreJobRecoveryPointDetails() { }
        public string RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreSourceDataStoreType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreSourceDataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType OperationalStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType left, Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType left, Azure.ResourceManager.DataProtection.Models.RestoreSourceDataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreTargetInfo : Azure.ResourceManager.DataProtection.Models.RestoreTargetInfoBase
    {
        public RestoreTargetInfo(Azure.ResourceManager.DataProtection.Models.RecoveryOption recoveryOption, Azure.ResourceManager.DataProtection.Models.Datasource datasourceInfo) : base (default(Azure.ResourceManager.DataProtection.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtection.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.Datasource DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.DatasourceSet DatasourceSetInfo { get { throw null; } set { } }
    }
    public abstract partial class RestoreTargetInfoBase
    {
        protected RestoreTargetInfoBase(Azure.ResourceManager.DataProtection.Models.RecoveryOption recoveryOption) { }
        public Azure.ResourceManager.DataProtection.Models.RecoveryOption RecoveryOption { get { throw null; } }
        public string RestoreLocation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreTargetLocationType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreTargetLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType AzureBlobs { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType left, Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType left, Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionTag
    {
        public RetentionTag(string tagName) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } set { } }
    }
    public partial class ScheduleBasedBackupCriteria : Azure.ResourceManager.DataProtection.Models.BackupCriteria
    {
        public ScheduleBasedBackupCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.AbsoluteMarker> AbsoluteCriteria { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.Day> DaysOfMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.DayOfWeek> DaysOfTheWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.Month> MonthsOfYear { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleTimes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.WeekNumber> WeeksOfTheMonth { get { throw null; } }
    }
    public partial class ScheduleBasedTriggerContext : Azure.ResourceManager.DataProtection.Models.TriggerContext
    {
        public ScheduleBasedTriggerContext(Azure.ResourceManager.DataProtection.Models.BackupSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtection.Models.TaggingCriteria> taggingCriteria) { }
        public Azure.ResourceManager.DataProtection.Models.BackupSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.TaggingCriteria> TaggingCriteria { get { throw null; } }
    }
    public partial class SecretStoreBasedAuthCredentials : Azure.ResourceManager.DataProtection.Models.AuthCredentials
    {
        public SecretStoreBasedAuthCredentials() { }
        public Azure.ResourceManager.DataProtection.Models.SecretStoreResource SecretStoreResource { get { throw null; } set { } }
    }
    public partial class SecretStoreResource
    {
        public SecretStoreResource(Azure.ResourceManager.DataProtection.Models.SecretStoreType secretStoreType) { }
        public Azure.ResourceManager.DataProtection.Models.SecretStoreType SecretStoreType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretStoreType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.SecretStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.SecretStoreType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SecretStoreType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.SecretStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.SecretStoreType left, Azure.ResourceManager.DataProtection.Models.SecretStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.SecretStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.SecretStoreType left, Azure.ResourceManager.DataProtection.Models.SecretStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecuritySettings
    {
        public SecuritySettings() { }
        public Azure.ResourceManager.DataProtection.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.SoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
    }
    public partial class SoftDeleteSettings
    {
        public SoftDeleteSettings() { }
        public double? RetentionDurationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.SoftDeleteState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftDeleteState : System.IEquatable<Azure.ResourceManager.DataProtection.Models.SoftDeleteState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftDeleteState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.SoftDeleteState AlwaysOn { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SoftDeleteState Off { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SoftDeleteState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.SoftDeleteState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.SoftDeleteState left, Azure.ResourceManager.DataProtection.Models.SoftDeleteState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.SoftDeleteState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.SoftDeleteState left, Azure.ResourceManager.DataProtection.Models.SoftDeleteState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceDataStoreType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.SourceDataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceDataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.SourceDataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SourceDataStoreType SnapshotStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SourceDataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType left, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.SourceDataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.SourceDataStoreType left, Azure.ResourceManager.DataProtection.Models.SourceDataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceLifeCycle
    {
        public SourceLifeCycle(Azure.ResourceManager.DataProtection.Models.DeleteOption deleteAfter, Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase sourceDataStore) { }
        public Azure.ResourceManager.DataProtection.Models.DeleteOption DeleteAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase SourceDataStore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.TargetCopySetting> TargetDataStoreCopySettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.DataProtection.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.Status ConfiguringProtection { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Status ConfiguringProtectionFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Status ProtectionConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Status ProtectionStopped { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Status SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.Status SoftDeleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.Status left, Azure.ResourceManager.DataProtection.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.Status left, Azure.ResourceManager.DataProtection.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSetting
    {
        public StorageSetting() { }
        public Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType? DatastoreType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.StorageSettingType? SettingType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSettingStoreType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSettingStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType SnapshotStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType left, Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType left, Azure.ResourceManager.DataProtection.Models.StorageSettingStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSettingType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.StorageSettingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSettingType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingType GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingType LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.StorageSettingType ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.StorageSettingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.StorageSettingType left, Azure.ResourceManager.DataProtection.Models.StorageSettingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.StorageSettingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.StorageSettingType left, Azure.ResourceManager.DataProtection.Models.StorageSettingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedFeature
    {
        internal SupportedFeature() { }
        public System.Collections.Generic.IReadOnlyList<string> ExposureControlledFeatures { get { throw null; } }
        public string FeatureName { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.FeatureSupportStatus? SupportStatus { get { throw null; } }
    }
    public partial class SyncBackupInstanceContent
    {
        public SyncBackupInstanceContent() { }
        public Azure.ResourceManager.DataProtection.Models.SyncType? SyncType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.SyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.SyncType Default { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.SyncType ForceResync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.SyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.SyncType left, Azure.ResourceManager.DataProtection.Models.SyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.SyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.SyncType left, Azure.ResourceManager.DataProtection.Models.SyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TaggingCriteria
    {
        public TaggingCriteria(bool isDefault, long taggingPriority, Azure.ResourceManager.DataProtection.Models.RetentionTag tagInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtection.Models.BackupCriteria> Criteria { get { throw null; } }
        public bool IsDefault { get { throw null; } set { } }
        public long TaggingPriority { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.RetentionTag TagInfo { get { throw null; } set { } }
    }
    public partial class TargetCopySetting
    {
        public TargetCopySetting(Azure.ResourceManager.DataProtection.Models.CopyOption copyAfter, Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase dataStore) { }
        public Azure.ResourceManager.DataProtection.Models.CopyOption CopyAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtection.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
    }
    public partial class TargetDetails
    {
        public TargetDetails(string filePrefix, Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType restoreTargetLocationType, System.Uri uri) { }
        public string FilePrefix { get { throw null; } }
        public Azure.ResourceManager.DataProtection.Models.RestoreTargetLocationType RestoreTargetLocationType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class TriggerBackupContent
    {
        public TriggerBackupContent(Azure.ResourceManager.DataProtection.Models.AdHocBackupRuleOptions backupRuleOptions) { }
        public Azure.ResourceManager.DataProtection.Models.AdHocBackupRuleOptions BackupRuleOptions { get { throw null; } }
    }
    public abstract partial class TriggerContext
    {
        protected TriggerContext() { }
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
    public partial class ValidateForBackupContent
    {
        public ValidateForBackupContent(Azure.ResourceManager.DataProtection.Models.BackupInstance backupInstance) { }
        public Azure.ResourceManager.DataProtection.Models.BackupInstance BackupInstance { get { throw null; } }
    }
    public partial class ValidateRestoreRequestObject
    {
        public ValidateRestoreRequestObject(Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent restoreRequestObject) { }
        public Azure.ResourceManager.DataProtection.Models.AzureBackupRestoreContent RestoreRequestObject { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationType : System.IEquatable<Azure.ResourceManager.DataProtection.Models.ValidationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.ValidationType DeepValidation { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.ValidationType ShallowValidation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.ValidationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.ValidationType left, Azure.ResourceManager.DataProtection.Models.ValidationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.ValidationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.ValidationType left, Azure.ResourceManager.DataProtection.Models.ValidationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekNumber : System.IEquatable<Azure.ResourceManager.DataProtection.Models.WeekNumber>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekNumber(string value) { throw null; }
        public static Azure.ResourceManager.DataProtection.Models.WeekNumber First { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.WeekNumber Fourth { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.WeekNumber Last { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.WeekNumber Second { get { throw null; } }
        public static Azure.ResourceManager.DataProtection.Models.WeekNumber Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtection.Models.WeekNumber other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtection.Models.WeekNumber left, Azure.ResourceManager.DataProtection.Models.WeekNumber right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtection.Models.WeekNumber (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtection.Models.WeekNumber left, Azure.ResourceManager.DataProtection.Models.WeekNumber right) { throw null; }
        public override string ToString() { throw null; }
    }
}
