namespace Azure.Analytics.Synapse.ManagedVirtualNetwork
{
    public partial class ManagedPrivateEndpointsClient
    {
        protected ManagedPrivateEndpointsClient() { }
        public ManagedPrivateEndpointsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ManagedPrivateEndpointsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.ManagedVirtualNetwork.ManagedPrivateEndpointsClientOptions options) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint> Create(string managedVirtualNetworkName, string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint managedPrivateEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint>> CreateAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint managedPrivateEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint> Get(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint>> GetAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint> List(string managedVirtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint> ListAsync(string managedVirtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedPrivateEndpointsClientOptions : Azure.Core.ClientOptions
    {
        public ManagedPrivateEndpointsClientOptions(Azure.Analytics.Synapse.ManagedVirtualNetwork.ManagedPrivateEndpointsClientOptions.ServiceVersion serviceVersion = Azure.Analytics.Synapse.ManagedVirtualNetwork.ManagedPrivateEndpointsClientOptions.ServiceVersion.V2019_06_01_preview) { }
        public enum ServiceVersion
        {
            V2019_06_01_preview = 1,
        }
    }
}
namespace Azure.Analytics.Synapse.ManagedVirtualNetwork.Models
{
    public partial class ManagedPrivateEndpoint
    {
        public ManagedPrivateEndpoint() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpointProperties Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointConnectionState
    {
        public ManagedPrivateEndpointConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointListResponse
    {
        internal ManagedPrivateEndpointListResponse() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpoint> Value { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointProperties
    {
        public ManagedPrivateEndpointProperties() { }
        public Azure.Analytics.Synapse.ManagedVirtualNetwork.Models.ManagedPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
}
