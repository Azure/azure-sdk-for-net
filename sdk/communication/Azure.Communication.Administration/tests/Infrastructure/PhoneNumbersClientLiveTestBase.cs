// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Administration.Tests
{
    public class PhoneNumbersClientLiveTestBase : RecordedTestBase<PhoneNumbersClientTestEnvironment>
    {
        public PhoneNumbersClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationRecordedTestSanitizer();

        public bool IncludePhoneNumberLiveTests
            => TestEnvironment.Mode == RecordedTestMode.Playback || Environment.GetEnvironmentVariable("INCLUDE_PHONENUMBER_LIVE_TESTS") == "True";

        /// <summary>
        /// Creates a <see cref="PhoneNumberAdministrationClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumberAdministrationClient" />.</returns>
        protected PhoneNumbersClient CreateClient(bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new PhoneNumbersClientOptions()));

            return isInstrumented ? InstrumentClient(client) : client;
        }
    }
}
