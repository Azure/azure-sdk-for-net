// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Authentication;
using System.Threading;
using System.Windows.Forms;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// A token provider that uses ADAL to retrieve
    /// tokens from Azure Active Directory for user
    /// credentials.
    /// </summary>
    public class RefreshTokenProvider : ITokenProvider
    {
        private string _refreshToken;
        private string _applicationId;
        private readonly static TimeSpan expirationThreshold = TimeSpan.FromMinutes(5);

        public RefreshTokenProvider(string refreshToken, string applicationId)
        {
            _refreshToken = refreshToken;
            _applicationId = applicationId;
        }

        /// <summary>
        /// Acquire an access token using a refresh tone and application Id
        /// </summary>
        /// <param name="config">The adal configuration to use when getting the token</param>
        /// <param name="promptBehavior">ignored</param>
        /// <param name="userId">ignored</param>
        /// <param name="password">ignored</param>
        /// <param name="credentialType">ignored</param>
        /// <returns>An access token acquired using the given refresh token</returns>
        public IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId, SecureString password,
            AzureAccount.AccountType credentialType)
        {
             throw new NotImplementedException();
       }

        public IAccessToken GetAccessTokenWithCertificate(AdalConfiguration config, string principalId, string certificateThumbprint,
            AzureAccount.AccountType credentialType)
        {
            throw new NotImplementedException();
        }

        public IAccessToken GetAccessTokenWithRefreshToken(AdalConfiguration configuration, AzureAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            if (account.Type != AzureAccount.AccountType.RefreshToken)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "RefreshToken"), "credentialType");
            }

            var result = Authenticate(configuration);
            return new AdalAccessToken(result, this, configuration, account.Id);
        }

        private AuthenticationResult Authenticate(AdalConfiguration config)
        {
            var context = new AuthenticationContext(config.AdEndpoint + config.AdDomain, config.ValidateAuthority, config.TokenCache);
            TracingAdapter.Information(Resources.UPNAcquireTokenContextTrace, context.Authority, context.CorrelationId,
                context.ValidateAuthority);
            TracingAdapter.Information(Resources.UPNAcquireTokenConfigTrace, config.AdDomain, config.AdEndpoint,
                config.ClientId, config.ClientRedirectUri);
            var result = context.AcquireTokenByRefreshToken(_refreshToken, _applicationId, config.ResourceClientUri);
            return result;
        }

        internal void Renew(AdalAccessToken token)
        {
            TracingAdapter.Information(Resources.UPNRenewTokenTrace, token.AuthResult.AccessTokenType, token.AuthResult.ExpiresOn,
                token.AuthResult.IsMultipleResourceRefreshToken, token.AuthResult.TenantId, token.UserId);
            var user = token.AuthResult.UserInfo;
            if (user != null)
            {
                TracingAdapter.Information(Resources.UPNRenewTokenUserInfoTrace, user.DisplayableId, user.FamilyName,
                    user.GivenName, user.IdentityProvider, user.UniqueId);
            }
            if (IsExpired(token))
            {
                TracingAdapter.Information(Resources.UPNExpiredTokenTrace);
                AuthenticationResult result = Authenticate(token.Configuration);

                if (result == null)
                {
                    throw new AuthenticationException(Resources.ExpiredRefreshToken);
                }
                else
                {
                    token.AuthResult = result;
                }
            }
        }

        private bool IsExpired(AdalAccessToken token)
        {
#if DEBUG
            if (Environment.GetEnvironmentVariable("FORCE_EXPIRED_ACCESS_TOKEN") != null)
            {
                return true;
            }
#endif
            var expiration = token.AuthResult.ExpiresOn;
            var currentTime = DateTimeOffset.UtcNow;
            var timeUntilExpiration = expiration - currentTime;
            TracingAdapter.Information(Resources.UPNTokenExpirationCheckTrace, expiration, currentTime, expirationThreshold,
                timeUntilExpiration);
            return timeUntilExpiration < expirationThreshold;
        }

    }
}
