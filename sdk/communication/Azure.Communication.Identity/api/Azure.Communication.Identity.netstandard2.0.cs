namespace Azure.Communication.Identity
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString) { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Identity.CommunicationIdentityClientOptions options) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions options = null) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUserIdentifier> CreateUser(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<(Azure.Communication.CommunicationUserIdentifier user, Azure.Core.AccessToken token)> CreateUserWithToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<(Azure.Communication.CommunicationUserIdentifier user, Azure.Core.AccessToken token)>> CreateUserWithTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.Models.CommunicationTurnCredentialsResponse> GetTurnCredentials(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.Models.CommunicationTurnCredentialsResponse>> GetTurnCredentialsAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationIdentityClientOptions(Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationTokenScope : System.IEquatable<Azure.Communication.Identity.CommunicationTokenScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationTokenScope(string value) { throw null; }
        public static Azure.Communication.Identity.CommunicationTokenScope Chat { get { throw null; } }
        public static Azure.Communication.Identity.CommunicationTokenScope VoIP { get { throw null; } }
        public bool Equals(Azure.Communication.Identity.CommunicationTokenScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Identity.CommunicationTokenScope left, Azure.Communication.Identity.CommunicationTokenScope right) { throw null; }
        public static implicit operator Azure.Communication.Identity.CommunicationTokenScope (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Identity.CommunicationTokenScope left, Azure.Communication.Identity.CommunicationTokenScope right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Communication.Identity.Models
{
    public partial class CommunicationTurnCredentialsResponse
    {
        internal CommunicationTurnCredentialsResponse() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Identity.Models.CommunicationTurnServer> TurnServers { get { throw null; } }
    }
    public partial class CommunicationTurnServer
    {
        internal CommunicationTurnServer() { }
        public string Credential { get { throw null; } }
        public string Urls { get { throw null; } }
        public string Username { get { throw null; } }
    }
}
