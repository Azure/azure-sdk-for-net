// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityTokenCredentialTests
    {
        private static readonly Guid s_testAccountId = Guid.Parse("87e9abb1-79b9-4502-bbae-cfae8c610f23");

        private static readonly Uri s_testEndpoint = new Uri("https://sts.my.mixedreality.endpoint.com");

        [Test]
        public void GetMixedRealityCredential()
        {
            MixedRealityAccountKeyCredential credential = new MixedRealityAccountKeyCredential(s_testAccountId, "my_account_key");
            TokenCredential actual = MixedRealityTokenCredential.GetMixedRealityCredential(s_testAccountId, s_testEndpoint, credential);

            Assert.AreNotEqual(credential, actual);
        }

        [Test]
        public void GetMixedRealityCredentialWithStatic()
        {
            StaticAccessTokenCredential credential = new StaticAccessTokenCredential(default);
            TokenCredential actual = MixedRealityTokenCredential.GetMixedRealityCredential(s_testAccountId, s_testEndpoint, credential);

            Assert.AreEqual(credential, actual);
        }
    }
}
