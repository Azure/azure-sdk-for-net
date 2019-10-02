// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace TrackOne
{
    /// <summary>
    /// Represents the Azure Active Directory token provider for the Event Hubs.
    /// </summary>
    internal class AzureActiveDirectoryTokenProvider : TokenProvider
    {
        private readonly AuthenticationContext _authContext;

#if ALLOW_CERTIFICATE_IDENTITY
        readonly ClientCredential clientCredential;
        readonly ClientAssertionCertificate clientAssertionCertificate;
#endif
        private readonly string _clientId;
        private readonly Uri _redirectUri;
        private readonly IPlatformParameters _platformParameters;
        private readonly UserIdentifier _userIdentifier;

        private enum AuthType
        {
            ClientCredential,
            UserPasswordCredential,
            ClientAssertionCertificate,
            InteractiveUserLogin
        }

        private readonly AuthType _authType;

#if ALLOW_CERTIFICATE_IDENTITY
        internal AzureActiveDirectoryTokenProvider(AuthenticationContext authContext, ClientCredential credential)
        {
            this.clientCredential = credential;
            this.authContext = authContext;
            this.authType = AuthType.ClientCredential;
            this.clientId = clientCredential.ClientId;
        }

        internal AzureActiveDirectoryTokenProvider(AuthenticationContext authContext, ClientAssertionCertificate clientAssertionCertificate)
        {
            this.clientAssertionCertificate = clientAssertionCertificate;
            this.authContext = authContext;
            this.authType = AuthType.ClientAssertionCertificate;
            this.clientId = clientAssertionCertificate.ClientId;
        }
#endif

        internal AzureActiveDirectoryTokenProvider(AuthenticationContext authContext, string clientId, Uri redirectUri, IPlatformParameters platformParameters, UserIdentifier userIdentifier)
        {
            _authContext = authContext;
            _clientId = clientId;
            _redirectUri = redirectUri;
            _platformParameters = platformParameters;
            _userIdentifier = userIdentifier;
            _authType = AuthType.InteractiveUserLogin;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {

            AuthenticationResult authResult = _authType switch
            {
#if ALLOW_CERTIFICATE_IDENTITY
                case AuthType.ClientCredential:
                    authResult = await this.authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, this.clientCredential);
                    break;

                case AuthType.ClientAssertionCertificate:
                    authResult = await this.authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, this.clientAssertionCertificate);
                    break;
#endif
                AuthType.InteractiveUserLogin => await _authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, _clientId, _redirectUri, _platformParameters, _userIdentifier),

                _ => throw new NotSupportedException(),
            };
            return new JsonSecurityToken(authResult.AccessToken, appliesTo);
        }
    }
}
