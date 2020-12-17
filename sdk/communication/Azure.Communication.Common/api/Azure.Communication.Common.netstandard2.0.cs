namespace Azure.Communication
{
    public partial class CallingApplicationIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public CallingApplicationIdentifier(string id) { }
        public string Id { get { throw null; } }
    }
    public abstract partial class CommunicationIdentifier
    {
        protected CommunicationIdentifier() { }
    }
    public partial class CommunicationUserIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public CommunicationUserIdentifier(string id) { }
        public string Id { get { throw null; } }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{Value}")]
    public partial class PhoneNumberIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public PhoneNumberIdentifier(string phoneNumber) { }
        public string Value { get { throw null; } }
    }
    public partial class UnknownIdentifier : Azure.Communication.CommunicationIdentifier
    {
        public UnknownIdentifier(string id) { }
        public string Id { get { throw null; } }
    }
}
namespace Azure.Communication.Identity
{
    public sealed partial class CommunicationTokenCredential : System.IDisposable
    {
        public CommunicationTokenCredential(bool refreshProactively, System.Func<System.Threading.CancellationToken, string> tokenRefresher, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<string>>? asyncTokenRefresher = null, string? initialToken = null) { }
        public CommunicationTokenCredential(string userToken) { }
        public void Dispose() { }
        public Azure.Core.AccessToken GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
