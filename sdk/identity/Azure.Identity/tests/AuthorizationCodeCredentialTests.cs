// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AuthorizationCodeCredentialTests : ClientTestBase
    {
        public AuthorizationCodeCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task AuthenticateWithAuthCodeMockAsync()
        {
            var expectedToken = Guid.NewGuid().ToString();
            var authCode = Guid.NewGuid().ToString();
            var clientId = Guid.NewGuid().ToString();
            var tenantId = Guid.NewGuid().ToString();
            var clientSecret = Guid.NewGuid().ToString();
            string[] scopes = { "https://vault.azure.net/.default" };
            var account = new MockAccount("username", tenantId);
            var options = new TokenCredentialOptions();
            var authResult = new AuthenticationResult(
                expectedToken,
                false,
                "",
                DateTimeOffset.Now.AddHours(1),
                default,
                tenantId,
                account,
                null,
                scopes,
                Guid.NewGuid(),
                null,
                "Bearer");
            var mockMsalClient = new MockMsalConfidentialClient(authResult);

            AuthorizationCodeCredential cred = InstrumentClient(
                new AuthorizationCodeCredential(tenantId, clientId, clientSecret, authCode, options, mockMsalClient));

            AccessToken token = await cred.GetTokenAsync(new TokenRequestContext(scopes));

            Assert.AreEqual(token.Token, expectedToken);

            AccessToken token2 = await cred.GetTokenAsync(new TokenRequestContext(scopes));

            Assert.AreEqual(token.Token, expectedToken);
        }
    }
}
