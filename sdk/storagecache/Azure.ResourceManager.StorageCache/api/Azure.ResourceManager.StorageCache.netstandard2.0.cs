namespace Azure.ResourceManager.StorageCache
{
    public partial class StorageCacheCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.StorageCacheResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.StorageCacheResource>, System.Collections.IEnumerable
    {
        protected StorageCacheCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageCacheResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheName, Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageCacheResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheName, Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> Get(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageCache.StorageCacheResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageCache.StorageCacheResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> GetAsync(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageCache.StorageCacheResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.StorageCacheResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageCache.StorageCacheResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.StorageCacheResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageCacheData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageCacheData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? CacheSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheDirectorySettings DirectoryServicesSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheHealth Health { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> MountAddresses { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheNetworkSettings NetworkSettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.PrimingJob> PrimingJobs { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageCache.Models.NfsAccessPolicy> SecurityAccessPolicies { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> SpaceAllocation { get { throw null; } }
        public Azure.Core.ResourceIdentifier Subnet { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUpgradeStatus UpgradeStatus { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public static partial class StorageCacheExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> GetStorageCache(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> GetStorageCacheAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageCache.StorageCacheResource GetStorageCacheResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageCache.StorageCacheCollection GetStorageCaches(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.StorageCacheResource> GetStorageCaches(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.StorageCacheResource> GetStorageCachesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.StorageCacheSku> GetStorageCacheSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.StorageCacheSku> GetStorageCacheSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsage> GetStorageCacheUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsage> GetStorageCacheUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageCache.StorageTargetResource GetStorageTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsageModel> GetUsageModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsageModel> GetUsageModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageCacheResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageCacheResource() { }
        public virtual Azure.ResourceManager.StorageCache.StorageCacheData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableDebugInfo(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableDebugInfoAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Flush(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FlushAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource> GetStorageTarget(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource>> GetStorageTargetAsync(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageCache.StorageTargetCollection GetStorageTargets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PausePrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PausePrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumePrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumePrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartPrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJob primingjob = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartPrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJob primingjob = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopPrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopPrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource> Update(Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageCacheResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageCacheResource>> UpdateAsync(Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageCacheResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.StorageCacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateSpaceAllocation(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> spaceAllocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateSpaceAllocationAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> spaceAllocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeFirmware(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeFirmwareAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.StorageTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.StorageTargetResource>, System.Collections.IEnumerable
    {
        protected StorageTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageTargetName, Azure.ResourceManager.StorageCache.StorageTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageTargetName, Azure.ResourceManager.StorageCache.StorageTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource> Get(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageCache.StorageTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageCache.StorageTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource>> GetAsync(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageCache.StorageTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.StorageTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageCache.StorageTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.StorageTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageTargetData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageTargetData() { }
        public int? AllocationPercentage { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.BlobNfsTarget BlobNfs { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClfsTarget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageCache.Models.NamespaceJunction> Junctions { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.Nfs3Target Nfs3 { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType? State { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageTargetType? TargetType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> UnknownAttributes { get { throw null; } }
    }
    public partial class StorageTargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageTargetResource() { }
        public virtual Azure.ResourceManager.StorageCache.StorageTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string storageTargetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string force = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string force = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Flush(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FlushAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Invalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InvalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshDns(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshDnsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreDefaults(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreDefaultsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.StorageTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.StorageTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.StorageTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StorageCache.Models
{
    public partial class BlobNfsTarget
    {
        public BlobNfsTarget() { }
        public Azure.Core.ResourceIdentifier Target { get { throw null; } set { } }
        public string UsageModel { get { throw null; } set { } }
        public int? VerificationTimer { get { throw null; } set { } }
        public int? WriteBackTimer { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainJoinedType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.DomainJoinedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainJoinedType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.DomainJoinedType Error { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.DomainJoinedType No { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.DomainJoinedType Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.DomainJoinedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.DomainJoinedType left, Azure.ResourceManager.StorageCache.Models.DomainJoinedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.DomainJoinedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.DomainJoinedType left, Azure.ResourceManager.StorageCache.Models.DomainJoinedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceJunction
    {
        public NamespaceJunction() { }
        public string NamespacePath { get { throw null; } set { } }
        public string NfsAccessPolicy { get { throw null; } set { } }
        public string NfsExport { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
    }
    public partial class Nfs3Target
    {
        public Nfs3Target() { }
        public string Target { get { throw null; } set { } }
        public string UsageModel { get { throw null; } set { } }
        public int? VerificationDelayInSeconds { get { throw null; } set { } }
        public int? WriteBackDelayInSeconds { get { throw null; } set { } }
    }
    public partial class NfsAccessPolicy
    {
        public NfsAccessPolicy(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.Models.NfsAccessRule> accessRules) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageCache.Models.NfsAccessRule> AccessRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NfsAccessRule
    {
        public NfsAccessRule(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope scope, Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess access) { }
        public Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess Access { get { throw null; } set { } }
        public bool? AllowSubmountAccess { get { throw null; } set { } }
        public bool? AllowSuid { get { throw null; } set { } }
        public string AnonymousGID { get { throw null; } set { } }
        public string AnonymousUID { get { throw null; } set { } }
        public bool? EnableRootSquash { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsAccessRuleAccess : System.IEquatable<Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsAccessRuleAccess(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess No { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess left, Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess left, Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsAccessRuleScope : System.IEquatable<Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsAccessRuleScope(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope Default { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope Host { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope Network { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope left, Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope left, Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutstandingCondition
    {
        internal OutstandingCondition() { }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class PrimingJob
    {
        public PrimingJob(string primingJobName, System.Uri primingManifestUri) { }
        public string PrimingJobDetails { get { throw null; } }
        public string PrimingJobId { get { throw null; } }
        public string PrimingJobName { get { throw null; } set { } }
        public double? PrimingJobPercentComplete { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.PrimingJobState? PrimingJobState { get { throw null; } }
        public string PrimingJobStatus { get { throw null; } }
        public System.Uri PrimingManifestUri { get { throw null; } set { } }
    }
    public partial class PrimingJobContent
    {
        public PrimingJobContent(string primingJobId) { }
        public string PrimingJobId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrimingJobState : System.IEquatable<Azure.ResourceManager.StorageCache.Models.PrimingJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrimingJobState(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.PrimingJobState Complete { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.PrimingJobState Paused { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.PrimingJobState Queued { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.PrimingJobState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.PrimingJobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.PrimingJobState left, Azure.ResourceManager.StorageCache.Models.PrimingJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.PrimingJobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.PrimingJobState left, Azure.ResourceManager.StorageCache.Models.PrimingJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheActiveDirectorySettings
    {
        public StorageCacheActiveDirectorySettings(System.Net.IPAddress primaryDnsIPAddress, string domainName, string domainNetBiosName, string cacheNetBiosName) { }
        public string CacheNetBiosName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheActiveDirectorySettingsCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.DomainJoinedType? DomainJoined { get { throw null; } }
        public string DomainName { get { throw null; } set { } }
        public string DomainNetBiosName { get { throw null; } set { } }
        public System.Net.IPAddress PrimaryDnsIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress SecondaryDnsIPAddress { get { throw null; } set { } }
    }
    public partial class StorageCacheActiveDirectorySettingsCredentials
    {
        public StorageCacheActiveDirectorySettingsCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class StorageCacheDirectorySettings
    {
        public StorageCacheDirectorySettings() { }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheActiveDirectorySettings ActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadSettings UsernameDownload { get { throw null; } set { } }
    }
    public partial class StorageCacheEncryptionKeyVaultKeyReference
    {
        public StorageCacheEncryptionKeyVaultKeyReference(System.Uri keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class StorageCacheEncryptionSettings
    {
        public StorageCacheEncryptionSettings() { }
        public bool? EnableRotationToLatestKeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheEncryptionKeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheFirmwareStatusType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheFirmwareStatusType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType Available { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType left, Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType left, Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheHealth
    {
        internal StorageCacheHealth() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.OutstandingCondition> Conditions { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType? State { get { throw null; } }
        public string StatusDescription { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheHealthStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheHealthStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Degraded { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Down { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Flushing { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Healthy { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType StartFailed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Stopped { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Stopping { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Transitioning { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Unknown { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType Upgrading { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType WaitingForKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType left, Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType left, Azure.ResourceManager.StorageCache.Models.StorageCacheHealthStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheNetworkSettings
    {
        public StorageCacheNetworkSettings() { }
        public string DnsSearchDomain { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> DnsServers { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public string NtpServer { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> UtilityAddresses { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheProvisioningStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheProvisioningStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Cancelled { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Creating { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Deleting { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType left, Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType left, Azure.ResourceManager.StorageCache.Models.StorageCacheProvisioningStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheRestriction
    {
        internal StorageCacheRestriction() { }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode? ReasonCode { get { throw null; } }
        public string RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode left, Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode left, Azure.ResourceManager.StorageCache.Models.StorageCacheRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheSku
    {
        internal StorageCacheSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.StorageCacheSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.StorageCacheSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.StorageCacheRestriction> Restrictions { get { throw null; } }
    }
    public partial class StorageCacheSkuCapability
    {
        internal StorageCacheSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageCacheSkuLocationInfo
    {
        internal StorageCacheSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class StorageCacheUpgradeSettings
    {
        public StorageCacheUpgradeSettings() { }
        public bool? EnableUpgradeSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } set { } }
    }
    public partial class StorageCacheUpgradeStatus
    {
        internal StorageCacheUpgradeStatus() { }
        public string CurrentFirmwareVersion { get { throw null; } }
        public System.DateTimeOffset? FirmwareUpdateDeadline { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheFirmwareStatusType? FirmwareUpdateStatus { get { throw null; } }
        public System.DateTimeOffset? LastFirmwareUpdate { get { throw null; } }
        public string PendingFirmwareVersion { get { throw null; } }
    }
    public partial class StorageCacheUsage
    {
        internal StorageCacheUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class StorageCacheUsageModel
    {
        internal StorageCacheUsageModel() { }
        public string DisplayDescription { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string TargetType { get { throw null; } }
    }
    public partial class StorageCacheUsageName
    {
        internal StorageCacheUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageCacheUsernameDownloadCredential
    {
        public StorageCacheUsernameDownloadCredential() { }
        public string BindDistinguishedName { get { throw null; } set { } }
        public string BindPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheUsernameDownloadedType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheUsernameDownloadedType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType Error { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType No { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType left, Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType left, Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageCacheUsernameDownloadSettings
    {
        public StorageCacheUsernameDownloadSettings() { }
        public bool? AutoDownloadCertificate { get { throw null; } set { } }
        public System.Uri CaCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadCredential Credentials { get { throw null; } set { } }
        public bool? EnableExtendedGroups { get { throw null; } set { } }
        public bool? EncryptLdapConnection { get { throw null; } set { } }
        public System.Uri GroupFileUri { get { throw null; } set { } }
        public string LdapBaseDN { get { throw null; } set { } }
        public string LdapServer { get { throw null; } set { } }
        public bool? RequireValidCertificate { get { throw null; } set { } }
        public System.Uri UserFileUri { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameDownloadedType? UsernameDownloaded { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType? UsernameSource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageCacheUsernameSourceType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageCacheUsernameSourceType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType AD { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType File { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType Ldap { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType left, Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType left, Azure.ResourceManager.StorageCache.Models.StorageCacheUsernameSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTargetOperationalStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTargetOperationalStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType Busy { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType Flushing { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType Ready { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType left, Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType left, Azure.ResourceManager.StorageCache.Models.StorageTargetOperationalStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageTargetSpaceAllocation
    {
        public StorageTargetSpaceAllocation() { }
        public int? AllocationPercentage { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTargetType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.StorageTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTargetType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetType BlobNfs { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetType Clfs { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetType Nfs3 { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.StorageTargetType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.StorageTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.StorageTargetType left, Azure.ResourceManager.StorageCache.Models.StorageTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.StorageTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.StorageTargetType left, Azure.ResourceManager.StorageCache.Models.StorageTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
