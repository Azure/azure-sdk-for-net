// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    internal class CallRecordingLiveTests : CallingServerClientLiveTestsBase
    {
        public CallRecordingLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task RecordingOperations()
        {
            //if (SkipCallingServerInteractionLiveTests)
            //{
            //    Assert.Ignore("Skip callingserver interaction live tests flag is on");
            //}

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            string callConnectionId = "421f0b00-8734-4a48-941a-e45cfa931d57";

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetUser = "8:acs:70559d7c-67b2-444f-a1f3-8027a1412880_00000013-1e8e-b94b-02c3-593a0d00c4cd";
                string ngrok = "https://6961-2001-4898-80e8-9-b17d-4a04-3083-2cc4.ngrok.io";
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(targetUser) };
                var callResponse = await client.CreateCallAsync(new CallSource(user), targets, new Uri(ngrok)).ConfigureAwait(false);
                string callId = "52753440-1452-11ed-a659-d9a97e0e1bb4";
                CallRecording callRecording = client.GetCallRecording();
                var recordingResponse = await callRecording.StartRecordingAsync(new GroupCallLocator(callId), new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);

                var recordingId = recordingResponse.Value.RecordingId;
                Assert.NotNull(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);

                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);
                Assert.NotNull(recordingResponse.Value.RecordingStatus);
                Assert.Equals(recordingResponse.Value.RecordingStatus ?? "", "active");

                //await callRecording.PauseRecordingAsync(recordingId);
                //await WaitForOperationCompletion().ConfigureAwait(false);
                //recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                //Assert.NotNull(recordingResponse.Value);
                //Assert.NotNull(recordingResponse.Value.RecordingStatus);
                //Assert.Equals(recordingResponse.Value.RecordingStatus ?? "", "inactive");

                //await callRecording.ResumeRecordingAsync(recordingId);
                //await WaitForOperationCompletion().ConfigureAwait(false);
                //recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                //Assert.NotNull(recordingResponse.Value);
                //Assert.NotNull(recordingResponse.Value.RecordingStatus);
                //Assert.Equals(recordingResponse.Value.RecordingStatus ?? "", "active");

                await callRecording.StopRecordingAsync(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);
                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected Error: {ex}");
            }
            finally
            {
                var callConnection = client.GetCallConnection(callConnectionId);
                await callConnection.HangupAsync(true).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task CreateCallToACSGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallingServerClient.
             * 2. create a call from source to one ACS target.
             * 3. use GetCall method to check for the connected state.
             * 4. hang up the call.
             * 5. use GetCall method to check for 404 Not Found once call is hung up.
            */

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            bool wasConnected = false;
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetUser = await CreateIdentityUserAsync().ConfigureAwait(false);
                string ngrok = "https://6961-2001-4898-80e8-9-b17d-4a04-3083-2cc4.ngrok.io";
                var targets = new CommunicationIdentifier[] { targetUser };
                var callResponse = await client.CreateCallAsync(new CallSource(user), targets, new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(callResponse);
                var call = callResponse.Value;
                Assert.NotNull(call);
                CallConnection callConnection = call.CallConnection;
                var callConnectionId = callConnection.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);
                var callConnectionPropertiesResponse = await callConnection.GetPropertiesAsync().ConfigureAwait(false);
                var callConnectionProperties = callConnectionPropertiesResponse.Value;
                Assert.NotNull(callConnectionProperties);
                Assert.AreEqual("connecting", callConnectionProperties.CallConnectionState.ToString());
                await WaitForOperationCompletion().ConfigureAwait(false);

                for (int retry = 0; retry < 10; retry++)
                {
                    callConnectionPropertiesResponse = await callConnection.GetPropertiesAsync().ConfigureAwait(false);
                    callConnectionProperties = callConnectionPropertiesResponse.Value;
                    Assert.NotNull(callConnectionProperties);
                    //Assert.AreEqual("connected", callConnectionProperties.CallConnectionState.ToString());
                    if ("connected" == callConnectionProperties.CallConnectionState.ToString())
                    {
                        Assert.AreEqual("connected", callConnectionProperties.CallConnectionState.ToString());
                        Console.WriteLine("Connected!!");
                        wasConnected = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Not connected for the {retry + 1} time");
                    }
                    await WaitForOperationCompletion().ConfigureAwait(false);
                }

                await callConnection.HangupAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                callConnectionPropertiesResponse = await callConnection.GetPropertiesAsync().ConfigureAwait(false);
                Assert.Fail("Call connection should not be found after hanging up.");
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && wasConnected)
                {
                    // call hung up successfully
                    Assert.Pass();
                }
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
