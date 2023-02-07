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

            try
            {
                // create caller and receiver
                CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
                CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
                CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
                string? callConnectionId = null;

                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
<<<<<<< HEAD
<<<<<<< HEAD
=======
                    createCallOptions.RepeatabilityHeaders = null;
>>>>>>> 571d4180fc... integrate call invite to create call
=======
                    createCallOptions.RepeatabilityHeaders = null;
>>>>>>> refs/rewritten/richardcho-create-call
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    // answer the call
                    var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
<<<<<<< HEAD
<<<<<<< HEAD
=======
                    answerCallOptions.RepeatabilityHeaders = null;
>>>>>>> 571d4180fc... integrate call invite to create call
=======
                    answerCallOptions.RepeatabilityHeaders = null;
>>>>>>> refs/rewritten/richardcho-create-call
                    AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);

                    // wait for callConnected
                    var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(connectedEvent);
                    Assert.IsTrue(connectedEvent is CallConnected);
                    Assert.AreEqual(callConnectionId, ((CallConnected)connectedEvent!).CallConnectionId);

                    // test get properties
                    Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                    // try hangup
                    var hangUpOptions = new HangUpOptions(true);
<<<<<<< HEAD
<<<<<<< HEAD
=======
                    hangUpOptions.RepeatabilityHeaders = null;
>>>>>>> 571d4180fc... integrate call invite to create call
=======
                    hangUpOptions.RepeatabilityHeaders = null;
>>>>>>> refs/rewritten/richardcho-create-call
                    await response.CallConnection.HangUpAsync(hangUpOptions).ConfigureAwait(false);
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
                finally
                {
                    await CleanUpCall(client, callConnectionId);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
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
            try
            {
                CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
                CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
                CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
                string? callConnectionId = null;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> refs/rewritten/richardcho-create-call

                try
                {
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
<<<<<<< HEAD
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
=======
>>>>>>> 571d4180fc... integrate call invite to create call

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
<<<<<<< HEAD
=======
                    // setup service bus
                    var uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
=======
>>>>>>> refs/rewritten/richardcho-create-call
                    createCallOptions.RepeatabilityHeaders = null;
                    CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                    callConnectionId = response.CallConnectionProperties.CallConnectionId;
                    Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

                    // wait for incomingcall context
                    string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(incomingCallContext);

                    // answer the call
                    var rejectCallOptions = new RejectCallOptions(incomingCallContext);
                    rejectCallOptions.RepeatabilityHeaders = null;
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
<<<<<<< HEAD
>>>>>>> 571d4180fc... integrate call invite to create call
=======
>>>>>>> refs/rewritten/richardcho-create-call
                    throw;
                }
                finally
                {
                    await CleanUpCall(client, callConnectionId);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
