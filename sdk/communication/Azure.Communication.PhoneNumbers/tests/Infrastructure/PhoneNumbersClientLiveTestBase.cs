// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersClientLiveTestBase : RecordedTestBase<PhoneNumbersClientTestEnvironment>
    {
        public PhoneNumbersClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new PhoneNumbersClientRecordedTestSanitizer();

        public bool IncludePhoneNumberLiveTests
            => TestEnvironment.Mode == RecordedTestMode.Playback || Environment.GetEnvironmentVariable("INCLUDE_PHONENUMBER_LIVE_TESTS") == "True";

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClient(bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.LiveTestConnectionString,
                    InstrumentClientOptions(new PhoneNumbersClientOptions()));

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClientWithTokenCredential(TokenCredential token, bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.LiveTestEndpoint,
                    token,
                    InstrumentClientOptions(new PhoneNumbersClientOptions()));

            return isInstrumented ? InstrumentClient(client) : client;
        }
    }
}
