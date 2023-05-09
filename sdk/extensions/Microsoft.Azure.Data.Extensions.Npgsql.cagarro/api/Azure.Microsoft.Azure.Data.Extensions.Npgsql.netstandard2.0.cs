#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Containers, Azure.Core.Expressions, Azure.Data, Azure.DigitalTwins, Azure.Identity, Azure.IoT, Azure.Learn, Azure.Management, Azure.Media, Azure.Messaging, Azure.MixedReality, Azure.Monitor, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Microsoft.Extensions.Azure
namespace Npgsql
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Containers, Azure.Core.Expressions, Azure.Data, Azure.DigitalTwins, Azure.Identity, Azure.IoT, Azure.Learn, Azure.Management, Azure.Media, Azure.Messaging, Azure.MixedReality, Azure.Monitor, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Microsoft.Extensions.Azure
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
        public static NpgsqlDataSourceBuilder UseAzureADAuthentication(this NpgsqlDataSourceBuilder builder, TokenCredential credential) { throw null; }
    }
}

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Containers, Azure.Core.Expressions, Azure.Data, Azure.DigitalTwins, Azure.Identity, Azure.IoT, Azure.Learn, Azure.Management, Azure.Media, Azure.Messaging, Azure.MixedReality, Azure.Monitor, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Microsoft.Extensions.Azure
namespace Microsoft.Azure.Data.Extensions.Npgsql
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Containers, Azure.Core.Expressions, Azure.Data, Azure.DigitalTwins, Azure.Identity, Azure.IoT, Azure.Learn, Azure.Management, Azure.Media, Azure.Messaging, Azure.MixedReality, Azure.Monitor, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Microsoft.Extensions.Azure
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
        public TokenCredentialNpgsqlPasswordProvider(TokenCredential credential) { }

        /// <summary>
        /// Method that implements NpgsqlDbContextOptionsBuilder.ProvidePasswordCallback delegate signature.
        /// It can used in Entity Framework DbContext configuration
        /// </summary>
        /// <param name="host">Just part of the delegate signature. It is ignored</param>
        /// <param name="port">Just part of the delegate signature. It is ignored</param>
        /// <param name="database">Just part of the delegate signature. It is ignored</param>
        /// <param name="username">Just part of the delegate signature. It is ignored</param>
        /// <returns></returns>
        public string ProvidePasswordCallback(string host, int port, string database, string username) { }

        /// <summary>
        /// Property that holds an implementation of NpgsqlDataSourceBuilder.UsePeriodicPasswordProvider delegate signature.
        /// </summary>
        public Func<NpgsqlConnectionStringBuilder, CancellationToken, ValueTask<string>> PasswordProvider { get; }
    }
}
