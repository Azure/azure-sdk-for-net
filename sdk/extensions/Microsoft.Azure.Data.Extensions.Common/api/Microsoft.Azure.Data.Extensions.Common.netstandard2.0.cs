namespace Microsoft.Azure.Data.Extensions.Common
{
    /// <summary>
    /// Provides basic functionality to provide valid tokens that can be used to authenticate to Azure Open Source databases, such as Postgresql and MySql.
    /// It caches access tokens for performance and avoid throttling.
    /// </summary>
    public partial class TokenCredentialBaseAuthenticationProvider
    {
        /// <summary>
        /// The TokenCredential is provided by the caller
        /// </summary>
        /// <param name="credential">TokenCredential provided by the caller</param>
        public TokenCredentialBaseAuthenticationProvider(TokenCredential credential) { }

        /// <summary>
        /// Provides an access token that can be used to authenticate to OSS Azure databases.
        /// If last authentication token is still valid it could be reused.
        /// </summary>
        /// <param name="cancellationToken">Token that can be used to propagate the cancellation of the operation</param>
        /// <returns>Access Token that can be used to authenticate to Postgresql or MySql</returns>
        public partial async ValueTask<string> GetAuthenticationTokenAsync(CancellationToken cancellationToken = default) { }

        /// <summary>
        /// Provides an access token that can be used to authenticate to OSS Azure databases.
        /// If last authentication token is still valid it could be reused.
        /// </summary>
        /// <param name="cancellationToken">Token that can be used to propagate the cancellation of the operation</param>
        /// <returns>Access Token that can be used to authenticate to Postgresql or MySql</returns>
        public partial string GetAuthenticationToken(CancellationToken cancellationToken = default) { }
    }
}
