using Azure.Core;
using Microsoft.Azure.Data.Extensions.Common;
using Npgsql;

namespace Microsoft.Azure.Data.Extensions.Npgsql
{
    /// <summary>
    /// Provides implementations for Npgsql delegates to get passwords that can be used with Azure Database for Postgresql
    /// Passwords provided are access tokens issued by Azure AD.
    /// </summary>
    public partial class TokenCredentialNpgsqlPasswordProvider : TokenCredentialBaseAuthenticationProvider
    {
        /// <summary>
        /// Token credential provided by the caller that will be used to retrieve AAD access tokens.
        /// </summary>
        /// <param name="credential">TokenCredential to use to retrieve AAD access tokens</param>
        public TokenCredentialNpgsqlPasswordProvider(TokenCredential credential) : base(credential)
        { }

        /// <summary>
        /// Method that implements NpgsqlDbContextOptionsBuilder.ProvidePasswordCallback delegate signature.
        /// It can used in Entity Framework DbContext configuration
        /// </summary>
        /// <param name="host">Just part of the delegate signature. It is ignored</param>
        /// <param name="port">Just part of the delegate signature. It is ignored</param>
        /// <param name="database">Just part of the delegate signature. It is ignored</param>
        /// <param name="username">Just part of the delegate signature. It is ignored</param>
        /// <returns></returns>
        public partial string ProvidePasswordCallback(string host, int port, string database, string username) { }

        /// <summary>
        /// Method that implements NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider delegate signature.
        /// <see href="https://www.npgsql.org/doc/security.html?tabs=tabid-1#auth-token-rotation-and-dynamic-password"/>
        /// </summary>
        /// <param name="settings">ConnectionString settings</param>
        /// <param name="cancellationToken">token to propagate cancellation</param>
        /// <returns>AAD issued access token that can be used as password for Azure Database for Postgresql</returns>
        private partial ValueTask<string> PeriodicPasswordProvider(NpgsqlConnectionStringBuilder settings, CancellationToken cancellationToken = default) { }

        /// <summary>
        /// Property that holds an implementation of NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider delegate signature.
        /// </summary>
        public partial Func<NpgsqlConnectionStringBuilder, CancellationToken, ValueTask<string>> PasswordProvider { get; }
    }
}

namespace Npgsql
{
    /// <summary>
    /// NpgsqlDataSourceBuilder extensions that simplify the configuration to use AAD authentication when connecting to Azure Database for Postgresql
    /// </summary>
    public static partial class NpgsqlDataSourceBuilderExtensions
    {
        /// <summary>
        /// Configures NpgsqlDataSourceBuilder to use AAD authentication to connect to Azure Database for Postgresql using the provided TokenCredential
        /// </summary>
        /// <param name="builder">NpgsqlDataSourceBuilder to be configured with AAD authentication</param>
        /// <param name="credential">TokenCredential that will be used to retrieve AAD access tokens</param>
        /// <returns>NpgsqlDataSourceBuilder configured with AAD authentication</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> or <paramref name="credential"/> are null</exception>
        public static partial NpgsqlDataSourceBuilder UseAzureADAuthentication(this NpgsqlDataSourceBuilder builder, TokenCredential credential) { }
    }
}