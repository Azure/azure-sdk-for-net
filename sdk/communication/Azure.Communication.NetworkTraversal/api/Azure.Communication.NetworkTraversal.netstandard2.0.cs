namespace Azure.Communication.NetworkTraversal
{
    public partial class CommunicationRelayClient
    {
        protected CommunicationRelayClient() { }
        public CommunicationRelayClient(string connectionString) { }
        public CommunicationRelayClient(string connectionString, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public CommunicationRelayClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration> GetRelayConfiguration(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration>> GetRelayConfigurationAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationRelayClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationRelayClientOptions(Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion version = Azure.Communication.NetworkTraversal.CommunicationRelayClientOptions.ServiceVersion.V2021_02_22_preview1) { }
        public enum ServiceVersion
        {
            V2021_02_22_preview1 = 1,
        }
    }
    public partial class CommunicationRelayConfiguration
    {
        internal CommunicationRelayConfiguration() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.NetworkTraversal.CommunicationTurnServer> TurnServers { get { throw null; } }
    }
    public partial class CommunicationTurnServer
    {
        internal CommunicationTurnServer() { }
        public string Credential { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Urls { get { throw null; } }
        public string Username { get { throw null; } }
    }
    public static partial class NetworkTraversalModelFactory
    {
        public static Azure.Communication.NetworkTraversal.CommunicationRelayConfiguration CommunicationRelayConfiguration(System.DateTimeOffset expiresOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Communication.NetworkTraversal.CommunicationTurnServer> turnServers = null) { throw null; }
        public static Azure.Communication.NetworkTraversal.CommunicationTurnServer CommunicationTurnServer(System.Collections.Generic.IEnumerable<string> urls = null, string username = null, string credential = null) { throw null; }
    }
}
