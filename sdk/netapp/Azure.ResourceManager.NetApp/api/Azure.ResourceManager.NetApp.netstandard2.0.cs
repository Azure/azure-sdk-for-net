namespace Azure.ResourceManager.NetApp
{
    public partial class BackupData : Azure.ResourceManager.Models.ResourceData
    {
        public BackupData(Azure.Core.AzureLocation location) { }
        public string BackupId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.BackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
    }
    public partial class BackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.BackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.BackupPolicyResource>, System.Collections.IEnumerable
    {
        protected BackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.BackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.BackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.BackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.BackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.BackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.BackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.BackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.BackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.VolumeBackups> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
    }
    public partial class BackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupPolicyResource() { }
        public virtual Azure.ResourceManager.NetApp.BackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
        public CapacityPoolData(Azure.Core.AzureLocation location, long size, Azure.ResourceManager.NetApp.Models.ServiceLevel serviceLevel) : base (default(Azure.Core.AzureLocation)) { }
        public bool? CoolAccess { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.EncryptionType? EncryptionType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string PoolId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.QosType? QosType { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ServiceLevel ServiceLevel { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.VolumeCollection GetVolumes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppAccountAccountBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountAccountBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppAccountAccountBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountAccountBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.BackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppAccountCapacityPoolVolumeBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountCapacityPoolVolumeBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.BackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.BackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppAccountCapacityPoolVolumeBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountCapacityPoolVolumeBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.BackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountCapacityPoolVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountCapacityPoolVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.ActiveDirectory> ActiveDirectories { get { throw null; } }
        public string EncryptionKeySource { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
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
        public virtual Azure.ResourceManager.NetApp.BackupPolicyCollection GetBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource> GetBackupPolicy(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BackupPolicyResource>> GetBackupPolicyAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> GetCapacityPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetCapacityPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolCollection GetCapacityPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource> GetNetAppAccountAccountBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource>> GetNetAppAccountAccountBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountAccountBackupCollection GetNetAppAccountAccountBackups() { throw null; }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyCollection GetSnapshotPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetSnapshotPolicy(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetSnapshotPolicyAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.Vault> GetVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.Vault> GetVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource> GetVolumeGroupDetail(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource>> GetVolumeGroupDetailAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.VolumeGroupDetailCollection GetVolumeGroupDetails() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.VolumeGroup> GetVolumeGroupsByNetAppAccount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.VolumeGroup> GetVolumeGroupsByNetAppAccountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetAppExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse> CheckFilePathAvailabilityNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.FilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse>> CheckFilePathAvailabilityNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.FilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse> CheckNameAvailabilityNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.ResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse>> CheckNameAvailabilityNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.ResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse> CheckQuotaAvailabilityNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.CheckAvailabilityResponse>> CheckQuotaAvailabilityNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.BackupPolicyResource GetBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.CapacityPoolResource GetCapacityPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountAccountBackupResource GetNetAppAccountAccountBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetNetAppAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource GetNetAppAccountCapacityPoolVolumeBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountResource GetNetAppAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountCollection GetNetAppAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotPolicyResource GetSnapshotPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotResource GetSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> GetSubscriptionQuotaItem(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>> GetSubscriptionQuotaItemAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource GetSubscriptionQuotaItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.SubscriptionQuotaItemCollection GetSubscriptionQuotaItems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.NetApp.SubvolumeInfoResource GetSubvolumeInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.VolumeGroupDetailResource GetVolumeGroupDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.VolumeQuotaRuleResource GetVolumeQuotaRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.VolumeResource GetVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotResource>, System.Collections.IEnumerable
    {
        protected SnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.SnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.SnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.SnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.SnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotData : Azure.ResourceManager.Models.ResourceData
    {
        public SnapshotData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SnapshotId { get { throw null; } }
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
        public Azure.ResourceManager.NetApp.Models.DailySchedule DailySchedule { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.HourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.MonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.WeeklySchedule WeeklySchedule { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.VolumeResource> GetVolumes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.VolumeResource> GetVolumesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotResource() { }
        public virtual Azure.ResourceManager.NetApp.SnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFiles(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotRestoreFiles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFilesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotRestoreFiles body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionQuotaItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>, System.Collections.IEnumerable
    {
        protected SubscriptionQuotaItemCollection() { }
        public virtual Azure.Response<bool> Exists(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> Get(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>> GetAsync(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionQuotaItemData : Azure.ResourceManager.Models.ResourceData
    {
        public SubscriptionQuotaItemData() { }
        public int? Current { get { throw null; } }
        public int? Default { get { throw null; } }
    }
    public partial class SubscriptionQuotaItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionQuotaItemResource() { }
        public virtual Azure.ResourceManager.NetApp.SubscriptionQuotaItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string quotaLimitName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubscriptionQuotaItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubvolumeInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SubvolumeInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SubvolumeInfoResource>, System.Collections.IEnumerable
    {
        protected SubvolumeInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SubvolumeInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.SubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SubvolumeInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.SubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource> Get(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.SubvolumeInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.SubvolumeInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource>> GetAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.SubvolumeInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SubvolumeInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.SubvolumeInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SubvolumeInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubvolumeInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public SubvolumeInfoData() { }
        public string ParentPath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class SubvolumeInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubvolumeInfoResource() { }
        public virtual Azure.ResourceManager.NetApp.SubvolumeInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string subvolumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.SubvolumeModel> GetMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.SubvolumeModel>> GetMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SubvolumeInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SubvolumeInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.VolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.VolumeResource>, System.Collections.IEnumerable
    {
        protected VolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.VolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.VolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.VolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.VolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.VolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.VolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VolumeData(Azure.Core.AzureLocation location, string creationToken, long usageThreshold, string subnetId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.AvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public string CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public bool? CoolAccess { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.VolumePropertiesDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.EnableSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public bool? Encrypted { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.EncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.ExportPolicyRule> ExportRules { get { throw null; } }
        public string FileSystemId { get { throw null; } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } set { } }
        public bool? KerberosEnabled { get { throw null; } set { } }
        public string KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public bool? LdapEnabled { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.MountTargetProperties> MountTargets { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public string NetworkSiblingSetId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.PlacementKeyValuePairs> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ServiceLevel? ServiceLevel { get { throw null; } set { } }
        public bool? SmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? SmbEncryption { get { throw null; } set { } }
        public bool? SnapshotDirectoryVisible { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VolumeGroupDetailCollection : Azure.ResourceManager.ArmCollection
    {
        protected VolumeGroupDetailCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeGroupDetailResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.VolumeGroupDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeGroupDetailResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.VolumeGroupDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource> Get(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource>> GetAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeGroupDetailData : Azure.ResourceManager.Models.ResourceData
    {
        public VolumeGroupDetailData() { }
        public Azure.ResourceManager.NetApp.Models.VolumeGroupMetaData GroupMetaData { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.VolumeGroupVolumeProperties> Volumes { get { throw null; } }
    }
    public partial class VolumeGroupDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeGroupDetailResource() { }
        public virtual Azure.ResourceManager.NetApp.VolumeGroupDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string volumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeGroupDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeGroupDetailResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.VolumeGroupDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeGroupDetailResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.VolumeGroupDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeQuotaRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>, System.Collections.IEnumerable
    {
        protected VolumeQuotaRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.VolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.VolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> Get(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> GetAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeQuotaRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VolumeQuotaRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.Type? QuotaType { get { throw null; } set { } }
    }
    public partial class VolumeQuotaRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeQuotaRuleResource() { }
        public virtual Azure.ResourceManager.NetApp.VolumeQuotaRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string volumeQuotaRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeResource() { }
        public virtual Azure.ResourceManager.NetApp.VolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AuthorizeReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.AuthorizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AuthorizeReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.AuthorizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BreakReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BreakReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource> GetNetAppAccountCapacityPoolVolumeBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupResource>> GetNetAppAccountCapacityPoolVolumeBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountCapacityPoolVolumeBackupCollection GetNetAppAccountCapacityPoolVolumeBackups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.Replication> GetReplications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.Replication> GetReplicationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource> GetSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotResource>> GetSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.SnapshotCollection GetSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.BackupStatus> GetStatusBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.BackupStatus>> GetStatusBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource> GetSubvolumeInfo(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SubvolumeInfoResource>> GetSubvolumeInfoAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.SubvolumeInfoCollection GetSubvolumeInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource> GetVolumeQuotaRule(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeQuotaRuleResource>> GetVolumeQuotaRuleAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.VolumeQuotaRuleCollection GetVolumeQuotaRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.RestoreStatus> GetVolumeRestoreStatusBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.RestoreStatus>> GetVolumeRestoreStatusBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PoolChange(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.PoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PoolChangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.PoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReestablishReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.ReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReestablishReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.ReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReInitializeReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReInitializeReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Relocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RelocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.ReplicationStatus> ReplicationStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.ReplicationStatus>> ReplicationStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetCifsPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetCifsPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revert(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumeRevert body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumeRevert body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevertRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.VolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.VolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.VolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ActiveDirectory
    {
        public ActiveDirectory() { }
        public string ActiveDirectoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Administrators { get { throw null; } }
        public string AdName { get { throw null; } set { } }
        public bool? AesEncryption { get { throw null; } set { } }
        public bool? AllowLocalNfsUsersWithLdap { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BackupOperators { get { throw null; } }
        public string Dns { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public bool? EncryptDCConnections { get { throw null; } set { } }
        public string KdcIP { get { throw null; } set { } }
        public bool? LdapOverTLS { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.LdapSearchScopeOpt LdapSearchScope { get { throw null; } set { } }
        public bool? LdapSigning { get { throw null; } set { } }
        public string OrganizationalUnit { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SecurityOperators { get { throw null; } }
        public string ServerRootCACertificate { get { throw null; } set { } }
        public string Site { get { throw null; } set { } }
        public string SmbServerName { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveDirectoryStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveDirectoryStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus InUse { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.ActiveDirectoryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationType : System.IEquatable<Azure.ResourceManager.NetApp.Models.ApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ApplicationType SAPHana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ApplicationType left, Azure.ResourceManager.NetApp.Models.ApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ApplicationType left, Azure.ResourceManager.NetApp.Models.ApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AuthorizeContent
    {
        public AuthorizeContent() { }
        public string RemoteVolumeResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsDataStore : System.IEquatable<Azure.ResourceManager.NetApp.Models.AvsDataStore>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsDataStore(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.AvsDataStore Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.AvsDataStore Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.AvsDataStore other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.AvsDataStore left, Azure.ResourceManager.NetApp.Models.AvsDataStore right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.AvsDataStore (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.AvsDataStore left, Azure.ResourceManager.NetApp.Models.AvsDataStore right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BackupPolicyPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.VolumeBackups> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
    }
    public partial class BackupStatus
    {
        internal BackupStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? Healthy { get { throw null; } }
        public long? LastTransferSize { get { throw null; } }
        public string LastTransferType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.MirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.NetApp.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BackupType Manual { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.BackupType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.BackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.BackupType left, Azure.ResourceManager.NetApp.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.BackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.BackupType left, Azure.ResourceManager.NetApp.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BreakReplicationContent
    {
        public BreakReplicationContent() { }
        public bool? ForceBreakReplication { get { throw null; } set { } }
    }
    public partial class CapacityPoolPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CapacityPoolPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? CoolAccess { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.QosType? QosType { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class CheckAvailabilityResponse
    {
        internal CheckAvailabilityResponse() { }
        public bool? IsAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CheckNameResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CheckNameResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckNameResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckNameResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckNameResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CheckNameResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CheckNameResourceType left, Azure.ResourceManager.NetApp.Models.CheckNameResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CheckNameResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CheckNameResourceType left, Azure.ResourceManager.NetApp.Models.CheckNameResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckQuotaNameResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckQuotaNameResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType left, Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType left, Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChownMode : System.IEquatable<Azure.ResourceManager.NetApp.Models.ChownMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChownMode(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ChownMode Restricted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ChownMode Unrestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ChownMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ChownMode left, Azure.ResourceManager.NetApp.Models.ChownMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ChownMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ChownMode left, Azure.ResourceManager.NetApp.Models.ChownMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DailySchedule
    {
        public DailySchedule() { }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableSubvolume : System.IEquatable<Azure.ResourceManager.NetApp.Models.EnableSubvolume>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableSubvolume(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EnableSubvolume Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EnableSubvolume Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EnableSubvolume other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EnableSubvolume left, Azure.ResourceManager.NetApp.Models.EnableSubvolume right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EnableSubvolume (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EnableSubvolume left, Azure.ResourceManager.NetApp.Models.EnableSubvolume right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionKeySource : System.IEquatable<Azure.ResourceManager.NetApp.Models.EncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EncryptionKeySource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EncryptionKeySource MicrosoftNetApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EncryptionKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EncryptionKeySource left, Azure.ResourceManager.NetApp.Models.EncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EncryptionKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EncryptionKeySource left, Azure.ResourceManager.NetApp.Models.EncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionType : System.IEquatable<Azure.ResourceManager.NetApp.Models.EncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EncryptionType Double { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EncryptionType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EncryptionType left, Azure.ResourceManager.NetApp.Models.EncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EncryptionType left, Azure.ResourceManager.NetApp.Models.EncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.NetApp.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EndpointType Dst { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EndpointType Src { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EndpointType left, Azure.ResourceManager.NetApp.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EndpointType left, Azure.ResourceManager.NetApp.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportPolicyRule
    {
        public ExportPolicyRule() { }
        public string AllowedClients { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ChownMode? ChownMode { get { throw null; } set { } }
        public bool? Cifs { get { throw null; } set { } }
        public bool? HasRootAccess { get { throw null; } set { } }
        public bool? Kerberos5IReadOnly { get { throw null; } set { } }
        public bool? Kerberos5IReadWrite { get { throw null; } set { } }
        public bool? Kerberos5PReadOnly { get { throw null; } set { } }
        public bool? Kerberos5PReadWrite { get { throw null; } set { } }
        public bool? Kerberos5ReadOnly { get { throw null; } set { } }
        public bool? Kerberos5ReadWrite { get { throw null; } set { } }
        public bool? Nfsv3 { get { throw null; } set { } }
        public bool? Nfsv41 { get { throw null; } set { } }
        public int? RuleIndex { get { throw null; } set { } }
        public bool? UnixReadOnly { get { throw null; } set { } }
        public bool? UnixReadWrite { get { throw null; } set { } }
    }
    public partial class FilePathAvailabilityContent
    {
        public FilePathAvailabilityContent(string name, string subnetId) { }
        public string Name { get { throw null; } }
        public string SubnetId { get { throw null; } }
    }
    public partial class HourlySchedule
    {
        public HourlySchedule() { }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InAvailabilityReasonType : System.IEquatable<Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InAvailabilityReasonType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType left, Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType left, Azure.ResourceManager.NetApp.Models.InAvailabilityReasonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LdapSearchScopeOpt
    {
        public LdapSearchScopeOpt() { }
        public string GroupDN { get { throw null; } set { } }
        public string GroupMembershipFilter { get { throw null; } set { } }
        public string UserDN { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MirrorState : System.IEquatable<Azure.ResourceManager.NetApp.Models.MirrorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MirrorState(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.MirrorState Broken { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.MirrorState Mirrored { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.MirrorState Uninitialized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.MirrorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.MirrorState left, Azure.ResourceManager.NetApp.Models.MirrorState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.MirrorState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.MirrorState left, Azure.ResourceManager.NetApp.Models.MirrorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonthlySchedule
    {
        public MonthlySchedule() { }
        public string DaysOfMonth { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
    public partial class MountTargetProperties
    {
        internal MountTargetProperties() { }
        public string FileSystemId { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string MountTargetId { get { throw null; } }
        public string SmbServerFqdn { get { throw null; } }
    }
    public partial class NetAppAccountCapacityPoolVolumeBackupPatch
    {
        public NetAppAccountCapacityPoolVolumeBackupPatch() { }
        public string BackupId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.BackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
    }
    public partial class NetAppAccountPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetAppAccountPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.ActiveDirectory> ActiveDirectories { get { throw null; } }
        public string EncryptionKeySource { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFeature : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetworkFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFeature(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetworkFeature Basic { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetworkFeature Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetworkFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetworkFeature left, Azure.ResourceManager.NetApp.Models.NetworkFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetworkFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetworkFeature left, Azure.ResourceManager.NetApp.Models.NetworkFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementKeyValuePairs
    {
        public PlacementKeyValuePairs(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class PoolChangeContent
    {
        public PoolChangeContent(string newPoolResourceId) { }
        public string NewPoolResourceId { get { throw null; } }
    }
    public enum ProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Patching = 2,
        Deleting = 3,
        Moving = 4,
        Failed = 5,
        Succeeded = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QosType : System.IEquatable<Azure.ResourceManager.NetApp.Models.QosType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QosType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.QosType Auto { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.QosType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.QosType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.QosType left, Azure.ResourceManager.NetApp.Models.QosType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.QosType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.QosType left, Azure.ResourceManager.NetApp.Models.QosType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaAvailabilityContent
    {
        public QuotaAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType checkQuotaNameResourceType, string resourceGroup) { }
        public Azure.ResourceManager.NetApp.Models.CheckQuotaNameResourceType CheckQuotaNameResourceType { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
    }
    public partial class ReestablishReplicationContent
    {
        public ReestablishReplicationContent() { }
        public string SourceVolumeId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationshipStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.RelationshipStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationshipStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.RelationshipStatus Idle { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RelationshipStatus Transferring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.RelationshipStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.RelationshipStatus left, Azure.ResourceManager.NetApp.Models.RelationshipStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.RelationshipStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.RelationshipStatus left, Azure.ResourceManager.NetApp.Models.RelationshipStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Replication
    {
        internal Replication() { }
        public Azure.ResourceManager.NetApp.Models.EndpointType? EndpointType { get { throw null; } }
        public string RemoteVolumeRegion { get { throw null; } }
        public string RemoteVolumeResourceId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.ReplicationSchedule? ReplicationSchedule { get { throw null; } }
    }
    public partial class ReplicationObject
    {
        public ReplicationObject(string remoteVolumeResourceId) { }
        public Azure.ResourceManager.NetApp.Models.EndpointType? EndpointType { get { throw null; } set { } }
        public string RemoteVolumeRegion { get { throw null; } set { } }
        public string RemoteVolumeResourceId { get { throw null; } set { } }
        public string ReplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ReplicationSchedule? ReplicationSchedule { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationSchedule : System.IEquatable<Azure.ResourceManager.NetApp.Models.ReplicationSchedule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationSchedule(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ReplicationSchedule Daily { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ReplicationSchedule Hourly { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ReplicationSchedule _10Minutely { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ReplicationSchedule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ReplicationSchedule left, Azure.ResourceManager.NetApp.Models.ReplicationSchedule right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ReplicationSchedule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ReplicationSchedule left, Azure.ResourceManager.NetApp.Models.ReplicationSchedule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationStatus
    {
        internal ReplicationStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? Healthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.MirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RelationshipStatus? RelationshipStatus { get { throw null; } }
        public string TotalProgress { get { throw null; } }
    }
    public partial class ResourceNameAvailabilityContent
    {
        public ResourceNameAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.CheckNameResourceType resourceType, string resourceGroup) { }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.CheckNameResourceType ResourceType { get { throw null; } }
    }
    public partial class RestoreStatus
    {
        internal RestoreStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? Healthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.MirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityStyle : System.IEquatable<Azure.ResourceManager.NetApp.Models.SecurityStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityStyle(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SecurityStyle Ntfs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.SecurityStyle Unix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.SecurityStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.SecurityStyle left, Azure.ResourceManager.NetApp.Models.SecurityStyle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.SecurityStyle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.SecurityStyle left, Azure.ResourceManager.NetApp.Models.SecurityStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceLevel : System.IEquatable<Azure.ResourceManager.NetApp.Models.ServiceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ServiceLevel Premium { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ServiceLevel Standard { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ServiceLevel StandardZRS { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ServiceLevel Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ServiceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ServiceLevel left, Azure.ResourceManager.NetApp.Models.ServiceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ServiceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ServiceLevel left, Azure.ResourceManager.NetApp.Models.ServiceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SnapshotPolicyPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetApp.Models.DailySchedule DailySchedule { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.HourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.MonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.WeeklySchedule WeeklySchedule { get { throw null; } set { } }
    }
    public partial class SnapshotRestoreFiles
    {
        public SnapshotRestoreFiles(System.Collections.Generic.IEnumerable<string> filePaths) { }
        public string DestinationPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FilePaths { get { throw null; } }
    }
    public partial class SubvolumeInfoPatch
    {
        public SubvolumeInfoPatch() { }
        public string Path { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class SubvolumeModel : Azure.ResourceManager.Models.ResourceData
    {
        internal SubvolumeModel() { }
        public System.DateTimeOffset? AccessedTimeStamp { get { throw null; } }
        public long? BytesUsed { get { throw null; } }
        public System.DateTimeOffset? ChangedTimeStamp { get { throw null; } }
        public System.DateTimeOffset? CreationTimeStamp { get { throw null; } }
        public System.DateTimeOffset? ModifiedTimeStamp { get { throw null; } }
        public string ParentPath { get { throw null; } }
        public string Path { get { throw null; } }
        public string Permissions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Type : System.IEquatable<Azure.ResourceManager.NetApp.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.Type DefaultGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.Type DefaultUserQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.Type IndividualGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.Type IndividualUserQuota { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.Type left, Azure.ResourceManager.NetApp.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.Type left, Azure.ResourceManager.NetApp.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Vault : Azure.ResourceManager.Models.ResourceData
    {
        internal Vault() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string VaultName { get { throw null; } }
    }
    public partial class VolumeBackupProperties
    {
        public VolumeBackupProperties() { }
        public bool? BackupEnabled { get { throw null; } set { } }
        public string BackupPolicyId { get { throw null; } set { } }
        public bool? PolicyEnforced { get { throw null; } set { } }
        public string VaultId { get { throw null; } set { } }
    }
    public partial class VolumeBackups
    {
        internal VolumeBackups() { }
        public int? BackupsCount { get { throw null; } }
        public bool? PolicyEnabled { get { throw null; } }
        public string VolumeName { get { throw null; } }
    }
    public partial class VolumeGroup : Azure.ResourceManager.Models.ResourceData
    {
        internal VolumeGroup() { }
        public Azure.ResourceManager.NetApp.Models.VolumeGroupMetaData GroupMetaData { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class VolumeGroupMetaData
    {
        public VolumeGroupMetaData() { }
        public string ApplicationIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string DeploymentSpecId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.PlacementKeyValuePairs> GlobalPlacementRules { get { throw null; } }
        public string GroupDescription { get { throw null; } set { } }
        public long? VolumesCount { get { throw null; } }
    }
    public partial class VolumeGroupVolumeProperties
    {
        public VolumeGroupVolumeProperties(string creationToken, long usageThreshold, string subnetId) { }
        public Azure.ResourceManager.NetApp.Models.AvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public string CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public bool? CoolAccess { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.VolumePropertiesDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.EnableSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public bool? Encrypted { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.EncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.ExportPolicyRule> ExportRules { get { throw null; } }
        public string FileSystemId { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } set { } }
        public bool? KerberosEnabled { get { throw null; } set { } }
        public string KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public bool? LdapEnabled { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.MountTargetProperties> MountTargets { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public string NetworkSiblingSetId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.PlacementKeyValuePairs> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ProximityPlacementGroup { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ServiceLevel? ServiceLevel { get { throw null; } set { } }
        public bool? SmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? SmbEncryption { get { throw null; } set { } }
        public bool? SnapshotDirectoryVisible { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
    }
    public partial class VolumePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VolumePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? CoolAccess { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.VolumePatchPropertiesDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.ExportPolicyRule> ExportRules { get { throw null; } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ServiceLevel? ServiceLevel { get { throw null; } set { } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long? UsageThreshold { get { throw null; } set { } }
    }
    public partial class VolumePatchPropertiesDataProtection
    {
        public VolumePatchPropertiesDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.VolumeBackupProperties Backup { get { throw null; } set { } }
        public string SnapshotPolicyId { get { throw null; } set { } }
    }
    public partial class VolumePropertiesDataProtection
    {
        public VolumePropertiesDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.VolumeBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.ReplicationObject Replication { get { throw null; } set { } }
        public string SnapshotPolicyId { get { throw null; } set { } }
    }
    public partial class VolumeQuotaRulePatch
    {
        public VolumeQuotaRulePatch() { }
        public Azure.ResourceManager.NetApp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.Type? QuotaType { get { throw null; } set { } }
    }
    public partial class VolumeRevert
    {
        public VolumeRevert() { }
        public string SnapshotId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeStorageToNetworkProximity : System.IEquatable<Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeStorageToNetworkProximity(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity T1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity T2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.VolumeStorageToNetworkProximity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeeklySchedule
    {
        public WeeklySchedule() { }
        public string Day { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
    }
}
