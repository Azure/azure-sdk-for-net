namespace Azure.Communication.Identity
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Identity.CommunicationIdentityClientOptions? options = null) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions? options = null) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUserIdentifier> CreateUser(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<(Azure.Communication.CommunicationUserIdentifier user, Azure.Communication.Identity.CommunicationUserToken token)> CreateUserWithToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<(Azure.Communication.CommunicationUserIdentifier user, Azure.Communication.Identity.CommunicationUserToken token)>> CreateUserWithTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserToken> IssueToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserToken>> IssueTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationIdentityClientOptions(Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
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
    public partial class CommunicationUserToken
    {
        internal CommunicationUserToken() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Token { get { throw null; } }
    }
}
