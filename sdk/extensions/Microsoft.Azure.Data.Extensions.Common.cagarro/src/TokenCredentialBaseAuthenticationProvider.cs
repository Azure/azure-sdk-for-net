// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Common
{
    /// <summary>
    /// Provides basic functionality to provide valid tokens that can be used to authenticate to Azure Open Source databases, such as Postgresql and MySql.
    /// It caches access tokens for performance and avoid throttling.
    /// </summary>
    public class TokenCredentialBaseAuthenticationProvider
    {
        /// <summary>
        /// scope to be requested using TokenCredential to get access to Postgres and MySql
        /// </summary>
        private const string OSSRDBMS_SCOPE = "https://ossrdbms-aad.database.windows.net/.default";

        /// <summary>
        /// The request context is always the same. It is not necessary to create a new one each time it is requested
        /// </summary>
        private static readonly TokenRequestContext requestContext = new TokenRequestContext(new string[] { OSSRDBMS_SCOPE });

        /// <summary>
        /// TokenCredential to use to get access tokens. It can be provided by the caller, otherwise a DefaultAzureCredential is created
        /// </summary>
        private readonly TokenCredential credential;

        /// <summary>
        /// Last access token retrieved. It is used as a response cache
        /// </summary>
        private AccessToken? accessToken;

        /// <summary>
        /// The TokenCredential is provided by the caller
        /// </summary>
        /// <param name="credential">TokenCredential provided by the caller</param>
        public TokenCredentialBaseAuthenticationProvider(TokenCredential credential)
        {
            this.credential = credential;
        }

        /// <summary>
        /// Provides an access token that can be used to authenticate to OSS Azure databases.
        /// If last authentication token is still valid it could be reused.
        /// </summary>
        /// <param name="cancellationToken">Token that can be used to propagate the cancellation of the operation</param>
        /// <returns>Access Token that can be used to authenticate to Postgresql or MySql</returns>
        public async ValueTask<string> GetAuthenticationTokenAsync(CancellationToken cancellationToken = default)
        {
            if (accessToken?.ExpiresOn > DateTimeOffset.UtcNow.AddMinutes(20))
            {
                return accessToken?.Token;
            }
            else
            {
                accessToken = await credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false);
                return accessToken?.Token;
            }
        }

        /// <summary>
        /// Provides an access token that can be used to authenticate to OSS Azure databases.
        /// If last authentication token is still valid it could be reused.
        /// </summary>
        /// <param name="cancellationToken">Token that can be used to propagate the cancellation of the operation</param>
        /// <returns>Access Token that can be used to authenticate to Postgresql or MySql</returns>
        public string GetAuthenticationToken(CancellationToken cancellationToken = default)
        {
            if (accessToken?.ExpiresOn > DateTimeOffset.UtcNow.AddMinutes(20))
            {
                return accessToken?.Token;
            }
            else
            {
                accessToken = credential.GetToken(requestContext, cancellationToken);
                return accessToken?.Token;
            }
        }
    }
}
