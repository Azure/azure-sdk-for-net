// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTestBase : RecordedTestBase<RoomsClientTestEnvironment>
    {
        public RoomsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }
        protected RoomsClient CreateInstrumentedRoomsClient()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            RoomsClient client = new RoomsClient(connectionString, CreateRoomsClientOptionsWithCorrelationVectorLogs());

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@RoomsClient client = new RoomsClient(connectionString);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient

            return InstrumentClient(client);
        }

        // TODO: Add Live Tests covering tokenCredential case when supported
        public RoomsClient CreateRoomsClientWithToken()
        {
            Uri endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                /*@@*/tokenCredential = new DefaultAzureCredential();
                //@@ RoomsClient client = new RoomsClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClientWithToken
            }
            RoomsClient client = new RoomsClient(endpoint, tokenCredential, CreateRoomsClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(client);
        }
        private RoomsClientOptions CreateRoomsClientOptionsWithCorrelationVectorLogs()
        {
            RoomsClientOptions roomsClientOptions = new RoomsClientOptions();
            roomsClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(roomsClientOptions);
        }
    }
}
