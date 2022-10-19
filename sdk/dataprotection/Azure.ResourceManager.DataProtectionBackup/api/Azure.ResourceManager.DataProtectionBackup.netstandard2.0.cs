namespace Azure.ResourceManager.DataProtectionBackup
{
    public partial class AzureBackupJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureBackupJobResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureBackupJobResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>, System.Collections.IEnumerable
    {
        protected AzureBackupJobResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureBackupJobResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupJobResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupJob Properties { get { throw null; } set { } }
    }
    public partial class AzureBackupRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureBackupRecoveryPointResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureBackupRecoveryPointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected AzureBackupRecoveryPointResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureBackupRecoveryPointResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupRecoveryPointResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRecoveryPoint Properties { get { throw null; } set { } }
    }
    public partial class BackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo> AdhocBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo>> AdhocBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupFindRestorableTimeRangesResponseResource> FindRestorableTimeRange(Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupFindRestorableTimeRangesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupFindRestorableTimeRangesResponseResource>> FindRestorableTimeRangeAsync(Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupFindRestorableTimeRangesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource> GetAzureBackupRecoveryPointResource(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource>> GetAzureBackupRecoveryPointResourceAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResourceCollection GetAzureBackupRecoveryPointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SuspendBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SyncBackupInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.SyncBackupInstanceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.SyncBackupInstanceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRehydrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRehydrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo> TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo>> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo> ValidateForRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.ValidateRestoreRequestObject validateRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo>> ValidateForRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.ValidateRestoreRequestObject validateRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupInstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>, System.Collections.IEnumerable
    {
        protected BackupInstanceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BackupInstanceResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstance Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class BackupVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupVaultResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.BackupVaultResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource> GetAzureBackupJobResource(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource>> GetAzureBackupJobResourceAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResourceCollection GetAzureBackupJobResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource> GetBackupInstanceResource(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource>> GetBackupInstanceResourceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.BackupInstanceResourceCollection GetBackupInstanceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> GetBaseBackupPolicyResource(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>> GetBaseBackupPolicyResourceAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceCollection GetBaseBackupPolicyResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> GetDeletedBackupInstanceResource(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>> GetDeletedBackupInstanceResourceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResourceCollection GetDeletedBackupInstanceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> GetResourceGuardProxyBaseResource(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> GetResourceGuardProxyBaseResourceAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceCollection GetResourceGuardProxyBaseResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerExportJob(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerExportJobAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo> ValidateForBackupBackupInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.ValidateForBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.OperationJobExtendedInfo>> ValidateForBackupBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.ValidateForBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupVaultResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>, System.Collections.IEnumerable
    {
        protected BackupVaultResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtectionBackup.BackupVaultResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtectionBackup.BackupVaultResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupVaultResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupVaultResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupVault properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVault Properties { get { throw null; } set { } }
    }
    public partial class BaseBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BaseBackupPolicyResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BaseBackupPolicyResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected BaseBackupPolicyResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BaseBackupPolicyResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BaseBackupPolicyResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BaseBackupPolicy Properties { get { throw null; } set { } }
    }
    public static partial class DataProtectionBackupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationResponseBase> CheckFeatureSupportDataProtection(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationRequestBase featureValidationRequestBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationResponseBase>> CheckFeatureSupportDataProtectionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationRequestBase featureValidationRequestBase, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.CheckNameAvailabilityResult> CheckNameAvailabilityBackupVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityBackupVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.AzureBackupJobResource GetAzureBackupJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.AzureBackupRecoveryPointResource GetAzureBackupRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.BackupInstanceResource GetBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.BackupVaultResource GetBackupVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> GetBackupVaultResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource>> GetBackupVaultResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.BackupVaultResourceCollection GetBackupVaultResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> GetBackupVaultResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.BackupVaultResource> GetBackupVaultResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.BaseBackupPolicyResource GetBaseBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource GetDeletedBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource GetResourceGuardDeleteProtectedItemRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource GetResourceGuardDeleteResourceGuardProxyRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource GetResourceGuardDisableSoftDeleteRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource GetResourceGuardGetBackupSecurityPINRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource GetResourceGuardProxyBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource GetResourceGuardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetResourceGuardResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardResourceCollection GetResourceGuardResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource GetResourceGuardUpdateProtectedItemRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource GetResourceGuardUpdateProtectionPolicyRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeletedBackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedBackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Undelete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UndeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedBackupInstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>, System.Collections.IEnumerable
    {
        protected DeletedBackupInstanceResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedBackupInstanceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedBackupInstanceResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DeletedBackupInstance Properties { get { throw null; } set { } }
    }
    public abstract partial class DppBaseResource : Azure.ResourceManager.ArmResource
    {
        protected DppBaseResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DppBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected abstract Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected abstract System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class DppBaseResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal DppBaseResourceData() { }
    }
    public partial class ResourceGuardDeleteProtectedItemRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDeleteProtectedItemRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDeleteProtectedItemRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDeleteProtectedItemRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardDeleteResourceGuardProxyRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDeleteResourceGuardProxyRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDeleteResourceGuardProxyRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDeleteResourceGuardProxyRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardDisableSoftDeleteRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardDisableSoftDeleteRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardDisableSoftDeleteRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardDisableSoftDeleteRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardGetBackupSecurityPINRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardGetBackupSecurityPINRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardGetBackupSecurityPINRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardGetBackupSecurityPINRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardProxyBaseResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string resourceGuardProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.UnlockDeleteResponse> UnlockDelete(Azure.ResourceManager.DataProtectionBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.UnlockDeleteResponse>> UnlockDeleteAsync(Azure.ResourceManager.DataProtectionBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardProxyBaseResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> Get(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> GetAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceGuardProxyBaseResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource> GetResourceGuardDeleteProtectedItemRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestResource>> GetResourceGuardDeleteProtectedItemRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteProtectedItemRequestCollection GetResourceGuardDeleteProtectedItemRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource> GetResourceGuardDeleteResourceGuardProxyRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestResource>> GetResourceGuardDeleteResourceGuardProxyRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardDeleteResourceGuardProxyRequestCollection GetResourceGuardDeleteResourceGuardProxyRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource> GetResourceGuardDisableSoftDeleteRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestResource>> GetResourceGuardDisableSoftDeleteRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardDisableSoftDeleteRequestCollection GetResourceGuardDisableSoftDeleteRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource> GetResourceGuardGetBackupSecurityPINRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestResource>> GetResourceGuardGetBackupSecurityPINRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardGetBackupSecurityPINRequestCollection GetResourceGuardGetBackupSecurityPINRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> GetResourceGuardUpdateProtectedItemRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>> GetResourceGuardUpdateProtectedItemRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestCollection GetResourceGuardUpdateProtectedItemRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> GetResourceGuardUpdateProtectionPolicyRequest(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>> GetResourceGuardUpdateProtectionPolicyRequestAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestCollection GetResourceGuardUpdateProtectionPolicyRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Update(Azure.ResourceManager.DataProtectionBackup.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> UpdateAsync(Azure.ResourceManager.DataProtectionBackup.Models.PatchResourceRequestInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Get(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGuardResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuard Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardUpdateProtectedItemRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardUpdateProtectedItemRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardUpdateProtectedItemRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardUpdateProtectedItemRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectedItemRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardUpdateProtectionPolicyRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardUpdateProtectionPolicyRequestCollection() { }
        public virtual Azure.Response<bool> Exists(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> Get(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>> GetAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardUpdateProtectionPolicyRequestResource : Azure.ResourceManager.DataProtectionBackup.DppBaseResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardUpdateProtectionPolicyRequestResource() { }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName, string requestName) { throw null; }
        public new Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardUpdateProtectionPolicyRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource> GetCore(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DppBaseResource>> GetCoreAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class AbsoluteDeleteOption : Azure.ResourceManager.DataProtectionBackup.Models.DeleteOption
    {
        public AbsoluteDeleteOption(System.TimeSpan duration) : base (default(System.TimeSpan)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AbsoluteMarker : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AbsoluteMarker(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker AllBackup { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker FirstOfDay { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker FirstOfMonth { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker FirstOfWeek { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker FirstOfYear { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker left, Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker left, Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdHocBackupRuleOptions
    {
        public AdHocBackupRuleOptions(string ruleName, Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerOption triggerOption) { }
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
        public Azure.ResourceManager.DataProtectionBackup.Models.RetentionTag TagInfo { get { throw null; } set { } }
    }
    public partial class AdhocBasedTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.TriggerContext
    {
        public AdhocBasedTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedTaggingCriteria taggingCriteria) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RetentionTag TaggingCriteriaTagInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.AlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.AlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.AlertsState left, Azure.ResourceManager.DataProtectionBackup.Models.AlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.AlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.AlertsState left, Azure.ResourceManager.DataProtectionBackup.Models.AlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AuthCredentials
    {
        protected AuthCredentials() { }
    }
    public partial class AzureBackupDiscreteRecoveryPoint : Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRecoveryPoint
    {
        public AzureBackupDiscreteRecoveryPoint(System.DateTimeOffset recoveryPointOn) { }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetails> RecoveryPointDataStoresDetails { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
        public System.DateTimeOffset RecoveryPointOn { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string RetentionTagName { get { throw null; } set { } }
        public string RetentionTagVersion { get { throw null; } set { } }
    }
    public partial class AzureBackupFindRestorableTimeRangesContent
    {
        public AzureBackupFindRestorableTimeRangesContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType sourceDataStoreType) { }
        public string EndTime { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType SourceDataStoreType { get { throw null; } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class AzureBackupFindRestorableTimeRangesResponse
    {
        public AzureBackupFindRestorableTimeRangesResponse() { }
        public string ObjectType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange> RestorableTimeRanges { get { throw null; } }
    }
    public partial class AzureBackupFindRestorableTimeRangesResponseResource : Azure.ResourceManager.Models.ResourceData
    {
        public AzureBackupFindRestorableTimeRangesResponseResource() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupFindRestorableTimeRangesResponse Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.DataProtectionBackup.Models.JobExtendedInfo ExtendedInfo { get { throw null; } }
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
    public partial class AzureBackupParams : Azure.ResourceManager.DataProtectionBackup.Models.BackupParameters
    {
        public AzureBackupParams(string backupType) { }
        public string BackupType { get { throw null; } set { } }
    }
    public abstract partial class AzureBackupRecoveryPoint
    {
        protected AzureBackupRecoveryPoint() { }
    }
    public partial class AzureBackupRecoveryPointBasedRestoreRequest : Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent
    {
        public AzureBackupRecoveryPointBasedRestoreRequest(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public string RecoveryPointId { get { throw null; } }
    }
    public partial class AzureBackupRecoveryTimeBasedRestoreRequest : Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent
    {
        public AzureBackupRecoveryTimeBasedRestoreRequest(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointTime) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public string RecoveryPointTime { get { throw null; } }
    }
    public partial class AzureBackupRehydrationContent
    {
        public AzureBackupRehydrationContent(string recoveryPointId, System.TimeSpan rehydrationRetentionDuration) { }
        public string RecoveryPointId { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    public abstract partial class AzureBackupRestoreContent
    {
        protected AzureBackupRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase RestoreTargetInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType SourceDataStoreType { get { throw null; } }
        public string SourceResourceId { get { throw null; } set { } }
    }
    public partial class AzureBackupRestoreWithRehydrationRequest : Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRecoveryPointBasedRestoreRequest
    {
        public AzureBackupRestoreWithRehydrationRequest(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId, Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority rehydrationPriority, System.TimeSpan rehydrationRetentionDuration) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority RehydrationPriority { get { throw null; } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    public partial class AzureBackupRule : Azure.ResourceManager.DataProtectionBackup.Models.BasePolicyRule
    {
        public AzureBackupRule(string name, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore, Azure.ResourceManager.DataProtectionBackup.Models.TriggerContext trigger) : base (default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupParameters BackupParameters { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.TriggerContext Trigger { get { throw null; } set { } }
    }
    public partial class AzureOperationalStoreParameters : Azure.ResourceManager.DataProtectionBackup.Models.DataStoreParameters
    {
        public AzureOperationalStoreParameters(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType)) { }
        public string ResourceGroupId { get { throw null; } set { } }
    }
    public partial class AzureRetentionRule : Azure.ResourceManager.DataProtectionBackup.Models.BasePolicyRule
    {
        public AzureRetentionRule(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> lifecycles) : base (default(string)) { }
        public bool? IsDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> Lifecycles { get { throw null; } }
    }
    public abstract partial class BackupCriteria
    {
        protected BackupCriteria() { }
    }
    public partial class BackupInstance
    {
        public BackupInstance(Azure.ResourceManager.DataProtectionBackup.Models.Datasource dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.PolicyInfo policyInfo, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? CurrentProtectionState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.Datasource DataSourceInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DatasourceSet DataSourceSetInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.PolicyInfo PolicyInfo { get { throw null; } set { } }
        public Azure.ResponseError ProtectionErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ProtectionStatusDetails ProtectionStatus { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ValidationType? ValidationType { get { throw null; } set { } }
    }
    public abstract partial class BackupParameters
    {
        protected BackupParameters() { }
    }
    public partial class BackupPolicy : Azure.ResourceManager.DataProtectionBackup.Models.BaseBackupPolicy
    {
        public BackupPolicy(System.Collections.Generic.IEnumerable<string> datasourceTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.BasePolicyRule> policyRules) : base (default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BasePolicyRule> PolicyRules { get { throw null; } }
    }
    public partial class BackupSchedule
    {
        public BackupSchedule(System.Collections.Generic.IEnumerable<string> repeatingTimeIntervals) { }
        public System.Collections.Generic.IList<string> RepeatingTimeIntervals { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class BackupVault
    {
        public BackupVault(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.StorageSetting> storageSettings) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public bool? IsVaultProtectedByResourceGuard { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState? ResourceMoveState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.StorageSetting> StorageSettings { get { throw null; } }
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
    public partial class CopyOnExpiryOption : Azure.ResourceManager.DataProtectionBackup.Models.CopyOption
    {
        public CopyOnExpiryOption() { }
    }
    public abstract partial class CopyOption
    {
        protected CopyOption() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CurrentProtectionState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CurrentProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState BackupSchedulesSuspended { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState ConfiguringProtection { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState ConfiguringProtectionFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState NotProtected { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState ProtectionConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState ProtectionStopped { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState RetentionSchedulesSuspended { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState UpdatingProtection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState left, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState left, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomCopyOption : Azure.ResourceManager.DataProtectionBackup.Models.CopyOption
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
        public DataStoreInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType DataStoreType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
    }
    public abstract partial class DataStoreParameters
    {
        protected DataStoreParameters(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType DataStoreType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType OperationalStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Day
    {
        public Day() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeek : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek left, Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek left, Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeletedBackupInstance : Azure.ResourceManager.DataProtectionBackup.Models.BackupInstance
    {
        public DeletedBackupInstance(Azure.ResourceManager.DataProtectionBackup.Models.Datasource dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.PolicyInfo policyInfo, string objectType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.Datasource), default(Azure.ResourceManager.DataProtectionBackup.Models.PolicyInfo), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DeletionInfo DeletionInfo { get { throw null; } }
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
    public readonly partial struct FeatureSupportStatus : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureSupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus AlphaPreview { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus PrivatePreview { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus PublicPreview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus left, Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus left, Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.FeatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureType DataSourceType { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.FeatureType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.FeatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.FeatureType left, Azure.ResourceManager.DataProtectionBackup.Models.FeatureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.FeatureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.FeatureType left, Azure.ResourceManager.DataProtectionBackup.Models.FeatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureValidationRequest : Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationRequestBase
    {
        public FeatureValidationRequest() { }
        public string FeatureName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.FeatureType? FeatureType { get { throw null; } set { } }
    }
    public abstract partial class FeatureValidationRequestBase
    {
        protected FeatureValidationRequestBase() { }
    }
    public partial class FeatureValidationResponse : Azure.ResourceManager.DataProtectionBackup.Models.FeatureValidationResponseBase
    {
        internal FeatureValidationResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.SupportedFeature> Features { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.FeatureType? FeatureType { get { throw null; } }
    }
    public abstract partial class FeatureValidationResponseBase
    {
        protected FeatureValidationResponseBase() { }
    }
    public partial class ImmediateCopyOption : Azure.ResourceManager.DataProtectionBackup.Models.CopyOption
    {
        public ImmediateCopyOption() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState Locked { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState left, Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState left, Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ItemLevelRestoreCriteria
    {
        protected ItemLevelRestoreCriteria() { }
    }
    public partial class ItemLevelRestoreTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase
    {
        public ItemLevelRestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption recoveryOption, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> restoreCriteria, Azure.ResourceManager.DataProtectionBackup.Models.Datasource datasourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.Datasource DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DatasourceSet DatasourceSetInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> RestoreCriteria { get { throw null; } }
    }
    public partial class JobExtendedInfo
    {
        internal JobExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string BackupInstanceState { get { throw null; } }
        public double? DataTransferredInBytes { get { throw null; } }
        public string RecoveryDestination { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails SourceRecoverPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.JobSubTask> SubTasks { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails TargetRecoverPoint { get { throw null; } }
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
    public partial class KubernetesPVRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public KubernetesPVRestoreCriteria() { }
        public string Name { get { throw null; } set { } }
        public string StorageClassName { get { throw null; } set { } }
    }
    public partial class KubernetesStorageClassRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public KubernetesStorageClassRestoreCriteria() { }
        public string Provisioner { get { throw null; } set { } }
        public string SelectedStorageClassName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Month : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.Month>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Month(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month April { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month August { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month December { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month February { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month January { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month July { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month June { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month March { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month May { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month November { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month October { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Month September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.Month other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.Month left, Azure.ResourceManager.DataProtectionBackup.Models.Month right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.Month (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.Month left, Azure.ResourceManager.DataProtectionBackup.Models.Month right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class OperationExtendedInfo
    {
        protected OperationExtendedInfo() { }
    }
    public partial class OperationJobExtendedInfo : Azure.ResourceManager.DataProtectionBackup.Models.OperationExtendedInfo
    {
        internal OperationJobExtendedInfo() { }
        public string JobId { get { throw null; } }
    }
    public partial class PatchBackupVaultInput
    {
        public PatchBackupVaultInput() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecuritySettings SecuritySettings { get { throw null; } set { } }
    }
    public partial class PatchResourceRequestInput
    {
        public PatchResourceRequestInput() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.PatchBackupVaultInput Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PolicyInfo
    {
        public PolicyInfo(string policyId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreParameters> DataStoreParametersList { get { throw null; } }
        public string PolicyId { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } }
    }
    public partial class ProtectionStatusDetails
    {
        internal ProtectionStatusDetails() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.Status? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangeBasedItemLevelRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public RangeBasedItemLevelRestoreCriteria() { }
        public string MaxMatchingValue { get { throw null; } set { } }
        public string MinMatchingValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryOption : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryOption(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption FailIfExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption left, Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption left, Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption right) { throw null; }
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
        public Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus? RehydrationStatus { get { throw null; } }
        public string State { get { throw null; } set { } }
        public bool? Visible { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationPriority : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationPriority(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority High { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority left, Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority left, Azure.ResourceManager.DataProtectionBackup.Models.RehydrationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationStatus : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus CreateINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus DeleteINProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus left, Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus left, Azure.ResourceManager.DataProtectionBackup.Models.RehydrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuard
    {
        public ResourceGuard() { }
        public bool? AllowAutoApprovals { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperation> ResourceGuardOperations { get { throw null; } }
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
    public readonly partial struct ResourceGuardProvisioningState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceGuardProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuardProxyBase
    {
        public ResourceGuardProxyBase() { }
        public string Description { get { throw null; } set { } }
        public string LastUpdatedTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
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
    public readonly partial struct ResourceMoveState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState CommitTimedout { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState CriticalFailure { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState MoveSucceeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState PartialSuccess { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState PrepareTimedout { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState left, Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState left, Azure.ResourceManager.DataProtectionBackup.Models.ResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorableTimeRange
    {
        public RestorableTimeRange(string startTime, string endTime) { }
        public string EndTime { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class RestoreFilesTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase
    {
        public RestoreFilesTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption recoveryOption, Azure.ResourceManager.DataProtectionBackup.Models.TargetDetails targetDetails) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.TargetDetails TargetDetails { get { throw null; } }
    }
    public partial class RestoreJobRecoveryPointDetails
    {
        internal RestoreJobRecoveryPointDetails() { }
        public string RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreSourceDataStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreSourceDataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType OperationalStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase
    {
        public RestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption recoveryOption, Azure.ResourceManager.DataProtectionBackup.Models.Datasource datasourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.Datasource DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DatasourceSet DatasourceSetInfo { get { throw null; } set { } }
    }
    public abstract partial class RestoreTargetInfoBase
    {
        protected RestoreTargetInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption recoveryOption) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RecoveryOption RecoveryOption { get { throw null; } }
        public string RestoreLocation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreTargetLocationType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreTargetLocationType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType AzureBlobs { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType left, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType left, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionTag
    {
        public RetentionTag(string tagName) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } set { } }
    }
    public partial class ScheduleBasedBackupCriteria : Azure.ResourceManager.DataProtectionBackup.Models.BackupCriteria
    {
        public ScheduleBasedBackupCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.AbsoluteMarker> AbsoluteCriteria { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.Day> DaysOfMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DayOfWeek> DaysOfTheWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.Month> MonthsOfYear { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleTimes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber> WeeksOfTheMonth { get { throw null; } }
    }
    public partial class ScheduleBasedTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.TriggerContext
    {
        public ScheduleBasedTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.BackupSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.TaggingCriteria> taggingCriteria) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.TaggingCriteria> TaggingCriteria { get { throw null; } }
    }
    public partial class SecretStoreBasedAuthCredentials : Azure.ResourceManager.DataProtectionBackup.Models.AuthCredentials
    {
        public SecretStoreBasedAuthCredentials() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResource SecretStoreResource { get { throw null; } set { } }
    }
    public partial class SecretStoreResource
    {
        public SecretStoreResource(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType secretStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType SecretStoreType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecuritySettings
    {
        public SecuritySettings() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
    }
    public partial class SoftDeleteSettings
    {
        public SoftDeleteSettings() { }
        public double? RetentionDurationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftDeleteState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftDeleteState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState AlwaysOn { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState Off { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState left, Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState left, Azure.ResourceManager.DataProtectionBackup.Models.SoftDeleteState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceDataStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceDataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType SnapshotStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceLifeCycle
    {
        public SourceLifeCycle(Azure.ResourceManager.DataProtectionBackup.Models.DeleteOption deleteAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase sourceDataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DeleteOption DeleteAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase SourceDataStore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting> TargetDataStoreCopySettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status ConfiguringProtection { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status ConfiguringProtectionFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status ProtectionConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status ProtectionStopped { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.Status SoftDeleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.Status left, Azure.ResourceManager.DataProtectionBackup.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.Status left, Azure.ResourceManager.DataProtectionBackup.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageSetting
    {
        public StorageSetting() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType? DatastoreType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType? SettingType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSettingStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSettingStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType SnapshotStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType VaultStore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType left, Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSettingType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSettingType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType left, Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType left, Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedFeature
    {
        internal SupportedFeature() { }
        public System.Collections.Generic.IReadOnlyList<string> ExposureControlledFeatures { get { throw null; } }
        public string FeatureName { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus? SupportStatus { get { throw null; } }
    }
    public partial class SyncBackupInstanceContent
    {
        public SyncBackupInstanceContent() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SyncType? SyncType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.SyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SyncType Default { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SyncType ForceResync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.SyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.SyncType left, Azure.ResourceManager.DataProtectionBackup.Models.SyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.SyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.SyncType left, Azure.ResourceManager.DataProtectionBackup.Models.SyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TaggingCriteria
    {
        public TaggingCriteria(bool isDefault, long taggingPriority, Azure.ResourceManager.DataProtectionBackup.Models.RetentionTag tagInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BackupCriteria> Criteria { get { throw null; } }
        public bool IsDefault { get { throw null; } set { } }
        public long TaggingPriority { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RetentionTag TagInfo { get { throw null; } set { } }
    }
    public partial class TargetCopySetting
    {
        public TargetCopySetting(Azure.ResourceManager.DataProtectionBackup.Models.CopyOption copyAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CopyOption CopyAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
    }
    public partial class TargetDetails
    {
        public TargetDetails(string filePrefix, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType restoreTargetLocationType, System.Uri uri) { }
        public string FilePrefix { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType RestoreTargetLocationType { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class TriggerBackupContent
    {
        public TriggerBackupContent(Azure.ResourceManager.DataProtectionBackup.Models.AdHocBackupRuleOptions backupRuleOptions) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AdHocBackupRuleOptions BackupRuleOptions { get { throw null; } }
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
        public ValidateForBackupContent(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstance backupInstance) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstance BackupInstance { get { throw null; } }
    }
    public partial class ValidateRestoreRequestObject
    {
        public ValidateRestoreRequestObject(Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent restoreRequestObject) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureBackupRestoreContent RestoreRequestObject { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.ValidationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ValidationType DeepValidation { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ValidationType ShallowValidation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.ValidationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.ValidationType left, Azure.ResourceManager.DataProtectionBackup.Models.ValidationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.ValidationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.ValidationType left, Azure.ResourceManager.DataProtectionBackup.Models.ValidationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekNumber : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekNumber(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber First { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber Fourth { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber Last { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber Second { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber left, Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber left, Azure.ResourceManager.DataProtectionBackup.Models.WeekNumber right) { throw null; }
        public override string ToString() { throw null; }
    }
}
