// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityStsClientLiveTests : RecordedTestBase<MixedRealityTestEnvironment>
    {
        private const string ClientCorrelationVectorHeaderName = "X-MRC-CV";

        public MixedRealityStsClientLiveTests(bool isAsync)
            : base(isAsync)
        {
            IgnoredHeaders.Add(ClientCorrelationVectorHeaderName);
        }

        private MixedRealityStsClient CreateClient()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            Guid mixedRealityAccountId = Guid.Parse(TestEnvironment.AccountId);
            string mixedRealityAccountKey = TestEnvironment.AccountKey;

            return InstrumentClient(new MixedRealityStsClient(
                mixedRealityAccountId,
                mixedRealityAccountDomain,
                new AzureKeyCredential(mixedRealityAccountKey),
                InstrumentClientOptions(new MixedRealityStsClientOptions())
            ));
        }

        [Test]
        [LiveOnly(Reason = "JWT cannot be stored in test recording.")]
        public async Task GetToken()
        {
            MixedRealityStsClient client = CreateClient();

            AccessToken token = await client.GetTokenAsync();
            Assert.NotNull(token);
            Assert.NotNull(token.Token);
        }
    }
}
