// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallAutomationClients
{
    internal class CallAutomationClientAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallAutomationClientAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateCallToACSGetCallAndHangUpCallTest()
        {
            /* Tests: CreateCall, AnswerCall, Hangup(true), GetCallConnectionProperties, CallConnectedEvent, CallDisconnectedEvent
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call.
             * 5. once call is hung up, verify disconnected event
            */

            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;

            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

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
                    AnswerCallResult answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);

                    // wait for callConnected
                    var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(connectedEvent);
                    Assert.IsTrue(connectedEvent is CallConnected);
                    Assert.AreEqual(callConnectionId, ((CallConnected)connectedEvent!).CallConnectionId);

                    // test get properties
                    Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                    // try hangup
                    await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);
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
                await CleanUpCall(client, callConnectionId);
            }
        }

        [RecordedTest]
        public async Task CreateCallAndReject()
        {
            /* Tests: CreateCall, Reject
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. Reject
             * 3. See if call is not established
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            string? callConnectionId = null;

            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    // answer the call
                    var rejectCallOptions = new RejectCallOptions(incomingCallContext);
                    Response rejectResponse = await client.RejectCallAsync(rejectCallOptions);

                    // check reject response
                    Assert.IsFalse(rejectResponse.IsError);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    {
                        if (ex.Status == 404)
                        {
                            callConnectionId = null;
                            return;
                        }
                    }
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
                await CleanUpCall(client, callConnectionId);
            }
        }

        [RecordedTest]
        public async Task CreateCallAndMediaStreaming()
        {
            /* Tests: CreateCall, Media Streaming
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. Start Media Streaming and Stop Media Streaming
             * 3. See Media Streaming started and stopped in call
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            string? callConnectionId = null;

            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    MediaStreamingOptions mediaStreamingOptions = new MediaStreamingOptions(
                        new Uri("wss://localhost"),
                        MediaStreamingContent.Audio,
                        MediaStreamingAudioChannel.Mixed,
                        MediaStreamingTransport.Websocket,
                        false);
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"))
                    {
                        MediaStreamingOptions = mediaStreamingOptions
                    };
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    //Start media streaming
                    StartMediaStreamingRequestInternal startMediaStreamingOptions = new StartMediaStreamingRequestInternal()
                    {
                        OperationCallbackUri = TestEnvironment.DispatcherCallback + $"?q={uniqueId}",
                        OperationContext = "startMediaStreamingContext"
                    };
                    var startMediaStreamingResponse = await client.CallMediaRestClient.StartMediaStreamingAsync(callConnectionId, startMediaStreamingOptions);
                    var mediaStreamingStartedEvent = await WaitForEvent<MediaStreamingStarted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(mediaStreamingStartedEvent);
                    Assert.IsTrue(mediaStreamingStartedEvent is MediaStreamingStarted);

                    //Stop media streaming
                    StopMediaStreamingRequestInternal stopMediaStreamingOptions = new StopMediaStreamingRequestInternal()
                    {
                        OperationCallbackUri = TestEnvironment.DispatcherCallback + $"?q={uniqueId}"
                    };
                    var stopMediaStreamingResponse = await client.CallMediaRestClient.StopMediaStreamingAsync(callConnectionId, stopMediaStreamingOptions);
                    var stopMediaStreamingEvent = await WaitForEvent<MediaStreamingStopped>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(stopMediaStreamingEvent);
                    Assert.IsTrue(stopMediaStreamingEvent is MediaStreamingStopped);

                    // try hangup
                    await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);
                    callConnectionId = null;
                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    {
                        if (ex.Status == 404)
                        {
                            callConnectionId = null;
                            return;
                        }
                    }
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
                await CleanUpCall(client, callConnectionId);
            }
        }

        [RecordedTest]
        public async Task CreateCallAndTranscription()
        {
            /* Tests: CreateCall, Media Streaming
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. Start Transcription and Stop Transcription
             * 3. See Transcription started and stopped in call
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            string? callConnectionId = null;

            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    TranscriptionOptions transcriptionOptions = new TranscriptionOptions(
                        new Uri("wss://localhost"),
                        "en-US",
                        false);
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"))
                    {
                        TranscriptionOptions = transcriptionOptions
                    };
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    //Start Transcription
                    StartTranscriptionRequestInternal startTranscriptionOptions = new StartTranscriptionRequestInternal()
                    {
                        Locale = "en-US"
                    };
                    var startTranscriptionResponse = await client.CallMediaRestClient.StartTranscriptionAsync(callConnectionId, startTranscriptionOptions);
                    var startTranscriptionEvent = await WaitForEvent<TranscriptionStarted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(startTranscriptionEvent);
                    Assert.IsTrue(startTranscriptionEvent is TranscriptionStarted);

                    //Stop Transcription
                    StopTranscriptionRequestInternal stopTranscriptionOptions = new StopTranscriptionRequestInternal();
                    var stopTranscriptionResponse = await client.CallMediaRestClient.StopTranscriptionAsync(callConnectionId, stopTranscriptionOptions);
                    var stopTranscriptionEvent = await WaitForEvent<TranscriptionStopped>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(stopTranscriptionEvent);
                    Assert.IsTrue(stopTranscriptionEvent is TranscriptionStopped);

                    // try hangup
                    await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);
                    callConnectionId = null;
                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    {
                        if (ex.Status == 404)
                        {
                            callConnectionId = null;
                            return;
                        }
                    }
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
                await CleanUpCall(client, callConnectionId);
            }
        }
    }
}
