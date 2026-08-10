namespace Microsoft.Azure.PostgreSQL.Auth
{
    public static partial class EntraIdExtension
    {
        public static Npgsql.NpgsqlDataSourceBuilder UseEntraAuthentication(this Npgsql.NpgsqlDataSourceBuilder dataSourceBuilder, Azure.Core.TokenCredential credential, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Npgsql.NpgsqlDataSourceBuilder> UseEntraAuthenticationAsync(this Npgsql.NpgsqlDataSourceBuilder dataSourceBuilder, Azure.Core.TokenCredential credential, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
