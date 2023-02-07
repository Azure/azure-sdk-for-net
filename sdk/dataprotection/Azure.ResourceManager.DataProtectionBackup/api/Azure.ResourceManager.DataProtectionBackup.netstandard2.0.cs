namespace Azure.ResourceManager.DataProtectionBackup
{
    public static partial class DataProtectionBackupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase> CheckDataProtectionBackupFeatureSupport(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>> CheckDataProtectionBackupFeatureSupportAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult> CheckDataProtectionBackupVaultNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>> CheckDataProtectionBackupVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource GetDataProtectionBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource GetDataProtectionBackupJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource GetDataProtectionBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource GetDataProtectionBackupRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> GetDataProtectionBackupVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource GetDataProtectionBackupVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultCollection GetDataProtectionBackupVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource GetDeletedDataProtectionBackupInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuard(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetResourceGuardAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource GetResourceGuardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardCollection GetResourceGuards(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuards(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProtectionBackupInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>, System.Collections.IEnumerable
    {
        protected DataProtectionBackupInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupInstanceName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        public DataProtectionBackupInstanceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataProtectionBackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProtectionBackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult> FindRestorableTimeRange(Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>> FindRestorableTimeRangeAsync(Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetDataProtectionBackupRecoveryPoint(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>> GetDataProtectionBackupRecoveryPointAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointCollection GetDataProtectionBackupRecoveryPoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumeProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopProtection(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopProtectionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SuspendBackups(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendBackupsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SyncBackupInstance(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> TriggerAdhocBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> TriggerAdhocBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRehydration(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRehydrationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> ValidateRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> ValidateRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProtectionBackupJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>, System.Collections.IEnumerable
    {
        protected DataProtectionBackupJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupJobData : Azure.ResourceManager.Models.ResourceData
    {
        public DataProtectionBackupJobData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties Properties { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProtectionBackupJobResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProtectionBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected DataProtectionBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DataProtectionBackupPolicyData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase Properties { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProtectionBackupPolicyResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProtectionBackupRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected DataProtectionBackupRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupRecoveryPointData : Azure.ResourceManager.Models.ResourceData
    {
        public DataProtectionBackupRecoveryPointData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties Properties { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProtectionBackupRecoveryPointResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProtectionBackupVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>, System.Collections.IEnumerable
    {
        protected DataProtectionBackupVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupVaultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataProtectionBackupVaultData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties Properties { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProtectionBackupVaultResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> GetDataProtectionBackupInstance(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> GetDataProtectionBackupInstanceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceCollection GetDataProtectionBackupInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetDataProtectionBackupJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetDataProtectionBackupJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobCollection GetDataProtectionBackupJobs() { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyCollection GetDataProtectionBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> GetDataProtectionBackupPolicy(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> GetDataProtectionBackupPolicyAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> GetDeletedDataProtectionBackupInstance(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>> GetDeletedDataProtectionBackupInstanceAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceCollection GetDeletedDataProtectionBackupInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerExportJob(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerExportJobAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use Update(WaitUntil waitUntil, DataProtectionBackupVaultPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use UpdateAsync(WaitUntil waitUntil, DataProtectionBackupVaultPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> ValidateAdhocBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> ValidateAdhocBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedDataProtectionBackupInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>, System.Collections.IEnumerable
    {
        protected DeletedDataProtectionBackupInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> Get(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>> GetAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedDataProtectionBackupInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedDataProtectionBackupInstanceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class DeletedDataProtectionBackupInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedDataProtectionBackupInstanceResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Undelete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UndeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardsName, Azure.ResourceManager.DataProtectionBackup.ResourceGuardData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourceGuardData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGuardData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceGuardResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardResource() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceGuardsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetBackupSecurityPinObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetBackupSecurityPinObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetBackupSecurityPinObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetBackupSecurityPinObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteProtectedItemObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetDeleteProtectedItemObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteProtectedItemObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteProtectedItemObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteResourceGuardProxyObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetDeleteResourceGuardProxyObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteResourceGuardProxyObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDeleteResourceGuardProxyObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDisableSoftDeleteObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetDisableSoftDeleteObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDisableSoftDeleteObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetDisableSoftDeleteObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectedItemObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetUpdateProtectedItemObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectedItemObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectedItemObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectionPolicyObject(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>> GetUpdateProtectionPolicyObjectAsync(string requestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectionPolicyObjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData> GetUpdateProtectionPolicyObjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use Update(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Update(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> Update(Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use UpdateAsync(ResourceGuardPatch patch, CancellationToken cancellationToken = default) instead.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> UpdateAsync(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> UpdateAsync(Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class AdhocBackupRules
    {
        public AdhocBackupRules(string ruleName, string backupTriggerRetentionTagOverride) { }
        public string BackupTriggerRetentionTagOverride { get { throw null; } }
        public string RuleName { get { throw null; } }
    }
    public partial class AdhocBackupTriggerContent
    {
        public AdhocBackupTriggerContent(Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules backupRules) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules BackupRules { get { throw null; } }
    }
    public partial class AdhocBackupValidateContent
    {
        public AdhocBackupValidateContent(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties backupInstance) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties BackupInstance { get { throw null; } }
    }
    public partial class AdhocBasedBackupTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext
    {
        public AdhocBasedBackupTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag adhocBackupRetentionTagInfo) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag AdhocBackupRetentionTagInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureMonitorAlertsState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureMonitorAlertsState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState left, Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState left, Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupAbsoluteMarker : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupAbsoluteMarker(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker AllBackup { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker FirstOfDay { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker FirstOfMonth { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker FirstOfWeek { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker FirstOfYear { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker left, Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker left, Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BackupDataSourceSettings
    {
        protected BackupDataSourceSettings() { }
    }
    public partial class BackupFeatureValidationContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase
    {
        public BackupFeatureValidationContent() { }
        public string FeatureName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType? FeatureType { get { throw null; } set { } }
    }
    public abstract partial class BackupFeatureValidationContentBase
    {
        protected BackupFeatureValidationContentBase() { }
    }
    public partial class BackupFeatureValidationResult : Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase
    {
        internal BackupFeatureValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature> Features { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType? FeatureType { get { throw null; } }
    }
    public abstract partial class BackupFeatureValidationResultBase
    {
        protected BackupFeatureValidationResultBase() { }
    }
    public partial class BackupFindRestorableTimeRangeContent
    {
        public BackupFindRestorableTimeRangeContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType sourceDataStoreType) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType SourceDataStoreType { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class BackupFindRestorableTimeRangeResult : Azure.ResourceManager.Models.ResourceData
    {
        public BackupFindRestorableTimeRangeResult() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties Properties { get { throw null; } set { } }
    }
    public partial class BackupFindRestorableTimeRangeResultProperties
    {
        public BackupFindRestorableTimeRangeResultProperties() { }
        public string ObjectType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange> RestorableTimeRanges { get { throw null; } }
    }
    public partial class BackupInstanceDeletionInfo
    {
        internal BackupInstanceDeletionInfo() { }
        public System.DateTimeOffset? BillingEndOn { get { throw null; } }
        public string DeleteActivityId { get { throw null; } }
        public System.DateTimeOffset? DeleteOn { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
    }
    public partial class BackupInstancePolicyInfo
    {
        public BackupInstancePolicyInfo(Azure.Core.ResourceIdentifier policyId) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DataStoreParametersList is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings> DataStoreParametersList { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings PolicyParameters { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } }
    }
    public partial class BackupInstancePolicySettings
    {
        public BackupInstancePolicySettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings> BackupDataSourceParametersList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings> DataStoreParametersList { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupInstanceProtectionStatus : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupInstanceProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus ConfiguringProtection { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus ConfiguringProtectionFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus ProtectionConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus ProtectionStopped { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus SoftDeleting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus left, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus left, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupInstanceProtectionStatusDetails
    {
        internal BackupInstanceProtectionStatusDetails() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus? Status { get { throw null; } }
    }
    public partial class BackupInstanceSyncContent
    {
        public BackupInstanceSyncContent() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType? SyncType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupInstanceSyncType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupInstanceSyncType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType Default { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType ForceResync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupJobExtendedInfo
    {
        internal BackupJobExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string BackupInstanceState { get { throw null; } }
        public double? DataTransferredInBytes { get { throw null; } }
        public string RecoveryDestination { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails SourceRecoverPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask> SubTasks { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails TargetRecoverPoint { get { throw null; } }
    }
    public partial class BackupJobSubTask
    {
        internal BackupJobSubTask() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public int TaskId { get { throw null; } }
        public string TaskName { get { throw null; } }
        public string TaskProgress { get { throw null; } }
        public string TaskStatus { get { throw null; } }
    }
    public partial class BackupRecoveryPointBasedRestoreContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent
    {
        public BackupRecoveryPointBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public string RecoveryPointId { get { throw null; } }
    }
    public partial class BackupRecoveryTimeBasedRestoreContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent
    {
        public BackupRecoveryTimeBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, System.DateTimeOffset recoverOn) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public System.DateTimeOffset RecoverOn { get { throw null; } }
    }
    public partial class BackupRehydrationContent
    {
        public BackupRehydrationContent(string recoveryPointId, System.TimeSpan rehydrationRetentionDuration) { }
        public string RecoveryPointId { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupRehydrationPriority : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupRehydrationPriority(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority High { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority left, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority left, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BackupRestoreContent
    {
        protected BackupRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase RestoreTargetInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType SourceDataStoreType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
    }
    public partial class BackupRestoreWithRehydrationContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent
    {
        public BackupRestoreWithRehydrationContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority rehydrationPriority, System.TimeSpan rehydrationRetentionDuration) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority RehydrationPriority { get { throw null; } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
    }
    public partial class BackupSupportedFeature
    {
        internal BackupSupportedFeature() { }
        public System.Collections.Generic.IReadOnlyList<string> ExposureControlledFeatures { get { throw null; } }
        public string FeatureName { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus? SupportStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupSupportedFeatureType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupSupportedFeatureType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType DataSourceType { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupValidateRestoreContent
    {
        public BackupValidateRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent restoreRequestObject) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent RestoreRequestObject { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupValidationType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupValidationType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType DeepValidation { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType ShallowValidation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType left, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupVaultImmutabilityState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupVaultImmutabilityState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState Locked { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupVaultResourceMoveDetails
    {
        internal BackupVaultResourceMoveDetails() { }
        public System.DateTimeOffset? CompleteOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string SourceResourcePath { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TargetResourcePath { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupVaultResourceMoveState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupVaultResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState CommitTimedOut { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState CriticalFailure { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState MoveSucceeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState PartialSuccess { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState PrepareTimedOut { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupVaultSecuritySettings
    {
        public BackupVaultSecuritySettings() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
    }
    public partial class BackupVaultSoftDeleteSettings
    {
        public BackupVaultSoftDeleteSettings() { }
        public double? RetentionDurationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupVaultSoftDeleteState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupVaultSoftDeleteState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState AlwaysOn { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState Off { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobBackupDataSourceSettings : Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings
    {
        public BlobBackupDataSourceSettings(System.Collections.Generic.IEnumerable<string> containersList) { }
        public System.Collections.Generic.IList<string> ContainersList { get { throw null; } }
    }
    public partial class CopyOnExpirySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting
    {
        public CopyOnExpirySetting() { }
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
    public partial class CustomCopySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting
    {
        public CustomCopySetting() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupAbsoluteDeleteSetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting
    {
        public DataProtectionBackupAbsoluteDeleteSetting(System.TimeSpan duration) : base (default(System.TimeSpan)) { }
    }
    public abstract partial class DataProtectionBackupAuthCredentials
    {
        protected DataProtectionBackupAuthCredentials() { }
    }
    public abstract partial class DataProtectionBackupCopySetting
    {
        protected DataProtectionBackupCopySetting() { }
    }
    public abstract partial class DataProtectionBackupCriteria
    {
        protected DataProtectionBackupCriteria() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupCrossSubscriptionRestoreState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupCrossSubscriptionRestoreState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState Enabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState PermanentlyDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProtectionBackupDay
    {
        public DataProtectionBackupDay() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupDayOfWeek : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataProtectionBackupDeleteSetting
    {
        protected DataProtectionBackupDeleteSetting(System.TimeSpan duration) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupDiscreteRecoveryPointProperties : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties
    {
        public DataProtectionBackupDiscreteRecoveryPointProperties(System.DateTimeOffset recoverOn) { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } set { } }
        public System.DateTimeOffset RecoverOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail> RecoveryPointDataStoresDetails { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string RetentionTagName { get { throw null; } set { } }
        public string RetentionTagVersion { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupInstanceProperties
    {
        public DataProtectionBackupInstanceProperties(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? CurrentProtectionState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DataSourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DataSourceInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DataSourceSetInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo PolicyInfo { get { throw null; } set { } }
        public Azure.ResponseError ProtectionErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails ProtectionStatus { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? ValidationType { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupJobProperties
    {
        public DataProtectionBackupJobProperties(string activityId, string backupInstanceFriendlyName, Azure.Core.ResourceIdentifier dataSourceId, Azure.Core.AzureLocation dataSourceLocation, string dataSourceName, string dataSourceType, bool isUserTriggered, string operation, string operationCategory, bool isProgressEnabled, string sourceResourceGroup, string sourceSubscriptionId, System.DateTimeOffset startOn, string status, string subscriptionId, System.Collections.Generic.IEnumerable<string> supportedActions, string vaultName) { }
        public string ActivityId { get { throw null; } set { } }
        public string BackupInstanceFriendlyName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BackupInstanceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataSourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation DataSourceLocation { get { throw null; } set { } }
        public string DataSourceName { get { throw null; } set { } }
        public string DataSourceSetName { get { throw null; } set { } }
        public string DataSourceType { get { throw null; } set { } }
        public string DestinationDataStoreName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public bool IsProgressEnabled { get { throw null; } set { } }
        public bool IsUserTriggered { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public string OperationCategory { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public string PolicyName { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupMonth : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupMonth(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth April { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth August { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth December { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth February { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth January { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth July { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth June { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth March { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth May { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth November { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth October { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProtectionBackupNameAvailabilityContent
    {
        public DataProtectionBackupNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupNameAvailabilityResult
    {
        internal DataProtectionBackupNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("DataProtectionBackupPatch is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
    public partial class DataProtectionBackupPatch
    {
        public DataProtectionBackupPatch() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? AlertSettingsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public abstract partial class DataProtectionBackupPolicyPropertiesBase
    {
        protected DataProtectionBackupPolicyPropertiesBase(System.Collections.Generic.IEnumerable<string> dataSourceTypes) { }
        public System.Collections.Generic.IList<string> DataSourceTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupProvisioningState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataProtectionBackupRecoveryPointProperties
    {
        protected DataProtectionBackupRecoveryPointProperties() { }
    }
    public partial class DataProtectionBackupRetentionTag
    {
        public DataProtectionBackupRetentionTag(string tagName) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupRule : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule
    {
        public DataProtectionBackupRule(string name, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext trigger) : base (default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase BackupParameters { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext Trigger { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupSchedule
    {
        public DataProtectionBackupSchedule(System.Collections.Generic.IEnumerable<string> repeatingTimeIntervals) { }
        public System.Collections.Generic.IList<string> RepeatingTimeIntervals { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupSettings : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase
    {
        public DataProtectionBackupSettings(string backupType) { }
        public string BackupType { get { throw null; } set { } }
    }
    public abstract partial class DataProtectionBackupSettingsBase
    {
        protected DataProtectionBackupSettingsBase() { }
    }
    public partial class DataProtectionBackupStorageSetting
    {
        public DataProtectionBackupStorageSetting() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType? DataStoreType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType? StorageSettingType { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupTaggingCriteria
    {
        public DataProtectionBackupTaggingCriteria(bool isDefault, long taggingPriority, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag tagInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria> Criteria { get { throw null; } }
        public bool IsDefault { get { throw null; } set { } }
        public long TaggingPriority { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag TagInfo { get { throw null; } set { } }
    }
    public abstract partial class DataProtectionBackupTriggerContext
    {
        protected DataProtectionBackupTriggerContext() { }
    }
    public partial class DataProtectionBackupVaultPatch
    {
        public DataProtectionBackupVaultPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataProtectionBackupVaultPatchProperties
    {
        public DataProtectionBackupVaultPatchProperties() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? AlertSettingsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings SecuritySettings { get { throw null; } set { } }
    }
    public partial class DataProtectionBackupVaultProperties
    {
        public DataProtectionBackupVaultProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> storageSettings) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? AlertSettingsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        public bool? IsVaultProtectedByResourceGuard { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState? ResourceMoveState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> StorageSettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupWeekNumber : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupWeekNumber(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber First { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber Fourth { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber Last { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber Second { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataProtectionBasePolicyRule
    {
        protected DataProtectionBasePolicyRule(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class DataProtectionOperationExtendedInfo
    {
        protected DataProtectionOperationExtendedInfo() { }
    }
    public partial class DataProtectionOperationJobExtendedInfo : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo
    {
        internal DataProtectionOperationJobExtendedInfo() { }
        public System.Guid? JobId { get { throw null; } }
    }
    public partial class DataProtectionRetentionRule : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule
    {
        public DataProtectionRetentionRule(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> lifecycles) : base (default(string)) { }
        public bool? IsDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> Lifecycles { get { throw null; } }
    }
    public partial class DataSourceInfo
    {
        public DataSourceInfo(Azure.Core.ResourceIdentifier resourceId) { }
        public string DataSourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class DataSourceSetInfo
    {
        public DataSourceSetInfo(Azure.Core.ResourceIdentifier resourceId) { }
        public string DataSourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
    }
    public partial class DataStoreInfoBase
    {
        public DataStoreInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType DataStoreType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
    }
    public abstract partial class DataStoreSettings
    {
        protected DataStoreSettings(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) { }
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
    public partial class DeletedDataProtectionBackupInstanceProperties : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties
    {
        public DeletedDataProtectionBackupInstanceProperties(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo, string objectType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo), default(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo DeletionInfo { get { throw null; } }
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
    public partial class ImmediateCopySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting
    {
        public ImmediateCopySetting() { }
    }
    public abstract partial class ItemLevelRestoreCriteria
    {
        protected ItemLevelRestoreCriteria() { }
    }
    public partial class ItemLevelRestoreTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase
    {
        public ItemLevelRestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> restoreCriteria, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo datasourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DatasourceSetInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> RestoreCriteria { get { throw null; } }
    }
    public partial class ItemPathBasedRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public ItemPathBasedRestoreCriteria(string itemPath, bool isPathRelativeToBackupItem) { }
        public bool IsPathRelativeToBackupItem { get { throw null; } }
        public string ItemPath { get { throw null; } }
        public System.Collections.Generic.IList<string> SubItemPathPrefix { get { throw null; } }
    }
    public partial class KubernetesClusterBackupDataSourceSettings : Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings
    {
        public KubernetesClusterBackupDataSourceSettings(bool isSnapshotVolumesEnabled, bool isClusterScopeResourcesIncluded) { }
        public System.Collections.Generic.IList<string> ExcludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedResourceTypes { get { throw null; } }
        public bool IsClusterScopeResourcesIncluded { get { throw null; } set { } }
        public bool IsSnapshotVolumesEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LabelSelectors { get { throw null; } }
    }
    public partial class KubernetesClusterRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public KubernetesClusterRestoreCriteria(bool isClusterScopeResourcesIncluded) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy? ConflictPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedResourceTypes { get { throw null; } }
        public bool IsClusterScopeResourcesIncluded { get { throw null; } }
        public System.Collections.Generic.IList<string> LabelSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> NamespaceMappings { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode? PersistentVolumeRestoreMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterRestoreExistingResourcePolicy : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterRestoreExistingResourcePolicy(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy Patch { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy Skip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy left, Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy left, Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class OperationalDataStoreSettings : Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings
    {
        public OperationalDataStoreSettings(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType)) { }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentVolumeRestoreMode : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentVolumeRestoreMode(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode RestoreWithoutVolumeData { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode RestoreWithVolumeData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode left, Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode left, Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RangeBasedItemLevelRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria
    {
        public RangeBasedItemLevelRestoreCriteria() { }
        public string MaxMatchingValue { get { throw null; } set { } }
        public string MinMatchingValue { get { throw null; } set { } }
    }
    public partial class RecoveryPointDataStoreDetail
    {
        public RecoveryPointDataStoreDetail() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsVisible { get { throw null; } set { } }
        public string Metadata { get { throw null; } set { } }
        public System.Guid? RecoveryPointDataStoreId { get { throw null; } set { } }
        public string RecoveryPointDataStoreType { get { throw null; } set { } }
        public System.DateTimeOffset? RehydrationExpireOn { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus? RehydrationStatus { get { throw null; } }
        public string State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPointDataStoreRehydrationStatus : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPointDataStoreRehydrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus CreateInProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus DeleteInProgress { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus left, Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus left, Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoverySetting : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoverySetting(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting FailIfExists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting left, Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting left, Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuardOperationDetails
    {
        internal ResourceGuardOperationDetails() { }
        public Azure.Core.ResourceType? RequestResourceType { get { throw null; } }
        public string VaultCriticalOperation { get { throw null; } }
    }
    public partial class ResourceGuardPatch
    {
        public ResourceGuardPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourceGuardProperties
    {
        public ResourceGuardProperties() { }
        public string Description { get { throw null; } }
        public bool? IsAutoApprovalsAllowed { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails> ResourceGuardOperations { get { throw null; } }
        public System.Collections.Generic.IList<string> VaultCriticalOperationExclusionList { get { throw null; } }
    }
    public partial class ResourceGuardProtectedObjectData : Azure.ResourceManager.Models.ResourceData
    {
        internal ResourceGuardProtectedObjectData() { }
    }
    public partial class RestorableTimeRange
    {
        public RestorableTimeRange(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
    }
    public partial class RestoreFilesTargetDetails
    {
        public RestoreFilesTargetDetails(string filePrefix, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType restoreTargetLocationType, System.Uri uri) { }
        public string FilePrefix { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType RestoreTargetLocationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceArmId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class RestoreFilesTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase
    {
        public RestoreFilesTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails targetDetails) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails TargetDetails { get { throw null; } }
    }
    public partial class RestoreJobRecoveryPointDetails
    {
        internal RestoreJobRecoveryPointDetails() { }
        public System.DateTimeOffset? RecoverOn { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
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
        public RestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DataSourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DataSourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DataSourceSetInfo { get { throw null; } set { } }
    }
    public abstract partial class RestoreTargetInfoBase
    {
        protected RestoreTargetInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting RecoverySetting { get { throw null; } }
        public Azure.Core.AzureLocation? RestoreLocation { get { throw null; } set { } }
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
    public partial class RuleBasedBackupPolicy : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase
    {
        public RuleBasedBackupPolicy(System.Collections.Generic.IEnumerable<string> dataSourceTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule> policyRules) : base (default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule> PolicyRules { get { throw null; } }
    }
    public partial class ScheduleBasedBackupCriteria : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria
    {
        public ScheduleBasedBackupCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker> AbsoluteCriteria { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay> DaysOfMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek> DaysOfWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth> MonthsOfYear { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleTimes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber> WeeksOfMonth { get { throw null; } }
    }
    public partial class ScheduleBasedBackupTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext
    {
        public ScheduleBasedBackupTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria> taggingCriteriaList) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria> TaggingCriteriaList { get { throw null; } }
    }
    public partial class SecretStoreBasedAuthCredentials : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials
    {
        public SecretStoreBasedAuthCredentials() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo SecretStoreResource { get { throw null; } set { } }
    }
    public partial class SecretStoreResourceInfo
    {
        public SecretStoreResourceInfo(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType secretStoreType) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceDataStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceDataStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType OperationalStore { get { throw null; } }
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
        public SourceLifeCycle(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting deleteAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase sourceDataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting DeleteAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase SourceDataStore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting> TargetDataStoreCopySettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSettingStoreType : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSettingStoreType(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType ArchiveStore { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType OperationalStore { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
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
    public partial class TargetCopySetting
    {
        public TargetCopySetting(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting copyAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting CopyAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
    }
}
