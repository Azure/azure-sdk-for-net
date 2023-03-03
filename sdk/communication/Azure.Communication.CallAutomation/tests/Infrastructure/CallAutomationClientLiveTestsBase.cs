﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
{
    internal class CallAutomationClientLiveTestsBase : RecordedTestBase<CallAutomationClientTestEnvironment>
    {
        private const string URIDomainRegEx = @"https://([^/?]+)";

        public CallAutomationClientLiveTestsBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            SanitizedHeaders.Add("X-FORWARDED-HOST");
            SanitizedHeaders.Add("Repeatability-Request-ID");
            SanitizedHeaders.Add("Repeatability-First-Sent");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..rawId");
            JsonPathSanitizers.Add("$..value");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainRegEx, "https://sanitized.skype.com"));
        }

        public bool SkipCallAutomationInteractionLiveTests
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_CALLAUTOMATION_INTERACTION_LIVE_TESTS")== "TRUE";

        /// <summary>
        /// Creates a <see cref="CallAutomationClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClient" />.</returns>
        protected CallAutomationClient CreateInstrumentedCallAutomationClientWithConnectionString()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            CallAutomationClient callAutomationClient;
            if (TestEnvironment.PMAEndpoint == null || TestEnvironment.PMAEndpoint.Length == 0)
            {
                callAutomationClient = new CallAutomationClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            }
            else
            {
                callAutomationClient = new CallAutomationClient(new Uri(TestEnvironment.PMAEndpoint), connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            }

            return InstrumentClient(callAutomationClient);
        }

        /// <summary>
        /// Creates a <see cref="CallAutomationClientOptions" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClientOptions" />.</returns>
        private CallAutomationClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallAutomationClientOptions callClientOptions = new CallAutomationClientOptions();
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }

        protected async Task WaitForOperationCompletion(int milliSeconds = 10000)
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                await Task.Delay(milliSeconds);
        }

        protected string GetResourceId()
        {
            return TestEnvironment.ResourceIdentifier;
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestStaticConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        protected async Task<CommunicationUserIdentifier> CreateIdentityUserAsync() {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            return await communicationIdentityClient.CreateUserAsync().ConfigureAwait(false);
        }
    }
}
