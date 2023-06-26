namespace Azure.ResourceManager.Hardwaresecuritymodules
{
    public partial class DedicatedHsmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>, System.Collections.IEnumerable
    {
        protected DedicatedHsmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHsmData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DedicatedHsmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkProfile ManagementNetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName? SkuName { get { throw null; } set { } }
        public string StampId { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class DedicatedHsmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHsmResource() { }
        public virtual Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hardwaresecuritymodules.Models.DedicatedHsmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hardwaresecuritymodules.Models.DedicatedHsmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HardwaresecuritymodulesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> CreateCloudHsmClusterPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, string peConnectionName, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection>> CreateCloudHsmClusterPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, string peConnectionName, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> CreateOrUpdateCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster>> CreateOrUpdateCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteCloudHsmClusterPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCloudHsmClusterPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> GetCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster>> GetCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> GetCloudHsmClusterPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection>> GetCloudHsmClusterPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateLinkResource> GetCloudHsmClusterPrivateLinkResourcesByCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateLinkResource> GetCloudHsmClusterPrivateLinkResourcesByCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> GetCloudHsmClustersByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> GetCloudHsmClustersByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> GetCloudHsmClustersBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> GetCloudHsmClustersBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> GetDedicatedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource>> GetDedicatedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource GetDedicatedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmCollection GetDedicatedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> GetDedicatedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmResource> GetDedicatedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> GetPrivateEndpointConnectionsByCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> GetPrivateEndpointConnectionsByCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster> UpdateCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterPatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster>> UpdateCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterPatchContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hardwaresecuritymodules.Models
{
    public static partial class ArmHardwaresecuritymodulesModelFactory
    {
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmCluster CloudHsmCluster(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState?), string autoGeneratedDomainNameLabelScope = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSecurityDomainProperties securityDomain = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmProperties> hsms = null, string publicNetworkAccess = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSku sku = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.DedicatedHsmData DedicatedHsmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkProfile managementNetworkProfile = null, string stampId = null, string statusMessage = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType? provisioningState = default(Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType?), Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName? skuName = default(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDependency EndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDetail EndpointDetail(string ipAddress = null, int? port = default(int?), string protocol = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection HardwaresecuritymodulesPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateLinkResource HardwaresecuritymodulesPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkInterface NetworkInterface(string id = null, string privateIPAddress = null) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDependency> endpoints = null) { throw null; }
    }
    public partial class CloudHsmCluster : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CloudHsmCluster(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmProperties> Hsms { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSecurityDomainProperties SecurityDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSku Sku { get { throw null; } set { } }
    }
    public partial class CloudHsmClusterPatchContent
    {
        public CloudHsmClusterPatchContent() { }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CloudHsmClusterSecurityDomainProperties
    {
        public CloudHsmClusterSecurityDomainProperties() { }
        public string ActivationStatus { get { throw null; } set { } }
        public int? FipsState { get { throw null; } set { } }
    }
    public partial class CloudHsmClusterSku
    {
        public CloudHsmClusterSku(Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuName name, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily? family = default(Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily?)) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterSkuFamily : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily B { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily left, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily left, Azure.ResourceManager.Hardwaresecuritymodules.Models.CloudHsmClusterSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CloudHsmClusterSkuName
    {
        StandardB1 = 0,
        StandardB10 = 1,
    }
    public partial class CloudHsmProperties
    {
        public CloudHsmProperties() { }
        public string Fqdn { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        public string StateMessage { get { throw null; } set { } }
    }
    public partial class DedicatedHsmPatch
    {
        public DedicatedHsmPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public string Description { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public int? Port { get { throw null; } }
        public string Protocol { get { throw null; } }
    }
    public partial class HardwaresecuritymodulesPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData
    {
        public HardwaresecuritymodulesPrivateEndpointConnection() { }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState InternalError { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HardwaresecuritymodulesPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public HardwaresecuritymodulesPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class HardwaresecuritymodulesPrivateLinkServiceConnectionState
    {
        public HardwaresecuritymodulesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwaresecuritymodulesSkuName : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwaresecuritymodulesSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK1CPS250 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK1CPS2500 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK1CPS60 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK2CPS250 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK2CPS2500 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName PayShield10KLMK2CPS60 { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName SafeNetLunaNetworkHSMA790 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName left, Azure.ResourceManager.Hardwaresecuritymodules.Models.HardwaresecuritymodulesSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyType : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Allocating { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType CheckingQuota { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Connecting { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Failed { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType left, Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType left, Azure.ResourceManager.Hardwaresecuritymodules.Models.JsonWebKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterface
    {
        public NetworkInterface() { }
        public string Id { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hardwaresecuritymodules.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hardwaresecuritymodules.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState left, Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState left, Azure.ResourceManager.Hardwaresecuritymodules.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
