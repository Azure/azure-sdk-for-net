namespace Azure.ResourceManager.DigitalTwins
{
    public partial class DigitalTwinsDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>, System.Collections.IEnumerable
    {
        protected DigitalTwinsDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DigitalTwinsDescriptionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DigitalTwinsDescriptionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class DigitalTwinsDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DigitalTwinsDescriptionResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> GetDigitalTwinsEndpointResource(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> GetDigitalTwinsEndpointResourceAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceCollection GetDigitalTwinsEndpointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> GetDigitalTwinsPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> GetDigitalTwinsPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionCollection GetDigitalTwinsPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> GetDigitalTwinsPrivateLinkResource(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>> GetDigitalTwinsPrivateLinkResourceAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResourceCollection GetDigitalTwinsPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> GetTimeSeriesDatabaseConnection(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> GetTimeSeriesDatabaseConnectionAsync(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionCollection GetTimeSeriesDatabaseConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DigitalTwinsEndpointResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsEndpointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>, System.Collections.IEnumerable
    {
        protected DigitalTwinsEndpointResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DigitalTwinsEndpointResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DigitalTwinsEndpointResourceData(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties properties) { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties Properties { get { throw null; } set { } }
    }
    public static partial class DigitalTwinsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameResult> CheckDigitalTwinsNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameResult>> CheckDigitalTwinsNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> GetDigitalTwinsDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource GetDigitalTwinsDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionCollection GetDigitalTwinsDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource GetDigitalTwinsEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource GetDigitalTwinsPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource GetDigitalTwinsPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource GetTimeSeriesDatabaseConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DigitalTwinsPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DigitalTwinsPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DigitalTwinsPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DigitalTwinsPrivateEndpointConnectionData(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class DigitalTwinsPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DigitalTwinsPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DigitalTwinsPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string resourceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DigitalTwinsPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> Get(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>> GetAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DigitalTwinsPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal DigitalTwinsPrivateLinkResourceData() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class TimeSeriesDatabaseConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>, System.Collections.IEnumerable
    {
        protected TimeSeriesDatabaseConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string timeSeriesDatabaseConnectionName, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string timeSeriesDatabaseConnectionName, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Get(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> GetAsync(string timeSeriesDatabaseConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TimeSeriesDatabaseConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public TimeSeriesDatabaseConnectionData() { }
        public Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class TimeSeriesDatabaseConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TimeSeriesDatabaseConnectionResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string timeSeriesDatabaseConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact? cleanupConnectionArtifacts = default(Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact? cleanupConnectionArtifacts = default(Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalTwins.Mock
{
    public partial class DigitalTwinsDescriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected DigitalTwinsDescriptionResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameResult> CheckDigitalTwinsNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameResult>> CheckDigitalTwinsNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionCollection GetDigitalTwinsDescriptions() { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalTwins.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CleanupConnectionArtifact : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CleanupConnectionArtifact(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact False { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact left, Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact left, Azure.ResourceManager.DigitalTwins.Models.CleanupConnectionArtifact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataExplorerConnectionProperties : Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionProperties
    {
        public DataExplorerConnectionProperties(Azure.Core.ResourceIdentifier adxResourceId, System.Uri adxEndpointUri, string adxDatabaseName, System.Uri eventHubEndpointUri, string eventHubEntityPath, Azure.Core.ResourceIdentifier eventHubNamespaceResourceId) { }
        public string AdxDatabaseName { get { throw null; } set { } }
        public System.Uri AdxEndpointUri { get { throw null; } set { } }
        public string AdxRelationshipLifecycleEventsTableName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AdxResourceId { get { throw null; } set { } }
        public string AdxTableName { get { throw null; } set { } }
        public string AdxTwinLifecycleEventsTableName { get { throw null; } set { } }
        public string EventHubConsumerGroup { get { throw null; } set { } }
        public System.Uri EventHubEndpointUri { get { throw null; } set { } }
        public string EventHubEntityPath { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubNamespaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval? RecordPropertyAndItemRemovals { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsAuthenticationType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigitalTwinsDescriptionPatch
    {
        public DigitalTwinsDescriptionPatch() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess? DigitalTwinsPatchPublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DigitalTwinsEndpointResourceProperties
    {
        protected DigitalTwinsEndpointResourceProperties() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DeadLetterSecret { get { throw null; } set { } }
        public System.Uri DeadLetterUri { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityReference Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DigitalTwinsEventGridProperties : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public DigitalTwinsEventGridProperties(string topicEndpoint, string accessKey1) { }
        public string AccessKey1 { get { throw null; } set { } }
        public string AccessKey2 { get { throw null; } set { } }
        public string TopicEndpoint { get { throw null; } set { } }
    }
    public partial class DigitalTwinsEventHubProperties : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public DigitalTwinsEventHubProperties() { }
        public string ConnectionStringPrimaryKey { get { throw null; } set { } }
        public string ConnectionStringSecondaryKey { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
    }
    public partial class DigitalTwinsManagedIdentityReference
    {
        public DigitalTwinsManagedIdentityReference() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsManagedIdentityType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigitalTwinsNameContent
    {
        public DigitalTwinsNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType ResourceType { get { throw null; } }
    }
    public partial class DigitalTwinsNameResult
    {
        internal DigitalTwinsNameResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigitalTwinsPrivateEndpointConnectionProperties
    {
        public DigitalTwinsPrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DigitalTwinsPrivateLinkResourceProperties
    {
        internal DigitalTwinsPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsPrivateLinkResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsPrivateLinkResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState Approved { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigitalTwinsPrivateLinkServiceConnectionState
    {
        public DigitalTwinsPrivateLinkServiceConnectionState(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalTwinsResourceType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalTwinsResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType MicrosoftDigitalTwinsDigitalTwinsInstances { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType left, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigitalTwinsServiceBusProperties : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public DigitalTwinsServiceBusProperties() { }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public string PrimaryConnectionString { get { throw null; } set { } }
        public string SecondaryConnectionString { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordPropertyAndItemRemoval : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordPropertyAndItemRemoval(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval False { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval left, Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval left, Azure.ResourceManager.DigitalTwins.Models.RecordPropertyAndItemRemoval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TimeSeriesDatabaseConnectionProperties
    {
        protected TimeSeriesDatabaseConnectionProperties() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsManagedIdentityReference Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeSeriesDatabaseConnectionState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeSeriesDatabaseConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Moving { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Updating { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState left, Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState left, Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
