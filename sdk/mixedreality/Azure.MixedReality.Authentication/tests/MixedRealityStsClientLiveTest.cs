// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityStsClientLiveTest : RecordedTestBase<MixedRealityTestEnvironment>
    {
        public MixedRealityStsClientLiveTest(bool isAsync)
            : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;

            Matcher = new MixedRealityRecordMatcher();
        }

        private MixedRealityStsClient CreateClient()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;
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
