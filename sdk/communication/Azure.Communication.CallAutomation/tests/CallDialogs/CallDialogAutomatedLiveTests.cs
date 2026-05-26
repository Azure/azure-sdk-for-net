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
        [Ignore("botid not set properly")]
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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.That(connectedEvent is CallConnected, Is.True);
            Assert.That(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId, Is.True);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialog dialogOptions = new StartDialog(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                var checkedDialogId = dialogResponse.Value.DialogId;
                Assert.That(dialogResponse.Value.DialogId, Is.Not.Null);
                Assert.That(Guid.TryParse(checkedDialogId, out var result), Is.True);
                Assert.That(dialogId, Is.EqualTo(checkedDialogId));

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStartedReceived, Is.Not.Null);
                Assert.That(dialogStartedReceived is DialogStarted, Is.True);

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(checkedDialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));

                var dialogStoppedReceived = await WaitForEvent<DialogCompleted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStoppedReceived, Is.Not.Null);
                Assert.That(dialogStoppedReceived is DialogCompleted, Is.True);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        [Ignore("botid not set properly")]
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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.That(connectedEvent is CallConnected, Is.True);
            Assert.That(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId, Is.True);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialog dialogOptions = new StartDialog(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                Assert.That(dialogResponse.Value.DialogId, Is.EqualTo(dialogId));

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStartedReceived, Is.Not.Null);
                Assert.That(dialogStartedReceived is DialogStarted, Is.True);

                // send a new dialog with same ID but different context, should fail
                dialogOptions = new StartDialog(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "new context"
                };
                Assert.ThrowsAsync<RequestFailedException>(() => callDialog.StartDialogAsync(dialogOptions));

                // send a new dialog with different ID, should fail
                string secondDialogId = "de7fcbc8-1803-4ec1-80ed-2c9c087587f6";
                dialogOptions = new StartDialog(secondDialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                Assert.ThrowsAsync<RequestFailedException>(() => callDialog.StartDialogAsync(dialogOptions));

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));

                var dialogStoppedReceived = await WaitForEvent<DialogCompleted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStoppedReceived, Is.Not.Null);
                Assert.That(dialogStoppedReceived is DialogCompleted, Is.True);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        [Ignore("botid not set properly")]
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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.That(connectedEvent is CallConnected, Is.True);
            Assert.That(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId, Is.True);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialog dialogOptions = new StartDialog(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                Assert.That(dialogResponse.Value.DialogId, Is.EqualTo(dialogId));

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStartedReceived, Is.Not.Null);
                Assert.That(dialogStartedReceived is DialogStarted, Is.True);

                // send the start dialog again, should succeed
                dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));

                var dialogStoppedReceived = await WaitForEvent<DialogCompleted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStoppedReceived, Is.Not.Null);
                Assert.That(dialogStoppedReceived is DialogCompleted, Is.True);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        [Ignore("botid not set properly")]
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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.That(connectedEvent is CallConnected, Is.True);
            Assert.That(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId, Is.True);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();

                // send the dialog to the target user
                var dialogContext = new Dictionary<string, object>();
                StartDialog dialogOptions = new StartDialog(dialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };
                var dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                Assert.That(dialogResponse.Value.DialogId, Is.Not.Null);
                Assert.That(dialogResponse.Value.DialogId, Is.EqualTo(dialogId));

                // wait for DialogStarted event
                var dialogStartedReceived = await WaitForEvent<DialogStarted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStartedReceived, Is.Not.Null);
                Assert.That(dialogStartedReceived is DialogStarted, Is.True);

                // stop the dialog
                var stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));

                var dialogStoppedReceived = await WaitForEvent<DialogCompleted>(targetCallConnectionId, TimeSpan.FromSeconds(20));
                Assert.That(dialogStoppedReceived, Is.Not.Null);
                Assert.That(dialogStoppedReceived is DialogCompleted, Is.True);

                string secondDialogId = "de7fcbc8-1803-4ec1-80ed-2c9c087587fd";
                dialogOptions = new StartDialog(secondDialogId, new PowerVirtualAgentsDialog(botAppId, dialogContext))
                {
                    OperationContext = "context"
                };

                // Start and stop the dialog again, it should work fine
                dialogResponse = await callDialog.StartDialogAsync(dialogOptions).ConfigureAwait(false);
                Assert.That(dialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status201Created));

                Assert.That(dialogResponse.Value.DialogId, Is.Not.Null);
                Assert.That(dialogResponse.Value.DialogId, Is.EqualTo(secondDialogId));

                stopDialogResponse = await callDialog.StopDialogAsync(dialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId, uniqueId);
            }
        }

        [RecordedTest]
        [Ignore("botid not set properly")]
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
            Assert.That(response.CallConnectionProperties.CallConnectionId, Is.Not.Empty);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.That(incomingCallContext, Is.Not.Null);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            AnswerCallResult answerResponse = await client.AnswerCallAsync(answerCallOptions);
            var targetCallConnectionId = answerResponse.CallConnectionProperties.CallConnectionId;

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.That(connectedEvent, Is.Not.Null);
            Assert.That(connectedEvent is CallConnected, Is.True);
            Assert.That(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId, Is.True);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.That(properties.Value.CallConnectionState, Is.EqualTo(CallConnectionState.Connected));

            try
            {
                var callDialog = client.GetCallConnection(targetCallConnectionId).GetCallDialog();
                var unusedDialogId = "daa16e13-0605-4170-8411-24e012a7e91b";

                // stop a non-existing dialog, should pass without event
                var stopDialogResponse = await callDialog.StopDialogAsync(unusedDialogId).ConfigureAwait(false);
                Assert.That(stopDialogResponse.GetRawResponse().Status, Is.EqualTo(StatusCodes.Status204NoContent));
            }
            catch (RequestFailedException ex)
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