// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallDialogs
{
    internal class CallDialogAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallDialogAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DialogOperationsTest()
        {
            // ignores test if botAppId is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            if (botAppId == null)
            {
                Assert.Ignore();
            }

            // create caller and receiver
            var user = await CreateIdentityUserAsync().ConfigureAwait(false);
            var target = await CreateIdentityUserAsync().ConfigureAwait(false);

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);

            // setup service bus
            var uniqueId = await ServiceBusWithNewCall(user, target);

            // create call and assert response
            var createCallOptions = new CreateCallOptions(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
            string callConnectionId = response.CallConnectionProperties.CallConnectionId;
            Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

            // wait for incoming call context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(incomingCallContext);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
            var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
            Assert.AreEqual(answerResponse.GetRawResponse().Status, StatusCodes.Status200OK);
            var targetCallConnectionId = answerResponse.Value.CallConnectionProperties.CallConnectionId;

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
                var callDialog = client.GetCallConnection(callConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(DialogInputType.PowerVirtualAgents, botAppId, dialogContext)
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                var dialogId = dialogResponse.Value.DialogId;
                Assert.NotNull(dialogResponse.Value.DialogId);

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.NotNull(dialogStartedReceived);
                Assert.IsTrue(dialogStartedReceived is DialogStarted);

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status204NoContent, stopDialogResponse.GetRawResponse().Status);

                var dialogStoppedReceived = await WaitForEvent<DialogCompleted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(dialogStoppedReceived);
                Assert.IsTrue(dialogStoppedReceived is DialogCompleted);
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
    }
}
