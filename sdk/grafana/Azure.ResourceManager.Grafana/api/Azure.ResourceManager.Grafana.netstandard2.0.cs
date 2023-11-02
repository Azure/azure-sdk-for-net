namespace Azure.ResourceManager.Grafana
{
    public static partial class GrafanaExtensions
    {
        public static Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource GetGrafanaPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource GetGrafanaPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafana(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetManagedGrafanaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaResource GetManagedGrafanaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaCollection GetManagedGrafanas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrafanaPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected GrafanaPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GrafanaPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public GrafanaPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GrafanaPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrafanaPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrafanaPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrafanaPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrafanaPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected GrafanaPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GrafanaPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public GrafanaPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ManagedGrafanaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>, System.Collections.IEnumerable
    {
        protected ManagedGrafanaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedGrafanaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Grafana.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Grafana.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.ManagedGrafanaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.ManagedGrafanaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedGrafanaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedGrafanaData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class ManagedGrafanaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedGrafanaResource() { }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetGrafanaPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetGrafanaPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionCollection GetGrafanaPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetGrafanaPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetGrafanaPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceCollection GetGrafanaPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Update(Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> UpdateAsync(Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Grafana.Mocking
{
    public partial class MockableGrafanaArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaArmClient() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource GetGrafanaPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource GetGrafanaPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaResource GetManagedGrafanaResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableGrafanaResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafana(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetManagedGrafanaAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaCollection GetManagedGrafanas() { throw null; }
    }
    public partial class MockableGrafanaSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Grafana.Models
{
    public static partial class ArmGrafanaModelFactory
    {
        public static Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData GrafanaPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState connectionState = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData GrafanaPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState?), string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaData ManagedGrafanaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties ManagedGrafanaProperties(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState?), string grafanaVersion = null, string endpoint = null, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess?), Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy?), Azure.ResourceManager.Grafana.Models.GrafanaApiKey? apiKey = default(Azure.ResourceManager.Grafana.Models.GrafanaApiKey?), Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? deterministicOutboundIP = default(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP?), System.Collections.Generic.IEnumerable<string> outboundIPs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> monitorWorkspaceIntegrations = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeterministicOutboundIP : System.IEquatable<Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeterministicOutboundIP(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP left, Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP left, Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaApiKey : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaApiKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaApiKey(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaApiKey Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaApiKey Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaApiKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaApiKey left, Azure.ResourceManager.Grafana.Models.GrafanaApiKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaApiKey (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaApiKey left, Azure.ResourceManager.Grafana.Models.GrafanaApiKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GrafanaPrivateLinkServiceConnectionState
    {
        public GrafanaPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaProvisioningState : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess left, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess left, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaZoneRedundancy : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy left, Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy left, Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedGrafanaPatch
    {
        public ManagedGrafanaPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedGrafanaPatchProperties
    {
        public ManagedGrafanaPatchProperties() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaApiKey? ApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> MonitorWorkspaceIntegrations { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class ManagedGrafanaProperties
    {
        public ManagedGrafanaProperties() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaApiKey? ApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public string GrafanaVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> MonitorWorkspaceIntegrations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class MonitorWorkspaceIntegration
    {
        public MonitorWorkspaceIntegration() { }
        public Azure.Core.ResourceIdentifier MonitorWorkspaceResourceId { get { throw null; } set { } }
    }
}
