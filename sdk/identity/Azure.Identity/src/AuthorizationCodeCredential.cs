using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Authenticates by redeeming and authorization code previously obtained from Azure Acitve Directory.  See
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow for more information
    /// about the autorization code authentication flow.
    /// </summary>
    public class AuthorizationCodeCredential : TokenCredential
    {
        private readonly IConfidentialClientApplication _confidentialClient;
        private readonly string _authCode;
        private IAccount _account;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="authorizationCode"></param>
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode)
            : this(tenantId, clientId, clientSecret, authorizationCode, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="authorizationCode"></param>
        /// <param name="options"></param>
        public AuthorizationCodeCredential(string tenantId, string clientId, string clientSecret, string authorizationCode, IdentityClientOptions options)
        {
            options ??= new IdentityClientOptions();

            _confidentialClient = ConfidentialClientApplicationBuilder.Create(clientId).WithClientSecret(clientSecret).Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override AccessToken GetToken(TokenRequest request, CancellationToken cancellationToken = default)
        {
            return GetTokenAsync(request, cancellationToken).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<AccessToken> GetTokenAsync(TokenRequest request, CancellationToken cancellationToken = default)
        {
            AccessToken token = default;
            if (_account is null)
            {
                AuthenticationResult result = await _confidentialClient.AcquireTokenByAuthorizationCode(request.Scopes, _authCode).ExecuteAsync().ConfigureAwait(false);

                _account = result.Account;

                token = new AccessToken(result.AccessToken, result.ExpiresOn);
            }
            else
            {
                AuthenticationResult result = await _confidentialClient.AcquireTokenSilent(request.Scopes, _account).ExecuteAsync().ConfigureAwait(false);

                token = new AccessToken(result.AccessToken, result.ExpiresOn);
            }

            return token;
        }
    }
}
