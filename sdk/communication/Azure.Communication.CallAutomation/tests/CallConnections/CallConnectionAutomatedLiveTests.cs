// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallConnections
{
    internal class CallConnectionAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallConnectionAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task RemoveAUserCallTest()
        {
            /* Tests: CreateCall, AnswerCall, RemoveParticipants, ParticipantsUpdated
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. Remove a Participant.
             * 5. Check the call if the call is terminated.
            */

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

                    // wait for participants updated
                    var participantsUpdatedEvent1 = await WaitForEvent<ParticipantsUpdated>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(participantsUpdatedEvent1);
                    Assert.AreEqual(2, ((ParticipantsUpdated)participantsUpdatedEvent1!).Participants.Count);

                    // test get properties
                    Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                    // try RemoveParticipants
                    string operationContext1 = "MyTestOperationcontext";
                    var removeParticipantsOptions = new RemoveParticipantOptions(target)
                    {
                        OperationContext = operationContext1,
                    };
                    Response<RemoveParticipantResult> removePartResponse = await response.CallConnection.RemoveParticipantAsync(removeParticipantsOptions);
                    Assert.IsTrue(!removePartResponse.GetRawResponse().IsError);
                    Assert.AreEqual(operationContext1, removePartResponse.Value.OperationContext);

                    // call should be disconnected after removing participant
                    try
                    {
                        // test get properties
                        _ = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    {
                        if (ex.Status == 404)
                        {
                            callConnectionId = null;
                            return;
                        }
                    }

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

        /// <summary>
        /// Tests: CreateCall, MuteParticipant, GetParticipant
        /// Test case: ACS to ACS call
        /// 1. create a CallAutomationClient.
        /// 2. create a call from source to ACS target.
        /// 3. get updated call properties and check for the connected state.
        /// 4. Add a Participant.
        /// 5. Mute the target participant
        /// 6. verify the participant is mutred successfully
        /// </summary>
        /// <returns></returns>
        /// [Ignore("ignore until record asset infrastructure is in place")]
        [RecordedTest]
        public async Task MuteParticipantTest()
        {
            // create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
            var client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            var targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null;

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

                // add participant
                var callConnection = response.CallConnection;
                var operationContext = "context";
                var addParticipantOptions = new AddParticipantOptions(new CallInvite(participantToAdd))
                {
                    InvitationTimeoutInSeconds = 60,
                    OperationContext = operationContext,
                };
                var addParticipantResponse = await callConnection.AddParticipantAsync(addParticipantOptions);
                Assert.AreEqual(operationContext, addParticipantResponse.Value.OperationContext);

                await WaitForOperationCompletion(4000);

                // mute the target participant
                Response<MuteParticipantResult> muteParticipantResponse = await response.CallConnection.MuteParticipantAsync(new MuteParticipantOptions(target)
                {
                    OperationContext = "context"
                });
                Assert.IsNotNull(muteParticipantResponse);
                Assert.AreEqual(200, muteParticipantResponse.GetRawResponse().Status);

                await WaitForOperationCompletion(4000);

                Response<IReadOnlyList<CallParticipant>> participantsResponse = await response.CallConnection.GetParticipantsAsync();
                Assert.IsNotNull(target);

                // verify the participant is mutred successfully
                bool isMuted = false;
                IReadOnlyList<CallParticipant> participants = participantsResponse.Value;
                foreach (CallParticipant participant in participants)
                {
                    if (participant.Identifier.Equals(target) && participant.IsMuted)
                    {
                        isMuted = true;
                    }
                }
                Assert.IsTrue(isMuted, "Failed to mute participant");
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
