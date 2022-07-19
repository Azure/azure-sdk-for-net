namespace Azure.Communication.NetworkTraversal
{
    public partial class CommunicationIceServer
    {
        public CommunicationIceServer(System.Collections.Generic.IEnumerable<string> urls, string username, string credential, Azure.Communication.NetworkTraversal.RouteType routeType) { }
        public string Credential { get { throw null; } set { } }
        public Azure.Communication.NetworkTraversal.RouteType RouteType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Urls { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class CommunicationRelayClient
    {
        protected CommunicationRelayClient() { }
        public CommunicationRelayClient(string connectionString) { }
        public CommunicationRelayClient(string connectionString, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration> GetRelayConfiguration(Azure.Communication.CommunicationUserIdentifier communicationUser = null, Azure.Communication.NetworkTraversal.RouteType? routeType = default(Azure.Communication.NetworkTraversal.RouteType?), int? ttl = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration>> GetRelayConfigurationAsync(Azure.Communication.CommunicationUserIdentifier communicationUser = null, Azure.Communication.NetworkTraversal.RouteType? routeType = default(Azure.Communication.NetworkTraversal.RouteType?), int? ttl = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationRelayClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationRelayClientOptions(Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion version = Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion.V2022_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_03_01_Preview = 1,
        }
    }
    public partial class CommunicationRelayConfiguration
    {
        public CommunicationRelayConfiguration(System.DateTimeOffset expiresOn, System.Collections.Generic.IEnumerable<Azure.Communication.NetworkTraversal.CommunicationIceServer> iceServers) { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.NetworkTraversal.CommunicationIceServer> IceServers { get { throw null; } }
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
