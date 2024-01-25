namespace Azure.ResourceManager.DataProtectionBackup
{
    public static partial class DataProtectionBackupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase> CheckDataProtectionBackupFeatureSupport(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>> CheckDataProtectionBackupFeatureSupportAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult> CheckDataProtectionBackupVaultNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>> CheckDataProtectionBackupVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetCrossRegionRestoreJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent content, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJobsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent content, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource GetResourceGuardProxyBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource GetResourceGuardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardCollection GetResourceGuards(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuards(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetSecondaryRecoveryPoints(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent content, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetSecondaryRecoveryPointsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent content, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> TriggerCrossRegionRestoreBackupInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject crossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> TriggerCrossRegionRestoreBackupInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject crossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> ValidateCrossRegionRestoreBackupInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject validateCrossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> ValidateCrossRegionRestoreBackupInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject validateCrossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> GetIfExists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>> GetIfExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>
    {
        public DataProtectionBackupInstanceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetIfExists(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetIfExistsAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>
    {
        public DataProtectionBackupJobData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> GetIfExists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>> GetIfExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>
    {
        public DataProtectionBackupPolicyData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetIfExists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>> GetIfExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupRecoveryPointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>
    {
        public DataProtectionBackupRecoveryPointData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProtectionBackupVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>
    {
        public DataProtectionBackupVaultData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> GetResourceGuardProxyBaseResource(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> GetResourceGuardProxyBaseResourceAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceCollection GetResourceGuardProxyBaseResources() { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> GetIfExists(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>> GetIfExistsAsync(string backupInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedDataProtectionBackupInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>
    {
        public DeletedDataProtectionBackupInstanceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetIfExists(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetIfExistsAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>
    {
        public ResourceGuardData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.ResourceGuardData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.ResourceGuardData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult> UnlockDelete(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>> UnlockDeleteAsync(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> GetIfExists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>> GetIfExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyBaseResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>
    {
        public ResourceGuardProxyBaseResourceData() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.DataProtectionBackup.Mocking
{
    public partial class MockableDataProtectionBackupArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataProtectionBackupArmClient() { }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceResource GetDataProtectionBackupInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource GetDataProtectionBackupJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyResource GetDataProtectionBackupPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource GetDataProtectionBackupRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource GetDataProtectionBackupVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceResource GetDeletedDataProtectionBackupInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResource GetResourceGuardProxyBaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource GetResourceGuardResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataProtectionBackupResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataProtectionBackupResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult> CheckDataProtectionBackupVaultNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>> CheckDataProtectionBackupVaultNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJob(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource>> GetCrossRegionRestoreJobAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJobs(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent content, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobResource> GetCrossRegionRestoreJobsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent content, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVault(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource>> GetDataProtectionBackupVaultAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultCollection GetDataProtectionBackupVaults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuard(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource>> GetResourceGuardAsync(string resourceGuardsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataProtectionBackup.ResourceGuardCollection GetResourceGuards() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetSecondaryRecoveryPoints(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent content, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointResource> GetSecondaryRecoveryPointsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent content, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> TriggerCrossRegionRestoreBackupInstance(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject crossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> TriggerCrossRegionRestoreBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject crossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo> ValidateCrossRegionRestoreBackupInstance(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject validateCrossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>> ValidateCrossRegionRestoreBackupInstanceAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject validateCrossRegionRestoreRequestObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDataProtectionBackupSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataProtectionBackupSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase> CheckDataProtectionBackupFeatureSupport(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>> CheckDataProtectionBackupFeatureSupportAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultResource> GetDataProtectionBackupVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuards(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataProtectionBackup.ResourceGuardResource> GetResourceGuardsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class AdhocBackupRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>
    {
        public AdhocBackupRules(string ruleName, string backupTriggerRetentionTagOverride) { }
        public string BackupTriggerRetentionTagOverride { get { throw null; } }
        public string RuleName { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdhocBackupTriggerContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>
    {
        public AdhocBackupTriggerContent(Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules backupRules) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupRules BackupRules { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupTriggerContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdhocBackupValidateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>
    {
        public AdhocBackupValidateContent(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties backupInstance) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties BackupInstance { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBackupValidateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdhocBasedBackupTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>
    {
        public AdhocBasedBackupTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag adhocBackupRetentionTagInfo) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag AdhocBackupRetentionTagInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.AdhocBasedBackupTriggerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDataProtectionBackupModelFactory
    {
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult BackupFeatureValidationResult(Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType? featureType = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature> features = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent BackupFindRestorableTimeRangeContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType sourceDataStoreType = default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult BackupFindRestorableTimeRangeResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo BackupInstanceDeletionInfo(System.DateTimeOffset? deleteOn = default(System.DateTimeOffset?), System.DateTimeOffset? billingEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), string deleteActivityId = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo BackupInstancePolicyInfo(Azure.Core.ResourceIdentifier policyId = null, string policyVersion = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings policyParameters = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails BackupInstanceProtectionStatusDetails(Azure.ResponseError errorDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus? status = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo BackupJobExtendedInfo(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalDetails = null, string backupInstanceState = null, double? dataTransferredInBytes = default(double?), string recoveryDestination = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails sourceRecoverPoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask> subTasks = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails targetRecoverPoint = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo BackupJobExtendedInfo(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalDetails = null, string backupInstanceState = null, double? dataTransferredInBytes = default(double?), string recoveryDestination = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails sourceRecoverPoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask> subTasks = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails targetRecoverPoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail> warningDetails = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask BackupJobSubTask(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalDetails = null, int taskId = 0, string taskName = null, string taskProgress = null, string taskStatus = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent BackupRecoveryPointBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType = default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null, string recoveryPointId = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent BackupRecoveryTimeBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType = default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null, System.DateTimeOffset recoverOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent BackupRehydrationContent(string recoveryPointId = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority? rehydrationPriority = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority?), System.TimeSpan rehydrationRetentionDuration = default(System.TimeSpan)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent BackupRestoreContent(string objectType = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType = default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent BackupRestoreWithRehydrationContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType = default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null, string recoveryPointId = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority rehydrationPriority = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority), System.TimeSpan rehydrationRetentionDuration = default(System.TimeSpan)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature BackupSupportedFeature(string featureName = null, Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus? supportStatus = default(Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus?), System.Collections.Generic.IEnumerable<string> exposureControlledFeatures = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails BackupVaultResourceMoveDetails(string operationId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completeOn = default(System.DateTimeOffset?), string sourceResourcePath = null, string targetResourcePath = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties DataProtectionBackupDiscreteRecoveryPointProperties(string friendlyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail> recoveryPointDataStoresDetails = null, System.DateTimeOffset recoverOn = default(System.DateTimeOffset), string policyName = null, string policyVersion = null, string recoveryPointId = null, string recoveryPointType = null, string retentionTagName = null, string retentionTagVersion = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties DataProtectionBackupDiscreteRecoveryPointProperties(string friendlyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail> recoveryPointDataStoresDetails = null, System.DateTimeOffset recoverOn = default(System.DateTimeOffset), string policyName = null, string policyVersion = null, string recoveryPointId = null, string recoveryPointType = null, string retentionTagName = null, string retentionTagVersion = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState? recoveryPointState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupInstanceData DataProtectionBackupInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties DataProtectionBackupInstanceProperties(string friendlyName = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo dataSourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails protectionStatus = null, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? currentProtectionState = default(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState?), Azure.ResponseError protectionErrorDetails = null, string provisioningState = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials dataSourceAuthCredentials = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? validationType = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties DataProtectionBackupInstanceProperties(string friendlyName = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo dataSourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails protectionStatus = null, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? currentProtectionState = default(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState?), Azure.ResponseError protectionErrorDetails = null, string provisioningState = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials dataSourceAuthCredentials = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? validationType = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType?), string objectType = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupJobData DataProtectionBackupJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties DataProtectionBackupJobProperties(string activityId = null, string backupInstanceFriendlyName = null, Azure.Core.ResourceIdentifier backupInstanceId = null, Azure.Core.ResourceIdentifier dataSourceId = null, Azure.Core.AzureLocation dataSourceLocation = default(Azure.Core.AzureLocation), string dataSourceName = null, string dataSourceSetName = null, string dataSourceType = null, System.TimeSpan? duration = default(System.TimeSpan?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo extendedInfo = null, bool isUserTriggered = false, string operation = null, string operationCategory = null, Azure.Core.ResourceIdentifier policyId = null, string policyName = null, bool isProgressEnabled = false, System.Uri progressUri = null, string restoreType = null, string sourceResourceGroup = null, string sourceSubscriptionId = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string status = null, string subscriptionId = null, System.Collections.Generic.IEnumerable<string> supportedActions = null, string vaultName = null, Azure.ETag? eTag = default(Azure.ETag?), string sourceDataStoreName = null, string destinationDataStoreName = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties DataProtectionBackupJobProperties(string activityId = null, string backupInstanceFriendlyName = null, Azure.Core.ResourceIdentifier backupInstanceId = null, Azure.Core.ResourceIdentifier dataSourceId = null, Azure.Core.AzureLocation dataSourceLocation = default(Azure.Core.AzureLocation), string dataSourceName = null, string dataSourceSetName = null, string dataSourceType = null, System.TimeSpan? duration = default(System.TimeSpan?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo extendedInfo = null, bool isUserTriggered = false, string operation = null, string operationCategory = null, Azure.Core.ResourceIdentifier policyId = null, string policyName = null, bool isProgressEnabled = false, System.Uri progressUri = null, string rehydrationPriority = null, string restoreType = null, string sourceResourceGroup = null, string sourceSubscriptionId = null, System.DateTimeOffset startOn = default(System.DateTimeOffset), string status = null, string subscriptionId = null, System.Collections.Generic.IEnumerable<string> supportedActions = null, string vaultName = null, Azure.ETag? eTag = default(Azure.ETag?), string sourceDataStoreName = null, string destinationDataStoreName = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult DataProtectionBackupNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupPolicyData DataProtectionBackupPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupRecoveryPointData DataProtectionBackupRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag DataProtectionBackupRetentionTag(Azure.ETag? eTag = default(Azure.ETag?), string id = null, string tagName = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DataProtectionBackupVaultData DataProtectionBackupVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties DataProtectionBackupVaultProperties(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? alertSettingsForAllJobFailures = default(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? provisioningState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState? resourceMoveState = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails resourceMoveDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings securitySettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> storageSettings = null, bool? isVaultProtectedByResourceGuard = default(bool?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings featureSettings = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel? secureScore = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties DataProtectionBackupVaultProperties(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? alertSettingsForAllJobFailures = default(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? provisioningState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState? resourceMoveState = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails resourceMoveDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings securitySettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> storageSettings = null, bool? isVaultProtectedByResourceGuard = default(bool?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings featureSettings = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel? secureScore = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel?), System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> replicatedRegions = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties DataProtectionBackupVaultProperties(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? alertSettingsForAllJobFailures = default(Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? provisioningState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState? resourceMoveState = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState?), Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails resourceMoveDetails = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings securitySettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> storageSettings = null, bool? isVaultProtectedByResourceGuard = default(bool?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? crossSubscriptionRestoreState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo DataProtectionOperationJobExtendedInfo(Azure.Core.ResourceIdentifier jobResourceId = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo DataProtectionOperationJobExtendedInfo(string jobIdentifier = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult DataProtectionUnlockDeleteResult(string unlockDeleteExpiryTime = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.DeletedDataProtectionBackupInstanceData DeletedDataProtectionBackupInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties DeletedDataProtectionBackupInstanceProperties(string friendlyName = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo dataSourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails protectionStatus = null, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? currentProtectionState = default(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState?), Azure.ResponseError protectionErrorDetails = null, string provisioningState = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials dataSourceAuthCredentials = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? validationType = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType?), Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails identityDetails = null, string objectType = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo deletionInfo = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties DeletedDataProtectionBackupInstanceProperties(string friendlyName = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo dataSourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails protectionStatus = null, Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? currentProtectionState = default(Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState?), Azure.ResponseError protectionErrorDetails = null, string provisioningState = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials dataSourceAuthCredentials = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? validationType = default(Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType?), string objectType = null, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo deletionInfo = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo ItemLevelRestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting = default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting), Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> restoreCriteria = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo datasourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo datasourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials datasourceAuthCredentials = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria ItemPathBasedRestoreCriteria(string itemPath = null, bool isPathRelativeToBackupItem = false, System.Collections.Generic.IEnumerable<string> subItemPathPrefix = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria KubernetesClusterRestoreCriteria(bool isClusterScopeResourcesIncluded = false, System.Collections.Generic.IEnumerable<string> includedNamespaces = null, System.Collections.Generic.IEnumerable<string> excludedNamespaces = null, System.Collections.Generic.IEnumerable<string> includedResourceTypes = null, System.Collections.Generic.IEnumerable<string> excludedResourceTypes = null, System.Collections.Generic.IEnumerable<string> labelSelectors = null, Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode? persistentVolumeRestoreMode = default(Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode?), Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy? conflictPolicy = default(Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy?), System.Collections.Generic.IDictionary<string, string> namespaceMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName> restoreHookReferences = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria KubernetesClusterVaultTierRestoreCriteria(bool includeClusterScopeResources = false, System.Collections.Generic.IEnumerable<string> includedNamespaces = null, System.Collections.Generic.IEnumerable<string> excludedNamespaces = null, System.Collections.Generic.IEnumerable<string> includedResourceTypes = null, System.Collections.Generic.IEnumerable<string> excludedResourceTypes = null, System.Collections.Generic.IEnumerable<string> labelSelectors = null, Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode? persistentVolumeRestoreMode = default(Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode?), Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy? conflictPolicy = default(Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy?), System.Collections.Generic.IDictionary<string, string> namespaceMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName> restoreHookReferences = null, Azure.Core.ResourceIdentifier stagingResourceGroupId = null, Azure.Core.ResourceIdentifier stagingStorageAccountId = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail RecoveryPointDataStoreDetail(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.Guid? recoveryPointDataStoreId = default(System.Guid?), string metadata = null, string state = null, string recoveryPointDataStoreType = null, bool? isVisible = default(bool?), System.DateTimeOffset? rehydrationExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus? rehydrationStatus = default(Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreRehydrationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardData ResourceGuardData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails ResourceGuardOperationDetails(string vaultCriticalOperation = null, Azure.Core.ResourceType? requestResourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties ResourceGuardProperties(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? provisioningState = default(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState?), bool? isAutoApprovalsAllowed = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails> resourceGuardOperations = null, System.Collections.Generic.IEnumerable<string> vaultCriticalOperationExclusionList = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData ResourceGuardProtectedObjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.ResourceGuardProxyBaseResourceData ResourceGuardProxyBaseResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase properties = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails RestoreFilesTargetDetails(string filePrefix = null, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType restoreTargetLocationType = default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType), System.Uri uri = null, Azure.Core.ResourceIdentifier targetResourceArmId = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo RestoreFilesTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting = default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting), Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails targetDetails = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails RestoreJobRecoveryPointDetails(string recoveryPointId = null, System.DateTimeOffset? recoverOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo RestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting = default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting), Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo dataSourceSetInfo = null, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials dataSourceAuthCredentials = null) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase RestoreTargetInfoBase(string objectType = null, Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting = default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting), Azure.Core.AzureLocation? restoreLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail UserFacingWarningDetail(string resourceName = null, Azure.ResponseError warning = null) { throw null; }
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
    public abstract partial class BackupDataSourceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>
    {
        protected BackupDataSourceSettings() { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFeatureValidationContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>
    {
        public BackupFeatureValidationContent() { }
        public string FeatureName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType? FeatureType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupFeatureValidationContentBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>
    {
        protected BackupFeatureValidationContentBase() { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationContentBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFeatureValidationResult : Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>
    {
        internal BackupFeatureValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature> Features { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeatureType? FeatureType { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupFeatureValidationResultBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>
    {
        protected BackupFeatureValidationResultBase() { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFeatureValidationResultBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFindRestorableTimeRangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>
    {
        public BackupFindRestorableTimeRangeContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType sourceDataStoreType) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreSourceDataStoreType SourceDataStoreType { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFindRestorableTimeRangeResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>
    {
        public BackupFindRestorableTimeRangeResult() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupFindRestorableTimeRangeResultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>
    {
        public BackupFindRestorableTimeRangeResultProperties() { }
        public string ObjectType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange> RestorableTimeRanges { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupFindRestorableTimeRangeResultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupInstanceDeletionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>
    {
        internal BackupInstanceDeletionInfo() { }
        public System.DateTimeOffset? BillingEndOn { get { throw null; } }
        public string DeleteActivityId { get { throw null; } }
        public System.DateTimeOffset? DeleteOn { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupInstancePolicyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>
    {
        public BackupInstancePolicyInfo(Azure.Core.ResourceIdentifier policyId) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DataStoreParametersList is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings> DataStoreParametersList { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings PolicyParameters { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupInstancePolicySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>
    {
        public BackupInstancePolicySettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings> BackupDataSourceParametersList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings> DataStoreParametersList { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupInstanceProtectionStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>
    {
        internal BackupInstanceProtectionStatusDetails() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatus? Status { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupInstanceSyncContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>
    {
        public BackupInstanceSyncContent() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncType? SyncType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceSyncContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>
    {
        internal BackupJobExtendedInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public string BackupInstanceState { get { throw null; } }
        public double? DataTransferredInBytes { get { throw null; } }
        public string RecoveryDestination { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails SourceRecoverPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask> SubTasks { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails TargetRecoverPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail> WarningDetails { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupJobSubTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>
    {
        internal BackupJobSubTask() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalDetails { get { throw null; } }
        public int TaskId { get { throw null; } }
        public string TaskName { get { throw null; } }
        public string TaskProgress { get { throw null; } }
        public string TaskStatus { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupJobSubTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRecoveryPointBasedRestoreContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>
    {
        public BackupRecoveryPointBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public string RecoveryPointId { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRecoveryTimeBasedRestoreContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>
    {
        public BackupRecoveryTimeBasedRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, System.DateTimeOffset recoverOn) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType)) { }
        public System.DateTimeOffset RecoverOn { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryTimeBasedRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRehydrationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>
    {
        public BackupRehydrationContent(string recoveryPointId, System.TimeSpan rehydrationRetentionDuration) { }
        public string RecoveryPointId { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class BackupRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>
    {
        protected BackupRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails IdentityDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase RestoreTargetInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType SourceDataStoreType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRestoreWithRehydrationContent : Azure.ResourceManager.DataProtectionBackup.Models.BackupRecoveryPointBasedRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>
    {
        public BackupRestoreWithRehydrationContent(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase restoreTargetInfo, Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType sourceDataStoreType, string recoveryPointId, Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority rehydrationPriority, System.TimeSpan rehydrationRetentionDuration) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase), default(Azure.ResourceManager.DataProtectionBackup.Models.SourceDataStoreType), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRehydrationPriority RehydrationPriority { get { throw null; } }
        public System.TimeSpan RehydrationRetentionDuration { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreWithRehydrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupSupportedFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>
    {
        internal BackupSupportedFeature() { }
        public System.Collections.Generic.IReadOnlyList<string> ExposureControlledFeatures { get { throw null; } }
        public string FeatureName { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.FeatureSupportStatus? SupportStatus { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupSupportedFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupValidateRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>
    {
        public BackupValidateRestoreContent(Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent restoreRequestObject) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent RestoreRequestObject { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupValidateRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupVaultFeatureSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>
    {
        public BackupVaultFeatureSettings() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState? CrossRegionRestoreState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupVaultResourceMoveDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>
    {
        internal BackupVaultResourceMoveDetails() { }
        public System.DateTimeOffset? CompleteOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string SourceResourcePath { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TargetResourcePath { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupVaultSecureScoreLevel : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupVaultSecureScoreLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel Adequate { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel Maximum { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel Minimum { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel None { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel NotSupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel left, Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupVaultSecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>
    {
        public BackupVaultSecuritySettings() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings SoftDeleteSettings { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupVaultSoftDeleteSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>
    {
        public BackupVaultSoftDeleteSettings() { }
        public double? RetentionDurationInDays { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteState? State { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSoftDeleteSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class BaseResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>
    {
        protected BaseResourceProperties() { }
        Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobBackupDataSourceSettings : Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>
    {
        public BlobBackupDataSourceSettings(System.Collections.Generic.IEnumerable<string> containersList) { }
        public System.Collections.Generic.IList<string> ContainersList { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.BlobBackupDataSourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyOnExpirySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>
    {
        public CopyOnExpirySetting() { }
        Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CopyOnExpirySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CrossRegionRestoreDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>
    {
        public CrossRegionRestoreDetails(Azure.Core.AzureLocation sourceRegion, Azure.Core.ResourceIdentifier sourceBackupInstanceId) { }
        public Azure.Core.ResourceIdentifier SourceBackupInstanceId { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CrossRegionRestoreJobContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>
    {
        public CrossRegionRestoreJobContent(Azure.Core.AzureLocation sourceRegion, Azure.Core.ResourceIdentifier sourceBackupVaultId, System.Guid jobId) { }
        public System.Guid JobId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceBackupVaultId { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CrossRegionRestoreJobsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>
    {
        public CrossRegionRestoreJobsContent(Azure.Core.AzureLocation sourceRegion, Azure.Core.ResourceIdentifier sourceBackupVaultId) { }
        public Azure.Core.ResourceIdentifier SourceBackupVaultId { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreJobsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CrossRegionRestoreRequestObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>
    {
        public CrossRegionRestoreRequestObject(Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent restoreRequestObject, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails crossRegionRestoreDetails) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails CrossRegionRestoreDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent RestoreRequestObject { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreRequestObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CrossRegionRestoreState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CrossRegionRestoreState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState left, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState left, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CustomCopySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>
    {
        public CustomCopySetting() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.CustomCopySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupAbsoluteDeleteSetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>
    {
        public DataProtectionBackupAbsoluteDeleteSetting(System.TimeSpan duration) : base (default(System.TimeSpan)) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAbsoluteDeleteSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionBackupAuthCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>
    {
        protected DataProtectionBackupAuthCredentials() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionBackupCopySetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>
    {
        protected DataProtectionBackupCopySetting() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionBackupCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>
    {
        protected DataProtectionBackupCriteria() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataProtectionBackupDay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>
    {
        public DataProtectionBackupDay() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class DataProtectionBackupDeleteSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>
    {
        protected DataProtectionBackupDeleteSetting(System.TimeSpan duration) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupDiscreteRecoveryPointProperties : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>
    {
        public DataProtectionBackupDiscreteRecoveryPointProperties(System.DateTimeOffset recoverOn) { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } set { } }
        public System.DateTimeOffset RecoverOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail> RecoveryPointDataStoresDetails { get { throw null; } }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState? RecoveryPointState { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string RetentionTagName { get { throw null; } set { } }
        public string RetentionTagVersion { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDiscreteRecoveryPointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>
    {
        public DataProtectionBackupInstanceProperties(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CurrentProtectionState? CurrentProtectionState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DataSourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DataSourceInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DataSourceSetInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails IdentityDetails { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo PolicyInfo { get { throw null; } set { } }
        public Azure.ResponseError ProtectionErrorDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceProtectionStatusDetails ProtectionStatus { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupValidationType? ValidationType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>
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
        public string RehydrationPriority { get { throw null; } }
        public string RestoreType { get { throw null; } }
        public string SourceDataStoreName { get { throw null; } set { } }
        public string SourceResourceGroup { get { throw null; } set { } }
        public string SourceSubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedActions { get { throw null; } }
        public string VaultName { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataProtectionBackupNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>
    {
        public DataProtectionBackupNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>
    {
        internal DataProtectionBackupNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class DataProtectionBackupPolicyPropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>
    {
        protected DataProtectionBackupPolicyPropertiesBase(System.Collections.Generic.IEnumerable<string> dataSourceTypes) { }
        public System.Collections.Generic.IList<string> DataSourceTypes { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProtectionBackupRecoveryPointCompletionState : System.IEquatable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProtectionBackupRecoveryPointCompletionState(string value) { throw null; }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState Completed { get { throw null; } }
        public static Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState Partial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState left, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointCompletionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataProtectionBackupRecoveryPointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>
    {
        protected DataProtectionBackupRecoveryPointProperties() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRecoveryPointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupRetentionTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>
    {
        public DataProtectionBackupRetentionTag(string tagName) { }
        public Azure.ETag? ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupRule : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>
    {
        public DataProtectionBackupRule(string name, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext trigger) : base (default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase BackupParameters { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext Trigger { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>
    {
        public DataProtectionBackupSchedule(System.Collections.Generic.IEnumerable<string> repeatingTimeIntervals) { }
        public System.Collections.Generic.IList<string> RepeatingTimeIntervals { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupSettings : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>
    {
        public DataProtectionBackupSettings(string backupType) { }
        public string BackupType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionBackupSettingsBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>
    {
        protected DataProtectionBackupSettingsBase() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSettingsBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupStorageSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>
    {
        public DataProtectionBackupStorageSetting() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingStoreType? DataStoreType { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.StorageSettingType? StorageSettingType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupTaggingCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>
    {
        public DataProtectionBackupTaggingCriteria(bool isDefault, long taggingPriority, Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag tagInfo) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria> Criteria { get { throw null; } }
        public bool IsDefault { get { throw null; } set { } }
        public long TaggingPriority { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupRetentionTag TagInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionBackupTriggerContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>
    {
        protected DataProtectionBackupTriggerContext() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupVaultPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>
    {
        public DataProtectionBackupVaultPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupVaultPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>
    {
        public DataProtectionBackupVaultPatchProperties() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? AlertSettingsForAllJobFailures { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings FeatureSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings SecuritySettings { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionBackupVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>
    {
        public DataProtectionBackupVaultProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> storageSettings) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.AzureMonitorAlertsState? AlertSettingsForAllJobFailures { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCrossSubscriptionRestoreState? CrossSubscriptionRestoreState { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultFeatureSettings FeatureSettings { get { throw null; } set { } }
        public bool? IsVaultProtectedByResourceGuard { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReplicatedRegions { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultResourceMoveState? ResourceMoveState { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecureScoreLevel? SecureScore { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupVaultSecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupStorageSetting> StorageSettings { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class DataProtectionBasePolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>
    {
        protected DataProtectionBasePolicyRule(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionIdentityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>
    {
        public DataProtectionIdentityDetails() { }
        public System.Uri UserAssignedIdentityArmUri { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionIdentityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataProtectionOperationExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>
    {
        protected DataProtectionOperationExtendedInfo() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionOperationJobExtendedInfo : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationExtendedInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>
    {
        internal DataProtectionOperationJobExtendedInfo() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public System.Guid? JobId { get { throw null; } }
        public string JobIdentifier { get { throw null; } }
        public string JobName { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobResourceId { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionOperationJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionRetentionRule : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>
    {
        public DataProtectionRetentionRule(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> lifecycles) : base (default(string)) { }
        public bool? IsDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle> Lifecycles { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionRetentionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionUnlockDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>
    {
        public DataProtectionUnlockDeleteContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public string ResourceToBeDeleted { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProtectionUnlockDeleteResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>
    {
        internal DataProtectionUnlockDeleteResult() { }
        public string UnlockDeleteExpiryTime { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionUnlockDeleteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataSourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>
    {
        public DataSourceInfo(Azure.Core.ResourceIdentifier resourceId) { }
        public string DataSourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties ResourceProperties { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string ResourceUriString { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataSourceSetInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>
    {
        public DataSourceSetInfo(Azure.Core.ResourceIdentifier resourceId) { }
        public string DataSourceType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties ResourceProperties { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property has been replaced by ResourceUriString", false)]
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string ResourceUriString { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataStoreInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>
    {
        public DataStoreInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType, string objectType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType DataStoreType { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataStoreSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>
    {
        protected DataStoreSettings(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType DataStoreType { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DefaultResourceProperties : Azure.ResourceManager.DataProtectionBackup.Models.BaseResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>
    {
        public DefaultResourceProperties() { }
        Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DefaultResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedDataProtectionBackupInstanceProperties : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupInstanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>
    {
        public DeletedDataProtectionBackupInstanceProperties(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo, Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo policyInfo, string objectType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo), default(Azure.ResourceManager.DataProtectionBackup.Models.BackupInstancePolicyInfo), default(string)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupInstanceDeletionInfo DeletionInfo { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.DeletedDataProtectionBackupInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FetchSecondaryRPsRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>
    {
        public FetchSecondaryRPsRequestContent() { }
        public Azure.Core.ResourceIdentifier SourceBackupInstanceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? SourceRegion { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.FetchSecondaryRPsRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImmediateCopySetting : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>
    {
        public ImmediateCopySetting() { }
        Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ImmediateCopySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ItemLevelRestoreCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>
    {
        protected ItemLevelRestoreCriteria() { }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemLevelRestoreTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>
    {
        public ItemLevelRestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> restoreCriteria, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo datasourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DatasourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DatasourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DatasourceSetInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria> RestoreCriteria { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemPathBasedRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>
    {
        public ItemPathBasedRestoreCriteria(string itemPath, bool isPathRelativeToBackupItem) { }
        public bool IsPathRelativeToBackupItem { get { throw null; } }
        public string ItemPath { get { throw null; } }
        public System.Collections.Generic.IList<string> SubItemPathPrefix { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ItemPathBasedRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterBackupDataSourceSettings : Azure.ResourceManager.DataProtectionBackup.Models.BackupDataSourceSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>
    {
        public KubernetesClusterBackupDataSourceSettings(bool isSnapshotVolumesEnabled, bool isClusterScopeResourcesIncluded) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName> BackupHookReferences { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedResourceTypes { get { throw null; } }
        public bool IsClusterScopeResourcesIncluded { get { throw null; } set { } }
        public bool IsSnapshotVolumesEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LabelSelectors { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterBackupDataSourceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>
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
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName> RestoreHookReferences { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class KubernetesClusterVaultTierRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>
    {
        public KubernetesClusterVaultTierRestoreCriteria(bool includeClusterScopeResources) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterRestoreExistingResourcePolicy? ConflictPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedResourceTypes { get { throw null; } }
        public bool IncludeClusterScopeResources { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedNamespaces { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedResourceTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> LabelSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> NamespaceMappings { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.PersistentVolumeRestoreMode? PersistentVolumeRestoreMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName> RestoreHookReferences { get { throw null; } }
        public Azure.Core.ResourceIdentifier StagingResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StagingStorageAccountId { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesClusterVaultTierRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesPVRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>
    {
        public KubernetesPVRestoreCriteria() { }
        public string Name { get { throw null; } set { } }
        public string StorageClassName { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesPVRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesStorageClassRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>
    {
        public KubernetesStorageClassRestoreCriteria() { }
        public string Provisioner { get { throw null; } set { } }
        public string SelectedStorageClassName { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.KubernetesStorageClassRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespacedName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>
    {
        public NamespacedName() { }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.NamespacedName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationalDataStoreSettings : Azure.ResourceManager.DataProtectionBackup.Models.DataStoreSettings, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>
    {
        public OperationalDataStoreSettings(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType dataStoreType) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.DataStoreType)) { }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.OperationalDataStoreSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RangeBasedItemLevelRestoreCriteria : Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>
    {
        public RangeBasedItemLevelRestoreCriteria() { }
        public string MaxMatchingValue { get { throw null; } set { } }
        public string MinMatchingValue { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RangeBasedItemLevelRestoreCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointDataStoreDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>
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
        Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RecoveryPointDataStoreDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceGuardOperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>
    {
        public ResourceGuardOperationDetail() { }
        public string DefaultResourceRequest { get { throw null; } set { } }
        public string VaultCriticalOperation { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardOperationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>
    {
        internal ResourceGuardOperationDetails() { }
        public Azure.Core.ResourceType? RequestResourceType { get { throw null; } }
        public string VaultCriticalOperation { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>
    {
        public ResourceGuardPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>
    {
        public ResourceGuardProperties() { }
        public string Description { get { throw null; } }
        public bool? IsAutoApprovalsAllowed { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetails> ResourceGuardOperations { get { throw null; } }
        public System.Collections.Generic.IList<string> VaultCriticalOperationExclusionList { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardProtectedObjectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>
    {
        internal ResourceGuardProtectedObjectData() { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProtectedObjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardProxyBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>
    {
        public ResourceGuardProxyBase() { }
        public string Description { get { throw null; } set { } }
        public string LastUpdatedTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
        public string ResourceGuardResourceId { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ResourceGuardProxyBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorableTimeRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>
    {
        public RestorableTimeRange(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public string ObjectType { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestorableTimeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreFilesTargetDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>
    {
        public RestoreFilesTargetDetails(string filePrefix, Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType restoreTargetLocationType, System.Uri uri) { }
        public string FilePrefix { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetLocationType RestoreTargetLocationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceArmId { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreFilesTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>
    {
        public RestoreFilesTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails targetDetails) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetDetails TargetDetails { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreJobRecoveryPointDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>
    {
        internal RestoreJobRecoveryPointDetails() { }
        public System.DateTimeOffset? RecoverOn { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreJobRecoveryPointDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RestoreTargetInfo : Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>
    {
        public RestoreTargetInfo(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting, Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo dataSourceInfo) : base (default(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting)) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials DataSourceAuthCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceInfo DataSourceInfo { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataSourceSetInfo DataSourceSetInfo { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RestoreTargetInfoBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>
    {
        protected RestoreTargetInfoBase(Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting recoverySetting) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.RecoverySetting RecoverySetting { get { throw null; } }
        public Azure.Core.AzureLocation? RestoreLocation { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RuleBasedBackupPolicy : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupPolicyPropertiesBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>
    {
        public RuleBasedBackupPolicy(System.Collections.Generic.IEnumerable<string> dataSourceTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule> policyRules) : base (default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBasePolicyRule> PolicyRules { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.RuleBasedBackupPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleBasedBackupCriteria : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCriteria, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>
    {
        public ScheduleBasedBackupCriteria() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.BackupAbsoluteMarker> AbsoluteCriteria { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDay> DaysOfMonth { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDayOfWeek> DaysOfWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupMonth> MonthsOfYear { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleTimes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupWeekNumber> WeeksOfMonth { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleBasedBackupTriggerContext : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTriggerContext, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>
    {
        public ScheduleBasedBackupTriggerContext(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule schedule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria> taggingCriteriaList) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupTaggingCriteria> TaggingCriteriaList { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ScheduleBasedBackupTriggerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretStoreBasedAuthCredentials : Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupAuthCredentials, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>
    {
        public SecretStoreBasedAuthCredentials() { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo SecretStoreResource { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreBasedAuthCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretStoreResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>
    {
        public SecretStoreResourceInfo(Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType secretStoreType) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreType SecretStoreType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SecretStoreResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SourceLifeCycle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>
    {
        public SourceLifeCycle(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting deleteAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase sourceDataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupDeleteSetting DeleteAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase SourceDataStore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting> TargetDataStoreCopySettings { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.SourceLifeCycle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TargetCopySetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>
    {
        public TargetCopySetting(Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting copyAfter, Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase dataStore) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataProtectionBackupCopySetting CopyAfter { get { throw null; } set { } }
        public Azure.ResourceManager.DataProtectionBackup.Models.DataStoreInfoBase DataStore { get { throw null; } set { } }
        Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.TargetCopySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserFacingWarningDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>
    {
        internal UserFacingWarningDetail() { }
        public string ResourceName { get { throw null; } }
        public Azure.ResponseError Warning { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.UserFacingWarningDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateCrossRegionRestoreRequestObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>
    {
        public ValidateCrossRegionRestoreRequestObject(Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent restoreRequestObject, Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails crossRegionRestoreDetails) { }
        public Azure.ResourceManager.DataProtectionBackup.Models.CrossRegionRestoreDetails CrossRegionRestoreDetails { get { throw null; } }
        public Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent RestoreRequestObject { get { throw null; } }
        Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataProtectionBackup.Models.ValidateCrossRegionRestoreRequestObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
