// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.Extensions.Common.Tests
{
    public class TokenCredentialBaseAuthenticationProviderTests : LiveTestBase<ConfigurationTestEnvironment>
    {
        [Test]
        public async Task CachingCreds()
        {
            TokenCredentialBaseAuthenticationProvider authenticationPlugin = new TokenCredentialBaseAuthenticationProvider(TestEnvironment.Credential);
            string[] tokens = await Task.WhenAll(authenticationPlugin.GetAuthenticationTokenAsync().AsTask(), authenticationPlugin.GetAuthenticationTokenAsync().AsTask());
            Assert.AreEqual(tokens[0], tokens[1]);
            string accessToken1 = await authenticationPlugin.GetAuthenticationTokenAsync();
            string accessToken2 = await authenticationPlugin.GetAuthenticationTokenAsync();
            Assert.AreEqual(accessToken1, accessToken2);
            Assert.AreEqual(accessToken1, tokens[1]);
        }

        [Test]
        public async Task NoCachingCreds()
        {
            const string OSSRDBMS_SCOPE = "https://ossrdbms-aad.database.windows.net/.default";
            TokenRequestContext requestContext = new TokenRequestContext(new string[] { OSSRDBMS_SCOPE });
            var token1 = await TestEnvironment.Credential.GetTokenAsync(requestContext, CancellationToken.None);

            var token2 = await TestEnvironment.Credential.GetTokenAsync(requestContext, CancellationToken.None);
            Assert.AreEqual(token1.Token, token2.Token);
        }
    }
}
