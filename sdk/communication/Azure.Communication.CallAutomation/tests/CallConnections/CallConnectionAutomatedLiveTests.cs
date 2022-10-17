﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string? callConnectionId = null;

            try
            {
                // create caller and receiver
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var target = await CreateIdentityUserAsync().ConfigureAwait(false);

                // setup service bus
                var uniqueId = await ServiceBusWithNewCall(user, target);

                // create call and assert response
                var createCallOptions = new CreateCallOptions(new CallSource(user), new CommunicationIdentifier[] { target }, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"))
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("619e45a5-41f2-40bd-a20e-98b13944e146"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                callConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCallContext);

                // answer the call
                var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback)) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("1d58fb9f-24a9-4574-86df-6354ce7fa728"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);

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
                var removeParticipantsOptions = new RemoveParticipantsOptions(new CommunicationIdentifier[] { target }) {
                    OperationContext = operationContext1,
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("650e6e14-23d4-400a-b13c-2481af64dd0b"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                Response<RemoveParticipantsResult> removePartResponse = await response.CallConnection.RemoveParticipantsAsync(removeParticipantsOptions);
                Assert.IsTrue(!removePartResponse.GetRawResponse().IsError);
                Assert.AreEqual(operationContext1, removePartResponse.Value.OperationContext);

                // call should be disconnected after removing participant
                var disconnectedEvent = await WaitForEvent<CallDisconnected>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(disconnectedEvent);
                Assert.IsTrue(disconnectedEvent is CallDisconnected);
                Assert.AreEqual(callConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);
                callConnectionId = null;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                if (!string.IsNullOrEmpty(callConnectionId))
                {
                    var hangUpOptions = new HangUpOptions(true)
                    {
                        RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("fed6e917-f1df-4e21-b7de-c26d0947124b"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                    };
                    await client.GetCallConnection(callConnectionId).HangUpAsync(hangUpOptions).ConfigureAwait(false);
                }
            }
        }
    }
}
