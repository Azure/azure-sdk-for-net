namespace Azure.ResourceManager.IotCentral
{
    public partial class IotCentralAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>, System.Collections.IEnumerable
    {
        protected IotCentralAppCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotCentral.IotCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.IotCentral.IotCentralAppData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralAppData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotCentralAppData(Azure.Core.AzureLocation location, Azure.ResourceManager.IotCentral.Models.AppSkuInfo sku) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.NetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.AppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.AppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public string Template { get { throw null; } set { } }
    }
    public partial class IotCentralAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralAppResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetIotCentralPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetIotCentralPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionCollection GetIotCentralPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetIotCentralPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetIotCentralPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceCollection GetIotCentralPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.Models.IotCentralAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotCentralExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IotCentral.Models.AppAvailabilityInfo> CheckNameAvailabilityApp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.AppAvailabilityInfo>> CheckNameAvailabilityAppAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotCentral.Models.AppAvailabilityInfo> CheckSubdomainAvailabilityApp(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.Models.AppAvailabilityInfo>> CheckSubdomainAvailabilityAppAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.IotCentral.Models.OperationInputs operationInputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApp(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralAppResource>> GetIotCentralAppAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralAppResource GetIotCentralAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralAppCollection GetIotCentralApps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralAppResource> GetIotCentralAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource GetIotCentralPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource GetIotCentralPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotCentral.Models.AppTemplate> GetTemplatesApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotCentral.Models.AppTemplate> GetTemplatesAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected IotCentralPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public IotCentralPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IotCentralPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotCentralPrivateLinkResource() { }
        public virtual Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotCentralPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected IotCentralPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotCentral.IotCentralPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotCentralPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public IotCentralPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
}
namespace Azure.ResourceManager.IotCentral.Models
{
    public partial class AppAvailabilityInfo
    {
        internal AppAvailabilityInfo() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppSku : System.IEquatable<Azure.ResourceManager.IotCentral.Models.AppSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppSku(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.AppSku ST0 { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.AppSku ST1 { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.AppSku ST2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.AppSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.AppSku left, Azure.ResourceManager.IotCentral.Models.AppSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.AppSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.AppSku left, Azure.ResourceManager.IotCentral.Models.AppSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppSkuInfo
    {
        public AppSkuInfo(Azure.ResourceManager.IotCentral.Models.AppSku name) { }
        public Azure.ResourceManager.IotCentral.Models.AppSku Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.AppState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.AppState Created { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.AppState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.AppState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.AppState left, Azure.ResourceManager.IotCentral.Models.AppState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.AppState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.AppState left, Azure.ResourceManager.IotCentral.Models.AppState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppTemplate
    {
        internal AppTemplate() { }
        public string Description { get { throw null; } }
        public string Industry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.Models.AppTemplateLocations> Locations { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public float? Order { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class AppTemplateLocations
    {
        internal AppTemplateLocations() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class IotCentralAppPatch
    {
        public IotCentralAppPatch() { }
        public string ApplicationId { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.NetworkRuleSets NetworkRuleSets { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotCentral.IotCentralPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.AppSku? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.AppState? State { get { throw null; } }
        public string Subdomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Template { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotCentralPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotCentralPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotCentralPrivateLinkServiceConnectionState
    {
        public IotCentralPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.IotCentralPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAction : System.IEquatable<Azure.ResourceManager.IotCentral.Models.NetworkAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAction(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.NetworkAction Allow { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.NetworkAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.NetworkAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.NetworkAction left, Azure.ResourceManager.IotCentral.Models.NetworkAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.NetworkAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.NetworkAction left, Azure.ResourceManager.IotCentral.Models.NetworkAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSetIPRule
    {
        public NetworkRuleSetIPRule() { }
        public string FilterName { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class NetworkRuleSets
    {
        public NetworkRuleSets() { }
        public bool? ApplyToDevices { get { throw null; } set { } }
        public bool? ApplyToIoTCentral { get { throw null; } set { } }
        public Azure.ResourceManager.IotCentral.Models.NetworkAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotCentral.Models.NetworkRuleSetIPRule> IPRules { get { throw null; } }
    }
    public partial class OperationInputs
    {
        public OperationInputs(string name) { }
        public string Name { get { throw null; } }
        public string OperationInputsType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.IotCentral.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.ProvisioningState left, Azure.ResourceManager.IotCentral.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.ProvisioningState left, Azure.ResourceManager.IotCentral.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess left, Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess left, Azure.ResourceManager.IotCentral.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
