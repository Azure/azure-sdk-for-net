// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security;
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
        private readonly string _userId;
        private readonly string _userSecret;
        private readonly string _userName;
        private readonly string[] _dataplaneScopes;

        public DevCenterTestUserCredential(string clientId, string clientSecret, string userId, string userSecret, string userName, string dataplaneScope, Uri authority)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _userId = userId;
            _userSecret = userSecret;
            _userName = userName;
            _authority = authority;
            _dataplaneScopes = new string[] { dataplaneScope };
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken accessToken = GetTokenAsync(requestContext, cancellationToken).GetAwaiter().GetResult();
            return accessToken;
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            IPublicClientApplication app = PublicClientApplicationBuilder.Create(_clientId)
                                              .WithAuthority(_authority)
                                              .Build();

            AuthenticationResult result1 = await app.AcquireTokenByUsernamePassword(new string[] { $"api://{_clientId}/devCenterSdkTest" }, _userName, _userSecret).ExecuteAsync();

            IConfidentialClientApplication app2 = ConfidentialClientApplicationBuilder.Create(_clientId)
                                          .WithAuthority(_authority)
                                          .WithClientSecret(_clientSecret)
                                          .Build();
            AuthenticationResult result2 = await app2.AcquireTokenOnBehalfOf(_dataplaneScopes, new UserAssertion(result1.AccessToken)).ExecuteAsync();

            return new AccessToken(result2.AccessToken, result2.ExpiresOn);
        }
    }
}
