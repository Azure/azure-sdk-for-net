namespace Azure.ResourceManager.StorageCache
{
    public partial class CacheCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.CacheResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.CacheResource>, System.Collections.IEnumerable
    {
        protected CacheCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.CacheResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheName, Azure.ResourceManager.StorageCache.CacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StorageCache.CacheResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheName, Azure.ResourceManager.StorageCache.CacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> Get(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StorageCache.CacheResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StorageCache.CacheResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> GetAsync(string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StorageCache.CacheResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StorageCache.CacheResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StorageCache.CacheResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.CacheResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CacheData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CacheData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? CacheSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheDirectorySettings DirectoryServicesSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheHealth Health { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> MountAddresses { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.CacheNetworkSettings NetworkSettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.PrimingJob> PrimingJobs { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.ProvisioningStateType? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageCache.Models.NfsAccessPolicy> SecurityAccessPolicies { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> SpaceAllocation { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheUpgradeStatus UpgradeStatus { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class CacheResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CacheResource() { }
        public virtual Azure.ResourceManager.StorageCache.CacheData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DebugInfo(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DebugInfoAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Flush(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FlushAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource> GetStorageTarget(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource>> GetStorageTargetAsync(string storageTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StorageCache.StorageTargetCollection GetStorageTargets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PausePrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PausePrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResumePrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumePrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SpaceAllocation(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> spaceAllocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SpaceAllocationAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StorageCache.Models.StorageTargetSpaceAllocation> spaceAllocation = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartPrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJob primingjob = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartPrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJob primingjob = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopPrimingJob(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopPrimingJobAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StorageCache.Models.PrimingJobIdParameter primingJobId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> Update(Azure.ResourceManager.StorageCache.CacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> UpdateAsync(Azure.ResourceManager.StorageCache.CacheData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeFirmware(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeFirmwareAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StorageCacheExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StorageCache.Models.AscOperation> GetAscOperation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.Models.AscOperation>> GetAscOperationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.ResourceUsage> GetAscUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.ResourceUsage> GetAscUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.StorageCache.CacheResource> GetCache(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.CacheResource>> GetCacheAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cacheName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageCache.CacheResource GetCacheResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StorageCache.CacheCollection GetCaches(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.CacheResource> GetCaches(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.CacheResource> GetCachesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.ResourceSku> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.ResourceSku> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StorageCache.StorageTargetResource GetStorageTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StorageCache.Models.UsageModel> GetUsageModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StorageCache.Models.UsageModel> GetUsageModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string ClfsTarget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StorageCache.Models.NamespaceJunction> Junctions { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.Nfs3Target Nfs3 { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.ProvisioningStateType? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.OperationalStateType? State { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation DnsRefresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DnsRefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Flush(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FlushAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StorageCache.StorageTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Invalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InvalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AscOperation
    {
        internal AscOperation() { }
        public string EndTime { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.ErrorResponse Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Output { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class BlobNfsTarget
    {
        public BlobNfsTarget() { }
        public string Target { get { throw null; } set { } }
        public string UsageModel { get { throw null; } set { } }
    }
    public partial class CacheActiveDirectorySettings
    {
        public CacheActiveDirectorySettings(string primaryDnsIPAddress, string domainName, string domainNetBiosName, string cacheNetBiosName) { }
        public string CacheNetBiosName { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheActiveDirectorySettingsCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.DomainJoinedType? DomainJoined { get { throw null; } }
        public string DomainName { get { throw null; } set { } }
        public string DomainNetBiosName { get { throw null; } set { } }
        public string PrimaryDnsIPAddress { get { throw null; } set { } }
        public string SecondaryDnsIPAddress { get { throw null; } set { } }
    }
    public partial class CacheActiveDirectorySettingsCredentials
    {
        public CacheActiveDirectorySettingsCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class CacheDirectorySettings
    {
        public CacheDirectorySettings() { }
        public Azure.ResourceManager.StorageCache.Models.CacheActiveDirectorySettings ActiveDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheUsernameDownloadSettings UsernameDownload { get { throw null; } set { } }
    }
    public partial class CacheEncryptionSettings
    {
        public CacheEncryptionSettings() { }
        public Azure.ResourceManager.StorageCache.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
    }
    public partial class CacheHealth
    {
        internal CacheHealth() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.Condition> Conditions { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.HealthStateType? State { get { throw null; } }
        public string StatusDescription { get { throw null; } }
    }
    public partial class CacheNetworkSettings
    {
        public CacheNetworkSettings() { }
        public string DnsSearchDomain { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public string NtpServer { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> UtilityAddresses { get { throw null; } }
    }
    public partial class CacheUpgradeSettings
    {
        public CacheUpgradeSettings() { }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } set { } }
        public bool? UpgradeScheduleEnabled { get { throw null; } set { } }
    }
    public partial class CacheUpgradeStatus
    {
        internal CacheUpgradeStatus() { }
        public string CurrentFirmwareVersion { get { throw null; } }
        public System.DateTimeOffset? FirmwareUpdateDeadline { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.FirmwareStatusType? FirmwareUpdateStatus { get { throw null; } }
        public System.DateTimeOffset? LastFirmwareUpdate { get { throw null; } }
        public string PendingFirmwareVersion { get { throw null; } }
    }
    public partial class CacheUsernameDownloadSettings
    {
        public CacheUsernameDownloadSettings() { }
        public bool? AutoDownloadCertificate { get { throw null; } set { } }
        public System.Uri CaCertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.CacheUsernameDownloadSettingsCredentials Credentials { get { throw null; } set { } }
        public bool? EncryptLdapConnection { get { throw null; } set { } }
        public bool? ExtendedGroups { get { throw null; } set { } }
        public System.Uri GroupFileUri { get { throw null; } set { } }
        public string LdapBaseDN { get { throw null; } set { } }
        public string LdapServer { get { throw null; } set { } }
        public bool? RequireValidCertificate { get { throw null; } set { } }
        public System.Uri UserFileUri { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType? UsernameDownloaded { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.UsernameSource? UsernameSource { get { throw null; } set { } }
    }
    public partial class CacheUsernameDownloadSettingsCredentials
    {
        public CacheUsernameDownloadSettingsCredentials() { }
        public string BindDn { get { throw null; } set { } }
        public string BindPassword { get { throw null; } set { } }
    }
    public partial class Condition
    {
        internal Condition() { }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
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
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareStatusType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.FirmwareStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareStatusType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.FirmwareStatusType Available { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.FirmwareStatusType Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.FirmwareStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.FirmwareStatusType left, Azure.ResourceManager.StorageCache.Models.FirmwareStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.FirmwareStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.FirmwareStatusType left, Azure.ResourceManager.StorageCache.Models.FirmwareStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.HealthStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Degraded { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Down { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Flushing { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Healthy { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType StartFailed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Stopped { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Stopping { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Transitioning { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Unknown { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType Upgrading { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.HealthStateType WaitingForKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.HealthStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.HealthStateType left, Azure.ResourceManager.StorageCache.Models.HealthStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.HealthStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.HealthStateType left, Azure.ResourceManager.StorageCache.Models.HealthStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKeyReference
    {
        public KeyVaultKeyReference(System.Uri keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
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
        public string AnonymousGID { get { throw null; } set { } }
        public string AnonymousUID { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public bool? RootSquash { get { throw null; } set { } }
        public Azure.ResourceManager.StorageCache.Models.NfsAccessRuleScope Scope { get { throw null; } set { } }
        public bool? SubmountAccess { get { throw null; } set { } }
        public bool? Suid { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NfsAccessRuleAccess : System.IEquatable<Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NfsAccessRuleAccess(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess No { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess Ro { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.NfsAccessRuleAccess Rw { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.OperationalStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.OperationalStateType Busy { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.OperationalStateType Flushing { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.OperationalStateType Ready { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.OperationalStateType Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.OperationalStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.OperationalStateType left, Azure.ResourceManager.StorageCache.Models.OperationalStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.OperationalStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.OperationalStateType left, Azure.ResourceManager.StorageCache.Models.OperationalStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrimingJob
    {
        public PrimingJob(string primingJobName, string primingManifestUri) { }
        public string PrimingJobDetails { get { throw null; } }
        public string PrimingJobId { get { throw null; } }
        public string PrimingJobName { get { throw null; } set { } }
        public double? PrimingJobPercentComplete { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.PrimingJobState? PrimingJobState { get { throw null; } }
        public string PrimingJobStatus { get { throw null; } }
        public string PrimingManifestUri { get { throw null; } set { } }
    }
    public partial class PrimingJobIdParameter
    {
        public PrimingJobIdParameter(string primingJobId) { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.ProvisioningStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Cancelled { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Creating { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Deleting { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ProvisioningStateType Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.ProvisioningStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.ProvisioningStateType left, Azure.ResourceManager.StorageCache.Models.ProvisioningStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.ProvisioningStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.ProvisioningStateType left, Azure.ResourceManager.StorageCache.Models.ProvisioningStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.ResourceManager.StorageCache.Models.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.ReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.ReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.ReasonCode left, Azure.ResourceManager.StorageCache.Models.ReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.ReasonCode left, Azure.ResourceManager.StorageCache.Models.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StorageCache.Models.Restriction> Restrictions { get { throw null; } }
    }
    public partial class ResourceSkuCapabilities
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceUsage
    {
        internal ResourceUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.StorageCache.Models.ResourceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ResourceUsageName
    {
        internal ResourceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.ResourceManager.StorageCache.Models.ReasonCode? ReasonCode { get { throw null; } }
        public string RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
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
    public partial class UsageModel
    {
        internal UsageModel() { }
        public string DisplayDescription { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string TargetType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsernameDownloadedType : System.IEquatable<Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsernameDownloadedType(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType Error { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType No { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType left, Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType left, Azure.ResourceManager.StorageCache.Models.UsernameDownloadedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsernameSource : System.IEquatable<Azure.ResourceManager.StorageCache.Models.UsernameSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsernameSource(string value) { throw null; }
        public static Azure.ResourceManager.StorageCache.Models.UsernameSource AD { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.UsernameSource File { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.UsernameSource Ldap { get { throw null; } }
        public static Azure.ResourceManager.StorageCache.Models.UsernameSource None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StorageCache.Models.UsernameSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StorageCache.Models.UsernameSource left, Azure.ResourceManager.StorageCache.Models.UsernameSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.StorageCache.Models.UsernameSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StorageCache.Models.UsernameSource left, Azure.ResourceManager.StorageCache.Models.UsernameSource right) { throw null; }
        public override string ToString() { throw null; }
    }
}
