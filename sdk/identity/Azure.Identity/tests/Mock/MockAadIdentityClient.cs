// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    internal class MockAadIdentityClient : AadIdentityClient
    {
        public MockAadIdentityClient(Func<AccessToken> tokenFactory)
        {
            TokenFactory = tokenFactory;
        }

        public Func<AccessToken> TokenFactory { get; set; }

        public override AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            return TokenFactory();
        }

        public override AccessToken Authenticate(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            return TokenFactory();
        }

        public override Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(TokenFactory());
        }

        public override Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(TokenFactory());
        }
    }
}
