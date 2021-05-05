// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests
{
    public class ServerCallingLiveTestBase : RecordedTestBase<ServerCallingTestEnvironment>
    {
        public ServerCallingLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new ServerCallingRecordedTestSanitizer();

        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreTests)
            {
                Assert.Ignore("ServerCalling tests are skipped " +
                    "because ServerCalling package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }

        public CallClient CreateServerCallingClient()
        {
            var connectionString = TestEnvironment.LiveTestConnectionString;
            CallClient client = new CallClient(connectionString, CreateServerCallingClientOptions());

            #region Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@CallClient client = new CallClient(connectionString);
            #endregion Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            return InstrumentClient(client);
        }
        public CallClient CreateSmsClientWithToken()
        {
            Uri endpoint = TestEnvironment.LiveTestEndpoint;
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                #region Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                /*@@*/tokenCredential = new DefaultAzureCredential();
                //@@ CallClient client = new CallClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClientWithToken
            }
            CallClient client = new CallClient(endpoint, tokenCredential, CreateServerCallingClientOptions());
            return InstrumentClient(client);
        }

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

        // Todo: add CorrelationVectorLogs
        private CallClientOptions CreateServerCallingClientOptions()
        {
            CallClientOptions callClientOptions = new CallClientOptions();
            return InstrumentClientOptions(callClientOptions);
        }
    }
}
