// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Communication.SipRouting;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.SipRouting.Tests.Infrastructure
{
    public class SipRoutingClientLiveTestBase : RecordedTestBase<SipRoutingClientTestEnvironment>
    {
        public SipRoutingClientLiveTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Record)
            => Sanitizer = new SipRoutingClientRecordedTestSanitizer();

        public bool IncludeSipRoutingLiveTests
            => TestEnvironment.Mode == RecordedTestMode.Playback
            || string.Equals(Environment.GetEnvironmentVariable("INCLUDE_SipRouting_LIVE_TESTS"), "True", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Creates a <see cref="SipRoutingClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="SipRoutingClient" />.</returns>
        protected SipRoutingClient CreateClient(bool isInstrumented = true)
        {
            var client = new SipRoutingClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SipRoutingClientOptions()));

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="SipRoutingClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="SipRoutingClient" />.</returns>
        protected SipRoutingClient CreateClientWithTokenCredential(TokenCredential token, bool isInstrumented = true)
        {
            var client = new SipRoutingClient(
                    new Uri(ConnectionString.Parse(TestEnvironment.ConnectionString, allowEmptyValues: true).GetRequired("endpoint")),
                    token,
                    InstrumentClientOptions(new SipRoutingClientOptions()));

            return isInstrumented ? InstrumentClient(client) : client;
        }
    }
}
