﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

        [RecordedTest]
        public async Task CreateCallAndReject()
        {
            /* Tests: CreateCall, Reject
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. Reject
             * 3. See if call is not established
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
                Response rejectResponse = await client.RejectCallAsync(incomingCallContext, CallRejectReason.None);

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
                        // doesn't exist, as expected
                        Assert.Pass();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
