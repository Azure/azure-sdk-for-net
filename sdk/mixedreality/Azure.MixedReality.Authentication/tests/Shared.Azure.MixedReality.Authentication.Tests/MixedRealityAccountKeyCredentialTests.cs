// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityAccountKeyCredentialTests
    {
        private const string ExpectedTestToken = "87e9abb1-79b9-4502-bbae-cfae8c610f23:my_account_key";

        private static readonly Guid s_testAccountId = Guid.Parse("87e9abb1-79b9-4502-bbae-cfae8c610f23");

        private static readonly string s_testAccountKey = "my_account_key";

        private static readonly AzureKeyCredential s_testKeyCredential = new AzureKeyCredential(s_testAccountKey);

        [Test]
        public void Create()
        {
            new MixedRealityAccountKeyCredential(s_testAccountId, s_testAccountKey);
            new MixedRealityAccountKeyCredential(s_testAccountId, s_testKeyCredential);
        }

        [Test]
        public void CreateWithInvalidParameters()
        {
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => new MixedRealityAccountKeyCredential(Guid.Empty, s_testAccountKey));
            Assert.AreEqual("accountId", ex!.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new MixedRealityAccountKeyCredential(s_testAccountId, (string)null!));
            Assert.AreEqual("key", ex!.ParamName);

            ex = Assert.Throws<ArgumentException>(() => new MixedRealityAccountKeyCredential(s_testAccountId, ""));
            Assert.AreEqual("key", ex!.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => new MixedRealityAccountKeyCredential(s_testAccountId, (AzureKeyCredential)null!));
            Assert.AreEqual("keyCredential", ex!.ParamName);
        }

        [Test]
        public void GetToken()
        {
            MixedRealityAccountKeyCredential credential = new MixedRealityAccountKeyCredential(s_testAccountId, s_testKeyCredential);
            AccessToken token = credential.GetToken(default, default);
            Assert.AreEqual(ExpectedTestToken, token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }

        [Test]
        public async Task GetTokenAsync()
        {
            MixedRealityAccountKeyCredential credential = new MixedRealityAccountKeyCredential(s_testAccountId, s_testKeyCredential);
            AccessToken token = await credential.GetTokenAsync(default, default);
            Assert.AreEqual(ExpectedTestToken, token.Token);
            Assert.AreEqual(DateTimeOffset.MaxValue, token.ExpiresOn);
        }
    }
}
