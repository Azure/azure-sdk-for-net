// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Communication.PhoneNumbers;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallDialogs
{
    internal class CallDialogAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        private const string dialogId = "92e08834-b6ee-4ede-8956-9fefa27a691c";
        public CallDialogAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DialogOperationsTest()
        {
            // ignores test if botAppId or PMA Endpoint is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            var endpoint = TestEnvironment.PMAEndpoint;
            if (botAppId == null || endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                var checkedDialogId = dialogResponse.Value.DialogId;
                Assert.NotNull(dialogResponse.Value.DialogId);
                Assert.IsTrue(Guid.TryParse(checkedDialogId, out var result));
                Assert.AreEqual(checkedDialogId, dialogId);

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.NotNull(dialogStartedReceived);
                Assert.IsTrue(dialogStartedReceived is DialogStarted);

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(checkedDialogId).ConfigureAwait(false);
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

        [RecordedTest]
        public async Task DifferingConcurrentDialogsTest()
        {
            // ignores test if botAppId or PMA Endpoint is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            var endpoint = TestEnvironment.PMAEndpoint;
            if (botAppId == null || endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                Assert.AreEqual(dialogId, dialogResponse.Value.DialogId);

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.NotNull(dialogStartedReceived);
                Assert.IsTrue(dialogStartedReceived is DialogStarted);

                // send a new dialog with same ID but different context, should fail
                dialogOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "new context"
                };
                Assert.ThrowsAsync<RequestFailedException>(() => callDialog.StartDialogAsync(dialogOptions));

                // send a new dialog with different ID, should fail
                string secondDialogId = "de7fcbc8-1803-4ec1-80ed-2c9c087587f6";
                dialogOptions = new StartDialogOptions(secondDialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                Assert.ThrowsAsync<RequestFailedException>(() => callDialog.StartDialogAsync(dialogOptions));

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

        [RecordedTest]
        [Ignore("MPaaS currently does not have a version of updateDialog applied")]
        public async Task DialogOperationsTest_AzureOpenAI()
        {
            // ignores test if PMA Endpoint is not set in environment variables
            var endpoint = TestEnvironment.PMAEndpoint;
            if (endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(dialogId, new AzureOpenAIDialog(dialogContext))
                {
                    OperationContext = "context"
                };
                var startDialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, startDialogResponse.GetRawResponse().Status);

                Assert.AreEqual(dialogId, startDialogResponse.Value.DialogId);

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.NotNull(dialogStartedReceived);
                Assert.IsTrue(dialogStartedReceived is DialogStarted);

                // send an UpdateDialog call, it does not currently cause a returning event
                var updateDialogOptions = new UpdateDialogOptions(dialogId, new AzureOpenAIDialogUpdate(dialogId, dialogContext));
                var updateDialogResponse = await callDialog.UpdateDialogAsync(updateDialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status200OK, updateDialogResponse.Status);

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

        [RecordedTest]
        public async Task IdenticalDialogsTest()
        {
            // ignores test if botAppId or PMA Endpoint is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            var endpoint = TestEnvironment.PMAEndpoint;
            if (botAppId == null || endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                Assert.AreEqual(dialogId, dialogResponse.Value.DialogId);

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.NotNull(dialogStartedReceived);
                Assert.IsTrue(dialogStartedReceived is DialogStarted);

                // send the start dialog again, should succeed
                dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

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

        [RecordedTest]
        public async Task SubsequentDialogsTest()
        {
            // ignores test if botAppId or PMA Endpoint is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            var endpoint = TestEnvironment.PMAEndpoint;
            if (botAppId == null || endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialogOptions dialogOptions = new StartDialogOptions(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                Assert.NotNull(dialogResponse.Value.DialogId);
                Assert.AreEqual(dialogId, dialogResponse.Value.DialogId);

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

                string secondDialogId = "de7fcbc8-1803-4ec1-80ed-2c9c087587fd";
                dialogOptions = new StartDialogOptions(secondDialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };

                // Start and stop the dialog again, it should work fine
                dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status201Created, dialogResponse.GetRawResponse().Status);

                Assert.NotNull(dialogResponse.Value.DialogId);
                Assert.AreEqual(secondDialogId, dialogResponse.Value.DialogId);

                stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status204NoContent, stopDialogResponse.GetRawResponse().Status);
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
        public async Task StopNonexistingDialogTest()
        {
            // ignores test if botAppId or PMA Endpoint is not set in environment variables
            var botAppId = TestEnvironment.BotAppId;
            var endpoint = TestEnvironment.PMAEndpoint;
            if (botAppId == null || endpoint == null)
            {
                Assert.Ignore();
            }

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
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();
                var unusedDialogId = "daa16e13-0605-4170-8411-24e012a7e91b";

                // stop a non-existing dialog, should pass without event
                var stopDialogResponse = await callDialog.StopDialogAsync(unusedDialogId).ConfigureAwait(false);
                Assert.AreEqual(StatusCodes.Status204NoContent, stopDialogResponse.GetRawResponse().Status);
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
