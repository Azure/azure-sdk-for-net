// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Identity;
using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.NetworkTraversal.Tests
{
    public class CommunicationRelayClientLiveTestBase : RecordedTestBase<CommunicationRelayClientTestEnvironment>
    {
        public CommunicationRelayClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationRelayClientRecordedTestSanitizer();

        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreTests)
            {
                Assert.Ignore("Networking tests are skipped " +
                    "because networking package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }

        /// <summary>
        /// Creates a <see cref="CommunicationRelayClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationRelayClient" />.</returns>
        protected CommunicationRelayClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.ConnectionString,
                    CreateNetworkingClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationRelayClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.Endpoint,
                    new AzureKeyCredential(TestEnvironment.AccessKey),
                    CreateNetworkingClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationRelayClient CreateClientWithTokenCredential()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.Endpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateNetworkingClientOptionsWithCorrelationVectorLogs()));

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));

        private CommunicationRelayClientOptions CreateNetworkingClientOptionsWithCorrelationVectorLogs()
        {
            CommunicationRelayClientOptions communicationNetworkingClientOptions = new CommunicationRelayClientOptions();
            communicationNetworkingClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(communicationNetworkingClientOptions);
        }
    }
}
