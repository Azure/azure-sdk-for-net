namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints
{
    public partial class ManagedPrivateEndpointsClient
    {
        protected ManagedPrivateEndpointsClient() { }
        public ManagedPrivateEndpointsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> Create(string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint managedPrivateEndpoint, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint>> CreateAsync(string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint managedPrivateEndpoint, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> Get(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint>> GetAsync(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> List(string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> ListAsync(string managedVirtualNetworkName = "default", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedPrivateEndpointsClientOptions : Azure.Core.ClientOptions
    {
        public ManagedPrivateEndpointsClientOptions(Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions.ServiceVersion version = Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions.ServiceVersion.V2019_06_01_preview) { }
        public enum ServiceVersion
        {
            V2019_06_01_preview = 1,
        }
    }
}
namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models
{
    public partial class ManagedPrivateEndpoint
    {
        public ManagedPrivateEndpoint() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointProperties Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointConnectionState
    {
        public ManagedPrivateEndpointConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointProperties
    {
        public ManagedPrivateEndpointProperties() { }
        public Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
}
