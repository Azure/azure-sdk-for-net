namespace Azure.Communication
{
    public partial class CallingApplication : Azure.Communication.CommunicationIdentifier
    {
        public CallingApplication(string id) { }
        public string Id { get { throw null; } }
    }
    public abstract partial class CommunicationIdentifier
    {
        protected CommunicationIdentifier() { }
    }
    public partial class CommunicationUser : Azure.Communication.CommunicationIdentifier
    {
        public CommunicationUser(string id) { }
        public string Id { get { throw null; } }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{Value}")]
    public partial class PhoneNumber : Azure.Communication.CommunicationIdentifier
    {
        public PhoneNumber(string phoneNumber) { }
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
<<<<<<< HEAD
        public CommunicationTokenCredential(Azure.Communication.Identity.CommunicationTokenRefreshOptions tokenRefreshOptions) { }
=======
        public CommunicationTokenCredential(bool refreshProactively, System.Func<System.Threading.CancellationToken, string> tokenRefresher, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<string>>? asyncTokenRefresher = null, string? initialToken = null) { }
>>>>>>> 9e93e136d1dd5ee5cb24adb1ded988a45acf79c3
        public CommunicationTokenCredential(string userToken) { }
        public void Dispose() { }
        public Azure.Core.AccessToken GetToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationTokenRefreshOptions
    {
        public CommunicationTokenRefreshOptions(bool refreshProactively, System.Func<System.Threading.CancellationToken, string> tokenRefresher, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<string>>? asyncTokenRefresher, string? token = null) { }
    }
}
