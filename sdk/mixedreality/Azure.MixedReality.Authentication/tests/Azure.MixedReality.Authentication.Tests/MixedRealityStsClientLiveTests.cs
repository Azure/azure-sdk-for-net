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
        public MixedRealityStsClientLiveTests(bool isAsync)
            : base(isAsync)
        {
            Matcher = new MixedRealityRecordMatcher();
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
        public async Task GetToken()
        {
            MixedRealityStsClient client = CreateClient();

            AccessToken token = await client.GetTokenAsync();
            Assert.NotNull(token);
            Assert.NotNull(token.Token);
        }
    }
}
