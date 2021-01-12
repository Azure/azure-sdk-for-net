// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core;
using Azure.MixedReality.RemoteRendering.Models;
using NUnit.Framework;

namespace Azure.MixedReality.RemoteRendering.Tests
{
    public class RemoteRenderingLiveTests : RecordedTestBase<RemoteRenderingTestEnvironment>
    {
        private readonly string _accountDomain;
        private readonly string _accountId;
        private readonly string _accountKey;

        public RemoteRenderingLiveTests(bool isAsync) :
            base(isAsync /*, RecordedTestMode.Record */)
        {
            _accountDomain = TestEnvironment.AccountDomain;
            _accountId = TestEnvironment.AccountId;
            _accountKey = TestEnvironment.AccountKey;
        }

        //[RecordedTest]
        public async void TestSimpleConversion()
        {
            var client = GetClient();

            // TODO: Can I use resources which stay resident somewhere, or will I need them deployed to Blob storage
            // as part of the test deployment?

            ConversionInputSettings input = new ConversionInputSettings("foo", "bar.fbx");
            ConversionOutputSettings output = new ConversionOutputSettings("foobar.arrAsset");
            ConversionSettings settings = new ConversionSettings(input, output);

            string conversionId = "MyConversionId";

            ConversionInformation conversion = await client.CreateConversionAsync(conversionId, settings);
            Assert.AreEqual(conversion.Settings, settings);

            ConversionInformation conversion2 = await client.GetConversionAsync(conversionId);
            Assert.AreEqual(conversion2.Settings, settings);
        }

        //[RecordedTest]
        public async void TestSimpleSession()
        {
            var client = GetClient();

            CreateSessionBody settings = new CreateSessionBody(10, SessionSize.Standard);

            string sessionId = "MySessionId";

            SessionProperties session = await client.CreateSessionAsync(sessionId, settings);
            Assert.AreEqual(session.MaxLeaseTimeMinutes, settings.MaxLeaseTimeMinutes);
            Assert.AreEqual(session.Size, settings.Size);

            SessionProperties session2 = await client.GetSessionAsync(sessionId);
            Assert.AreEqual(session2, session);

            UpdateSessionBody updateSettings = new UpdateSessionBody(15);

            SessionProperties session3 = await client.UpdateSessionAsync(sessionId, updateSettings);
            Assert.AreEqual(session3.MaxLeaseTimeMinutes, 15);

            var sessionList = client.ListSessions();
            int sessionCount = 0;
            foreach (var s in sessionList)
            {
                ++sessionCount;
                Assert.AreEqual(session3, s);
            }
            Assert.AreEqual(sessionCount, 1);

            await client.StopSessionAsync(sessionId);
        }

        private RemoteRenderingClient GetClient()
        {
            var options = InstrumentClientOptions(new RemoteRenderingClientOptions());
            return InstrumentClient(new RemoteRenderingClient(_accountId, options));
        }
    }
}
