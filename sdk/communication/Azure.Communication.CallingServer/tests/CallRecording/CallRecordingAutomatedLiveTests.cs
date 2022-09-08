// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Communication.CallingServer
{
    internal class CallRecordingAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallRecordingAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateACSCallAndUnmixedAudioTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. start recording the call without channel affinity
             * 5. stop recording the call
             * 6. hang up the call.
             * 7. once call is hung up, verify disconnected event
            */
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();

            try
            {
                // create caller and reciever
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var target = await CreateIdentityUserAsync().ConfigureAwait(false);

                // setup service bus
                var uniqueId = await ServiceBusWithNewCall(user, target);

                // create call and assert response
                CreateCallResult response = await client.CreateCallAsync(new CallSource(user), new CommunicationIdentifier[] { target }, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}")).ConfigureAwait(false);
                string callConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCallContext);

                // answer the call
                var answerResponse = await client.AnswerCallAsync(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
                Assert.AreEqual(answerResponse.GetRawResponse().Status, StatusCodes.Status200OK);

                // wait for callConnected
                var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(connectedEvent);
                Assert.IsTrue(connectedEvent is CallConnected);
                Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

                // test get properties
                Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                // try start recording unmixed audio - no channel affinity
                var startRecordingResponse = await client.GetCallRecording().StartRecordingAsync(
                    new StartRecordingOptions(new ServerCallLocator(properties.Value.ServerCallId))
                    {
                        RecordingChannel = RecordingChannel.Unmixed,
                        RecordingContent = RecordingContent.Audio,
                        RecordingFormat = RecordingFormat.Wav,
                        RecordingStateCallbackEndpoint = new Uri(TestEnvironment.DispatcherCallback)
                    });
                Assert.AreEqual(StatusCodes.Status200OK, startRecordingResponse.GetRawResponse().Status);
                Assert.NotNull(startRecordingResponse.Value.RecordingId);

                // try stop recording
                var stopRecordingResponse = await client.GetCallRecording().StopRecordingAsync(startRecordingResponse.Value.RecordingId);
                Assert.AreEqual(StatusCodes.Status204NoContent, stopRecordingResponse.Status);

                // wait for CallRecordingStateChanged event TODO: Figure out why this event not being received
                // var recordingStartedEvent = await WaitForEvent<CallRecordingStateChanged>(callConnectionId, TimeSpan.FromSeconds(20));
                // Assert.IsNotNull(recordingStartedEvent);
                // Assert.IsTrue(recordingStartedEvent is CallRecordingStateChanged);
                // Assert.IsTrue(((CallRecordingStateChanged)recordingStartedEvent!).CallConnectionId == callConnectionId);

                // try hangup
                await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(disconnectedEvent);
                Assert.IsTrue(disconnectedEvent is CallDisconnected);
                Assert.IsTrue(((CallDisconnected)disconnectedEvent!).CallConnectionId == callConnectionId);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CreateACSCallUnmixedAudioAffinityTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. start recording the call with channel affinity
             * 5. stop recording the call
             * 6. hang up the call.
             * 7. once call is hung up, verify disconnected event
            */
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();

            try
            {
                // create caller and reciever
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var target = await CreateIdentityUserAsync().ConfigureAwait(false);

                // setup service bus
                var uniqueId = await ServiceBusWithNewCall(user, target);

                // create call and assert response
                CreateCallResult response = await client.CreateCallAsync(new CallSource(user), new CommunicationIdentifier[] { target }, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}")).ConfigureAwait(false);
                string callConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCallContext);

                // answer the call
                var answerResponse = await client.AnswerCallAsync(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
                Assert.AreEqual(answerResponse.GetRawResponse().Status, StatusCodes.Status200OK);

                // wait for callConnected
                var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(connectedEvent);
                Assert.IsTrue(connectedEvent is CallConnected);
                Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

                // test get properties
                Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                // try start recording unmixed audio with channel affinity
                var startRecordingResponse = await client.GetCallRecording().StartRecordingAsync(
                    new StartRecordingOptions(new ServerCallLocator(properties.Value.ServerCallId))
                    {
                        RecordingChannel = RecordingChannel.Unmixed,
                        RecordingContent = RecordingContent.Audio,
                        RecordingFormat = RecordingFormat.Wav,
                        RecordingStateCallbackEndpoint = new Uri(TestEnvironment.DispatcherCallback),
                        ChannelAffinity = new List<ChannelAffinity>
                        {
                            new ChannelAffinity { Channel = 0, Participant = user },
                            new ChannelAffinity { Channel = 1, Participant = target }
                        }
                    });
                Assert.AreEqual(StatusCodes.Status200OK, startRecordingResponse.GetRawResponse().Status);
                Assert.NotNull(startRecordingResponse.Value.RecordingId);

                // try stop recording
                var stopRecordingResponse = await client.GetCallRecording().StopRecordingAsync(startRecordingResponse.Value.RecordingId);
                Assert.AreEqual(StatusCodes.Status204NoContent, stopRecordingResponse.Status);

                // wait for CallRecordingStateChanged event TODO: Figure out why event not received
                // var recordingStartedEvent = await WaitForEvent<CallRecordingStateChanged>(callConnectionId, TimeSpan.FromSeconds(20));
                // Assert.IsNotNull(recordingStartedEvent);
                // Assert.IsTrue(recordingStartedEvent is CallRecordingStateChanged);
                // Assert.IsTrue(((CallRecordingStateChanged)recordingStartedEvent!).CallConnectionId == callConnectionId);

                // try hangup
                await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(disconnectedEvent);
                Assert.IsTrue(disconnectedEvent is CallDisconnected);
                Assert.IsTrue(((CallDisconnected)disconnectedEvent!).CallConnectionId == callConnectionId);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
