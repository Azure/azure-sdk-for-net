// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientLiveTestBase : RecordedTestBase<CommunicationIdentityClientTestEnvironment>
    {
        public CommunicationIdentityClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationIdentityClientRecordedTestSanitizer();

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));

        protected CommunicationIdentityClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.Endpoint,
                    new AzureKeyCredential(TestEnvironment.AccessKey),
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));

        protected CommunicationIdentityClient CreateClientWithTokenCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.Endpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));
    }
}
