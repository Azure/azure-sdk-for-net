namespace Azure.Communication.Administration
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Administration.CommunicationIdentityClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUser> CreateUser(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUser>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUser communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUser communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Administration.Models.CommunicationUserToken> IssueToken(Azure.Communication.CommunicationUser communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Administration.Models.CommunicationUserToken>> IssueTokenAsync(Azure.Communication.CommunicationUser communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Administration.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUser communicationUser, System.DateTimeOffset? issuedBefore = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUser communicationUser, System.DateTimeOffset? issuedBefore = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion LatestVersion = Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion.V1;
        public CommunicationIdentityClientOptions(Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Administration.CommunicationIdentityClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationTokenScope : System.IEquatable<Azure.Communication.Administration.CommunicationTokenScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationTokenScope(string value) { throw null; }
        public static Azure.Communication.Administration.CommunicationTokenScope Chat { get { throw null; } }
        public static Azure.Communication.Administration.CommunicationTokenScope Pstn { get { throw null; } }
        public static Azure.Communication.Administration.CommunicationTokenScope VoIP { get { throw null; } }
        public bool Equals(Azure.Communication.Administration.CommunicationTokenScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Administration.CommunicationTokenScope left, Azure.Communication.Administration.CommunicationTokenScope right) { throw null; }
        public static implicit operator Azure.Communication.Administration.CommunicationTokenScope (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Administration.CommunicationTokenScope left, Azure.Communication.Administration.CommunicationTokenScope right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Communication.Administration.Models
{
    public partial class CommunicationUserToken
    {
        internal CommunicationUserToken() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
        public Azure.Communication.CommunicationUser User { get { throw null; } }
    }
}
