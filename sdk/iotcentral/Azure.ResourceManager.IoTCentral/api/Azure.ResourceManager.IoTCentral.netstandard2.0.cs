namespace Azure.ResourceManager.IoTCentral
{
    public partial class IoTCentralAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>, System.Collections.IEnumerable
    {
        protected IoTCentralAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IoTCentral.IoTCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IoTCentral.IoTCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTCentralAppData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IoTCentralAppData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Guid? ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
    }
    public partial class IoTCentralAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTCentralAppResource() { }
        public virtual Azure.ResourceManager.IoTCentral.IoTCentralAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> GetIoTCentralPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>> GetIoTCentralPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionCollection GetIoTCentralPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> GetIoTCentralPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>> GetIoTCentralPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResourceCollection GetIoTCentralPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IoTCentralExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityResponse> CheckIoTCentralAppNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityResponse>> CheckIoTCentralAppNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityResponse> CheckIoTCentralAppSubdomainAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityResponse>> CheckIoTCentralAppSubdomainAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> GetIoTCentralApp(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralAppResource>> GetIoTCentralAppAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTCentral.IoTCentralAppResource GetIoTCentralAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTCentral.IoTCentralAppCollection GetIoTCentralApps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> GetIoTCentralApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTCentral.IoTCentralAppResource> GetIoTCentralAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource GetIoTCentralPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource GetIoTCentralPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppTemplate> GetTemplatesApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppTemplate> GetTemplatesAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTCentralPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IoTCentralPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTCentralPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public IoTCentralPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IoTCentralPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTCentralPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTCentralPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IoTCentralPrivateLinkResource() { }
        public virtual Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IoTCentralPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected IoTCentralPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTCentral.IoTCentralPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IoTCentralPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public IoTCentralPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
}
namespace Azure.ResourceManager.IoTCentral.Models
{
    public partial class IoTCentralAppNameAvailabilityContent
    {
        public IoTCentralAppNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class IoTCentralAppNameAvailabilityResponse
    {
        internal IoTCentralAppNameAvailabilityResponse() { }
        public string IoTCentralAppNameUnavailableReason { get { throw null; } }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class IoTCentralAppPatch
    {
        public IoTCentralAppPatch() { }
        public System.Guid? ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTCentral.IoTCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Template { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralAppSku : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralAppSku(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku ST0 { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku ST1 { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku ST2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku left, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku left, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTCentralAppSkuInfo
    {
        public IoTCentralAppSkuInfo(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku name) { }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralAppSku Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralAppState : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralAppState(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState Created { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralAppState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTCentralAppTemplate
    {
        internal IoTCentralAppTemplate() { }
        public string Description { get { throw null; } }
        public string Industry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTCentral.Models.IoTCentralAppTemplateLocation> Locations { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public float? Order { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class IoTCentralAppTemplateLocation
    {
        internal IoTCentralAppTemplateLocation() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralNetworkAction : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralNetworkAction(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction left, Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction left, Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTCentralNetworkRuleSetIPRule
    {
        public IoTCentralNetworkRuleSetIPRule() { }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class IoTCentralNetworkRuleSets
    {
        public IoTCentralNetworkRuleSets() { }
        public bool? ApplyToDevices { get { throw null; } set { } }
        public bool? ApplyToIoTCentral { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTCentral.Models.IoTCentralNetworkRuleSetIPRule> IPRules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTCentralPrivateLinkServiceConnectionState
    {
        public IoTCentralPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IoTCentral.Models.IoTCentralPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralProvisioningState : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState left, Azure.ResourceManager.IoTCentral.Models.IoTCentralProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IoTCentralPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IoTCentralPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess left, Azure.ResourceManager.IoTCentral.Models.IoTCentralPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
