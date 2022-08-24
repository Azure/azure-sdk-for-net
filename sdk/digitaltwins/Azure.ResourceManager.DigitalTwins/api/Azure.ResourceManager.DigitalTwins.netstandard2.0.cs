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
        public Azure.ResourceManager.DigitalTwins.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.DigitalTwins.GroupIdInformationCollection GetAllGroupIdInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource> GetDigitalTwinsEndpointResource(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource>> GetDigitalTwinsEndpointResourceAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResourceCollection GetDigitalTwinsEndpointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource> GetDigitalTwinsPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource>> GetDigitalTwinsPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionCollection GetDigitalTwinsPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> GetGroupIdInformation(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>> GetGroupIdInformationAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.DigitalTwins.Models.CheckNameResult> CheckNameAvailabilityDigitalTwin(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.CheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.CheckNameResult>> CheckNameAvailabilityDigitalTwinAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DigitalTwins.Models.CheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource>> GetDigitalTwinsDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource GetDigitalTwinsDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionCollection GetDigitalTwinsDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.DigitalTwinsDescriptionResource> GetDigitalTwinsDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointResource GetDigitalTwinsEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.DigitalTwinsPrivateEndpointConnectionResource GetDigitalTwinsPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.GroupIdInformationResource GetGroupIdInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public DigitalTwinsPrivateEndpointConnectionData(Azure.ResourceManager.DigitalTwins.Models.ConnectionProperties properties) { }
        public Azure.ResourceManager.DigitalTwins.Models.ConnectionProperties Properties { get { throw null; } set { } }
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
    public partial class GroupIdInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>, System.Collections.IEnumerable
    {
        protected GroupIdInformationCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> Get(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>> GetAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupIdInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal GroupIdInformationData() { }
        public Azure.ResourceManager.DigitalTwins.Models.GroupIdInformationProperties Properties { get { throw null; } }
    }
    public partial class GroupIdInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupIdInformationResource() { }
        public virtual Azure.ResourceManager.DigitalTwins.GroupIdInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string resourceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.GroupIdInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DigitalTwins.TimeSeriesDatabaseConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalTwins.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.AuthenticationType IdentityBased { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.AuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.AuthenticationType left, Azure.ResourceManager.DigitalTwins.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.AuthenticationType left, Azure.ResourceManager.DigitalTwins.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureDataExplorerConnectionProperties : Azure.ResourceManager.DigitalTwins.Models.TimeSeriesDatabaseConnectionProperties
    {
        public AzureDataExplorerConnectionProperties(string adxResourceId, System.Uri adxEndpointUri, string adxDatabaseName, System.Uri eventHubEndpointUri, string eventHubEntityPath, string eventHubNamespaceResourceId) { }
        public string AdxDatabaseName { get { throw null; } set { } }
        public System.Uri AdxEndpointUri { get { throw null; } set { } }
        public string AdxResourceId { get { throw null; } set { } }
        public string AdxTableName { get { throw null; } set { } }
        public string EventHubConsumerGroup { get { throw null; } set { } }
        public System.Uri EventHubEndpointUri { get { throw null; } set { } }
        public string EventHubEntityPath { get { throw null; } set { } }
        public string EventHubNamespaceResourceId { get { throw null; } set { } }
    }
    public partial class CheckNameContent
    {
        public CheckNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.ResourceType ResourceType { get { throw null; } }
    }
    public partial class CheckNameResult
    {
        internal CheckNameResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.Reason? Reason { get { throw null; } }
    }
    public partial class ConnectionProperties
    {
        public ConnectionProperties() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ConnectionPropertiesPrivateLinkServiceConnectionState : Azure.ResourceManager.DigitalTwins.Models.ConnectionState
    {
        public ConnectionPropertiesPrivateLinkServiceConnectionState(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus status, string description) : base (default(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus), default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState Approved { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ConnectionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectionState
    {
        public ConnectionState(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus status, string description) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
    }
    public partial class DigitalTwinsDescriptionPatch
    {
        public DigitalTwinsDescriptionPatch() { }
        public Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess? DigitalTwinsPatchPublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DigitalTwinsEndpointResourceProperties
    {
        public DigitalTwinsEndpointResourceProperties() { }
        public Azure.ResourceManager.DigitalTwins.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DeadLetterSecret { get { throw null; } set { } }
        public System.Uri DeadLetterUri { get { throw null; } set { } }
        public Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGrid : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public EventGrid(string topicEndpoint, string accessKey1) { }
        public string AccessKey1 { get { throw null; } set { } }
        public string AccessKey2 { get { throw null; } set { } }
        public string TopicEndpoint { get { throw null; } set { } }
    }
    public partial class EventHub : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public EventHub() { }
        public string ConnectionStringPrimaryKey { get { throw null; } set { } }
        public string ConnectionStringSecondaryKey { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
    }
    public partial class GroupIdInformationProperties
    {
        internal GroupIdInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.DigitalTwins.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess left, Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess left, Azure.ResourceManager.DigitalTwins.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.Reason left, Azure.ResourceManager.DigitalTwins.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.Reason left, Azure.ResourceManager.DigitalTwins.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.ResourceType MicrosoftDigitalTwinsDigitalTwinsInstances { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.ResourceType left, Azure.ResourceManager.DigitalTwins.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.ResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.ResourceType left, Azure.ResourceManager.DigitalTwins.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceBus : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public ServiceBus() { }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public string EntityPath { get { throw null; } set { } }
        public string PrimaryConnectionString { get { throw null; } set { } }
        public string SecondaryConnectionString { get { throw null; } set { } }
    }
    public partial class TimeSeriesDatabaseConnectionProperties
    {
        public TimeSeriesDatabaseConnectionProperties() { }
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
