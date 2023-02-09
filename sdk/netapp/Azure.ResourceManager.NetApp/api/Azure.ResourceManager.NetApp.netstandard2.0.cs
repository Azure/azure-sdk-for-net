namespace Azure.ResourceManager.NetApp
{
    public partial class CapacityPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>, System.Collections.IEnumerable
    {
        protected CapacityPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.NetApp.CapacityPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.NetApp.CapacityPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.CapacityPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.CapacityPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.CapacityPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.CapacityPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CapacityPoolData(Azure.Core.AzureLocation location, long size, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel serviceLevel) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType? EncryptionType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public System.Guid? PoolId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? QosType { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel ServiceLevel { get { throw null; } set { } }
        public long Size { get { throw null; } set { } }
        public float? TotalThroughputMibps { get { throw null; } }
        public float? UtilizedThroughputMibps { get { throw null; } }
    }
    public partial class CapacityPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityPoolResource() { }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetNetAppVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetNetAppVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeCollection GetNetAppVolumes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppAccountBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppAccountBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.NetApp.NetAppAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.NetApp.NetAppAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> ActiveDirectories { get { throw null; } }
        public bool? DisableShowmount { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class NetAppAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> GetCapacityPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetCapacityPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolCollection GetCapacityPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetNetAppAccountBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetNetAppAccountBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountBackupCollection GetNetAppAccountBackups() { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupPolicyCollection GetNetAppBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetNetAppBackupPolicy(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetNetAppBackupPolicyAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> GetNetAppVolumeGroup(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetNetAppVolumeGroupAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeGroupCollection GetNetAppVolumeGroups() { throw null; }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyCollection GetSnapshotPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetSnapshotPolicy(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetSnapshotPolicyAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVault> GetVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVault> GetVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult> GetVolumeGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult> GetVolumeGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RenewCredentials(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RenewCredentialsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public NetAppBackupData(Azure.Core.AzureLocation location) { }
        public string BackupId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppBackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
    }
    public partial class NetAppBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected NetAppBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.NetAppBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.NetAppBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppBackupPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppBackupPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
    }
    public partial class NetAppBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppBackupPolicyResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetAppExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.CapacityPoolResource GetCapacityPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetNetAppAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountBackupResource GetNetAppAccountBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountResource GetNetAppAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountCollection GetNetAppAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupPolicyResource GetNetAppBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource GetNetAppSubvolumeInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeGroupResource GetNetAppVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource GetNetAppVolumeQuotaRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeResource GetNetAppVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource GetNetAppVolumeSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotPolicyResource GetSnapshotPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo> QueryRegionInfoNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppSubvolumeInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>, System.Collections.IEnumerable
    {
        protected NetAppSubvolumeInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Get(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppSubvolumeInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public NetAppSubvolumeInfoData() { }
        public string ParentPath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class NetAppSubvolumeInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppSubvolumeInfoResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string subvolumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata> GetMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>> GetMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.NetAppVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.NetAppVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppVolumeData(Azure.Core.AzureLocation location, string creationToken, long usageThreshold, Azure.Core.ResourceIdentifier subnetId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public bool? DeleteBaseSnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public System.Guid? FileSystemId { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } }
        public bool? IsKerberosEnabled { get { throw null; } set { } }
        public bool? IsLdapEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } set { } }
        public bool? IsSmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? IsSmbEncryptionEnabled { get { throw null; } set { } }
        public bool? IsSnapshotDirectoryVisible { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> MountTargets { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public System.Guid? NetworkSiblingSetId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? SmbNonBrowsable { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class NetAppVolumeGroupCollection : Azure.ResourceManager.ArmCollection
    {
        protected NetAppVolumeGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Get(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public NetAppVolumeGroupData() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata GroupMetaData { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume> Volumes { get { throw null; } }
    }
    public partial class NetAppVolumeGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeGroupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string volumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeQuotaRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeQuotaRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Get(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeQuotaRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppVolumeQuotaRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? QuotaType { get { throw null; } set { } }
    }
    public partial class NetAppVolumeQuotaRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeQuotaRuleResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string volumeQuotaRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AuthorizeReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AuthorizeReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BreakReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BreakReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus> GetBackupStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>> GetBackupStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetNetAppSubvolumeInfo(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetNetAppSubvolumeInfoAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppSubvolumeInfoCollection GetNetAppSubvolumeInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetNetAppVolumeBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetNetAppVolumeBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeBackupCollection GetNetAppVolumeBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetNetAppVolumeQuotaRule(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetNetAppVolumeQuotaRuleAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleCollection GetNetAppVolumeQuotaRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetNetAppVolumeSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetNetAppVolumeSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeSnapshotCollection GetNetAppVolumeSnapshots() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication> GetReplications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication> GetReplicationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus> GetReplicationStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>> GetReplicationStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus> GetRestoreStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>> GetRestoreStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PoolChange(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PoolChangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReestablishReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReestablishReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReInitializeReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReInitializeReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Relocate(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.RelocateVolumeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RelocateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.RelocateVolumeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetCifsPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetCifsPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revert(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevertRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeSnapshotData : Azure.ResourceManager.Models.ResourceData
    {
        public NetAppVolumeSnapshotData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SnapshotId { get { throw null; } }
    }
    public partial class NetAppVolumeSnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeSnapshotResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFiles(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFilesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>, System.Collections.IEnumerable
    {
        protected SnapshotPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotPolicyName, Azure.ResourceManager.NetApp.SnapshotPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotPolicyName, Azure.ResourceManager.NetApp.SnapshotPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Get(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.SnapshotPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.SnapshotPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SnapshotPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule DailySchedule { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule HourlySchedule { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule WeeklySchedule { get { throw null; } set { } }
    }
    public partial class SnapshotPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotPolicyResource() { }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string snapshotPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetVolumes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetVolumesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetApp.Models
{
    public static partial class ArmNetAppModelFactory
    {
        public static Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping AvailabilityZoneMapping(string availabilityZone = null, bool? isAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.CapacityPoolData CapacityPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Guid? poolId = default(System.Guid?), long size = (long)0, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel), string provisioningState = null, float? totalThroughputMibps = default(float?), float? utilizedThroughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? qosType = default(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType?), bool? isCoolAccessEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType? encryptionType = default(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory NetAppAccountActiveDirectory(string activeDirectoryId = null, string username = null, string password = null, string domain = null, string dns = null, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus? status = default(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus?), string statusDetails = null, string smbServerName = null, string organizationalUnit = null, string site = null, System.Collections.Generic.IEnumerable<string> backupOperators = null, System.Collections.Generic.IEnumerable<string> administrators = null, System.Net.IPAddress kdcIP = null, string adName = null, string serverRootCACertificate = null, bool? isAesEncryptionEnabled = default(bool?), bool? isLdapSigningEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> securityOperators = null, bool? isLdapOverTlsEnabled = default(bool?), bool? allowLocalNfsUsersWithLdap = default(bool?), bool? encryptDCConnections = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration ldapSearchScope = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountData NetAppAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories = null, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption = null, bool? disableShowmount = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupData NetAppBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string backupId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, long? size = default(long?), string label = null, Azure.ResourceManager.NetApp.Models.NetAppBackupType? backupType = default(Azure.ResourceManager.NetApp.Models.NetAppBackupType?), string failureReason = null, string volumeName = null, bool? useExistingSnapshot = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupPolicyData NetAppBackupPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier backupPolicyId = null, string provisioningState = null, int? dailyBackupsToKeep = default(int?), int? weeklyBackupsToKeep = default(int?), int? monthlyBackupsToKeep = default(int?), int? volumesAssigned = default(int?), bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> volumeBackups = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult NetAppCheckAvailabilityResult(bool? isAvailable = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason? reason = default(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity NetAppEncryptionIdentity(string principalId = null, string userAssignedIdentity = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties NetAppKeyVaultProperties(string keyVaultId = null, System.Uri keyVaultUri = null, string keyName = null, string keyVaultResourceId = null, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus? status = default(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRegionInfo NetAppRegionInfo(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> availabilityZoneMappings = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? current = default(int?), int? @default = default(int?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData NetAppSubvolumeInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, long? size = default(long?), string parentPath = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata NetAppSubvolumeMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, string parentPath = null, long? size = default(long?), long? bytesUsed = default(long?), string permissions = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? accessedOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVault NetAppVault(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string vaultName = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail NetAppVolumeBackupDetail(string volumeName = null, int? backupsCount = default(int?), bool? isPolicyEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = default(long?), string lastTransferType = null, long? totalTransferBytes = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null, System.Guid? fileSystemId = default(System.Guid?), string creationToken = null, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long usageThreshold = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, System.Collections.Generic.IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = default(bool?), string backupId = null, string baremetalTenantId = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), System.Guid? networkSiblingSetId = default(System.Guid?), Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = default(bool?), bool? isSnapshotDirectoryVisible = default(bool?), bool? isKerberosEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle?), bool? isSmbEncryptionEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?), bool? isSmbContinuouslyAvailable = default(bool?), float? throughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource = default(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource?), Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = default(bool?), bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), string unixPermissions = null, int? cloneProgress = default(int?), Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore = default(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore?), bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), long? maximumNumberOfFiles = default(long?), string volumeGroupName = null, Azure.Core.ResourceIdentifier capacityPoolResourceId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules = null, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes = default(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeGroupData NetAppVolumeGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string provisioningState = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata groupMetaData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume> volumes = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata NetAppVolumeGroupMetadata(string groupDescription = null, Azure.ResourceManager.NetApp.Models.NetAppApplicationType? applicationType = default(Azure.ResourceManager.NetApp.Models.NetAppApplicationType?), string applicationIdentifier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> globalPlacementRules = null, string deploymentSpecId = null, long? volumesCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult NetAppVolumeGroupResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string provisioningState = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata groupMetaData = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Guid? fileSystemId = default(System.Guid?), string creationToken = null, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long usageThreshold = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, System.Collections.Generic.IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = default(bool?), string backupId = null, string baremetalTenantId = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), System.Guid? networkSiblingSetId = default(System.Guid?), Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = default(bool?), bool? isSnapshotDirectoryVisible = default(bool?), bool? isKerberosEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle?), bool? isSmbEncryptionEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?), bool? isSmbContinuouslyAvailable = default(bool?), float? throughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource = default(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource?), Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = default(bool?), bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), string unixPermissions = null, int? cloneProgress = default(int?), Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore = default(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore?), bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), long? maximumNumberOfFiles = default(long?), string volumeGroupName = null, Azure.Core.ResourceIdentifier capacityPoolResourceId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules = null, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes = default(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget NetAppVolumeMountTarget(System.Guid? mountTargetId = default(System.Guid?), System.Guid fileSystemId = default(System.Guid), System.Net.IPAddress ipAddress = null, string smbServerFqdn = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData NetAppVolumeQuotaRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetAppProvisioningState?), long? quotaSizeInKiBs = default(long?), Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? quotaType = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType?), string quotaTarget = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication NetAppVolumeReplication(Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType = default(Azure.ResourceManager.NetApp.Models.NetAppEndpointType?), Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule = default(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule?), Azure.Core.ResourceIdentifier remoteVolumeResourceId = null, string remoteVolumeRegion = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string totalProgress = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData NetAppVolumeSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string snapshotId = null, System.DateTimeOffset? created = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotPolicyData SnapshotPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule hourlySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule dailySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule weeklySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule monthlySchedule = null, bool? isEnabled = default(bool?), string provisioningState = null) { throw null; }
    }
    public partial class AvailabilityZoneMapping
    {
        internal AvailabilityZoneMapping() { }
        public string AvailabilityZone { get { throw null; } }
        public bool? IsAvailable { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityPoolEncryptionType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityPoolEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType Double { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType left, Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType left, Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityPoolPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CapacityPoolPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? QosType { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityPoolQosType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CapacityPoolQosType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityPoolQosType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolQosType Auto { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolQosType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType left, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CapacityPoolQosType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType left, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableNetAppSubvolume : System.IEquatable<Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableNetAppSubvolume(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume left, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume left, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppAccountActiveDirectory
    {
        public NetAppAccountActiveDirectory() { }
        public string ActiveDirectoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Administrators { get { throw null; } }
        public string AdName { get { throw null; } set { } }
        public bool? AllowLocalNfsUsersWithLdap { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BackupOperators { get { throw null; } }
        public string Dns { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public bool? EncryptDCConnections { get { throw null; } set { } }
        public bool? IsAesEncryptionEnabled { get { throw null; } set { } }
        public bool? IsLdapOverTlsEnabled { get { throw null; } set { } }
        public bool? IsLdapSigningEnabled { get { throw null; } set { } }
        public System.Net.IPAddress KdcIP { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration LdapSearchScope { get { throw null; } set { } }
        public string OrganizationalUnit { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SecurityOperators { get { throw null; } }
        public string ServerRootCACertificate { get { throw null; } set { } }
        public string Site { get { throw null; } set { } }
        public string SmbServerName { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppAccountActiveDirectoryStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppAccountActiveDirectoryStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus InUse { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppAccountEncryption
    {
        public NetAppAccountEncryption() { }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
    }
    public partial class NetAppAccountPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppAccountPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> ActiveDirectories { get { throw null; } }
        public bool? DisableShowmount { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption Encryption { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppApplicationType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppApplicationType SapHana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppApplicationType left, Azure.ResourceManager.NetApp.Models.NetAppApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppApplicationType left, Azure.ResourceManager.NetApp.Models.NetAppApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppAvsDataStore : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppAvsDataStore(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore left, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore left, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppBackupPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppBackupPolicyPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppBackupType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppBackupType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppBackupType Manual { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppBackupType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppBackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppBackupType left, Azure.ResourceManager.NetApp.Models.NetAppBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppBackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppBackupType left, Azure.ResourceManager.NetApp.Models.NetAppBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppCheckAvailabilityResult
    {
        internal NetAppCheckAvailabilityResult() { }
        public bool? IsAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppChownMode : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppChownMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppChownMode(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppChownMode Restricted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppChownMode Unrestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppChownMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppChownMode left, Azure.ResourceManager.NetApp.Models.NetAppChownMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppChownMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppChownMode left, Azure.ResourceManager.NetApp.Models.NetAppChownMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppEncryptionIdentity
    {
        public NetAppEncryptionIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppEncryptionKeySource : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppEncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource MicrosoftNetApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource left, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource left, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppEndpointType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEndpointType Destination { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppEndpointType Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppEndpointType left, Azure.ResourceManager.NetApp.Models.NetAppEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppEndpointType left, Azure.ResourceManager.NetApp.Models.NetAppEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppFilePathAvailabilityContent
    {
        public NetAppFilePathAvailabilityContent(string name, Azure.Core.ResourceIdentifier subnetId) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppFileServiceLevel : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppFileServiceLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Premium { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Standard { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel StandardZrs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel left, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel left, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppKeySource : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppKeySource(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeySource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeySource MicrosoftNetApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppKeySource left, Azure.ResourceManager.NetApp.Models.NetAppKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppKeySource left, Azure.ResourceManager.NetApp.Models.NetAppKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppKeyVaultProperties
    {
        public NetAppKeyVaultProperties(System.Uri keyVaultUri, string keyName, string keyVaultResourceId) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } }
        public string KeyVaultResourceId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppKeyVaultStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppKeyVaultStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus InUse { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus left, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus left, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppLdapSearchScopeConfiguration
    {
        public NetAppLdapSearchScopeConfiguration() { }
        public string GroupDN { get { throw null; } set { } }
        public string GroupMembershipFilter { get { throw null; } set { } }
        public string UserDN { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppMirrorState : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppMirrorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppMirrorState(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Broken { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Mirrored { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Uninitialized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppMirrorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppMirrorState left, Azure.ResourceManager.NetApp.Models.NetAppMirrorState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppMirrorState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppMirrorState left, Azure.ResourceManager.NetApp.Models.NetAppMirrorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppNameAvailabilityContent
    {
        public NetAppNameAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType resourceType, string resourceGroup) { }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNameAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNameAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNameUnavailableReason : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason left, Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason left, Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNetworkFeature : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNetworkFeature(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature Basic { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature left, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature left, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum NetAppProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Patching = 2,
        Deleting = 3,
        Moving = 4,
        Failed = 5,
        Succeeded = 6,
    }
    public partial class NetAppQuotaAvailabilityContent
    {
        public NetAppQuotaAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType availabilityResourceType, string resourceGroup) { }
        public Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType AvailabilityResourceType { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppQuotaAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppQuotaAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppRegionInfo
    {
        internal NetAppRegionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> AvailabilityZoneMappings { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppRelationshipStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppRelationshipStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Idle { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Transferring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus left, Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus left, Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppReplicationObject
    {
        public NetAppReplicationObject(Azure.Core.ResourceIdentifier remoteVolumeResourceId) { }
        public Azure.ResourceManager.NetApp.Models.NetAppEndpointType? EndpointType { get { throw null; } set { } }
        public string RemoteVolumeRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } set { } }
        public string ReplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? ReplicationSchedule { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppReplicationSchedule : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppReplicationSchedule(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule Daily { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule Hourly { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule TenMinutely { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule left, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule left, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppRestoreStatus
    {
        internal NetAppRestoreStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
    }
    public partial class NetAppSubscriptionQuotaItem : Azure.ResourceManager.Models.ResourceData
    {
        public NetAppSubscriptionQuotaItem() { }
        public int? Current { get { throw null; } }
        public int? Default { get { throw null; } }
    }
    public partial class NetAppSubvolumeInfoPatch
    {
        public NetAppSubvolumeInfoPatch() { }
        public string Path { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class NetAppSubvolumeMetadata : Azure.ResourceManager.Models.ResourceData
    {
        internal NetAppSubvolumeMetadata() { }
        public System.DateTimeOffset? AccessedOn { get { throw null; } }
        public long? BytesUsed { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ParentPath { get { throw null; } }
        public string Path { get { throw null; } }
        public string Permissions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
    }
    public partial class NetAppVault : Azure.ResourceManager.Models.ResourceData
    {
        internal NetAppVault() { }
        public string VaultName { get { throw null; } }
    }
    public partial class NetAppVolumeAuthorizeReplicationContent
    {
        public NetAppVolumeAuthorizeReplicationContent() { }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } set { } }
    }
    public partial class NetAppVolumeBackupConfiguration
    {
        public NetAppVolumeBackupConfiguration() { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } set { } }
        public bool? IsBackupEnabled { get { throw null; } set { } }
        public bool? IsPolicyEnforced { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
    }
    public partial class NetAppVolumeBackupDetail
    {
        internal NetAppVolumeBackupDetail() { }
        public int? BackupsCount { get { throw null; } }
        public bool? IsPolicyEnabled { get { throw null; } }
        public string VolumeName { get { throw null; } }
    }
    public partial class NetAppVolumeBackupPatch
    {
        public NetAppVolumeBackupPatch() { }
        public string BackupId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppBackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
    }
    public partial class NetAppVolumeBackupStatus
    {
        internal NetAppVolumeBackupStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public long? LastTransferSize { get { throw null; } }
        public string LastTransferType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
    }
    public partial class NetAppVolumeBreakReplicationContent
    {
        public NetAppVolumeBreakReplicationContent() { }
        public bool? ForceBreakReplication { get { throw null; } set { } }
    }
    public partial class NetAppVolumeDataProtection
    {
        public NetAppVolumeDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration Backup { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationObject Replication { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotPolicyId { get { throw null; } set { } }
    }
    public partial class NetAppVolumeExportPolicyRule
    {
        public NetAppVolumeExportPolicyRule() { }
        public bool? AllowCifsProtocol { get { throw null; } set { } }
        public string AllowedClients { get { throw null; } set { } }
        public bool? AllowNfsV3Protocol { get { throw null; } set { } }
        public bool? AllowNfsV41Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppChownMode? ChownMode { get { throw null; } set { } }
        public bool? HasRootAccess { get { throw null; } set { } }
        public bool? IsKerberos5iReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5iReadWrite { get { throw null; } set { } }
        public bool? IsKerberos5pReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5pReadWrite { get { throw null; } set { } }
        public bool? IsKerberos5ReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5ReadWrite { get { throw null; } set { } }
        public bool? IsUnixReadOnly { get { throw null; } set { } }
        public bool? IsUnixReadWrite { get { throw null; } set { } }
        public int? RuleIndex { get { throw null; } set { } }
    }
    public partial class NetAppVolumeGroupMetadata
    {
        public NetAppVolumeGroupMetadata() { }
        public string ApplicationIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppApplicationType? ApplicationType { get { throw null; } set { } }
        public string DeploymentSpecId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> GlobalPlacementRules { get { throw null; } }
        public string GroupDescription { get { throw null; } set { } }
        public long? VolumesCount { get { throw null; } }
    }
    public partial class NetAppVolumeGroupResult : Azure.ResourceManager.Models.ResourceData
    {
        internal NetAppVolumeGroupResult() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata GroupMetaData { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class NetAppVolumeGroupVolume
    {
        public NetAppVolumeGroupVolume(string creationToken, long usageThreshold, Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public bool? DeleteBaseSnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public System.Guid? FileSystemId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } }
        public bool? IsKerberosEnabled { get { throw null; } set { } }
        public bool? IsLdapEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } set { } }
        public bool? IsSmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? IsSmbEncryptionEnabled { get { throw null; } set { } }
        public bool? IsSnapshotDirectoryVisible { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> MountTargets { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public System.Guid? NetworkSiblingSetId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? SmbNonBrowsable { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
    }
    public partial class NetAppVolumeMountTarget
    {
        internal NetAppVolumeMountTarget() { }
        public System.Guid FileSystemId { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.Guid? MountTargetId { get { throw null; } }
        public string SmbServerFqdn { get { throw null; } }
    }
    public partial class NetAppVolumePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppVolumePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long? UsageThreshold { get { throw null; } set { } }
    }
    public partial class NetAppVolumePatchDataProtection
    {
        public NetAppVolumePatchDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration Backup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotPolicyId { get { throw null; } set { } }
    }
    public partial class NetAppVolumePlacementRule
    {
        public NetAppVolumePlacementRule(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NetAppVolumePoolChangeContent
    {
        public NetAppVolumePoolChangeContent(Azure.Core.ResourceIdentifier newPoolResourceId) { }
        public Azure.Core.ResourceIdentifier NewPoolResourceId { get { throw null; } }
    }
    public partial class NetAppVolumeQuotaRulePatch
    {
        public NetAppVolumeQuotaRulePatch() { }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? QuotaType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeQuotaType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeQuotaType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType DefaultGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType DefaultUserQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType IndividualGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType IndividualUserQuota { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType left, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType left, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppVolumeReestablishReplicationContent
    {
        public NetAppVolumeReestablishReplicationContent() { }
        public Azure.Core.ResourceIdentifier SourceVolumeId { get { throw null; } set { } }
    }
    public partial class NetAppVolumeReplication
    {
        internal NetAppVolumeReplication() { }
        public Azure.ResourceManager.NetApp.Models.NetAppEndpointType? EndpointType { get { throw null; } }
        public string RemoteVolumeRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? ReplicationSchedule { get { throw null; } }
    }
    public partial class NetAppVolumeReplicationStatus
    {
        internal NetAppVolumeReplicationStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public string TotalProgress { get { throw null; } }
    }
    public partial class NetAppVolumeRevertContent
    {
        public NetAppVolumeRevertContent() { }
        public string SnapshotId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeSecurityStyle : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeSecurityStyle(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle Ntfs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle Unix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle left, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle left, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppVolumeSnapshotRestoreFilesContent
    {
        public NetAppVolumeSnapshotRestoreFilesContent(System.Collections.Generic.IEnumerable<string> filePaths) { }
        public string DestinationPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FilePaths { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeStorageToNetworkProximity : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeStorageToNetworkProximity(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity T1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity T2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionStorageToNetworkProximity : System.IEquatable<Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionStorageToNetworkProximity(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1AndT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelocateVolumeContent
    {
        public RelocateVolumeContent() { }
        public string CreationToken { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmbAccessBasedEnumeration : System.IEquatable<Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmbAccessBasedEnumeration(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration left, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration left, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmbNonBrowsable : System.IEquatable<Azure.ResourceManager.NetApp.Models.SmbNonBrowsable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmbNonBrowsable(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SmbNonBrowsable Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.SmbNonBrowsable Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable left, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.SmbNonBrowsable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable left, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotPolicyDailySchedule
    {
        public SnapshotPolicyDailySchedule() { }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    public partial class SnapshotPolicyHourlySchedule
    {
        public SnapshotPolicyHourlySchedule() { }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    public partial class SnapshotPolicyMonthlySchedule
    {
        public SnapshotPolicyMonthlySchedule() { }
        public string DaysOfMonth { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    public partial class SnapshotPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SnapshotPolicyPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule DailySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule HourlySchedule { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule WeeklySchedule { get { throw null; } set { } }
    }
    public partial class SnapshotPolicyWeeklySchedule
    {
        public SnapshotPolicyWeeklySchedule() { }
        public string Day { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
}
