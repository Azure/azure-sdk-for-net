namespace Microsoft.Azure.Data.Extensions.Common
{
    public partial class TokenCredentialBaseAuthenticationProvider
    {
        public TokenCredentialBaseAuthenticationProvider(Azure.Core.TokenCredential credential) { }
        public string GetAuthenticationToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<string> GetAuthenticationTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
