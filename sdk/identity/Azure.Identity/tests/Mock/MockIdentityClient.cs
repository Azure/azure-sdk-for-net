// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity.Tests.Mock
{
    internal class MockIdentityClient : IdentityClient
    {
        private static AccessToken ExpiredTokenFactory(string[] scopes, string tenantId, string clientId, string clientSecret, CancellationToken cancellationToken)
        {
            return CreateAccessToken(scopes, tenantId, clientId, clientSecret, DateTimeOffset.UtcNow - TimeSpan.FromMinutes(1));
        }

        private static AccessToken LiveTokenFactory(string[] scopes, string tenantId, string clientId, string clientSecret, CancellationToken cancellationToken)
        {
            return CreateAccessToken(scopes, tenantId, clientId, clientSecret, DateTimeOffset.UtcNow + TimeSpan.FromHours(1));
        }

        private static AccessToken CreateAccessToken(string[] scopes, string tenantId, string clientId, string clientSecret, DateTimeOffset expires)
        {
            MockToken token = CreateMockToken(scopes, tenantId, clientId, clientSecret);

            return new AccessToken(token.ToString(), expires);
        }

        private static MockToken CreateMockToken(string[] scopes, string tenantId, string clientId, string clientSecret)
        {
            return new MockToken().WithField("scopes", string.Join("+", scopes)).WithField("tenantId", tenantId).WithField("clientId", clientId).WithField("clientSecret", clientSecret);
        }

        public static MockIdentityClient ExpiredTokenClient { get; } = new MockIdentityClient(ExpiredTokenFactory);

        public static MockIdentityClient LiveTokenClient { get; } = new MockIdentityClient(LiveTokenFactory);
        
        private Func<string[], string, string, string, CancellationToken, AccessToken> _tokenFactory;

        public MockIdentityClient()
            : this(LiveTokenFactory)
        {

        }

        public MockIdentityClient(AccessToken token)
            : this(() => token)
        {
        }

        public MockIdentityClient(Func<AccessToken> tokenFactory)
            : this((scopes, tenantId, clientId, clientSecret, cancellationToken) => tokenFactory())
        {
        }

        public MockIdentityClient(Func<string[], string, string, string, CancellationToken, AccessToken> tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public override AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            return CreateToken(scopes, clientId: clientId, tenantId: tenantId, clientSecret: clientSecret, cancellationToken: cancellationToken);
        }

        public async override Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            return await CreateTokenAsync(scopes, clientId: clientId, tenantId: tenantId, clientSecret: clientSecret, cancellationToken: cancellationToken);
        }
        public override AccessToken AuthenticateManagedIdentity(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            return CreateToken(scopes, clientId: clientId, cancellationToken: cancellationToken);
        }

        public async override Task<AccessToken> AuthenticateManagedIdentityAsync(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {

            return await CreateTokenAsync(scopes, clientId: clientId, cancellationToken: cancellationToken);
        }

        private async Task<AccessToken> CreateTokenAsync(string[] scopes, string tenantId = default, string clientId = default, string clientSecret = default, CancellationToken cancellationToken = default)
        {
            if (cancellationToken != default)
            {
                await Task.Delay(1000, cancellationToken);
            }

            return _tokenFactory(scopes, tenantId, clientId, clientSecret, cancellationToken);
        }

        private AccessToken CreateToken(string[] scopes, string tenantId = default, string clientId = default, string clientSecret = default, CancellationToken cancellationToken = default)
        {
            if (cancellationToken != default)
            {
                Task.Delay(1000, cancellationToken).GetAwaiter().GetResult();
            }

            return _tokenFactory(scopes, tenantId, clientId, clientSecret, cancellationToken);
        }
    }
}
