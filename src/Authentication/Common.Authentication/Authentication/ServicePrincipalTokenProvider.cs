// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
//
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
using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Common.Authentication
{
    internal class ServicePrincipalTokenProvider : ITokenProvider
    {
        private static readonly TimeSpan expirationThreshold = TimeSpan.FromMinutes(5);

        public IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId, SecureString password,
            AzureAccount.AccountType credentialType)
        {
            if (credentialType == AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), "credentialType");
            }
            return new ServicePrincipalAccessToken(config, AcquireToken(config, userId, password), this, userId);
        }

        private AuthenticationResult AcquireToken(AdalConfiguration config, string appId, SecureString appKey)
        {
            if (appKey == null)
            {
                return Renew(config, appId);
            }

            StoreAppKey(appId, config.AdDomain, appKey);

            string authority = config.AdEndpoint + config.AdDomain;
            var context = new AuthenticationContext(authority, config.ValidateAuthority,
                AzureSession.TokenCache);
            var credential = new ClientCredential(appId, appKey);
            return context.AcquireToken("https://management.core.windows.net/", credential);
        }

        private AuthenticationResult Renew(AdalConfiguration config, string appId)
        {
            TracingAdapter.Information(Resources.SPNRenewTokenTrace, appId, config.AdDomain, config.AdEndpoint, 
                config.ClientId, config.ClientRedirectUri);
           using (SecureString appKey = LoadAppKey(appId, config.AdDomain))
            {
                if (appKey == null)
                {
                    throw new KeyNotFoundException(string.Format(Resources.ServiceKeyNotFound, appId));
                }
                return AcquireToken(config, appId, appKey);
            }
        }

        private SecureString LoadAppKey(string appId, string tenantId)
        {
            return ServicePrincipalKeyStore.GetKey(appId, tenantId);
        }

        private void StoreAppKey(string appId, string tenantId, SecureString appKey)
        {
            ServicePrincipalKeyStore.SaveKey(appId, tenantId, appKey);
        }


        private class ServicePrincipalAccessToken : IAccessToken
        {
            internal readonly AdalConfiguration Configuration;
            internal AuthenticationResult AuthResult;
            private readonly ServicePrincipalTokenProvider tokenProvider;
            private readonly string appId;

            public ServicePrincipalAccessToken(AdalConfiguration configuration, AuthenticationResult authResult, ServicePrincipalTokenProvider tokenProvider, string appId)
            {
                Configuration = configuration;
                AuthResult = authResult;
                this.tokenProvider = tokenProvider;
                this.appId = appId;
            }

            public void AuthorizeRequest(Action<string, string> authTokenSetter)
            {
                if (IsExpired)
                {
                    AuthResult = tokenProvider.Renew(Configuration, appId);
                }

                authTokenSetter(AuthResult.AccessTokenType, AuthResult.AccessToken);
            }

            public string UserId { get { return appId; } }
            public string AccessToken { get { return AuthResult.AccessToken; } }
            public LoginType LoginType { get { return LoginType.OrgId; } }
            public string TenantId { get { return this.Configuration.AdDomain; } }

            private bool IsExpired
            {
                get
                {
#if DEBUG
                    if (Environment.GetEnvironmentVariable("FORCE_EXPIRED_ACCESS_TOKEN") != null)
                    {
                        return true;
                    }
#endif

                    var expiration = AuthResult.ExpiresOn;
                    var currentTime = DateTimeOffset.UtcNow;
                    var timeUntilExpiration = expiration - currentTime;
                    TracingAdapter.Information(Resources.SPNTokenExpirationCheckTrace, expiration, currentTime, 
                        expirationThreshold, timeUntilExpiration);
                    return timeUntilExpiration < expirationThreshold;
                }
            }
        }
    }
}
