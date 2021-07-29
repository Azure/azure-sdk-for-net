// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class StaticTokenCredentialTests : ClientTestBase
    {
        public StaticTokenCredentialTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task ValidStaticTokenString()
        {
            string expectedToken = "token";
            StaticTokenCredential credential = InstrumentClient(new StaticTokenCredential(expectedToken));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://default.mock.auth.scope/.default" }));

            Assert.AreEqual(expectedToken, actualToken.Token);
        }

        [Test]
        public async Task ValidStaticAccessToken()
        {
            AccessToken expectedToken = new AccessToken("token", DateTimeOffset.MinValue);
            StaticTokenCredential credential = InstrumentClient(new StaticTokenCredential(expectedToken));

            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(new string[] { "https://default.mock.auth.scope/.default" }));

            Assert.AreEqual(expectedToken.Token, actualToken.Token);
            Assert.AreEqual(expectedToken.ExpiresOn, actualToken.ExpiresOn);
        }
    }
}