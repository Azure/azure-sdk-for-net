// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Communication.PhoneNumbers;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectedEvent is CallConnected, Is.True);
                Assert.That(((CallConnected)connectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
            });

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                // start continuous dtmf recognition
                var startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(target);
                Assert.That(startContinuousDtmfResponse.Status, Is.EqualTo(StatusCodes.Status200OK));

                // again start continuous dtmf recognition and expect success
                startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(target);
                Assert.That(startContinuousDtmfResponse.Status, Is.EqualTo(StatusCodes.Status200OK));

                // send dtmf tones to the target user
                var tones = new DtmfTone[] { DtmfTone.One };
                var sendDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().SendDtmfTonesAsync(tones, target);
                Assert.That(sendDtmfResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status202Accepted));

                // wait for ContinuousDtmfRecognitionToneReceived event
                var continuousDtmfRecognitionToneReceived = await WaitForEvent<ContinuousDtmfRecognitionToneReceived>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(continuousDtmfRecognitionToneReceived, Is.Not.Null);
                Assert.That(continuousDtmfRecognitionToneReceived is ContinuousDtmfRecognitionToneReceived, Is.True);

                // wait for SendDtmfCompleted event
                var sendDtmfCompletedEvent = await WaitForEvent<SendDtmfTonesCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(sendDtmfCompletedEvent, Is.Not.Null);
                Assert.That(sendDtmfCompletedEvent is SendDtmfTonesCompleted, Is.True);

                // stop continuous dtmf recognition
                var stopContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StopContinuousDtmfRecognitionAsync(target);
                Assert.That(stopContinuousDtmfResponse.Status, Is.EqualTo(StatusCodes.Status200OK));

                // wait for ContinuousDtmfRecognitionStopped event
                var continuousDtmfRecognitionStopped = await WaitForEvent<ContinuousDtmfRecognitionStopped>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(continuousDtmfRecognitionStopped, Is.Not.Null);
                Assert.That(continuousDtmfRecognitionStopped is ContinuousDtmfRecognitionStopped, Is.True);

                // again call stop coninuous recognition and expect success
                stopContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StopContinuousDtmfRecognitionAsync(target);
                Assert.That(stopContinuousDtmfResponse.Status, Is.EqualTo(StatusCodes.Status200OK));
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playCompletedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playCompletedEvent is PlayCompleted, Is.True);
                        Assert.That(((PlayCompleted)playCompletedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playFailedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playFailedEvent is PlayFailed, Is.True);
                        Assert.That(((PlayFailed)playFailedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                        Assert.That(((PlayFailed)playFailedEvent!).FailedPlaySourceIndex, Is.EqualTo(0));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playFailedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playFailedEvent is PlayFailed, Is.True);
                        Assert.That(((PlayFailed)playFailedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                        Assert.That(((PlayFailed)playFailedEvent!).FailedPlaySourceIndex, Is.EqualTo(1));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playFailedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playFailedEvent is PlayFailed, Is.True);
                        Assert.That(((PlayFailed)playFailedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                        Assert.That(((PlayFailed)playFailedEvent!).FailedPlaySourceIndex, Is.EqualTo(0));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
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
                    Assert.That(playFailedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(playFailedEvent is PlayFailed, Is.True);
                        Assert.That(((PlayFailed)playFailedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                        Assert.That(((PlayFailed)playFailedEvent!).FailedPlaySourceIndex, Is.EqualTo(1));
                    });

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task DtmfRecognizeWithMultipleFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Dtmf;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task DtmfRecognizeWithMultipleTextSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Dtmf;

                    // Assert multiple Text Sources
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice },
                        new TextSource("Test prompt2") { VoiceName = SpeechToTextVoice },
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playTextSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task DtmfRecognizeWithCombinationOfTextAndFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Dtmf;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task DtmfRecognizeWithInvalidFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Dtmf;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task DtmfRecognizeWithInvalidFileSourceWithValidSourceTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Dtmf;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav")),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechRecognizeWithMultipleFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Speech;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechRecognizeWithMultipleTextSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Speech;

                    // Assert multiple Text Sources
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice },
                        new TextSource("Test prompt2") { VoiceName = SpeechToTextVoice },
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playTextSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechRecognizeWithCombinationOfTextAndFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Speech;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechRecognizeWithInvalidFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Speech;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechRecognizeWithInvalidFileSourceWithValidSourceTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Speech;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav")),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task ChoiceRecognizeWithMultipleFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Choices;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task ChoiceRecognizeWithMultipleTextSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Choices;

                    // Assert multiple Text Sources
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice },
                        new TextSource("Test prompt2") { VoiceName = SpeechToTextVoice },
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playTextSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task ChoiceRecognizeWithCombinationOfTextAndFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.Choices;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task ChoiceRecognizeWithInvalidFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Choices;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task ChoiceRecognizeWithInvalidFileSourceWithValidSourceTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.Choices;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav")),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechOrDtmfRecognizeWithMultipleFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.SpeechOrDtmf;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechOrDtmfRecognizeWithMultipleTextSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.SpeechOrDtmf;

                    // Assert multiple Text Sources
                    var playTextSources = new List<PlaySource>() {
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice },
                        new TextSource("Test prompt2") { VoiceName = SpeechToTextVoice },
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playTextSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechOrDtmfRecognizeWithCombinationOfTextAndFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    string SpeechToTextVoice = "en-US-NancyNeural";
                    RecognizeInputType recognizeInputType = RecognizeInputType.SpeechOrDtmf;

                    // Assert combination of text and file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                        new TextSource("Test prompt1") { VoiceName = SpeechToTextVoice }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechOrDtmfRecognizeWithInvalidFileSourcesTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.SpeechOrDtmf;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav"))
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task SpeechOrDtmfRecognizeWithInvalidFileSourceWithValidSourceTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId, true);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    RecognizeInputType recognizeInputType = RecognizeInputType.SpeechOrDtmf;

                    // Assert multiple Text Source with wrong file source
                    var playMultipleSources = new List<PlaySource>() {
                        new FileSource(new Uri("https://dummy.com/dummyurl.wav")),
                        new TextSource("Test prompt1") { VoiceName = "en-US-NancyNeural" }
                    };

                    await VerifyRecognizeFailedEventForMultipleSources(callConnectionId, client, playMultipleSources, target, recognizeInputType, null, true);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task HoldUnholdParticipantInACallTest()
        {
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;
            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);
                    var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId);
                    callConnectionId = result.CallerCallConnectionId;
                    var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
                    var callConnection = client.GetCallConnection(callConnectionId);

                    // wait for callConnected
                    var addParticipantSucceededEvent = await WaitForEvent<ParticipantsUpdated>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(addParticipantSucceededEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(addParticipantSucceededEvent is ParticipantsUpdated, Is.True);
                        Assert.That(((ParticipantsUpdated)addParticipantSucceededEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

                    // Assert the participant hold
                    await callConnection.GetCallMedia().HoldAsync(target).ConfigureAwait(false);
                    await Task.Delay(1000);
                    var participantResult = await callConnection.GetParticipantAsync(target).ConfigureAwait(false);
                    Assert.That(participantResult, Is.Not.Null);
                    Assert.That(participantResult.Value.IsOnHold, Is.True);

                    // Assert the participant unhold
                    await callConnection.GetCallMedia().UnholdAsync(target).ConfigureAwait(false);

                    await Task.Delay(1000);

                    participantResult = await callConnection.GetParticipantAsync(target).ConfigureAwait(false);
                    Assert.That(participantResult, Is.Not.Null);
                    Assert.That(participantResult.Value.IsOnHold, Is.False);

                    // try hangup
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.That(disconnectedEvent, Is.Not.Null);
                    Assert.Multiple(() =>
                    {
                        Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                        Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
                    });

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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task CreateCallWithMediaStreamingTest()
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
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    MediaStreamingOptions mediaStreamingOptions = new MediaStreamingOptions(
                        MediaStreamingAudioChannel.Mixed)
                    { TransportUri = new Uri(TestEnvironment.TransportUrl), StartMediaStreaming = false };

                    var result = await CreateAndAnswerCallWithMediaOrTranscriptionOptions(client, targetClient, target, uniqueId, true,
                          mediaStreamingOptions, transcriptionOptions: null);
                    callConnectionId = result.CallerCallConnectionId;
                    await VerifyMediaStreaming(client, result.CallerCallConnectionId);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task AnswerCallWithMediaStreamingTest()
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
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    MediaStreamingOptions mediaStreamingOptions = new MediaStreamingOptions(
                        MediaStreamingAudioChannel.Mixed)
                    { TransportUri = new Uri(TestEnvironment.TransportUrl) , StartMediaStreaming = false};

                    var result = await CreateAndAnswerCallWithMediaOrTranscriptionOptions(client, targetClient, target, uniqueId, false,
                          mediaStreamingOptions, transcriptionOptions: null);
                    callConnectionId = result.TargetCallConnectionId;
                    await VerifyMediaStreaming(targetClient, result.TargetCallConnectionId);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task AnswerCallWithMediaStreamingUnmixedTest()
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
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    MediaStreamingOptions mediaStreamingOptions = new MediaStreamingOptions(
                        MediaStreamingAudioChannel.Unmixed)
                    { TransportUri = new Uri(TestEnvironment.TransportUrl), StartMediaStreaming = false };

                    var result = await CreateAndAnswerCallWithMediaOrTranscriptionOptions(client, targetClient, target, uniqueId, false,
                          mediaStreamingOptions, transcriptionOptions: null);
                    callConnectionId = result.TargetCallConnectionId;
                    await VerifyMediaStreaming(targetClient, result.TargetCallConnectionId);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task CreateCallAndTranscriptionTest()
        {
            /* Tests: CreateCall, Transcription
             * Test case: ACS to ACS call
             * 1. create a call with transcription options
             * 2. Answer a call
             * 3. Start Transcription and Stop Transcription
             * 3. See Transcription started and stopped event triggerred
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
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
                    TranscriptionOptions transcriptionOptions = new TranscriptionOptions(
                        "en-CA")
                    { TransportUri = new Uri(TestEnvironment.TransportUrl), StartTranscription = false };
                    var result = await CreateAndAnswerCallWithMediaOrTranscriptionOptions(client, targetClient, target, uniqueId, true,
                          null, transcriptionOptions);
                    callConnectionId = result.CallerCallConnectionId;
                    await VerifyTranscription(targetClient, result.CallerCallConnectionId);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task AnswerCallAndTranscriptionTest()
        {
            /* Tests: CreateCall, Transcription
             * Test case: ACS to ACS call
             * 1. create a call
             * 2. Answer a call with transcription options
             * 3. Start Transcription and Stop Transcription
             * 3. See Transcription started and stopped event triggerred
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
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
                    TranscriptionOptions transcriptionOptions = new TranscriptionOptions(
                        "en-CA")
                    { TransportUri = new Uri(TestEnvironment.TransportUrl), StartTranscription = false };
                    var result = await CreateAndAnswerCallWithMediaOrTranscriptionOptions(client, targetClient, target, uniqueId, false,
                          null, transcriptionOptions);
                    callConnectionId = result.TargetCallConnectionId;
                    await VerifyTranscription(targetClient, result.TargetCallConnectionId);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
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
                Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.That(incomingCallContext, Is.Not.Null);

                // answer the call
                var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                AnswerCallResult answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);

                var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;
                // wait for callConnected

                var connectedEvent = await WaitForEvent<CallConnected>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(connectedEvent, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(connectedEvent is CallConnected, Is.True);
                    Assert.That(((CallConnected)connectedEvent!).CallConnectionId, Is.EqualTo(targetCallConnectionId));
                });
                return (callerCallConnectionId, targetCallConnectionId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<(string CallerCallConnectionId, string TargetCallConnectionId)> CreateAndAnswerCallWithMediaOrTranscriptionOptions(
            CallAutomationClient client,
            CallAutomationClient targetClient,
            CommunicationUserIdentifier target,
            string uniqueId,
            bool isOutboundValidation,
            MediaStreamingOptions? mediaStreamingOptions,
            TranscriptionOptions? transcriptionOptions
            )
        {
            try
            {
                // create call and assert response
                var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                if (isOutboundValidation)
                {
                    if (mediaStreamingOptions != null)
                    {
                        createCallOptions.MediaStreamingOptions = mediaStreamingOptions;
                    }
                    if (transcriptionOptions != null)
                    {
                        createCallOptions.TranscriptionOptions = transcriptionOptions;
                        createCallOptions.CallIntelligenceOptions = new CallIntelligenceOptions()
                        {
                            CognitiveServicesEndpoint = new Uri(TestEnvironment.CognitiveServiceEndpoint)
                        };
                    }
                }
                CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                var callerCallConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.That(incomingCallContext, Is.Not.Null);

                // answer the call
                var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                if (!isOutboundValidation)
                {
                    if (mediaStreamingOptions != null)
                    {
                        answerCallOptions.MediaStreamingOptions = mediaStreamingOptions;
                    }
                    if (transcriptionOptions != null)
                    {
                        answerCallOptions.TranscriptionOptions = transcriptionOptions;
                        answerCallOptions.CallIntelligenceOptions = new CallIntelligenceOptions()
                        {
                            CognitiveServicesEndpoint = new Uri(TestEnvironment.CognitiveServiceEndpoint)
                        };
                    }
                }
                AnswerCallResult answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);

                var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;
                // wait for callConnected

                var connectedEvent = await WaitForEvent<CallConnected>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(connectedEvent, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(connectedEvent is CallConnected, Is.True);
                    Assert.That(((CallConnected)connectedEvent!).CallConnectionId, Is.EqualTo(targetCallConnectionId));
                });
                return (callerCallConnectionId, targetCallConnectionId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task VerifyMediaStreaming(CallAutomationClient client,
            string callConnectionId)
        {
            //Start media streaming
            StartMediaStreamingOptions startMediaStreamingOptions = new StartMediaStreamingOptions()
            {
                OperationContext = "startMediaStreamingContext"
            };

            var callerMedia = client.GetCallConnection(callConnectionId).GetCallMedia();
            await callerMedia.StartMediaStreamingAsync(startMediaStreamingOptions);

            // wait for callConnected
            var mediaStreamingStartedEvent = await WaitForEvent<MediaStreamingStarted>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(mediaStreamingStartedEvent, Is.Not.Null);
            Assert.That(mediaStreamingStartedEvent is MediaStreamingStarted, Is.True);

            // Assert call connection properties
            var connectionProperties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(connectionProperties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectionProperties.Value.MediaStreamingSubscription, Is.Not.Null);
                Assert.That(MediaStreamingSubscriptionState.Active, Is.EqualTo(connectionProperties.Value.MediaStreamingSubscription.State));
            });

            //Stop media streaming
            StopMediaStreamingOptions stopMediaStreamingOptions = new StopMediaStreamingOptions();

            await callerMedia.StopMediaStreamingAsync(stopMediaStreamingOptions);

            // wait for callConnected
            var stopMediaStreamingEvent = await WaitForEvent<MediaStreamingStopped>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(stopMediaStreamingEvent, Is.Not.Null);
            Assert.That(stopMediaStreamingEvent is MediaStreamingStopped, Is.True);

            // Assert call connection properties
            connectionProperties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(connectionProperties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectionProperties.Value.MediaStreamingSubscription, Is.Not.Null);
                Assert.That(MediaStreamingSubscriptionState.Inactive, Is.EqualTo(connectionProperties.Value.MediaStreamingSubscription.State));
            });

            // try hangup
            await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
            var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(disconnectedEvent, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
            });
        }

        private async Task VerifyTranscription(CallAutomationClient client, string callConnectionId)
        {
            //Start Transcription
            StartTranscriptionOptions startTranscriptionOptions = new StartTranscriptionOptions()
            {
                Locale = "en-CA",
                OperationContext = "StartTranscription"
            };

            var callerMedia = client.GetCallConnection(callConnectionId).GetCallMedia();
            var startTranscriptionResponse = await callerMedia.StartTranscriptionAsync(startTranscriptionOptions);
            var startTranscriptionEvent = await WaitForEvent<TranscriptionStarted>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(startTranscriptionEvent, Is.Not.Null);
            Assert.That(startTranscriptionEvent is TranscriptionStarted, Is.True);

            var source = new TextSource("Hello, this is live test", "en-US-ElizabethNeural");
            var options = new PlayToAllOptions(source) { OperationContext = "playalloptionduringtranscription" };
            callerMedia.PlayToAll(options);

            // test get properties
            var connectionProperties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(connectionProperties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectionProperties.Value.TranscriptionSubscription, Is.Not.Null);
                Assert.That(TranscriptionSubscriptionState.Active, Is.EqualTo(connectionProperties.Value.TranscriptionSubscription.State));
            });

            // Update Transcription
            UpdateTranscriptionOptions updateTranscriptionOptions = new UpdateTranscriptionOptions("en-US") { OperationContext = "UpdateTranscription" };
            var updateTranscriptionResponse = await callerMedia.UpdateTranscriptionAsync(updateTranscriptionOptions);
            var updateTranscriptionEvent = await WaitForEvent<TranscriptionUpdated>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(updateTranscriptionEvent, Is.Not.Null);
            Assert.That(updateTranscriptionEvent is TranscriptionUpdated, Is.True);

            connectionProperties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(connectionProperties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectionProperties.Value.TranscriptionSubscription, Is.Not.Null);
                Assert.That(TranscriptionSubscriptionState.Active, Is.EqualTo(connectionProperties.Value.TranscriptionSubscription.State));
            });

            //Stop Transcription
            StopTranscriptionOptions stopTranscriptionOptions = new StopTranscriptionOptions() { OperationContext = "StopTranscription" };
            var stopTranscriptionResponse = await callerMedia.StopTranscriptionAsync(stopTranscriptionOptions);

            var stopTranscriptionEvent = await WaitForEvent<TranscriptionStopped>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(stopTranscriptionEvent, Is.Not.Null);
            Assert.That(stopTranscriptionEvent is TranscriptionStopped, Is.True);

            connectionProperties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(connectionProperties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(connectionProperties.Value.TranscriptionSubscription, Is.Not.Null);
                Assert.That(TranscriptionSubscriptionState.Inactive, Is.EqualTo(connectionProperties.Value.TranscriptionSubscription.State));
            });

            // try hangup
            await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
            var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(disconnectedEvent, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(disconnectedEvent is CallDisconnected, Is.True);
                Assert.That(((CallDisconnected)disconnectedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
            });
        }

        private async Task VerifyRecognizeFailedEventForMultipleSources(string callConnectionId,
            CallAutomationClient client, List<PlaySource> playMultipleSources,
            CommunicationUserIdentifier target,
            RecognizeInputType recognizeInputType,
            PlaySource? playSource = null,
            bool isInvalidSourceCheck = false,
            bool expectedBadRequestCheck = false)
        {
            // Assert the playall with multiple Text Sources
            var recognizeOptions = GetRecognizeOptions(playMultipleSources, target, recognizeInputType, playSource);
            Assert.That(recognizeOptions, Is.Not.Null);

            var callConnection = client.GetCallConnection(callConnectionId);

            try
            {
                await callConnection.GetCallMedia().StartRecognizingAsync(recognizeOptions).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (expectedBadRequestCheck)
                {
                    if (ex.Status == 400)
                    {
                        return;
                    }
                }
            }

            // Assert the playall with multiple Text Sources
            var recognizeFailedEvent = await WaitForEvent<RecognizeFailed>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(recognizeFailedEvent, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(recognizeFailedEvent is RecognizeFailed, Is.True);
                Assert.That(((RecognizeFailed)recognizeFailedEvent!).CallConnectionId, Is.EqualTo(callConnectionId));
            });
            if (expectedBadRequestCheck)
            {
                Assert.That(((RecognizeFailed)recognizeFailedEvent!).ReasonCode, Is.EqualTo(MediaEventReasonCode.PlayInvalidFileFormat));
            }
            else if (isInvalidSourceCheck)
            {
                Assert.That(((RecognizeFailed)recognizeFailedEvent!).FailedPlaySourceIndex, Is.EqualTo(0));
            }
            else
            {
                Assert.That(((RecognizeFailed)recognizeFailedEvent!).ReasonCode, Is.EqualTo(MediaEventReasonCode.RecognizeInitialSilenceTimedOut));
                if (recognizeInputType != RecognizeInputType.Dtmf)
                    Assert.That(((RecognizeFailed)recognizeFailedEvent!).FailedPlaySourceIndex, Is.Null);
            }
        }

        private CallMediaRecognizeOptions? GetRecognizeOptions(List<PlaySource> playSources,
            CommunicationUserIdentifier target,
           RecognizeInputType type,
            PlaySource? playSource = null)
        {
            CallMediaRecognizeOptions? recognizeOptions = type.ToString() switch
            {
                "dtmf" => new CallMediaRecognizeDtmfOptions(targetParticipant: target, 2)
                {
                    InterruptPrompt = false,
                    InitialSilenceTimeout = TimeSpan.FromSeconds(5),
                    PlayPrompts = playSources,
                    Prompt = playSource ?? null,
                    OperationContext = "dtmfContext",
                    InterToneTimeout = TimeSpan.FromSeconds(5)
                },
                "choices" => new CallMediaRecognizeChoiceOptions(targetParticipant: target, GetChoices())
                {
                    InterruptCallMediaOperation = false,
                    InterruptPrompt = false,
                    InitialSilenceTimeout = TimeSpan.FromSeconds(5),
                    Prompt = playSource ?? null,
                    PlayPrompts = playSources,
                    OperationContext = "choiceContext"
                },
                "speech" => new CallMediaRecognizeSpeechOptions(target)
                {
                    Prompt = playSource ?? null,
                    PlayPrompts = playSources,
                    EndSilenceTimeout = TimeSpan.FromMilliseconds(1000),
                    OperationContext = "speechContext"
                },
                "speechOrDtmf" => new CallMediaRecognizeSpeechOrDtmfOptions(target, 2)
                {
                    PlayPrompts = playSources,
                    Prompt = playSource ?? null,
                    EndSilenceTimeout = TimeSpan.FromMilliseconds(1000),
                    InitialSilenceTimeout = TimeSpan.FromSeconds(10),
                    InterruptPrompt = true,
                    OperationContext = "speechordtmfContext"
                },
                _ => null
            };

            return recognizeOptions;
        }

        private List<RecognitionChoice> GetChoices()
        {
            return new List<RecognitionChoice> {
            new RecognitionChoice("Confirm", new List<string> {
                "Confirm",
                "First",
                "One"
            }) {
                Tone = DtmfTone.One
            },
            new RecognitionChoice("Cancel", new List<string> {
                "Cancel",
                "Second",
                "Two"
            }) {
                Tone = DtmfTone.Two
            }
        };
        }
    }
}
