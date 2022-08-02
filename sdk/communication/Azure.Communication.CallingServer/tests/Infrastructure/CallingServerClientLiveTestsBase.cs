// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.CallingServer.Tests.Infrastructure
{
    internal class CallingServerClientLiveTestsBase : RecordedTestBase<CallingServerClientTestEnvironment>
    {
        private const string URIDomainRegEx = @"https://([^/?]+)";

        public CallingServerClientLiveTestsBase(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            SanitizedHeaders.Add("X-FORWARDED-HOST");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..rawId");
            JsonPathSanitizers.Add("$..value");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainRegEx, "https://sanitized.skype.com"));
        }

        public bool SkipCallingServerInteractionLiveTests
            => TestEnvironment.Mode == RecordedTestMode.Live && Environment.GetEnvironmentVariable("SKIP_CALLINGSERVER_INTERACTION_LIVE_TESTS") == "TRUE";

        /// <summary>
        /// Creates a <see cref="CallingServerClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallingServerClient" />.</returns>
        protected CallingServerClient CreateInstrumentedCallingServerClientWithConnectionString()
        {
            //var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            var connectionString = "endpoint=https://acs-recording-common-e2e.communication.azure.com/;accesskey=bSHJgxhB3/I52CmZkwf3u2ojPNVwEuEyba7SeWbfrKFmYgd7C2eujSD/ArlSBcQzo/dp5ZX7OS2LZ86hIt5UQg==";

            CallingServerClient callingServerClient;
            //if (TestEnvironment.PMAEndpoint == null || TestEnvironment.PMAEndpoint.Length == 0)
            //{
            //    callingServerClient = new CallingServer.CallingServerClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            //}
            //else
            //{
            //    callingServerClient = new CallingServer.CallingServerClient(new Uri(TestEnvironment.PMAEndpoint), connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            //}
            callingServerClient = new CallingServerClient(new Uri("https://pma-dev-fmorales.plat-dev.skype.net/"), connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(callingServerClient);
        }

        /// <summary>
        /// Creates a <see cref="CallingServerClientOptions" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallingServerClientOptions" />.</returns>
        private CallingServerClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallingServerClientOptions callClientOptions = new CallingServerClientOptions();
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
                    "endpoint=https://minwoolee-comm2.communication.azure.com/;accesskey=75HV1Ivj4upqENZnOaKcxaJ6tQGbd9pkIEHHuyAefb8tKFGiYxOLjHeRbg4f/9W3vSWKztx+YLmXxrl9mzArfA==",
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        protected async Task<CommunicationUserIdentifier> CreateIdentityUserAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            return await communicationIdentityClient.CreateUserAsync().ConfigureAwait(false);
        }
    }
}
