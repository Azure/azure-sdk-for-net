namespace Azure.Communication.NetworkTraversal
{
    public partial class CommunicationIceServer
    {
        internal CommunicationIceServer() { }
        public string Credential { get { throw null; } }
        public Azure.Communication.NetworkTraversal.RouteType RouteType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Urls { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public partial class CommunicationRelayClient
    {
        protected CommunicationRelayClient() { }
        public CommunicationRelayClient(string connectionString) { }
        public CommunicationRelayClient(string connectionString, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration> GetRelayConfiguration(Azure.Communication.NetworkTraversal.Models.GetRelayConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration> GetRelayConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration>> GetRelayConfigurationAsync(Azure.Communication.NetworkTraversal.Models.GetRelayConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration>> GetRelayConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationRelayClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationRelayClientOptions(Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion version = Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion.V2021_10_08_preview) { }
        public enum ServiceVersion
        {
            V2021_10_08_preview = 1,
        }
    }
    public partial class CommunicationRelayConfiguration
    {
        internal CommunicationRelayConfiguration() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.NetworkTraversal.CommunicationIceServer> IceServers { get { throw null; } }
    }
    public static partial class NetworkTraversalModelFactory
    {
        public static Azure.Communication.NetworkTraversal.CommunicationIceServer CommunicationIceServer(System.Collections.Generic.IEnumerable<string> urls = null, string username = null, string credential = null, Azure.Communication.NetworkTraversal.RouteType routeType = default(Azure.Communication.NetworkTraversal.RouteType)) { throw null; }
        public static Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration CommunicationRelayConfiguration(System.DateTimeOffset expiresOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Communication.NetworkTraversal.CommunicationIceServer> iceServers = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteType : System.IEquatable<Azure.Communication.NetworkTraversal.RouteType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteType(string value) { throw null; }
        public static Azure.Communication.NetworkTraversal.RouteType Any { get { throw null; } }
        public static Azure.Communication.NetworkTraversal.RouteType Nearest { get { throw null; } }
        public bool Equals(Azure.Communication.NetworkTraversal.RouteType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.NetworkTraversal.RouteType left, Azure.Communication.NetworkTraversal.RouteType right) { throw null; }
        public static implicit operator Azure.Communication.NetworkTraversal.RouteType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.NetworkTraversal.RouteType left, Azure.Communication.NetworkTraversal.RouteType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Communication.NetworkTraversal.Models
{
    public partial class GetRelayConfigurationOptions
    {
        public GetRelayConfigurationOptions() { }
        public Azure.Communication.CommunicationUserIdentifier CommunicationUser { get { throw null; } set { } }
        public Azure.Communication.NetworkTraversal.RouteType? RouteType { get { throw null; } set { } }
    }
}
