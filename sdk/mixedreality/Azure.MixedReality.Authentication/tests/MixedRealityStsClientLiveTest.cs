// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.MixedReality.Authentication;
using NUnit.Framework;

namespace Azure.Template.Tests
{
    public class MixedRealityStsClientLiveTest : RecordedTestBase<MixedRealityStsClientTestEnvironment>
    {
        public MixedRealityStsClientLiveTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Playback)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private MixedRealityStsClient CreateClient()
        {
            string mixedRealityAccountDomain = TestEnvironment.AccountDomain;
            string mixedRealityAccountId = TestEnvironment.AccountId;
            string mixedRealityAccountKey = TestEnvironment.AccountKey;

            return InstrumentClient(new MixedRealityStsClient(
                mixedRealityAccountId,
                mixedRealityAccountDomain,
                mixedRealityAccountKey,
                InstrumentClientOptions(new MixedRealityStsClientOptions())
            ));
        }

        [Test]
        public async Task GetTokenAsync()
        {
            MixedRealityStsClient client = CreateClient();

            AccessToken token = await client.GetTokenAsync();
            Assert.NotNull(token);
            Assert.NotNull(token.Token);
        }
    }
}
