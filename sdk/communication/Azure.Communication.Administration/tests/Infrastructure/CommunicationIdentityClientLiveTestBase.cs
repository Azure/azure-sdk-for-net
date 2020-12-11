// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Administration.Tests
{
    public class CommunicationIdentityClientLiveTestBase : RecordedTestBase<CommunicationIdentityClientTestEnvironment>
    {
        public CommunicationIdentityClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationRecordedTestSanitizer();

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

        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClientWithToken(TokenCredential token)
            => InstrumentClient(
                new CommunicationIdentityClient(
                    new Uri(TestEnvironment.EndpointString),
                    token,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions())));
    }
}
