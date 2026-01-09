// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class StaticAccessTokenCredentialTests
    {
        private const string ExpectedTestToken = "my_access_token";

        private static readonly AccessToken s_fakeAccessToken = new AccessToken(ExpectedTestToken, DateTimeOffset.MaxValue);

        [Test]
        public void Create()
        {
            new StaticAccessTokenCredential(s_fakeAccessToken);
        }

        [Test]
        public void GetToken()
        {
            StaticAccessTokenCredential credential = new StaticAccessTokenCredential(s_fakeAccessToken);
            AccessToken token = credential.GetToken(default, default);
            Assert.Multiple(() =>
            {
                Assert.That(token.Token, Is.EqualTo(ExpectedTestToken));
                Assert.That(token.ExpiresOn, Is.EqualTo(DateTimeOffset.MaxValue));
            });
        }

        [Test]
        public async Task GetTokenAsync()
        {
            StaticAccessTokenCredential credential = new StaticAccessTokenCredential(s_fakeAccessToken);
            AccessToken token = await credential.GetTokenAsync(default, default);
            Assert.Multiple(() =>
            {
                Assert.That(token.Token, Is.EqualTo(ExpectedTestToken));
                Assert.That(token.ExpiresOn, Is.EqualTo(DateTimeOffset.MaxValue));
            });
        }
    }
}
