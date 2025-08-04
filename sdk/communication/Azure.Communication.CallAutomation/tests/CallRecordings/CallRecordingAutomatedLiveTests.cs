// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallRecordings
{
    internal class CallRecordingAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallRecordingAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task RecordingOperationsTest()
        {
             // create caller and receiver
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            bool stopRecording = false;

            // setup service bus
            string uniqueId = await ServiceBusWithNewCall(user, target);

            // create call and assert response
            var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
            string callConnectionId = response.CallConnectionProperties.CallConnectionId;
            Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(incomingCallContext);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
            var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
            Assert.AreEqual(answerResponse.GetRawResponse().Status, StatusCodes.Status200OK);

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(connectedEvent);
            Assert.IsTrue(connectedEvent is CallConnected);
            Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

            var serverCallId = properties.Value.ServerCallId;

            CallRecording callRecording = client.GetCallRecording();
            StartRecordingOptions recordingOptions = new StartRecordingOptions(new ServerCallLocator(serverCallId))
            {
                RecordingStateCallbackUri = new Uri(TestEnvironment.DispatcherCallback),
            };
            var recordingResponse = await callRecording.StartAsync(recordingOptions).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);

            var recordingId = recordingResponse.Value.RecordingId;
            Assert.NotNull(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);

            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Active);

            await callRecording.PauseAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Inactive);

            await callRecording.ResumeAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Active);

            await callRecording.StopAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            stopRecording = true;

            try
            {
                recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && stopRecording)
                {
                    // recording stopped successfully
                    return;
                }

                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
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

            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    // answer the call
                    var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
                    var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
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
                    var startRecordingResponse = await client.GetCallRecording().StartAsync(
                        new StartRecordingOptions(new ServerCallLocator(properties.Value.ServerCallId))
                        {
                            RecordingChannel = RecordingChannel.Unmixed,
                            RecordingContent = RecordingContent.Audio,
                            RecordingFormat = RecordingFormat.Wav,
                            RecordingStateCallbackUri = new Uri(TestEnvironment.DispatcherCallback),
                        });
                    Assert.AreEqual(StatusCodes.Status200OK, startRecordingResponse.GetRawResponse().Status);
                    Assert.NotNull(startRecordingResponse.Value.RecordingId);

                    // try stop recording
                    var stopRecordingResponse = await client.GetCallRecording().StopAsync(startRecordingResponse.Value.RecordingId);
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
                    callConnectionId = null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
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
            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    // answer the call
                    var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
                    var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
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
                    var startRecordingOptions =
                        new StartRecordingOptions(new ServerCallLocator(properties.Value.ServerCallId))
                        {
                            RecordingChannel = RecordingChannel.Unmixed,
                            RecordingContent = RecordingContent.Audio,
                            RecordingFormat = RecordingFormat.Wav,
                            RecordingStateCallbackUri = new Uri(TestEnvironment.DispatcherCallback),
                        };
                    startRecordingOptions.AudioChannelParticipantOrdering.Add(user);
                    startRecordingOptions.AudioChannelParticipantOrdering.Add(target);
                    var startRecordingResponse = await client.GetCallRecording().StartAsync(startRecordingOptions);
                    Assert.AreEqual(StatusCodes.Status200OK, startRecordingResponse.GetRawResponse().Status);
                    Assert.NotNull(startRecordingResponse.Value.RecordingId);

                    // try stop recording
                    var stopRecordingResponse = await client.GetCallRecording().StopAsync(startRecordingResponse.Value.RecordingId);
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
                    callConnectionId = null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task StartRecordingWithCallConnectionIdTest()
        {
            // create caller and receiver
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            bool stopRecording = false;

            // setup service bus
            var uniqueId = await ServiceBusWithNewCall(user, target);

            // create call and assert response
            var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
            string callConnectionId = response.CallConnectionProperties.CallConnectionId;
            Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(incomingCallContext);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
            var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
            Assert.AreEqual(answerResponse.GetRawResponse().Status, StatusCodes.Status200OK);

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(connectedEvent);
            Assert.IsTrue(connectedEvent is CallConnected);
            Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

            var serverCallId = properties.Value.ServerCallId;

            CallRecording callRecording = client.GetCallRecording();
            StartRecordingOptions recordingOptions = new StartRecordingOptions(callConnectionId)
            {
                RecordingStateCallbackUri = new Uri(TestEnvironment.DispatcherCallback)
            };
            var recordingResponse = await callRecording.StartAsync(recordingOptions).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);

            var recordingId = recordingResponse.Value.RecordingId;
            Assert.NotNull(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);

            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Active);

            await callRecording.PauseAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Inactive);

            await callRecording.ResumeAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(recordingResponse.Value);
            Assert.NotNull(recordingResponse.Value.RecordingState);
            Assert.AreEqual(recordingResponse.Value.RecordingState, RecordingState.Active);

            await callRecording.StopAsync(recordingId);
            await WaitForOperationCompletion().ConfigureAwait(false);
            stopRecording = true;

            try
            {
                recordingResponse = await callRecording.GetStateAsync(recordingId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && stopRecording)
                {
                    // recording stopped successfully
                    return;
                }

                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }
    }
}
