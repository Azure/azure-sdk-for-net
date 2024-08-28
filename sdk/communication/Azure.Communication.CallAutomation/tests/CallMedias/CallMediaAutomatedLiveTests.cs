// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using Azure.Communication.PhoneNumbers;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation.Tests.CallMedias
{
    internal class CallMediaAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallMediaAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Ignore(reason: "Skipping this until live test is re-recorded with latest API")]
        [RecordedTest]
        public async Task continuousDtmfDetectionAndSendDtmfTest()
        {
            /* Test case: Continuous Dtmf start, Stop and Send Dtmf in an ACS to ACS PSTN call
             * 1. create a CallAutomation client
             * 2. create a call from an ACS PSTN to another ACS PSTN target.
             * 3. get updated call properties and check for the connected state.
             * 4. start continuous dtmf recognition.
             * 5. again start continuous dtmf recognition and expect success.
             * 6. send dtmf and expect success.
             * 7. wait for ContinuousDtmfRecognitionToneReceived
             * 8. wait for SendDtmfCompleted event.
             * 9. stop continuous dtmf recognition.
             * 10. wait for ContinuousDtmfRecognitionStopped event.
             * 11. again stop continuous dtmf recognition and expect success.
             * 12. clean up the call.
             */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);

            CommunicationIdentifier sourcePhone;
            CommunicationIdentifier target;

            // when in playback, use Sanatized values
            if (Mode == RecordedTestMode.Playback)
            {
                sourcePhone = new PhoneNumberIdentifier("Sanitized");
                target = new PhoneNumberIdentifier("Sanitized");
            }
            else
            {
                PhoneNumbersClient phoneNumbersClient = new PhoneNumbersClient(TestEnvironment.LiveTestStaticConnectionString);
                var purchasedPhoneNumbers = phoneNumbersClient.GetPurchasedPhoneNumbersAsync();
                List<string> phoneNumbers = new List<string>();
                await foreach (var phoneNumber in purchasedPhoneNumbers)
                {
                    phoneNumbers.Add(phoneNumber.PhoneNumber);
                    Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
                }
                target = new PhoneNumberIdentifier(phoneNumbers[1]);
                sourcePhone = new PhoneNumberIdentifier(phoneNumbers[0]);
            }

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);

            // setup service bus
            var uniqueId = await ServiceBusWithNewCall(sourcePhone, target);

            // create call and assert response
            CallInvite invite = new CallInvite((PhoneNumberIdentifier)target, (PhoneNumberIdentifier)sourcePhone);
            CreateCallResult response = await client.CreateCallAsync(invite, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));

            string callConnectionId = response.CallConnectionProperties.CallConnectionId;
            Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(incomingCallContext);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(connectedEvent);
            Assert.IsTrue(connectedEvent is CallConnected);
            Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

            try
            {
                // start continuous dtmf recognition
                var startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(target);
                Assert.AreEqual(StatusCodes.Status200OK, startContinuousDtmfResponse.Status);

                // again start continuous dtmf recognition and expect success
                startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(target);
                Assert.AreEqual(startContinuousDtmfResponse.Status, StatusCodes.Status200OK);

                // send dtmf tones to the target user
                var tones = new DtmfTone[] { DtmfTone.One };
                var sendDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().SendDtmfTonesAsync(tones, target);
                Assert.AreEqual(StatusCodes.Status202Accepted, sendDtmfResponse.GetRawResponse().Status);

                // wait for ContinuousDtmfRecognitionToneReceived event
                var continuousDtmfRecognitionToneReceived = await WaitForEvent<ContinuousDtmfRecognitionToneReceived>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(continuousDtmfRecognitionToneReceived);
                Assert.IsTrue(continuousDtmfRecognitionToneReceived is ContinuousDtmfRecognitionToneReceived);

                // wait for SendDtmfCompleted event
                var sendDtmfCompletedEvent = await WaitForEvent<SendDtmfTonesCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(sendDtmfCompletedEvent);
                Assert.IsTrue(sendDtmfCompletedEvent is SendDtmfTonesCompleted);

                // stop continuous dtmf recognition
                var stopContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StopContinuousDtmfRecognitionAsync(target);
                Assert.AreEqual(StatusCodes.Status200OK, stopContinuousDtmfResponse.Status);

                // wait for ContinuousDtmfRecognitionStopped event
                var continuousDtmfRecognitionStopped = await WaitForEvent<ContinuousDtmfRecognitionStopped>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(continuousDtmfRecognitionStopped);
                Assert.IsTrue(continuousDtmfRecognitionStopped is ContinuousDtmfRecognitionStopped);

                // again call stop coninuous recognition and expect success
                stopContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StopContinuousDtmfRecognitionAsync(target);
                Assert.AreEqual(StatusCodes.Status200OK, stopContinuousDtmfResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId);
            }
        }

        [RecordedTest]
        public async Task PlayFilesSourceWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // File Source
                    var playFileSource = new FileSource(new Uri(TestEnvironment.FileSourceUrl) );

                    PlayOptions options = new PlayOptions(playFileSource, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayFilesSourceWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // File Source
                    var playFileSource = new FileSource(new Uri(TestEnvironment.FileSourceUrl) );

                    PlayToAllOptions options = new PlayToAllOptions(playFileSource) { OperationContext = "context" };

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayTextSourceWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Text Source
                    var playTextSource = new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" };

                    PlayOptions options = new PlayOptions(playTextSource, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayTextSourceWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Text Source
                    var playTextSource = new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" };

                    PlayToAllOptions options = new PlayToAllOptions(playTextSource) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlaySSMLSourceWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // SSML Source
                    var ssmlToPlay = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";

                    var playSSMLSource = new SsmlSource(ssmlToPlay);

                    PlayOptions options = new PlayOptions(playSSMLSource, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlaySSMLSourceWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // SSML Source
                    var ssmlToPlay = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";

                    var playSSMLSource = new SsmlSource(ssmlToPlay);

                    PlayToAllOptions options = new PlayToAllOptions(playSSMLSource) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayFilesSourceWithPlayMediaWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // File Source
                    var playFileSource = new FileSource(new Uri(TestEnvironment.FileSourceUrl));

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayAsync(playFileSource, new List<CommunicationUserIdentifier>() { target }).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayFilesSourceWithPlayMediaAllWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // File Source
                    var playFileSource = new FileSource(new Uri(TestEnvironment.FileSourceUrl));

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(playFileSource).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayTextSourceWithPlayMediaWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Text Source
                    var playTextSource = new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(playTextSource, new List<CommunicationUserIdentifier>() { target }).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayTextSourceWithPlayMediaAllWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Text Source
                    var playTextSource = new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(playTextSource).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlaySSMLSourceWithPlayMediaWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // SSML Source
                    var ssmlToPlay = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";

                    var playSSMLSource = new SsmlSource(ssmlToPlay);

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(playSSMLSource, new List<CommunicationUserIdentifier>() { target }).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlaySSMLSourceWithPlayMediaAllWithoutOptionsTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // SSML Source
                    var ssmlToPlay = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";

                    var playSSMLSource = new SsmlSource(ssmlToPlay);

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(playSSMLSource).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleFilesSourcesWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple File Source
                    var playFileSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) )
                    };

                    PlayOptions options = new PlayOptions(playFileSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleFilesSourcesWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple File Source
                    var playFileSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) )
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playFileSources) { OperationContext = "context" };

                    // Assert the Play with multiple File Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleTextSourcesWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple Text Source
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt2") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt3") { VoiceName = "en-US-NancyNeural" }
                    };

                    PlayOptions options = new PlayOptions(playTextSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleTextSourcesWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple Text Source
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt2") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt3") { VoiceName = "en-US-NancyNeural" }
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playTextSources) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayCombinedTextAndFileSourcesWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple Sources
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    PlayOptions options = new PlayOptions(playMultipleSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayCombinedTextAndFileSourcesWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple Sources
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playMultipleSources) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayInvalidFileSourceWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Assert multiple Text Source with wrong file source play failed event
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    PlayOptions options = new PlayOptions(playMultipleSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playFailedEvent = await WaitForEvent<PlayFailed>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playFailedEvent);
                    Assert.IsTrue(playFailedEvent is PlayFailed);
                    Assert.AreEqual(callConnectionId, ((PlayFailed)playFailedEvent!).CallConnectionId);
                    Assert.AreEqual(0, ((PlayFailed)playFailedEvent!).FailedPlaySourceIndex);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayInvalidAndValidFileSourceWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Assert multiple Text Source with wrong file source play failed event
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    PlayOptions options = new PlayOptions(playMultipleSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playFailedEvent = await WaitForEvent<PlayFailed>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playFailedEvent);
                    Assert.IsTrue(playFailedEvent is PlayFailed);
                    Assert.AreEqual(callConnectionId, ((PlayFailed)playFailedEvent!).CallConnectionId);
                    Assert.AreEqual(1, ((PlayFailed)playFailedEvent!).FailedPlaySourceIndex);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayInvalidFileSourceWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Assert multiple Text Source with wrong file source play failed event
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playMultipleSources) { OperationContext = "context" };

                    // Assert the Play with invalid file source
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playFailedEvent = await WaitForEvent<PlayFailed>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playFailedEvent);
                    Assert.IsTrue(playFailedEvent is PlayFailed);
                    Assert.AreEqual(callConnectionId, ((PlayFailed)playFailedEvent!).CallConnectionId);
                    Assert.AreEqual(0, ((PlayFailed)playFailedEvent!).FailedPlaySourceIndex);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayInvalidAndInvalidFileSourceWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, false);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Assert multiple Text Source with wrong file source play failed event
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playMultipleSources) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playFailedEvent = await WaitForEvent<PlayFailed>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playFailedEvent);
                    Assert.IsTrue(playFailedEvent is PlayFailed);
                    Assert.AreEqual(callConnectionId, ((PlayFailed)playFailedEvent!).CallConnectionId);
                    Assert.AreEqual(1, ((PlayFailed)playFailedEvent!).FailedPlaySourceIndex);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMaxLimitOfPlaySourcesWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // Max play Sources(Current limit is 10)
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl) ),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt2") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt3") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt4") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt5") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt6") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt7") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt8") { VoiceName = "en-US-NancyNeural" },
                        new TextSource("Test prompt9") { VoiceName = "en-US-NancyNeural" }
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playMultipleSources) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleSSMLSourcesWithPlayMediaTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple SSML Source
                    var ssmlToPlay1 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";
                    var ssmlToPlay2 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 2</voice></speak>";
                    var ssmlToPlay3 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 3</voice></speak>";

                    var playSSMLSources = new List<PlaySource>() {
                        new SsmlSource(ssmlToPlay1),
                        new SsmlSource(ssmlToPlay2),
                        new SsmlSource(ssmlToPlay3)
                    };

                    PlayOptions options = new PlayOptions(playSSMLSources, new List<CommunicationUserIdentifier>() { target }) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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
        public async Task PlayMultipleSSMLSourcesWithPlayMediaAllTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;
            try
            {
                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // multiple SSML Source
                    var ssmlToPlay1 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 1</voice></speak>";
                    var ssmlToPlay2 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 2</voice></speak>";
                    var ssmlToPlay3 = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">SSML Prompt 3</voice></speak>";

                    var playSSMLSources = new List<PlaySource>() {
                        new SsmlSource(ssmlToPlay1),
                        new SsmlSource(ssmlToPlay2),
                        new SsmlSource(ssmlToPlay3)
                    };

                    PlayToAllOptions options = new PlayToAllOptions(playSSMLSources) { OperationContext = "context" };

                    // Assert the Play with multiple Text Sources
                    await callConnection.GetCallMedia().PlayToAllAsync(options).ConfigureAwait(false);
                    var playCompletedEvent = await WaitForEvent<PlayCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(playCompletedEvent);
                    Assert.IsTrue(playCompletedEvent is PlayCompleted);
                    Assert.AreEqual(callConnectionId, ((PlayCompleted)playCompletedEvent!).CallConnectionId);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

                    try
                    {
                        // test get properties
                        Response<CallConnectionProperties> properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
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

        public async Task<(string CallerCallConnectionId, string TargetCallConnectionId)> CreateAndAnswerCall(CallAutomationClient client,
           CallAutomationClient targetClient,
           CommunicationUserIdentifier target,
           string uniqueId,
           bool createCallWithCogService = false)
        {
            try
            {
                // create call and assert response
                var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                if (createCallWithCogService)
                {
                    createCallOptions.CallIntelligenceOptions = new CallIntelligenceOptions() { CognitiveServicesEndpoint = new Uri(TestEnvironment.CognitiveServiceEndpoint) };
                }
                CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                var callerCallConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCallContext);

                // answer the call
                var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                AnswerCallResult answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);

                var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;
                // wait for callConnected

                var connectedEvent = await WaitForEvent<CallConnected>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(connectedEvent);
                Assert.IsTrue(connectedEvent is CallConnected);
                Assert.AreEqual(targetCallConnectionId, ((CallConnected)connectedEvent!).CallConnectionId);
                return (callerCallConnectionId, targetCallConnectionId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
