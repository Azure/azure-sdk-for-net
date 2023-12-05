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
                await CleanUpCall(client, callConnectionId);
            }
        }
    }
}
