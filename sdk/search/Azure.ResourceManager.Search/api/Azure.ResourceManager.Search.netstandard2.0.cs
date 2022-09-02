namespace Azure.ResourceManager.Search
{
    public static partial class SearchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Search.Models.CheckNameAvailabilityOutput> CheckNameAvailabilityService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.CheckNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.CheckNameAvailabilityOutput>> CheckNameAvailabilityServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.CheckNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceResource GetSearchServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceCollection GetSearchServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SharedPrivateLinkResource GetSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SearchPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public SearchPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Search.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class SearchPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceResource>, System.Collections.IEnumerable
    {
        protected SearchServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string searchServiceName, Azure.ResourceManager.Search.SearchServiceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string searchServiceName, Azure.ResourceManager.Search.SearchServiceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Get(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SearchServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Search.Models.HostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.IPRule> IPRules { get { throw null; } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
    }
    public partial class SearchServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchServiceResource() { }
        public virtual Azure.ResourceManager.Search.SearchServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.QueryKey> CreateQueryKey(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.QueryKey>> CreateQueryKeyAsync(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueryKey(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueryKeyAsync(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.AdminKeyResult> GetAdminKey(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.AdminKeyResult>> GetAdminKeyAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.QueryKey> GetQueryKeysBySearchService(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.QueryKey> GetQueryKeysBySearchServiceAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetSearchPrivateEndpointConnection(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetSearchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionCollection GetSearchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource> GetSharedPrivateLinkResource(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource>> GetSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SharedPrivateLinkResourceCollection GetSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResources(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResourcesAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.AdminKeyResult> RegenerateAdminKey(Azure.ResourceManager.Search.Models.AdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.AdminKeyResult>> RegenerateAdminKeyAsync(Azure.ResourceManager.Search.Models.AdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Update(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> UpdateAsync(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Search.SharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedPrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedPrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedPrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedPrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SharedPrivateLinkResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SharedPrivateLinkResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SharedPrivateLinkResourceData() { }
        public Azure.ResourceManager.Search.Models.SharedPrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Search.Models
{
    public enum AdminKeyKind
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class AdminKeyResult
    {
        internal AdminKeyResult() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ResourceType ResourceType { get { throw null; } }
    }
    public partial class CheckNameAvailabilityOutput
    {
        internal CheckNameAvailabilityOutput() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Search.Models.UnavailableNameReason? Reason { get { throw null; } }
    }
    public enum HostingMode
    {
        Default = 0,
        HighDensity = 1,
    }
    public partial class IPRule
    {
        public IPRule() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Search.Models.PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState
    {
        public PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.PrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public enum PrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum ProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class QueryKey
    {
        internal QueryKey() { }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.Search.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.ResourceType SearchServices { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.ResourceType left, Azure.ResourceManager.Search.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.ResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.ResourceType left, Azure.ResourceManager.Search.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchManagementRequestOptions
    {
        public SearchManagementRequestOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
    }
    public partial class SearchPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public SearchPrivateLinkResource() { }
        public Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class SearchPrivateLinkResourceProperties
    {
        internal SearchPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.ShareablePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
    }
    public partial class SearchServicePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SearchServicePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Search.Models.HostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.IPRule> IPRules { get { throw null; } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
    }
    public enum SearchServiceStatus
    {
        Running = 0,
        Provisioning = 1,
        Deleting = 2,
        Degraded = 3,
        Disabled = 4,
        Error = 5,
    }
    public enum SearchSkuName
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Standard2 = 3,
        Standard3 = 4,
        StorageOptimizedL1 = 5,
        StorageOptimizedL2 = 6,
    }
    public partial class ShareablePrivateLinkResourceProperties
    {
        internal ShareablePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string ShareablePrivateLinkResourcePropertiesType { get { throw null; } }
    }
    public partial class ShareablePrivateLinkResourceType
    {
        internal ShareablePrivateLinkResourceType() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ShareablePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class SharedPrivateLinkResourceProperties
    {
        public SharedPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SharedPrivateLinkResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public string ResourceRegion { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } set { } }
    }
    public enum SharedPrivateLinkResourceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
    }
    public enum SharedPrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnavailableNameReason : System.IEquatable<Azure.ResourceManager.Search.Models.UnavailableNameReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnavailableNameReason(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.UnavailableNameReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.UnavailableNameReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.UnavailableNameReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.UnavailableNameReason left, Azure.ResourceManager.Search.Models.UnavailableNameReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.UnavailableNameReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.UnavailableNameReason left, Azure.ResourceManager.Search.Models.UnavailableNameReason right) { throw null; }
        public override string ToString() { throw null; }
    }
}
