// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using NUnit.Framework.Internal;

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
                CreateCallResult response = await client.CreateCallAsync(new CreateCallOptions(new CallSource(user), new CommunicationIdentifier[] { target }, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"))).ConfigureAwait(false);
                callConnectionId = response.CallConnectionProperties.CallConnectionId;
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                // wait for incomingcall context
                string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(incomingCallContext);

                // answer the call
                AnswerCallResult answerResponse = await client.AnswerCallAsync(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));

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
                Response<RemoveParticipantsResult> removePartResponse = await response.CallConnection.RemoveParticipantsAsync(new CommunicationIdentifier[] { target }, operationContext1);
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
                    await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                }
            }
        }
    }
}
