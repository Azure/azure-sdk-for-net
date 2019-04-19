// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Represents the Azure Active Directory token provider for the Event Hubs.
    /// </summary>
    public class AzureActiveDirectoryTokenProvider : TokenProvider
    {
        readonly AuthenticationContext authContext;

#if !UAP10_0 && !IOS
        readonly ClientCredential clientCredential;
        readonly ClientAssertionCertificate clientAssertionCertificate;
#endif
        readonly string clientId;
        readonly Uri redirectUri;
        readonly IPlatformParameters platformParameters;
        readonly UserIdentifier userIdentifier;

        enum AuthType
        {
            ClientCredential,
            UserPasswordCredential,
            ClientAssertionCertificate,
            InteractiveUserLogin
        }

        readonly AuthType authType;

#if !UAP10_0 && !IOS
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
            this.authContext = authContext;
            this.clientId = clientId;
            this.redirectUri = redirectUri;
            this.platformParameters = platformParameters;
            this.userIdentifier = userIdentifier;
            this.authType = AuthType.InteractiveUserLogin;
        }

        /// <summary>
        /// Gets a <see cref="SecurityToken"/> for the given audience and duration.
        /// </summary>
        /// <param name="appliesTo">The URI which the access token applies to</param>
        /// <param name="timeout">The time span that specifies the timeout value for the message that gets the security token</param>
        /// <returns><see cref="SecurityToken"/></returns>
        public override async Task<SecurityToken> GetTokenAsync(string appliesTo, TimeSpan timeout)
        {
            AuthenticationResult authResult;

            switch (this.authType)
            {
#if !UAP10_0 && !IOS
                case AuthType.ClientCredential:
                    authResult = await this.authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, this.clientCredential);
                    break;

                case AuthType.ClientAssertionCertificate:
                    authResult = await this.authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, this.clientAssertionCertificate);
                    break;
#endif
                case AuthType.InteractiveUserLogin:
                    authResult = await this.authContext.AcquireTokenAsync(ClientConstants.AadEventHubsAudience, this.clientId, this.redirectUri, this.platformParameters, this.userIdentifier);
                    break;

                default:
                    throw new NotSupportedException();
            }

            return new JsonSecurityToken(authResult.AccessToken, appliesTo);
        }
    }
}