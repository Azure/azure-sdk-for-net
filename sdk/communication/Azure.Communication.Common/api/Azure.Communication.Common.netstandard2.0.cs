namespace Azure.Communication
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationCloudEnvironment : System.IEquatable<Azure.Communication.CommunicationCloudEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationCloudEnvironment(string value) { throw null; }
        public static Azure.Communication.CommunicationCloudEnvironment Dod { get { throw null; } }
        public static Azure.Communication.CommunicationCloudEnvironment Gcch { get { throw null; } }
        public static Azure.Communication.CommunicationCloudEnvironment Public { get { throw null; } }
        public bool Equals(Azure.Communication.CommunicationCloudEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CommunicationCloudEnvironment left, Azure.Communication.CommunicationCloudEnvironment right) { throw null; }
        public static implicit operator Azure.Communication.CommunicationCloudEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.Communication.CommunicationCloudEnvironment left, Azure.Communication.CommunicationCloudEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class CommunicationIdentifier : System.IEquatable<Azure.Communication.CommunicationIdentifier>
    {
        protected CommunicationIdentifier() { }
        public virtual string RawId { get { throw null; } }
        public abstract bool Equals(Azure.Communication.CommunicationIdentifier other);
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public static Azure.Communication.CommunicationIdentifier FromRawId(string rawId) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.CommunicationIdentifier left, Azure.Communication.CommunicationIdentifier right) { throw null; }
        public static bool operator !=(Azure.Communication.CommunicationIdentifier left, Azure.Communication.CommunicationIdentifier right) { throw null; }
    }
    public sealed partial class CommunicationTokenCredential : System.IDisposable
    {
        public CommunicationTokenCredential(Azure.Communication.CommunicationTokenRefreshOptions options) { }
        public CommunicationTokenCredential(Azure.Communication.EntraCommunicationTokenCredentialOptions options) { }
        public CommunicationTokenCredential(string token) { }
        public void Dispose() { }
        public Azure.Core.AccessToken GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationTokenRefreshOptions
    {
        public CommunicationTokenRefreshOptions(bool refreshProactively, System.Func<System.Threading.CancellationToken, string> tokenRefresher) { }
        public System.Func<System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<string>> AsyncTokenRefresher { get { throw null; } set { } }
        public string InitialToken { get { throw null; } set { } }
    }
    public partial class CommunicationUserIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public CommunicationUserIdentifier(string id) { }
        public string Id { get { throw null; } }
        public override string RawId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntraCommunicationTokenCredentialOptions
    {
        public EntraCommunicationTokenCredentialOptions(string resourceEndpoint, Azure.Core.TokenCredential entraTokenCredential) { }
        public string ResourceEndpoint { get { throw null; } }
        public string[] Scopes { get { throw null; } set { } }
        public Azure.Core.TokenCredential TokenCredential { get { throw null; } }
    }
    public partial class MicrosoftTeamsAppIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public MicrosoftTeamsAppIdentifier(string appId, Azure.Communication.CommunicationCloudEnvironment? cloud = default(Azure.Communication.CommunicationCloudEnvironment?)) { }
        public string AppId { get { throw null; } }
        public Azure.Communication.CommunicationCloudEnvironment Cloud { get { throw null; } }
        public override string RawId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MicrosoftTeamsUserIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public MicrosoftTeamsUserIdentifier(string userId, bool isAnonymous = false, Azure.Communication.CommunicationCloudEnvironment? cloud = default(Azure.Communication.CommunicationCloudEnvironment?), string rawId = null) { }
        public Azure.Communication.CommunicationCloudEnvironment Cloud { get { throw null; } }
        public bool IsAnonymous { get { throw null; } }
        public override string RawId { get { throw null; } }
        public string UserId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PhoneNumberIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public PhoneNumberIdentifier(string phoneNumber, string rawId = null) { }
        public string AssertedId { get { throw null; } }
        public bool IsAnonymous { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public override string RawId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamsExtensionUserIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public TeamsExtensionUserIdentifier(string userId, string tenantId, string resourceId, Azure.Communication.CommunicationCloudEnvironment? cloud = default(Azure.Communication.CommunicationCloudEnvironment?), string rawId = null) { }
        public Azure.Communication.CommunicationCloudEnvironment Cloud { get { throw null; } }
        public override string RawId { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string UserId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnknownIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public UnknownIdentifier(string id) { }
        public string Id { get { throw null; } }
        public override string RawId { get { throw null; } }
        public override bool Equals(Azure.Communication.CommunicationIdentifier other) { throw null; }
        public override string ToString() { throw null; }
    }
}
