// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Developer.DevCenter.Tests
{
    /// <summary>
    /// This TokenCredential implementation does the following:
    ///   1. Obtains a token for a user using Username/Secret credential against the test principal
    ///   2. Uses the access token from 1) to obtain a on-behalf-of (OBO) token to the service
    ///
    /// This allows us to test user-only scenarios without user interaction.
    /// </summary>
    internal sealed class DevCenterTestUserCredential : TokenCredential
    {
        private readonly Uri _authority;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _userSecret;
        private readonly string _userName;
        private readonly string[] _dataplaneScopes;

        public DevCenterTestUserCredential(string clientId, string clientSecret, string userSecret, string userName, string dataplaneScope, Uri authorityHost, string tenantId)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _userSecret = userSecret;
            _userName = userName;
            _authority = new(authorityHost, tenantId);
            _dataplaneScopes = new string[] { dataplaneScope };
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            IPublicClientApplication publicApp = PublicClientApplicationBuilder.Create(_clientId)
                                              .WithAuthority(_authority)
                                              .Build();

#pragma warning disable CS0618 // Suppress obsolete warning for AcquireTokenByUsernamePassword in test-only code
            AuthenticationResult userAuthentication = await publicApp.AcquireTokenByUsernamePassword(new string[] { $"api://{_clientId}/fidalgotest" }, _userName, _userSecret).ExecuteAsync();
#pragma warning restore CS0618

            IConfidentialClientApplication confidentialApp = ConfidentialClientApplicationBuilder.Create(_clientId)
                                          .WithAuthority(_authority)
                                          .WithClientSecret(_clientSecret)
                                          .Build();
            AuthenticationResult clientOBOAuthentication = await confidentialApp.AcquireTokenOnBehalfOf(_dataplaneScopes, new UserAssertion(userAuthentication.AccessToken)).ExecuteAsync();

            return new AccessToken(clientOBOAuthentication.AccessToken, clientOBOAuthentication.ExpiresOn);
        }
    }
}
