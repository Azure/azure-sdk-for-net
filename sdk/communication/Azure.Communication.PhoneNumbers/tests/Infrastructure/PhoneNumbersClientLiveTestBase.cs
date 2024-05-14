// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumbersClientLiveTestBase : RecordedTestBase<PhoneNumbersClientTestEnvironment>
    {
        private const string PhoneNumberRegEx = @"[\\+]?[0-9]{11,15}";
        private const string UrlEncodedPhoneNumberRegEx = @"[\\%2B]{0,3}[0-9]{11,15}";
        protected const string UnauthorizedNumber = "+14255550123";
        protected const string UnknownPhoneNumberSearchResultId = "01234567-0123-0123-0123-0123456789AB";
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";

        public PhoneNumbersClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("location");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(PhoneNumberRegEx, SanitizeValue));
            UriRegexSanitizers.Add(new UriRegexSanitizer(UrlEncodedPhoneNumberRegEx, SanitizeValue));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        public bool SkipPhoneNumberLiveTests
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_PHONENUMBER_LIVE_TESTS") == "TRUE";

        public bool SkipUpdateCapabilitiesLiveTest
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_UPDATE_CAPABILITIES_LIVE_TESTS") == "TRUE";

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClientWithConnectionString(bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.LiveTestStaticConnectionString,
                    CreatePhoneNumbersClientOptionsWithCorrelationVectorLogs());

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> with the azure key credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClientWithAzureKeyCredential(bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                     new AzureKeyCredential(TestEnvironment.LiveTestStaticAccessKey),
                    CreatePhoneNumbersClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClientWithTokenCredential(bool isInstrumented = true)
        {
            var client = new PhoneNumbersClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreatePhoneNumbersClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="PhoneNumbersClient" /> based on provided authMethod
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="PhoneNumbersClient" />.</returns>
        protected PhoneNumbersClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString, bool isInstrumented = true)
        {
            return authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(isInstrumented),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(isInstrumented),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(isInstrumented),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod))
            };
        }

        protected string GetTestPhoneNumber()
        {
            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                return SanitizeValue;

            if (!SkipUpdateCapabilitiesLiveTest)
                return TestEnvironment.TestAgentPhoneNumber;

            return TestEnvironment.DefaultTestPhoneNumber;
        }

        protected void SleepIfNotInPlaybackMode()
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                Thread.Sleep(2000);
        }

        private PhoneNumbersClientOptions CreatePhoneNumbersClientOptionsWithCorrelationVectorLogs()
        {
            PhoneNumbersClientOptions phoneNumbersClientOptions = new PhoneNumbersClientOptions();
            phoneNumbersClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            phoneNumbersClientOptions.AcceptedLanguage = "en-US";
            return InstrumentClientOptions(phoneNumbersClientOptions);
        }
    }
}
