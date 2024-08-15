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

        public async Task HoldUnholdParticipantInACallTest()
        {
            // Create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            var targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;

            try
            {
                // setup call - create and answer the call
                callConnectionId = await SetupCallAsync(client, targetClient, user, target).ConfigureAwait(false);
                var callConnection = client.GetCallConnection(callConnectionId);

                // hold participant and asset
                await AssertParticipantHoldAsync(client, callConnectionId, target, TestEnvironment.FileSourceUrl).ConfigureAwait(false);

                // unhold participant and asset
                await AssertParticipantUnholdAsync(callConnection, target).ConfigureAwait(false);

                // hangup call
                await HangUpCallAsync(client, callConnectionId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId).ConfigureAwait(false);
            }
        }

        [RecordedTest]
        public async Task HoldUnholdParticipantInACallWithHoldOptionsTest()
        {
            // Create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            var targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;

            try
            {
                // setup call - create and answer the call
                callConnectionId = await SetupCallAsync(client, targetClient, user, target).ConfigureAwait(false);
                var callConnection = client.GetCallConnection(callConnectionId);

                var holdOptions = new HoldOptions(target)
                {
                    PlaySource = new FileSource(new Uri(TestEnvironment.FileSourceUrl)),
                    OperationContext = "withholdoptions",
                };
                // hold participant and asset
                await AssertParticipantHoldAsync(client, callConnectionId, target, TestEnvironment.FileSourceUrl).ConfigureAwait(false);

                // unhold participant and asset
                await AssertParticipantUnholdAsync(callConnection, target).ConfigureAwait(false);

                // hangup call
                await HangUpCallAsync(client, callConnectionId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId).ConfigureAwait(false);
            }
        }

        [RecordedTest]
        public async Task HoldUnholdParticipantInACallWithPlaySourceTest()
        {
            // Create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            var targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;

            try
            {
                // setup call - create and answer the call
                callConnectionId = await SetupCallAsync(client, targetClient, user, target).ConfigureAwait(false);
                var callConnection = client.GetCallConnection(callConnectionId);

                // hold participant and asset
                await AssertParticipantHoldAsync(client, callConnectionId, target, TestEnvironment.FileSourceUrl).ConfigureAwait(false);

                // unhold participant and asset
                await AssertParticipantUnholdAsync(callConnection, target).ConfigureAwait(false);

                // hangup call
                await HangUpCallAsync(client, callConnectionId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId).ConfigureAwait(false);
            }
        }

        private async Task<string> SetupCallAsync(CallAutomationClient client, CallAutomationClient targetClient, CommunicationUserIdentifier user, CommunicationUserIdentifier target)
        {
            var uniqueId = await ServiceBusWithNewCall(user, target).ConfigureAwait(false);
            var result = await CreateAndAnswerCall(client, targetClient, target, uniqueId).ConfigureAwait(false);
            var callConnectionId = result.CallerCallConnectionId;

            var addParticipantSucceededEvent = await WaitForEvent<ParticipantsUpdated>(callConnectionId, TimeSpan.FromSeconds(20)).ConfigureAwait(false);
            Assert.IsNotNull(addParticipantSucceededEvent);
            Assert.IsTrue(addParticipantSucceededEvent is ParticipantsUpdated);
            Assert.IsTrue(((ParticipantsUpdated)addParticipantSucceededEvent!).CallConnectionId == callConnectionId);

            return callConnectionId;
        }

        private async Task AssertParticipantHoldAsync(CallAutomationClient client, string callConnectionId, CommunicationUserIdentifier target, string? fileSourceUrl = null, HoldOptions? holdOptions = null)
        {
            var callConnection = client.GetCallConnection(callConnectionId);
            if (!string.IsNullOrWhiteSpace(fileSourceUrl))
            {
                await callConnection.GetCallMedia().HoldAsync(target, new FileSource(new Uri(TestEnvironment.FileSourceUrl))).ConfigureAwait(false);
            }
            else if (holdOptions != null)
            {
                await callConnection.GetCallMedia().HoldAsync(holdOptions).ConfigureAwait(false);
            }

            await Task.Delay(1000).ConfigureAwait(false);
            var participantResult = await callConnection.GetParticipantAsync(target).ConfigureAwait(false);
            Assert.IsNotNull(participantResult);
            Assert.IsTrue(participantResult.Value.IsOnHold);
        }

        private async Task AssertParticipantUnholdAsync(CallConnection callConnection, CommunicationUserIdentifier target)
        {
            await callConnection.GetCallMedia().UnholdAsync(target).ConfigureAwait(false);
            await Task.Delay(1000).ConfigureAwait(false);

            var participantResult = await callConnection.GetParticipantAsync(target).ConfigureAwait(false);
            Assert.IsNotNull(participantResult);
            Assert.IsFalse(participantResult.Value.IsOnHold);
        }

        private async Task HangUpCallAsync(CallAutomationClient client, string callConnectionId)
        {
            await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
            var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20)).ConfigureAwait(false);
            Assert.IsNotNull(disconnectedEvent);
            Assert.IsTrue(disconnectedEvent is CallDisconnected);
            Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);

            try
            {
                var properties = await client.GetCallConnection(callConnectionId).GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    callConnectionId = string.Empty;
                }
            }
        }

        private async Task<(string CallerCallConnectionId, string TargetCallConnectionId)> CreateAndAnswerCall(CallAutomationClient client,
            CallAutomationClient targetClient,
            CommunicationUserIdentifier target,
            string uniqueId,
            bool createCallWithCogService = false)
        {
            try
            {
                // create call and assert response
                var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
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
