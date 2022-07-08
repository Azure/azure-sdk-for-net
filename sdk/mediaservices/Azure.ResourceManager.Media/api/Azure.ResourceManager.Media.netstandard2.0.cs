namespace Azure.ResourceManager.Media
{
    public partial class AccountFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AccountFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AccountFilterResource>, System.Collections.IEnumerable
    {
        protected AccountFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AccountFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.AccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AccountFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.AccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AccountFilterResource> Get(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.AccountFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.AccountFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AccountFilterResource>> GetAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.AccountFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AccountFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.AccountFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AccountFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountFilterData : Azure.ResourceManager.Models.ResourceData
    {
        public AccountFilterData() { }
        public int? FirstQualityBitrate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.PresentationTimeRange PresentationTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackSelection> Tracks { get { throw null; } }
    }
    public partial class AccountFilterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountFilterResource() { }
        public virtual Azure.ResourceManager.Media.AccountFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string filterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AccountFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AccountFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AccountFilterResource> Update(Azure.ResourceManager.Media.AccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AccountFilterResource>> UpdateAsync(Azure.ResourceManager.Media.AccountFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AssetResource>, System.Collections.IEnumerable
    {
        protected AssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.AssetResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.AssetResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.AssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.AssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssetData : Azure.ResourceManager.Models.ResourceData
    {
        public AssetData() { }
        public string AlternateId { get { throw null; } set { } }
        public System.Guid? AssetId { get { throw null; } }
        public string Container { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat? StorageEncryptionFormat { get { throw null; } }
    }
    public partial class AssetFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AssetFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AssetFilterResource>, System.Collections.IEnumerable
    {
        protected AssetFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AssetFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.AssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.AssetFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string filterName, Azure.ResourceManager.Media.AssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetFilterResource> Get(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.AssetFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.AssetFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetFilterResource>> GetAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.AssetFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.AssetFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.AssetFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.AssetFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssetFilterData : Azure.ResourceManager.Models.ResourceData
    {
        public AssetFilterData() { }
        public int? FirstQualityBitrate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.PresentationTimeRange PresentationTimeRange { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackSelection> Tracks { get { throw null; } }
    }
    public partial class AssetFilterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssetFilterResource() { }
        public virtual Azure.ResourceManager.Media.AssetFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string filterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetFilterResource> Update(Azure.ResourceManager.Media.AssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetFilterResource>> UpdateAsync(Azure.ResourceManager.Media.AssetFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssetResource() { }
        public virtual Azure.ResourceManager.Media.AssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetFilterResource> GetAssetFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetFilterResource>> GetAssetFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.AssetFilterCollection GetAssetFilters() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.AssetContainerSas> GetContainerSas(Azure.ResourceManager.Media.Models.ListContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.AssetContainerSas>> GetContainerSasAsync(Azure.ResourceManager.Media.Models.ListContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionData> GetEncryptionKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionData>> GetEncryptionKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> GetMediaServiceAssetTrack(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>> GetMediaServiceAssetTrackAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServiceAssetTrackCollection GetMediaServiceAssetTracks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.ListStreamingLocatorsResponse> GetStreamingLocators(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.ListStreamingLocatorsResponse>> GetStreamingLocatorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetResource> Update(Azure.ResourceManager.Media.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetResource>> UpdateAsync(Azure.ResourceManager.Media.AssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssetTrackData : Azure.ResourceManager.Models.ResourceData
    {
        public AssetTrackData() { }
        public Azure.ResourceManager.Media.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.TrackBase Track { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>, System.Collections.IEnumerable
    {
        protected ContentKeyPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.ContentKeyPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contentKeyPolicyName, Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.ContentKeyPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contentKeyPolicyName, Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Get(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.ContentKeyPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.ContentKeyPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.ContentKeyPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentKeyPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ContentKeyPolicyData() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> Options { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
    }
    public partial class ContentKeyPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContentKeyPolicyResource() { }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string contentKeyPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties> GetPolicyPropertiesWithSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.ContentKeyPolicyProperties>> GetPolicyPropertiesWithSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> Update(Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> UpdateAsync(Azure.ResourceManager.Media.ContentKeyPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.JobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.JobResource>, System.Collections.IEnumerable
    {
        protected JobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.JobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.JobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.JobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.JobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.JobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.JobResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.JobResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.JobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.JobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.JobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.JobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.JobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobData : Azure.ResourceManager.Models.ResourceData
    {
        public JobData() { }
        public System.Collections.Generic.IDictionary<string, string> CorrelationData { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobInput Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JobOutput> Outputs { get { throw null; } }
        public Azure.ResourceManager.Media.Models.Priority? Priority { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobState? State { get { throw null; } }
    }
    public partial class JobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobResource() { }
        public virtual Azure.ResourceManager.Media.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.JobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.JobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.JobResource> Update(Azure.ResourceManager.Media.JobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.JobResource>> UpdateAsync(Azure.ResourceManager.Media.JobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LiveEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.LiveEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.LiveEventResource>, System.Collections.IEnumerable
    {
        protected LiveEventCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveEventResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string liveEventName, Azure.ResourceManager.Media.LiveEventData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveEventResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string liveEventName, Azure.ResourceManager.Media.LiveEventData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> Get(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.LiveEventResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.LiveEventResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> GetAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.LiveEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.LiveEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.LiveEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.LiveEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LiveEventData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LiveEventData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventEncoding Encoding { get { throw null; } set { } }
        public string HostnamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInput Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveEventPreview Preview { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveEventResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamOptionsFlag> StreamOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventTranscription> Transcriptions { get { throw null; } }
        public bool? UseStaticHostname { get { throw null; } set { } }
    }
    public partial class LiveEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LiveEventResource() { }
        public virtual Azure.ResourceManager.Media.LiveEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Allocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AllocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string liveEventName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveOutputResource> GetLiveOutput(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveOutputResource>> GetLiveOutputAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.LiveOutputCollection GetLiveOutputs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reset(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.LiveEventActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.LiveEventActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveEventResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.LiveEventData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveEventResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.LiveEventData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LiveOutputCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.LiveOutputResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.LiveOutputResource>, System.Collections.IEnumerable
    {
        protected LiveOutputCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveOutputResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string liveOutputName, Azure.ResourceManager.Media.LiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveOutputResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string liveOutputName, Azure.ResourceManager.Media.LiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveOutputResource> Get(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.LiveOutputResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.LiveOutputResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveOutputResource>> GetAsync(string liveOutputName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.LiveOutputResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.LiveOutputResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.LiveOutputResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.LiveOutputResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LiveOutputData : Azure.ResourceManager.Models.ResourceData
    {
        public LiveOutputData() { }
        public System.TimeSpan? ArchiveWindowLength { get { throw null; } set { } }
        public string AssetName { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public int? HlsFragmentsPerTsSegment { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string ManifestName { get { throw null; } set { } }
        public long? OutputSnapTime { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.LiveOutputResourceState? ResourceState { get { throw null; } }
    }
    public partial class LiveOutputResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LiveOutputResource() { }
        public virtual Azure.ResourceManager.Media.LiveOutputData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string liveEventName, string liveOutputName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveOutputResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveOutputResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveOutputResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.LiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.LiveOutputResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.LiveOutputData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationMediaServicesOperationResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected LocationMediaServicesOperationResultCollection() { }
        public virtual Azure.Response<bool> Exists(string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> Get(string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> GetAsync(string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationMediaServicesOperationResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationMediaServicesOperationResultResource() { }
        public virtual Azure.ResourceManager.Media.MediaServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MediaExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Media.Models.EntityNameAvailabilityCheckOutput> CheckNameAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Media.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.EntityNameAvailabilityCheckOutput>> CheckNameAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.Media.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.AccountFilterResource GetAccountFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.AssetFilterResource GetAssetFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.AssetResource GetAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.ContentKeyPolicyResource GetContentKeyPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.JobResource GetJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.LiveEventResource GetLiveEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.LiveOutputResource GetLiveOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource> GetLocationMediaServicesOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource>> GetLocationMediaServicesOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.LocationMediaServicesOperationResultResource GetLocationMediaServicesOperationResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.LocationMediaServicesOperationResultCollection GetLocationMediaServicesOperationResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource GetMediaPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaPrivateLinkResource GetMediaPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> GetMediaservice(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource GetMediaServiceAssetTrackOperationResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServiceAssetTrackResource GetMediaServiceAssetTrackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> GetMediaserviceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaserviceResource GetMediaserviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaserviceCollection GetMediaservices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Media.MediaserviceResource> GetMediaservices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Media.MediaserviceResource> GetMediaservicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.Models.MediaServiceOperationStatus> GetMediaServicesOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaServiceOperationStatus>> GetMediaServicesOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.StreamingEndpointResource GetStreamingEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingLocatorResource GetStreamingLocatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingPolicyResource GetStreamingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.TransformResource GetTransformResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MediaPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MediaPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MediaPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Media.MediaPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MediaPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MediaServiceAssetTrackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>, System.Collections.IEnumerable
    {
        protected MediaServiceAssetTrackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.AssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.AssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> Get(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>> GetAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServiceAssetTrackOperationResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected MediaServiceAssetTrackOperationResultCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServiceAssetTrackOperationResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServiceAssetTrackOperationResultResource() { }
        public virtual Azure.ResourceManager.Media.AssetTrackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string trackName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServiceAssetTrackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServiceAssetTrackResource() { }
        public virtual Azure.ResourceManager.Media.AssetTrackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string trackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource> GetMediaServiceAssetTrackOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultResource>> GetMediaServiceAssetTrackOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServiceAssetTrackOperationResultCollection GetMediaServiceAssetTrackOperationResults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.AssetTrackOperationStatus> GetOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.AssetTrackOperationStatus>> GetOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServiceAssetTrackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.AssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServiceAssetTrackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.AssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateTrackData(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateTrackDataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaserviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaserviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaserviceResource>, System.Collections.IEnumerable
    {
        protected MediaserviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaserviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaserviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaserviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaserviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaserviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaserviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaserviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaserviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MediaServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServiceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StorageAuthentication? StorageAuthentication { get { throw null; } set { } }
    }
    public partial class MediaserviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaserviceResource() { }
        public virtual Azure.ResourceManager.Media.MediaServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AccountFilterResource> GetAccountFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AccountFilterResource>> GetAccountFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.AccountFilterCollection GetAccountFilters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetResource> GetAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetResource>> GetAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.AssetCollection GetAssets() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyCollection GetContentKeyPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetContentKeyPolicy(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetContentKeyPolicyAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.EdgePolicies> GetEdgePolicies(Azure.ResourceManager.Media.Models.ListEdgePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.EdgePolicies>> GetEdgePoliciesAsync(Azure.ResourceManager.Media.Models.ListEdgePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> GetLiveEvent(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> GetLiveEventAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.LiveEventCollection GetLiveEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource> GetMediaPrivateEndpointConnection(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionResource>> GetMediaPrivateEndpointConnectionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaPrivateEndpointConnectionCollection GetMediaPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource> GetMediaPrivateLinkResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaPrivateLinkResource>> GetMediaPrivateLinkResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaPrivateLinkResourceCollection GetMediaPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> GetStreamingEndpoint(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetStreamingEndpointAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingEndpointCollection GetStreamingEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> GetStreamingLocator(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetStreamingLocatorAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingLocatorCollection GetStreamingLocators() { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingPolicyCollection GetStreamingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> GetStreamingPolicy(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetStreamingPolicyAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.TransformResource> GetTransform(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.TransformResource>> GetTransformAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.TransformCollection GetTransforms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaserviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaserviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncStorageKeys(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncStorageKeysAsync(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaserviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaservicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaserviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaservicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>, System.Collections.IEnumerable
    {
        protected StreamingEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingEndpointName, Azure.ResourceManager.Media.StreamingEndpointData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingEndpointName, Azure.ResourceManager.Media.StreamingEndpointData data, bool? autoStart = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> Get(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingEndpointData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StreamingEndpointData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Media.Models.StreamingEndpointAccessControl AccessControl { get { throw null; } set { } }
        public string AvailabilitySetName { get { throw null; } set { } }
        public bool? CdnEnabled { get { throw null; } set { } }
        public string CdnProfile { get { throw null; } set { } }
        public string CdnProvider { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomHostNames { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FreeTrialEndOn { get { throw null; } }
        public string HostName { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public long? MaxCacheAge { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingEndpointResourceState? ResourceState { get { throw null; } }
        public int? ScaleUnits { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ArmStreamingEndpointCurrentSku Sku { get { throw null; } set { } }
    }
    public partial class StreamingEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingEndpointResource() { }
        public virtual Azure.ResourceManager.Media.StreamingEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Scale(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.ArmStreamingEndpointSkuInfo> Skus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.ArmStreamingEndpointSkuInfo> SkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingLocatorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>, System.Collections.IEnumerable
    {
        protected StreamingLocatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingLocatorName, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingLocatorName, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> Get(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingLocatorResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingLocatorResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingLocatorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingLocatorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingLocatorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingLocatorData : Azure.ResourceManager.Models.ResourceData
    {
        public StreamingLocatorData() { }
        public string AlternativeMediaId { get { throw null; } set { } }
        public string AssetName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> ContentKeys { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Guid? StreamingLocatorId { get { throw null; } set { } }
        public string StreamingPolicyName { get { throw null; } set { } }
    }
    public partial class StreamingLocatorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingLocatorResource() { }
        public virtual Azure.ResourceManager.Media.StreamingLocatorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingLocatorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.ListContentKeysResponse> GetContentKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.ListContentKeysResponse>> GetContentKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.ListPathsResponse> GetPaths(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.ListPathsResponse>> GetPathsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingLocatorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingLocatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>, System.Collections.IEnumerable
    {
        protected StreamingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string streamingPolicyName, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string streamingPolicyName, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> Get(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.StreamingPolicyResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.StreamingPolicyResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.StreamingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.StreamingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.StreamingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StreamingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public StreamingPolicyData() { }
        public Azure.ResourceManager.Media.Models.CommonEncryptionCbcs CommonEncryptionCbcs { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CommonEncryptionCenc CommonEncryptionCenc { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnvelopeEncryption EnvelopeEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnabledProtocols NoEncryptionEnabledProtocols { get { throw null; } set { } }
    }
    public partial class StreamingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StreamingPolicyResource() { }
        public virtual Azure.ResourceManager.Media.StreamingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string streamingPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.StreamingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.StreamingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TransformCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.TransformResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.TransformResource>, System.Collections.IEnumerable
    {
        protected TransformCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.TransformResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.TransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.TransformResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.TransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.TransformResource> Get(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.TransformResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.TransformResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.TransformResource>> GetAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.TransformResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.TransformResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.TransformResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.TransformResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TransformData : Azure.ResourceManager.Models.ResourceData
    {
        public TransformData() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TransformOutput> Outputs { get { throw null; } }
    }
    public partial class TransformResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TransformResource() { }
        public virtual Azure.ResourceManager.Media.TransformData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.TransformResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.TransformResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.JobResource> GetJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.JobResource>> GetJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.JobCollection GetJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.TransformResource> Update(Azure.ResourceManager.Media.TransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.TransformResource>> UpdateAsync(Azure.ResourceManager.Media.TransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Media.Models
{
    public partial class AacAudio : Azure.ResourceManager.Media.Models.Audio
    {
        public AacAudio() { }
        public Azure.ResourceManager.Media.Models.AacAudioProfile? Profile { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AacAudioProfile : System.IEquatable<Azure.ResourceManager.Media.Models.AacAudioProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AacAudioProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile AacLc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HeAacV1 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HeAacV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AacAudioProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AacAudioProfile left, Azure.ResourceManager.Media.Models.AacAudioProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AacAudioProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AacAudioProfile left, Azure.ResourceManager.Media.Models.AacAudioProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AbsoluteClipTime : Azure.ResourceManager.Media.Models.ClipTime
    {
        public AbsoluteClipTime(System.TimeSpan time) { }
        public System.TimeSpan Time { get { throw null; } set { } }
    }
    public partial class AccessControl
    {
        public AccessControl() { }
        public Azure.ResourceManager.Media.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPAllowList { get { throw null; } }
    }
    public partial class AccountEncryption
    {
        public AccountEncryption(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType keyType) { }
        public Azure.ResourceManager.Media.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AccountEncryptionKeyType KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountEncryptionKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.AccountEncryptionKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountEncryptionKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AccountEncryptionKeyType CustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AccountEncryptionKeyType SystemKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType left, Azure.ResourceManager.Media.Models.AccountEncryptionKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AccountEncryptionKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AccountEncryptionKeyType left, Azure.ResourceManager.Media.Models.AccountEncryptionKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AkamaiSignatureHeaderAuthenticationKey
    {
        public AkamaiSignatureHeaderAuthenticationKey() { }
        public string Base64Key { get { throw null; } set { } }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisResolution : System.IEquatable<Azure.ResourceManager.Media.Models.AnalysisResolution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisResolution(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AnalysisResolution SourceResolution { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AnalysisResolution StandardDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AnalysisResolution other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AnalysisResolution left, Azure.ResourceManager.Media.Models.AnalysisResolution right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AnalysisResolution (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AnalysisResolution left, Azure.ResourceManager.Media.Models.AnalysisResolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmStreamingEndpointCapacity
    {
        internal ArmStreamingEndpointCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public string ScaleType { get { throw null; } }
    }
    public partial class ArmStreamingEndpointCurrentSku
    {
        public ArmStreamingEndpointCurrentSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class ArmStreamingEndpointSkuInfo
    {
        internal ArmStreamingEndpointSkuInfo() { }
        public Azure.ResourceManager.Media.Models.ArmStreamingEndpointCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SkuName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetContainerPermission : System.IEquatable<Azure.ResourceManager.Media.Models.AssetContainerPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetContainerPermission(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AssetContainerPermission Read { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AssetContainerPermission ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AssetContainerPermission ReadWriteDelete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AssetContainerPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AssetContainerPermission left, Azure.ResourceManager.Media.Models.AssetContainerPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AssetContainerPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AssetContainerPermission left, Azure.ResourceManager.Media.Models.AssetContainerPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetContainerSas
    {
        internal AssetContainerSas() { }
        public System.Collections.Generic.IReadOnlyList<string> AssetContainerSasUrls { get { throw null; } }
    }
    public partial class AssetFileEncryptionMetadata
    {
        internal AssetFileEncryptionMetadata() { }
        public System.Guid AssetFileId { get { throw null; } }
        public string AssetFileName { get { throw null; } }
        public string InitializationVector { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetStorageEncryptionFormat : System.IEquatable<Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetStorageEncryptionFormat(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat MediaStorageClientEncryption { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat left, Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat left, Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetStreamingLocator
    {
        internal AssetStreamingLocator() { }
        public string AssetName { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Guid? StreamingLocatorId { get { throw null; } }
        public string StreamingPolicyName { get { throw null; } }
    }
    public partial class AssetTrackOperationStatus
    {
        internal AssetTrackOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttributeFilter : System.IEquatable<Azure.ResourceManager.Media.Models.AttributeFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttributeFilter(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AttributeFilter All { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AttributeFilter Bottom { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AttributeFilter Top { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AttributeFilter ValueEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AttributeFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AttributeFilter left, Azure.ResourceManager.Media.Models.AttributeFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AttributeFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AttributeFilter left, Azure.ResourceManager.Media.Models.AttributeFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Audio : Azure.ResourceManager.Media.Models.Codec
    {
        public Audio() { }
        public int? Bitrate { get { throw null; } set { } }
        public int? Channels { get { throw null; } set { } }
        public int? SamplingRate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioAnalysisMode : System.IEquatable<Azure.ResourceManager.Media.Models.AudioAnalysisMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioAnalysisMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.AudioAnalysisMode Basic { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AudioAnalysisMode Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.AudioAnalysisMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.AudioAnalysisMode left, Azure.ResourceManager.Media.Models.AudioAnalysisMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.AudioAnalysisMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.AudioAnalysisMode left, Azure.ResourceManager.Media.Models.AudioAnalysisMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioAnalyzerPreset : Azure.ResourceManager.Media.Models.Preset
    {
        public AudioAnalyzerPreset() { }
        public string AudioLanguage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExperimentalOptions { get { throw null; } }
        public Azure.ResourceManager.Media.Models.AudioAnalysisMode? Mode { get { throw null; } set { } }
    }
    public partial class AudioOverlay : Azure.ResourceManager.Media.Models.Overlay
    {
        public AudioOverlay(string inputLabel) : base (default(string)) { }
    }
    public partial class AudioTrack : Azure.ResourceManager.Media.Models.TrackBase
    {
        public AudioTrack() { }
    }
    public partial class AudioTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor
    {
        public AudioTrackDescriptor() { }
        public Azure.ResourceManager.Media.Models.ChannelMapping? ChannelMapping { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlurType : System.IEquatable<Azure.ResourceManager.Media.Models.BlurType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlurType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.BlurType Black { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.BlurType Box { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.BlurType High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.BlurType Low { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.BlurType Med { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.BlurType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.BlurType left, Azure.ResourceManager.Media.Models.BlurType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.BlurType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.BlurType left, Azure.ResourceManager.Media.Models.BlurType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuiltInStandardEncoderPreset : Azure.ResourceManager.Media.Models.Preset
    {
        public BuiltInStandardEncoderPreset(Azure.ResourceManager.Media.Models.EncoderNamedPreset presetName) { }
        public Azure.ResourceManager.Media.Models.PresetConfigurations Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EncoderNamedPreset PresetName { get { throw null; } set { } }
    }
    public partial class CbcsDrmConfiguration
    {
        public CbcsDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration FairPlay { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public string WidevineCustomLicenseAcquisitionUrlTemplate { get { throw null; } set { } }
    }
    public partial class CencDrmConfiguration
    {
        public CencDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public string WidevineCustomLicenseAcquisitionUrlTemplate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelMapping : System.IEquatable<Azure.ResourceManager.Media.Models.ChannelMapping>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelMapping(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ChannelMapping BackLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping BackRight { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping Center { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping FrontLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping FrontRight { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping LowFrequencyEffects { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping StereoLeft { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ChannelMapping StereoRight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ChannelMapping other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ChannelMapping left, Azure.ResourceManager.Media.Models.ChannelMapping right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ChannelMapping (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ChannelMapping left, Azure.ResourceManager.Media.Models.ChannelMapping right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class ClipTime
    {
        public ClipTime() { }
    }
    public partial class Codec
    {
        public Codec() { }
        public string Label { get { throw null; } set { } }
    }
    public partial class CommonEncryptionCbcs
    {
        public CommonEncryptionCbcs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CbcsDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    public partial class CommonEncryptionCenc
    {
        public CommonEncryptionCenc() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CencDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Complexity : System.IEquatable<Azure.ResourceManager.Media.Models.Complexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Complexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.Complexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Complexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Complexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.Complexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.Complexity left, Azure.ResourceManager.Media.Models.Complexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.Complexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.Complexity left, Azure.ResourceManager.Media.Models.Complexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyClearKeyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyClearKeyConfiguration() { }
    }
    public partial class ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyConfiguration() { }
    }
    public partial class ContentKeyPolicyFairPlayConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyFairPlayConfiguration(byte[] ask, string fairPlayPfxPassword, string fairPlayPfx, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType rentalAndLeaseKeyType, long rentalDuration) { }
        public byte[] Ask { get { throw null; } set { } }
        public string FairPlayPfx { get { throw null; } set { } }
        public string FairPlayPfxPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration OfflineRentalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType RentalAndLeaseKeyType { get { throw null; } set { } }
        public long RentalDuration { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyFairPlayOfflineRentalConfiguration
    {
        public ContentKeyPolicyFairPlayOfflineRentalConfiguration(long playbackDurationSeconds, long storageDurationSeconds) { }
        public long PlaybackDurationSeconds { get { throw null; } set { } }
        public long StorageDurationSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyFairPlayRentalAndLeaseKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyFairPlayRentalAndLeaseKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType DualExpiry { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType PersistentLimited { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType PersistentUnlimited { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType Undefined { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyOpenRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyOpenRestriction() { }
    }
    public partial class ContentKeyPolicyOption
    {
        public ContentKeyPolicyOption(Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration configuration, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction restriction) { }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration Configuration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Guid? PolicyOptionId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction Restriction { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyPlayReadyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyPlayReadyConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> licenses) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> Licenses { get { throw null; } }
        public string ResponseCustomData { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader : Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader() { }
    }
    public partial class ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier : Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier(System.Guid? keyId) { }
        public System.Guid? KeyId { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyPlayReadyContentKeyLocation
    {
        public ContentKeyPolicyPlayReadyContentKeyLocation() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyContentType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyContentType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType UltraVioletDownload { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType UltraVioletStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction
    {
        public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction(bool bestEffort, int configurationData) { }
        public bool BestEffort { get { throw null; } set { } }
        public int ConfigurationData { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyPlayReadyLicense
    {
        public ContentKeyPolicyPlayReadyLicense(bool allowTestDevices, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType licenseType, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation contentKeyLocation, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType contentType) { }
        public bool AllowTestDevices { get { throw null; } set { } }
        public System.DateTimeOffset? BeginOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation ContentKeyLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public System.TimeSpan? GracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyPlayRight PlayRight { get { throw null; } set { } }
        public System.TimeSpan? RelativeBeginDate { get { throw null; } set { } }
        public System.TimeSpan? RelativeExpirationDate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyLicenseType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType NonPersistent { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType Persistent { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyPlayReadyPlayRight
    {
        public ContentKeyPolicyPlayReadyPlayRight(bool digitalVideoOnlyContentRestriction, bool imageConstraintForAnalogComponentVideoRestriction, bool imageConstraintForAnalogComputerMonitorRestriction, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption allowPassingVideoContentToUnknownOutput) { }
        public int? AgcAndColorStripeRestriction { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption AllowPassingVideoContentToUnknownOutput { get { throw null; } set { } }
        public int? AnalogVideoOpl { get { throw null; } set { } }
        public int? CompressedDigitalAudioOpl { get { throw null; } set { } }
        public int? CompressedDigitalVideoOpl { get { throw null; } set { } }
        public bool DigitalVideoOnlyContentRestriction { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction ExplicitAnalogTelevisionOutputRestriction { get { throw null; } set { } }
        public System.TimeSpan? FirstPlayExpiration { get { throw null; } set { } }
        public bool ImageConstraintForAnalogComponentVideoRestriction { get { throw null; } set { } }
        public bool ImageConstraintForAnalogComputerMonitorRestriction { get { throw null; } set { } }
        public int? ScmsRestriction { get { throw null; } set { } }
        public int? UncompressedDigitalAudioOpl { get { throw null; } set { } }
        public int? UncompressedDigitalVideoOpl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyUnknownOutputPassingOption : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyUnknownOutputPassingOption(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption Allowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption AllowedWithVideoConstriction { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption NotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyProperties
    {
        internal ContentKeyPolicyProperties() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.ContentKeyPolicyOption> Options { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
    }
    public partial class ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyRestriction() { }
    }
    public partial class ContentKeyPolicyRestrictionTokenKey
    {
        public ContentKeyPolicyRestrictionTokenKey() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyRestrictionTokenType : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyRestrictionTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Jwt { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Swt { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType left, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyRsaTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey
    {
        public ContentKeyPolicyRsaTokenKey(byte[] exponent, byte[] modulus) { }
        public byte[] Exponent { get { throw null; } set { } }
        public byte[] Modulus { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicySymmetricTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey
    {
        public ContentKeyPolicySymmetricTokenKey(byte[] keyValue) { }
        public byte[] KeyValue { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyTokenClaim
    {
        public ContentKeyPolicyTokenClaim() { }
        public string ClaimType { get { throw null; } set { } }
        public string ClaimValue { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyTokenRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyTokenRestriction(string issuer, string audience, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey primaryVerificationKey, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType restrictionTokenType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey> AlternateVerificationKeys { get { throw null; } }
        public string Audience { get { throw null; } set { } }
        public string Issuer { get { throw null; } set { } }
        public string OpenIdConnectDiscoveryDocument { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey PrimaryVerificationKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyTokenClaim> RequiredClaims { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenType RestrictionTokenType { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyUnknownConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyUnknownConfiguration() { }
    }
    public partial class ContentKeyPolicyUnknownRestriction : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyUnknownRestriction() { }
    }
    public partial class ContentKeyPolicyWidevineConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyWidevineConfiguration(string widevineTemplate) { }
        public string WidevineTemplate { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyX509CertificateTokenKey : Azure.ResourceManager.Media.Models.ContentKeyPolicyRestrictionTokenKey
    {
        public ContentKeyPolicyX509CertificateTokenKey(byte[] rawBody) { }
        public byte[] RawBody { get { throw null; } set { } }
    }
    public partial class CopyAudio : Azure.ResourceManager.Media.Models.Codec
    {
        public CopyAudio() { }
    }
    public partial class CopyVideo : Azure.ResourceManager.Media.Models.Codec
    {
        public CopyVideo() { }
    }
    public partial class CrossSiteAccessPolicies
    {
        public CrossSiteAccessPolicies() { }
        public string ClientAccessPolicy { get { throw null; } set { } }
        public string CrossDomainPolicy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.Media.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.DefaultAction left, Azure.ResourceManager.Media.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.DefaultAction left, Azure.ResourceManager.Media.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefaultKey
    {
        public DefaultKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
    }
    public partial class Deinterlace
    {
        public Deinterlace() { }
        public Azure.ResourceManager.Media.Models.DeinterlaceMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.DeinterlaceParity? Parity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeinterlaceMode : System.IEquatable<Azure.ResourceManager.Media.Models.DeinterlaceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeinterlaceMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.DeinterlaceMode AutoPixelAdaptive { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceMode Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.DeinterlaceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.DeinterlaceMode left, Azure.ResourceManager.Media.Models.DeinterlaceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.DeinterlaceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.DeinterlaceMode left, Azure.ResourceManager.Media.Models.DeinterlaceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeinterlaceParity : System.IEquatable<Azure.ResourceManager.Media.Models.DeinterlaceParity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeinterlaceParity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity BottomFieldFirst { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.DeinterlaceParity TopFieldFirst { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.DeinterlaceParity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.DeinterlaceParity left, Azure.ResourceManager.Media.Models.DeinterlaceParity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.DeinterlaceParity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.DeinterlaceParity left, Azure.ResourceManager.Media.Models.DeinterlaceParity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgePolicies
    {
        internal EdgePolicies() { }
        public Azure.ResourceManager.Media.Models.EdgeUsageDataCollectionPolicy UsageDataCollectionPolicy { get { throw null; } }
    }
    public partial class EdgeUsageDataCollectionPolicy
    {
        internal EdgeUsageDataCollectionPolicy() { }
        public string DataCollectionFrequency { get { throw null; } }
        public string DataReportingFrequency { get { throw null; } }
        public Azure.ResourceManager.Media.Models.EdgeUsageDataEventHub EventHubDetails { get { throw null; } }
        public System.TimeSpan? MaxAllowedUnreportedUsageDuration { get { throw null; } }
    }
    public partial class EdgeUsageDataEventHub
    {
        internal EdgeUsageDataEventHub() { }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class EnabledProtocols
    {
        public EnabledProtocols(bool download, bool dash, bool hls, bool smoothStreaming) { }
        public bool Dash { get { throw null; } set { } }
        public bool Download { get { throw null; } set { } }
        public bool Hls { get { throw null; } set { } }
        public bool SmoothStreaming { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncoderNamedPreset : System.IEquatable<Azure.ResourceManager.Media.Models.EncoderNamedPreset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncoderNamedPreset(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset AACGoodQualityAudio { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset AdaptiveStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset ContentAwareEncoding { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset ContentAwareEncodingExperimental { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset CopyAllBitrateNonInterleaved { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrate720P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264MultipleBitrateSD { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrate720P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H264SingleBitrateSD { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265AdaptiveStreaming { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265ContentAwareEncoding { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate4K { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset H265SingleBitrate720P { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EncoderNamedPreset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EncoderNamedPreset left, Azure.ResourceManager.Media.Models.EncoderNamedPreset right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EncoderNamedPreset (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EncoderNamedPreset left, Azure.ResourceManager.Media.Models.EncoderNamedPreset right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScheme : System.IEquatable<Azure.ResourceManager.Media.Models.EncryptionScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScheme(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncryptionScheme CommonEncryptionCbcs { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncryptionScheme CommonEncryptionCenc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncryptionScheme EnvelopeEncryption { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncryptionScheme NoEncryption { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EncryptionScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EncryptionScheme left, Azure.ResourceManager.Media.Models.EncryptionScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EncryptionScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EncryptionScheme left, Azure.ResourceManager.Media.Models.EncryptionScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityNameAvailabilityCheckOutput
    {
        internal EntityNameAvailabilityCheckOutput() { }
        public string Message { get { throw null; } }
        public bool NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntropyMode : System.IEquatable<Azure.ResourceManager.Media.Models.EntropyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntropyMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EntropyMode Cabac { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EntropyMode Cavlc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EntropyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EntropyMode left, Azure.ResourceManager.Media.Models.EntropyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EntropyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EntropyMode left, Azure.ResourceManager.Media.Models.EntropyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvelopeEncryption
    {
        public EnvelopeEncryption() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public string CustomKeyAcquisitionUrlTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    public partial class FaceDetectorPreset : Azure.ResourceManager.Media.Models.Preset
    {
        public FaceDetectorPreset() { }
        public Azure.ResourceManager.Media.Models.BlurType? BlurType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExperimentalOptions { get { throw null; } }
        public Azure.ResourceManager.Media.Models.FaceRedactorMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AnalysisResolution? Resolution { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceRedactorMode : System.IEquatable<Azure.ResourceManager.Media.Models.FaceRedactorMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceRedactorMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.FaceRedactorMode Analyze { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FaceRedactorMode Combined { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FaceRedactorMode Redact { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.FaceRedactorMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.FaceRedactorMode left, Azure.ResourceManager.Media.Models.FaceRedactorMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.FaceRedactorMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.FaceRedactorMode left, Azure.ResourceManager.Media.Models.FaceRedactorMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Filters
    {
        public Filters() { }
        public Azure.ResourceManager.Media.Models.Rectangle Crop { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.Deinterlace Deinterlace { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.Overlay> Overlays { get { throw null; } }
        public Azure.ResourceManager.Media.Models.Rotation? Rotation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterTrackPropertyCompareOperation : System.IEquatable<Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterTrackPropertyCompareOperation(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation Equal { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation NotEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterTrackPropertyCondition
    {
        public FilterTrackPropertyCondition(Azure.ResourceManager.Media.Models.FilterTrackPropertyType property, string value, Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation operation) { }
        public Azure.ResourceManager.Media.Models.FilterTrackPropertyCompareOperation Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.FilterTrackPropertyType Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterTrackPropertyType : System.IEquatable<Azure.ResourceManager.Media.Models.FilterTrackPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterTrackPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Bitrate { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType FourCC { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Language { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Name { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Type { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.FilterTrackPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.FilterTrackPropertyType left, Azure.ResourceManager.Media.Models.FilterTrackPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.FilterTrackPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.FilterTrackPropertyType left, Azure.ResourceManager.Media.Models.FilterTrackPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterTrackSelection
    {
        public FilterTrackSelection(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition> trackSelections) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FilterTrackPropertyCondition> TrackSelections { get { throw null; } }
    }
    public partial class Format
    {
        public Format(string filenamePattern) { }
        public string FilenamePattern { get { throw null; } set { } }
    }
    public partial class FromAllInputFile : Azure.ResourceManager.Media.Models.InputDefinition
    {
        public FromAllInputFile() { }
    }
    public partial class FromEachInputFile : Azure.ResourceManager.Media.Models.InputDefinition
    {
        public FromEachInputFile() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264Complexity : System.IEquatable<Azure.ResourceManager.Media.Models.H264Complexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264Complexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264Complexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264Complexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264Complexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264Complexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264Complexity left, Azure.ResourceManager.Media.Models.H264Complexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264Complexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264Complexity left, Azure.ResourceManager.Media.Models.H264Complexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H264Layer : Azure.ResourceManager.Media.Models.VideoLayer
    {
        public H264Layer(int bitrate) : base (default(int)) { }
        public System.TimeSpan? BufferWindow { get { throw null; } set { } }
        public float? Crf { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EntropyMode? EntropyMode { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.H264VideoProfile? Profile { get { throw null; } set { } }
        public int? ReferenceFrames { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264RateControlMode : System.IEquatable<Azure.ResourceManager.Media.Models.H264RateControlMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264RateControlMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode ABR { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode CBR { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode CRF { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264RateControlMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264RateControlMode left, Azure.ResourceManager.Media.Models.H264RateControlMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264RateControlMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264RateControlMode left, Azure.ResourceManager.Media.Models.H264RateControlMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H264Video : Azure.ResourceManager.Media.Models.Video
    {
        public H264Video() { }
        public Azure.ResourceManager.Media.Models.H264Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H264Layer> Layers { get { throw null; } }
        public Azure.ResourceManager.Media.Models.H264RateControlMode? RateControlMode { get { throw null; } set { } }
        public bool? SceneChangeDetection { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264VideoProfile : System.IEquatable<Azure.ResourceManager.Media.Models.H264VideoProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264VideoProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Baseline { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High422 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile High444 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264VideoProfile Main { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H264VideoProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H264VideoProfile left, Azure.ResourceManager.Media.Models.H264VideoProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H264VideoProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H264VideoProfile left, Azure.ResourceManager.Media.Models.H264VideoProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H265Complexity : System.IEquatable<Azure.ResourceManager.Media.Models.H265Complexity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H265Complexity(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H265Complexity Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265Complexity Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265Complexity Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H265Complexity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H265Complexity left, Azure.ResourceManager.Media.Models.H265Complexity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H265Complexity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H265Complexity left, Azure.ResourceManager.Media.Models.H265Complexity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H265Layer : Azure.ResourceManager.Media.Models.H265VideoLayer
    {
        public H265Layer(int bitrate) : base (default(int)) { }
        public System.TimeSpan? BufferWindow { get { throw null; } set { } }
        public float? Crf { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.H265VideoProfile? Profile { get { throw null; } set { } }
        public int? ReferenceFrames { get { throw null; } set { } }
    }
    public partial class H265Video : Azure.ResourceManager.Media.Models.Video
    {
        public H265Video() { }
        public Azure.ResourceManager.Media.Models.H265Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H265Layer> Layers { get { throw null; } }
        public bool? SceneChangeDetection { get { throw null; } set { } }
    }
    public partial class H265VideoLayer : Azure.ResourceManager.Media.Models.Layer
    {
        public H265VideoLayer(int bitrate) { }
        public bool? AdaptiveBFrame { get { throw null; } set { } }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H265VideoProfile : System.IEquatable<Azure.ResourceManager.Media.Models.H265VideoProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H265VideoProfile(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Main { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H265VideoProfile Main10 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.H265VideoProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.H265VideoProfile left, Azure.ResourceManager.Media.Models.H265VideoProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.H265VideoProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.H265VideoProfile left, Azure.ResourceManager.Media.Models.H265VideoProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HlsSettings
    {
        public HlsSettings() { }
        public string Characteristics { get { throw null; } set { } }
        public bool? Default { get { throw null; } set { } }
        public bool? Forced { get { throw null; } set { } }
    }
    public partial class Image : Azure.ResourceManager.Media.Models.Video
    {
        public Image(string start) { }
        public string Range { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        public string Step { get { throw null; } set { } }
    }
    public partial class ImageFormat : Azure.ResourceManager.Media.Models.Format
    {
        public ImageFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class InputDefinition
    {
        public InputDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackDescriptor> IncludedTracks { get { throw null; } }
    }
    public partial class InputFile : Azure.ResourceManager.Media.Models.InputDefinition
    {
        public InputFile() { }
        public string Filename { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InsightsType : System.IEquatable<Azure.ResourceManager.Media.Models.InsightsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InsightsType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InsightsType AllInsights { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InsightsType AudioInsightsOnly { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InsightsType VideoInsightsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InsightsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InsightsType left, Azure.ResourceManager.Media.Models.InsightsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InsightsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InsightsType left, Azure.ResourceManager.Media.Models.InsightsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InterleaveOutput : System.IEquatable<Azure.ResourceManager.Media.Models.InterleaveOutput>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InterleaveOutput(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InterleaveOutput InterleavedOutput { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InterleaveOutput NonInterleavedOutput { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InterleaveOutput other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InterleaveOutput left, Azure.ResourceManager.Media.Models.InterleaveOutput right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InterleaveOutput (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InterleaveOutput left, Azure.ResourceManager.Media.Models.InterleaveOutput right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRange
    {
        public IPRange() { }
        public string Address { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? SubnetPrefixLength { get { throw null; } set { } }
    }
    public partial class JobError
    {
        internal JobError() { }
        public Azure.ResourceManager.Media.Models.JobErrorCategory? Category { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.JobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobRetry? Retry { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobErrorCategory : System.IEquatable<Azure.ResourceManager.Media.Models.JobErrorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobErrorCategory(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.JobErrorCategory Configuration { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCategory Content { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCategory Download { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCategory Service { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCategory Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.JobErrorCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.JobErrorCategory left, Azure.ResourceManager.Media.Models.JobErrorCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.JobErrorCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.JobErrorCategory left, Azure.ResourceManager.Media.Models.JobErrorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobErrorCode : System.IEquatable<Azure.ResourceManager.Media.Models.JobErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.JobErrorCode ConfigurationUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode ContentMalformed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode ContentUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode DownloadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode DownloadTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode ServiceError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode ServiceTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode UploadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobErrorCode UploadTransientError { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.JobErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.JobErrorCode left, Azure.ResourceManager.Media.Models.JobErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.JobErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.JobErrorCode left, Azure.ResourceManager.Media.Models.JobErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobErrorDetail
    {
        internal JobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class JobInput
    {
        public JobInput() { }
    }
    public partial class JobInputAsset : Azure.ResourceManager.Media.Models.JobInputClip
    {
        public JobInputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
    }
    public partial class JobInputClip : Azure.ResourceManager.Media.Models.JobInput
    {
        public JobInputClip() { }
        public Azure.ResourceManager.Media.Models.ClipTime End { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.InputDefinition> InputDefinitions { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ClipTime Start { get { throw null; } set { } }
    }
    public partial class JobInputHttp : Azure.ResourceManager.Media.Models.JobInputClip
    {
        public JobInputHttp() { }
        public System.Uri BaseUri { get { throw null; } set { } }
    }
    public partial class JobInputs : Azure.ResourceManager.Media.Models.JobInput
    {
        public JobInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JobInput> Inputs { get { throw null; } }
    }
    public partial class JobInputSequence : Azure.ResourceManager.Media.Models.JobInput
    {
        public JobInputSequence() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JobInputClip> Inputs { get { throw null; } }
    }
    public partial class JobOutput
    {
        public JobOutput() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobError Error { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.Preset PresetOverride { get { throw null; } set { } }
        public int? Progress { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobState? State { get { throw null; } }
    }
    public partial class JobOutputAsset : Azure.ResourceManager.Media.Models.JobOutput
    {
        public JobOutputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobRetry : System.IEquatable<Azure.ResourceManager.Media.Models.JobRetry>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobRetry(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.JobRetry DoNotRetry { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobRetry MayRetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.JobRetry other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.JobRetry left, Azure.ResourceManager.Media.Models.JobRetry right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.JobRetry (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.JobRetry left, Azure.ResourceManager.Media.Models.JobRetry right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobState : System.IEquatable<Azure.ResourceManager.Media.Models.JobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.JobState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Error { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Finished { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Processing { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Queued { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.JobState Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.JobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.JobState left, Azure.ResourceManager.Media.Models.JobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.JobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.JobState left, Azure.ResourceManager.Media.Models.JobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JpgFormat : Azure.ResourceManager.Media.Models.ImageFormat
    {
        public JpgFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class JpgImage : Azure.ResourceManager.Media.Models.Image
    {
        public JpgImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JpgLayer> Layers { get { throw null; } }
        public int? SpriteColumn { get { throw null; } set { } }
    }
    public partial class JpgLayer : Azure.ResourceManager.Media.Models.Layer
    {
        public JpgLayer() { }
        public int? Quality { get { throw null; } set { } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string CurrentKeyIdentifier { get { throw null; } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class Layer
    {
        public Layer() { }
        public string Height { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
    }
    public partial class ListContainerSasContent
    {
        public ListContainerSasContent() { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AssetContainerPermission? Permissions { get { throw null; } set { } }
    }
    public partial class ListContentKeysResponse
    {
        internal ListContentKeysResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> ContentKeys { get { throw null; } }
    }
    public partial class ListEdgePoliciesContent
    {
        public ListEdgePoliciesContent() { }
        public string DeviceId { get { throw null; } set { } }
    }
    public partial class ListPathsResponse
    {
        internal ListPathsResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> DownloadPaths { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.StreamingPath> StreamingPaths { get { throw null; } }
    }
    public partial class ListStreamingLocatorsResponse
    {
        internal ListStreamingLocatorsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.AssetStreamingLocator> StreamingLocators { get { throw null; } }
    }
    public partial class LiveEventActionContent
    {
        public LiveEventActionContent() { }
        public bool? RemoveOutputsOnStop { get { throw null; } set { } }
    }
    public partial class LiveEventEncoding
    {
        public LiveEventEncoding() { }
        public Azure.ResourceManager.Media.Models.LiveEventEncodingType? EncodingType { get { throw null; } set { } }
        public System.TimeSpan? KeyFrameInterval { get { throw null; } set { } }
        public string PresetName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StretchMode? StretchMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventEncodingType : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventEncodingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventEncodingType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType None { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType PassthroughBasic { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType PassthroughStandard { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType Premium1080P { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventEncodingType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventEncodingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventEncodingType left, Azure.ResourceManager.Media.Models.LiveEventEncodingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventEncodingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventEncodingType left, Azure.ResourceManager.Media.Models.LiveEventEncodingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventEndpoint
    {
        public LiveEventEndpoint() { }
        public string Protocol { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class LiveEventInput
    {
        public LiveEventInput(Azure.ResourceManager.Media.Models.LiveEventInputProtocol streamingProtocol) { }
        public string AccessToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllow { get { throw null; } }
        public System.TimeSpan? KeyFrameIntervalDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInputProtocol StreamingProtocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventInputProtocol : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventInputProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventInputProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventInputProtocol FragmentedMP4 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventInputProtocol Rtmp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventInputProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventInputProtocol left, Azure.ResourceManager.Media.Models.LiveEventInputProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventInputProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventInputProtocol left, Azure.ResourceManager.Media.Models.LiveEventInputProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventInputTrackSelection
    {
        public LiveEventInputTrackSelection() { }
        public string Operation { get { throw null; } set { } }
        public string Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class LiveEventPreview
    {
        public LiveEventPreview() { }
        public string AlternativeMediaId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllow { get { throw null; } }
        public string PreviewLocator { get { throw null; } set { } }
        public string StreamingPolicyName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Allocating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState StandBy { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveEventResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveEventResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveEventResourceState left, Azure.ResourceManager.Media.Models.LiveEventResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveEventResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveEventResourceState left, Azure.ResourceManager.Media.Models.LiveEventResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveEventTranscription
    {
        public LiveEventTranscription() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.LiveEventInputTrackSelection> InputTrackSelection { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string TrackName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveOutputResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.LiveOutputResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveOutputResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LiveOutputResourceState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LiveOutputResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LiveOutputResourceState left, Azure.ResourceManager.Media.Models.LiveOutputResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LiveOutputResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LiveOutputResourceState left, Azure.ResourceManager.Media.Models.LiveOutputResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaPrivateLinkServiceConnectionState
    {
        public MediaPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class MediaServiceOperationStatus
    {
        internal MediaServiceOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class MediaservicePatch
    {
        public MediaservicePatch() { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServiceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StorageAuthentication? StorageAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Mp4Format : Azure.ResourceManager.Media.Models.MultiBitrateFormat
    {
        public Mp4Format(string filenamePattern) : base (default(string)) { }
    }
    public partial class MultiBitrateFormat : Azure.ResourceManager.Media.Models.Format
    {
        public MultiBitrateFormat(string filenamePattern) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.OutputFile> OutputFiles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnErrorType : System.IEquatable<Azure.ResourceManager.Media.Models.OnErrorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnErrorType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.OnErrorType ContinueJob { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.OnErrorType StopProcessingJob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.OnErrorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.OnErrorType left, Azure.ResourceManager.Media.Models.OnErrorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.OnErrorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.OnErrorType left, Azure.ResourceManager.Media.Models.OnErrorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputFile
    {
        public OutputFile(System.Collections.Generic.IEnumerable<string> labels) { }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
    }
    public partial class Overlay
    {
        public Overlay(string inputLabel) { }
        public double? AudioGainLevel { get { throw null; } set { } }
        public System.TimeSpan? End { get { throw null; } set { } }
        public System.TimeSpan? FadeInDuration { get { throw null; } set { } }
        public System.TimeSpan? FadeOutDuration { get { throw null; } set { } }
        public string InputLabel { get { throw null; } set { } }
        public System.TimeSpan? Start { get { throw null; } set { } }
    }
    public partial class PngFormat : Azure.ResourceManager.Media.Models.ImageFormat
    {
        public PngFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class PngImage : Azure.ResourceManager.Media.Models.Image
    {
        public PngImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.PngLayer> Layers { get { throw null; } }
    }
    public partial class PngLayer : Azure.ResourceManager.Media.Models.Layer
    {
        public PngLayer() { }
    }
    public partial class PresentationTimeRange
    {
        public PresentationTimeRange() { }
        public long? EndTimestamp { get { throw null; } set { } }
        public bool? ForceEndTimestamp { get { throw null; } set { } }
        public long? LiveBackoffDuration { get { throw null; } set { } }
        public long? PresentationWindowDuration { get { throw null; } set { } }
        public long? StartTimestamp { get { throw null; } set { } }
        public long? Timescale { get { throw null; } set { } }
    }
    public partial class Preset
    {
        public Preset() { }
    }
    public partial class PresetConfigurations
    {
        public PresetConfigurations() { }
        public Azure.ResourceManager.Media.Models.Complexity? Complexity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InterleaveOutput? InterleaveOutput { get { throw null; } set { } }
        public float? KeyFrameIntervalInSeconds { get { throw null; } set { } }
        public int? MaxBitrateBps { get { throw null; } set { } }
        public int? MaxHeight { get { throw null; } set { } }
        public int? MaxLayers { get { throw null; } set { } }
        public int? MinBitrateBps { get { throw null; } set { } }
        public int? MinHeight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Priority : System.IEquatable<Azure.ResourceManager.Media.Models.Priority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Priority(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.Priority High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Priority Low { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Priority Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.Priority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.Priority left, Azure.ResourceManager.Media.Models.Priority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.Priority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.Priority left, Azure.ResourceManager.Media.Models.Priority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Media.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ProvisioningState left, Azure.ResourceManager.Media.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ProvisioningState left, Azure.ResourceManager.Media.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Media.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.PublicNetworkAccess left, Azure.ResourceManager.Media.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.PublicNetworkAccess left, Azure.ResourceManager.Media.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Rectangle
    {
        public Rectangle() { }
        public string Height { get { throw null; } set { } }
        public string Left { get { throw null; } set { } }
        public string Top { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
    }
    public partial class ResourceIdentity
    {
        public ResourceIdentity(bool useSystemAssignedIdentity) { }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public bool UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Rotation : System.IEquatable<Azure.ResourceManager.Media.Models.Rotation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Rotation(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.Rotation Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Rotation None { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Rotation Rotate0 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Rotation Rotate180 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Rotation Rotate270 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Rotation Rotate90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.Rotation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.Rotation left, Azure.ResourceManager.Media.Models.Rotation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.Rotation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.Rotation left, Azure.ResourceManager.Media.Models.Rotation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelectAudioTrackByAttribute : Azure.ResourceManager.Media.Models.AudioTrackDescriptor
    {
        public SelectAudioTrackByAttribute(Azure.ResourceManager.Media.Models.TrackAttribute attribute, Azure.ResourceManager.Media.Models.AttributeFilter filter) { }
        public Azure.ResourceManager.Media.Models.TrackAttribute Attribute { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AttributeFilter Filter { get { throw null; } set { } }
        public string FilterValue { get { throw null; } set { } }
    }
    public partial class SelectAudioTrackById : Azure.ResourceManager.Media.Models.AudioTrackDescriptor
    {
        public SelectAudioTrackById(long trackId) { }
        public long TrackId { get { throw null; } set { } }
    }
    public partial class SelectVideoTrackByAttribute : Azure.ResourceManager.Media.Models.VideoTrackDescriptor
    {
        public SelectVideoTrackByAttribute(Azure.ResourceManager.Media.Models.TrackAttribute attribute, Azure.ResourceManager.Media.Models.AttributeFilter filter) { }
        public Azure.ResourceManager.Media.Models.TrackAttribute Attribute { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AttributeFilter Filter { get { throw null; } set { } }
        public string FilterValue { get { throw null; } set { } }
    }
    public partial class SelectVideoTrackById : Azure.ResourceManager.Media.Models.VideoTrackDescriptor
    {
        public SelectVideoTrackById(long trackId) { }
        public long TrackId { get { throw null; } set { } }
    }
    public partial class StandardEncoderPreset : Azure.ResourceManager.Media.Models.Preset
    {
        public StandardEncoderPreset(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.Codec> codecs, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.Format> formats) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.Codec> Codecs { get { throw null; } }
        public Azure.ResourceManager.Media.Models.Filters Filters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.Format> Formats { get { throw null; } }
    }
    public partial class StorageAccount
    {
        public StorageAccount(Azure.ResourceManager.Media.Models.StorageAccountType accountType) { }
        public Azure.ResourceManager.Media.Models.StorageAccountType AccountType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Media.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StorageAccountType Primary { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StorageAccountType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StorageAccountType left, Azure.ResourceManager.Media.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StorageAccountType left, Azure.ResourceManager.Media.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAuthentication : System.IEquatable<Azure.ResourceManager.Media.Models.StorageAuthentication>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAuthentication(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StorageAuthentication ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StorageAuthentication System { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StorageAuthentication other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StorageAuthentication left, Azure.ResourceManager.Media.Models.StorageAuthentication right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StorageAuthentication (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StorageAuthentication left, Azure.ResourceManager.Media.Models.StorageAuthentication right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageEncryptedAssetDecryptionData
    {
        internal StorageEncryptedAssetDecryptionData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.AssetFileEncryptionMetadata> AssetFileEncryptionMetadata { get { throw null; } }
        public byte[] Key { get { throw null; } }
    }
    public partial class StreamingEndpointAccessControl
    {
        public StreamingEndpointAccessControl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey> AkamaiSignatureHeaderAuthenticationKeyList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllow { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingEndpointResourceState : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingEndpointResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingEndpointResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Running { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Starting { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingEndpointResourceState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState left, Azure.ResourceManager.Media.Models.StreamingEndpointResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingEndpointResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingEndpointResourceState left, Azure.ResourceManager.Media.Models.StreamingEndpointResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingEntityScaleUnit
    {
        public StreamingEntityScaleUnit() { }
        public int? ScaleUnit { get { throw null; } set { } }
    }
    public partial class StreamingLocatorContentKey
    {
        public StreamingLocatorContentKey(System.Guid id) { }
        public System.Guid Id { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType? KeyType { get { throw null; } }
        public string LabelReferenceInStreamingPolicy { get { throw null; } set { } }
        public string PolicyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.TrackSelection> Tracks { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingLocatorContentKeyType : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingLocatorContentKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType CommonEncryptionCbcs { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType CommonEncryptionCenc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType EnvelopeEncryption { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType left, Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType left, Azure.ResourceManager.Media.Models.StreamingLocatorContentKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingPath
    {
        internal StreamingPath() { }
        public Azure.ResourceManager.Media.Models.EncryptionScheme EncryptionScheme { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol StreamingProtocol { get { throw null; } }
    }
    public partial class StreamingPolicyContentKey
    {
        public StreamingPolicyContentKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackSelection> Tracks { get { throw null; } }
    }
    public partial class StreamingPolicyContentKeys
    {
        public StreamingPolicyContentKeys() { }
        public Azure.ResourceManager.Media.Models.DefaultKey DefaultKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey> KeyToTrackMappings { get { throw null; } }
    }
    public partial class StreamingPolicyFairPlayConfiguration
    {
        public StreamingPolicyFairPlayConfiguration(bool allowPersistentLicense) { }
        public bool AllowPersistentLicense { get { throw null; } set { } }
        public string CustomLicenseAcquisitionUrlTemplate { get { throw null; } set { } }
    }
    public partial class StreamingPolicyPlayReadyConfiguration
    {
        public StreamingPolicyPlayReadyConfiguration() { }
        public string CustomLicenseAcquisitionUrlTemplate { get { throw null; } set { } }
        public string PlayReadyCustomAttributes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingPolicyStreamingProtocol : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingPolicyStreamingProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Dash { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Download { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol Hls { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol SmoothStreaming { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol left, Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol left, Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamOptionsFlag : System.IEquatable<Azure.ResourceManager.Media.Models.StreamOptionsFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamOptionsFlag(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag Default { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag LowLatency { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamOptionsFlag LowLatencyV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamOptionsFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamOptionsFlag left, Azure.ResourceManager.Media.Models.StreamOptionsFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamOptionsFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamOptionsFlag left, Azure.ResourceManager.Media.Models.StreamOptionsFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StretchMode : System.IEquatable<Azure.ResourceManager.Media.Models.StretchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StretchMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StretchMode AutoFit { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StretchMode AutoSize { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StretchMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StretchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StretchMode left, Azure.ResourceManager.Media.Models.StretchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StretchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StretchMode left, Azure.ResourceManager.Media.Models.StretchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SyncStorageKeysContent
    {
        public SyncStorageKeysContent() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class TextTrack : Azure.ResourceManager.Media.Models.TrackBase
    {
        public TextTrack() { }
        public string DisplayName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.HlsSettings HlsSettings { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } }
        public Azure.ResourceManager.Media.Models.Visibility? PlayerVisibility { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackAttribute : System.IEquatable<Azure.ResourceManager.Media.Models.TrackAttribute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackAttribute(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackAttribute Bitrate { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackAttribute Language { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackAttribute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackAttribute left, Azure.ResourceManager.Media.Models.TrackAttribute right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackAttribute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackAttribute left, Azure.ResourceManager.Media.Models.TrackAttribute right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackBase
    {
        public TrackBase() { }
    }
    public partial class TrackDescriptor
    {
        public TrackDescriptor() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackPropertyCompareOperation : System.IEquatable<Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackPropertyCompareOperation(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Equal { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation left, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackPropertyCondition
    {
        public TrackPropertyCondition(Azure.ResourceManager.Media.Models.TrackPropertyType property, Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation operation) { }
        public Azure.ResourceManager.Media.Models.TrackPropertyCompareOperation Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.TrackPropertyType Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackPropertyType : System.IEquatable<Azure.ResourceManager.Media.Models.TrackPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TrackPropertyType FourCC { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TrackPropertyType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TrackPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TrackPropertyType left, Azure.ResourceManager.Media.Models.TrackPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TrackPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TrackPropertyType left, Azure.ResourceManager.Media.Models.TrackPropertyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackSelection
    {
        public TrackSelection() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackPropertyCondition> TrackSelections { get { throw null; } }
    }
    public partial class TransformOutput
    {
        public TransformOutput(Azure.ResourceManager.Media.Models.Preset preset) { }
        public Azure.ResourceManager.Media.Models.OnErrorType? OnError { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.Preset Preset { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.Priority? RelativePriority { get { throw null; } set { } }
    }
    public partial class TransportStreamFormat : Azure.ResourceManager.Media.Models.MultiBitrateFormat
    {
        public TransportStreamFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class UtcClipTime : Azure.ResourceManager.Media.Models.ClipTime
    {
        public UtcClipTime(System.DateTimeOffset time) { }
        public System.DateTimeOffset Time { get { throw null; } set { } }
    }
    public partial class Video : Azure.ResourceManager.Media.Models.Codec
    {
        public Video() { }
        public System.TimeSpan? KeyFrameInterval { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StretchMode? StretchMode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.VideoSyncMode? SyncMode { get { throw null; } set { } }
    }
    public partial class VideoAnalyzerPreset : Azure.ResourceManager.Media.Models.AudioAnalyzerPreset
    {
        public VideoAnalyzerPreset() { }
        public Azure.ResourceManager.Media.Models.InsightsType? InsightsToExtract { get { throw null; } set { } }
    }
    public partial class VideoLayer : Azure.ResourceManager.Media.Models.Layer
    {
        public VideoLayer(int bitrate) { }
        public bool? AdaptiveBFrame { get { throw null; } set { } }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
    }
    public partial class VideoOverlay : Azure.ResourceManager.Media.Models.Overlay
    {
        public VideoOverlay(string inputLabel) : base (default(string)) { }
        public Azure.ResourceManager.Media.Models.Rectangle CropRectangle { get { throw null; } set { } }
        public double? Opacity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.Rectangle Position { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VideoSyncMode : System.IEquatable<Azure.ResourceManager.Media.Models.VideoSyncMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VideoSyncMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Cfr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Passthrough { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.VideoSyncMode Vfr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.VideoSyncMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.VideoSyncMode left, Azure.ResourceManager.Media.Models.VideoSyncMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.VideoSyncMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.VideoSyncMode left, Azure.ResourceManager.Media.Models.VideoSyncMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VideoTrack : Azure.ResourceManager.Media.Models.TrackBase
    {
        public VideoTrack() { }
    }
    public partial class VideoTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor
    {
        public VideoTrackDescriptor() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Visibility : System.IEquatable<Azure.ResourceManager.Media.Models.Visibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Visibility(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.Visibility Hidden { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.Visibility Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.Visibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.Visibility left, Azure.ResourceManager.Media.Models.Visibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.Visibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.Visibility left, Azure.ResourceManager.Media.Models.Visibility right) { throw null; }
        public override string ToString() { throw null; }
    }
}
