namespace Azure.Analytics.Synapse.ManagedPrivateEndpoints
{
    public partial class ManagedPrivateEndpointsClient
    {
        protected ManagedPrivateEndpointsClient() { }
        public ManagedPrivateEndpointsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.ManagedPrivateEndpoints.ManagedPrivateEndpointsClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(string managedPrivateEndpointName, Azure.Core.RequestContent requestBody, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string managedPrivateEndpointName, Azure.Core.RequestContent requestBody, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Delete(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response Get(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string managedPrivateEndpointName, string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response List(string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListAsync(string managedVirtualNetworkName = "default", Azure.RequestOptions requestOptions = null) { throw null; }
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
