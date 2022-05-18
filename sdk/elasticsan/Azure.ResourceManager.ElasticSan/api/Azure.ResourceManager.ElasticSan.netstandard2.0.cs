namespace Azure.ResourceManager.ElasticSan
{
    public partial class ElasticSanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>, System.Collections.IEnumerable
    {
        protected ElasticSanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticSanName, Azure.ResourceManager.ElasticSan.ElasticSanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticSanName, Azure.ResourceManager.ElasticSan.ElasticSanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> Get(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetAsync(string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticSanData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long? BaseSizeTiB { get { throw null; } set { } }
        public long? ElasticSanVolumeGroupCount { get { throw null; } }
        public long? ExtendedCapacitySizeTiB { get { throw null; } set { } }
        public long? ProvisionedMbps { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ProvisioningStates? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSku Sku { get { throw null; } set { } }
        public long? TotalElasticSanVolumeSizeGiB { get { throw null; } }
        public long? TotalIops { get { throw null; } }
        public long? TotalMbps { get { throw null; } }
    }
    public static partial class ElasticSanExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetElasticSanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string elasticSanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanResource GetElasticSanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanCollection GetElasticSans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanResource> GetElasticSansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource GetElasticSanVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource GetElasticSanVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ElasticSan.Models.ResourceTypeSku> GetSkus(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.Models.ResourceTypeSku> GetSkusAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeleteElasticSanVolumeGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeleteElasticSanVolumeGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetElasticSanVolumeGroup(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetElasticSanVolumeGroupAsync(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupCollection GetElasticSanVolumeGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>, System.Collections.IEnumerable
    {
        protected ElasticSanVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticSanVolumeName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticSanVolumeName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Get(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetAsync(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanVolumeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticSanVolumeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ElasticSan.Models.SourceCreationData CreationData { get { throw null; } set { } }
        public string ElasticSanVolumeId { get { throw null; } }
        public long? SizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.IscsiTargetInfo StorageTarget { get { throw null; } }
    }
    public partial class ElasticSanVolumeGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>, System.Collections.IEnumerable
    {
        protected ElasticSanVolumeGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string elasticSanVolumeGroupName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string elasticSanVolumeGroupName, Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Get(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetAsync(string elasticSanVolumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticSanVolumeGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticSanVolumeGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ElasticSan.Models.EncryptionType? Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.StorageTargetType? ProtocolType { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ProvisioningStates? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ElasticSan.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class ElasticSanVolumeGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanVolumeGroupResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string elasticSanVolumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeleteVolumes = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeleteVolumes = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> GetElasticSanVolume(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetElasticSanVolumeAsync(string elasticSanVolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeCollection GetElasticSanVolumes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanElasticSanVolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanElasticSanVolumeGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticSanVolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticSanVolumeResource() { }
        public virtual Azure.ResourceManager.ElasticSan.ElasticSanVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string elasticSanName, string elasticSanVolumeGroupName, string elasticSanVolumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanElasticSanVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ElasticSan.ElasticSanVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ElasticSan.Models.ElasticSanElasticSanVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ElasticSan.Models
{
    public partial class ElasticSanElasticSanVolumeGroupPatch
    {
        public ElasticSanElasticSanVolumeGroupPatch() { }
        public Azure.ResourceManager.ElasticSan.Models.EncryptionType? Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.StorageTargetType? ProtocolType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ElasticSan.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class ElasticSanElasticSanVolumePatch
    {
        public ElasticSanElasticSanVolumePatch() { }
        public long? SizeGiB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ElasticSanPatch
    {
        public ElasticSanPatch() { }
        public long? BaseSizeTiB { get { throw null; } set { } }
        public long? ExtendedCapacitySizeTiB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ElasticSanSku
    {
        public ElasticSanSku() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanSkuName : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName left, Azure.ResourceManager.ElasticSan.Models.ElasticSanSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticSanTier : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ElasticSanTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticSanTier(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanTier Hero { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanTier Hub { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ElasticSanTier Satellite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ElasticSanTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ElasticSanTier left, Azure.ResourceManager.ElasticSan.Models.ElasticSanTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ElasticSanTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ElasticSanTier left, Azure.ResourceManager.ElasticSan.Models.ElasticSanTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ElasticSanVolumeCreateOption
    {
        None = 0,
        FromElasticSanVolume = 1,
        FromDiskSnapshot = 2,
        Export = 3,
    }
    public partial class ElasticSanVolumeTierInfo
    {
        internal ElasticSanVolumeTierInfo() { }
        public long? MaxConnectedClientCount { get { throw null; } }
        public long? MaxIops { get { throw null; } }
        public long? MaxIopsPerGiB { get { throw null; } }
        public long? MaxMbps { get { throw null; } }
        public long? MaxMbpsPerGiB { get { throw null; } }
        public long? MaxSizeGiB { get { throw null; } }
        public long? MinIncrementSizeGiB { get { throw null; } }
        public long? MinSizeGiB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionType : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.EncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.EncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.EncryptionType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.EncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.EncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.EncryptionType left, Azure.ResourceManager.ElasticSan.Models.EncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.EncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.EncryptionType left, Azure.ResourceManager.ElasticSan.Models.EncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IscsiTargetInfo
    {
        internal IscsiTargetInfo() { }
        public Azure.ResourceManager.ElasticSan.Models.ProvisioningStates? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.OperationalStatus? Status { get { throw null; } }
        public string TargetIqn { get { throw null; } }
        public string TargetPortalHostname { get { throw null; } }
        public int? TargetPortalPort { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalStatus : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.OperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus StoppedDeallocated { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.OperationalStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.OperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.OperationalStatus left, Azure.ResourceManager.ElasticSan.Models.OperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.OperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.OperationalStatus left, Azure.ResourceManager.ElasticSan.Models.OperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStates : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.ProvisioningStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStates(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Canceled { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Creating { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Deleting { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Failed { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Invalid { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Pending { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.ProvisioningStates Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.ProvisioningStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.ProvisioningStates left, Azure.ResourceManager.ElasticSan.Models.ProvisioningStates right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.ProvisioningStates (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.ProvisioningStates left, Azure.ResourceManager.ElasticSan.Models.ProvisioningStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeSku
    {
        internal ResourceTypeSku() { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeTierInfo ElasticSanVolume { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ElasticSan.Models.SkuLocationInfo> LocationInfo { get { throw null; } }
        public long? MaxElasticSanVolumeCount { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.SanTierInfo San { get { throw null; } }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanSku Sku { get { throw null; } }
    }
    public partial class SanTierInfo
    {
        internal SanTierInfo() { }
        public long? IopsPerBaseTiB { get { throw null; } }
        public long? MaxElasticSanVolumeGroupCount { get { throw null; } }
        public long? MaxIops { get { throw null; } }
        public long? MaxMbps { get { throw null; } }
        public long? MaxSizeTiB { get { throw null; } }
        public long? MbpsPerBaseTiB { get { throw null; } }
        public long? MinIncrementSizeTiB { get { throw null; } }
        public long? MinSizeTiB { get { throw null; } }
    }
    public partial class SkuLocationInfo
    {
        internal SkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class SourceCreationData
    {
        public SourceCreationData(Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption createSource) { }
        public Azure.ResourceManager.ElasticSan.Models.ElasticSanVolumeCreateOption CreateSource { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageTargetType : System.IEquatable<Azure.ResourceManager.ElasticSan.Models.StorageTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageTargetType(string value) { throw null; }
        public static Azure.ResourceManager.ElasticSan.Models.StorageTargetType Iscsi { get { throw null; } }
        public static Azure.ResourceManager.ElasticSan.Models.StorageTargetType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ElasticSan.Models.StorageTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ElasticSan.Models.StorageTargetType left, Azure.ResourceManager.ElasticSan.Models.StorageTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ElasticSan.Models.StorageTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ElasticSan.Models.StorageTargetType left, Azure.ResourceManager.ElasticSan.Models.StorageTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string virtualNetworkResourceId) { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.ElasticSan.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkResourceId { get { throw null; } set { } }
    }
    public enum VirtualNetworkRuleState
    {
        Provisioning = 0,
        Deprovisioning = 1,
        Succeeded = 2,
        Failed = 3,
        NetworkSourceDeleted = 4,
    }
}
