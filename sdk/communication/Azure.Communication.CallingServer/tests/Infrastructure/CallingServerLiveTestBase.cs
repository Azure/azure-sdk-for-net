// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerLiveTestBase : RecordedTestBase<CallingServerTestEnvironment>
    {
        public CallingServerLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CallingServerRecordedTestSanitizer();

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        /// <summary>
        /// Creates a <see cref="CallingServerClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallingServerClient" />.</returns>
        protected CallingServerClient CreateInstrumentedCallingServerClient()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            CallingServerClient callingServerClient = new CallingServerClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());

            #region Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@CallingServerClient callingServerClient = new CallingServerClient(connectionString);
            #endregion Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient

            return InstrumentClient(callingServerClient);
        }
        protected async Task SleepIfNotInPlaybackModeAsync()
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                await Task.Delay(10000);
        }

        private CallingServerClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallingServerClientOptions callClientOptions = new CallingServerClientOptions();
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }
    }
}
