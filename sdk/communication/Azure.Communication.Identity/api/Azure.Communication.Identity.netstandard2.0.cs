namespace Azure.Communication.Identity
{
    public partial class CommunicationIdentityClient
    {
        protected CommunicationIdentityClient() { }
        public CommunicationIdentityClient(string connectionString) { }
        public CommunicationIdentityClient(string connectionString, Azure.Communication.Identity.CommunicationIdentityClientOptions options) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions options = null) { }
        public CommunicationIdentityClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Identity.CommunicationIdentityClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.CommunicationUserIdentifier> CreateUser(string to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.CommunicationUserIdentifier> CreateUser(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(string to, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken> CreateUserAndToken(string to, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(string to, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.CommunicationUserIdentifierAndToken>> CreateUserAndTokenAsync(string to, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(string to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.CommunicationUserIdentifier>> CreateUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetToken(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Collections.Generic.IEnumerable<Azure.Communication.Identity.CommunicationTokenScope> scopes, System.TimeSpan tokenExpiresIn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Core.AccessToken> GetTokenForTeamsUser(Azure.Communication.Identity.GetTokenForTeamsUserOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Core.AccessToken>> GetTokenForTeamsUserAsync(Azure.Communication.Identity.GetTokenForTeamsUserOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Identity.Models.CommunicationUserDetail> GetUserDetail(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Identity.Models.CommunicationUserDetail>> GetUserDetailAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeTokens(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeTokensAsync(Azure.Communication.CommunicationUserIdentifier communicationUser, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationIdentityClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationIdentityClientOptions(Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion version = Azure.Communication.Identity.CommunicationIdentityClientOptions.ServiceVersion.V2025_03_02_PREVIEW) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2022_06_01 = 2,
            V2022_10_01 = 3,
            V2023_10_01 = 4,
            V2025_03_02_PREVIEW = 5,
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
        public System.DateTimeOffset? LastTokenIssuedAt { get { throw null; } }
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
    public partial class CommunicationIdentity
    {
        internal CommunicationIdentity() { }
        public string CustomId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastTokenIssuedAt { get { throw null; } }
    }
    public static partial class CommunicationIdentityModelFactory
    {
        public static Azure.Communication.Identity.Models.CommunicationIdentity CommunicationIdentity(string customId = null, System.DateTimeOffset? lastTokenIssuedAt = default(System.DateTimeOffset?), string id = null) { throw null; }
        public static Azure.Communication.Identity.CommunicationUserIdentifierAndToken CommunicationUserIdentifierAndToken(Azure.Communication.CommunicationUserIdentifier user, Azure.Core.AccessToken accessToken) { throw null; }
        public static Azure.Communication.Identity.CommunicationUserIdentifierAndToken CommunicationUserIdentifierAndToken(Azure.Communication.CommunicationUserIdentifier user, Azure.Core.AccessToken accessToken, System.DateTimeOffset? lastTokenIssuedAt) { throw null; }
        public static Azure.Communication.Identity.Models.EntraAssignment EntraAssignment(string objectId = null, string tenantId = null, Azure.Communication.Identity.Models.EntraPrincipalType principalType = default(Azure.Communication.Identity.Models.EntraPrincipalType), System.Collections.Generic.IEnumerable<string> clientIds = null) { throw null; }
        public static Azure.Communication.Identity.Models.EntraAssignmentsResponse EntraAssignmentsResponse(System.Collections.Generic.IEnumerable<Azure.Communication.Identity.Models.EntraAssignment> value = null, string nextLink = null) { throw null; }
        public static Azure.Communication.Identity.Models.TeamsExtensionAssignmentResponse TeamsExtensionAssignmentResponse(string objectId = null, string tenantId = null, Azure.Communication.Identity.Models.TeamsExtensionPrincipalType principalType = default(Azure.Communication.Identity.Models.TeamsExtensionPrincipalType), System.Collections.Generic.IEnumerable<string> clientIds = null) { throw null; }
    }
    public partial class CommunicationUserDetail
    {
        internal CommunicationUserDetail() { }
        public string CustomId { get { throw null; } }
        public System.DateTimeOffset? LastTokenIssuedAt { get { throw null; } }
        public Azure.Communication.CommunicationUserIdentifier User { get { throw null; } }
    }
    public partial class EntraAssignment
    {
        internal EntraAssignment() { }
        public System.Collections.Generic.IReadOnlyList<string> ClientIds { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public Azure.Communication.Identity.Models.EntraPrincipalType PrincipalType { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class EntraAssignmentCreateOrUpdateRequest
    {
        public EntraAssignmentCreateOrUpdateRequest(string tenantId, Azure.Communication.Identity.Models.EntraPrincipalType principalType, System.Collections.Generic.IEnumerable<string> clientIds) { }
        public System.Collections.Generic.IList<string> ClientIds { get { throw null; } }
        public Azure.Communication.Identity.Models.EntraPrincipalType PrincipalType { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class EntraAssignmentsResponse
    {
        internal EntraAssignmentsResponse() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Identity.Models.EntraAssignment> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntraPrincipalType : System.IEquatable<Azure.Communication.Identity.Models.EntraPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntraPrincipalType(string value) { throw null; }
        public static Azure.Communication.Identity.Models.EntraPrincipalType Group { get { throw null; } }
        public static Azure.Communication.Identity.Models.EntraPrincipalType Tenant { get { throw null; } }
        public static Azure.Communication.Identity.Models.EntraPrincipalType User { get { throw null; } }
        public bool Equals(Azure.Communication.Identity.Models.EntraPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Identity.Models.EntraPrincipalType left, Azure.Communication.Identity.Models.EntraPrincipalType right) { throw null; }
        public static implicit operator Azure.Communication.Identity.Models.EntraPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Identity.Models.EntraPrincipalType left, Azure.Communication.Identity.Models.EntraPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamsExtensionAssignmentResponse
    {
        internal TeamsExtensionAssignmentResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> ClientIds { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public Azure.Communication.Identity.Models.TeamsExtensionPrincipalType PrincipalType { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TeamsExtensionPrincipalType : System.IEquatable<Azure.Communication.Identity.Models.TeamsExtensionPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TeamsExtensionPrincipalType(string value) { throw null; }
        public static Azure.Communication.Identity.Models.TeamsExtensionPrincipalType ResourceAccount { get { throw null; } }
        public static Azure.Communication.Identity.Models.TeamsExtensionPrincipalType User { get { throw null; } }
        public bool Equals(Azure.Communication.Identity.Models.TeamsExtensionPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Identity.Models.TeamsExtensionPrincipalType left, Azure.Communication.Identity.Models.TeamsExtensionPrincipalType right) { throw null; }
        public static implicit operator Azure.Communication.Identity.Models.TeamsExtensionPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Identity.Models.TeamsExtensionPrincipalType left, Azure.Communication.Identity.Models.TeamsExtensionPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
