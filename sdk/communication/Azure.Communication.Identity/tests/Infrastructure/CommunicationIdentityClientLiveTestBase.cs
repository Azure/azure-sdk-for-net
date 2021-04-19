// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientLiveTestBase : RecordedTestBase<CommunicationIdentityClientTestEnvironment>
    {
        public CommunicationIdentityClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationIdentityClientRecordedTestSanitizer();

        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreTests)
            {
                Assert.Ignore("Identity tests are skipped " +
                    "because identity package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.ConnectionString,
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationIdentityClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.Endpoint,
                    new AzureKeyCredential(TestEnvironment.AccessKey),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationIdentityClient CreateClientWithTokenCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.Endpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        private CommunicationIdentityClientOptions CreateIdentityClientOptionsWithCorrelationVectorLogs()
        {
            CommunicationIdentityClientOptions communicationIdentityClientOptions = new CommunicationIdentityClientOptions();
            communicationIdentityClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(communicationIdentityClientOptions);
        }
    }
}
