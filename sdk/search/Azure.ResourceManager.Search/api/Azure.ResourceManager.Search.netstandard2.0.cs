namespace Azure.ResourceManager.Search
{
    public static partial class SearchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceResource GetSearchServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceCollection GetSearchServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource GetSharedSearchServicePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult> UsageBySubscriptionSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult>> UsageBySubscriptionSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>
    {
        public SearchPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceResource> GetIfExists(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceResource>> GetIfExistsAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>
    {
        public SearchServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchSemanticSearch? SemanticSearch { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchServiceResource() { }
        public virtual Azure.ResourceManager.Search.SearchServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> CreateQueryKey(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>> CreateQueryKeyAsync(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueryKey(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueryKeyAsync(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult> GetAdminKey(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>> GetAdminKeyAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchService(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchServiceAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetSearchPrivateEndpointConnection(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetSearchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionCollection GetSearchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetSharedSearchServicePrivateLinkResource(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetSharedSearchServicePrivateLinkResourceAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceCollection GetSharedSearchServicePrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResources(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResourcesAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult> RegenerateAdminKey(Azure.ResourceManager.Search.Models.SearchServiceAdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>> RegenerateAdminKeyAsync(Azure.ResourceManager.Search.Models.SearchServiceAdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Update(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> UpdateAsync(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedSearchServicePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedSearchServicePrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Get(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>
    {
        public SharedSearchServicePrivateLinkResourceData() { }
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Search.Mocking
{
    public partial class MockableSearchArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchArmClient() { }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceResource GetSearchServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource GetSharedSearchServicePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSearchResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceCollection GetSearchServices() { throw null; }
    }
    public partial class MockableSearchSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServices(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServicesAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscription(Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscriptionAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult> UsageBySubscriptionSku(Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult>> UsageBySubscriptionSkuAsync(Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Search.Models
{
    public static partial class ArmSearchModelFactory
    {
        public static Azure.ResourceManager.Search.Models.QuotaUsageResult QuotaUsageResult(Azure.Core.ResourceIdentifier id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.Search.Models.QuotaUsageResultName name = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.QuotaUsageResultName QuotaUsageResultName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk SearchEncryptionWithCmk(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? enforcement = default(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement?), Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? encryptionComplianceStatus = default(Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus?)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData SearchPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResource SearchPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties SearchPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType> shareablePrivateLinkResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult SearchServiceAdminKeyResult(string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent SearchServiceNameAvailabilityContent(string name = null, Azure.ResourceManager.Search.Models.SearchServiceResourceType resourceType = default(Azure.ResourceManager.Search.Models.SearchServiceResourceType)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult SearchServiceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason? reason = default(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceQueryKey SearchServiceQueryKey(string name = null, string key = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties ShareableSearchServicePrivateLinkResourceProperties(string shareablePrivateLinkResourcePropertiesType = null, string groupId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType ShareableSearchServicePrivateLinkResourceType(string name = null, Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData SharedSearchServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
    }
    public partial class QuotaUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>
    {
        internal QuotaUsageResult() { }
        public int? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Search.Models.QuotaUsageResultName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        Azure.ResourceManager.Search.Models.QuotaUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaUsageResultName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>
    {
        internal QuotaUsageResultName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Search.Models.QuotaUsageResultName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResultName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchAadAuthDataPlaneAuthOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>
    {
        public SearchAadAuthDataPlaneAuthOptions() { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthFailureMode? AadAuthFailureMode { get { throw null; } set { } }
        public System.BinaryData ApiKeyOnly { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchAadAuthFailureMode
    {
        Http403 = 0,
        Http401WithBearerChallenge = 1,
    }
    public enum SearchEncryptionComplianceStatus
    {
        Compliant = 0,
        NonCompliant = 1,
    }
    public partial class SearchEncryptionWithCmk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>
    {
        public SearchEncryptionWithCmk() { }
        public Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? EncryptionComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? Enforcement { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchEncryptionWithCmkEnforcement
    {
        Unspecified = 0,
        Disabled = 1,
        Enabled = 2,
    }
    public partial class SearchManagementRequestOptions
    {
        public SearchManagementRequestOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
    }
    public partial class SearchPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>
    {
        public SearchPrivateLinkResource() { }
        public Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>
    {
        internal SearchPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchPrivateLinkServiceConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchPrivateLinkServiceConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Incomplete { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState left, Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState left, Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchSemanticSearch : System.IEquatable<Azure.ResourceManager.Search.Models.SearchSemanticSearch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchSemanticSearch(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Disabled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Free { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchSemanticSearch other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchSemanticSearch left, Azure.ResourceManager.Search.Models.SearchSemanticSearch right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchSemanticSearch (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchSemanticSearch left, Azure.ResourceManager.Search.Models.SearchSemanticSearch right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SearchServiceAdminKeyKind
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class SearchServiceAdminKeyResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>
    {
        internal SearchServiceAdminKeyResult() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchServiceHostingMode
    {
        Default = 0,
        HighDensity = 1,
    }
    public partial class SearchServiceIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>
    {
        public SearchServiceIPRule() { }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SearchServiceIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>
    {
        public SearchServiceNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceResourceType ResourceType { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>
    {
        internal SearchServiceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason? Reason { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason left, Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason left, Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServicePatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>
    {
        public SearchServicePatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchSemanticSearch? SemanticSearch { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServicePrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>
    {
        public SearchServicePrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServicePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>
    {
        public SearchServicePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchServicePrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum SearchServiceProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
    }
    public enum SearchServicePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SearchServiceQueryKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>
    {
        internal SearchServiceQueryKey() { }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Search.Models.SearchServiceQueryKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceQueryKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceResourceType : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceResourceType SearchServices { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceResourceType left, Azure.ResourceManager.Search.Models.SearchServiceResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceResourceType left, Azure.ResourceManager.Search.Models.SearchServiceResourceType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ShareableSearchServicePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>
    {
        internal ShareableSearchServicePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string ShareablePrivateLinkResourcePropertiesType { get { throw null; } }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareableSearchServicePrivateLinkResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>
    {
        internal ShareableSearchServicePrivateLinkResourceType() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>
    {
        public SharedSearchServicePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceRegion { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SharedSearchServicePrivateLinkResourceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
    }
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
}
