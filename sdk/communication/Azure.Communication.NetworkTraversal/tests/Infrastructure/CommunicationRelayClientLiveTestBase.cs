// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Identity;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.NetworkTraversal.Tests
{
    public class CommunicationRelayClientLiveTestBase : RecordedTestBase<CommunicationRelayClientTestEnvironment>
    {
        public CommunicationRelayClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..credential");
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        /// <summary>
        /// Creates a <see cref="CommunicationRelayClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationRelayClient" />.</returns>
        protected CommunicationRelayClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    CreateNetworkingClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationRelayClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    new AzureKeyCredential(TestEnvironment.LiveTestDynamicAccessKey),
                    CreateNetworkingClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationRelayClient CreateClientWithTokenCredential()
            => InstrumentClient(
                new CommunicationRelayClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
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
                    TestEnvironment.LiveTestDynamicConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01))));

        private CommunicationRelayClientOptions CreateNetworkingClientOptionsWithCorrelationVectorLogs()
        {
            CommunicationRelayClientOptions communicationNetworkingClientOptions = new CommunicationRelayClientOptions();
            communicationNetworkingClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(communicationNetworkingClientOptions);
        }
    }
}
