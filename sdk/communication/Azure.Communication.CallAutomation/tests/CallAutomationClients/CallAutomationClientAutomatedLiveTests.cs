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

            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
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
        public async Task CreateCallAndReject()
        {
            /* Tests: CreateCall, Reject
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. Reject
             * 3. See if call is not established
            */

            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            string? callConnectionId = null, uniqueId = null;

            try
            {
                try
                {
                    // setup service bus
                    uniqueId = await ServiceBusWithNewCall(user, target);

                    // create call and assert response
                    var createCallOptions = new CreateCallOptions(
                        new CallInvite(target),
                        new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
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

                    var createCallFailedEvent = await WaitForEvent<CreateCallFailed>(callConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(createCallFailedEvent);
                    Assert.IsTrue(createCallFailedEvent is CreateCallFailed);
                    Assert.AreEqual(callConnectionId, ((CreateCallFailed)createCallFailedEvent!).CallConnectionId);

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
        public async Task CreateCallToAcsConnectCallAndHangupForEveryoneTest()
        {
            /* Tests: CreateCall, AnswerCall, Connect call, Hangup(true), GetCallConnectionProperties, CallConnectedEvent, CallDisconnectedEvent
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. connect call.
             * 4. get updated call properties and check for the connected state.
             * 5. hang up the call.
             * 6. once call is hung up, verify disconnected event
            */

            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
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

                    // server call locator for connect call.
                    CallLocator callLocator = new ServerCallLocator(connectedEvent.ServerCallId);

                    // connect call.
                    ConnectCallResult connectCallResult = await client.ConnectCallAsync(callLocator, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                    var connectCallConnectionId = connectCallResult.CallConnectionProperties.CallConnectionId.ToString();

                    // wait for connect call connected.
                    var connectCallConnectedEvent = await WaitForEvent<CallConnected>(connectCallConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(connectCallConnectedEvent);
                    Assert.IsTrue(connectCallConnectedEvent is CallConnected);
                    Assert.AreEqual(connectCallConnectionId, ((CallConnected)connectCallConnectedEvent!).CallConnectionId);

                    CallConnection ConnectCallConnection = connectCallResult.CallConnection;

                    // test get properties
                    Response<CallConnectionProperties> properties = await ConnectCallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                    // try hangup
                    await connectCallResult.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                    var disconnectedEvent = await WaitForEvent<CallDisconnected>(connectCallConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedEvent);
                    Assert.IsTrue(disconnectedEvent is CallDisconnected);
                    Assert.AreEqual(connectCallConnectionId, ((CallDisconnected)disconnectedEvent!).CallConnectionId);
                    connectCallConnectionId = null;

                    // try hangup
                    try
                    {
                        await answerResponse.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex)
                    {
                        Assert.AreEqual(ex.Status, 404);
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
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        public async Task CreateCallToAcsConnectCallAndHangupTest()
        {
            /* Tests: CreateCall, AnswerCall, Connect call, Hangup(true), GetCallConnectionProperties, CallConnectedEvent, CallDisconnectedEvent
             * Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. connect call.
             * 4. get updated call properties and check for the connected state.
             * 5. hang up the call.
             * 6. once call is hung up, verify disconnected event
            */

            // create caller and receiver
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
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

                    // server call locator for connect call.
                    CallLocator callLocator = new ServerCallLocator(connectedEvent.ServerCallId);

                    // connect call.
                    ConnectCallResult connectCallResult = await client.ConnectCallAsync(callLocator, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
                    var connectCallConnectionId = connectCallResult.CallConnectionProperties.CallConnectionId.ToString();

                    // wait for connect call connected.
                    var connectCallConnectedEvent = await WaitForEvent<CallConnected>(connectCallConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(connectCallConnectedEvent);
                    Assert.IsTrue(connectCallConnectedEvent is CallConnected);
                    Assert.AreEqual(connectCallConnectionId, ((CallConnected)connectCallConnectedEvent!).CallConnectionId);

                    CallConnection ConnectCallConnection = connectCallResult.CallConnection;

                    // test get properties
                    Response<CallConnectionProperties> properties = await ConnectCallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                    Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

                    // try hangup
                    await connectCallResult.CallConnection.HangUpAsync(false).ConfigureAwait(false);
                    var disconnectedConnectEvent = await WaitForEvent<CallDisconnected>(connectCallConnectionId, TimeSpan.FromSeconds(20));
                    Assert.IsNotNull(disconnectedConnectEvent);
                    Assert.IsTrue(disconnectedConnectEvent is CallDisconnected);
                    Assert.AreEqual(connectCallConnectionId, ((CallDisconnected)disconnectedConnectEvent!).CallConnectionId);
                    connectCallConnectionId = null;

                    // try to hangup for anwercall
                    await answerResponse.CallConnection.HangUpAsync(false).ConfigureAwait(false);
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
    }
}
