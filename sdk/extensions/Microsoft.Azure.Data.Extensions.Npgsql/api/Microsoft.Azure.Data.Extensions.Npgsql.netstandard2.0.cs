namespace Microsoft.Azure.Data.Extensions.Common
{
    public partial class TokenCredentialBaseAuthenticationProvider
    {
        public TokenCredentialBaseAuthenticationProvider(Azure.Core.TokenCredential credential) { }
        public string GetAuthenticationToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<string> GetAuthenticationTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Microsoft.Azure.Data.Extensions.Npgsql
{
    public partial class TokenCredentialNpgsqlPasswordProvider : Microsoft.Azure.Data.Extensions.Common.TokenCredentialBaseAuthenticationProvider
    {
        public TokenCredentialNpgsqlPasswordProvider(Azure.Core.TokenCredential credential) : base (default(Azure.Core.TokenCredential)) { }
        public System.Func<Npgsql.NpgsqlConnectionStringBuilder, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<string>> PasswordProvider { get { throw null; } }
        public string ProvidePasswordCallback(string host, int port, string database, string username) { throw null; }
    }
}
namespace Npgsql
{
    public static partial class NpgsqlDataSourceBuilderExtensions
    {
        public static Npgsql.NpgsqlDataSourceBuilder UseAzureADAuthentication(this Npgsql.NpgsqlDataSourceBuilder builder, Azure.Core.TokenCredential credential) { throw null; }
    }
}
