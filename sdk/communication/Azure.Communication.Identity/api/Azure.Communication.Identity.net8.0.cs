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
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetTokenForTeamsUser(Azure.Communication.Identity.GetTokenForTeamsUserOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenForTeamsUserAsync(Azure.Communication.Identity.GetTokenForTeamsUserOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationIdentityClientOptions(Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2022_06_01 = 2,
            V2022_10_01 = 3,
            V2023_10_01 = 4,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationTokenScope : System.IEquatable<Azure.Communication.Identity.CommunicationTokenScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationTokenScope(string value) { throw null; }
        public static Azure.Communication.Identity.CommunicationTokenScope Chat { get { throw null; } }
        public static Azure.Communication.Identity.CommunicationTokenScope ChatJoin { get { throw null; } }
        public static Azure.Communication.Identity.CommunicationTokenScope ChatJoinLimited { get { throw null; } }
        public static Azure.Communication.Identity.CommunicationTokenScope VoIP { get { throw null; } }
        public static Azure.Communication.Identity.CommunicationTokenScope VoIPJoin { get { throw null; } }
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
    public partial class CommunicationUserIdentifierAndToken
    {
        internal CommunicationUserIdentifierAndToken() { }
        public Azure.Core.AccessToken AccessToken { get { throw null; } }
        public Azure.Communication.CommunicationUserIdentifier User { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Deconstruct(out Azure.Communication.CommunicationUserIdentifier user, out Azure.Core.AccessToken accessToken) { throw null; }
    }
    public partial class GetTokenForTeamsUserOptions
    {
        public GetTokenForTeamsUserOptions(string teamsUserAadToken, string clientId, string userObjectId) { }
        public string ClientId { get { throw null; } }
        public string TeamsUserAadToken { get { throw null; } }
        public string UserObjectId { get { throw null; } }
    }
}
namespace Azure.Communication.Identity.Models
{
    public static partial class CommunicationIdentityModelFactory
    {
        public static Azure.Communication.Identity.CommunicationUserIdentifierAndToken CommunicationUserIdentifierAndToken(Azure.Communication.CommunicationUserIdentifier user, Azure.Core.AccessToken accessToken) { throw null; }
    }
}
