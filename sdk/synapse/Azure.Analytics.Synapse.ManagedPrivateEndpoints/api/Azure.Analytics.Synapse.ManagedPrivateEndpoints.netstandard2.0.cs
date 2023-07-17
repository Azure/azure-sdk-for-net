namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints
{
    public partial class ManagedPrivateEndpointsClient
    {
        protected ManagedPrivateEndpointsClient() { }
        public ManagedPrivateEndpointsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> Create(string managedVirtualNetworkName, string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint managedPrivateEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint>> CreateAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint managedPrivateEndpoint, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> Get(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint>> GetAsync(string managedVirtualNetworkName, string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> List(string managedVirtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint> ListAsync(string managedVirtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedPrivateEndpointsClientOptions : Azure.Core.ClientOptions
    {
        public ManagedPrivateEndpointsClientOptions(Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions.ServiceVersion version = Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions.ServiceVersion.V2020_12_01) { }
        public enum ServiceVersion
        {
            V2020_12_01 = 1,
        }
    }
}
namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models
{
    public static partial class AnalyticsSynapseManagedPrivateEndpointsModelFactory
    {
        public static Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpoint ManagedPrivateEndpoint(string id = null, string name = null, string type = null, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointProperties properties = null) { throw null; }
        public static Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointConnectionState ManagedPrivateEndpointConnectionState(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointProperties ManagedPrivateEndpointProperties(string name = null, string privateLinkResourceId = null, string groupId = null, string provisioningState = null, Azure.Analytics.Synapse.ManagedPrivateEndpoints.Models.ManagedPrivateEndpointConnectionState connectionState = null, bool? isReserved = default(bool?), System.Collections.Generic.IEnumerable<string> fqdns = null, bool? isCompliant = default(bool?)) { throw null; }
    }
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
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public bool? IsCompliant { get { throw null; } set { } }
        public bool? IsReserved { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
}
