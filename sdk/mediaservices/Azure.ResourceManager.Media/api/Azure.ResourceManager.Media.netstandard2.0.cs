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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyPreference> Preferences { get { throw null; } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventEncoding Encoding { get { throw null; } set { } }
        public string HostnamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInput Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public int? HttpLiveStreamingFragmentsPerTsSegment { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
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
    public partial class MediaAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetResource>, System.Collections.IEnumerable
    {
        protected MediaAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assetName, Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Get(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaAssetResource> GetAll(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaAssetResource> GetAllAsync(string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaAssetData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaAssetData() { }
        public string AlternateId { get { throw null; } set { } }
        public System.Guid? AssetId { get { throw null; } }
        public string Container { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AssetStorageEncryptionFormat? StorageEncryptionFormat { get { throw null; } }
    }
    public partial class MediaAssetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AssetFilterResource> GetAssetFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AssetFilterResource>> GetAssetFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.AssetFilterCollection GetAssetFilters() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo> GetEncryptionKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.StorageEncryptedAssetDecryptionInfo>> GetEncryptionKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> GetMediaAssetTrack(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetMediaAssetTrackAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackCollection GetMediaAssetTracks() { throw null; }
        public virtual Azure.Pageable<System.Uri> GetStorageContainerUris(Azure.ResourceManager.Media.Models.GetContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.Uri> GetStorageContainerUrisAsync(Azure.ResourceManager.Media.Models.GetContainerSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.AssetStreamingLocator> GetStreamingLocators(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.AssetStreamingLocator> GetStreamingLocatorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> Update(Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> UpdateAsync(Azure.ResourceManager.Media.MediaAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetTrackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>, System.Collections.IEnumerable
    {
        protected MediaAssetTrackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trackName, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> Get(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaAssetTrackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaAssetTrackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetAsync(string trackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaAssetTrackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaAssetTrackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaAssetTrackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaAssetTrackData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaAssetTrackData() { }
        public Azure.ResourceManager.Media.Models.MediaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.AssetTrackInfo Track { get { throw null; } set { } }
    }
    public partial class MediaAssetTrackOperationResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected MediaAssetTrackOperationResultCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetTrackOperationResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetTrackOperationResultResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string trackName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaAssetTrackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaAssetTrackResource() { }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string assetName, string trackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource> GetMediaAssetTrackOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource>> GetMediaAssetTrackOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetTrackOperationResultCollection GetMediaAssetTrackOperationResults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.AssetTrackOperationStatus> GetOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.AssetTrackOperationStatus>> GetOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaAssetTrackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaAssetTrackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateTrackData(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateTrackDataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MediaExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Media.Models.MediaNameAvailabilityResult> CheckMediaNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaNameAvailabilityResult>> CheckMediaNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.Media.Models.MediaNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.AccountFilterResource GetAccountFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.AssetFilterResource GetAssetFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.ContentKeyPolicyResource GetContentKeyPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.LiveEventResource GetLiveEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.LiveOutputResource GetLiveOutputResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetResource GetMediaAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetTrackOperationResultResource GetMediaAssetTrackOperationResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaAssetTrackResource GetMediaAssetTrackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetMediaServicesAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountResource GetMediaServicesAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesAccountCollection GetMediaServicesAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetMediaServicesAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource> GetMediaServicesOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource>> GetMediaServicesOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesOperationResultResource GetMediaServicesOperationResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesOperationResultCollection GetMediaServicesOperationResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesOperationStatus> GetMediaServicesOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.MediaServicesOperationStatus>> GetMediaServicesOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource GetMediaServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaServicesPrivateLinkResource GetMediaServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaTransformJobResource GetMediaTransformJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.MediaTransformResource GetMediaTransformResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingEndpointResource GetStreamingEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingLocatorResource GetStreamingLocatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Media.StreamingPolicyResource GetStreamingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MediaServicesAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>, System.Collections.IEnumerable
    {
        protected MediaServicesAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Media.MediaServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MediaServicesAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServicesAccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaStorageAuthentication? StorageAuthentication { get { throw null; } set { } }
    }
    public partial class MediaServicesAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesAccountResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.AccountFilterResource> GetAccountFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.AccountFilterResource>> GetAccountFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.AccountFilterCollection GetAccountFilters() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.ContentKeyPolicyCollection GetContentKeyPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource> GetContentKeyPolicy(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.ContentKeyPolicyResource>> GetContentKeyPolicyAsync(string contentKeyPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.EdgePolicies> GetEdgePolicies(Azure.ResourceManager.Media.Models.GetEdgePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.EdgePolicies>> GetEdgePoliciesAsync(Azure.ResourceManager.Media.Models.GetEdgePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.LiveEventResource> GetLiveEvent(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.LiveEventResource>> GetLiveEventAsync(string liveEventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.LiveEventCollection GetLiveEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaAssetResource> GetMediaAsset(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaAssetResource>> GetMediaAssetAsync(string assetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaAssetCollection GetMediaAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetMediaServicesPrivateEndpointConnection(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetMediaServicesPrivateEndpointConnectionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionCollection GetMediaServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetMediaServicesPrivateLinkResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetMediaServicesPrivateLinkResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceCollection GetMediaServicesPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> GetMediaTransform(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetMediaTransformAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaTransformCollection GetMediaTransforms() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> GetStreamingEndpoint(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> GetStreamingEndpointAsync(string streamingEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingEndpointCollection GetStreamingEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource> GetStreamingLocator(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingLocatorResource>> GetStreamingLocatorAsync(string streamingLocatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingLocatorCollection GetStreamingLocators() { throw null; }
        public virtual Azure.ResourceManager.Media.StreamingPolicyCollection GetStreamingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource> GetStreamingPolicy(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingPolicyResource>> GetStreamingPolicyAsync(string streamingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncStorageKeys(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncStorageKeysAsync(Azure.ResourceManager.Media.Models.SyncStorageKeysContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaServicesAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.MediaServicesAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesOperationResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected MediaServicesOperationResultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource> Get(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource>> GetAsync(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesOperationResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesOperationResultResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation locationName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesOperationResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MediaServicesPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaServicesPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Media.Models.MediaPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MediaServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Media.MediaServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaServicesPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MediaServicesPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaServicesPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MediaTransformCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformResource>, System.Collections.IEnumerable
    {
        protected MediaTransformCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string transformName, Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Get(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaTransformResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaTransformResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetAsync(string transformName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaTransformResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaTransformResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaTransformData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaTransformData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformOutput> Outputs { get { throw null; } }
    }
    public partial class MediaTransformJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformJobResource>, System.Collections.IEnumerable
    {
        protected MediaTransformJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.MediaTransformJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Media.MediaTransformJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Media.MediaTransformJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Media.MediaTransformJobResource> GetAll(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.MediaTransformJobResource> GetAllAsync(string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Media.MediaTransformJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Media.MediaTransformJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Media.MediaTransformJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.MediaTransformJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MediaTransformJobData : Azure.ResourceManager.Models.ResourceData
    {
        public MediaTransformJobData() { }
        public System.Collections.Generic.IDictionary<string, string> CorrelationData { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaTransformJobInputBasicProperties Input { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformJobOutput> Outputs { get { throw null; } }
        public Azure.ResourceManager.Media.Models.TransformOutputsPriority? Priority { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobState? State { get { throw null; } }
    }
    public partial class MediaTransformJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaTransformJobResource() { }
        public virtual Azure.ResourceManager.Media.MediaTransformJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CancelJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource> Update(Azure.ResourceManager.Media.MediaTransformJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource>> UpdateAsync(Azure.ResourceManager.Media.MediaTransformJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaTransformResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MediaTransformResource() { }
        public virtual Azure.ResourceManager.Media.MediaTransformData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string transformName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource> GetMediaTransformJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformJobResource>> GetMediaTransformJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Media.MediaTransformJobCollection GetMediaTransformJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.MediaTransformResource> Update(Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.MediaTransformResource>> UpdateAsync(Azure.ResourceManager.Media.MediaTransformData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string CdnProfile { get { throw null; } set { } }
        public string CdnProvider { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.CrossSiteAccessPolicies CrossSiteAccessPolicies { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomHostNames { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? FreeTrialEndOn { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsCdnEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public long? MaxCacheAge { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingEndpointResourceState? ResourceState { get { throw null; } }
        public int? ScaleUnitsNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingEndpointCurrentSku Sku { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo> GetSupportedSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.StreamingEndpointSkuInfo> GetSupportedSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Scale(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Media.Models.StreamingEntityScaleUnit streamingEntityScaleUnit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.StreamingEndpointResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> GetContentKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Media.Models.StreamingLocatorContentKey> GetContentKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Media.Models.GetPathsResult> GetSupportedPaths(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Media.Models.GetPathsResult>> GetSupportedPathsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EnvelopeEncryption EnvelopeEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols NoEncryptionEnabledProtocols { get { throw null; } set { } }
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
}
namespace Azure.ResourceManager.Media.Models
{
    public partial class AacAudio : Azure.ResourceManager.Media.Models.AudioCommonProperties
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
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HEAacV1 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.AacAudioProfile HEAacV2 { get { throw null; } }
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
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultContentKeyPolicyName { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public System.Guid? StreamingLocatorId { get { throw null; } }
        public string StreamingPolicyName { get { throw null; } }
    }
    public abstract partial class AssetTrackInfo
    {
        protected AssetTrackInfo() { }
    }
    public partial class AssetTrackOperationStatus
    {
        internal AssetTrackOperationStatus() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
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
    public partial class AudioAnalyzerPreset : Azure.ResourceManager.Media.Models.MediaPreset
    {
        public AudioAnalyzerPreset() { }
        public string AudioLanguage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExperimentalOptions { get { throw null; } }
        public Azure.ResourceManager.Media.Models.AudioAnalysisMode? Mode { get { throw null; } set { } }
    }
    public partial class AudioCommonProperties : Azure.ResourceManager.Media.Models.CodecBasicProperties
    {
        public AudioCommonProperties() { }
        public int? Bitrate { get { throw null; } set { } }
        public int? Channels { get { throw null; } set { } }
        public int? SamplingRate { get { throw null; } set { } }
    }
    public partial class AudioOverlay : Azure.ResourceManager.Media.Models.OverlayBasicProperties
    {
        public AudioOverlay(string inputLabel) : base (default(string)) { }
    }
    public partial class AudioTrack : Azure.ResourceManager.Media.Models.AssetTrackInfo
    {
        public AudioTrack() { }
    }
    public partial class AudioTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor
    {
        public AudioTrackDescriptor() { }
        public Azure.ResourceManager.Media.Models.ChannelMapping? ChannelMapping { get { throw null; } set { } }
    }
    public partial class BuiltInStandardEncoderPreset : Azure.ResourceManager.Media.Models.MediaPreset
    {
        public BuiltInStandardEncoderPreset(Azure.ResourceManager.Media.Models.EncoderNamedPreset presetName) { }
        public Azure.ResourceManager.Media.Models.EncoderPresetConfigurations Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.EncoderNamedPreset PresetName { get { throw null; } set { } }
    }
    public partial class CbcsDrmConfiguration
    {
        public CbcsDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyFairPlayConfiguration FairPlay { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public System.Uri WidevineCustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
    }
    public partial class CencDrmConfiguration
    {
        public CencDrmConfiguration() { }
        public Azure.ResourceManager.Media.Models.StreamingPolicyPlayReadyConfiguration PlayReady { get { throw null; } set { } }
        public System.Uri WidevineCustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
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
    public abstract partial class ClipTime
    {
        protected ClipTime() { }
    }
    public abstract partial class CodecBasicProperties
    {
        protected CodecBasicProperties() { }
        public string Label { get { throw null; } set { } }
    }
    public partial class CommonEncryptionCbcs
    {
        public CommonEncryptionCbcs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CbcsDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    public partial class CommonEncryptionCenc
    {
        public CommonEncryptionCenc() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.CencDrmConfiguration Drm { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyClearKeyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyClearKeyConfiguration() { }
    }
    public abstract partial class ContentKeyPolicyConfiguration
    {
        protected ContentKeyPolicyConfiguration() { }
    }
    public partial class ContentKeyPolicyFairPlayConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyFairPlayConfiguration(byte[] fairPlayApplicationSecretKey, string fairPlayPfxPassword, string fairPlayPfx, Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType rentalAndLeaseKeyType, long rentalDuration) { }
        public byte[] FairPlayApplicationSecretKey { get { throw null; } set { } }
        public string FairPlayPfx { get { throw null; } set { } }
        public string FairPlayPfxPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayOfflineRentalConfiguration OfflineRentalConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyFairPlayRentalAndLeaseKeyType RentalAndLeaseKeyType { get { throw null; } set { } }
        public long RentalDuration { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyFairPlayOfflineRentalConfiguration
    {
        public ContentKeyPolicyFairPlayOfflineRentalConfiguration(long playbackDurationInSeconds, long storageDurationInSeconds) { }
        public long PlaybackDurationInSeconds { get { throw null; } set { } }
        public long StorageDurationInSeconds { get { throw null; } set { } }
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
    public partial class ContentKeyPolicyPlayReadyConfiguration : Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyPlayReadyConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> licenses) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicense> Licenses { get { throw null; } }
        public System.BinaryData ResponseCustomData { get { throw null; } set { } }
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
    public abstract partial class ContentKeyPolicyPlayReadyContentKeyLocation
    {
        protected ContentKeyPolicyPlayReadyContentKeyLocation() { }
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
        public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction(bool isBestEffort, int configurationData) { }
        public int ConfigurationData { get { throw null; } set { } }
        public bool IsBestEffort { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyPlayReadyLicense
    {
        public ContentKeyPolicyPlayReadyLicense(bool allowTestDevices, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyLicenseType licenseType, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation contentKeyLocation, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType contentType) { }
        public bool AllowTestDevices { get { throw null; } set { } }
        public System.DateTimeOffset? BeginOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentKeyLocation ContentKeyLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyContentType ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
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
        public ContentKeyPolicyPlayReadyPlayRight(bool hasDigitalVideoOnlyContentRestriction, bool hasImageConstraintForAnalogComponentVideoRestriction, bool hasImageConstraintForAnalogComputerMonitorRestriction, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting allowPassingVideoContentToUnknownOutput) { }
        public int? AgcAndColorStripeRestriction { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting AllowPassingVideoContentToUnknownOutput { get { throw null; } set { } }
        public int? AnalogVideoOutputProtectionLevel { get { throw null; } set { } }
        public int? CompressedDigitalAudioOutputProtectionLevel { get { throw null; } set { } }
        public int? CompressedDigitalVideoOutputProtectionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction ExplicitAnalogTelevisionOutputRestriction { get { throw null; } set { } }
        public System.TimeSpan? FirstPlayExpiration { get { throw null; } set { } }
        public bool HasDigitalVideoOnlyContentRestriction { get { throw null; } set { } }
        public bool HasImageConstraintForAnalogComponentVideoRestriction { get { throw null; } set { } }
        public bool HasImageConstraintForAnalogComputerMonitorRestriction { get { throw null; } set { } }
        public int? ScmsRestriction { get { throw null; } set { } }
        public int? UncompressedDigitalAudioOutputProtectionLevel { get { throw null; } set { } }
        public int? UncompressedDigitalVideoOutputProtectionLevel { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentKeyPolicyPlayReadyUnknownOutputPassingSetting : System.IEquatable<Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentKeyPolicyPlayReadyUnknownOutputPassingSetting(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting Allowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting AllowedWithVideoConstriction { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting NotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting left, Azure.ResourceManager.Media.Models.ContentKeyPolicyPlayReadyUnknownOutputPassingSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentKeyPolicyPreference
    {
        public ContentKeyPolicyPreference(Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration configuration, Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction restriction) { }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyConfiguration Configuration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Guid? PolicyOptionId { get { throw null; } }
        public Azure.ResourceManager.Media.Models.ContentKeyPolicyRestriction Restriction { get { throw null; } set { } }
    }
    public partial class ContentKeyPolicyProperties
    {
        internal ContentKeyPolicyProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Guid? PolicyId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.ContentKeyPolicyPreference> Preferences { get { throw null; } }
    }
    public abstract partial class ContentKeyPolicyRestriction
    {
        protected ContentKeyPolicyRestriction() { }
    }
    public abstract partial class ContentKeyPolicyRestrictionTokenKey
    {
        protected ContentKeyPolicyRestrictionTokenKey() { }
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
    public partial class CopyAudio : Azure.ResourceManager.Media.Models.CodecBasicProperties
    {
        public CopyAudio() { }
    }
    public partial class CopyVideo : Azure.ResourceManager.Media.Models.CodecBasicProperties
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
    public partial class DeinterlaceSettings
    {
        public DeinterlaceSettings() { }
        public Azure.ResourceManager.Media.Models.DeinterlaceMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.DeinterlaceParity? Parity { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncoderComplexitySetting : System.IEquatable<Azure.ResourceManager.Media.Models.EncoderComplexitySetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncoderComplexitySetting(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncoderComplexitySetting Balanced { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderComplexitySetting Quality { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.EncoderComplexitySetting Speed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.EncoderComplexitySetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.EncoderComplexitySetting left, Azure.ResourceManager.Media.Models.EncoderComplexitySetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.EncoderComplexitySetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.EncoderComplexitySetting left, Azure.ResourceManager.Media.Models.EncoderComplexitySetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncoderNamedPreset : System.IEquatable<Azure.ResourceManager.Media.Models.EncoderNamedPreset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncoderNamedPreset(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.EncoderNamedPreset AacGoodQualityAudio { get { throw null; } }
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
    public partial class EncoderPresetConfigurations
    {
        public EncoderPresetConfigurations() { }
        public Azure.ResourceManager.Media.Models.EncoderComplexitySetting? Complexity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InterleaveOutput? InterleaveOutput { get { throw null; } set { } }
        public float? KeyFrameIntervalInSeconds { get { throw null; } set { } }
        public int? MaxBitrateBps { get { throw null; } set { } }
        public int? MaxHeight { get { throw null; } set { } }
        public int? MaxLayers { get { throw null; } set { } }
        public int? MinBitrateBps { get { throw null; } set { } }
        public int? MinHeight { get { throw null; } set { } }
    }
    public partial class EncryptionSchemeDefaultKey
    {
        public EncryptionSchemeDefaultKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
    }
    public partial class EnvelopeEncryption
    {
        public EnvelopeEncryption() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> ClearTracks { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyContentKeys ContentKeys { get { throw null; } set { } }
        public System.Uri CustomKeyAcquisitionUriTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaEnabledProtocols EnabledProtocols { get { throw null; } set { } }
    }
    public partial class FilteringOperations
    {
        public FilteringOperations() { }
        public Azure.ResourceManager.Media.Models.RectangularWindowProperties Crop { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.DeinterlaceSettings Deinterlace { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.OverlayBasicProperties> Overlays { get { throw null; } }
        public Azure.ResourceManager.Media.Models.RotationSetting? Rotation { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Media.Models.FilterTrackPropertyType FourCharacterCode { get { throw null; } }
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
    public abstract partial class FormatBasicProperties
    {
        protected FormatBasicProperties(string filenamePattern) { }
        public string FilenamePattern { get { throw null; } set { } }
    }
    public partial class FromAllInputFile : Azure.ResourceManager.Media.Models.MediaTransformJobInputDefinition
    {
        public FromAllInputFile() { }
    }
    public partial class FromEachInputFile : Azure.ResourceManager.Media.Models.MediaTransformJobInputDefinition
    {
        public FromEachInputFile() { }
    }
    public partial class GetContainerSasContent
    {
        public GetContainerSasContent() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.AssetContainerPermission? Permissions { get { throw null; } set { } }
    }
    public partial class GetEdgePoliciesContent
    {
        public GetEdgePoliciesContent() { }
        public string DeviceId { get { throw null; } set { } }
    }
    public partial class GetPathsResult
    {
        internal GetPathsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> DownloadPaths { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.StreamingPath> StreamingPaths { get { throw null; } }
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
        public float? ConstantRateFactor { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LayerEntropyMode? EntropyMode { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Abr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Cbr { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.H264RateControlMode Crf { get { throw null; } }
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
    public partial class H264Video : Azure.ResourceManager.Media.Models.InputVideoEncodingProperties
    {
        public H264Video() { }
        public Azure.ResourceManager.Media.Models.H264Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H264Layer> Layers { get { throw null; } }
        public Azure.ResourceManager.Media.Models.H264RateControlMode? RateControlMode { get { throw null; } set { } }
        public bool? UseSceneChangeDetection { get { throw null; } set { } }
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
    public partial class H265Video : Azure.ResourceManager.Media.Models.InputVideoEncodingProperties
    {
        public H265Video() { }
        public Azure.ResourceManager.Media.Models.H265Complexity? Complexity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.H265Layer> Layers { get { throw null; } }
        public bool? UseSceneChangeDetection { get { throw null; } set { } }
    }
    public partial class H265VideoLayer : Azure.ResourceManager.Media.Models.VideoOrImageLayerProperties
    {
        public H265VideoLayer(int bitrate) { }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
        public bool? UseAdaptiveBFrame { get { throw null; } set { } }
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
        public bool? IsDefault { get { throw null; } set { } }
        public bool? IsForced { get { throw null; } set { } }
    }
    public partial class ImageBasicProperties : Azure.ResourceManager.Media.Models.InputVideoEncodingProperties
    {
        public ImageBasicProperties(string start) { }
        public string Range { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        public string Step { get { throw null; } set { } }
    }
    public partial class InputVideoEncodingProperties : Azure.ResourceManager.Media.Models.CodecBasicProperties
    {
        public InputVideoEncodingProperties() { }
        public System.TimeSpan? KeyFrameInterval { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.InputVideoStretchMode? StretchMode { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.VideoSyncMode? SyncMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputVideoStretchMode : System.IEquatable<Azure.ResourceManager.Media.Models.InputVideoStretchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputVideoStretchMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode AutoFit { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode AutoSize { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.InputVideoStretchMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.InputVideoStretchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.InputVideoStretchMode left, Azure.ResourceManager.Media.Models.InputVideoStretchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.InputVideoStretchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.InputVideoStretchMode left, Azure.ResourceManager.Media.Models.InputVideoStretchMode right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlDefaultAction : System.IEquatable<Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction left, Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction left, Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRange
    {
        public IPRange() { }
        public System.Net.IPAddress Address { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? SubnetPrefixLength { get { throw null; } set { } }
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
    public partial class JpgFormat : Azure.ResourceManager.Media.Models.OutputImageFileFormat
    {
        public JpgFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class JpgImage : Azure.ResourceManager.Media.Models.ImageBasicProperties
    {
        public JpgImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.JpgLayer> Layers { get { throw null; } }
        public int? SpriteColumn { get { throw null; } set { } }
    }
    public partial class JpgLayer : Azure.ResourceManager.Media.Models.VideoOrImageLayerProperties
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LayerEntropyMode : System.IEquatable<Azure.ResourceManager.Media.Models.LayerEntropyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LayerEntropyMode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LayerEntropyMode ContextAdaptiveBinaryArithmeticCoder { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.LayerEntropyMode ContextAdaptiveVariableLengthCoder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.LayerEntropyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.LayerEntropyMode left, Azure.ResourceManager.Media.Models.LayerEntropyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.LayerEntropyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.LayerEntropyMode left, Azure.ResourceManager.Media.Models.LayerEntropyMode right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Media.Models.InputVideoStretchMode? StretchMode { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllowedIPs { get { throw null; } }
        public System.TimeSpan? KeyFrameIntervalDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.LiveEventInputProtocol StreamingProtocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiveEventInputProtocol : System.IEquatable<Azure.ResourceManager.Media.Models.LiveEventInputProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiveEventInputProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.LiveEventInputProtocol FragmentedMp4 { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> IPAllowedIPs { get { throw null; } }
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
    public partial class MediaAccessControl
    {
        public MediaAccessControl() { }
        public Azure.ResourceManager.Media.Models.IPAccessControlDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> IPAllowList { get { throw null; } }
    }
    public partial class MediaEnabledProtocols
    {
        public MediaEnabledProtocols(bool isDownloadEnabled, bool isDashEnabled, bool isHttpLiveStreamingEnabled, bool isSmoothStreamingEnabled) { }
        public bool IsDashEnabled { get { throw null; } set { } }
        public bool IsDownloadEnabled { get { throw null; } set { } }
        public bool IsHttpLiveStreamingEnabled { get { throw null; } set { } }
        public bool IsSmoothStreamingEnabled { get { throw null; } set { } }
    }
    public partial class MediaNameAvailabilityContent
    {
        public MediaNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class MediaNameAvailabilityResult
    {
        internal MediaNameAvailabilityResult() { }
        public bool IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public abstract partial class MediaPreset
    {
        protected MediaPreset() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaProvisioningState : System.IEquatable<Azure.ResourceManager.Media.Models.MediaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaProvisioningState left, Azure.ResourceManager.Media.Models.MediaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaProvisioningState left, Azure.ResourceManager.Media.Models.MediaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaPublicNetworkAccessStatus : System.IEquatable<Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaPublicNetworkAccessStatus(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus left, Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus left, Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaServicesAccountPatch
    {
        public MediaServicesAccountPatch() { }
        public Azure.ResourceManager.Media.Models.AccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaAccessControl KeyDeliveryAccessControl { get { throw null; } set { } }
        public System.Guid? MediaServiceId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.MediaServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaPublicNetworkAccessStatus? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaServicesStorageAccount> StorageAccounts { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaStorageAuthentication? StorageAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MediaServicesOperationStatus
    {
        internal MediaServicesOperationStatus() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class MediaServicesStorageAccount
    {
        public MediaServicesStorageAccount(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType accountType) { }
        public Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType AccountType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaServicesStorageAccountType : System.IEquatable<Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaServicesStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType Primary { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType left, Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType left, Azure.ResourceManager.Media.Models.MediaServicesStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaStorageAuthentication : System.IEquatable<Azure.ResourceManager.Media.Models.MediaStorageAuthentication>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaStorageAuthentication(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaStorageAuthentication ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaStorageAuthentication System { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaStorageAuthentication other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaStorageAuthentication left, Azure.ResourceManager.Media.Models.MediaStorageAuthentication right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaStorageAuthentication (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaStorageAuthentication left, Azure.ResourceManager.Media.Models.MediaStorageAuthentication right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaTrackSelection
    {
        public MediaTrackSelection() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackPropertyCondition> TrackSelections { get { throw null; } }
    }
    public partial class MediaTransformJobError
    {
        internal MediaTransformJobError() { }
        public Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory? Category { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.MediaTransformJobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaTransformJobRetry? Retry { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaTransformJobErrorCategory : System.IEquatable<Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaTransformJobErrorCategory(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory Configuration { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory Content { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory Download { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory Service { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory left, Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory left, Azure.ResourceManager.Media.Models.MediaTransformJobErrorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaTransformJobErrorCode : System.IEquatable<Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaTransformJobErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode ConfigurationUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode ContentMalformed { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode ContentUnsupported { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode DownloadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode DownloadTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode ServiceError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode ServiceTransientError { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode UploadNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode UploadTransientError { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode left, Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode left, Azure.ResourceManager.Media.Models.MediaTransformJobErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaTransformJobErrorDetail
    {
        internal MediaTransformJobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class MediaTransformJobInputAsset : Azure.ResourceManager.Media.Models.MediaTransformJobInputClip
    {
        public MediaTransformJobInputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
    }
    public abstract partial class MediaTransformJobInputBasicProperties
    {
        protected MediaTransformJobInputBasicProperties() { }
    }
    public partial class MediaTransformJobInputClip : Azure.ResourceManager.Media.Models.MediaTransformJobInputBasicProperties
    {
        public MediaTransformJobInputClip() { }
        public Azure.ResourceManager.Media.Models.ClipTime End { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformJobInputDefinition> InputDefinitions { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.ClipTime Start { get { throw null; } set { } }
    }
    public abstract partial class MediaTransformJobInputDefinition
    {
        protected MediaTransformJobInputDefinition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.TrackDescriptor> IncludedTracks { get { throw null; } }
    }
    public partial class MediaTransformJobInputFile : Azure.ResourceManager.Media.Models.MediaTransformJobInputDefinition
    {
        public MediaTransformJobInputFile() { }
        public string Filename { get { throw null; } set { } }
    }
    public partial class MediaTransformJobInputHttp : Azure.ResourceManager.Media.Models.MediaTransformJobInputClip
    {
        public MediaTransformJobInputHttp() { }
        public System.Uri BaseUri { get { throw null; } set { } }
    }
    public partial class MediaTransformJobInputs : Azure.ResourceManager.Media.Models.MediaTransformJobInputBasicProperties
    {
        public MediaTransformJobInputs() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformJobInputBasicProperties> Inputs { get { throw null; } }
    }
    public partial class MediaTransformJobInputSequence : Azure.ResourceManager.Media.Models.MediaTransformJobInputBasicProperties
    {
        public MediaTransformJobInputSequence() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTransformJobInputClip> Inputs { get { throw null; } }
    }
    public abstract partial class MediaTransformJobOutput
    {
        protected MediaTransformJobOutput() { }
        public System.DateTimeOffset? EndsOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.MediaTransformJobError Error { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaPreset PresetOverride { get { throw null; } set { } }
        public int? Progress { get { throw null; } }
        public System.DateTimeOffset? StartsOn { get { throw null; } }
        public Azure.ResourceManager.Media.Models.JobState? State { get { throw null; } }
    }
    public partial class MediaTransformJobOutputAsset : Azure.ResourceManager.Media.Models.MediaTransformJobOutput
    {
        public MediaTransformJobOutputAsset(string assetName) { }
        public string AssetName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaTransformJobRetry : System.IEquatable<Azure.ResourceManager.Media.Models.MediaTransformJobRetry>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaTransformJobRetry(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobRetry DoNotRetry { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformJobRetry MayRetry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaTransformJobRetry other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaTransformJobRetry left, Azure.ResourceManager.Media.Models.MediaTransformJobRetry right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaTransformJobRetry (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaTransformJobRetry left, Azure.ResourceManager.Media.Models.MediaTransformJobRetry right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaTransformOutput
    {
        public MediaTransformOutput(Azure.ResourceManager.Media.Models.MediaPreset preset) { }
        public Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction? OnError { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.MediaPreset Preset { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.TransformOutputsPriority? RelativePriority { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaTransformOutputErrorAction : System.IEquatable<Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaTransformOutputErrorAction(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction ContinueJob { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction StopProcessingJob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction left, Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction left, Azure.ResourceManager.Media.Models.MediaTransformOutputErrorAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Mp4Format : Azure.ResourceManager.Media.Models.MultiBitrateFormat
    {
        public Mp4Format(string filenamePattern) : base (default(string)) { }
    }
    public partial class MultiBitrateFormat : Azure.ResourceManager.Media.Models.FormatBasicProperties
    {
        public MultiBitrateFormat(string filenamePattern) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MultiBitrateOutputFile> OutputFiles { get { throw null; } }
    }
    public partial class MultiBitrateOutputFile
    {
        public MultiBitrateOutputFile(System.Collections.Generic.IEnumerable<string> labels) { }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
    }
    public partial class OutputImageFileFormat : Azure.ResourceManager.Media.Models.FormatBasicProperties
    {
        public OutputImageFileFormat(string filenamePattern) : base (default(string)) { }
    }
    public abstract partial class OverlayBasicProperties
    {
        protected OverlayBasicProperties(string inputLabel) { }
        public double? AudioGainLevel { get { throw null; } set { } }
        public System.TimeSpan? End { get { throw null; } set { } }
        public System.TimeSpan? FadeInDuration { get { throw null; } set { } }
        public System.TimeSpan? FadeOutDuration { get { throw null; } set { } }
        public string InputLabel { get { throw null; } set { } }
        public System.TimeSpan? Start { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlayerVisibility : System.IEquatable<Azure.ResourceManager.Media.Models.PlayerVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlayerVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.PlayerVisibility Hidden { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.PlayerVisibility Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.PlayerVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.PlayerVisibility left, Azure.ResourceManager.Media.Models.PlayerVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.PlayerVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.PlayerVisibility left, Azure.ResourceManager.Media.Models.PlayerVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PngFormat : Azure.ResourceManager.Media.Models.OutputImageFileFormat
    {
        public PngFormat(string filenamePattern) : base (default(string)) { }
    }
    public partial class PngImage : Azure.ResourceManager.Media.Models.ImageBasicProperties
    {
        public PngImage(string start) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.PngLayer> Layers { get { throw null; } }
    }
    public partial class PngLayer : Azure.ResourceManager.Media.Models.VideoOrImageLayerProperties
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
    public partial class RectangularWindowProperties
    {
        public RectangularWindowProperties() { }
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
    public readonly partial struct RotationSetting : System.IEquatable<Azure.ResourceManager.Media.Models.RotationSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RotationSetting(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.RotationSetting Auto { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting None { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate0 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate180 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate270 { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.RotationSetting Rotate90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.RotationSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.RotationSetting left, Azure.ResourceManager.Media.Models.RotationSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.RotationSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.RotationSetting left, Azure.ResourceManager.Media.Models.RotationSetting right) { throw null; }
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
    public partial class StandardEncoderPreset : Azure.ResourceManager.Media.Models.MediaPreset
    {
        public StandardEncoderPreset(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.CodecBasicProperties> codecs, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Media.Models.FormatBasicProperties> formats) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.CodecBasicProperties> Codecs { get { throw null; } }
        public Azure.ResourceManager.Media.Models.FilteringOperations Filters { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.FormatBasicProperties> Formats { get { throw null; } }
    }
    public partial class StorageEncryptedAssetDecryptionInfo
    {
        internal StorageEncryptedAssetDecryptionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.AssetFileEncryptionMetadata> AssetFileEncryptionMetadata { get { throw null; } }
        public byte[] Key { get { throw null; } }
    }
    public partial class StreamingEndpointAccessControl
    {
        public StreamingEndpointAccessControl() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.AkamaiSignatureHeaderAuthenticationKey> AkamaiSignatureHeaderAuthenticationKeyList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.IPRange> AllowedIPs { get { throw null; } }
    }
    public partial class StreamingEndpointCapacity
    {
        internal StreamingEndpointCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public string ScaleType { get { throw null; } }
    }
    public partial class StreamingEndpointCurrentSku
    {
        public StreamingEndpointCurrentSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } }
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
    public partial class StreamingEndpointSkuInfo
    {
        internal StreamingEndpointSkuInfo() { }
        public Azure.ResourceManager.Media.Models.StreamingEndpointCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SkuName { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Media.Models.MediaTrackSelection> Tracks { get { throw null; } }
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
        public Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme EncryptionScheme { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public Azure.ResourceManager.Media.Models.StreamingPolicyStreamingProtocol StreamingProtocol { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamingPathEncryptionScheme : System.IEquatable<Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamingPathEncryptionScheme(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme CommonEncryptionCbcs { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme CommonEncryptionCenc { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme EnvelopeEncryption { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme NoEncryption { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme left, Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme left, Azure.ResourceManager.Media.Models.StreamingPathEncryptionScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingPolicyContentKey
    {
        public StreamingPolicyContentKey() { }
        public string Label { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.MediaTrackSelection> Tracks { get { throw null; } }
    }
    public partial class StreamingPolicyContentKeys
    {
        public StreamingPolicyContentKeys() { }
        public Azure.ResourceManager.Media.Models.EncryptionSchemeDefaultKey DefaultKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Media.Models.StreamingPolicyContentKey> KeyToTrackMappings { get { throw null; } }
    }
    public partial class StreamingPolicyFairPlayConfiguration
    {
        public StreamingPolicyFairPlayConfiguration(bool allowPersistentLicense) { }
        public bool AllowPersistentLicense { get { throw null; } set { } }
        public System.Uri CustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
    }
    public partial class StreamingPolicyPlayReadyConfiguration
    {
        public StreamingPolicyPlayReadyConfiguration() { }
        public System.Uri CustomLicenseAcquisitionUriTemplate { get { throw null; } set { } }
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
    public partial class SyncStorageKeysContent
    {
        public SyncStorageKeysContent() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class TextTrack : Azure.ResourceManager.Media.Models.AssetTrackInfo
    {
        public TextTrack() { }
        public string DisplayName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.HlsSettings HlsSettings { get { throw null; } set { } }
        public string LanguageCode { get { throw null; } }
        public Azure.ResourceManager.Media.Models.PlayerVisibility? PlayerVisibility { get { throw null; } set { } }
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
    public abstract partial class TrackDescriptor
    {
        protected TrackDescriptor() { }
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
        public static Azure.ResourceManager.Media.Models.TrackPropertyType FourCharacterCode { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformOutputsPriority : System.IEquatable<Azure.ResourceManager.Media.Models.TransformOutputsPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformOutputsPriority(string value) { throw null; }
        public static Azure.ResourceManager.Media.Models.TransformOutputsPriority High { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TransformOutputsPriority Low { get { throw null; } }
        public static Azure.ResourceManager.Media.Models.TransformOutputsPriority Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Media.Models.TransformOutputsPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Media.Models.TransformOutputsPriority left, Azure.ResourceManager.Media.Models.TransformOutputsPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Media.Models.TransformOutputsPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Media.Models.TransformOutputsPriority left, Azure.ResourceManager.Media.Models.TransformOutputsPriority right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class VideoAnalyzerPreset : Azure.ResourceManager.Media.Models.AudioAnalyzerPreset
    {
        public VideoAnalyzerPreset() { }
        public Azure.ResourceManager.Media.Models.InsightsType? InsightsToExtract { get { throw null; } set { } }
    }
    public partial class VideoLayer : Azure.ResourceManager.Media.Models.VideoOrImageLayerProperties
    {
        public VideoLayer(int bitrate) { }
        public int? BFrames { get { throw null; } set { } }
        public int Bitrate { get { throw null; } set { } }
        public string FrameRate { get { throw null; } set { } }
        public int? MaxBitrate { get { throw null; } set { } }
        public int? Slices { get { throw null; } set { } }
        public bool? UseAdaptiveBFrame { get { throw null; } set { } }
    }
    public partial class VideoOrImageLayerProperties
    {
        public VideoOrImageLayerProperties() { }
        public string Height { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
    }
    public partial class VideoOverlay : Azure.ResourceManager.Media.Models.OverlayBasicProperties
    {
        public VideoOverlay(string inputLabel) : base (default(string)) { }
        public Azure.ResourceManager.Media.Models.RectangularWindowProperties CropRectangle { get { throw null; } set { } }
        public double? Opacity { get { throw null; } set { } }
        public Azure.ResourceManager.Media.Models.RectangularWindowProperties Position { get { throw null; } set { } }
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
    public partial class VideoTrack : Azure.ResourceManager.Media.Models.AssetTrackInfo
    {
        public VideoTrack() { }
    }
    public partial class VideoTrackDescriptor : Azure.ResourceManager.Media.Models.TrackDescriptor
    {
        public VideoTrackDescriptor() { }
    }
}
