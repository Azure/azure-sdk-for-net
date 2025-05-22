// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        /// <summary>
        /// Tests: CreateCall, AddParticipant, CancelAddParticipant
        /// Test case: ACS to ACS call
        /// 1. create a CallAutomationClient.
        /// 2. create a call from source to ACS target.
        /// 3. get updated call properties and check for the connected state.
        /// 4. Add a Participant.
        /// 5. Cancel the add participant
        /// </summary>
        /// <returns></returns>
        [RecordedTest]
        public async Task CancelAddParticipantTest()
        {
            // create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);
            var participantToAdd = await CreateIdentityUserAsync().ConfigureAwait(false);
            var client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            var targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);
            string? callConnectionId = null, uniqueId = null;

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
                Assert.IsNotNull(addParticipantResponse.Value.InvitationId);

                // ensure invitation has arrived
                await Task.Delay(3000);

                // cancel add participant
                CancelAddParticipantOperationOptions cancelOption = new CancelAddParticipantOperationOptions(addParticipantResponse.Value.InvitationId)
                {
                    OperationContext = operationContext,
                };
                await callConnection.CancelAddParticipantOperationAsync(cancelOption);

                // wait for cancel event
                var CancelAddParticipantSucceededEvent = await WaitForEvent<CancelAddParticipantSucceeded>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(CancelAddParticipantSucceededEvent);
                Assert.IsTrue(CancelAddParticipantSucceededEvent is CancelAddParticipantSucceeded);
                Assert.AreEqual(((CancelAddParticipantSucceeded)CancelAddParticipantSucceededEvent!).InvitationId, addParticipantResponse.Value.InvitationId);
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

        /// <summary>
        /// Tests: CreateCall, MoveParticipants
        /// Test case: Move a participant between two ACS calls
        /// 1. Create two separate calls with three total participants
        /// 2. Wait for both calls to be connected
        /// 3. Move one participant from the first call to the second call
        /// 4. Verify the participant was successfully moved
        /// 5. Verify the participant count in both calls after the move
        /// 6. Clean up both calls
        /// </summary>
        [RecordedTest]
        public async Task MoveParticipantsBetweenCallsTest()
        {
            // Create participants for the test
            var user1 = await CreateIdentityUserAsync().ConfigureAwait(false);         // First call - caller
            var user2 = await CreateIdentityUserAsync().ConfigureAwait(false);         // First call - target (will be moved)
            var user3 = await CreateIdentityUserAsync().ConfigureAwait(false);         // Second call - caller
            var user4 = await CreateIdentityUserAsync().ConfigureAwait(false);         // Second call - target

            // Create clients for each participant
            var client1 = CreateInstrumentedCallAutomationClientWithConnectionString(user1);
            var client2 = CreateInstrumentedCallAutomationClientWithConnectionString(user2);
            var client3 = CreateInstrumentedCallAutomationClientWithConnectionString(user3);
            var client4 = CreateInstrumentedCallAutomationClientWithConnectionString(user4);

            string? call1ConnectionId = null, call2ConnectionId = null, uniqueId1 = null, uniqueId2 = null;

            try
            {
                // Setup first call between user1 and user2
                uniqueId1 = await ServiceBusWithNewCall(user1, user2);
                var createCall1Options = new CreateCallOptions(new CallInvite(user2), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId1}"));
                CreateCallResult call1Response = await client1.CreateCallAsync(createCall1Options).ConfigureAwait(false);
                call1ConnectionId = call1Response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(call1ConnectionId);

                // Wait for incoming call context for first call
                string? incomingCall1Context = await WaitForIncomingCallContext(uniqueId1, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCall1Context);

                // user2 answers the first call
                var answerCall1Options = new AnswerCallOptions(incomingCall1Context, new Uri(TestEnvironment.DispatcherCallback));
                AnswerCallResult answer1Response = await client2.AnswerCallAsync(answerCall1Options);

                // Wait for first call to be connected
                var connected1Event = await WaitForEvent<CallConnected>(call1ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(connected1Event);
                Assert.AreEqual(call1ConnectionId, ((CallConnected)connected1Event!).CallConnectionId);

                // Wait for participants updated in first call
                var participants1UpdatedEvent = await WaitForEvent<ParticipantsUpdated>(call1ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(participants1UpdatedEvent);
                Assert.AreEqual(2, ((ParticipantsUpdated)participants1UpdatedEvent!).Participants.Count);

                // Setup second call between user3 and user4
                uniqueId2 = await ServiceBusWithNewCall(user3, user4);
                var createCall2Options = new CreateCallOptions(new CallInvite(user4), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId2}"));
                CreateCallResult call2Response = await client3.CreateCallAsync(createCall2Options).ConfigureAwait(false);
                call2ConnectionId = call2Response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(call2ConnectionId);

                // Wait for incoming call context for second call
                string? incomingCall2Context = await WaitForIncomingCallContext(uniqueId2, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCall2Context);

                // user4 answers the second call
                var answerCall2Options = new AnswerCallOptions(incomingCall2Context, new Uri(TestEnvironment.DispatcherCallback));
                AnswerCallResult answer2Response = await client4.AnswerCallAsync(answerCall2Options);

                // Wait for second call to be connected
                var connected2Event = await WaitForEvent<CallConnected>(call2ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(connected2Event);
                Assert.AreEqual(call2ConnectionId, ((CallConnected)connected2Event!).CallConnectionId);

                // Wait for participants updated in second call
                var participants2InitialEvent = await WaitForEvent<ParticipantsUpdated>(call2ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(participants2InitialEvent);
                Assert.AreEqual(2, ((ParticipantsUpdated)participants2InitialEvent!).Participants.Count);

                // Move user2 from first call to second call
                string operationContext = "MoveParticipantContext";
                var moveParticipantsOptions = new MoveParticipantsOptions(new[] { user2 }, call1ConnectionId)
                {
                    OperationContext = operationContext
                };

                // Execute move operation from the second call's connection
                Response<MoveParticipantsResult> moveResponse = await call2Response.CallConnection.MoveParticipantsAsync(moveParticipantsOptions);
                Assert.IsFalse(moveResponse.GetRawResponse().IsError);
                Assert.AreEqual(operationContext, moveResponse.Value.OperationContext);

                // Wait for participants updated in second call (should now include user2)
                var participants2UpdatedEvent = await WaitForEvent<ParticipantsUpdated>(call2ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(participants2UpdatedEvent);

                // Verify user2 was added to the second call
                var participantsInCall2 = ((ParticipantsUpdated)participants2UpdatedEvent!).Participants;
                bool user2FoundInCall2 = false;
                foreach (var participant in participantsInCall2)
                {
                    if (participant.Identifier is CommunicationUserIdentifier userIdentifier &&
                        userIdentifier.Id == ((CommunicationUserIdentifier)user2).Id)
                    {
                        user2FoundInCall2 = true;
                        break;
                    }
                }
                Assert.IsTrue(user2FoundInCall2, "User2 was not found in the second call after move operation");
                Assert.AreEqual(3, participantsInCall2.Count, "Second call should now have 3 participants (user2, user3, and user4)");

                // Wait for participants updated in first call (should no longer include user2)
                var participants1UpdatedAfterMoveEvent = await WaitForEvent<ParticipantsUpdated>(call1ConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(participants1UpdatedAfterMoveEvent);

                // Verify user2 was removed from the first call
                var participantsInCall1 = ((ParticipantsUpdated)participants1UpdatedAfterMoveEvent!).Participants;
                bool user2FoundInCall1 = false;
                foreach (var participant in participantsInCall1)
                {
                    if (participant.Identifier is CommunicationUserIdentifier userIdentifier &&
                        userIdentifier.Id == ((CommunicationUserIdentifier)user2).Id)
                    {
                        user2FoundInCall1 = true;
                        break;
                    }
                }
                Assert.IsFalse(user2FoundInCall1, "User2 was still found in the first call after move operation");
                Assert.AreEqual(1, participantsInCall1.Count, "First call should now have only 1 participant (user1)");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Clean up both calls
                await CleanUpCall(client1, call1ConnectionId, uniqueId1);
                await CleanUpCall(client3, call2ConnectionId, uniqueId2);
            }
        }
    }
}
